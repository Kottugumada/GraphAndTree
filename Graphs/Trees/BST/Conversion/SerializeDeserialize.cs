// public class TreeNode{
//     public TreeNode left;
//     public TreeNode right;
//     public int val;
//     public TreeNode(int data){
//         val = data;
//     }
// }
using System;
using System.Text;
using System.Collections.Generic;

namespace BST
{
    public class Solution_Codec {

        // Encodes a tree to a single string.
        // https://leetcode.com/problems/serialize-and-deserialize-bst/
        public string serialize(TreeNode root) {

            // base condition for corner cases
            if (root == null)
                return "X";
            // pre order traversal makes sense
            // root left right
            string leftSubtree = serialize(root.left);
            string rightSubtree = serialize(root.right);

            StringBuilder sb = new StringBuilder();
            sb.Append(root.val.ToString());
            sb.Append(",");
            sb.Append(leftSubtree);
            sb.Append(rightSubtree);

            return sb.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data) {
            string[] elements = data.Split(',');
            // instantiate the queue and add the split values from strings
            Queue<string> nodesLeft = new Queue<string>(elements);
            return DeserializeHelper(nodesLeft);
        }

        private TreeNode DeserializeHelper(Queue<string> nodesLeft)
        {
            string valueForNode = nodesLeft.Dequeue();
            if (valueForNode.Equals("X"))
            {
                return null;
            }
            TreeNode newNode = new TreeNode(int.Parse(valueForNode));
            newNode.left = DeserializeHelper(nodesLeft);
            newNode.right = DeserializeHelper(nodesLeft);
            return newNode;
        }
    }
}
// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));