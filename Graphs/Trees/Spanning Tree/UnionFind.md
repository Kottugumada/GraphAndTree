# Union Find
It has two components
Union and Find
Find tells you what group the element belongs to
Union merges the groups together

### Where is Union Find Used?

* Kruskal's Minimum Spanning Tree
* Grid percolation
* Network Connectivity
* Least common ancestor in tree
* Image Processing


# Complexity
* Construction : O(n)
* Union : amortized constant time O(n)
* Find : amortized constant time O(n)
* Get component size : amortized constant time O(n)
* Check if connected : amortized constant time O(n)
* count components  O(1) 


# Construction
* Bijection: [0,n)
* store mappings, may be in a hash table
* Unify edges


# Find Operation
To *Find* which component a particular element belongs to find the root of that component by following the parent nodes until a self loop is reached (a node whose parent is itself)

# Union Operation
To *Unify* two elements find which are the root nodes of each component and if the root nodes are different make one of the root nodes be the parent of the other

# Path Compression

