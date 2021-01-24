using System;

namespace OtusOne
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                int numberOne = GetNumber("Enter the first number");
                int numberTwo = GetNumber("Enter the second number");


                Console.WriteLine("Choose an operation: +, -, *, /, max, min");
                string howCalculate = Console.ReadLine();


                int resultCalculate = GetResult(numberOne, numberTwo, howCalculate);
                Console.WriteLine(resultCalculate);

            } while (AskContinue());
        }

        static bool AskContinue()
        {
            while (true) 
            {
                Console.WriteLine("Do you want to continue? Y/N");
                string askStatus = Console.ReadLine();
                if (askStatus.ToUpper() == "Y")
                    return true;
                else if (askStatus.ToUpper() == "N")
                    return false;
                else
                    Console.WriteLine("Incorrect answer.Try again...");


            }
        }

        private static int GetResult(int NumberOne, int NumberTwo, string HowCalculate)
        {
            int ResultCalculate;
            switch (HowCalculate)
            {
                case "+":
                    ResultCalculate = NumberOne + NumberTwo;
                    break;
                case "-":
                    ResultCalculate = NumberOne - NumberTwo;
                    break;
                case "*":
                    ResultCalculate = NumberOne * NumberTwo;
                    break;
                case "/":
                    try
                    {
                        ResultCalculate = NumberOne / NumberTwo;
                    }
                    catch (DivideByZeroException)
                    {
                        ResultCalculate = 0;
                        Console.WriteLine("You cannot divide by 0");
                    }
                    break;
                case "max":
                    ResultCalculate = GetMax(NumberOne, NumberTwo);
                    break;
                case "min":
                    ResultCalculate = GetMin(NumberOne, NumberTwo);
                    break;

                default:
                    Console.WriteLine("Enter correct Value...");
                    ResultCalculate = 0;
                    break;
            }
            return ResultCalculate;
        }

        private static int GetNumber(string readNumber)
        {
            Console.WriteLine(readNumber);

            while (true)
            {
                string intNumber = Console.ReadLine();
                int ResultCalculate;
                if (Int32.TryParse(intNumber, out ResultCalculate))
                    return ResultCalculate;
                else
                {
                    Console.WriteLine("Enter correct Value...");
                }
            }

        }

        static int GetMax(int numberOne, int numberTwo)
        {
            int maxValue = 0;
            if (numberOne > numberTwo)
                maxValue = numberOne;
            else
            {
                maxValue = numberTwo;
            }
            return maxValue;
        }

        static int GetMin(int numberOne, int numberTwo)
        {
            int minValue = 0;
            if (numberOne < numberTwo)
                minValue = numberOne;
            else
                minValue = numberTwo;
            return minValue;
        }
    }
}
