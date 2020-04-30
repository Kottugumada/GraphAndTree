using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs.Heaps.Trees.Graphs.Backtracking
{
    public class Bipartite
    {
        /// <summary>
        /// https://leetcode.com/problems/is-graph-bipartite/
        /// This is a classic graph coloring problem with two colors
        /// colors array would have three states: 0: not yet colored, 1: blue, -1: red
        /// For each node that has not yet been colored, use a color and then use the other color to color the adjacent node
        /// if colored , check for the color of the adjacent node
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public bool IsBipartite(int[][] graph)
        {
            int n = graph.Length;
            int[] colors = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (colors[i] == 0 && !IsValid(graph, colors,1,i))
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsValid(int[][] graph, int[] colors,int color, int node)
        {
            // if it is colored
            if (colors[node] != 0)
            {
                return colors[node] == color;
            }
            colors[node] = color;
            foreach (var next in graph[node])
            {
                if (!IsValid(graph,colors,-color,next))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
