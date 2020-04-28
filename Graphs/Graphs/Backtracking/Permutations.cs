using System;
using System.Collections.Generic;

namespace Backtracking
{
    public class Permutations
    {
        /// <summary>
        /// https://leetcode.com/problems/permutations/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Backtracking_Permute(res, new List<int>(), nums, 0);
            return res;
        }

        private void Backtracking_Permute(IList<IList<int>> res, List<int> permutations, int[] nums, int start)
        {
            if (permutations.Count == nums.Length)
            {
                res.Add(new List<int>(permutations));
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (permutations.Contains(nums[i]))
                    {
                        continue;
                    }
                    permutations.Add(nums[i]);
                    Backtracking_Permute(res, permutations, nums, i + 1);
                    permutations.Remove(permutations.Count - 1);
                }
            }
        }
        /// <summary>
        /// https://leetcode.com/problems/permutations-ii/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            Backtracking(res, new List<int>(), nums, new bool[nums.Length]);
            return res;
        }

        private void Backtracking(IList<IList<int>> res, List<int> permutations, int[] nums, bool[] used)
        {
            if (nums.Length == permutations.Count)
            {
                res.Add(new List<int>(permutations));
            }
            else
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (used[i] || i>0 && nums[i] == nums[i-1] && !used[i-1])
                    {
                        continue;
                    }
                    used[i] = true;
                    permutations.Add(nums[i]);
                    Backtracking(res, permutations, nums, used);
                    used[i] = false;
                    permutations.RemoveAt(permutations.Count - 1);
                }
            }
        }
    }
}
