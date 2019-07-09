using System.Collections.Generic;
using System.Linq;

namespace BST
{
    public class Solution
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;

            Stack<TreeNode> st = new Stack<TreeNode>();
            st.Push(root);

            while( root != null || st.Any()) {
                var node = st.Pop();
                if(node.left != null)
                {
                    node.left.val = node.val + node.left.val;
                    st.Push(node.left);
                }
                else if(node.right != null)
                {
                    node.right.val = node.val + node.right.val;
                    st.Push(node.right);
                }
                else if(node.left == null && node.right == null)
                {
                    if (node.val == sum) return true;
                }
            }
            return false;
        }
        public bool HasPathSum_Recursive(TreeNode root, int sum)
        {
            if (root == null) return false;
            if (root.left == null && root.right == null) {
                if (root.val == sum)
                    return true;
            }
            return HasPathSum_Recursive(root.left, sum - root.val) || HasPathSum_Recursive(root.right, sum - root.val);
        }
    }
}