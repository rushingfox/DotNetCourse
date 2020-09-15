using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter the size of the array:");
            int size = Convert.ToInt32(Console.ReadLine());
            if (size<=0)
            {
                Console.WriteLine("size is invalid!");
            }
            else
            {
                double[] array = new double[size];
                Console.WriteLine(@"please enter the elements of the array(you should enter a \n behind every element):");
                for (int i = 0; i < size; i++)
                {
                    array[i] = Convert.ToDouble(Console.ReadLine());
                }

                double max, min, average, sum;
                max = array[0];
                min = array[0];
                sum = array[0];
                for (int i = 1; i < size; i++)
                {
                    sum += array[i];
                    if (array[i]<min)
                    {
                        min = array[i];
                    }
                    else if (array[i]>max)
                    {
                        max = array[i];
                    }
                }
                average = sum / size;

                Console.WriteLine($"maximum is{max}, minimum is {min}, average is {average} and the sum is {sum}");
            }
            Console.ReadKey();
        }
    }
}
