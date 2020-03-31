using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Heaps.Trees.Graphs.StronglyConnectedComponents
{
    public class CriticalRoutersInANetwork
    {
        /// <summary>
        /// https://leetcode.com/discuss/interview-question/436073/
        /// </summary>
        /// <param name="numRouters"></param>
        /// <param name="links"></param>
        /// <returns></returns>
        public List<int> CriticalRouters(int numRouters,int numLinks, List<List<int>> links)
        {
            List<int> result = new List<int>();
            if (links.Count == 0) return result;
            List<List<int>> graph = ConstructGraph(numRouters, links); // Create graph as adjacency list

            int[] visited = new int[numRouters]; // To keep track of when the node is discovered       
            int[] lowLink = new int[numRouters];  // Keeps track of lowest node (based on identified)

            Array.Fill(visited, -1);
            int id = 0; // To avoid the global variable

            for (int i = 0; i < numRouters; i++)
                if (visited[i] == -1)
                    DFS_Routers(graph, i, i, lowLink, visited, result, id);

            return result.Distinct().ToList();
        }

        private void DFS_Routers(List<List<int>> graph, int curr, int parent,
                         int[] lowLink, int[] visited, List<int> result, int id)
        {
            visited[curr] = lowLink[curr] = id++; // discovery

            foreach (var dest in graph[curr])
            {
                if (dest == parent) continue; // due to undirected graph

                if (visited[dest] == -1)
                { // if the to node is undiscovered
                    DFS_Routers(graph, dest, curr, lowLink, visited, result, id);
                    lowLink[curr] = Math.Min(lowLink[curr], lowLink[dest]); // on backtracking, set the low link value

                    if (lowLink[dest] > visited[curr])
                        result.Add(dest);
                        result.Add(curr);
                }
                else
                    lowLink[curr] = Math.Min(lowLink[curr], visited[dest]); // Low link is influenced by the discovery time
            }
        }


        private List<List<int>> ConstructGraph(int n, List<List<int>> connections)
        {
            List<List<int>> graph = new List<List<int>>();
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
