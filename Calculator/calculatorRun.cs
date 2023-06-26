using System;

namespace Calculator
{
    public static class CalculatorStart
    {
        public static void RunCalculator()
        {
            Console.WriteLine();
            Console.WriteLine("Calculator");
            Console.WriteLine("------------");

            bool validInput = false; 
            double num1 = 0; 

            while (!validInput)
            {
                Console.WriteLine("Enter the first number:");

                if (!double.TryParse(Console.ReadLine(), out num1))
                {
                    Console.WriteLine("Invalid number. Please try again.");
                    Console.WriteLine();
                }
                else
                {
                    validInput = true;
                }
            }

            validInput = false; 
            string operation = string.Empty;

            while (!validInput)
            {
                Console.WriteLine("Enter an arithmetic operation (+, -, *, /):");
                operation = Console.ReadLine();

                if (operation != "+" && operation != "-" && operation != "*" && operation != "/")
                {
                    Console.WriteLine("Invalid arithmetic operation. Please try again.");
                    Console.WriteLine();
                }
                else
                {
                    validInput = true;
                }
            }

            validInput = false;
            double num2 = 0; 

            while (!validInput)
            {
                Console.WriteLine("Enter the second number:");

                if (!double.TryParse(Console.ReadLine(), out num2))
                {
                    Console.WriteLine("Invalid number. Please try again.");
                    Console.WriteLine();
                }
                else
                {
                    validInput = true;
                }
            }

            double result = 0;

            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Division by zero is not allowed.");
                        Console.WriteLine();
                        Console.ReadKey();
                    }
                    result = num1 / num2;
                    break;
                default:
                    Console.WriteLine("Invalid operation");
                    Console.WriteLine();
                    return;
            }

            Console.WriteLine("Result: " + result);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
