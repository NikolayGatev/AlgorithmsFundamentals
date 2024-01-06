namespace InsertionSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            InsertionSort(numbers);

            Console.WriteLine(String.Join(" ", numbers));
        }

        private static void InsertionSort(int[] numbers)
        {
            for (int i = 1; i < numbers.Length; i++)
            {
                var j = i;

                while(j > 0 && numbers[j] > numbers[j-1])
                {
                    Swap(numbers, j);
                    j--;
                }
            }
        }

        private static void Swap(int[] numbers, int j)
        {
            (numbers[j], numbers[j-1]) = (numbers[j-1], numbers[j]);
        }
    }
}