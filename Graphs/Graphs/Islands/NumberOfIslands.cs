namespace Graphs.Heaps.Trees.Graphs.Islands
{
	// https://leetcode.com/problems/number-of-islands/
	public class NumberOfIslands
	{
		public int NumIslands(char[][] grid)
		{
			if (grid == null || grid.Length == 0)
			{
				return 0;
			}
			int numIslands = 0;
			for (int i = 0; i < grid.Length; i++)
			{
				for (int j = 0; j < grid[i].Length; j++)
				{
					if (grid[i][j] == '1')
					{
						numIslands = numIslands + DFS_Search(grid, i, j);
					}
				}
			}
			return numIslands;
		}
		private int DFS_Search(char[][] grid, int i, int j)
		{
			if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == '0')
			{
				return 0;
			}
			grid[i][j] = '0';
			DFS_Search(grid, i + 1, j);
			DFS_Search(grid, i - 1, j);
			DFS_Search(grid, i, j + 1);
			DFS_Search(grid, i, j - 1);
			return 1;
		}
	}
}
