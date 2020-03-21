namespace Graphs.Heaps.Trees.Graphs.Trie
{
    public class TrieNode
    {
        public bool isWord;
        public TrieNode[] children;
        public TrieNode()
        {
            children = new TrieNode[26];
        }
    }
    public class TrieDataStructure
    {
        public TrieNode root;
        public TrieDataStructure()
        {
            root = new TrieNode();
        }

        /// <summary>
        /// Inserts a word into Trie
        /// </summary>
        /// <param name="word"></param>
        public void InsertWord(string word)
        {
            TrieNode tn = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (tn.children[c-'a'] == null)
                {
                    tn.children[c - 'a'] = new TrieNode();
                }
                tn = tn.children[c - 'a'];
            }
            tn.isWord = true;
        }

        /// <summary>
        /// Returns true if a word is in the Trie
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Search(string word)
        {
            TrieNode tn = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (tn.children[c-'a'] == null)
                {
                    return false;
                }
                tn = tn.children[c - 'a'];
            }
            return tn.isWord;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode tn = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                char c = prefix[i];
                if (tn.children[c-'a'] == null)
                {
                    return false;
                }
                tn = tn.children[c - 'a'];
            }
            return true;
        }
    }
}
