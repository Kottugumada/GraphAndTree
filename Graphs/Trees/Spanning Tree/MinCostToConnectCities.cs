using System;

namespace Graphs.Heaps.Trees.Trees.Spanning_Tree
{
    public class MinCostToConnectCities
    {
        int[] parent;
        int groupCount;
        /// <summary>
        /// https://leetcode.com/discuss/interview-question/356981 (assume weight as 0 to solve this)
        /// https://leetcode.com/discuss/interview-question/357310 (assume weight as 0 to solve this)
        /// https://leetcode.com/problems/connecting-cities-with-minimum-cost
        /// </summary>
        /// <param name="N"></param>
        /// <param name="connections"></param>
        /// <returns></returns>
        public int MinimumCost(int N, int[][] connections)
        {
            // to prevent overflow
            parent = new int[N+1];
            for (int i = 0; i <= N; i++)
            {
                parent[i] = i;
            }
            groupCount = N;
            // sort array by weight
            Array.Sort(connections, (x,y)=>x[2].CompareTo(y[2]));
            int res = 0;
            foreach (var item in connections)
            {
                int x = item[0], y = item[1];
                // not in the same group
                if (Find(x) != Find(y))
                {
                    res = res + item[2]; // increment cost (or weight)
                    Union(x,y); // Unionify
                }
            }
            return groupCount == 1 ? res : -1;
        }

        private void Union(int x, int y)
        {
            int rootx = Find(x);
            int rooty = Find(y);
            if (rootx != rooty)
            {
                parent[rootx] = rooty;
                groupCount--;
            }
        }

        private int Find(int x)
        {
            if (parent[x] == x)
            {
                return parent[x];
            }
            parent[x] = Find(parent[x]);
            return parent[x];
        }
    }
}
