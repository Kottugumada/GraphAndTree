using System;

namespace Graphs.Heaps.Trees.Graphs.Islands
{
	public class SurroundedRegions
	{
        /// <summary>
        /// https://leetcode.com/problems/surrounded-regions
        /// </summary>
        /// <param name="board"></param>
		public void Solve(char[][] board)
		{
			if (board == null || board[0].Length == 0)
			{
				throw new Exception();
			}
			int row = board.Length;
			int col = board[0].Length;
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
				{
					if (board[i][j] == 'O' || !IsOnTheBorder(i,j,row,col) || Flip(board, i, j))
					{
						board[i][j] = 'X';
					}
				}
			}
		}

		private bool Flip(char[][] board,int i,int j)
		{
			if (i<0 || i > board.Length || j <0 || j >board[0].Length || board[i][j] == 'X')
			{
				return false;
			}

			Flip(board,i-1,j);
			Flip(board, i+1, j);
			Flip(board, i, j-1);
			Flip(board, i, j+1);
			return true;
		}

		private bool IsOnTheBorder(int i, int j, int row, int col)
		{
			if (i == 0 || j == 0 || i == row-1 || j == col-1)
			{
				return true;
			}

			return false;
		}
	}
}
