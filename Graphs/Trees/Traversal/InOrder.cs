 // Definition for a binary tree node.
 public class TreeNode {
     public int val;
     public TreeNode left;
     public TreeNode right;
     public TreeNode(int x) { val = x; }
 }
public class Solution {
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
}