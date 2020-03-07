using System;

namespace Graphs.Heaps.Trees.Graphs.Islands
{
	// https://leetcode.com/problems/max-area-of-island/
	public class MaxArea
	{
		public int MaxAreaOfIsland(int[][] grid)
		{
			int maxArea = 0;

			if (grid == null || grid.Length == 0)
			{
				return maxArea;
			}
			int row = grid.Length;
			int col = grid[0].Length;
			for (int i = 0; i < row; i++) 
			{
				for (int j = 0; j < col; j++)
				{
					if (grid[i][j] == 1)
					{
						maxArea = Math.Max(maxArea, AreaOfIslands(grid, i, j));
					}
				}
			}
			return maxArea;
		}

		private int AreaOfIslands(int[][] grid, int i, int j)
		{
			if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 0)
			{
				return 0;
			}

			grid[i][j] = 0;
			return 1 + AreaOfIslands(grid, i + 1, j) + AreaOfIslands(grid, i - 1, j) + AreaOfIslands(grid, i, j + 1) + AreaOfIslands(grid, i, j - 1);
		}
	}
}
