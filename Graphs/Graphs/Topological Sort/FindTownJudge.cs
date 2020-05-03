namespace Graphs.Heaps.Trees.Graphs.Topological_Sort
{
    public class FindTownJudge
    {
        public int FindJudge(int N, int[][] trust)
        {
            int n = trust.Length;
            if (trust == null || trust.Length == 0)
            {
                return N;
            }
            // a town judge would have 0 incoming edges
            int[] inDegree = new int[N+1];
            foreach (var item in trust)
            {
                inDegree[item[0]]++; // if 1 knows 3, increment the number of people who know 3
                inDegree[item[1]]--; // similarly decrement 1
            }
            for (int i = 0; i < inDegree.Length; i++)
            {
                if (inDegree[i] == N-1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
