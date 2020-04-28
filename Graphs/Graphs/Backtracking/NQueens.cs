using System;
using System.Collections.Generic;

namespace Backtracking
{
    public class NQueens
    {
        /// <summary>
        /// https://leetcode.com/problems/n-queens/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<IList<string>> SolveNQueens(int n)
        {
            // fill the board with '.'
            char[][] board = new char[n][];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i] = new char[n];
                    Array.Fill(board[i],'.');
                }
            }

            IList<IList<string>> res = new List<IList<string>>();
            Backtracking_NQueens(res,board, 0);
            return res;
        }

        private void Backtracking_NQueens(IList<IList<string>> res, char[][] board, int row)
        {
            if (row == board.Length)
            {
                res.Add(Construct(board));
                return;
            }
            else
            {
                // i is the column count
                for (int col = 0; col < board.Length; col++)
                {
                    // this is the choice that we work on
                    // now we validate where our choice results in a valid placement or not
                    // Choose 
                    // Explore
                    // Remove what you started with
                    if (IsValid(board,row,col))
                    {
                        // if it is a valid placement, 
                        // we set the position in square as 'Q'
                        // we continue exploring other rows for this column
                        board[row][col] = 'Q';
                        Backtracking_NQueens(res, board, row + 1);
                        board[row][col] = '.';
                    }
                    // now that we have explored all options associated with that particular placement
                    // we remove that placement from out list
                }
            }
        }

        private bool IsValid(char[][] board, int row, int col)
        {
            // check all columns
            for (int i = 0; i < row; i++)
            {
                if (board[i][col] == 'Q')
                {
                    return false;
                }
            }

            //check 45 degree
            for (int i = row - 1, j = col + 1; i >= 0 && j < board.Length; i--, j++)
            {
                if (board[i][j] == 'Q')
                {
                    return false;
                }
            }
            //check 135
            for (int i = row - 1, j = col - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i][j] == 'Q')
                {
                    return false;
                }
            }
                return true;
        }

        private IList<string> Construct(char[][] board)
        {
            List<string> path = new List<string>();
            for (int i = 0; i < board.Length; i++)
            {
                path.Add(new string(board[i]));
            }
            return path;
        }
    }
}
