namespace CombinationWithoutRepetisions
{
    public class Program
    {
        private static int k;
        private static string[] elements;
        private static string[] combinations;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();

            k = int.Parse(Console.ReadLine());
            combinations = new string[k];

            Combination(0, 0);
        }

        private static void Combination(int idx, int startIdx)
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine(String.Join(" ", combinations));
                return;
            }

            for (int i = startIdx; i < elements.Length; i++)
            {
                combinations[idx] = elements[i];

                //For combination with repetitions "startIdx = i", not "i + 1" 
                Combination(idx + 1, i + 1);
            }
        }
    }
}