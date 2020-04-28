using System;
using System.Collections.Generic;

namespace Backtracking
{
    public class NQueens_Attempt2
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            var visited = new int[n];
            Array.Fill(visited, -n);
            var res = new List<IList<string>>();
            Solve(res, visited, 0, n);

            return res;
        }

        void Solve(IList<IList<string>> res, int[] visited, int row, int n)
        {
            if (row == n)
            {
                // Add to the final result
                res.Add(BuildResult(visited));
                return;
            }

            for (var col = 0; col < n; col++)
            {
                if (IsValid(visited, col, row, n))
                {
                    visited[row] = col;
                    Solve(res, visited, row + 1, n);
                    //reset
                    visited[row] = -n;
                }
            }
        }

        IList<string> BuildResult(int[] visited)
        {
            var res = new List<string>();
            for (var i = 0; i < visited.Length; i++)
            {
                var chars = new char[visited.Length];
                Array.Fill(chars, '.');
                chars[visited[i]] = 'Q';
                res.Add(new string(chars));
            }
            return res;
        }

        bool IsValid(int[] visited, int col, int row, int n)
        {
            if (row == 0)
            {
                return true;
            }

            // check the left/right diagno not found and the same col not found
            /*if (Math.Abs(visited[row -1] - col) == 1){
                return false;
            }*/

            for (var i = 0; i < row; i++)
            {
                if (visited[i] == col || Math.Abs(visited[i] - col) == row - i)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
