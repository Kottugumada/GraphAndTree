using System.Collections.Generic;

namespace Backtracking
{
    public class WordSearch
    {
        /// <summary>
        /// https://leetcode.com/problems/word-search
        /// </summary>
        /// <param name="board"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exist(char[][] board, string word)
        {
            if (board == null || board.Length == 0)
            {
                return false;
            }
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == word[0] && Backtracking_WordSearch(board, word, i, j, 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool Backtracking_WordSearch(char[][] board, string word, int i, int j, int count)
        {
            // count here is my backtracking iterator
            if (count == word.Length)
            {
                return true;
            }
            if (i<0 || i>=board.Length || j<0 || j>= board[i].Length || board[i][j] != word[count])
            {
                return false;
            }
            char temp = board[i][j]; // not to lose the currrent value
            board[i][j] = '#'; // mark the cell
            bool found = Backtracking_WordSearch(board, word, i + 1, j, count + 1) ||
                Backtracking_WordSearch(board, word, i - 1, j, count + 1) ||
                Backtracking_WordSearch(board, word, i, j + 1, count + 1) ||
                Backtracking_WordSearch(board, word, i, j - 1, count + 1);
            board[i][j] = temp; // retrieve the value
            return found;
        }

        char[][] board;
        /// <summary>
    /// https://leetcode.com/problems/word-search-ii/
    /// </summary>
    /// <param name="board"></param>
    /// <param name="words"></param>
    /// <returns></returns>
        public IList<string> FindWords(char[][] board, string[] words)
    {
        IList<string> res = new List<string>();
        // step 1 Construct the trie
        TrieNode root = new TrieNode();
        foreach (var word in words)
        {
            TrieNode node = root;
            foreach (var letter in word.ToCharArray())
            {
                if (node.children.ContainsKey(letter))
                {
                    node = node.children[letter];
                }
                else
                {
                    // if node not found add a new tried node with that letter
                    TrieNode newNode = new TrieNode();
                    node.children.Add(letter, newNode);
                    node = newNode;
                }
            }
            // store the word in the trie
            node.word = word;
        }
            this.board = board;
            // step 2. Backtracking for each cell in the board
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[0].Length; col++)
                {
                    if (root.children.ContainsKey(board[row][col]))
                    {
                        Backtracking_WordSearch2(row,col,root,res);
                    }
                }
            }
            return res;
    }

        private void Backtracking_WordSearch2(int row, int col, TrieNode parentNode, IList<string> res)
        {
            char letter = board[row][col];
            TrieNode currNode = parentNode.children[letter];

            // check if there is a match
            if (currNode.word != null)
            {
                res.Add(currNode.word);
                currNode.word = null;
            }

            // mark the current letter before exploration
            board[row][col] = '#';

            // explore neighbor cells in around-clock directions: up, right, down, left
            int[] dr = { -1, 0, 1, 0 };
            int[] dc = { 0, 1, 0, -1 };
            for (int i = 0; i < 4; ++i)
            {
                int newRow = row + dr[i];
                int newCol = col + dc[i];
                if (newRow < 0 || newRow >= board.Length || newCol < 0
                    || newCol >= board[0].Length)
                {
                    continue;
                }
                if (currNode.children.ContainsKey(board[newRow][newCol]))
                {
                    Backtracking_WordSearch2(newRow, newCol, currNode, res);
                }
            }

            // end of exploration, reset the previous word
            board[row][col] = letter;

            // optimization: incrementally remove the leaf nodes
            if (currNode.children == null)
            {
                parentNode.children.Remove(letter);
            }
        }
    }
    public class TrieNode
    {
        public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
        public string word = null;
        public TrieNode() { }
    }
}
