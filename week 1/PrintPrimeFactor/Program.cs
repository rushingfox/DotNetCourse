using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintPrimeFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"please enter a positive integer and a \n:");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number<=0)
            {
                Console.WriteLine("the number is invalid!");
            }
            else
            {
                Console.WriteLine("the prime factor(s) is below:");
                for (int trynum1 = 2;trynum1<= 0.5*number; trynum1++)
                {
                    if (number%trynum1==0)
                    {
                        bool isprime = true;
                        for (int trynum2 = 2; trynum2 <= Math.Sqrt(trynum1); trynum2++)
                        {
                            if (trynum2%trynum1==0)
                            {
                                isprime = false;
                            }
                        }
                        if (isprime)
                        {
                            Console.Write(trynum1+" ");
                        }
                    }
                }
            }
            Console.ReadKey();//pause the console
        }
    }
}
