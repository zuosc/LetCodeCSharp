using System;

namespace _617MergeTwoBinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             Given two binary trees and imagine that when you put one of them to cover the other,
             给定两个二叉树，并想象当你把其中一个覆盖另一个时，
             some nodes of the two trees are overlapped while the others are not.
             两棵树的一些节点重叠，而其他节点不重叠

             You need to merge them into a new binary tree. The merge rule is that if two nodes overlap, 
             您需要将它们合并成一个新的二叉树。 合并规则是如果两个节点重叠，
             then sum node values up as the new value of the merged node. Otherwise, 
             那么sum节点值作为合并节点的新值。 除此以外，
             the NOT null node will be used as the node of new tree.
             NOT空节点将被用作新树的节点。



                Example 1:
                Input: 
	                Tree 1                     Tree 2                  
                          1                         2                             
                         / \                       / \                            
                        3   2                     1   3                        
                       /                           \   \                      
                      5                             4   7                  
                Output: 
                Merged tree:
	                     3
	                    / \
	                   4   5
	                  / \   \ 
	                 5   4   7
                Note: The merging process must start from the root nodes of both trees.
             */


            Console.WriteLine("Hello World!");
        }

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            //如果一个tree为null的话就可以直接用另外一个tree來return
            if (t1 == null)
            {
                return t2;
            }
            if (t2 == null)
            {
                return t1;
            }

            return new TreeNode(t1.val + t2.val)
            {
                left = MergeTrees(t1.left, t2.left),
                right = MergeTrees(t1.right, t2.right)
            };
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
    }
}
