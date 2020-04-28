using System.Collections.Generic;

namespace Backtracking
{
    public class LetterCombinationsPhoneNumbers
    {
        /// <summary>
        /// https://leetcode.com/problems/letter-combinations-of-a-phone-number/
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public IList<string> LetterCombinations(string digits)
        {
            IList<string> res = new List<string>();
            BackTracking_LetterCombinations(res, digits, "");
            return res;
        }

        private void BackTracking_LetterCombinations(IList<string> res, string digits, string combination)
        {
            if ( digits.Length == 0) {
                res.Add(new string(combination));
            }
            else{
                string digit = combination.Substring(0,1);
                string letters = DigitToLetters(digit);
                for (int i = 0; i < letters.Length; i++)
                {
                    string letter = letters.Substring(i,i+1);
                    BackTracking_LetterCombinations(res, digits.Substring(1), combination+letter);
                }
            }
        }
        private string DigitToLetters(string digit)
        {
            Dictionary<string, string> digitMap = new Dictionary<string, string>();
            digitMap.Add("2","abc");
            digitMap.Add("3", "def");
            digitMap.Add("4", "ghi");
            digitMap.Add("5", "jkl");
            digitMap.Add("6", "mno");
            digitMap.Add("7", "pqrs");
            digitMap.Add("8", "uvw");
            digitMap.Add("9", "xyz");
            if (digitMap.ContainsKey(digit))
            {
                return digitMap[digit];
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
