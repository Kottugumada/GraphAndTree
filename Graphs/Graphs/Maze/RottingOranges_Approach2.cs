using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.Maze
{
    public class RottingOranges_Approach2
    {
        /// <summary>
        /// Similar to Number of Islands
        /// https://leetcode.com/problems/rotting-oranges/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int OrangesRotting(int[][] grid)
        {
            Queue<Point> queue = new Queue<Point>();
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    // enqueue all rotten oranges
                    if (grid[i][j] == 2) queue.Enqueue(new Point(i, j));
                }
            }

            var count = queue.Count == 0 ? 0 : -1; // set count to -1 because queue may have been preloaded with already rotten apples (or oranges)

            while (queue.Count > 0)
            {
                count++;
                var size = queue.Count; // important to copy the value because queue.Count will change in below the for loop
                for (var i = 0; i < size; i++)
                {
                    Point p = queue.Dequeue();
                    if (TryRotOne(grid, p.X + 1, p.Y))
                    {
                        queue.Enqueue(new Point(p.X + 1, p.Y));
                    }
                    if (TryRotOne(grid, p.X - 1, p.Y))
                    {
                        queue.Enqueue(new Point(p.X - 1, p.Y));
                    }
                    if (TryRotOne(grid, p.X, p.Y + 1))
                    {
                        queue.Enqueue(new Point(p.X, p.Y + 1));
                    }
                    if (TryRotOne(grid, p.X, p.Y - 1))
                    {
                        queue.Enqueue(new Point(p.X, p.Y - 1));
                    }
                }
            }

            // at the end if there are still fresh oranges left
            // return -1 since it means it was not possible to rot all fresh oranges
            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1) return -1;
                }
            }

            return count;
        }

        private bool TryRotOne(int[][] grid, int x, int y)
        {
            // if the value is valid and is fresh, try to rot it
            // this is called on the queue of rotten oranges, so definitely is adjacent to a rotten orange
            if (x >= 0 && x < grid.Length && y >= 0 && y < grid[x].Length && grid[x][y] == 1)
            {
                grid[x][y] = 2;
                return true;
            }
            return false;
        }

        private class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X;
            public int Y;
        }
    }
}
