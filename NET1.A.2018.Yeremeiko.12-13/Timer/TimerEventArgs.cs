using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    public class TimerEventArgs : EventArgs
    {
        private readonly int seconds;
        private readonly int minutes;
        private readonly int hours;

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerEventArgs"/> class.
        /// </summary>
        /// <param name="hours">The hours.</param>
        /// <param name="minutes">The minutes.</param>
        /// <param name="seconds">The seconds.</param>
        public TimerEventArgs(int hours, int minutes, int seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
        }

        /// <summary>
        /// Gets the seconds.
        /// </summary>
        /// <value>
        /// The seconds.
        /// </value>
        public int Seconds => seconds;

        /// <summary>
        /// Gets the minutes.
        /// </summary>
        /// <value>
        /// The minutes.
        /// </value>
        public int Minutes => minutes;

        /// <summary>
        /// Gets the hours.
        /// </summary>
        /// <value>
        /// The hours.
        /// </value>
        public int Hours => hours;
    }
}
