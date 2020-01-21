// Using an Adjacency List time complexity is O(vertices + edges)
using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.Topological_Sort
{
	public class CourseScheduling_AdjList
	{
		public bool CanFinish(int numCourses, int[][] prerequisites)
		{
			var graph = GetAdjacencyList(numCourses, prerequisites);
			return !HasCycle(graph);
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

		private bool HasCycle(List<int>[] adjacencyList)
		{
			var stack = new Stack<int>();
			var visited = new bool[adjacencyList.Length];
			var stacked = new bool[adjacencyList.Length];

			for (var i = 0; i < adjacencyList.Length; ++i)
			{
				if (!visited[i] && HasCycle(i, visited, stacked, adjacencyList))
				{
					return true;
				}
			}

			return false;
		}

		private bool HasCycle(int i, bool[] visited, bool[] stacked, List<int>[] adjacencyList)
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
				if (HasCycle(adjacent, visited, stacked, adjacencyList))
				{
					return true;
				}
			}

			stacked[i] = false;
			return false;
		}
	}
}
