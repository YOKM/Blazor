using System;
using System.Collections.Generic;

namespace ImagingTaskSchedule.Shared.Models
{
    public partial class ImagingJobdetails
    {
        public int Id { get; set; }
        public string Jobname { get; set; }
        public int Jobid { get; set; }
        public string EmailNotificationAddress { get; set; }
        public string JobdetailsType { get; set; }
        public string SFtphost { get; set; }
        public string SFtpuploadFrom { get; set; }
        public string SFtpuploadto { get; set; }
        public string SFtpdownloadFrom { get; set; }
        public string SFtpdownloadTo { get; set; }
        public string UsernamesFtp { get; set; }
        public string PaswordsFtp { get; set; }
        public string SshfingerPrint { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Extra4 { get; set; }
        public string Extra5 { get; set; }
    }
}
