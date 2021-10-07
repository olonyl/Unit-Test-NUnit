using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SerialPortParser
    {
        public static int ParsePort(string port)
        {
            if (!port.StartsWith("COM"))
            {
                throw new FormatException("Port is not in a correct format.");
            }
            else
            {
                const int lastIndexOfPrefix = 3;
                string portNumber = port.Substring(lastIndexOfPrefix);
                return int.Parse(portNumber);
            }
        }
    }
}
