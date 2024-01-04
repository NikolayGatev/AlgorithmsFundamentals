using System.Runtime.InteropServices;

namespace Reverce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split();

            Reverce(elements, 0);

            Console.WriteLine(string.Join(" ", elements));
        }

        private static void Reverce(string[] elements, int idx)
        {
            if (idx > elements.Length / 2)
            {
                return;
            }
            var temp = elements[idx];
            elements[idx] = elements[elements.Length - idx - 1];
            elements[elements.Length - idx - 1] = temp;

            Reverce(elements, idx + 1);
        }
    }
}