using System.Collections.Generic;

namespace DataStructures.Trees.BST.Traversal
{
    public class LevelOrder
    {
        public IList<IList<int>> LevelOrderTraversal(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null) return res;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int size = q.Count;
                IList<int> lvl = new List<int>();
                while (size > 0)
                {
                    TreeNode node = q.Dequeue();
                    lvl.Add(node.val);
                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                    size--;
                }
                res.Add(lvl);
            }
            return res;
        }
        IList<IList<int>> levels = new List<IList<int>>();
        public IList<IList<int>> LevelOrderTraversal_Recursive(TreeNode root)
        {
            if (root == null)
            {
                return levels;
            }
            Helper(root,0);
            return levels;
        }

        private void Helper(TreeNode root, int level)
        {
            // start at the currenr level
            if (levels.Count == level)
            {
                levels.Add(new List<int>());
            }
            // fill the current level
            levels[level].Add(root.val);

            // process child nodes
            if (root.left != null)
            {
                Helper(root.left, level + 1);
            }
            if(root.right != null)
            {
                Helper(root.right, level + 1);
            }
        }
    }
}
