using System;

namespace Graphs.Heaps.Trees.Trees.BST
{
    public class MaximumPathSum
    {
        int maxPathSum = int.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            PathSumHelper(root);
            return maxPathSum;
        }
        private int PathSumHelper(TreeNode root)
        {
            if (root == null)
                return 0;
            int left = PathSumHelper(root.left);
            int right =PathSumHelper(root.right);
            int currentMax = 0;

            currentMax = Math.Max(currentMax,Math.Max(left + root.val, right + root.val));
            maxPathSum = Math.Max(maxPathSum, left + root.val + right);
            return currentMax;
        }
    }
}
