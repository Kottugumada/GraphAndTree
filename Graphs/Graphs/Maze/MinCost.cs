using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs.Heaps.Trees.Graphs.Islands
{
    public class MinCostInAGrid
    {
        public class Point
        {
            public int X;
            public int Y;
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        /// <summary>
        /// https://leetcode.com/problems/minimum-cost-to-make-at-least-one-valid-path-in-a-grid
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int MinCost(int[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return -1;
            }
            // direction vectors
            int[][] dirs = new int[4][];
            dirs[0] = new int[] { 0, 1 }; // right
            dirs[1] = new int[] { 0, -1 }; // left
            dirs[2] = new int[] { 1, 0 }; // down
            dirs[3] = new int[] { -1, 0 }; // up

            // cost array
            int[,] cost = new int[grid.Length, grid[0].Length];
            // initialize all the cost array components
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    cost[i,j] = int.MaxValue;
                }
            }

            // Queue for BFS
            Queue<Point> q = new Queue<Point>();

            // enqueue the point of entry, which is (0,0)
            cost[0, 0] = 0;
            q.Enqueue(new Point(0,0));

            // start search, set the cost value for the first point
            while (q.Count>0)
            {
                // dequeue the point from the queue
                Point p = q.Dequeue();
                // current cost is eual to the value at that node
                int currentCost = cost[p.X,p.Y];

                // explore all its neighbors using the direction vectors
                for (int i = 0; i < 4; i++)
                {
                    int newX = p.X + dirs[i][0];
                    int newY = p.Y + dirs[i][1];
                    int newCost = currentCost + (grid[p.X][p.Y] == (i + 1) ? 0 : 1);

                    // check if the neighboring values are within grid bounds
                    if (newX >= 0 && newY >=0 && newX < grid.Length && newY < grid[0].Length) 
                    {
                        // if the cost on the newighbor is larger update the cost of that node
                        if (newCost < cost[newX,newY])
                        {
                            cost[newX,newY] = newCost;
                            // queue that node for BFS
                            q.Enqueue(new Point(newX, newY));
                        }
                    }
                }
            }
            // return the cost at the last node
            return cost[grid.Length-1,grid[0].Length-1];
        }
    }
}
