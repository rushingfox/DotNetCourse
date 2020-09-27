using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shapes;                    //to use the other project(named as shapes) in the same solution, I add it to the "cite" part of this project (ShapeFactory) firstly. Then I write this line to use it actually.

namespace ShapeFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            Random random = new Random();
            double sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum+=factory.produce((ShapeFactory.shapename)random.Next(3)).area_calculating();
            }
            Console.WriteLine("the sum area of this ten shapes:"+sum);
            Console.ReadKey();
        }
    }
}