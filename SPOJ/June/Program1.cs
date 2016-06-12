namespace ConsoleApplication
{
    public class Program1
    {
        public void Run()
        {
            string input = "";
            input = System.Console.ReadLine();
            while (!input.Equals("42"))
            {
                System.Console.WriteLine(input);
                input = System.Console.ReadLine();
            }
        }
    }
}