using System.ComponentModel.Design;

namespace CyclesInGraph
{
    public class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static HashSet<string> visited;
        public static HashSet<string> cycles;
        public static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            visited = new HashSet<string>();
            cycles = new HashSet<string>();

            string token;

            while ((token = Console.ReadLine()) != "End") 
            {
                var edge = token.Split('-');
                var from = edge[0];
                var to = edge[1];

                if(!graph.ContainsKey(from))
                {
                    graph[from] = new List<string>();
                }

                if(!graph.ContainsKey(to))
                {
                    graph[to] = new List<string>();
                }

                graph[from].Add(to);
            }

            try
            {
                foreach (var node in graph.Keys)
                {
                    DFS(node);
                }

                Console.WriteLine("Acyclic: Yes");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Acyclic: No");
            }
        }

        private static void DFS(string node)
        {
            if (cycles.Contains(node))
            {
                throw new InvalidOperationException();
            }

            if (visited.Contains(node))
            {
                return;
            }
            visited.Add(node);
            cycles.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            cycles.Remove(node);
        }
    }
}