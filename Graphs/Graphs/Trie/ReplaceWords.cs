using System.Collections.Generic;
using System.Text;

namespace Graphs.Heaps.Trees.Graphs.Trie
{
    public class ReplaceWordsTrie
    {
        TrieNode root = new TrieNode();
        public string ReplaceWords(IList<string> dict, string sentence)
        {
            string[] str = sentence.Split(" ");
            StringBuilder sb = new StringBuilder();
            BuildTrie(dict);
            for (int i = 0; i < str.Length; i++)
            {
                string s = str[i];
                if (root.children[s[0] - 'a'] != null)
                {
                    str[i] = Replace(s);
                }
                sb.Append(str[i]);
                sb.Append(" ");
            }
            return sb.ToString().Trim();
        }

        private string Replace(string str)
        {
            StringBuilder sb = new StringBuilder();
            TrieNode tn = root;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                int id = c - 'a';
                if (tn == null)
                {
                    break;
                }
                else if (tn.isWord)
                {
                    return sb.ToString();
                }
                else if (root.children[id] != null && !tn.isWord)
                {
                    sb.Append(c);
                }
                tn = tn.children[id];
            }
            return str;
        }

        private void BuildTrie(IList<string> str)
        {
            // build a trie out of the dict
            TrieNode root = new TrieNode();
            for (int i = 0; i < str.Count; i++)
            {
                TrieNode curr = root;
                string element = str[i];
                for (int j = 0; j < element.Length; j++)
                {
                    char c = element[j];
                    if (curr.children[c - 'a'] == null)
                    {
                        curr.children[c - 'a'] = new TrieNode();
                    }
                    curr = curr.children[c - 'a'];
                }
                curr.isWord = true;
            }
        }
    }

}
