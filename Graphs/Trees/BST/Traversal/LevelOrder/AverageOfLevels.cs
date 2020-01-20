using System.Collections.Generic;
using System.Linq;

namespace Graphs.Heaps.Trees.Trees.BST.Traversal.LevelOrder
{
    public class AverageOfLevelsOBST
    {
        public IList<double> AverageOfLevels(TreeNode root)
        {

            IList<double> res = new List<double>();
            Queue<TreeNode> q = new Queue<TreeNode>();

            if (root == null) return res;
            q.Enqueue(root);
            while (q.Any())
            {
                int lvlSum = 0;
                int size = q.Count;
                int c = 0;
                while (size > 0)
                {
                    TreeNode node = q.Dequeue();
                    lvlSum = lvlSum + node.val;
                    c++;
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                    size--;
                }
                res.Add((double)lvlSum / c);
            }
            return res;
        }
    }
}
