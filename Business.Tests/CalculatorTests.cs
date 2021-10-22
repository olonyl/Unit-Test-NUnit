using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Business.Tests
{
    public class CalculatorTests
    {
        [Test]
        public void AddNumber_ValidValues_ReturnsCorrectRestult()
        {
            var sut = new Calculator();
            int result = sut.AddNumbers(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }
    }
}
