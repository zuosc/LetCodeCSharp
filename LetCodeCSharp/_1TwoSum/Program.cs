using System;
using System.Collections.Generic;
using System.Linq;

namespace _1TwoSum
{
    static class Program
    {
        static void Main(string[] args)
        {
/*       Given an array of integers, return indices of the two numbers such that they add up to a specific target.

         给你一个整形的数组，返回其中的两个值，使其相加为一个指定的数字
         You may assume that each input would have exactly one solution, and you may not use the same element twice.
         你可以假设每个输入都会有一个解决方案，而且你不能使用相同的元素两次
         
         Example:
         Given nums = [2, 7, 11, 15], target = 9,

         Because nums[0] + nums[1] = 2 + 7 = 9,
         eturn [0, 1].
*/
            var intArr = new int[] {2, 8, 1, 13, 7, 5, 11, 15};
            var target = 9;
            var tmp = TwoSum(intArr, target);

            Console.WriteLine($"index:{tmp[0]},value:{intArr[tmp[0]]}");
            Console.WriteLine($"index:{tmp[1]},value:{intArr[tmp[1]]}");
            Console.ReadKey();
        }


        /// <summary>
        /// 解决方案一
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <remarks>
        /// 1、循环数组，以每个元素为key，序号为value(因为有重复的，所以value为int数组)
        /// 2、for循环字典，每次循环拿到key，然后用目标数减去key值，拿到结果
        /// 3、用结果当key，直接取字典的这个key的value。若能取到，则查找到
        /// 4、拿不到就继续下一个，拿到了就直接得到结果
        /// </remarks>
        /// <returns></returns>
        private static int[] TwoSum(int[] numbers, int target)
        {
            var dictionary = new Dictionary<int, List<int>>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (dictionary.ContainsKey(numbers[i]))
                {
                    dictionary[numbers[i]].Add(i);
                }
                else
                {
                    dictionary.Add(numbers[i], new List<int> {i});
                }
            }

            foreach (var keyValuePair in dictionary)
            {
                var remained = target - keyValuePair.Key;
                if (!dictionary.TryGetValue(remained, out var listOfIndexes))
                {
                    continue;
                }


                if (remained == keyValuePair.Key && listOfIndexes.Count > 1)
                {
                    var result = listOfIndexes.GetRange(0, 2);
                    result.Sort();
                    return result.ToArray();
                }

                if (remained != keyValuePair.Key && listOfIndexes.Count > 0)
                {
                    var result = new List<int>() {keyValuePair.Value[0], listOfIndexes[0]};
                    result.Sort();
                    return result.ToArray();
                }
            }

            return null;
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <remarks>
        /// 1、方法和1其实一样，只不过在循环加入字典的时候，就进行匹配。
        /// 2、若匹配到，直接结束
        /// 3、好处是不用循环整个数字，运气最差的时候，才要循环整个数组
        /// </remarks>
        /// <returns></returns>
        public static int[] TwoSumSolutionTwo(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var aim = target - nums[i];
                if(dict.ContainsKey(aim))
                {
                    return new int[] { dict[aim], i };
                }
                else
                {
                    if(!dict.ContainsKey(nums[i]))
                        dict.Add(nums[i], i);
                }
            }

            return null;
        }
    }
}