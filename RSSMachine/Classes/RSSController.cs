using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Usable;

namespace RSSMachine
{
    /// <summary>
    /// Адресное пространство.
    /// </summary>
    enum Address
    {
        Cells = 0x00,       //Ячейки.
        Control = 0x80,     //Пульт кассира.
        Dispatcher = 0xC0   //Диспетчер.
    }

    public class ControlStatus
    {
        public ControlStatus()
        {
            btnAllow = false;
            btnDeny = false;
        }

        public bool btnAllow { get; set; }

        public bool btnDeny { get; set; }
    }

    public class RSSController
    {
        public RSSController(string portName)
        {
            PortName = portName;
            port = new SerialPort(portName, 115200, Parity.None, 8, StopBits.OnePointFive);
            port.ReadTimeout = 1000;
            port.WriteTimeout = 1000;

            ControlStatus = new ControlStatus();
            LoopSuccessCounter = 0;
            LoopFaultCounter = 0;

            LoopThread = new Thread(LoopMapInfo);
            LoopThread.Start();

            cycleTime = new Stopwatch();
            CycleSpan = new TimeSpan();

            queueLock = new object();
            queueActions = new Collection<Action>();
        }

        /// <summary>
        /// COM-порт.
        /// </summary>
        SerialPort port;

        Task loop;

        Thread LoopThread;

        string PortName;

        /// <summary>
        /// Диагностика выполнения одного цикла.
        /// </summary>
        Stopwatch cycleTime;

        /// <summary>
        /// Время выполнения одного цикла.
        /// </summary>
        public TimeSpan CycleSpan { get; private set; }

        /// <summary>
        /// Статус пульта кассира.
        /// </summary>
        public ControlStatus ControlStatus { get; set; }

        /// <summary>
        /// Счетчик удачнных запросов.
        /// </summary>
        public int LoopSuccessCounter { get; set; }

        /// <summary>
        /// Счетчик неудачных запросов.
        /// </summary>
        public int LoopFaultCounter { get; set; }

        /// <summary>
        /// Блокировка доступа к queueActions.
        /// </summary>
        private object queueLock;

        /// <summary>
        /// Очередь комманд на выполнение.
        /// </summary>
        private Collection<Action> queueActions;

        /// <summary>
        /// Количество задач в очереди.
        /// </summary>
        public int QueueCount
        {
            get { return queueActions.Count; }
        }

        public async void Beep(byte Count = 3)
        {
            //SendCommand(new byte[] { (byte)Address.Control, 0x27, Count });

            lock(queueLock)
                queueActions.Add(() =>
                    {
                        SendCommand(new byte[] { (byte)Address.Control, 0x27, Count });
                        Thread.Sleep(200);
                    });
        }

        /// <summary>
        /// Получение статуса с пульта кассира.
        /// </summary>
        public void GetControlStatus()
        {
            SendCommand(new byte[] { (byte)Address.Control, 0x2 });

            Thread.Sleep(100);

            for (int i = 0; i < 10; i++)
            {
                byte[] buffer = RecieveAnswer();

                if (buffer[0] == (byte)Address.Control /*&& buffer[1] == 0x2*/)
                {
                    BitArray bitArray = new BitArray(new byte[] { buffer[4] });
                    ControlStatus.btnAllow = bitArray[0];
                    ControlStatus.btnDeny = bitArray[1];
                    break;
                }
            }
        }

        /// <summary>
        /// Отправка команад в контроллер с расчетом котрольной суммы.
        /// </summary>
        /// <param name="bytes">Байты команды.</param>
        private void SendCommand(byte[] bytes)
        {
            byte[] byteReals = new byte[bytes.Length + 1];
            for (int i = 0; i < bytes.Length; i++)
                byteReals[i] = bytes[i];
            byteReals[bytes.Length] = Cs_Calc(ref bytes, (uint)bytes.Length);
            port.Write(byteReals, 0, byteReals.Length);
        }

        /// <summary>
        /// Получение ответа от контроллера.
        /// </summary>
        /// <returns></returns>
        private byte[] RecieveAnswer()
        {
            byte[] buffer = new byte[port.ReadBufferSize];
            port.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        private void LoopMapInfo()
        {
            while (true)
            {
                cycleTime.Restart();
                try
                {
                    ThreadEx.CallTimedOutMethodSync(CycleMethod, 5000);
                    port.Close();                    
                }
                catch
                {
                    LoopFaultCounter++;
                }
                cycleTime.Stop();
                CycleSpan = cycleTime.Elapsed;
            }
        }

        private void CycleMethod()
        {
            try
            {
                if (!port.IsOpen)
                    port.Open();

                //Выполнение задач из очереди.
                List<Action> finished = new List<Action>();
                foreach (Action act in queueActions)
                {
                    act();
                    finished.Add(act);
                }
                //Удаление отработанных задач из очереди.
                lock (queueLock)
                {
                    foreach (Action act in finished)
                        queueActions.Remove(act);
                }

                GetControlStatus();

                port.Close();

                //Thread.Sleep(2000);
                LoopSuccessCounter++;
            }
            catch
            {
                LoopFaultCounter++;
            }
        }

        public void ReloadLoop()
        {
            try
            {
                /*
                LoopThread.Abort();
                Thread.Sleep(1000);

                port.Close();

                port.Dispose();

                port = new SerialPort(PortName, 115200, Parity.None, 8, StopBits.OnePointFive);

                Thread loopThread = new Thread(LoopMapInfo);
                loopThread.Start();
                */
                /*
                VolumeDeviceClass volumeDeviceClass = new VolumeDeviceClass();
                foreach (Volume device in volumeDeviceClass.Devices)
                {
                    // is this volume on USB disks?
                    if (!device.IsUsb)
                        continue;

                    // is this volume a logical disk?
                    if ((device.LogicalDrive == null) || (device.LogicalDrive.Length == 0))
                        continue;

                    device.Eject(true); // allow Windows to display any relevant UI
                }
                */
            }
            catch { }
        }

        /// <summary>
        /// Расчет контрольной суммы.
        /// </summary>
        /// <param name="buf">Массив входных байнов.</param>
        /// <param name="n">Количество байтов.</param>
        /// <returns></returns>
        private static byte Cs_Calc(ref byte[] buf, uint n)
        {
            byte cs = 0;
            for (uint a = 0; a < n; a++)
                cs += buf[a]++;
            cs++;
            cs = (byte)~cs;
            return cs;
        }
    }
}
