using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.Maze
{
    public class ShortestPathWithObstacles
    {
        public class Point
        {
            public int X;
            public int Y;
            public int k;
            public Point(int x, int y, int p)
            {
                X = x;
                Y = y;
                k = p;
            }
        }
        /// <summary>
        /// https://leetcode.com/problems/shortest-path-in-a-grid-with-obstacles-elimination/
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int ShortestPath(int[][] grid, int k)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return -1;
            }
            bool[][][] visited = new bool[k + 1][][];
            int ans = 0;

            // direction vectors
            int[][] dirs = new int[4][];
            dirs[0] = new int[] { 0, 1 }; // right
            dirs[1] = new int[] { 0, -1 }; // left
            dirs[2] = new int[] { 1, 0 }; // down
            dirs[3] = new int[] { -1, 0 }; // up

            int m = grid.Length;
            int n = grid[0].Length;
            if (k>=m+n-2) // m-1 + n-1
            {
                return m+n-2;
            }
            visited[k][0][0] = true;
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(new Point(0,0,k));
            while (q.Count>0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    Point p = q.Dequeue();
                    int x = p.X;
                    int y = p.Y;
                    int remainingK = p.k;
                    if (x == m-1 && y== n-1)
                    {
                        return ans;
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        int newX = x + dirs[i][0];
                        int newY = y + dirs[i][1];
                        if (newX>=0 && newX<m && newY>=0 && newY<n)
                        {
                            int newK = remainingK;
                            if (grid[newX][newY] == 1) { 
                            newK--;
                            }
                            if (k>=0 && visited[newK][newX][newY] == false)
                            {
                                visited[newK][newX][newY] = true;
                                q.Enqueue(new Point(newX, newY, k));
                            }
                        }
                    }
                }
                ans++;
            }
            return -1;
        }
    }
}
