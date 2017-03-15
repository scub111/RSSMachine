using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSMachine
{
    public class RSSController
    {
        public RSSController(string portName)
        {
            port = new SerialPort(portName, 115200, Parity.None, 8, StopBits.OnePointFive);
        }

        /// <summary>
        /// COM-порт.
        /// </summary>
        SerialPort port;

        public async void Beep()
        {
            try
            {
                port.Open();
                port.ReadTimeout = 3000;

                var bytes = new byte[] { 0x80, 0x02 };
                var CS = Cs_Calc(ref bytes, 2);
                port.Write(new byte[] { 0x80, 0x02, CS }, 0, 3);

                await Task.Delay(100);
                bytes = new byte[] { 0x80, 0x27, (byte)3 };
                CS = Cs_Calc(ref bytes, 3);
                port.Write(new byte[] { 0x80, 0x27, (byte)3, CS }, 0, 4);
                port.Close();
            }
            catch
            {

            }
        }

        private static byte Cs_Calc(ref byte[] buf, uint n)
        {
            byte cs = 0;
            for (uint a = 0; a < n; a++)
            {
                cs += buf[a]++;
            }
            cs++;
            cs = (byte)~cs;
            return cs;
        }
    }
}
