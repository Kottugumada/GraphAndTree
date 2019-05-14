using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs
{
    public class GraphInt
    {
        public GraphInt(List<int> vertices, List<Tuple<int,int>> edges)
        {
            foreach (var vertex in vertices)
            {
                AddVertex(vertex);
            }
            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }
        public Dictionary<int, HashSet<int>> AdjacencyList { get; } = new Dictionary<int, HashSet<int>>();
        private void AddEdge(Tuple<int, int> edge)
        {
            if (AdjacencyList.ContainsKey(edge.Item1) && AdjacencyList.ContainsKey(edge.Item2))
            {
                AdjacencyList[edge.Item1].Add(edge.Item2);
                AdjacencyList[edge.Item2].Add(edge.Item1);
            }
        }

        private void AddVertex(int vertex)
        {
            AdjacencyList[vertex] =  new HashSet<int>();
        }
    }
}
