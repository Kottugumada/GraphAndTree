using System;
using System.Collections.Generic;

namespace Backtracking
{
    public class Subsets
    {
        /// <summary>
        /// https://leetcode.com/problems/subsets-ii/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();
            Array.Sort(nums);
            Backtrack_Dup(res, new List<int>(), nums, 0);
            return res;
        }
        private void Backtrack_Dup(List<IList<int>> res, List<int> subsets, int[] nums, int start)
        {
            res.Add(new List<int>(subsets));
            for (int i = start; i < nums.Length; i++)
            {
                if (i > start && nums[i] == nums[i - 1]) { continue; }

                subsets.Add(nums[i]);
                Backtrack_Dup(res, subsets, nums, i + 1);
                subsets.RemoveAt(subsets.Count - 1);
            }
        }

        /// <summary>
        /// Recursive https://leetcode.com/problems/subsets/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets_Recursive(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();
            // Array.Sort(nums);
            Backtrack_Recursive(res, new List<int>(), nums, 0);
            return res;
        }

        public void Backtrack_Recursive(List<IList<int>> res, List<int> subsets, int[] nums, int start)
        {
            // list saves subsets pointer's last address and the last address is null
            // so the output is will be null, if it is not new-ed.
            // it is necessary to create a new ArrayList to save subsets each time.
            res.Add(new List<int>(subsets));
            for (int i = start; i < nums.Length; ++i)
            {
                subsets.Add(nums[i]);
                Backtrack_Recursive(res, subsets, nums, i + 1);
                // To generate all possible permutations, we need to remove the least recently added element while we are going up the recursive call stack.
                // In the first iteration of the for loop we add all permutations, that start with nums[0].Then, before we can begin building all permutations starting with nums[1],
                // we need to clear the subsets list(which currently contains permutations from the first iteration of the for loop) 
                subsets.RemoveAt(subsets.Count - 1);
            }
        }
        /// <summary>
        /// Iterative https://leetcode.com/problems/subsets/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Subsets_Iterative(int[] nums)
        {
            if (nums == null)
                return new List<IList<int>>();

            var res = new List<IList<int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    var subsets = new List<int>();
                    subsets.Add(nums[i]);

                    res.Add(new List<int>());
                    res.Add(subsets);
                }
                else
                {
                    for (int j = 0; j < res.Count; j++)
                    {
                        var list = new List<int>(res[j]);
                        list.Add(nums[i]);
                        res.Add(list);
                    }
                }
            }
            return res;
        }
    }
}
