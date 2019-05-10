using DataStructures.BST;
using DataStructures.Trees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            //string s = "-123 456";
            //s = s.Replace(" ","");
            //bool isDig = s.All(char.IsDigit);
            List<string> boxes = new List<string>();
            string[] shdhfvbhjsd = new string[3] { "r1 box ape", "br8 eat nim"," has uni gry" };
            boxes.Add("cat dog");
            boxes.Add("cat dog mouse");
            boxes.Add("add cat dog");
            List<string> sorted = shdhfvbhjsd.OrderBy(s => s.Length).ThenBy(r => r).ToList();
            sorted.AddRange(boxes);
            orderedJunctionBoxes(6, shdhfvbhjsd);
            //Console.WriteLine(sorted .ToString());
            Console.ReadKey();
            //var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var edges = new[] {
            //    Tuple.Create(1,2),Tuple.Create(1,3),
            //    Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
            //    Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
            //    Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            //var graph = new GraphDS.Graph<int>(vertices, edges);
            //var dfs = new GraphDS.GraphDFS();
            //var bfs = new GraphDS.GraphBFS();

            //Console.WriteLine("DFS");
            //Console.WriteLine(string.Join(", ",dfs.DFS(graph,1)));
            //Console.WriteLine("BFS");
            //Console.WriteLine(string.Join(", ", bfs.BFS(graph, 1)));
            ////Console.ReadKey();

            ////***********************************************************************//
            //Console.WriteLine("BST Traversal");
            //Node root = null;
            //Tree tree = new Tree();

            //Search search = new Search();
            //List<int> resultList = new List<int>();
           
            //root = tree.BalanceTree(vertices.ToList(), 0, vertices.ToList().Count());

            //if (root != null)
            //{
            //    Console.WriteLine("InOrder");
            //    search.InOrder(root);
            //    Console.WriteLine("PreOrder");
            //    search.PreOrder(root);
            //    Console.WriteLine("PostOrder");
            //    search.PostOrder(root);
            //}
            //else
            //{
            //    // root is null
            //    // display to the user
            //}
         
            //Console.ReadKey();
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
