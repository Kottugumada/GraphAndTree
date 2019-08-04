using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees.BST
{
   public class LCA
    {
        /*
         Traverse down the tree. At each node:
            if the node's value is smaller than both p and q, go right
            if it's bigger, go left
            otherwise, we've found the Lowest Common Ancestor
            Time Complexity: O(log n) if balanced tree, O(n) otherwise
            Space Complexity: O(1)
        */
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            if (root == null || p == null || q == null) return null;
            TreeNode curr = root;
            while(curr != null)
            {
                if (curr.val < p.val && curr.val < q.val)
                {
                    curr = curr.right;
                }
                else if(curr.val > p.val && curr.val > q.val){
                    curr = curr.left;
                }
                else
                {
                    return curr;
                }
            }
            return null;
        }
    }
}
