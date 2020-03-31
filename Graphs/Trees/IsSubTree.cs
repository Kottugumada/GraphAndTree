using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs.Heaps.Trees.Trees
{
    public class SubTree
    {
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null || t == null)
            {
                return s == t;
            }
            return IsSameTree(s, t) || IsSubtree(s.left, t) || IsSubtree(s.right, t); // traverse left subtree and right subtree
        }
        private bool IsSameTree(TreeNode s, TreeNode t)
        {
            if (s == null || t == null)
            {
                return s==t;
            }
            if (s.val != t.val)
            {
                return false;
            }
            return IsSameTree(s.left,t.left) && IsSameTree(s.right,t.right); // parse through the entire tree checking where all nodes match
        }
    }
}
