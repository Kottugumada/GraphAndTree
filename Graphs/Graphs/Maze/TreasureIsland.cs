using System;

namespace Graphs.Heaps.Trees.Graphs.Islands
{
    public class TreasureIsland
    {
        private int distance = int.MinValue;
        /// <summary>
        /// https://leetcode.com/discuss/interview-question/347457
        /// </summary>
        /// <param name="island"></param>
        /// <returns></returns>
        public int FindShortestPath(char[][] island)
        {
            if (island == null)
            {
                return -1;
            }
            bool[][] visited = new bool[island.Length][];
            DFS(island,0,0,visited,0);
            return distance;
        }

        private void DFS(char[][] grid, int i, int j, bool[][] visited, int levelDistance)
        {
            if (i<0 || i>=grid.Length || j <0 || j>= grid[0].Length || grid[i][j] == 'D' || visited[i][j] )
            {
                return;
            }
            if (grid[i][j] == 'X')
            {
                distance = Math.Min(distance, levelDistance);
                return;
            }
            visited[i][j] = true;
            DFS(grid, i, j - 1, visited, levelDistance + 1); // back
            DFS(grid, i, j + 1, visited, levelDistance+1); // forward
            DFS(grid, i-1, j, visited, levelDistance+1); // up
            DFS(grid, i+1, j, visited, levelDistance); // down

            visited[i][j] = false;
        }
    }
}
