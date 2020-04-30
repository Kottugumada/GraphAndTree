using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs.Heaps.Trees.Graphs.Maze
{
    public class MinesweeperGame
    {
        /// <summary>
        /// https://leetcode.com/problems/minesweeper
        /// </summary>
        /// <param name="board"></param>
        /// <param name="click"></param>
        /// <returns></returns>
        public char[][] UpdateBoard(char[][] board, int[] click)
        {
            // if there is a mine fill 'X'
            if (board[click[0]][click[1]] == 'M')
            {
                // set 'X'
                board[click[0]][click[1]] = 'X';
                return board;
            }
            // else DFS per click
            DFS(board, click[0],click[1]);
            return board;
        }

        private void DFS(char[][] board, int x, int y)
        {
            // return if out of bounds or empty
            if (x<0 || x>= board.Length || y<0 || y>= board[0].Length || board[x][y] != 'E')
            {
                return;
            }

            int mine = 0;
            int startRow = x - 1 < 0 ? 0 : x - 1;
            int endRow = x + 1 >= board.Length ? board.Length - 1 : x + 1;
            int startCol = y - 1 < 0 ? 0 : y - 1;
            int endCol = y + 1 >= board[0].Length ? board[0].Length - 1 : y + 1;

            for (int i = startRow; i <= endRow; i++)
            {
                for (int j = startCol; j <= endCol; j++)
                {
                    if (board[i][j] == 'M' || board[i][j] == 'X')
                    {
                        mine++;
                    }
                }
            }
            if (mine != 0)
            {
                // appends the number of adjacent cells
                board[x][y] = (char)(mine + '0'); 
            }
            else
            {
                board[x][y] = 'B';
                DFS(board, x+1, y); // down
                DFS(board, x-1, y); // up
                DFS(board, x, y+1); // right
                DFS(board, x, y-1); // left
                DFS(board, x+1, y+1); // SE
                DFS(board, x+1, y-1); // SW
                DFS(board, x-1, y-1); // NW
                DFS(board, x-1, y+1); // NE
            }
        }
    }
}
