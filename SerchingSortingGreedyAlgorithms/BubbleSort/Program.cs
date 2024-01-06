namespace BubbleSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            BubbleSort(numbers);

            Console.WriteLine(String.Join(" ", numbers));
        }

        private static void BubbleSort(int[] numbers)
        {
            var isSorted = false;

            while(!isSorted)
            {
                var sortedCount = 0;
                isSorted = true;

                for (int j = 1; j < numbers.Length - sortedCount; j++)
                {
                    var i = j - 1;

                    if (numbers[i] > numbers[j])
                    {
                        Swap(numbers, i, j);
                        isSorted = false;
                    }
                }
                sortedCount++;
            }
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            (numbers[first], numbers[second]) = (numbers[second], numbers[first]);
        }
    }
}