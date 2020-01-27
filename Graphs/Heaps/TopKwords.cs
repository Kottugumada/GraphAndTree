using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs.Heaps.Trees.Heaps
{
    public class TopKwords
    {
        public IList<string> TopKFrequent(string[] words, int k)
        {
            if (words == null || words.Length == 0 || k == 0) return null;
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (string word in words)
            {
                dict[word] = dict.ContainsKey(word) ? dict[word] + 1 : 1;
            }

            return dict.OrderByDescending(x => x.Value)
                        .ThenBy(x => x.Key)
                        .Take(k)
                        .Select(x => x.Key)
                        .ToList();
        }
    }
}
