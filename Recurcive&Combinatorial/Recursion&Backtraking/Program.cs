namespace Recursion_Backtraking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Console.WriteLine(SumRecursively(numbers, 0));
        }

        private static int SumRecursively(int[] numbers, int idx)
        {
            if (idx == numbers.Length - 1)
            {
                return numbers[idx];
            }

            return numbers[idx] + SumRecursively(numbers, idx + 1);
        }
    }
}