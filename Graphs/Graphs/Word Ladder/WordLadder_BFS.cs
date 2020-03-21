using System.Collections.Generic;
using System.Linq;

namespace Graphs.Heaps.Trees.Graphs.Word_Ladder
{
    public class WordLadder_BFS
    {
        /// <summary>
        /// https://leetcode.com/problems/word-ladder
        /// </summary>
        /// <param name="beginWord"></param>
        /// <param name="endWord"></param>
        /// <param name="wordList"></param>
        /// <returns></returns>
        public int LadderLength_BFS(string beginWord, string endWord, IList<string> wordList)
        {
            // since all  words are of the same length
            int l = beginWord.Length;

            // dictionary to hold a combination of words that can be formed from any given word, by changing one word at a time
            Dictionary<string, List<string>> allComboDict = new Dictionary<string, List<string>>();
            foreach (var word in wordList)
            {
                for (int i = 0; i < l; i++)
                {
                    // key is the generic word
                    // value is a list of words which have the same intermediate generic word
                    // instead of running through the entire lowercase alphabet, we can use a more generic approach of 
                    // substituting it with a character to make tranformations easier
                    /*
                     allComboDict at the end of a loop from 0 till length of (beginWord) "hit" would be
                     [0] (*ot,new List<string>(){hot})
                     [1] (h*t,new List<string>(){hot})
                     [2] (ho*,new List<string>(){hot})

                    when we parse the next word, from the list ["hot","dot","dog","lot","log","cog"]
                    the dictionary already has a key *ot
                    so, now
                    [0] (*ot, new List<string>(){hot,dot})
                    [1] (h*t,new List<string>(){hot})
                    [2] (ho*,new List<string>(){hot})
                     */
                    string maskedWord = word.Substring(0,i) + "*" + word.Substring(i+1);
                    List<string> transformations = allComboDict.GetValueOrDefault(maskedWord, new List<string>());
                    transformations.Add(word);
                    allComboDict[maskedWord] = transformations;
                }
            }

            // instantiate the queue for BFS
            Queue<Dictionary<string, int>> que = new Queue<Dictionary<string, int>>();
            que.Enqueue(new Dictionary<string, int>()
            {
                { beginWord, 1 }
            });

            // use visited dictionary to avoiud repeating
            Dictionary<string, bool> visited = new Dictionary<string, bool>();
            visited.Add(beginWord, true);

            while (que.Count>0)
            {
                Dictionary<string, int> node = que.Dequeue();
                string word = node.Keys.First();
                int level = node.Values.First();
                for (int i = 0; i < l; i++)
                {
                    // intermediate words for the current word
                    string maskedWord = word.Substring(0, i) + "*" + word.Substring(i + 1);
                    // next states are all the words which share the ame intermediate state
                    foreach (var adjacentWord in allComboDict.GetValueOrDefault(maskedWord,new List<string>()))
                    {
                        // if at any point we find what we are looking for, we return the answer
                        if (adjacentWord.Equals(endWord))
                        {
                            return level + 1;
                        }
                        // otherwise add it to BFS queue and mark it as visited
                        if (!visited.ContainsKey(adjacentWord))
                        {
                            visited.Add(adjacentWord, true);
                            que.Enqueue(new Dictionary<string, int>
                            {
                                { adjacentWord, level + 1 }
                            });
                        }
                    }
                }
            }
            return 0;
        }
    }
}
