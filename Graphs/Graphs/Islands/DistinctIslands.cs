using System.Collections.Generic;
using System.Text;

namespace Graphs.Heaps.Trees.Graphs.Islands
{
    public class DistinctIslands
    {
        /// <summary>
        /// https://leetcode.com/problems/number-of-distinct-islands
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumDistinctIslands(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }
            HashSet<string> hs = new HashSet<string>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        StringBuilder sb = new StringBuilder();
                        DFS_Islands(grid,i,j,sb);
                        hs.Add(sb.ToString());
                    }
                }
            }
            return hs.Count;
        }

        private void DFS_Islands(int[][] grid, int i, int j, StringBuilder sb)
        {
            if (i<0|| i>=grid.Length || j<0 || j>= grid[0].Length)
            {
                return;
            }
            grid[i][j] = 0;
            if (i-1>=0 && grid[i-1][j] == 1)
            {
                sb.Append("up");
                DFS_Islands(grid, i-1, j, sb);
            }
            else
            {
                sb.Append("notUp");
            }
            if (i + 1 < grid.Length && grid[i + 1][j] == 1)
            {
                sb.Append("down");
                DFS_Islands(grid, i + 1, j, sb);
            }
            if (j + 1 < grid[0].Length && grid[i][j+1] == 1)
            {
                sb.Append("right");
                DFS_Islands(grid, i, j+1, sb);
            }
            if (j - 1 >= 0 && grid[i][j-1] == 1)
            {
                sb.Append("down");
                DFS_Islands(grid, i, j-1, sb);
            }
            else
            {
                sb.Append("none");
            }
        }
    }
}
