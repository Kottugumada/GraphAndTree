// Using an Adjacency List time complexity is O(vertices + edges)
using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.Topological_Sort
{
    public class TopologicalSorting
    {
        public List<int> TopoSort(int numCourses, int[][] prerequisites)
        {
            var graph = GetAdjacencyList(numCourses, prerequisites);
            return HasCycle(graph, new List<int>());
        }

        private List<int>[] GetAdjacencyList(int n, int[][] edges)
        {
            var result = new List<int>[n];
            for (var i = 0; i < n; ++i)
            {
                result[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                result[edge[0]].Add(edge[1]);
            }

            return result;
        }

        private List<int> HasCycle(List<int>[] adjacencyList, List<int> res)
        {
            var visited = new bool[adjacencyList.Length];
            var stacked = new bool[adjacencyList.Length];

            for (var i = 0; i < adjacencyList.Length; ++i)
            {
                if (!visited[i])
                {
                   // res = HasCycle(i, visited, stacked, adjacencyList, res);
                }
            }

            return res;
        }

        private bool HasCycle(int i, bool[] visited, bool[] stacked, List<int>[] adjacencyList, List<int> res)
        {
            if (stacked[i])
            {
                return true;
            }

            if (visited[i])
            {
                return false;
            }

            visited[i] = true;
            stacked[i] = true;

            foreach (var adjacent in adjacencyList[i])
            {
                if (!HasCycle(adjacent, visited, stacked, adjacencyList, res))
                {
                    res.Add(adjacent);
                }
            }

            stacked[i] = false;
            return false;
        }
    }
}
