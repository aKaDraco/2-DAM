namespace DELEGADOS1
{
    internal class Program
    {
        //public static void view(int grade)
        //{
        //    Console.ForegroundColor = grade >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
        //    Console.WriteLine($"Student grade: {grade,3}.");
        //    Console.ResetColor();
        //}
        //public static bool pass(int num)
        //{
        //    return num >= 5;
        //}
        static void Main(string[] args)
        {
            int[] v = { 2, 2, 6, 7, 1, 10, 3 };
            Array.ForEach(v, item =>
            {
                Console.ForegroundColor = item >= 5 ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine($"Student grade: {item,3}.");
                Console.ResetColor();
                double inver = 1.0 / item;
                Console.WriteLine($"The inverse of {item} is: {inver,3}");
            });
            int res = Array.FindIndex(v, ite => ite >= 5);
            Console.WriteLine("Last approved array postion: " + res);
            Console.WriteLine($"The first passing student is number {res + 1} in the list.");
            Console.ReadKey();
        }

    }
}