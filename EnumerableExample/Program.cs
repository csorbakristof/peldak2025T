namespace EnumerableExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Values:");
            // LINQ
            // Lamda expression: v => v > 2
            foreach (var v in GetValues().Where( v => v > 1 )
                .Select( v => 3*v ))
                Console.WriteLine(v);
        }

        public static IEnumerable<int> GetValues()
        {
            var tomb = new int[] { 1, 2, 3, 4, 5 };
            return tomb;
        }
    }
}
