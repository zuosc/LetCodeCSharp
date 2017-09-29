using System;

namespace _639DecodeWaysII
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             A message containing letters from A-Z is being encoded to numbers using the following mapping way:
             使用以下映射方式将包含A-Z字母的消息编码为数字：

            'A' -> 1
            'B' -> 2
            ...
            'Z' -> 26
            Beyond that, now the encoded string can also contain the character '*', which can be treated as one of the numbers from 1 to 9.
            除此之外，现在编码的字符串还可以包含字符“*”，可以将其视为1到9之间的数字之一。

            Given the encoded message containing digits and the character '*', return the total number of ways to decode it.
            给定包含数字和字符'*'的编码消息，返回解码方式的总数。
            Also, since the answer may be very large, you should return the output mod 10^9 + 7.
            此外，由于答案可能非常大，您应该返回输出与10^9 + 7进行取余。

            Example 1:
            Input: "*"
            Output: 9
            Explanation: The encoded message can be decoded to the string: "A", "B", "C", "D", "E", "F", "G", "H", "I".
            Example 2:
            Input: "1*"
            Output: 9 + 9 = 18
            Note:
            The length of the input string will fit in range [1, 10^5].
            The input string will only contain the character '*' and digits '0' - '9'.
           */

            var tmp = NumDecodings("12124564456*");


            Console.WriteLine(tmp);
            Console.ReadKey();
        }



        private static int NumDecodings(string s)
        {
            int e0 = 1, e1 = 0, e2 = 0, f0, f1, f2, M = 1 * 10 ^ 9 + 7;
            foreach (char c in s)
            {
                if (c == '*')
                {
                    f0 = 9 * e0 + 9 * e1 + 6 * e2;
                    f1 = e0;
                    f2 = e0;
                }
                else
                {
                    f0 = ((c > '0') ? 1 : 0) * e0 + e1 + ((c <= '6') ? 1 : 0) * e2;
                    f1 = ((c == '1') ? 1 : 0) * e0;
                    f2 = ((c == '2') ? 1 : 0) * e0;
                }
                e0 = f0 % M;
                e1 = f1;
                e2 = f2;
            }
            return e0;
        }
    }
}
