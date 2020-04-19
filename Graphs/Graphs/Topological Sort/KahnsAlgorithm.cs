using System;
using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.Topological_Sort
{
    public class KahnsAlgorithm
    {
        public int[] Kahns(List<List<int>> graph)
        {
            int n = graph.Count;
            Stack<int> nodesWithNoIncomingEdges = new Stack<int>();
            int[] inDegree = new int[n];
            // build inDegree array
            foreach (List<int> edges in graph)
            {
                foreach (int destNode in edges)
                {
                    inDegree[destNode]++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (inDegree[i] == 0)
                {
                    nodesWithNoIncomingEdges.Push(i);
                }
            }
            int index = 0;
            int[] order = new int[n];
            while (nodesWithNoIncomingEdges.Count > 0)
            {
                int curr = nodesWithNoIncomingEdges.Pop();
                // add to order array 
                // this will finally give the topologically sorted values
                order[index++] = curr;
                foreach (var dest in graph[curr])
                {
                    inDegree[dest]--;
                    if (inDegree[dest] == 0)
                    {
                        nodesWithNoIncomingEdges.Push(dest);
                    }
                }
            }
            if (index != n)
            {
                throw new Exception("Cycle detected");
            }
            return order;
        }
    }
}
