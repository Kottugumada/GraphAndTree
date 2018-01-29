# Graph and Tree
DFS
To make sure the depth-first search algorithm doesn't re-visit vertices, the visited HashSet keeps track of vertices already visited. A Stack, called stack, keeps track of vertices found but not yet visited. Initially stack contains the starting vertex. The next vertex is popped from stack. If it has already been visited, it is discarded and the next vertex is popped from stack. If it has not been visited, it is added to the set of visited vertices and its unvisited neighbors are added to stack. This continues until there are no more vertices in stack, and the set of vertices visited is returned. The set of vertices returned is all the vertices that can be reached from the starting vertex

