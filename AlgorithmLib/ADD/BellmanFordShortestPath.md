# Algorithm Description Document

Author: Nathan Shumway

Date: 12/12/23

## 1. Name
Bellman Ford Shortest Path

## 2. Abstract
The Bellman-Ford algorithm is designed to find the shortest path from a single source vertex to all other vertices in a weighted graph. It handles negative edge weights and detects negative weight cycles in the graph.
## 3. Methodology
The Bellman-Ford algorithm initializes distance and predecessor arrays for each vertex in the graph. It relaxes edges iteratively |V| - 1 times to find the shortest paths. Then, it checks for negative cycles by iterating through all edges again.

## 4. Pseudocode
    
```

SHORTEST-PATH(graph, start_vertex)
    Initialize distance and predecessor arrays for each vertex
    Set the distance of the start_vertex to 0
    Relax edges |V| - 1 times
    Check for negative cycles
    Return resulting shortest distances and predecessors
```

## 5. Inputs & Outputs

Inputs:
graph: A weighted graph represented by an adjacency list.
start_vertex: The vertex from which to find the shortest paths.
Outputs:
(List<int>, List<int>): Two lists representing the resulting shortest distances and predecessors for each vertex from the start_vertex.

## 6. Analysis Results

* Worst Case: $O(n^2)$

* Best Case: $\Omega(N)$
