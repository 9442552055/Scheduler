using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scheduler.Data.Entities;
using Scheduler.Base;

namespace Scheduler.Services
{
    public static class ScheduleRunner
    {
        static List<TaskScheduler> scheduledTasks = new List<TaskScheduler>();
        public static void RunScheduledTasks()
        {

            //STEP 1: Fetch Schedule Configs
            List<ScheduleConfig> ScheduleConfigs = new List<ScheduleConfig>();

            Scheduler.Data.ScheduleConfigDBEntities entities = new Data.ScheduleConfigDBEntities();
            ScheduleConfigs = entities.ScheduleConfigurations.Select(f => new ScheduleConfig
            {
                AssemblyName = f.AssemblyName,
                CanPause = f.CanPause == 1,
                DueTime = f.DueTime,
                Id = f.Id,
                Interval = f.Interval,
                Paused = f.Paused == 1,
                TypeName = f.TypeName
            }).ToList();
            //Hardcoded instead should fetch from DB
            //ScheduleConfigs.Add(new ScheduleConfig
            //{
            //    DueTime = 500,
            //    Id = 1,
            //    Interval = 60000,
            //    CanPause=false,
            //    Paused=false,
            //    AssemblyName = @"D:\Importants\Scheduler\EmailNotification\bin\Release\EmailNotification.dll",
            //    TypeName = "EmailNotification.EmailNotificationTask"
            //    //Can add properties to configure parameters to inject for Task
            //});

            //Step 2: Loop The configurations and create ScheduledTask;
            foreach (ScheduleConfig config in ScheduleConfigs)
            {
                TaskScheduler taskScheduler = new TaskScheduler(config);
                taskScheduler.StartSchedule();
                scheduledTasks.Add(taskScheduler);
            }

        }

        public static void StopScheduledTasks()
        {
            foreach (TaskScheduler runnningTask in scheduledTasks)
            {
                runnningTask.Dispose();
            }
            scheduledTasks.Clear();
        }
    }
}
