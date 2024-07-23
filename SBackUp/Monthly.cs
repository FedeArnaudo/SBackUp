using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SBackUp
{
    internal class Monthly : IScheduler
    {
        public Monthly(int seconds, int minutes, int hours)
        {
            Seconds = seconds;
            Minutes = minutes;
            Hours = hours;
        }
        public int Seconds { get; set; }
        public int Minutes { get; set; }
        public int Hours { get; set; }
        public Trigger FrecuencyTask()
        {
            throw new NotImplementedException();
        }
    }
}
