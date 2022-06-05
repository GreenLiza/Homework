using System;
using System.Numerics;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator();
        }

        static void Calculator()
        {
            int option;
            do
            {
                Console.WriteLine("Please choose the operation: \n1-'+', \n2-'-', \n3-'*', \n4-'/', \n5-'^', \n6-'!', \n0-exit.");
                if (Int32.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine($"Result = {Sum()}");
                            break;
                        case 2:
                            Console.WriteLine($"Result = {Minus()}");
                            break;
                        case 3:
                            Console.WriteLine($"Result = {Multiply()}");
                            break;
                        case 4:
                            Console.WriteLine($"Result = {Divide()}");
                            break;
                        case 5:
                            Console.WriteLine($"Result = {Exponentiate()}");
                            break;
                        case 6:
                            Console.WriteLine($"Result = {Factorial(EnterPosIntNumber())}");
                            break;
                        case 0:
                            Console.WriteLine("Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Incorrect input, try again");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input, try again");
                    option = 1;
                }
            }
            while (option != 0);
        }

        static bool Rand(out double randNum1, out double randNum2)
        {
            Console.WriteLine("Do you want to use random numbers? Enter 1 for positive answer");
            if (Console.ReadLine() == "1")
            {
                randNum1 = Convert.ToDouble(new Random().Next(int.MinValue, int.MaxValue));
                randNum2 = Convert.ToDouble(new Random().Next(int.MinValue, int.MaxValue));
                Console.WriteLine($"First number: {randNum1}, second number: {randNum2}");
                return true;
            }
            else
            {
                randNum1 = 0;
                randNum2 = 0;
                return false;
            }
        }
        static double EnterNumber(string n)
        {
            Console.WriteLine($"Please, enter {n} number: ");
            if (double.TryParse(Console.ReadLine(), out double number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Incorrect input, try again");
                return EnterNumber(n);
            }
        }

        static double EnterPosIntNumber()
        {
            Console.WriteLine("Enter 1 to use random number or press 'enter' to choose manually");
            if (Console.ReadLine() == "1")
            {
                var randNum = Convert.ToDouble(new Random().Next());
                Console.WriteLine(randNum);
                return randNum;
            }
            else
            {
                Console.WriteLine("Please, enter any positive integer number: ");
                if (Double.TryParse(Console.ReadLine(), out double number))
                {
                    if (number >= 0 && number % 1 == 0)
                        return number;
                    else
                    {
                        Console.WriteLine("Incorrect input");
                        return EnterPosIntNumber();
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect input, try again");
                    return EnterPosIntNumber();
                }
            }


        }

        private static void CheckRand(out double x, out double y, string s1 = "first", string s2 = "second")
        {
            if (!Rand(out x, out y))
            {
                x = EnterNumber(s1);
                y = EnterNumber(s2);
            }
        }

        static double Sum()
        {
            CheckRand(out double x, out double y);
            double sum = x + y;
            return sum;
        }

        static double Minus()
        {
            CheckRand(out double x, out double y);
            double minus = x - y;
            return minus;
        }

        static double Multiply()
        {
            CheckRand(out double x, out double y);
            double mult = x * y;
            return mult;
        }

        static double Divide()
        {
            CheckRand(out double x, out double y);
            double div = x / y;
            return div;
        }

        static double Exponentiate()
        {
            CheckRand(out double x, out double y, "any", "the power");
            double exp = Math.Pow(x, y);
            return exp;
        }

        static double Factorial(double x)
        {
            double fact;
            if (x == 1 || x == 0)
            {
                fact = 1;
            }
            else
            {
                fact = x * Factorial(x - 1);
            }
            return fact;
        }

        /*
        static BigInteger Factorial(BigInteger x)
        {
            BigInteger fact;
            if (x == 1 || x == 0)
            {
                fact = 1;
            }
            else
            {
                fact = x * Factorial(x - 1);
            }
            return fact;
        }*/
    }

}

