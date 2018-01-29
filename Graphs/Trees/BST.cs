using System;
using System.Collections.Generic;
using System.Text;

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
        /// Insert data
        /// </summary>
        /// <param name="root"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node Insert(Node root,int data)
        {
            if (root == null)
            {
                root = new Node();
                root.value = data;
            }
            else if (data < root.value)
            {
                root.Left = Insert(root.Left,data);
            }
            else
            {
                root.Right = Insert(root.Right, data);
            }
            return root;
        }

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
