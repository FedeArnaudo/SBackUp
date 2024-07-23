using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SBackUp
{
    internal interface IScheduler
    {
        Trigger FrecuencyTask();
        int Seconds { get; set; }
        int Minutes { get; set; }
        int Hours { get; set; }
    }
}
