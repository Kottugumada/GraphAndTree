// https://leetcode.com/problems/k-closest-points-to-origin
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Heaps.Trees.Heaps
{
    public class KClosedToOrigin
    {
        public int[][] KClosest(int[][] points, int K)
        {
        Dictionary<int[], double> dict = new Dictionary<int[], double>();
        for (int i = 0; i < points.Length; i++)
        {
            double dist = Math.Sqrt(points[i][0] * points[i][0] + points[i][1] * points[i][1]);
                int[] point = new int[] { points[i][0], points[i][1] };
            dict.Add(point, dist);
        }
        return dict.OrderBy(x=>x.Value)
                    .Take(K)
                    .Select(x=>x.Key)
                    .ToArray();
    }
}
}
