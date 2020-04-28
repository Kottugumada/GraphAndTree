namespace Graphs.Heaps.Trees.Graphs.Trie
{
    // https://leetcode.com/problems/add-and-search-word-data-structure-design
    public class WordDictionary
    {

        /** Initialize your data structure here. */
        Trier root;
        public WordDictionary()
        {
            root = new Trier();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            Trier tn = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (tn.children[c - 'a'] == null)
                {
                    tn.children[c - 'a'] = new Trier();
                }
                tn = tn.children[c - 'a'];
            }
            tn.isWord = true;
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            Trier currNode = root;
            return SearchHelper(word,0,currNode);
        }
        private bool SearchHelper(string word, int start, Trier curr)
        {
            if (start == word.Length)
            {
                if (curr.isWord)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            char c = word[start];
            if (c == '.')
            {
                for (int i = 0; i < 26; i++)
                {
                    if (curr.children[i] != null)
                    {
                        if (SearchHelper(word,start+1,curr.children[i]))
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                if (curr.children[c-'a'] == null)
                {
                    return false;
                }
                else
                {
                    return SearchHelper(word,start+1,curr.children[c-'a']);
                }
            }
            return false;
        }
    }
    public class Trier
    {
        public bool isWord;
        public Trier[] children;
        public Trier()
        {
            children = new Trier[26];
        }
    }
}
