using System.Collections;

namespace AlgorithmLib;

public static class DAGTopologicalSort
{
    public static List<int> Sort(Graph g)
    {
        int vertices = g.Size(); // Get the number of vertices in the graph
        List<int> result = new List<int>(); // List to hold the topologically sorted order

        // Create an adjacency list to represent the graph connections
        List<List<int>> adjacencyList = new List<List<int>>();
        for (int i = 0; i < vertices; i++)
        {
            adjacencyList.Add(new List<int>());
        }

        // Construct the adjacency list by iterating through each vertex and its edges
        for (int u = 0; u < vertices; u++)
        {
            foreach (var edge in g.Edges(u))
            {
                int v = edge.DestId; // Destination ID of the edge
                adjacencyList[u].Add(v); // Add the destination vertex to the adjacency list for vertex 'u'
            }
        }

        int[] inDegree = new int[vertices]; // Array to hold the in-degree of each vertex
        // Calculate the in-degree for each vertex by traversing the adjacency list
        foreach (var neighbors in adjacencyList)
        {
            foreach (var neighbor in neighbors)
            {
                inDegree[neighbor]++; // Increment the in-degree of the neighbor vertex
            }
        }

        Queue<int> queue = new Queue<int>(); // Queue for BFS traversal
        // Enqueue vertices with in-degree zero (no incoming edges)
        for (int i = 0; i < vertices; ++i)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        // Perform topological sorting using BFS
        while (queue.Count != 0)
        {
            int current = queue.Dequeue(); // Dequeue a vertex with in-degree zero
            result.Add(current); // Add the vertex to the sorted order

            // Update in-degree of neighbors and enqueue if their in-degree becomes zero
            foreach (var neighbor in adjacencyList[current])
            {
                if (--inDegree[neighbor] == 0)
                {
                    queue.Enqueue(neighbor); // Enqueue vertex with in-degree zero
                }
            }
        }

        // Check if the graph has a cycle (if result count doesn't match vertices count)
        return result.Count == vertices ? result : new List<int>();
    }
}