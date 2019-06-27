using System;
using System.Collections.Generic;

namespace BST{
public class TreeNode{
    public TreeNode left;
    public TreeNode right;
    public int val;
    public TreeNode(int data){
        val = data;
    }
}
public class Solution_MaxDepthInBST{
public int MaxDepthInBST(TreeNode root){
   Queue<TreeNode> q = new Queue<TreeNode>();
    int count = 0;
    
    if(root == null) return 0;
    if(root.left == null && root.right == null) return 1;

    q.Enqueue(root);
    while(q.Count >0){
        int size = q.Count;
        while(size > 0){
            TreeNode node = q.Dequeue();
            if(node.left != null){
                q.Enqueue(node.left);
            }
            if(node.right != null){
                q.Enqueue(node.right);
            }
            size--;
        }
        count++;
    }
    return count;
}
public int MaxDepthInBST_Recursive(TreeNode root){
    if(root == null) return 0;
    return Math.Max(MaxDepthInBST_Recursive(root.left), MaxDepthInBST_Recursive(root.right)) + 1;
    }
}
}
