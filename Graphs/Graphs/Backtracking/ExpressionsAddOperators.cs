using System.Collections.Generic;
using System.Text;

namespace Backtracking
{
    public class ExpressionsAddOperators
    {
        /// <summary>
        /// https://leetcode.com/problems/expression-add-operators
        /// </summary>
        /// <param name="num"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<string> AddOperators(string num, int target)
        {
            IList<string> res = new List<string>();
            if (string.IsNullOrEmpty(num))
            {
                return res;
            }
            StringBuilder sb = new StringBuilder();
            DFS(res,sb,num,0,target,0,0);
            return res;
        }
        /// <summary>
        /// DFS and backtrack into all the possible ways
        /// </summary>
        /// <param name="res"></param>
        /// <param name="sb"></param>
        /// <param name="num"></param>
        /// <param name="pos"></param>
        /// <param name="target"></param>
        /// <param name="eval">overflow prevention we use a long type once it is larger than Integer.MAX_VALUE or minimum, we get over it.</param>
        /// <param name="multiplied">similarly we use a long type once it is larger than Integer.MAX_VALUE or minimum, we get over it.</param>
        private void DFS(IList<string> res, StringBuilder path, string num, int pos, int target, long eval, long multiplied)
        {
            /*
            if we have reached the end of the string:
                if the expression evaluates to the target:
                    Valid Expression found!
             */
            if (pos == num.Length)
            {
                if (target == eval)
                {
                    res.Add(path.ToString());
                }
                return;
            }
            int len = path.Length;
            long curr = 0;

            /*
            else dfs over all the operators
             */
            for (int i = pos; i < num.Length; i++)
            {
                // because we can't have numbers with multiple digits started with zero, we have to deal with it too.
                if (num[pos] == '0' && i != pos)
                {
                    break;
                }
                // this is to evaluate the no op step
                // no op just extends the current operand (curr) by current digit (num[pos]) 
                // for "123" Going from 12 to 123 is no op 
                // Something like this (12 * 10) + 3 
                curr = 10 * curr + (num[i] - '0');
                if (pos == 0)
                {
                    DFS(res, path.Append(curr), num, i + 1, target, curr, curr);
                    path.Length = len;
                }
                else
                {
                    DFS(res, path.Append("+").Append(curr), num, i + 1, target, eval + curr, curr);
                    DFS(res, path.Append("+").Append(curr), num, i + 1, target, eval + curr, curr);
                    path.Length = len;
                    DFS(res, path.Append("-").Append(curr), num, i + 1, target, eval - curr, -curr);
                    path.Length = len;
                    DFS(res, path.Append("*").Append(curr), num, i + 1, target, eval - multiplied + multiplied*curr, multiplied*curr);
                    path.Length = len;
                }
            }
        }
    }
}
