using System;
using System.Collections.Generic;

namespace _170TwoSumIII_DataStructureDesign
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            Design and implement a TwoSum class. It should support the following operations:add and find.
            设计和实现一个TwoSum类。他应该支持以下操作：增加和查找
            add - Add the number to an internal data structure.
            增加-增加一个数字到内部数据结构周昂
            find - Find if there exists any pair of numbers which sum is equal to the value.
            查找-查找是否存在任何一堆数字，其总和等于该值
            For example,
            add(1); add(3); add(5);
            find(4) -> true
            find(7) -> false
             */

            Console.WriteLine("Hello World!");
        }
    }


    public class TwoSum
    {
        Dictionary<int, int> hashtable;

        public TwoSum()
        {
            hashtable = new Dictionary<int, int>();
        }
        public void Add(int number)
        {
            if (hashtable.ContainsKey(number))
            {
                hashtable[number]++;
            }
            else
            {
                hashtable.Add(number, 1);
            }
        }

        public bool Find(int value)
        {
            foreach (var i in hashtable.Keys)
            {
                var valueToFind = value - i;

                if (valueToFind == i && hashtable[i] > 1)
                {
                    return true;
                }

                if (valueToFind != i && hashtable.ContainsKey(valueToFind))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
