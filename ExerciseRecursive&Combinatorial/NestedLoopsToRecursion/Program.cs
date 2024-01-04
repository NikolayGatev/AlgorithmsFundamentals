namespace NestedLoopsToRecursion
{
    public class Program
    {
        private static int[] elements;

        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            elements = new int[n];

            GenVecors(0);
        }

        private static void GenVecors(int idx)
        {
            if (idx >= elements.Length)
            {
                Console.WriteLine(String.Join(" ", elements));
                return;
            }

            for (int i = 1; i <= elements.Length; i++)
            {
                elements[idx] = i;
                GenVecors(idx + 1);
            }
        }
    }
}