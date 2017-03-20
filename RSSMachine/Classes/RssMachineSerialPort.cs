using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RSSMachine
{
    /// <summary>
    /// Класс объмена данными с RSS с симуляцией.
    /// </summary>
    public class RssMachineSerialPort : SerialPort
    {
        public RssMachineSerialPort(string portName, bool simulation = false) : base(portName, 115200, Parity.None, 8, StopBits.OnePointFive)
        {
            this.simulation = simulation;
            ControlStatusSim = new ControlStatus();
        }

        /// <summary>
        /// Симуляция.
        /// </summary>
        bool simulation;

        /// <summary>
        /// Статус пульта кассира (симуляция).
        /// </summary>
        public ControlStatus ControlStatusSim { get; set; }

        public new void Open()
        {
            if (!simulation)
                base.Open();
            else
            {
                isOpen = true;
                Thread.Sleep(50);
            }
        }

        public new void Close()
        {
            if (!simulation)
                base.Close();
            else
            {
                isOpen = false;
                Thread.Sleep(50);
            }
        }

        private bool isOpen;
        public new bool IsOpen
        {
            get
            {
                if (!simulation)
                    return base.IsOpen;
                else
                    return isOpen;
            }
        }
        /// <summary>
        /// Конвертация BitArray в массив байтов.
        /// </summary>
        /// <param name="bits">Объект BitArray.</param>
        /// <returns></returns>
        public static byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }

        public new void Write(byte[] buffer, int offset, int count)
        {
            if (!simulation)
                base.Write(buffer, offset, count);
            else
            {
                //SendCommand(new byte[] { (byte)Address.Control, 0x27, Count });

                if (buffer.Length >= 3)
                {
                    if (buffer[0] == (byte)Address.Control && buffer[1] == 0x2)
                    {
                        readBufferSize = 5;
                        bufferSim = new byte[readBufferSize];
                        bufferSim[0] = (byte)Address.Control;

                        BitArray bitArray = new BitArray(8);
                        bitArray[0] = ControlStatusSim.btnAllow;
                        bitArray[1] = ControlStatusSim.btnDeny;

                        bufferSim[4] = BitArrayToByteArray(bitArray)[0];
                    }
                }

                if (buffer.Length >= 4)
                {
                    if (buffer[0] == (byte)Address.Control && buffer[1] == 0x27)
                    {
                        int repeat = buffer[2];
                        //SystemSounds.Beep.Play();
                        for (int i = 0; i < repeat; i++)
                        {
                            Console.Beep(3000, 200);
                            //Thread.Sleep(1000);
                        }
                    }
                }
            }
        }

        private int readBufferSize;
        public new int ReadBufferSize
        {
            get
            {
                if (!simulation)
                    return base.ReadBufferSize;
                else
                    return readBufferSize;
            }
        }

        private byte[] bufferSim;
        public new int Read(byte[] buffer, int offset, int count)
        {
            if (!simulation)
                return base.Read(buffer, offset, count);
            else
            {
                //buffer = bufferSim;
                //buffer[1] = (byte)Address.Control;
                for (int i = 0; i < readBufferSize; i++)
                    buffer[i] = bufferSim[i];

                return 0;
            }
        }

    }
}
