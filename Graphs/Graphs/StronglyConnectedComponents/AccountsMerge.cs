using System;
using System.Collections.Generic;

namespace Graphs.Heaps.Trees.Graphs.StronglyConnectedComponents
{
    public class Solution
    {
        /// <summary>
        /// https://leetcode.com/problems/accounts-merge/
        /// </summary>
        /// <param name="accounts"></param>
        /// <returns></returns>
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            // email node and neighbor nodes mapping
            Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();
            // email and user name mapping
            Dictionary<string, string> emailNameMap = new Dictionary<string, string>();

            // construct graph
            foreach (var account in accounts)
            {
                // first value is user name
                string userName = account[0];
                for (int i = 1; i < account.Count; i++)
                {
                    // other following values on the list are email addresses
                    if (!graph.ContainsKey(account[i]))
                    {
                        graph[account[i]] = new HashSet<string>();
                    }

                    // if the email id exists add it to the hashset corresponding to the email id
                    emailNameMap[account[i]] = userName; // assign username to the email

                    if (i == 1)
                    {
                        continue;
                    }

                    // add adjacent email ids as edges
                    graph[account[i]].Add(account[i - 1]);
                    graph[account[i - 1]].Add(account[i]);
                }
            }

            HashSet<string> visited = new HashSet<string>();
            IList<IList<string>> res = new List<IList<string>>();

            // DFS
            foreach (var email in emailNameMap.Keys)
            {
                List<string> listOfEmailAddresses = new List<string>();
                if (visited.Add(email))
                {
                    DFS(graph, email, visited, listOfEmailAddresses);

                    listOfEmailAddresses.Add(emailNameMap[email]);
                    listOfEmailAddresses.Sort(StringComparer.Ordinal); // case insensitive compare
                    res.Add(listOfEmailAddresses);
                }
            }
            return res;
        }

        private void DFS(Dictionary<string, HashSet<string>> graph, string email, HashSet<string> visited, List<string> listOfEmailAddresses)
        {
            listOfEmailAddresses.Add(email);
            foreach (var item in graph[email])
            {
                if (visited.Add(item))
                {
                    DFS(graph, item, visited, listOfEmailAddresses);
                }
            }
        }
    }
}

