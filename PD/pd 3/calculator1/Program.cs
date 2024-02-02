using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static calculator.calculator;

namespace calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator calculator = null;

            while (true)
            {
                Console.Clear(); 
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Create a Single Object of Calculator");
                Console.WriteLine("2. Change Values of Attributes");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Subtract");
                Console.WriteLine("5. Multiply");
                Console.WriteLine("6. Divide");
                Console.WriteLine("7. Modulo");
                Console.WriteLine("8. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse((Console.ReadLine()));

                if (choice == 1)
                {
                    if (calculator == null)
                    {
                        calculator = new Calculator();
                        Console.WriteLine("Calculator object created.");
                    }
                    else
                    {
                        Console.WriteLine("Calculator object already exists.");
                    }
                }
                else if (choice == 2)
                {
                    if (calculator != null)
                    {
                        Console.Write("Enter value for number1: ");
                        calculator.number1 = int.Parse((Console.ReadLine()));
                        Console.Write("Enter value for number2: ");
                        calculator.number2 = int.Parse(Console.ReadLine());

                        Console.WriteLine("Values of attributes changed.");
                    }
                    else
                    {
                        Console.WriteLine("Calculator object does not exist. Create a calculator object first.");
                    }
                }
                else if (choice == 3)
                {
                    if (calculator != null)
                    {
                        int result = calculator.Add();
                        Console.WriteLine($"Addition: {calculator.number1} + {calculator.number2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Calculator object does not exist. Create a calculator object first.");
                    }
                }
                else if (choice == 4)
                {
                    if (calculator != null)
                    {
                        int result = calculator.Subtract();
                        Console.WriteLine($"Subtraction: {calculator.number1} - {calculator.number2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Calculator object does not exist. Create a calculator object first.");
                    }
                }
                else if (choice == 5)
                {
                    if (calculator != null)
                    {
                        int result = calculator.Multiply();
                        Console.WriteLine($"Multiplication: {calculator.number1} * {calculator.number2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Calculator object does not exist. Create a calculator object first.");
                    }
                }
                else if (choice == 6)
                {
                    if (calculator != null)
                    {
                        double result = calculator.Divide();
                        Console.WriteLine($"Division: {calculator.number1} / {calculator.number2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Calculator object does not exist. Create a calculator object first.");
                    }
                }
                else if (choice == 7)
                {
                    if (calculator != null)
                    {
                        int result = calculator.Modulo();
                        Console.WriteLine($"Modulo: {calculator.number1} % {calculator.number2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine("Calculator object does not exist. Create a calculator object first.");
                    }
                }
                else if (choice == 8)
                {
                    Console.WriteLine("Exiting the program...");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                }

                Console.WriteLine();
            }
        }
    }





}

