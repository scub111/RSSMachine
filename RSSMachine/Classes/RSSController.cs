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

    public static class TaskEx
    {
        public static async Task<TResult> WithTimeout<TResult>(this Task<TResult> task, TimeSpan timeout)
        {
            if (task.Status != System.Threading.Tasks.TaskStatus.Running)
                task.Start();

            if (task == await Task.WhenAny(task, Task.Delay(timeout)))
            {
                return await task;
            }
            throw new TimeoutException();
        }

        /// <summary>
        /// Запуск задачи с таймалутом.
        /// </summary>
        /// <param name="timeout">Время, за которое она должна выполнится, мс.</param>
        /// <param name="generateExeption">Генерировать ли исключение, если вышло время</param>
        /// <param name="exeptionText">Сообщение исключения.</param>
        public static async Task<bool> WithTimeout(this Task<bool> task, TimeSpan timeout, bool generateExeption = false, string exeptionText = "")
        {
            if (task.Status != System.Threading.Tasks.TaskStatus.Running)
                task.Start();

            if (task == await Task.WhenAny(task, Task.Delay(timeout)))
            {
                return await task;
            }
            if (generateExeption)
                throw new Exception(exeptionText);
            else
            {
                Task<bool> newTask = new Task<bool>(() => false);
                newTask.Start();
                return newTask.Result;
            }
        }
    }

    public class RSSController
    {
        public RSSController()
        {
            ControlStatus = new ControlStatus();
            LoopSuccessCounter = 0;
            LoopFaultCounter = 0;

            waitHandle = new ManualResetEvent(false);

            LoopThread = new Thread(MainLoop);
            LoopThread.Start();

            cycleTime = new Stopwatch();
            CycleSpan = new TimeSpan();

            queueLock = new object();
            queueActions = new Collection<Action>();
        }

        public void PostContructor(string portName = "COM1", bool simulation = false)
        {
            PortName = portName;
            port = new RssMachineSerialPort(portName, simulation);
            port.ReadTimeout = 1000;
            port.WriteTimeout = 1000;
        }

        /// <summary>
        /// COM-порт.
        /// </summary>
        RssMachineSerialPort port;

        /// <summary>
        /// Главный циклический поток передачи данных с контроллером.
        /// </summary>
        Thread LoopThread;

        /// <summary>
        /// Объект синхронизации потоков.
        /// </summary>
        private EventWaitHandle waitHandle;

        /// <summary>
        /// Имя порта.
        /// </summary>
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
        /// Статус пульта кассира (симуляция).
        /// </summary>
        public ControlStatus ControlStatusSim
        { get { return port.ControlStatusSim; } }
            

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

        /// <summary>
        /// Поиск COM-порта RSS-контроллера.
        /// </summary>
        /// <returns></returns>
        public static string FindPortName()
        {
            string[] portNames = SerialPort.GetPortNames();
            foreach (string portName in portNames)
            {
                try
                {
                    RSSController rssController = new RSSController();
                    rssController.PostContructor(portName);
                    if (rssController.GetControlStatus(true))
                        return portName;
                }
                catch
                { }
            }

            return "";
        }

        /// <summary>
        /// Запуск задачи с таймалутом.
        /// </summary>
        /// <param name="task">Выполняемая задача.</param>
        /// <param name="millisecondsTimeout">Время, за которое она должна выполнится, мс.</param>
        /// <param name="generateExeption">Генерировать ли исключение, если вышло время</param>
        /// <param name="exeptionText">Сообщение исключения.</param>
        /// <returns></returns>
        private Task<bool> StartTaskTimeout(Task<bool> task, int millisecondsTimeout, bool generateExeption = false, string exeptionText = "")
        {
            if (task.Status != System.Threading.Tasks.TaskStatus.Running)
                task.Start();

            if (task.Wait(millisecondsTimeout))
                 return task;
            else
            {
                if (generateExeption)
                    throw new Exception(exeptionText);
                else
                {
                    Task<bool> newTask = new Task<bool>(() => false);
                    newTask.Start();
                    return newTask;
                }
            }
        }

        /// <summary>
        /// Звуковой сигнал.
        /// </summary>
        /// <param name="Count">Количество повторов</param>
        /// <returns></returns>
        public Task<bool> Beep(byte Count = 3)
        {
            Stopwatch stopWath = new Stopwatch();
            Action action = new Action(() =>
            {
                SendCommand(new byte[] { (byte)Address.Control, 0x27, Count });
                Thread.Sleep(200);
            });

            lock (queueLock)
                queueActions.Add(action);
            
            Task<bool> task = new Task<bool>(() =>
            {
                while (true)
                {
                    lock (queueActions)
                    {
                        if (!queueActions.Contains(action))
                            return true;
                    }
                    Thread.Sleep(100);
                }
            });
            return task.WithTimeout(TimeSpan.FromSeconds(5), true, "Beep timeout exeption.");
        }

        /// <summary>
        /// Ожидание измений статуса пульта управления.
        /// </summary>
        /// <returns></returns>
        public Task<bool> WaitControlStatusChanged()
        {
            TriggerT<bool> trgAllow = new TriggerT<bool>(ControlStatus.btnAllow);
            TriggerT<bool> trgDeny = new TriggerT<bool>(ControlStatus.btnDeny);

            Task<bool> task = new Task<bool>(() =>
            {
                while (true)
                {
                    if (trgAllow.Calculate(ControlStatus.btnAllow) ||
                        trgDeny.Calculate(ControlStatus.btnDeny))
                        return true;

                    Thread.Sleep(100);
                }
            });
            return task.WithTimeout(TimeSpan.FromSeconds(60), true, "WaitControlStatusChanged exeption");
        }

        /// <summary>
        /// Получение статуса с пульта кассира.
        /// </summary>
        public bool GetControlStatus(bool withOpenClosePort = false)
        {
            bool result = false;

            if (withOpenClosePort && !port.IsOpen)
                port.Open();


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
                    result = true;
                    break;
                }
            }

            if (withOpenClosePort)
                port.Close();

            return result;
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

        /// <summary>
        /// Запуск потока обмена информацией с контроллером.
        /// </summary>
        public void Start()
        {
            waitHandle.Set();
        }

        /// <summary>
        /// Останов потока обмена информацией с контроллером.
        /// </summary>
        public void Stop()
        {
            waitHandle.Reset();
        }

        private void MainLoop()
        {
            while (true)
            {
                waitHandle.WaitOne();

                cycleTime.Restart();
                try
                {
                    ThreadEx.CallTimedOutMethodSync(MainMethod, 5000);
                }
                catch
                {
                    LoopFaultCounter++;
                }
                cycleTime.Stop();
                CycleSpan = cycleTime.Elapsed;
            }
        }

        private void MainMethod()
        {
            try
            {
                if (!port.IsOpen)
                    port.Open();

                if (port.IsOpen)
                {
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

                    LoopSuccessCounter++;
                }
                else
                {
                    LoopFaultCounter++;
                    Thread.Sleep(1000);
                }
            }
            catch
            {
                LoopFaultCounter++;
                Thread.Sleep(1000);
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
