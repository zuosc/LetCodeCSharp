﻿using System;

namespace _167TwoSumII
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Given an array of integers that is already sorted in ascending order,
             给定的整型数组是按照正序排列好的
             find two numbers such that they add up to a specific target number.
             找到两个数字，使他们相加正好为一个指定的数字

             The function twoSum should return indices of the two numbers such that they add up to the target, 
             函数twoSum应该返回两个数字的索引，使他们相加得到目标数
             where index1 must be less than index2. 
             index1必须小于index2
             Please note that your returned answers (both index1 and index2) are not zero-based.
             请注意，你返回的答案(index1和index2)都不是基于0的

            You may assume that each input would have exactly one solution and you may not use the same element twice.
            你可以假设每个输入都只有一种解决方式，你可能不会使用相同的元素两次
            Input: numbers={2, 7, 11, 15}, target=9
            Output: index1=1, index2=2         
            */

            var intArr = new int[] {1, 2, 5, 7, 8, 11, 13, 15};
            var target = 9;
            //var tmp = TwoSum(intArr, target);
            var tmp = TwoSum1(intArr, target);

            Console.WriteLine($"index:{tmp[0]},value:{intArr[tmp[0]-1]}");
            Console.WriteLine($"index:{tmp[1]},value:{intArr[tmp[1]-1]}");
            Console.ReadKey();
        }


        private static int[] TwoSum(int[] numbers, int target)
        {
            for (int i = 0, j = numbers.Length - 1; i < j;)
            {
                if (numbers[i] + numbers[j] == target)
                {
                    return new int[] {++i, ++j};
                }
                else if (numbers[i] + numbers[j] < target)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return new int[] {0, 0};
        }


        private static int[] TwoSum1(int[] numbers, int target)
        {
            int[] result = new int[2];
            //这里用二分搜索，我常用start和end来命名两头，middle是中间。
            int start = 0;
            int end = numbers.Length - 1;
            //这个while循环条件很巧妙，二分搜索建议固定一个模板，这个就挺好固定的。
            while (start + 1 < end)
            {
                //看，我刚说的是实话，而且这里middle的计算方法是防止越界。
                int middle = start + (end - start) / 2;
                if (numbers[start] + numbers[end] < target)
                {
                    //这里需要判断，到底是跳一半还是走一步，就再加个判断。
                    if (numbers[middle] + numbers[end] < target)
                    {
                        start = middle;
                    }
                    else
                    {
                        start++;
                    }
                }
                else if (numbers[start] + numbers[end] > target)
                {
                    if (numbers[start] + numbers[middle] > target)
                    {
                        end = middle;
                    }
                    else
                    {
                        end--;
                    }
                }
                else
                {
                    break;
                }
            }
            //题目中保证了有结果，还不是zero-based，那么就把result两项都续一秒。
            result[0] = start + 1;
            result[1] = end + 1;
            return result;
        }
    }
}