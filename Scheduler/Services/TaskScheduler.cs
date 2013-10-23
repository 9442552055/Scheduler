using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Scheduler.Data.Entities;

namespace Scheduler.Base
{
    public class TaskScheduler : IDisposable
    {
        public ScheduleConfig ScheduleConfig { get; private set; }
        public System.Threading.Timer Timer { get; private set; }

        private Assembly assembly;
        private Type ITaskType;
        private ITask taskInstance;
        public TaskScheduler(ScheduleConfig config)
        {
            ScheduleConfig = config;
            Timer = new System.Threading.Timer(TimerCallbackTarget);
        }

        public void StartSchedule()
        {
            try
            {
                CreateTaskInstance();
                Timer.Change(ScheduleConfig.DueTime, ScheduleConfig.Interval);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message + " at " + DateTime.Now.ToString());
            }
        }

        private void CreateTaskInstance()
        {
            assembly = Assembly.LoadFrom(ScheduleConfig.AssemblyName);
            ITaskType = assembly.GetType(ScheduleConfig.TypeName);
            if (ITaskType != null)
            {
                taskInstance = Activator.CreateInstance(ITaskType, new Object[]{
                    //TODO : Parameterised Task
                }) as ITask;
            }
        }

        private void TimerCallbackTarget(object state)
        {
            if (taskInstance == null)
                CreateTaskInstance();
            if (taskInstance != null)
            {
                if (ScheduleConfig.CanPause)
                {
                    //TODO Fetch config from db again to check whether paused.
                    if (!ScheduleConfig.Paused)
                    {
                        taskInstance.Run();
                    }
                }
                else
                    taskInstance.Run();
            }
        }

        public void Dispose()
        {
            Timer.Dispose();
            Timer = null;
            ITaskType = null;
            taskInstance = null;
            GC.Collect();
        }
    }
}
