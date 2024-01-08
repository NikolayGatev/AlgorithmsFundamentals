using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace DFSBFS
{
    public class Program
    {
        private static Dictionary<int, List<int>> graph;
        private static HashSet<int> visited;

        public static void Main(string[] args)
        {
            graph = new Dictionary<int, List<int>>()
            {
                {1, new List<int> {19, 21, 14} },
                {19, new List<int> {7, 12, 31, 21} },
                {21, new List<int> {14} },
                {14, new List<int> {23, 6}},
                {23, new List<int> {21} },
                {31, new List<int> {21}},
                {7, new List<int> {1}},
                {12, new List<int> ()},
                {6, new List<int> ()},
            };

            visited = new HashSet<int>();

            foreach (int node in graph.Keys)
            {
                BFS(node);
            }

            Console.WriteLine();

            visited.Clear();
            foreach (var node in graph.Keys)
            {
                DFS(node);
            }
        }

        private static void BFS(int startNode)
        {
            if(visited.Contains(startNode))
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited.Add(startNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                Console.WriteLine(node);

                foreach ( var child in graph[node])
                {
                    if(!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }


        }

        private static void DFS(int node)
        {
            if(visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            Console.WriteLine(node);
        }
    }
}