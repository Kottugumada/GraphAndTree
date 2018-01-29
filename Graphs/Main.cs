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
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var edges = new[] {
                Tuple.Create(1,2),Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graph = new GraphDS.Graph<int>(vertices, edges);
            var dfs = new GraphDS.GraphDFS();
            var bfs = new GraphDS.GraphBFS();

            Console.WriteLine("DFS");
            Console.WriteLine(string.Join(", ",dfs.DFS(graph,1)));
            Console.WriteLine("BFS");
            Console.WriteLine(string.Join(", ", bfs.BFS(graph, 1)));
            //Console.ReadKey();

            //***********************************************************************//
            Console.WriteLine("BST Traversal");
            Node root = null;
            Tree tree = new Tree();

            Search search = new Search();
            List<int> resultList = new List<int>();
           
            root = tree.BalanceTree(vertices.ToList(), 0, vertices.ToList().Count());

            if (root != null)
            {
                Console.WriteLine("InOrder");
                search.InOrder(root);
                Console.WriteLine("PreOrder");
                search.PreOrder(root);
                Console.WriteLine("PostOrder");
                search.PostOrder(root);
            }
            else
            {
                // root is null
                // display to the user
            }
         
            Console.ReadKey();
        }
    }
}
