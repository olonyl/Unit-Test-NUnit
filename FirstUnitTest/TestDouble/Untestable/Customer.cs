using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.TestDouble.Untestable
{
    public class Customer
    {
        private readonly Logger _logger = new Logger();
        public decimal CalculateWage(int id)
        {
            DbGateway gateway = new DbGateway();
            WorkingStatistics ws = gateway.GetWorkingStatistics(id);

            decimal wage;
            if (ws.PayHourly)
            {
                wage = ws.WorkingHours * ws.HourSalary;
            }
            else
            {
                wage = ws.MonthSalary;
            }
            _logger.Info($"Customer ID={id}, Wage:{wage}");

            return wage;
        }
    }   
}

internal class Logger
{
    public void Info(string s)
    {
        File.WriteAllText(@"C:\tmp:\log.txt", s);
    }
}

public class DbGateway
{
    public WorkingStatistics GetWorkingStatistics(int id)
    {
        //a real gateway can experience any possible problems
        //like "no connection" throwing an exception
        throw new NoConnection();
    }
}

public class NoConnection : Exception
{
}

public class WorkingStatistics
{
    public decimal HourSalary { get; set; }
    public int WorkingHours { get; set; }
    public decimal MonthSalary { get; set; }
    public bool PayHourly { get; set; }
}