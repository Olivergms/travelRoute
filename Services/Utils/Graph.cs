using Domain.Entities;

namespace Services.Utils;

public class Graph
{
    // Lista de adjacência: para cada nó (cidade), quais arestas saem dele
    private readonly Dictionary<string, List<Edge>> _adj = new Dictionary<string, List<Edge>>();

    public Graph(IEnumerable<TravelRoute> travelRouteList)
    {
        foreach(var route in travelRouteList)
        {
            if (!_adj.ContainsKey(route.Origin))
                _adj[route.Origin] = new List<Edge>();
            _adj[route.Origin].Add(new Edge(route.Destination, route.Price));
        }
    }   


    public (List<string> path, int totalCost) Dijkstra(string start, string end)
    {
        // Distâncias iniciais: infinito, exceto a origem
        var dist = new Dictionary<string, int>();
        var prev = new Dictionary<string, string>();
        var pq = new SortedSet<(int dist, string node)>();

        // Inicializa nós no grafo
        foreach (var node in _adj.Keys)
        {
            dist[node] = int.MaxValue;
            prev[node] = null;
        }
        dist[start] = 0;
        pq.Add((0, start));

        while (pq.Count > 0)
        {
            var (d, u) = pq.Min;
            pq.Remove(pq.Min);

            if (u == end) break;

            if (!_adj.ContainsKey(u)) continue;

            foreach (var edge in _adj[u])
            {
                int alt = d + edge.Cost;
                if (alt < dist[edge.To])
                {
                    // Atualiza prioridade na fila
                    if (dist[edge.To] != int.MaxValue)
                        pq.Remove((dist[edge.To], edge.To));
                    dist[edge.To] = alt;
                    prev[edge.To] = u;
                    pq.Add((alt, edge.To));
                }
            }
        }

        // Reconstrói caminho
        var path = new List<string>();
        if (dist[end] == int.MaxValue)
            return (path, -1); // sem caminho

        string cur = end;
        while (cur != null)
        {
            path.Add(cur);
            cur = prev[cur];
        }
        path.Reverse();
        return (path, dist[end]);
    }

}


class Edge
{
    public string To { get; }
    public int Cost { get; }
    public Edge(string to, int cost)
    {
        To = to;
        Cost = cost;
    }
}

