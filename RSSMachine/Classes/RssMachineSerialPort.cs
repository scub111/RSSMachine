using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSMachine
{
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
    }
}
