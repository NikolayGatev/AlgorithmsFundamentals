using System.Security.Cryptography;

namespace DistanceBetweenNodes
{
    public class Program
    {
        private static Dictionary<int, List<int>> graphs;
        public static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var pairs = int.Parse(Console.ReadLine());

            graphs = new Dictionary<int, List<int>>();

            for (int i = 0; i < nodes; i++)
            {
                var nodeAndChildren = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

                var node = int.Parse(nodeAndChildren[0]);

                if (nodeAndChildren.Length == 1)
                {
                    graphs[node] = new List<int>();
                }
                else
                {
                    var children = nodeAndChildren[1]
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
                    graphs[node] = children;
                }
            }
            
            for (int i = 0;i < pairs; i++)
            {
                var pair = Console.ReadLine()
                    .Split("-")
                    .Select(int.Parse)
                    .ToArray();

                var start = pair[0];
                var destination = pair[1];

                var steps = BFS(start, destination);

                Console.WriteLine(steps);
            }


        }

        private static int BFS(int start, int destination)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);

            var visited = new HashSet<int>() { start };
            var parent = new Dictionary<int, int> { { start, -1 } };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if(node == destination)
                {
                    return GetSteps(parent, destination);
                }

                foreach ( var child in graphs[node])
                {
                    if(visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);

                    queue.Enqueue(child);

                    parent[child] = node;
                }
            }

            return -1;
        }

        private static int GetSteps(Dictionary<int, int> parent, int destination)
        {
            var steps = 0;
            var node = destination;

            while(node != -1)
            {
                node = parent[node];
                steps++;
            }
            return steps - 1;
        }
    }
}