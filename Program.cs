using System;

namespace DMassignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            Automatron automatron = new Automatron();
            System.Console.WriteLine("Please choose 1 (succesful log parse) or 2 (failed log parse)");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int res))
            {
                automatron.ParseLog(res);
                Console.WriteLine("Log parsed");
            }else
            {
                System.Console.WriteLine("meltdown initiated - enjoy");
            }
        }
    }
}
