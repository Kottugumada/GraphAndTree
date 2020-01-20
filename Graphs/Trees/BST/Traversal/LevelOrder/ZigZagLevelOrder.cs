using System.Collections.Generic;
using System.Linq;

namespace Graphs.Heaps.Trees.Trees.BST.Traversal.LevelOrder
{
    public class ZigZagLevelOrder
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            IList<IList<int>> res = new List<IList<int>>();

            if (root == null) return res;
            q.Enqueue(root);
            bool zigzag = false;
            while (q.Any())
            {
                IList<int> lvl = new List<int>();
                int size = q.Count;
                while (size > 0)
                {
                    TreeNode node = q.Dequeue();
                    if (zigzag)
                    {
                        lvl.Insert(0, node.val);
                    }
                    else
                    {
                        lvl.Add(node.val);
                    }
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                    size--;
                }
                res.Add(lvl);
                zigzag = !zigzag;
            }
            return res;
        }
    }
}
