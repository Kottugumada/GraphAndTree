using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.BST
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;
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
                root.left = Insert(root.left,data);
            }
            else
            {
                root.right = Insert(root.right, data);
            }
            return root;
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
            Traverse(root.left);
            Traverse(root.right);
        }
    }
}
