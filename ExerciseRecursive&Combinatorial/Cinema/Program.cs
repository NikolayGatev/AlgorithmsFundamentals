using System.Runtime.CompilerServices;

namespace Cinema
{
    public class Program
    {
        private static List<string> nonStaticPeople;
        private static string[] people;
        private static bool[] locked;

        public static void Main(string[] args)
        {
            nonStaticPeople = Console.ReadLine().Split(", ").ToList();
            people = new string[nonStaticPeople.Count];
            locked = new bool[nonStaticPeople.Count];

            while(true)
            {
                var line = Console.ReadLine();

                if(line == "generate")
                {
                    break;
                }
                var part = line.Split(" - ");
                var name = part[0];
                var position = int.Parse(part[1]) - 1;

                people[position] = name;
                locked[position] = true;
                nonStaticPeople.Remove(name);
            }
            Permute(0);
        }

        private static void Permute(int idx)
        {
            if (idx >= nonStaticPeople.Count)
            {
                PrintPermutation();
                return;
            }

            Permute(idx + 1);

            for (int i = idx + 1; i < nonStaticPeople.Count; i++)
            {
                Swap(idx, 1);
                Permute(idx + 1);
                Swap(idx, 1);
            }
        }

        private static void PrintPermutation()
        {
            var peopleIndex = 0;

            for (int i = 0; i < people.Count(); i++)
            {
                if (locked[i])
                {
                    Console.Write(people[i] + " ");
                }
                else
                {
                    Console.Write(nonStaticPeople[peopleIndex++] + " ");
                }
            }
                Console.WriteLine();
        }

        private static void Swap(int first, int second)
        {
            (nonStaticPeople[first], nonStaticPeople[second]) = (nonStaticPeople[second], nonStaticPeople[first]);
        }
    }
}