using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;
using System.ComponentModel;
using System.Diagnostics;
using System.Timers;
using TextLogger;
using Scheduler.Services;

namespace Scheduler
{
    public class Service : ServiceBase
    {
        public ProjectInstaller installer;
       // List<ScheduleConfig> ScheduleConfigs = new List<ScheduleConfig>();
       // List<ScheduleTimer> ScheduleTimers = new List<ScheduleTimer>();

        public Service()
        {
            this.ServiceName = "Scheduler";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
            InitializeComponent();
            Logger.Instance.LogFile = @"D:\Scheduler.txt";
        }

        protected override void OnStart(string[] args)
        {
            // Insert code here to define processing.
            Logger.Instance.Log("Started at " + DateTime.Now.ToString());
            ScheduleRunner.RunScheduledTasks();
            //ScheduleConfigs = new List<ScheduleConfig>();
            //ScheduleTimers = new List<ScheduleTimer>();

            //TODO have to fetch this info from xml or from Table in DB
            //ScheduleConfigs.Add(new ScheduleConfig
            //{
            //    ApplicationName = "Email Sender",
            //    ApplicationNameWithPath = @"D:\Debug1\EmailSender.exe",
            //    SchedulePeriodicityInMins = 0.1,
            //    Enabled = true
            //});

            //foreach (ScheduleConfig c in ScheduleConfigs)
            //{
            //    ScheduleTimer T = new ScheduleTimer(c);
            //    T.Elapsed += new ElapsedEventHandler(T_Elapsed);
            //    System.IO.File.AppendAllText(@"D:\Scheduler.txt", "Started "+c.ApplicationName +" at " + DateTime.Now.ToString());
            //    T.Start();
            //    ScheduleTimers.Add(T);
            //}
            base.OnStart(args);
        }

        //void T_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    ScheduleConfig _config = (sender as ScheduleTimer).Config;
        //    try
        //    {
        //        System.IO.File.AppendAllText(@"D:\Scheduler.txt", Environment.NewLine + "Invoke started " + _config.ApplicationNameWithPath + " at " + DateTime.Now.ToString());
        //        Process.Start(new ProcessStartInfo
        //        {
        //            WindowStyle = ProcessWindowStyle.Hidden,
        //            FileName = _config.ApplicationNameWithPath,
        //            CreateNoWindow = true
        //        });
        //    }
        //    catch (Exception exp)
        //    {
        //        System.IO.File.AppendAllText(@"D:\Scheduler.txt", Environment.NewLine + "Failed to invoke " + _config.ApplicationNameWithPath + " at " + DateTime.Now.ToString());
        //    }
        //}

       
        protected override void OnStop()
        {
            ScheduleRunner.StopScheduledTasks();
            Logger.Instance.Log("Stopped at " + DateTime.Now.ToString());

            //foreach (ScheduleTimer t in ScheduleTimers)
            //{
            //    try
            //    {
            //        t.Stop();
            //        t.Dispose();
            //    }
            //    catch (Exception e)
            //    {
            //        System.IO.File.AppendAllText(@"D:\Scheduler.txt", Environment.NewLine + "Failed to stop/dispose " + t.ToString() +" at " + DateTime.Now.ToString());
            //    }
            //}
            base.OnStop();
        }

        private void InitializeComponent()
        {
            installer = new ProjectInstaller();
        }

    }

    public class ScheduleTimer : Timer
    {
       // public ScheduleConfig Config { get; private set; }
        //public ScheduleTimer(ScheduleConfig config)
        //    : base(config.SchedulePeriodicityInMins * 60000)
        //{
        //    Config = config;
        //    this.Enabled = config.Enabled;
           
        //}
    }
}
