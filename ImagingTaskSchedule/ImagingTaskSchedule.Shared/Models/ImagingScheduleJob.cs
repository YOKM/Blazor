using System;
using System.Collections.Generic;

namespace ImagingTaskSchedule.Shared.Models
{
    public partial class ImagingScheduleJob
    {
        public int Id { get; set; }
        public string Jobname { get; set; }
        public string ScheduleTime { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
    }
}
