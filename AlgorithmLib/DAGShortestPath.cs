using System.Runtime.CompilerServices;

namespace AlgorithmLib;


public static class DAGShortestPath
{
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex)
    {
        int vertices = g.Size(); // Get the number of vertices in the graph
        List<int> distance = new List<int>(); // List to hold distances from the start vertex
        List<int> pred = new List<int>(); // List to hold predecessors in the shortest path

        // Initialize distance and predecessors with INF values
        for (int i = 0; i < vertices; i++)
        {
            distance.Add(Graph.INF); // Initially, set all distances to infinity
            pred.Add(Graph.INF); // Initially, set all predecessors to infinity
        }

        distance[startVertex] = 0; // Set the distance of the start vertex to 0

        // Get the topological order using the previously defined topological sort function
        List<int> topologicalOrder = DAGTopologicalSort.Sort(g);

        // Traverse the vertices in topological order to update distances and predecessors
        foreach (int u in topologicalOrder)
        {
            // Iterate through the outgoing edges of the current vertex 'u'
            foreach (var edge in g.Edges(u))
            {
                int v = edge.DestId; // Destination vertex of the edge
                int weight = edge.Weight; // Weight of the edge from 'u' to 'v'

                // Relaxation step: Update distance and predecessor if a shorter path is found
                if (distance[u] != Graph.INF && distance[u] + weight < distance[v])
                {
                    distance[v] = distance[u] + weight; // Update the distance to vertex 'v'
                    pred[v] = u; // Set 'u' as the predecessor of 'v' in the shortest path
                }
            }
        }

        return (distance, pred); // Return the final distance and predecessor lists
    } 
    
}