using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( @"enter two numbers and an operator in order(when you finish every entering you should enter '\n' )" );
            double a = Convert.ToDouble(Console.ReadLine());
            double b = Convert.ToDouble(Console.ReadLine());
L:          char c = Convert.ToChar(Console.ReadLine());
            double result;
            switch (c)
            {
                case '*': result = a * b;break;
                case '+':result = a + b;break;
                case '-':result = a - b;break;
                case '/':result = a / b;break;
                default:
                    Console.WriteLine("you can only enter + - * /, please enter again!");
                    goto L;
            }
            Console.WriteLine("the answer is " + result);
            Console.WriteLine("enter any key to quit!");
            Console.ReadKey();
        }
    }
}
