using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Business.Tests
{
    public class FibonacciTests
    {
        [Test]
        public void TestFibonacci()
        {
            Assert.AreEqual(0, GetFibionacci(0));
        }

        private double GetFibionacci(int v)
        {
            return 0;
        }
    }
}
