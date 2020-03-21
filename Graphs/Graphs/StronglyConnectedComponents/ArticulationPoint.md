# Pseudocode Articulation Point
 # reference https://www.youtube.com/watch?v=aZXi1unBdJA&t=76s

id = 0;
g = adjacenyList of an undirected graph
n = size of the graph
outEdgeCount = 0 // cannot be an articulation point if it does not have more than one outgoing edges

# in the these arrays index i represents node i
ids = [0,0...0,0]                           # length n
lowLink = [0,0...0,0]                       # length n
visited = [false, false... false, false]    # length n
isArt = [false, false... false, false]		# length n
function findArtPoints(){
    bridges = []
    # finds all bridges in the graph across various connected components
    for(int i =0;i<n; i++){
        if(!visited[i]){
		outEdgeCount = 0 # reset edge count
            dfs(i, i, -1)
			isArt[i] = (outEdgeCount > 1)
        }
    }
    return isArt
}

# perform depth first search to find the bridges
# curr is the current node
# parent is the previous node
# The bridges list is always of even length 
# and indexes (2*i, 2*i+1) form a bridges

dfs(root, curr, parent){
	if(parent == root){
	outEdgeCount++;
	}
    visted[curr] = true // mark the current node
    id = id + 1
    lowLink[curr] = ids[curr] = id

    # for each edge from node 'curr' to node 'dest'
    for(dest : g[curr]){
        if(dest == parent){
            continue
        }
        if(!visited[dest]){
            dfs(dest, curr, bridges)
            lowLink[curr] = min(lowLink[curr], lowLink[dest])

            if(ids[curr] < lowLink[dest]){
                isArt[curr] = true
            }
			if(ids[curr] == lowLink[dest]){
				isArt[current] = true
			}
            else{
                lowLink[curr] = min(lowLink[curr], ids[dest])
            }
        }
    }
}
