using HeapSortDemo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            example ex = new example();
            int[] arr = new int[] {4,5,2,7,8 };
           Console.Write(ex.heapSort(arr, 5));
            // LevelOrder_BottomUp lvlOrder = new LevelOrder_BottomUp();
            //TreeNode root = new TreeNode(5);
            //root.left = new TreeNode(4);
            //root.right = new TreeNode(8);
            //root.right.left = new TreeNode(13);
            //root.right.right = new TreeNode(4);
            //root.left.left = new TreeNode(11);
            //root.left.left.left = new TreeNode(7);
            //root.left.right = new TreeNode(2);
            //Solution sl = new Solution();
            //sl.HasPathSum(root, 22);
            // lvlOrder.LevelOrderBottom(root);
            Console.ReadKey();
           
        }
        public static List<string> orderedJunctionBoxes(int numberOfBoxes,
                                         string[] boxList)
        {
            // WRITE YOUR CODE HERE
            List<string> res = new List<string>();
            if (boxList.Length == 0) return res;
            List<string> oldBoxes = new List<string>();
            List<string> newBoxes = new List<string>();
            foreach (string box in boxList)
            {
                // split string into id and version
                int idIndx = box.IndexOf(" ");
                string id = box.Substring(0, idIndx);
                string ver = box.Substring(idIndx + 1);

                // check if ver is all digits 
                string boxNoSpaces = box.Replace(" ", "");
                bool IsDigitsOnly = boxNoSpaces.All(char.IsDigit);
                // if IsDigitsOnly is false, it means it is alphanumeric
                // means old box
                if (!IsDigitsOnly)
                {
                    // now sort lexicographically
                    // add to the list of old boxes
                    oldBoxes.Add(box);
                }
                else
                {
                    newBoxes.Add(box);
                }
            }
            // now lexicographically sort old boxes
            List<string> lexSorted = oldBoxes.OrderBy(s => s.Length).ThenBy(r => r).ToList();
            // concat
            lexSorted.AddRange(newBoxes);
            foreach (var item in lexSorted)
            {
                res.Add(item);
            }
            return res;
        }
    }
}
