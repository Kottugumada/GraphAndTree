using System;

namespace Graphs.Heaps.Trees.Trees.Spanning_Tree
{
    public class PrimsAlgorithm
    {

        private int MinKey(int[] keys, bool[] mstSet, int v)
        {
            // initialize min value
            int min = Int32.MaxValue;
            int minIndex = -1;
            for (int i = 0; i < v; i++)
            {
                if (mstSet[i] == false && keys[i] < min)
                {
                    min = keys[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
        /// <summary>
        /// Find a Minimum Spanning Tree Using Prim's Algorithm
        /// </summary>
        /// <param name="graph">graph as an adjacency matrix</param>
        /// <param name="v">vertices</param>
        public void PrimsMinSpanningTree(int[,] graph, int v)
        {
            // Array to store the constructed min spanning tree
            int[] parent = new int[v];

            // keys to help pick the min weight of an edge
            int[] keys = new int[v];

            // flags to represent vertices not yet included in MST
            bool[] mstSet = new bool[v];

            // initialize all keys to a high min
            for (int i = 0; i < v; i++)
            {
                keys[i] = Int32.MaxValue;
                mstSet[i] = false;
            }
            // Always include first 1st vertex in MST. 
            // Make key 0 so that this vertex is 
            // picked as first vertex 
            // First node is always root of MST 
            keys[0] = 0;
            parent[0] = -1;

            // the MST will have V vertices
            for (int count = 0; count < v - 1; count++)
            {
                // pick the minimum vertex from a set of vertices not yet included in MST
                int u = MinKey(keys, mstSet, v);

                // Add the picked vertex to mstSet
                mstSet[u] = true;

                // Update key value and parent index of the adjacent vertices of the picked vertex.
                // Consider only those vertices which are not yet included in MST
                for (int i = 0; i < v; i++)
                {
                    if (graph[u, v] != 0 && mstSet[v] == false && graph[u, v] < keys[v])
                    {
                        parent[v] = u;
                        keys[v] = graph[u, v];
                    }
                }
            }
            PrintMST(parent, graph, v);
        }
        /// <summary>
        /// function to print the constructed MST stored in parent[]
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="graph"></param>
        static void PrintMST(int[] parent, int[,] graph, int vertices)
        {
            Console.WriteLine("Edge \tWeight");
            for (int i = 1; i < vertices; i++)
            {
                Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
            }
        }
    }
}
