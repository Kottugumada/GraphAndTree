using System;
using System.Collections.Generic;
using System.Linq;
using Graphs.Heaps.Trees.Graphs.Islands;
using Graphs.Heaps.Trees.Graphs.StronglyConnectedComponents;
using Graphs.Heaps.Trees.Graphs.Topological_Sort;
using Graphs.Heaps.Trees.Graphs.Trie;
using Graphs.Heaps.Trees.Graphs.Word_Ladder;
using Graphs.Heaps.Trees.Heaps;
using Graphs.Heaps.Trees.Trees.BST.Traversal.LevelOrder;
using Graphs.Heaps.Trees.Trees.Spanning_Tree;

namespace DataStructures
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            WordDictionary wd = new WordDictionary();
            wd.AddWord("bad");
            wd.AddWord("dad");
            wd.AddWord("mad");
            Console.Write(wd.Search("pad"));
            Console.Write(wd.Search("bad"));
            Console.Write(wd.Search(".ad"));
            Console.Write(wd.Search("b.."));
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
            //var arr = new int[5, 4]
            //                    {
            // {1,1, 0, 0},
            // {0,0, 1, 0},
            // {0,0, 0, 0},
            // {1,0, 1, 1},
            // {1,1, 1, 1},
            //                    };
            //n.numberAmazonGoStores(5, 4, arr);

            MinCostInAGrid minC = new MinCostInAGrid();
            int[][] grid = new int[4][];
            grid[0] = new int[] { 1, 1, 1, 1 };
            grid[1] = new int[] { 2, 2, 2, 2 };
            grid[2] = new int[] { 1, 1, 1, 1 };
            grid[3] = new int[] { 2, 2, 2, 2 };
            //minC.MinCost(grid);

            //n.NumIslands(grid);
            CriticalRoutersInANetwork rt = new CriticalRoutersInANetwork();
            //List<List<int>> ls = new List<List<int>> {
            //    new List<int> {1,2},
            //    new List<int> {2,3},
            //    new List<int> {3,4},
            //    new List<int> {4,5},
            //    new List<int> {5,1},
            //};
            //rt.CriticalRouters(6,7,ls);


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
            // WordLadder_BFS_LessEfficient wlbfs = new WordLadder_BFS_LessEfficient();
            // wlbfs.FindLadders("hit","cog",new string[] { "hot", "dot", "dog", "lot", "log", "cog" });
            TrieDataStructure obj = new TrieDataStructure();
            // obj.InsertWord("spinclass");
            //bool exists = obj.Search("spin");
          //   bool startsWith = obj.StartsWith("spin");

            //int nodes = 3;
            List<List<int>> graph = new List<List<int>>();
            //graph = CreateGraph(nodes);

            //AddEdge(graph, 0, 1);
            //AddEdge(graph, 0, 2);
           // AddEdge(graph, 1, 2);
            //AddEdge(graph, 2, 3);
            //AddEdge(graph, 3, 4);
            //AddEdge(graph, 2, 5);
            //AddEdge(graph, 5, 6);
            //AddEdge(graph, 6, 7);
            //AddEdge(graph, 7, 8);
            //AddEdge(graph, 8, 5);
            //BridgesAjacencyList bridge = new BridgesAjacencyList(graph, nodes);
            //List<int> bridges = bridge.FindBridges();

            // print the bridges
            //for (int i = 0; i < bridges.Count/2; i++)
            //{
            //    int node1 = bridges[2*i];
            //    int node2 = bridges[2 * i + 1];
            //    Console.WriteLine("Bridge is between node1: " + node1.ToString() + " and node2: " + node2.ToString());
            //}

            //ArticulationPointAdjacencyList artAdj = new ArticulationPointAdjacencyList(graph, nodes);
            //bool[] isArticulationPoint = artAdj.FindArticulationPoints();

            //for (int i = 0; i < nodes; i++)
            //{
            //    if (isArticulationPoint[i])
            //    {
            //        Console.WriteLine("ArticulationPoint is at index : " + i);
            //    }
            //}
            CriticalConnectionsInANetwork cr = new CriticalConnectionsInANetwork();
            //IList<IList<int>> connections = new List<IList<int>>();
            //connections.Add(new List<int>() {0,1 });
            //connections.Add(new List<int>() { 1, 2 });
            //connections.Add(new List<int>() { 2,0 });
            //connections.Add(new List<int>() { 1,3 });
            //cr.CriticalConnections(4, connections);


            PrimsAlgorithm prims = new PrimsAlgorithm();
            //int[,] pm = new int[,] { { 0, 2, 0, 6, 0 },
            //                          { 2, 0, 3, 8, 5 },
            //                          { 0, 3, 0, 0, 7 },
            //                          { 6, 8, 0, 0, 9 },
            //                          { 0, 5, 7, 9, 0 } };
            //prims.PrimsMinSpanningTree(pm, 5);

            Console.ReadKey();
           
        }

        private static void AddEdge(List<List<int>> graph, int src, int dest)
        {
            for (int i = 0; i < graph.Count; i++)
            {
                graph[src].Add(dest);
                graph[dest].Add(src);
            }
        }

        private static List<List<int>> CreateGraph(int nodes)
        {
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < nodes; i++)
            {
                graph.Add(new List<int>());
            }
            return graph;
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
