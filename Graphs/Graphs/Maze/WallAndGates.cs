using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.Maze
{
    public class WallAndGates
    {
        private class Point
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
        /// https://leetcode.com/problems/walls-and-gates
        /// </summary>
        /// <param name="rooms"></param>
        public void WallsAndGates(int[][] rooms)
        {
            if (rooms == null || rooms.Length == 0 || rooms[0].Length == 0)
            {
                return;
            }

            Queue<Point> q = new Queue<Point>();
            // find all gates and add to the queue
            for (int i = 0; i < rooms.Length; i++)
            {
                for (int j = 0; j < rooms[0].Length; j++)
                {
                    if (rooms[i][j] == 0)
                    {
                        q.Enqueue(new Point(i, j));
                    }
                }
            }

            while (q.Count > 0)
            {
                Point p = q.Dequeue();
                if (TryFindGates(rooms, p.X + 1, p.Y))
                {
                    if (rooms[p.X + 1][p.Y] == int.MaxValue)
                    {
                        rooms[p.X + 1][p.Y] = rooms[p.X][p.Y] + 1;
                        q.Enqueue(new Point(p.X + 1, p.Y));
                    }
                }
                if (TryFindGates(rooms, p.X - 1, p.Y))
                {
                    if (rooms[p.X - 1][p.Y] == int.MaxValue)
                    {
                        rooms[p.X - 1][p.Y] = rooms[p.X][p.Y] + 1;
                        q.Enqueue(new Point(p.X - 1, p.Y));
                    }
                }
                if (TryFindGates(rooms, p.X, p.Y + 1))
                {
                    if (rooms[p.X][p.Y + 1] == int.MaxValue)
                    {
                        rooms[p.X][p.Y + 1] = rooms[p.X][p.Y] + 1;
                        q.Enqueue(new Point(p.X, p.Y + 1));
                    }
                }
                if (TryFindGates(rooms, p.X, p.Y - 1))
                {
                    if (rooms[p.X][p.Y - 1] == int.MaxValue)
                    {
                        rooms[p.X][p.Y - 1] = rooms[p.X][p.Y] + 1;
                        q.Enqueue(new Point(p.X, p.Y - 1));
                    }
                }
            }
        }

        private bool TryFindGates(int[][] rooms, int x, int y)
        {
            if (x>=0 && y >=0 && x>= rooms.Length && y >= rooms[0].Length && rooms[x][y] == int.MaxValue)
            {
                return true;
            }
            return false;
        }
    }
    
}
