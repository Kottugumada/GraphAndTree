using System.Collections.Generic;

namespace Backtracking
{
    public class Parenthesis
    {
        /// <summary>
        /// https://leetcode.com/problems/generate-parentheses/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> res = new List<string>();
            Backtrack_Parenthesis(res,"",0 , 0, n);
            return res;
        }

        private void Backtrack_Parenthesis(IList<string> res, string curr, int open, int close, int maxBrackets)
        {
            if (curr.Length == maxBrackets*2)
            {
                res.Add(curr);
                return;
            }
            if (open < maxBrackets)
            {
                Backtrack_Parenthesis(res,curr+"(",open+1,close,maxBrackets);
            }
            if (close<open)
            {
                Backtrack_Parenthesis(res, curr + ")", open, close + 1, maxBrackets);
            }
        }
    }
}
