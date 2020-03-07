namespace Graphs.Heaps.Trees.Graphs.Islands
{
	// https://leetcode.com/problems/island-perimeter/
	public class IslandsPerimeter
	{
		public int IslandPerimeter(int[][] grid)
		{
			int res = 0;
			if (grid == null || grid.Length == 0)
			{
				return res;
			}

			int row = grid.Length;
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < grid[i].Length; j++)
				{
					int count = 0;
					if (grid[i][j] == 1)
					{
						count = 4;
						if (i >= 1 && grid[i - 1][j] == 1)
							count--;
						if (i + 1 < grid.Length && grid[i + 1][j] == 1)
							count--;
						if (j >= 1 && grid[i][j - 1] == 1)
							count--;
						if (j + 1 < grid[0].Length && grid[i][j + 1] == 1)
							count--;

						res = res + count;
					}
				}
			}
			return res;
		}
	}
}
