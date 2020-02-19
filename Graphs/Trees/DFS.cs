using System.Collections.Generic;

namespace DataStructures.BST
{
    public class Search
    {
        public void DFS(Node rootNode)
        {
            Stack<Node> searchStack = new Stack<BST.Node>();
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
    }
}
