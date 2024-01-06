namespace QuicSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            QuicSort(numbers, 0, numbers.Length - 1);

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void QuicSort(int[] numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while(left <= right)
            {
                if (numbers[left] > numbers[pivot] &&
                    numbers[right] < numbers[pivot])
                {
                    Swap(numbers, left, right);
                }

                if (numbers[left] <= numbers[pivot])
                {
                    left++;
                }

                if (numbers[right] >= numbers[pivot])
                {
                    right--;
                }
            }

            Swap(numbers, pivot, right);

            QuicSort(numbers, start, right - 1);
            QuicSort(numbers, right + 1, end);
        }

        private static void Swap(int[] numbers, int first, int second)
        {
            (numbers[first], numbers[second]) = (numbers[second], numbers[first]);
        }
    }
}