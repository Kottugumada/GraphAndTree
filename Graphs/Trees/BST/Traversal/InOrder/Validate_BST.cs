 // Definition for a binary tree node.
  // Time and Space Complexity O(n)
 public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int x) { val = x; }
 }
public class Solution {
    public bool IsValidBST(TreeNode root) {
   Stack<TreeNode> st = new Stack<TreeNode>();
        TreeNode curr = root;
        TreeNode prev = null;
        while (curr != null || stack.Count > 0)
        {
            if (curr != null)
            {
                st.Push(curr);
                curr = curr.left;
            }
            else
            {
                curr = st.Pop();
                if (prev != null && prev.val >= curr.val) return false;
                prev = curr;
                curr = curr.right;
            }
        }
        
        return true;
    }
}
