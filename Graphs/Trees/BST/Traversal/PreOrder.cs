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

public class Solution_PreOrderTraversal {
    public IList<int> PreOrderTraversal(TreeNode root) {
        IList<int> res = new List<int>();
        if(root == null) return res;

        Stack<TreeNode> st = new Stack<TreeNode>();
        TreeNode curr = root;
        while(curr != null || st.Any()){
            if(curr != null){
            st.Push(curr);
            res.Add(curr.val);
            curr = curr.left;
            }
            else{
                curr = st.Pop();
                curr = curr.right;
            }
        }
        return res;
    }
    /// <summary>
    /// Pre Order Traversal Recursive
    /// 1. Visit the root node
    /// 2. Traverse the left subtree
    /// 3. Traverse the right subtree
    /// </summary>
    /// <param name="rootNode"></param>
    public void PreOrder(TreeNode rootNode)
    {
        Console.WriteLine(rootNode.val.ToString());
        if (rootNode.left != null)
        {
            PreOrder(rootNode.left);
        }
        if (rootNode.right != null)
        {
            PreOrder(rootNode.right);
        }
    }
}