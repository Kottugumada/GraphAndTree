using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs.Heaps.Trees.Graphs.Topological_Sort
{
    public class AlienDictionary
    {
        public string AlienOrder(string[] words)
        {
            if (words == null || words.Length == 0)
                return "";

            if (words.Length == 1)
                return words[0];

            int[,] adj = new int[26, 26];
            int[] charExists = new int[26];

            foreach (string word in words)
                foreach (char ch in word)
                    charExists[ch - 'a'] = 1;

            //Create adjacency matrix
            for (int i = 0; i < words.Length - 1; i++)
            {
                int j = 0;

                while (j < Math.Min(words[i].Length, words[i + 1].Length))
                {
                    if (words[i][j] != words[i + 1][j])
                    {
                        adj[words[i][j] - 'a', words[i + 1][j] - 'a'] = 1;
                        break;
                    }

                    j++;
                }
            }

            return LexiSort(adj, charExists);
        }

        private string LexiSort(int[,] adj, int[] charExists)
        {
            int[] inDegree = new int[26];
            int nodeCount = 0;

            for (int i = 0; i < 26; i++)
            {
                if (charExists[i] == 1)
                {
                    nodeCount++;

                    for (int j = 0; j < 26; j++)
                        if (adj[i, j] == 1)
                        {
                            inDegree[j]++;  //The edge is from i to j
                        }
                }
            }

            Queue<int> que = new Queue<int>();

            for (int i = 0; i < 26; i++)
                if (charExists[i] == 1 && inDegree[i] == 0)
                    que.Enqueue(i);

            StringBuilder result = new StringBuilder();

            while (que.Count != 0)
            {
                int ch = que.Dequeue();

                result.Append((char)(ch + 'a'));

                for (int i = 0; i < 26; i++)
                    if (adj[ch, i] == 1 && --inDegree[i] == 0)
                        que.Enqueue(i);
            }

            //If there is loop or if there are disjoint graphs, nodecount will not match visited count
            return nodeCount == result.Length ? result.ToString() : "";
        }
    }
}
