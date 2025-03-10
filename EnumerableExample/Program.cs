namespace EnumerableExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Values:");
            // LINQ
            // Lamda expression: v => v > 2
            var values = GetValues();
            var enumerator = values.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }

        public static IEnumerable<int> GetValues()
        {
            // Valahogyan lesznek adataink...
            var tomb = new int[] { 1, 2, 3, 4, 5 };
            // Egyesével adjuk vissza őket
            foreach (var v in tomb)
            {
                yield return v;
            }
        }
    }
}
