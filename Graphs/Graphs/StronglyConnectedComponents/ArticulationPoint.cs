using System;
using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.StronglyConnectedComponents
{
    public class ArticulationPointAdjacencyList
    {
        private List<List<int>> graph;
        private int vertices;
        private int id;
        private bool[] visited;
        private int[] ids;
        private int[] lowLink;
        private bool[] isArticulationPoint;
        private int outEdgeCount;
        public ArticulationPointAdjacencyList(List<List<int>> graph, int vertices)
        {
            if (graph == null || vertices <= 0 || graph.Count != vertices)
            {
                throw new Exception();
            }
            this.graph = graph;
            this.vertices = vertices;
        }
        public bool[] FindArticulationPoints()
        {
            visited = new bool[vertices];
            lowLink = new int[vertices];
            isArticulationPoint = new bool[vertices];
            ids = new int[vertices];
            for (int i = 0; i < vertices; i++)
            {
                if (!visited[i])
                {
                    // start counting outward edges
                    outEdgeCount = 0;
                    DFS_ArticulationPoints(i,i,-1);
                    // only when outward edge count is greater than 1
                    // only one would em it is a cycle
                    isArticulationPoint[i] = outEdgeCount > 1;
                }
            }
            return isArticulationPoint;
        }

        private void DFS_ArticulationPoints(int root, int curr, int parent)
        {
            if (parent == root)
            {
                // when parent is the root, it means that the outward edge is the same
                outEdgeCount++;
            }

            visited[curr] = true;
            lowLink[curr] = ids[curr] = id + 1;

            List<int> edges = graph[curr];
            foreach (var dest in graph[curr])
            {
                if (dest == parent)
                {
                    continue;
                }
                if (!visited[dest])
                {
                    DFS_ArticulationPoints(root,dest, curr);
                    lowLink[curr] = Math.Min(lowLink[curr], lowLink[dest]);
                    // this where we know it is an articulation point
                    if (ids[curr] <= lowLink[dest])
                    {
                        isArticulationPoint[curr] = true;
                    }
                }
                else
                {
                    lowLink[curr] = Math.Min(lowLink[curr],ids[dest]);
                }
            }
        }
    }

}
