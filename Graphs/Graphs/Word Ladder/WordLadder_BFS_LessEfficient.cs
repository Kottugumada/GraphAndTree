using System.Collections.Generic;
using System.Linq;

namespace Graphs.Heaps.Trees.Graphs.Word_Ladder
{
    public class WordLadder_BFS_LessEfficient
    {
        /// <summary>
        /// https://leetcode.com/problems/word-ladder
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<string> hs = new HashSet<string>();
            foreach (var word in wordList)
            {
                hs.Add(word);
            }
            if (!hs.Contains(endWord))
            {
                return 0;
            }
            Queue<string> que = new Queue<string>();
            que.Enqueue(beginWord);
            int level = 1;
            while (que.Any())
            {
                int size = que.Count;
                for (int i = 0; i < size; i++)
                {
                    string currentWord = que.Dequeue();
                    char[] wordChars = currentWord.ToCharArray();
                    for (int j = 0; j < wordChars.Length; j++)
                    {
                        char originalChar = wordChars[j];
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            if (wordChars[j] == c)
                            {
                                continue;
                            }
                            wordChars[j] = c;
                            string newWord = new string(wordChars);
                            if (newWord.Equals(endWord))
                            {
                                return level + 1;
                            }
                            if (hs.Contains(newWord))
                            {
                                que.Enqueue(newWord);
                                hs.Remove(newWord);
                            }
                        }
                        wordChars[j] = originalChar;
                    }

                }
                level++;
            }
            return 0;
        }

        /// <summary>
        /// https://leetcode.com/problems/word-ladder-ii/
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            IList<IList<string>> res = new List<IList<string>>();
            // use a hashSet for better retrieval times
            HashSet<string> hs = new HashSet<string>();
            foreach (var item in wordList)
            {
                hs.Add(item);
            }

            // check if endWord exists in that hashSet
            if (!hs.Contains(endWord))
            {
                return res;
            }
            int len = beginWord.Length;
            Queue<string> que = new Queue<string>();
            que.Enqueue(beginWord);
            while (que.Any())
            {
                List<string> transformations = new List<string>();
                int size = que.Count();
                for (int i = 0; i < size; i++)
                {
                    string currentWord = que.Dequeue();
                    char[] currentWordArr = currentWord.ToCharArray();
                    for (int j = 0; j < currentWordArr.Length; j++)
                    {
                        char originalChar = currentWordArr[j];
                        for (char k = 'a'; k <= 'z'; k++)
                        {
                            if (currentWordArr[j] == k) { continue; }
                            currentWordArr[j] = k;
                            string newWord = new string(currentWordArr);
                            if (newWord.Equals(currentWord))
                            {
                                transformations.Add(currentWord);
                            }
                            if (hs.Contains(newWord))
                            {
                                que.Enqueue(newWord);
                                hs.Remove(newWord);
                            }
                        }
                        currentWordArr[j] = originalChar;
                    }
                }
                res.Add(transformations);
            }
            return res;
        }
    }
}
