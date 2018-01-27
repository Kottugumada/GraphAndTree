using System.Collections.Generic;

namespace DataStructures.Trees
{
    public class TreeDFS
    {

        public void Search(BST.Node rootNode)
        {
            Stack<BST.Node> searchStack = new Stack<BST.Node>();
            searchStack.Push(rootNode);

            while (searchStack.Count > 0)
            {
                var node = searchStack.Pop();

                if (node.left !=null)
                {
                    searchStack.Push(node.left);
                }
                if (node.right != null)
                {
                    searchStack.Push(node.right);
                }
            }
        }
    }
}
