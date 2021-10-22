using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDD_UnitTest
{
    /*
     * If divisible by 3        ->  return "Fizz"
     * If divisible by 5        ->  return "Buzz"
     * If dibisible by 5 and 3  ->  return "FizzBuzz"
     * Otherwise                ->  return ""
     */
    public class FizzBuzzTests
    {
        [TestCase("Fizz",3)]
        [TestCase("Buzz", 5)]
        [TestCase("Fizz", 6)]
        [TestCase("Buzz", 10)]
        [TestCase("FizzBuzz", 15)]
        [TestCase("FizzBuzz", 30)]
        [TestCase("", 7)]
        public void TestFizzBuzz(string expected , int number)
        {
            Assert.AreEqual(expected, FizzBuzz(number));
        }

        private string FizzBuzz(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
                return "FizzBuzz";
            if (number % 3 == 0)
                return "Fizz";
            if (number % 5 == 0)
                return "Buzz";
            return "";
        }
    }
}
