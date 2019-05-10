using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs
{
    public class DFS_Gayle
    {
        public class Node
        {
            public int id;
            public LinkedList<Node> adjacent = new LinkedList<Node>();
            public Node(int id)
            {
                this.id = id;
            }
        }
        private Node GetNode(int id)
        {
            return new Node(id);
        }
        public bool HasDFSPath(int source, int destination)
        {
            Node s = GetNode(source);
            Node d = GetNode(destination);
            HashSet<int> visited = new HashSet<int>();
            return HasDFSPath(s, d, visited);
        }

        private bool HasDFSPath(Node source, Node destination, HashSet<int> visited)
        {
            if (visited.Contains(source.id)) return false;
            visited.Add(source.id);

            if (source == destination)
            {
                return true;
            }
            foreach (Node child in source.adjacent)
            {
                if (HasDFSPath(child, destination, visited))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
    
