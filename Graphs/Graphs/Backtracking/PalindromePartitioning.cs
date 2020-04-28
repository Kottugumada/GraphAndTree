using System.Collections.Generic;

namespace Backtracking
{
    public class PalindromePartitioning
    {
        /// <summary>
        /// https://leetcode.com/problems/palindrome-partitioning/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<IList<string>> Partition(string s)
        {
            IList<IList<string>> res = new List<IList<string>>();
            Backtracking_Palindrome(res, new List<string>(), s, 0);
            return res;
        }

        private void Backtracking_Palindrome(IList<IList<string>> res, List<string> partitions, string s, int start)
        {
            if (start == s.Length)
            {
                res.Add(new List<string>(partitions));
                return;
            }
            else
            {
                for (int i = start; i < s.Length; i++)
                {
                    if(isPalindrome(s,start, i))
                    {
                        partitions.Add(s.Substring(start, i-start+1));
                        Backtracking_Palindrome(res, partitions, s, i+1);
                        partitions.RemoveAt(partitions.Count - 1);
                    }
                }
            }
        }

        private bool isPalindrome(string s, int start, int end)
        {
            char[] c = s.ToCharArray();
            while (start<end)
            {
                if (c[start++] != c[end--])
                    return false;
            }
            return true;
        }
    }
}
