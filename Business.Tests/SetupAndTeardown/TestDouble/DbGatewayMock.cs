using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.SetupAndTeardown.TestDouble
{
    public class DbGatewayMock : IDbGateway
    {
        private WorkingStatistics _ws;

        public int Id { get; private set; }

        public WorkingStatistics GetWorkingStatistics(int id)
        {
            Id = id;
            return _ws;
        }

        public void SetWorkingStatistics(WorkingStatistics ws)
        {
            _ws = ws;
        }

        public bool VerifyCalledWithProperId(int id)
        {
            return Id == id;
        }
    }
}
