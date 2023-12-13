namespace AlgorithmLib;

public static class BellmanFordShortestPath
{
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex)
    {
        int vertices = g.Size(); // Get the number of vertices in the graph
            List<int> distance = new List<int>(new int[vertices]); // Initialize a list to hold distances
            List<int> pred = new List<int>(new int[vertices]); // Initialize a list to hold predecessors

            // Initialize distances to infinity and predecessors to invalid for all vertices
            for (int i = 0; i < vertices; i++)
            {
                distance[i] = Graph.INF;
                pred[i] = Graph.INF;
            }

            distance[startVertex] = 0; // Set the distance of the starting vertex to 0

            // Relax edges |V| - 1 times
            for (int i = 0; i < vertices - 1; i++)
            {
                // Loop through all vertices and their edges to relax each edge
                for (int u = 0; u < vertices; u++)
                {
                    foreach (var edge in g.Edges(u)) // Iterate through edges of vertex u
                    {
                        int v = edge.DestId; // Destination vertex of the edge
                        int weight = edge.Weight; // Weight of the edge

                        // If relaxation is possible, update the distance and predecessor
                        if (distance[u] != Graph.INF && distance[u] + weight < distance[v])
                        {
                            distance[v] = distance[u] + weight;
                            pred[v] = u;
                        }
                    }
                }
            }

            // Check for negative cycles by iterating through all edges again
            for (int u = 0; u < vertices; u++)
            {
                foreach (var edge in g.Edges(u))
                {
                    int v = edge.DestId; // Destination vertex of the edge
                    int weight = edge.Weight; // Weight of the edge

                    // If there's a negative-weight cycle, return empty lists
                    if (distance[u] != Graph.INF && distance[u] + weight < distance[v])
                    {
                        return (new List<int>(), new List<int>());
                    }
                }
            }

            // Return the resulting shortest distances and predecessors
            return (distance, pred);

    } 
}