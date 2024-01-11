using System.Numerics;

namespace BreakCycles
{
    public class Edge
    {
        public string First { get; set; }

        public string Second { get; set; }

        public override string ToString()
        {
            return $"{this.First} - {this.Second}";
        }
    }

    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;

        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();

            for (int i = 0; i < n; i++)
            {
                var token = Console.ReadLine().Split(" -> ");
                var node = token[0];
                var children = token[1].Split().ToList();

                graph[node] = children;

                foreach (var child in children)
                {
                    edges.Add(new Edge {  First = node, Second = child });
                }
            }

            edges = edges
                .OrderBy(e => e.First)
                .ThenBy(e => e.Second)
                .ToList();
            var reversedEdges = new HashSet<string>();
            var removeEdges = new List<Edge>();

            foreach (var edge in edges)
            {
                if(reversedEdges.Contains(edge.ToString()))
                {
                    continue;
                }
                graph[edge.First].Remove(edge.Second);
                graph[edge.Second].Remove(edge.First);

                if(BFS(edge.First, edge.Second))
                {
                    removeEdges.Add(edge);
                    reversedEdges.Add($"{edge.Second} - {edge.First}");
                }
                else
                {
                    graph[edge.First].Add(edge.Second);
                    graph[edge.Second].Add(edge.First);
                }
            }

            Console.WriteLine(removeEdges.Count);
            Console.WriteLine(string.Join(Environment.NewLine, removeEdges));
        }

        private static bool BFS(string start, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);
            var visited = new HashSet<string>();

            while(queue.Count > 0)
            {
                var node = queue.Dequeue();

                if(node == destination)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }
                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return false;
        }
    }
}