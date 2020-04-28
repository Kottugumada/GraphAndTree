using System;
using System.Collections.Generic;

namespace Backtracking
{
    public class CombinationSumProblems
    {
        /// <summary>
        /// https://leetcode.com/problems/combination-sum/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();
            // Array.Sort(candidates);
            Backtracking_CombinationSum(res, new List<int>(), candidates, target, 0);
            return res;
        }

        private void Backtracking_CombinationSum(IList<IList<int>> res, List<int> combinations, int[] candidates, int remainingTarget, int start)
        {
            if (remainingTarget < 0) return;
            else if (remainingTarget == 0)
            {
                res.Add(new List<int>(combinations));
            }
            else
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    combinations.Add(candidates[i]);
                    Backtracking_CombinationSum(res, combinations, candidates, remainingTarget - candidates[i], i); // not i+1 since we can have duplicates in sum
                    combinations.RemoveAt(combinations.Count - 1);
                }
            }
        }

        /// <summary>
        /// https://leetcode.com/problems/combination-sum-ii/
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Array.Sort(candidates);
            Backtracking_CombinationSum_NoDups(res, new List<int>(), candidates, target, 0);
            return res;
        }

        private void Backtracking_CombinationSum_NoDups(IList<IList<int>> res, List<int> combinations, int[] candidates, int remainingTarget, int start)
        {
            if (remainingTarget < 0)
                return;
            else if (remainingTarget == 0)
                res.Add(new List<int>(combinations));
            else
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    if (i> start && candidates[i] == candidates[i-1])
                    {
                        continue; // skip if there are duplicate values
                    }
                    combinations.Add(candidates[i]);
                    Backtracking_CombinationSum_NoDups(res, combinations, candidates, remainingTarget-candidates[i], i+1);
                    combinations.RemoveAt(combinations.Count - 1);
                }
            }
        }
    }
}
