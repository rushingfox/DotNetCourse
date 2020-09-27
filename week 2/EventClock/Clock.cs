using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace EventClock
{
    class Clock
    {
        public delegate void deal(int a);
        public event deal Tick;
        public event deal Alarm;

        public void run()
        {
            int time = 0;
            while (true)
            {
                time += 1;
                if (time % 10 == 0)     //alarm per ten seconds, and when the tick and alarm function were running together, the alarm was triggered first.(this also follows the fact alarm is more important and louder)
                {
                    Alarm(time);
                }
                Tick(time);         //tick per second
                Thread.Sleep(1000);
            }
        }
    }
}
