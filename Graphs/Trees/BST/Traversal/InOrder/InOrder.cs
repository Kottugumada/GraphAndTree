// Definition for a binary tree node.
// Time and Space Complexity O(n)
//  public class TreeNode {
//      public int val;
//      public TreeNode left;
//      public TreeNode right;
//      public TreeNode(int x) { val = x; }
//  }
using System.Linq;
using System.Collections.Generic;
using System;

namespace BST
{
    public class InOrderSolution {
    public IList<int> InOrderTraversal(TreeNode root) {
        IList<int> res = new List<int>();
        if(root == null) return res;

        Stack<TreeNode> st = new Stack<TreeNode>();
        TreeNode curr = root;
        while(curr != null || st.Any()){
            if(curr != null){
            st.Push(curr);
            curr = curr.left;
            }
            else{
                curr = st.Pop();
                res.Add(curr.val);
                curr = curr.right;
            }
        }
        return res;
    }

        /// <summary>
        /// In Order Traversal Recursive
        /// 1. Traverse left subtree
        /// 2. Visit root node
        /// 3. Traverse right subtree
        /// </summary>
        /// <param name="rootNode"></param>
        public void InOrder(TreeNode rootNode)
        {
            if (rootNode.left != null)
            {
                InOrder(rootNode.left);
            }
            Console.WriteLine(rootNode.val.ToString());
            if (rootNode.right != null)
            {
                InOrder(rootNode.right);
            }
        }
    }
}