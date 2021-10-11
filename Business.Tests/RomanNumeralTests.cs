using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Business.Tests
{
    public class RomanNumeralTests
    {
        [TestCaseSource(typeof(RomanNumeralSource))]
        public void Parse(int expected, string roman)
        {
            Assert.AreEqual(expected, RomanNumeral.Parse(roman));
        }
        public class RomanNumeralSource : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new dynamic[] { 1, "I" };
                yield return new dynamic[] { 5, "V" };
                yield return new dynamic[] { 2, "II" };
                yield return new dynamic[] { 4, "IV" };
            }
        }
    }
    
}
