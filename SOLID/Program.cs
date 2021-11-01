using SOLID.DIP;
using SOLID.DIP.IoC_Container;
using System;

namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            //registering dependences  to Container
            var resolver = new SimpleIoC();
            resolver.Register<IRepository, TextRepository>();
            resolver.Register<PurchaseBl, PurchaseBl>();
            // Resolving dependences
            var purchaseBl = resolver.Resolve<PurchaseBl>();
            Console.WriteLine(purchaseBl.SavePurchaseOrder());
        }
    }
}
