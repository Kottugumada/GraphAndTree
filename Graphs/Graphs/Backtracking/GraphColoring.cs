using System;

namespace Backtracking
{
    public class Coloring
    {
        public int[] color;
        /// <summary>
        /// m coloring problem using backtracking
        /// Given an undirected graph and a number m, determine if the graph can be coloured with at most m colors 
        /// such that no two adjacent vertices of the graph are colored with the same color. 
        /// Here coloring of a graph means the assignment of colors to all vertices.
        /// there may be more than one solutions. This solution prints one of the solutions 
        /// Time Complexity:O(m^V).
        /// There are total O(m^V) combination of colors.So time complexity is O(m^V). 
        /// The upperbound time complexity remains the same but the average time taken will be less.
        /// Space Complexity:O(V).
        /// To store the output array O(V) space is required.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="m"></param>
        /// <returns>false if m colors cannot be assigned. 
        /// Otherwise returns true and prints assignments of colors to all vertices</returns>
        public bool GraphColoring(int[,] graph, int m, int vertices)
        {
            color = new int[vertices];
            for (int i = 0; i < vertices; i++)
            {
                color[i] = 0;
            }
            // call the helper method for vertex 0;
            if (!Backtracking(graph,m,color,0, vertices))
            {
                return false;
            }
            // print Solution
            PrintSolution(color, vertices);
            return true;
        }
        /// <summary>
        /// helper function to solve m coloring problem
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="m"></param>
        /// <param name="color"></param>
        /// <param name="currentVertex"></param>
        /// <returns></returns>
        private bool Backtracking(int[,] graph, int m, int[] color, int currentVertex, int vertices)
        {
            // if all vertices are assigned we return true
            if (currentVertex == vertices)
            {
                return true;
            }
            // consider one vertex and dfs different colors
            for (int c = 1; c <= m; c++)
            {
                // check if assignment of color c to vertex v is ok
                if (IsSafe(graph,color,c, currentVertex, vertices))
                {
                    color[currentVertex] = c;

                    // recurse to assign colors to the rest of the vertices
                    if (Backtracking(graph,m,color,currentVertex+1, vertices))
                    {
                        return true;
                    }
                    // if assigning color c doesn't lead to a solution, remove
                    color[currentVertex] = 0;
                }
            }
            // if no color can be assigned to this vertex, return false
            return false;
        }

        /// <summary>
        /// Check if current assignment is safe for the given vertex
        /// </summary>
        /// <param name="v"></param>
        /// <param name="graph"></param>
        /// <param name="color"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool IsSafe(int[,] graph, int[] color, int c, int currentVertex, int vertices)
        {
            for (int i = 0; i < vertices; i++)
            {
                if (graph[currentVertex, i] == 1 && c == color[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void PrintSolution(int[] color, int vertices)
        {
            Console.WriteLine("Solution Exists: Following" +
                                " are the assigned colors");
            for (int i = 0; i < vertices; i++)
                Console.Write(" " + color[i] + " ");
            Console.WriteLine();
        }
    }
}
