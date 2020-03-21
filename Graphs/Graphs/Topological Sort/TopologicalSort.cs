using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Heaps.Trees.Graphs.Topological_Sort
{
    public class Edge
    {
        public int source;
        public int destination;
        public Edge(int src, int dest)
        {
            source = src;
            destination = dest;
        }
    }
    public class Graph
    {
        private int vertices; // number of vertices
        private List<int>[] adjacencyList; // adjacencyList
        List<int> inDegree;
        public Graph(int N, List<Edge> edges)
        {
            vertices = N;
            adjacencyList = new List<int>[N];
            for (int i = 0; i < N; i++)
            {
                adjacencyList[i] = new List<int>();
            }
            inDegree = new List<int>();
            // initialize inDegree to 0;
            inDegree = Enumerable.Repeat(0, N).ToList();

            // add edges to the undirected graph
            for (int j = 0; j < edges.Count; j++)
            {
                int src = edges[j].source;
                int dest = edges[j].destination;

                // add edge from source to destination
                adjacencyList[src].Add(dest);

                // increment inDegree of the destination
                inDegree[dest]++;
            }
        }



        public List<int> TopologicalSort()
        {
            Stack<int> st = new Stack<int>();
            List<int> res = new List<int>();

            // mark all the vertices as not visited
            bool[] visited = new bool[vertices];
            for (int i = 0; i < vertices; i++)
            {
                visited[i] = false;
            }

            // call the helper function to store the topological sort for all vertices
            for (int j = 0; j < vertices; j++)
            {
                if (visited[j] == false)
                {
                    // TopologicalSortHelper(j, visited, st);
                }
            }
            while (st.Count > 0)
            {
                res.Add(st.Pop());
            }
            return res;
        }
    }
}
