using System;

namespace _461HammingDistance
{
    class Program
    {
        /*
            Hamming Distance 
            汉明距离(汉明权重)
            The Hamming distance between two integers is the number of positions at which the corresponding bits are different.
            两个等长字符串之间的汉明距离是两个整数对应位置的不同字符的个数（就是将一个字符串变换成另外一个字符串所需要替换的字符个数）
            Given two integers x and y, calculate the Hamming distance.
            Note:
            0 ≤ x, y< 2^31.

            Example:
            Input: x = 1, y = 4
            Output: 2

            Explanation:
            1   (0 0 0 1)
            4   (0 1 0 0)
                  ↑   ↑
            The above arrows point to positions where the corresponding bits are different.
        
        */

        static void Main(string[] args)
        {
            var distance = HammingDistance(0, 2147483647);//2147483647为int32最大值
            Console.WriteLine(distance);
            Console.ReadKey();
        }

        public static int HammingDistance(int x, int y)
        {
            //   x 0000 0000 0000 0000 0001
            //   y 0111 1111 1111 1111 1111
            //   ^
            // xor 0111 1111 1111 1111 1110
            int xor = x ^ y, count = 0;//异或 两个操作数的位中，相同则结果为0，不同则结果为1 所以xor为2147483646(0111 1111 1111 1110)
            for (int i = 0; i < 32; i++)
            {
                count += (xor >> i) & 1;//移位，不同的为1  与1相与。++就可以出结果了
            }
            return count;
        }
    }
}
