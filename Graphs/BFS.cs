﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDS
{
    public class GraphBFS
    {
        public HashSet<T> BFS<T>(Graph<T> graph,T start)
        {
            var visited = new HashSet<T>();
            if (!graph.AdjacencyList.ContainsKey(start))
            {
                return visited;
            }

            Queue<T> queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                if (visited.Contains(vertex))
                {
                    continue;
                }
                visited.Add(vertex);

                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (!visited.Contains(neighbor))
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }
            return visited;
            {

            }
        }
    }
}
