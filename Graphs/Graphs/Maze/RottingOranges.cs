using System.Collections.Generic;
using System.Linq;

// https://leetcode.com/problems/rotting-oranges

namespace Graphs.Heaps.Trees.Graphs.Maze
{
    public class RottingOranges
    {
        static int[] dr = new int[] { -1, 0, 1, 0 };
        static int[] dc = new int[] { 0, -1, 0, 1 };
        public static int OrangesRotting(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;

            int numFresh = 0;
            // Queue<int[]> q = new Queue<int[]>();
            Queue<int> q = new Queue<int>();
            Dictionary<int, int> depth = new Dictionary<int, int>();
            // map the grid
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        // q.Enqueue(new int[] { i, j});
                        int code = i * cols + j;
                        q.Enqueue(code);
                        depth.Add(code, 0);
                    }
                    //else if(grid[i][j] == 1)
                    //{
                    //    numFresh++;
                    //}
                }
            }

            if (numFresh == 0) return 0;

            int[][] dirs = new int[4][];
            dirs[0] = new int[] { 1, 0 };
            dirs[1] = new int[] { -1, 0 };
            dirs[2] = new int[] { 0, 1 };
            dirs[3] = new int[] { 0, -1 };

            int minutes = 0;

            while (q.Any())
            {
                int code = q.Dequeue();
                int r = code / cols;
                int c = code % cols;
                minutes++;
                int size = q.Count;
                for (int k = 0; k < 4; k++)
                {
                        int nr = r + dr[k];
                        int nc = c + dc[k];

                }
            }
            return numFresh == 0 ? minutes-1 : - 1;
        }
    }
}
