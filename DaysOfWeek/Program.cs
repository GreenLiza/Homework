using System;

namespace DaysOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter day number (from 1 to 7) or 'exit' to quit");
                string UserInput = Console.ReadLine();
                if (UserInput == "exit")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else if (Int32.TryParse(UserInput, out int x))
                {
                    FindDay(x);
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
            }
        }

        static void FindDay(int dayNumber)
        {
            switch (dayNumber)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Out of range");
                    break;
            }
        }
    }
}
