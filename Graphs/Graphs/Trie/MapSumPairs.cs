using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.Trie
{
    /// <summary>
    /// https://leetcode.com/problems/map-sum-pairs/
    /// </summary>
    public class MapSum
    {
        public Dictionary<string, int> nodes;
        TrieNode root;

        public class TrieNode
        {
            public Dictionary<char, TrieNode> children;
            public int sum { get; set; }
            public TrieNode()
            {
                children = new Dictionary<char, TrieNode>();
            }
        }
        public MapSum()
        {
            nodes = new Dictionary<string, int>();
            root = new TrieNode();
        }

        public void Insert(string key, int val)
        {
            TrieNode tn = root;
            int old = nodes.GetValueOrDefault(key, 0);
            nodes.Add(key, val);
            int diff = val - old;
            for (int i = 0; i < key.Length; i++)
            {
                char c = key[i];
                if (tn.children.ContainsKey(c))
                {
                    int oldSum = tn.children[c].sum;
                    tn.children[c].sum = oldSum + diff;
                    tn = tn.children[c];
                }
                else
                {
                    tn.children.Add(c, new TrieNode());
                    tn.children[c].sum = diff;
                    tn = tn.children[c];
                }
            }
        }

        public int Sum(string prefix)
        {
            TrieNode tn = root;
            int res = 0;
            for (int i = 0; i < prefix.Length; i++)
            {
                char c = prefix[i];
                if (tn.children.ContainsKey(c))
                {
                    res = tn.children[c].sum;
                    tn = tn.children[c];
                }
                else
                {
                    return 0;
                }
            }
            return res;
        }
    }
}
