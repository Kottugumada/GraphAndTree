using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs
{
    public class ReachingPointsMove
    {
        public class Point
        {
            public int x;
            public int y;
            public Point(int X, int Y)
            {
                x = X;
                y= Y;
            }
        }
        public bool ReachingPoints(int sx, int sy, int tx, int ty)
        {
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(new Point(sx,sy));
            while (q.Count > 0)
            {
                int size = q.Count;
                Point p = q.Dequeue();
                while (size>0)
                {
                    if (((p.x + p.y == tx ) && p.y == ty) || ((p.x == tx) && p.x + p.y == ty))
                    {
                        return true;
                    }
                    else
                    {
                        q.Enqueue(new Point(p.x + p.y,p.y));
                        q.Enqueue(new Point(p.y, p.x + p.y));
                    }
                    size--;
                }
            }
            return false;
        }
    }
}
