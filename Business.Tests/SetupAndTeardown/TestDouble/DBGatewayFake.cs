using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.SetupAndTeardown.TestDouble
{
    public class DBGatewayFake : IDbGateway
    {
        private Dictionary<int, WorkingStatistics> _storage = new Dictionary<int, WorkingStatistics>()
        {
            {1, new WorkingStatistics(){PayHourly= true, WorkingHours = 5, HourSalary = 10} },
            {1, new WorkingStatistics(){PayHourly= false, MonthSalary = 500} },
            {1, new WorkingStatistics(){PayHourly= true, WorkingHours = 8, HourSalary = 100} }
        };

        public bool Connected { get;  }

        public WorkingStatistics GetWorkingStatistics(int id)
        {
            return _storage[id];
        }
    }
}
