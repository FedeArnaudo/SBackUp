using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBackUp
{
    internal class Task
    {
        private IScheduler scheduler;
        private BackUp backUp;
        private Compressor compressor;
        public Task()
        {

        }
        public IScheduler Scheduler { get; set; }
        public void StartTask()
        {

        }
    }
}
