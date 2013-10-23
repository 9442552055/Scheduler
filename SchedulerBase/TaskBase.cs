using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler.Base
{
    public abstract class TaskBase : ITask
    {
        public TaskBase()
        {
         
        }

        public abstract void Run();
    }
}
