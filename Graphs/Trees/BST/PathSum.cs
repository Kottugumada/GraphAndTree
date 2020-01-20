using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class Solution
    {
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null) return false;

            Stack<TreeNode> st = new Stack<TreeNode>();
            Stack<int> sums = new Stack<int>();
            st.Push(root);
            sums.Push(sum);
            while( root != null || st.Any()) {
                var node = st.Pop();
                int value = sums.Pop();

                if(node.left != null)
                {
                    st.Push(node.left);
                    sums.Push(value - node.val);
                }
                else if(node.right != null)
                {
                    st.Push(node.right);
                    sums.Push(value - node.val);
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