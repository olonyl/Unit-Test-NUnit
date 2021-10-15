using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.SetupAndTeardown.TestDouble
{
    public class DbGatewayStub : IDbGateway
    {
        private WorkingStatistics _ws;

        public bool Connected { get; }

        public WorkingStatistics GetWorkingStatistics(int id)
        {
            return _ws;
        }
        public void SetWorkingStatistics(WorkingStatistics ws)
        {
            _ws = ws;
        }
    }
}
