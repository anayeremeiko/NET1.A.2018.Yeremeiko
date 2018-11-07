using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer;

namespace TimerConsole
{
    public class Subscriber
    {
        /// <summary>
        /// Registers to the specified timer.
        /// </summary>
        /// <param name="manager">The timer.</param>
        public void Register(TimerManager manager)
        {
            manager.TimeOver += this.TimeOutMsg;
        }

        /// <summary>
        /// Unsubscribes from the specified timer.
        /// </summary>
        /// <param name="manager">The timer.</param>
        public void Unregister(TimerManager manager)
        {
            manager.TimeOver += this.TimeOutMsg;
        }

        private void TimeOutMsg(object sender, TimerEventArgs info)
        {
            TimerManager manager = (TimerManager) sender;
            Console.WriteLine($"Time out! Timer: {manager.TimerName}. Time requested: {info.Hours}:{info.Minutes}:{info.Seconds}");
        }
    }
}
