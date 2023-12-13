# Algorithm Description Document

Author: Nathan Shumway

Date: 12/12/23

## 1. Name
Dijkstra Shortest Path

## 2. Abstract
The code implements Dijkstra's algorithm to find the shortest path from a given starting vertex to all other vertices in a directed graph. It uses a priority queue to efficiently manage and update the distances to vertices.

## 3. Methodology
The code follows the Dijkstra's algorithm approach:

Initialization of distance and predecessor lists.
Setting the distance of the start vertex to 0.
Creating a priority queue and inserting all vertices with their respective distances.
Looping until the priority queue is empty:
a. Extracting the vertex with the minimum distance from the priority queue.
b. Relaxing neighboring vertices, updating distances and predecessors if a shorter path is found.
Returning lists of distances and predecessors for each vertex.

## 4. Pseudocode

```
SHORTEST-PATH(graph, start_vertex)
    Initialize distance and predecessor lists for all vertices.
    Set distance of start_vertex to 0.
    Create a priority queue and insert all vertices with their respective distances.
    While priority queue is not empty:
        Extract vertex with minimum distance from the priority queue.
        For each neighboring vertex v of the extracted vertex:
            Update distance[v] if a shorter path is found.
            Update predecessor[v] accordingly.
    Return lists of distances and predecessors for each vertex.

```

## 5. Inputs & Outputs

Inputs:
graph: Directed graph.
start_vertex: The vertex from which the shortest paths are calculated.
Outputs:
distance: List of shortest distances from the start_vertex to all other vertices.
pred: List of predecessors for each vertex in the shortest path from start_vertex.

## 6. Analysis Results

* Worst Case: $O(n*Log n)$

* Best Case: $\Omega(n^2)$

