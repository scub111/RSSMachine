using System;
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
        }
        /// <summary>
        /// Симуляция.
        /// </summary>
        bool simulation;

        public new void Open()
        {
            if (!simulation)
                base.Open();
        }

        public new void Close()
        {
            if (!simulation)
                base.Close();
        }

        public new bool IsOpen
        {
            get
            {
                if (!simulation)
                    return base.IsOpen;
                else
                    return true;
            }
        }

        public new void Write(byte[] buffer, int offset, int count)
        {
            if (!simulation)
                base.Write(buffer, offset, count);
            else
            {
                //SendCommand(new byte[] { (byte)Address.Control, 0x27, Count });

                if (buffer.Length > 3)
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
    }
}
