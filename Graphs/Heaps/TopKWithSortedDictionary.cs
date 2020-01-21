using System.Collections.Generic;
using System.Linq;

namespace Graphs.Heaps.Trees.Heaps
{
    public class TopKWithSortedDictionary
    {
        public IList<int> TopKFrequent(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k == 0) return null;
            Dictionary<int, int> dict = new Dictionary<int, int>();
            foreach (int n in nums)
            {
                if (!dict.ContainsKey(n))
                {
                    dict.Add(n, 1);
                }
                else
                {
                    dict[n]++;
                }
            }
			// O(n)

            var sorted = dict.ToList();
            var temp = sorted.OrderByDescending(x => x.Value).Take(k);

            List<int> results = new List<int>();
            foreach (var item in temp)
            {
                results.Add(item.Key);
            }
            return results;
        }
    }
}
