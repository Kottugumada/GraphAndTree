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
using System.Text;
using System.Collections.Generic;

namespace BST {
public class BSTIterator {
    public Stack<TreeNode> st;
    public TreeNode curr;
    
    public BSTIterator(TreeNode root) {
        curr = root;
        st = new Stack<TreeNode>();
    }
    
    /** @return the next smallest number */
    public int Next() {
        int val = 0;
        while(st.Any() || curr != null){
            if(this.curr != null){
                st.Push(curr);
                curr = curr.left;
            }
            else{
                curr = st.Pop();
                val = curr.val;
                curr = curr.right;
                break;
            }
        }
        return val;
    }
    
    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return (st.Any() || curr != null);
    }
}
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */