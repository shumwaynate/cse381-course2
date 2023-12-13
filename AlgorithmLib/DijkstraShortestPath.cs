namespace AlgorithmLib;

public static class DijkstraShortestPath
{

    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex)
    {
        // Initializing lists to hold distances and predecessors for each vertex
        int vertices = g.Size();
        List<int> distance = new List<int>();
        List<int> pred = new List<int>();

        // Initializing distance with infinity and predecessors with infinity (initially unknown)
        for (int i = 0; i < vertices; i++)
        {
            distance.Add(Graph.INF);
            pred.Add(Graph.INF);
        }

        // Distance to the starting vertex is set to 0
        distance[startVertex] = 0;

        // Creating a priority queue to store vertices based on their distances
        PriorityQueue<int> pq = new PriorityQueue<int>();

        // Inserting all vertices into the priority queue with their respective distances
        for (int i = 0; i < vertices; i++)
        {
            pq.Insert(i, distance[i]);
        }

        // Dijkstra's algorithm loop
        while (pq.Size() > 0)
        {
            // Extracting the vertex with the minimum distance
            int u = pq.Dequeue();

            // Iterating through all neighboring vertices of u
            foreach (var edge in g.Edges(u))
            {
                int v = edge.DestId; // Destination vertex
                int alt = distance[u] + edge.Weight; // Alternative distance through u

                // Relaxation: If the alternative distance is shorter, update distance and predecessor
                if (alt < distance[v])
                {
                    distance[v] = alt;
                    pred[v] = u;
                    pq.DecreaseKey(v, alt); // Decrease the priority of v in the queue to the new distance
                }
            }
        }

        // Return the lists of distances and predecessors for each vertex
        return (distance, pred);
    } 
}