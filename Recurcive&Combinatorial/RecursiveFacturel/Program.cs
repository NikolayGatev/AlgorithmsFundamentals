namespace RecursiveFacturel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFactorialRecursive(n));
        }

        private static int CalcFactorialRecursive(int n)
        {
            if(n == 0)
            {
                return 1;
            }

            return n * CalcFactorialRecursive(n - 1);
        }
    }
}