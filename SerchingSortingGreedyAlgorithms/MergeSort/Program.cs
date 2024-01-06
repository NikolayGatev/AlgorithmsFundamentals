namespace MergeSort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var sorted = MergeSort(numbers);

            Console.WriteLine(String.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] numbers)
        {
            if(numbers.Length <= 1)
            {
                return numbers;
            }

            var left = numbers.Take(numbers.Length / 2).ToArray();
            var right = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
           var merge = new int[left.Length + right.Length];

            var mergeIdx = 0;
            var leftIdx = 0;
            var rightIdx = 0;

            while(leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    merge[mergeIdx++] = left[leftIdx++];
                }
                else
                {
                    merge[mergeIdx++] = right[rightIdx++];
                }

                for (int i = leftIdx; i < left.Length; i++)
                {
                    merge[mergeIdx++] = left[i];
                }

                for (int i = rightIdx; i < right.Length; i++)
                {
                    merge[mergeIdx++] = right[i];
                }
            }
            return merge;
        }
    }
}