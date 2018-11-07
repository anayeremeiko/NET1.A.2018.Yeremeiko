using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    public class TimerManager
    {
        private string timerName = "DefaultName";

        /// <summary>
        /// Gets or sets the name of the timer.
        /// </summary>
        /// <value>
        /// The name of the timer.
        /// </value>
        public string TimerName { get; set; }

        /// <summary>
        /// Occurs when time is over.
        /// </summary>
        public event EventHandler<TimerEventArgs> TimeOver = delegate { };

        /// <summary>
        /// Timer start.
        /// </summary>
        /// <param name="hours">The hours.</param>
        /// <param name="minutes">The minutes.</param>
        /// <param name="seconds">The seconds.</param>
        public void Run(int hours, int minutes, int seconds)
        {
            Thread timer = new Thread(StartCountDown);
            timer.Start(new TimeSpan(hours, minutes, seconds));
        }

        /// <summary>
        /// Timer start.
        /// </summary>
        /// <param name="minutes">The minutes.</param>
        /// <param name="seconds">The seconds.</param>
        public void Run(int minutes, int seconds)
        {
            Thread timer = new Thread(StartCountDown);
            timer.Start(new TimeSpan(0, minutes, seconds));
        }

        /// <summary>
        /// Timer start.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        public void Run(int seconds)
        {
            Thread timer = new Thread(StartCountDown);
            timer.Start(new TimeSpan(0, 0, seconds));
        }

        /// <summary>
        /// Raises the <see cref="E:TimeOver" /> event.
        /// </summary>
        /// <param name="e">The <see cref="TimerEventArgs"/> instance containing the event data.</param>
        protected virtual void OnTimeOver(TimerEventArgs e)
        {
            TimeOver?.Invoke(this, e);
        }

        /// <summary>
        /// Starts the count down.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <exception cref="ArgumentNullException">Time need to be not null.</exception>
        /// <exception cref="ArgumentException">Time is incorrect.</exception>
        private void StartCountDown(object time)
        {
            if (ReferenceEquals(time, null))
            {
                throw new ArgumentNullException($"{nameof(time)} need to be not null.");
            }

            if (!(time is TimeSpan))
            {
                throw new ArgumentException($"{nameof(time)} is incorrect.");
            }

            var timer = (TimeSpan) time;

            Thread.Sleep(timer);
            OnTimeOver(new TimerEventArgs(timer.Hours, timer.Minutes, timer.Seconds));
        }
    }
}
