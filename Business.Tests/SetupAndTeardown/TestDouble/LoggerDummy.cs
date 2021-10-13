using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.SetupAndTeardown.TestDouble
{
    public class LoggerDummy : ILogger
    {
        public void Info(string s)
        {
            //do nothing
        }
    }
}
