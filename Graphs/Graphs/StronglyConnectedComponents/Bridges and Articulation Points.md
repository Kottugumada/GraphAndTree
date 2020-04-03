# Pseudocode
 reference https://www.youtube.com/watch?v=aZXi1unBdJA&t=76s

id = 0;
g = adjacenyList of an undirected graph
n = size of the graph

# in the these arrays index i represents node i
* ids =		[0,		0...		0,	0]        # length n   
* lowLink = [0,		0...		0,	0]        # length n   
* visited = [false, false... false, false]    # length n    

function findBridges(){
    bridges = []
    # finds all bridges in the graph across varios connected components
    for(int i =0;i<n; i++){
        if(!visited[i]){
            dfs(i, -1, bridges)
        }
    }
    return bridges
}

* perform depth first search to find the bridges
* curr is the current node
* parent is the previous node
* The bridges list is always of even length 
* and indexes (2*i, 2*i+1) form a bridges

# dfs(curr, parent, bridges){
    visted[curr] = true // mark the current node
    id = id + 1
    lowLink[curr] = ids[curr] = id

  for each edge from node 'curr' to node 'dest'
    for(dest : g[curr]){
        if(dest == parent){
            continue
        }
        if(!visited[dest]){
            dfs(dest, curr, bridges)
            lowLink[curr] = min(lowLink[curr], lowLink[dest])

            if(ids[curr] < lowLink[dest]){
                bridges.add(curr)
                bridges.add(dest)
            }
            else{
                lowLink[curr] = min(lowLink[curr], ids[dest])
            }
        }
    }
}
