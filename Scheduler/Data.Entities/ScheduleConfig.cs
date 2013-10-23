using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Data.Entities
{
    public class ScheduleConfig
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string AssemblyName { get; set; }
        public string TypeName { get; set; }
        public long Interval { get; set; }
        public long DueTime { get; set; }
        public bool Paused { get; set; }
        public bool CanPause { get; set; }
    }
}
