using System.Collections.Generic;

namespace DataStructures.BST
{
    public class Node
    {
        public int value;
        public Node Left;
        public Node Right;
    }
    public class Tree
    {

        /// <summary>
        /// Balance a tree
        /// </summary>
        /// <param name="values"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public Node BalanceTree(IList<int> values, int min, int max)
        {
            if (min == max)
            {
                return null;
            }
            int median = min + (max - min) / 2;
            return new Node
            {
                Left = BalanceTree(values, min, median),
                Right = BalanceTree(values, median + 1, max),
                value = values[median]
            };

        }
        /// <summary>
        /// Traverse through nodes
        /// </summary>
        /// <param name="root"></param>
        public void Traverse(Node root)
        {
            if (root == null)
            {
                return;
            }
            Traverse(root.Left);
            Traverse(root.Right);
        }
    }
}
