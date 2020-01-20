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
            while (q.Count >0)
            {
                int size = q.Count;
                IList<int> lvl = new List<int>();
                while (size>0)
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
    }
}
