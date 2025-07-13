using Domain.Entities;

namespace Services.Utils;

class Dijkstra
{
    public static Itinerary FindShortestRoute(List<TravelRoute> rotas, string origin, string destination)
    {
        var graph = new Dictionary<string, List<(string destino, int peso)>>();

        foreach (var rota in rotas)
        {
            if (!graph.ContainsKey(rota.Origin))
                graph[rota.Origin] = new List<(string, int)>();

            graph[rota.Origin].Add((rota.Destination, rota.Price));
        }

        var distances = new Dictionary<string, int>();
        var previous = new Dictionary<string, string?>();
        var queue = new PriorityQueue<string, int>();
        var visiteds = new HashSet<string>();

        foreach (var no in graph.Keys)
        {
            distances[no] = int.MaxValue;
            previous[no] = null;
        }

        distances[origin] = 0;
        queue.Enqueue(origin, 0);

        while (queue.Count > 0)
        {
            var atual = queue.Dequeue();

            if (visiteds.Contains(atual))
                continue;

            visiteds.Add(atual);

            if (!graph.ContainsKey(atual))
                continue;

            foreach (var vizinho in graph[atual])
            {
                var novaDist = distances[atual] + vizinho.peso;

                if (!distances.ContainsKey(vizinho.destino) || novaDist < distances[vizinho.destino])
                {
                    distances[vizinho.destino] = novaDist;
                    previous[vizinho.destino] = atual;
                    queue.Enqueue(vizinho.destino, novaDist);
                }
            }
        }

        // Reconstrução do caminho
        var path = new List<string>();
        string? currentNo = destination;

        if (!previous.ContainsKey(destination) || distances[destination] == int.MaxValue)
            return null; // Sem caminho possível

        while (currentNo != null)
        {
            path.Insert(0, currentNo);
            currentNo = previous[currentNo];
        }

        return new Itinerary
        {
            Path = path,
            TotalCost = distances[destination]
        };
    }
}

class Itinerary
{
    public List<string> Path { get; set; } = new List<string>();
    public int TotalCost { get; set; }
}
