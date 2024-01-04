namespace RecursiveFibonacci
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFib(n));
        }

        private static int CalcFib(int n)
        {
            if (n < 2)
            {
                return 1;
            }
            return CalcFib(n - 1) + CalcFib(n - 2);
        }
    }
}