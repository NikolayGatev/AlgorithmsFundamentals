using System.ComponentModel.Design;
using System.Security.Cryptography;

namespace AreasInMatrix
{
    public class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        private static Dictionary<char, int> areas;

        public static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            graph = new char[row, col];
            areas = new Dictionary<char, int>();

            for (int i = 0; i < row; i++)
            {
                var rowElements = Console.ReadLine();

                for (int j = 0; j < col; j++)
                {
                    graph[i, j] = rowElements[j];
                }
            }

            visited = new bool[row, col];

            for(int i = 0;i < row; i++)
            {
                for (int j = 0;j < col; j++)
                {
                    if (visited[i, j])
                    {
                        continue;
                    }
                    var nodeValue = graph[i, j];
                    DFS(i, j, nodeValue);

                    if(areas.ContainsKey(nodeValue))
                    {
                        areas[nodeValue]++;
                    }
                    else
                    {
                        areas[nodeValue] = 1;
                    }
                }
            }

            foreach (var area in areas)
            {
                Console.WriteLine($"Letter '{area.Key}' -> '{area.Value}'");
            }

        }

        private static void DFS(int row, int col, char nodeValue)
        {
            if(row < 0 || row >= graph.GetLength(0) ||
                col < 0 || col >= graph.GetLength(1))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            if (graph[row, col] != nodeValue)
            {
                return;
            }

            visited[row, col] = true;

            DFS(row, col - 1, nodeValue);
            DFS(row, col + 1, nodeValue);
            DFS(row - 1, col, nodeValue);
            DFS(row + 1, col, nodeValue);

        }
    }
}