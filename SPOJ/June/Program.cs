namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Program1 prog1 = new Program1();
            //prog1.Run();

            PrimeNumberGenerator prog2 = new PrimeNumberGenerator();
            prog2.Run();
            System.Console.WriteLine("Press any key to Stop......");
            System.Console.ReadLine();
        }
    }
}
