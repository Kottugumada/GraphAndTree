using System;
using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.StronglyConnectedComponents
{
    public class CriticalConnectionsInANetwork
    {
        /// <summary>
        /// https://leetcode.com/problems/critical-connections-in-a-network/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="connections"></param>
        /// <returns></returns>
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (connections.Count == 0) return result;
            IList<IList<int>> graph = CreateGraph(n, connections); // Create graph as adjacency list

            int[] visited = new int[n]; // To keep track of when the node is discovered       
            int[] lowLink = new int[n];  // Keeps track of lowest node (based on identified)

            Array.Fill(visited, -1);
            int id = 0; // To avoid the global variable

            for (int i = 0; i < n; i++)
                if (visited[i] == -1)
                    DFS(graph, i, i, lowLink, visited, result, id);

            return result;
        }

        private void DFS(IList<IList<int>> graph, int curr, int parent,
                         int[] lowLink, int[] visited, IList<IList<int>> result, int id)
        {
            visited[curr] = lowLink[curr] = id++; // discovery

            foreach (var dest in graph[curr])
            {
                if (dest == parent) continue; // due to undirected graph

                if (visited[dest] == -1)
                { // if the to node is undiscovered
                    DFS(graph, dest, curr, lowLink, visited, result, id);
                    lowLink[curr] = Math.Min(lowLink[curr], lowLink[dest]); // crucial - on backtracking, set the low link value

                    if (lowLink[dest] > visited[curr])
                        result.Add(new List<int>() { dest, curr});
                }
                else
                    lowLink[curr] = Math.Min(lowLink[curr], visited[dest]); // Low link is influenced by the discovery time
            }
        }


        private IList<IList<int>> CreateGraph(int n, IList<IList<int>> connections)
        {
            IList<IList<int>> graph = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }

            foreach (var edge in connections)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            return graph;
        }
    }
}
