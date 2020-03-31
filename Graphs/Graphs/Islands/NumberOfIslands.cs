using System;

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

        /// <summary>
        /// Similar to the ablove problem
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="column"></param>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int numberAmazonGoStores(int rows, int column, int[,] grid)
        {
            // WRITE YOUR CODE HERE
            // check for any corner cases of invalid inputs
            // return 0 in such a case
            if (grid == null || grid.Length == 0)
            {
                return 0;
            }

            int numStores = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    // check for any stores
                    if (grid[i,j] == 1)
                    {
                        numStores = numStores + DFS_StoreSearch(grid,i,j);
                    }
                }
            }
            return numStores;
        }

        /// <summary>
        /// Search the number of stores depth first
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        private int DFS_StoreSearch(int[,] grid, int i, int j)
        {
            // evaluate that it always stays inbounds
            if (i < 0 || i >= grid.GetLength(0) || j < 0 || j >= grid.GetLength(1) || grid[i,j] == 0)
            {
                return 0;
            }
            // mark the empty spaces to backtack
            grid[i,j] = 0;
            DFS_StoreSearch(grid, i + 1, j);
            DFS_StoreSearch(grid, i - 1, j);
            DFS_StoreSearch(grid, i, j + 1);
            DFS_StoreSearch(grid, i, j - 1);
            return 1;
        }
    }


}
