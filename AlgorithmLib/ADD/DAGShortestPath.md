# Algorithm Description Document

Author: Nathan Shumway  

Date: 12/11/23

## 1. Name
Directed Acyclic Graph (DAG) Shortest Path

## 2. Abstract
The ShortestPath method in the Directed Acyclic Graph (DAG) determines the shortest paths from a starting vertex to all other vertices using a topological sort and dynamic programming approach.
## 3. Methodology
The method utilizes a topological sort to establish the vertex ordering and iterates through the vertices in topological order. It updates the distances to the vertices based on relaxation, considering the weights of the edges.
## 4. Pseudocode

```
SHORTEST-PATH(graph, start_vertex)
    vertices = Size of graph
    Initialize distance and predecessors to INF for all vertices except start_vertex (set distance[start_vertex] = 0)
    topologicalOrder = TopologicalSort(graph)
    for each vertex u in topologicalOrder
        for each outgoing edge from u to v
            if distance[u] != INF and distance[u] + weight < distance[v]
                distance[v] = distance[u] + weight
                pred[v] = u
    return (distance, pred)
```

## 5. Inputs & Outputs

Inputs:
graph: Directed Acyclic Graph
start_vertex: Starting vertex for finding shortest paths
Outputs:
List of distances from the start vertex to all other vertices
List of predecessors for each vertex in the shortest paths
## 6. Analysis Results

* Worst Case: $O(N)$

* Best Case: $\Omega(N)$

