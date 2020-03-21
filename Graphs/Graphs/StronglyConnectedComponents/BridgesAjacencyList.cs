using System;
using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.StronglyConnectedComponents
{
    public class BridgesAjacencyList
    {
        private int vertices, id;
        private int[] ids, lowLink;
        private bool[] visited;
        private List<List<int>> graph = new List<List<int>>();
        private List<int> bridges;

        public BridgesAjacencyList(List<List<int>> graph, int vertices)
        {
            if (graph == null || vertices <= 0 || graph.Count != vertices)
            {
                throw new Exception();
            }
            this.graph = graph;
            this.vertices = vertices;
        }

        public List<int> FindBridges()
        {
            id = 0;
            lowLink = new int[vertices];
            ids = new int[vertices];
            visited = new bool[vertices];

            bridges = new List<int>();

            // Finds all bridges in the graph across various connected components.
            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i])
                {
                    DFS(i, -1, bridges);
                }
            }
            return bridges;
        }

        private void DFS(int curr, int parent, List<int> bridges)
        {
            visited[curr] = true;
            lowLink[curr] = ids[curr] = ++id;

            foreach (var dest in graph[curr])
            {
                if (dest == parent)
                {
                    continue;
                }
                if (!visited[dest])
                {
                    DFS(dest,curr, bridges);
                    lowLink[curr] = Math.Min(lowLink[dest], lowLink[curr]);
                    // if lowLink of the destination made is greater than the id of the current node, 
                    // we found a bridge
                    if (ids[curr] < lowLink[dest])
                    {
                        bridges.Add(curr);
                        bridges.Add(dest);
                    }
                }
                else
                {
                    lowLink[curr] = Math.Min(lowLink[curr], ids[dest]);
                }
            }
        }
    }
}

/*
    Driver code
 ********************
    int nodes = 9;
    List<List<int>> graph = new List<List<int>>();
    graph = CreateGraph(nodes);

    AddEdge(graph, 0, 1);
    AddEdge(graph, 0, 2);
    AddEdge(graph, 1, 2);
    AddEdge(graph, 2, 3);
    AddEdge(graph, 3, 4);
    AddEdge(graph, 2, 5);
    AddEdge(graph, 5, 6);
    AddEdge(graph, 6, 7);
    AddEdge(graph, 7, 8);
    AddEdge(graph, 8, 5);
    BridgesAjacencyList bridge = new BridgesAjacencyList(graph, nodes);
    List<int> bridges = bridge.FindBridges();

    // print the bridges
    for (int i = 0; i < bridges.Count/2; i++)
    {
    int node1 = bridges[2*i];
    int node2 = bridges[2 * i + 1];
    Console.WriteLine("Bridge is between node1: " + node1.ToString() + " and node2: " + node2.ToString());
    }
     

        private static void AddEdge(List<List<int>> graph, int src, int dest)
        {
            for (int i = 0; i < graph.Count; i++)
            {
                graph[src].Add(dest);
                graph[dest].Add(src);
            }
        }

        private static List<List<int>> CreateGraph(int nodes)
        {
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < nodes; i++)
            {
                graph.Add(new List<int>());
            }
            return graph;
        }
*/
