using System;
using System.Collections.Generic;

namespace Dijkstras
{
    class Graph
    {
        Dictionary<char, Dictionary<char, int>> vertices = new Dictionary<char, Dictionary<char, int>>();

        public void add_vertex(char name, Dictionary<char, int> edges)
        {
            vertices[name] = edges;
        }

        public List<char> dijkstra(char start, char finish)
        {
            var previous = new Dictionary<char, char>();
            var distances = new Dictionary<char, int>();
            var nodes = new List<char>();

            List<char> path = null;

            foreach (var vertex in vertices)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }

                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);

                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == finish)
                {
                    path = new List<char>();
                    while (previous.ContainsKey(smallest))
                    {
                        path.Add(smallest);
                        smallest = previous[smallest];
                    }

                    break;
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in vertices[smallest])
                {
                    var alt = distances[smallest] + neighbor.Value;
                    if (alt < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = alt;
                        previous[neighbor.Key] = smallest;
                    }
                }
            }

            return path;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Graph g = new Graph();
            g.add_vertex('A', new Dictionary<char, int>() { { 'B', 140 }, { 'C', 310 } });
            g.add_vertex('B', new Dictionary<char, int>() { { 'E', 200 }, { 'D', 150 } });
            g.add_vertex('C', new Dictionary<char, int>() { { 'E', 480 }, { 'I', 200 } });
            g.add_vertex('D', new Dictionary<char, int>() { { 'G', 180 } });
            g.add_vertex('E', new Dictionary<char, int>() { { 'B', 300 }, { 'F', 240 } });
            g.add_vertex('F', new Dictionary<char, int>() {  { 'H', 100 } });
            g.add_vertex('G', new Dictionary<char, int>() { { 'J', 300 }, { 'H', 250 } });
            g.add_vertex('H', new Dictionary<char, int>() { { 'K', 200 }, { 'I', 300 } });
            g.add_vertex('I', new Dictionary<char, int>() {{'K', 150}});
            g.add_vertex('J',new Dictionary<char, int>());
            g.add_vertex('K',new Dictionary<char, int>());

            g.dijkstra('A', 'K').ForEach(x => Console.WriteLine(x));
            Console.ReadKey();
        }
    }
}