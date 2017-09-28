using System;
using System.Collections.Generic;

namespace _657JudgeRouteCircle
{
    class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /*
            Initially, there is a Robot at position (0, 0). Given a sequence of its moves, judge if this robot makes a circle, which means it moves back to the original place.
            最初，位置（0，0）有一个机器人。给它一系列的动作，判断这个机器人是否产生了一个圆圈，这意味着它返回原来的位置。
            The move sequence is represented by a string. And each move is represent by a character. 
            移动序列由字符串表示。 每个动作都由一个字符代表。
            The valid robot moves are R (Right), L (Left), U (Up) and D (down). The output should be true or false representing whether the robot makes a circle.
            有效的移动是R（右），L（左），U（向上）和D（向下）。输出应为true或false，表示机器人是否绕了个圈。

            Example 1:
            Input: "UD"
            Output: true

            Example 2:
            Input: "LL"
            Output: false

             */


            Console.WriteLine("Hello World!");
        }

        private bool judgeCircle(string moves)
        {
            int cnt1 = 0, cnt2 = 0;
            foreach (char move in moves)
            {
                if (move == 'U') ++cnt1;
                else if (move == 'D') --cnt1;
                else if (move == 'L') ++cnt2;
                else if (move == 'R') --cnt2;
            }
            return cnt1 == 0 && cnt2 == 0;
        }


        private bool judgeCircleTwo(string moves)
        {
            var dict = new Dictionary<char, int>();

            foreach (char move in moves)
            {
                ++dict[move];
            }
            return dict['L'] == dict['R'] && dict['U'] == dict['D'];
        }
    }
}
