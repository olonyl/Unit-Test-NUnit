using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TDD_UnitTest
{
    public class RomanNumeralTests
    {
        [TestCase(1,"I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(2, "II")]
        [TestCase(4, "IV")]
        [TestCase(554, "DLIV")]
        [TestCase(14, "XIV")]
        [TestCase(9, "IX")]
        [TestCase(555, "DLV")]
        public void Parse(int expected, string roman)
        {
            Assert.AreEqual(expected, Roman.Parse(roman));
        }
    }
    internal class Roman
    {
        private static Dictionary<char, int> map = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000},
        };
        internal static double Parse(string roman)
        {
            var result = 0;
            
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && IsSubstractive(roman[i] , roman[i + 1]))
                    result -= map[roman[i]];
                else result += map[roman[i]];
            }
            return result;
        }
        private static bool IsSubstractive(char v1, char v2)
        {
           return map[v1] < map[v2];
        }
    }
}
