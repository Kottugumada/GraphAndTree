using System;

namespace Graphs.Heaps.Trees.Graphs.Backtracking
{
    public class LongestIncreasingPathInAMatrix
    {
        int[][] dirs = new int[4][];
        /// <summary>
        /// https://leetcode.com/problems/longest-increasing-path-in-a-matrix
        /// DFS O(mn) solution with memoization
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int LongestIncreasingPath(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
            {
                return 0;
            }
            int m = matrix.Length;
            int n = matrix[0].Length;

            // memo
            int[,] cache = new int[m, n];
            int res = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    res = Math.Max(res, DFS(matrix,i,j,cache, m, n));
                }
            }
            return res;
        }

        private int DFS(int[][] matrix, int i, int j, int[,] cache, int m, int n)
        {
            if (cache[i,j] != 0)
            {
                return cache[i,j];
            }
            dirs[0] = new int[] { 0, 1 }; // right
            dirs[1] = new int[] { 0, -1 }; // left
            dirs[2] = new int[] { 1, 0 }; // down
            dirs[3] = new int[] { -1, 0 }; // up
            foreach (var d in dirs)
            {
                int newX = i + d[0];
                int newY = j + d[1];
                // check if it is in bounds
                if (newX>=0 && newX<m && newY>=0 && newY<n && matrix[newX][newY] > matrix[i][j])
                {
                    cache[i,j] = Math.Max(cache[i,j], DFS(matrix,newX,newY,cache,m,n));
                }
            }
            return ++cache[i, j];
        }
    }
}
