using DataStructures.BST;
using System;

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
            Console.ReadKey();

            //***********************************************************************//

            Node root = null;
            Tree tree = new Tree();
            int[] a = new int[100];
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                a[i] = random.Next(10);
            }
        }
    }
}
