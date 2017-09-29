using System;
using System.Collections.Generic;

namespace _13RomanToInteger
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Given a roman numeral, convert it to an integer.
             给定一个罗马数字，转化为整数
            Input is guaranteed to be within the range from 1 to 3999.
            输入确定范围在1-3999之间

            
                          基本字符  I    V     X     L      C      D      M
            相应的阿拉伯数字表示为  1    5    10    50     100    500    1000

            1、相同的数字连写，所表示的数等于这些数字相加得到的数，如：Ⅲ = 3；
            2、小的数字在大的数字的右边，所表示的数等于这些数字相加得到的数， 如：Ⅷ = 8；Ⅻ = 12；
            3、小的数字，（限于Ⅰ、X 和C）在大的数字的左边，所表示的数等于大数减小数得到的数，如：Ⅳ= 4；Ⅸ= 9；
            4、正常使用时，连写的数字重复不得超过三次。
            5、在一个数的上面画一条横线，表示这个数扩大1000倍。
             */

            var romanStr = "MMMCMXCIX";
            var num = RomanToInt(romanStr);

            Console.WriteLine(num);
            Console.ReadKey();
        }

        public static int RomanToInt(string str)
        {
            int res = 0;
            var dic = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };

            for (int i = 0; i < str.Length; ++i)
            {
                int val = dic[str[i]];
                if (i == str.Length - 1 || dic[str[i + 1]] <= dic[str[i]])
                {
                    res += val;
                }
                else
                {
                    res -= val;
                }
            }
            return res;
        }


        public static int RomanToIntTwo(string str)
        {
            int res = 0;
            var dic = new Dictionary<char, int> { { 'I', 1}, { 'V', 5}, { 'X', 10}, { 'L', 50}, { 'C', 100}, { 'D', 500}, { 'M', 1000} };

            for (int i = 0; i < str.Length; ++i)
            {
                if (i == 0 || dic[str[i]] <= dic[str[i - 1]]) res += dic[str[i]];
                else res += dic[str[i]] - 2 * dic[str[i - 1]];
            }
            return res;
        }
    }
}
