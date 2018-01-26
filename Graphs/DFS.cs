using System.Collections.Generic;

namespace DataStructures.GraphDS
{
    public class GraphDFS
    {
    
    /// <summary>
    /// Depth First Search
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="graph"></param>
    /// <param name="start"></param>
    /// <returns></returns>
        public HashSet<T> DFS<T>(Graph<T> graph, T start)
        {
            var visited = new HashSet<T>();

            Stack<T> stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                {
                    continue;
                }

                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        stack.Push(neighbor);
                    }
                }
            }
            return visited;
        }
    }
}
