using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP
{
    public class Repository : IRepository
    {
        public string Save()
        {
            return "I am saving data to Database.";
        }
    }
}
