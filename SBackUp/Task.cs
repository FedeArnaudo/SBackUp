using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBackUp
{
    internal class Task
    {
        public Task()
        {

        }
        public IScheduler Scheduler { get; set; }
        public Robocopy Robocopy { get; set; }
        public Compressor Compressor { get; set; }
        public void StartTask()
        {

        }
    }
}
