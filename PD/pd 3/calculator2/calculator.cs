using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    internal class calculator
    {
        public class Calculator
        {
            public int number1;
            public int number2;

            public Calculator(int num1 = 10, int num2 = 10)
            {
                number1 = num1;
                number2 = num2;
            }

            public int Add()
            {
                return number1 + number2;
            }

            public int Subtract()
            {
                return number1 - number2;
            }

            public int Multiply()
            {
                return number1 * number2;
            }

            public double Divide()
            {
                if (number2 != 0)
                {
                    return (double)number1 / number2;
                }
                else
                {
                    Console.WriteLine("Error: Cannot divide by zero.");
                    return 0;
                }
            }

            public int Modulo()
            {
                return number1 % number2;
            }
            
        }

    }
    
}
    

