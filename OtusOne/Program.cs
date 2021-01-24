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

        private static int GetResult(int numberOne, int numberTwo, string howCalculate)
        {
            int resultCalculate;
            switch (howCalculate)
            {
                case "+":
                    resultCalculate = numberOne + numberTwo;
                    break;
                case "-":
                    resultCalculate = numberOne - numberTwo;
                    break;
                case "*":
                    resultCalculate = numberOne * numberTwo;
                    break;
                case "/":
                    try
                    {
                        resultCalculate = numberOne / numberTwo;
                    }
                    catch (DivideByZeroException)
                    {
                        resultCalculate = 0;
                        Console.WriteLine("You cannot divide by 0");
                    }
                    break;
                case "max":
                    resultCalculate = Math.Max(numberOne, numberTwo);
                    break;
                case "min":
                    resultCalculate = Math.Min(numberOne, numberTwo);
                    break;

                default:
                    Console.WriteLine("Enter correct Value...");
                    resultCalculate = 0;
                    break;
            }
            return resultCalculate;
        }

        private static int GetNumber(string readNumber)
        {
            Console.WriteLine(readNumber);

            while (true)
            {
                string intNumber = Console.ReadLine();
                int resultCalculate;
                if (Int32.TryParse(intNumber, out resultCalculate))
                    return resultCalculate;
                else
                {
                    Console.WriteLine("Enter correct Value...");
                }
            }

        }


    }
}

