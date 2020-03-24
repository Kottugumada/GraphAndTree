namespace Graphs.Heaps.Trees.Trees.Spanning_Tree
{
    public class ConnectedComponents
    {
        /// <summary>
        /// https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/
        /// Similar to Number of islands II
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <returns></returns>
        public int CountComponents(int n, int[][] edges)
        {
            int[] parent = new int[n];
            for (int i = 0; i < n; i++)
            {
                parent[i] = i; // bijection
            }
            foreach (var item in edges)
            {
                int root1 = Find(parent,item[0]);
                int root2 = Find(parent, item[1]);
                if (root1!=root2)
                {
                    parent[root1] = root2;
                    n--;
                }
            }
            return n;
        }
        private int Find(int[] parent, int x)
        {
            while (parent[x] != x)
            {
                parent[x] = parent[parent[x]];
                x = parent[x];
            }
            return x;
        }
    }
}
