﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.SetupAndTeardown.TestDouble
{
    public class DbGatewaySpy : IDbGateway
    {
        private WorkingStatistics _ws;

        public int Id { get; private set; }

        public bool Connected { get; }

        public WorkingStatistics GetWorkingStatistics(int id)
        {
            Id = id;
            return _ws;
        }
        
        public void SetWorkingStatistics(WorkingStatistics ws)
        {
            _ws = ws;
        }
    }
}
