using System;
using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.Trie
{
    public class SearchSuggestions
    {
        public class Trie
        {
            public Trie[] children;
            public List<string> words;
            public Trie()
            {
                words = new List<string>();
                children = new Trie[26];
            }

            public void InsertWord(string word)
            {
                Trie node = new Trie();
                Trie root = node;
                for (int i = 0; i < word.Length; i++)
                {
                    char c = word[i];
                    if (root.children[c - 'a'] == null)
                    {
                        root.children[c - 'a'] = new Trie();
                    }
                    root = root.children[c - 'a'];
                }
            }
        }

        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            Array.Sort(products);

            Trie root = new Trie();
            for (int i = 0; i < products.Length; i++)
            {
                Trie n1 = root;
                n1.InsertWord(products[i]);
                if (n1.words.Count < 3)
                {
                    n1.words.Add(products[i]);
                }
            }
            IList<IList<string>> res = new List<IList<string>>();
            Trie n = root;

            // start going over the serach word, char by char
            for (int i = 0; i < searchWord.Length; i++)
            {
                n = n.children[searchWord[i] - 'a'];

                // if we meet null 
                // that would be mean that there are no more matches possible
                // the result of this can be filled by empty lists
                if (n == null)
                {
                    for (int j = 0; j < searchWord.Length; j++)
                    {
                        res.Add(new List<string>());
                        break;
                    }
                }
                res.Add(n.words);
            }
            return res;
        }
    }
}
