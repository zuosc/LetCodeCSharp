using System;
using System.Collections.Generic;

namespace _12IntegerToRoman
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             Given an integer, convert it to a roman numeral.
             给定一个整数，转化为罗马数字
            Input is guaranteed to be within the range from 1 to 3999.
            整数的范围确保在1-3999之间


                          基本字符  I    V     X     L      C      D      M
            相应的阿拉伯数字表示为  1    5    10    50     100    500    1000

             */
            var romanStr = GetRoman(3999);

            Console.WriteLine(romanStr);
            Console.ReadKey();
        }

        private static string GetRoman(int num)
        {
            List<string> v1 = new List<string> { "", "M", "MM", "MMM" };
            List<string> v2 = new List<string> { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            List<string> v3 = new List<string> { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            List<string> v4 = new List<string> { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string res = v1[num / 1000] + v2[(num % 1000) / 100] + v3[(num % 100) / 10] + v4[num % 10];
            return res;
        }

        private static string GetRomanTwo(int num)
        {
            string res = "";
            char[] roman = { 'M', 'D', 'C', 'L', 'X', 'V', 'I' };
            int[] value = { 1000, 500, 100, 50, 10, 5, 1 };

            for (int n = 0; n < 7; n += 2)
            {
                int x = num / value[n];
                if (x < 4)
                {
                    for (int i = 1; i <= x; ++i) res += roman[n];
                }
                else if (x == 4) res = res + roman[n] + roman[n - 1];
                else if (x > 4 && x < 9)
                {
                    res += roman[n - 1];
                    for (int i = 6; i <= x; ++i) res += roman[n];
                }
                else if (x == 9) res = res + roman[n] + roman[n - 2];
                num %= value[n];
            }
            return res;
        }
    }
}
