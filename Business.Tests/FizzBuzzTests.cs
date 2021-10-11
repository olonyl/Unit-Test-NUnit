using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Business.Tests
{
    /*
    * If divisible by 3        -> return "Fizz"
    * If divisible by 5        -> return "Buzz"
    * If divisible by 3 and 5  -> return "FizBuzz"
    * Otherwise                -> return ""
    */
    public class FizzBuzzTests
    {
        [TestCaseSource(typeof(FizzBuzzSource))]
        public void TestFizzBuzz(string expected, int number)
        {
            //Assert.That(expected, Is.EqualTo(FizzBuzz.Ask(number)));
            Assert.AreEqual(expected, FizzBuzz.Ask(number));
        }
    }

    public class FizzBuzzSource : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new dynamic[] { "Fizz", 3 };
            yield return new dynamic[] { "Fizz", 6 };
            yield return new dynamic[] { "Buzz", 5 };
            yield return new dynamic[] { "Buzz", 10 };
            yield return new dynamic[] { "FizzBuzz", 15 };
            yield return new dynamic[] { "FizzBuzz", 30 };
            yield return new dynamic[] { "", 7 };
        }
    }
}
