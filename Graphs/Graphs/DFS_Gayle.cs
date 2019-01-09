using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graphs
{
    public class DFS_Gayle
    {
        public  class Node
        {
            private int id;
            LinkedList<Node> adjacent = new LinkedList<Node>();
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

        private bool HasDFSPath(Node s, Node d, HashSet<int> visited)
        {
            throw new NotImplementedException();
        }

        public  class LinkedList<T>
        {
            T val;
            LinkedList<T> next;

            public LinkedList()
            {
            }

            public LinkedList(T p)
            {
                val = p;
            }
        }
    }
}
