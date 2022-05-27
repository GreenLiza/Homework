using System;

namespace MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userAnswer;
            do
            {
                Console.WriteLine("Enter any number:");
                if (Int32.TryParse(Console.ReadLine(), out int x))
                {
                    Multiplicate(x);
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
                Console.WriteLine("If you want to repeat - press enter. If you want to quit - enter 'exit'.");
                userAnswer = Console.ReadLine();
            } while (userAnswer != "exit");
            

        }

        static void Multiplicate(int number)
        {
            for (int i=1; i<11; i++)
            {
                Console.WriteLine($"{number}*{i}={number * i}");
            }
        }
    }
}
