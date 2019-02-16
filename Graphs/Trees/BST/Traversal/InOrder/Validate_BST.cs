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
        if (root == null) return true;
        Stack<TreeNode> st = new Stack<TreeNode>();
  Stack<int> upper_limits = new Stack<int>();
  Stack<int> lower_limits = new Stack<int>();
  st.Push(root);
  upper_limits.Push(null);
  lower_limits.Push(null);

  while(st.Any()){
      TreeNode node = st.Pop();
      int lower = lower_limits.Pop();
      int upper = upper_limits.Pop();

      if(node.right != null){
          if(node.right.val > node.val){
              if(upper != null && (node.right.val >= upper)) return false;
              st.Push(node.right);
              lower_limits.Push(node.val);
              upper_limits.Push(upper);
          }
          else{
              return false;
          }
      }
      if(node.left != null){
if(node.left.val < node.val){
    if(lower != null && (node.left.val <= lower)){
        lower_limits.Push(lower);
        upper_limits.Push(node.val);
    }
    else{
        return false;
    }
    }
        return true;
      }
  }
    }
}
