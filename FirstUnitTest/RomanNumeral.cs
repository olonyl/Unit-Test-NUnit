using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RomanNumeral
    {
        private static readonly Dictionary<char, int> Map = new Dictionary<char, int>()
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50  },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 },
        };

        public static int Parse (string roman)
        {
            int result = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if(i+1 < roman.Length && IsSubtractive(roman[i], roman[i + 1]))
                {
                    result -= Map[roman[i]];
                }
                else
                {
                    result += Map[roman[i]];
                }
                
            }
            return result;
        }

        private static bool IsSubtractive(char v1, char v2)
        {
            return Map[v1] < Map[v2];
        }
    }
}
