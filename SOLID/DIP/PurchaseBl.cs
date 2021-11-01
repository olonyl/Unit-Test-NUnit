using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP
{
    public class PurchaseBl
    {
        private readonly IRepository _repository;
        public PurchaseBl(IRepository repository)
        {
            _repository = repository;
        }

        public string SavePurchaseOrder()
        {
            return _repository.Save();
        }
    }
}
