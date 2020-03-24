using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs.Heaps.Trees.Trees.Spanning_Tree
{
    public class UnionFind
    {
        // number of elements in this union find
        private int size;

        // used to track the sizes of each of the components
        private int[] sz;

        //id[i] points to the parent of i, if id[i] = i then i is a root node
        private int[] id;

        // tracks the number of components in unuion find
        private int numComponents;

        public UnionFind(int size)
        {
            if (size<=0)
            {
                throw new Exception();
            }

            this.size = numComponents = size;
            sz = new int[size];
            id = new int[size];

            for (int i = 0; i < size; i++)
            {
                id[i] = i; // link to itself (self root)
                sz[i] = 1; // each component is usually a size of 1
            }
        }

        /// <summary>
        /// Find which component p belongs to abd also do path compression along the way
        /// takes amortized time
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int Find(int p)
        {
            int root = p;
            while (root != id[root])
            {
                root = id[root]; // till we find a self loop
            }

            // compress the path leading back to the root
            // this is path compression
            // and it is what gives us amortized time complexity

            while (p != root)
            {
                int next = id[p];
                id[p] = root;
                p = next;
            }
            return root;
        }

        /// <summary>
        /// Returns whether or not the elements p and q are in the same same component set
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q); // does path compresion along the way
        }

        /// <summary>
        /// Returns the size of the components p belongs to
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int ComponentSize(int p)
        {
            return sz[Find(p)];
        }

        /// <summary>
        /// Returns the number of elements in UnionFind/DisjointSet
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            return size;
        }

        public int Components()
        {
            return numComponents;
        }

        /// <summary>
        /// Unify p and q
        /// it is integer since we are calling this post bijection
        /// say letter to number mapping
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void Unify(int p, int q)
        {
            int root1 = Find(p);
            int root2 = Find(q);

            // these elements are already in the same group
            if (root1 == root2) return;

            // merge two components together
            // merge smaller component into the larger component
            if (sz[root1] < sz[root2])
            {
                sz[root2] += sz[root1];
                id[root1] = root2;
            }
            else
            {
                sz[root1] += sz[root2];
                id[root2] = root1;
            }

            // since the roots found are different
            // we know that the number of component sets has decreased by 1
            numComponents--;
        }
    }
}
