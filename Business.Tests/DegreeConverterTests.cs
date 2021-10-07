using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Business.Tests
{
    public class DegreeConverterTests
    {
        [Test]
        public void ToFahrenheit_0Celcius_Returns32()
        {
            var converter = new DegreeConverter();
            double result = converter.ToFahrenheit(0);

            Assert.That(result, Is.EqualTo(32));
        }

        [Test]
        public void ToCelsius_32Fahrenheit_Returns0()
        {
            var converter = new DegreeConverter();
            double result = converter.ToCelsius(32);

            Assert.That(result, Is.EqualTo(0));
        }
    }
}
