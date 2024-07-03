using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBackUp
{
    internal class TaskManager
    {
        private readonly List<Task> tasks;
        private static readonly TaskManager instanceTaskManager;
        private TaskManager()
        {
            tasks = new List<Task>();
        }
        public static TaskManager InstanceTaskManager { get; set; }
        public void AddTask(Task task)
        {

        }
        public bool EditTask()
        {
            return false;
        }
        public bool DeleteTask()
        {
            return false;
        }
        private Task GetTask()
        {
            return null;
        }
    }
}
