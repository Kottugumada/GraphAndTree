// https://leetcode.com/problems/kth-smallest-element-in-a-bst/

// Definition for a binary tree node.
// Time and Space Complexity O(n)
//  public class TreeNode {
//      public int val;
//      public TreeNode left;
//      public TreeNode right;
//      public TreeNode(int x) { val = x; }
//  }
using System;
using System.Linq;
using System.Collections.Generic;

namespace BST
{
    public class Solution_KthSmallest {
        /// <summary>
        /// https://leetcode.com/problems/kth-smallest-element-in-a-bst/
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthSmallest(TreeNode root, int k) {
        int count = 0;
        if(root == null) return count;

        Stack<TreeNode> st = new Stack<TreeNode>();
        while(root != null || st.Any()){
            if(root != null){
            st.Push(root);
            root = root.left;
            }
            else{
                root = st.Pop();
                count++;
                if(count == k) return root.val;
                root = root.right;
            }
        }
        return int.MinValue;
    }
}
}