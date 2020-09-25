using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> test = new GenericList<int>();//init the list
            Console.WriteLine("please enter the number of nodes you want:");
            int num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                test.Add(Convert.ToInt32(Console.ReadLine()));
            }


            test.ForEach(s => Console.WriteLine(s));//通过调用这个方法打印链表元素
            if (test.Head!=null)                    //通过调用这个方法求最大值和最小值
            {
                int max = test.Head.Data;
                int min = test.Head.Data;
                test.ForEach(s =>
                {
                    if (s > max)
                    {
                        max = s;
                    }
                    else if (s < min)
                    {
                        min = s;
                    }
                });
                Console.WriteLine("the max value: " + max + " the min value: " + min);
            }
            int sum = 0;
            test.ForEach(s =>  sum += s );
            Console.WriteLine("the sum is " + sum); //通过调用这个方法求和

            Console.ReadKey();
        }
    }
}
