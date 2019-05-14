using System;
using System.Collections.Generic;

namespace DataStructures.BST
{
    public class Search
    {
        public void DFS(BST.Node rootNode)
        {
            Stack<BST.Node> searchStack = new Stack<BST.Node>();
            searchStack.Push(rootNode);

            while (rootNode != null || searchStack.Count > 0)
            {
                if (rootNode != null)
                {
                    searchStack.Push(rootNode);
                    rootNode = rootNode.Left;
                }
                var node = searchStack.Pop();

                if (node.Left != null)
                {
                    searchStack.Push(node.Left);
                }
                if (node.Right != null)
                {
                    searchStack.Push(node.Right);
                }
            }
        }
        /// <summary>
        /// Pre Order Traversal
        /// 1. Visit the root node
        /// 2. Traverse the left subtree
        /// 3. Traverse the right subtree
        /// </summary>
        /// <param name="rootNode"></param>
        public void PreOrder(BST.Node rootNode)
        {
            Console.WriteLine(rootNode.value.ToString());
            if (rootNode.Left != null)
            {
                PreOrder(rootNode.Left);
            }
            if (rootNode.Right != null)
            {
                PreOrder(rootNode.Right);
            }
        }
        /// <summary>
        /// Post Order Travesal
        /// 1. Traverse the left subtree.
        /// 2. Traverse the right subtree.
        //  3. Visit the root.
        /// </summary>
        /// <param name="rootNode"></param>
        public void PostOrder(BST.Node rootNode)
        {
            if (rootNode.Left != null)
            {
                PostOrder(rootNode.Left);
            }
            if (rootNode.Right != null)
            {
                PostOrder(rootNode.Right);
            }
            Console.WriteLine(rootNode.value.ToString());
        }
        /// <summary>
        /// In Order Traversal
        /// 1. Traverse left subtree
        /// 2. Visit root node
        /// 3. Traverse right subtree
        /// </summary>
        /// <param name="rootNode"></param>
        public void InOrder(BST.Node rootNode)
        {
            if (rootNode.Left != null)
            {
                InOrder(rootNode.Left);
            }
            Console.WriteLine(rootNode.value.ToString());
            if (rootNode.Right != null)
            {
                InOrder(rootNode.Right);
            }
        }
    }
}
