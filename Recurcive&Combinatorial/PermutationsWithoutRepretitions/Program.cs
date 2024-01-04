namespace PermutationsWithoutRepretitions
{
    public class Program
    {
        private static string[] elements;

        //PermutationsWithoutRepretitions three Arrays

        //private static string[] permutations;
        //private static bool[] used;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();

            // With three arrays

            //permutations = new string[elements.Length];
            //used = new bool[elements.Length];

            Permute(0);
        }

        private static void Permute(int idx)
        {
            if (idx >= elements.Length)
            {
                // with three arrays printing array permutations

                Console.WriteLine(String.Join(" ", elements));
                return;
            }

            Permute(idx + 1);

            for (int i = idx + 1; i < elements.Length; i++)
            {
                Swap(idx, i);
                Permute(idx + 1);
                Swap(idx, i);
            }

            //With three arrays

            //for (int i = 0; i < elements.Length; i++)
            //{
            //    if (!used[i])
            //    {
            //        used[i] = true;
            //        permutations[idx] = elements[i];

            //        Permute(idx + 1);

            //        used[i] = false;
            //    }
            //}
        }

        private static void Swap(int first, int second)
        {
            (elements[first], elements[second]) = (elements[second], elements[first]);
        }
    }
}