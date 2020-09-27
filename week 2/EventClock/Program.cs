using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventClock
{
    class Program
    {
        static public void print_time(int the_time)
        {
            Console.WriteLine(the_time);
        }
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            clock.Alarm += s => Console.WriteLine("alarm:");
            clock.Tick += s => Console.WriteLine("tick:");
            clock.Alarm += print_time;
            clock.Tick += print_time;
            

            clock.run();
            Console.ReadKey();
        }

    }
}
