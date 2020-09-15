using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[101];
            for (int i = 0; i < 101; i++) //initial
            {
                array[i] = 1 ;
            }
            array[0] = 0;
            array[1] = 0;                 //1 means still existing in the array, 0 means not.
            int num1 = 2;
            int num2 = 100;
            while (num1*num1<=num2)
            {
                for (int i = num1*num1; i <= num2; i+=num1)
                {
                    array[i] = 0;
                }
                for (int i = num2; i > num1; i--)
                {
                    if (array[i]==1)
                    {
                        num2 = i;
                        break;
                    }
                }
                for (int i = num1+1; i <= num2; i++)
                {
                    if (array[i]==1)
                    {
                        num1 = i;
                        break;
                    }
                }
            }
            for (int i = 0; i < 101; i++)
            {
                if (array[i]==1)
                {
                    Console.Write(i + " ");
                }
            }
            Console.ReadKey();
        }
    }
}
