using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer;

namespace TimerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new TimerManager();
            var subscriber = new Subscriber();

            subscriber.Register(timer);

            timer.Run(12);

            timer.TimerName = "Timer1";

            timer.Run(20);

            Console.ReadLine();
        }
    }
}
