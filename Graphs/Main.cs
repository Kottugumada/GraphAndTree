using System;
using System.Collections.Generic;
using System.Linq;
using Graphs.Heaps.Trees.Graphs.Islands;
using Graphs.Heaps.Trees.Graphs.Topological_Sort;
using Graphs.Heaps.Trees.Graphs.Word_Ladder;
using Graphs.Heaps.Trees.Heaps;
using Graphs.Heaps.Trees.Trees.BST.Traversal.LevelOrder;

namespace DataStructures
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            KClosedToOrigin kC = new KClosedToOrigin();
            //int[][] points = new int[2][];
            //points[0] = new int[] { 1, 0 };
            //points[1] = new int[] { 0, 1 };
            //kC.KClosest(points, 2);
            TopKWithSortedDictionary topK = new TopKWithSortedDictionary();
            //topK.TopKFrequent(new int[] {1,1,1,2,2,3 }, 2);
            CourseScheduling_AdjMatrix_Courses courses = new CourseScheduling_AdjMatrix_Courses();
            //char[][] grid = new char[4][];
            //grid[0] = new char[] {'X', 'X', 'O', 'O'}; // { '1','1','0','0', '0'};
            //grid[2] = new char[] { 'X', 'O', 'O', 'X' }; // { '1', '1', '0' , '0', '0' };
            //grid[3] = new char[] { 'X', 'X', 'O', 'X' }; // { '0','0','1','0','0' };
            //grid[1] = new char[] { 'X', 'O', 'X', 'X' }; // { '0','0','0','1','1'};
            SurroundedRegions s = new SurroundedRegions();
            //s.Solve(grid);
            NumberOfIslands n = new NumberOfIslands();
            //n.NumIslands(grid);
            // courses.FindOrder(4, prerequisites);
            // example ex = new example();
            // int[] arr = new int[] {4,5,2,7,8 };
            //Console.Write(ex.heapSort(arr, 5));
            LevelOrder_BottomUp lvlOrder = new LevelOrder_BottomUp();
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
            WordLadder_BFS wl = new WordLadder_BFS();
            wl.LadderLength_BFS("hit", "cog", new string[] { "hot", "dot", "dog", "lot", "log", "cog" });
            WordLadder_BFS_LessEfficient wlbfs = new WordLadder_BFS_LessEfficient();
            // wlbfs.FindLadders("hit","cog",new string[] { "hot", "dot", "dog", "lot", "log", "cog" });
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
