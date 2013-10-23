using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            System.ServiceProcess.ServiceBase.Run(new Service());
        }
    }
}
