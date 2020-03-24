using System.Collections.Generic;
using System.Linq;

// https://leetcode.com/problems/rotting-oranges

namespace Graphs.Heaps.Trees.Graphs.Maze
{
    public class RottingOranges
    {
        private int[][] grid;
        private int rows;
        private int columns;

        public int OrangesRotting(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
                return -1;

            this.grid = grid;
            rows = grid.Length;
            columns = grid[0].Length;

            int fresh = 0;
            int rotten = 0;
            // count fresh and rotten
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (grid[i][j] == 1)
                        fresh++;
                    else if (grid[i][j] == 2)
                        rotten++;
                }
            }

            // nothing to rot
            if (fresh == 0)
                return 0;

            // from nowhere to rot
            if (rotten == 0)
                return -1;

            int steps = 0;
            int left = fresh;
            // count steps
            while (left > 0)
            {
                int changed = Update();
                if (changed == 0)
                    break;

                // update remaining
                left -= changed;
                steps++;
            }

            // something left means it is impossible to do it
            return left > 0 ? -1 : steps;
        }

        private bool Outside(int i, int j)
        {
            return i < 0 || i >= rows || j < 0 || j >= columns;
        }

        private int Update()
        {
            int changed = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (grid[i][j] == 2)
                    {
                        changed += Mark(i - 1, j);
                        changed += Mark(i + 1, j);
                        changed += Mark(i, j - 1);
                        changed += Mark(i, j + 1);
                    }
                }
            }

            // update to rotten candidate to rotten
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (grid[i][j] == 3)
                    {
                        grid[i][j] = 2;
                    }
                }
            }


            return changed;
        }

        int Mark(int i, int j)
        {
            if (Outside(i, j) || grid[i][j] != 1)
                return 0;

            // mark as rotten candidate
            grid[i][j] = 3;

            return 1;
        }
    }
}
