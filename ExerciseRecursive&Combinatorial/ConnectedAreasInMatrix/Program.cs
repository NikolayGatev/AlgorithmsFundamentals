namespace ConnectedAreasInMatrix
{
    public class Area
    {
        public int Row { get; set; }

        public int Col { get; set; }

        public int Size { get; set; }

    }
    public class Program
    {
        private const char VisitedSymbol = 'v';
        private static char[,] matrix;
        private static int size = 0;
        public static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            matrix = new char[row, col];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var curentRow = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = curentRow[j];
                }
            }

            var areas = new List<Area>();

            for (int i = 0;i < matrix.GetLength(0); i++)
            {
                for(int j = 0;j < matrix.GetLength(1); j++)
                {
                    size = 0;
                    GetAraes(i, j);

                    if (size != 0)
                    {
                        areas.Add(new Area { Row = i, Col = j, Size = size });
                    }

                }
            }
            var sorted = areas.OrderByDescending(x => x.Size).ThenBy(x => x.Row).ThenBy(x => x.Col).ToList();

            Console.WriteLine($"Total areas found: {areas.Count}");

            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({areas[i].Row}, {areas[i].Col}), size: {areas[i].Size}");
            }
        }

        private static void GetAraes(int row, int col)
        {
            if (IsOutMatrix(row, col) || IsWall(row, col) || IsVisited(row, col))
            {
                return;
            }

            size++;
            matrix[row, col] = VisitedSymbol;

            GetAraes(row - 1, col);
            GetAraes(row + 1, col);
            GetAraes(row, col - 1);
            GetAraes(row, col + 1);
        }

        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == VisitedSymbol;
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutMatrix(int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1);
        }
    }
}