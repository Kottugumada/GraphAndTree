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

namespace BST
{
    public class Solution_InorderSuccessor {
        /// <summary>
        /// https://leetcode.com/problems/inorder-successor-in-bst/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        Stack<TreeNode> st = new Stack<TreeNode>();
        TreeNode pre = null;
        if(root == null) return null;
        while(root != null || st.Any()){
            if(root != null){
                st.Push(root);
                root = root.left;
            } 
            else{
                root = st.Pop();
                if(pre == p){ return root;}
                else{
                    pre = root;
                    root = root.right;
                }
            }
        }
        return null;
    }
}
}