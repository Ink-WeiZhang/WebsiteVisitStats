using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace n360sitestats4.Models
{
    public class Visit
    {
        [Key]
        public int VisitID { get; set; }
        public DateTime VisitDateTime { get; set; }
        public long UserID { get; set; }
        public OperatingSystemType OperatingSystem{ get; set; }
        public DeviceType Device { get; set; }
        
    }

    public enum OperatingSystemType
    {
        Undefined = 0,
        MacOS = 1,
        Windows = 2,
        Linux = 3,
        iOS = 4,
        Android = 5,
        WindowsPhone = 6
    }

    public enum DeviceType
    {
        Undefined = 0,
        Desktop = 1,
        Tablet = 2,
        Smartphone = 3,
        SmartTV = 4,
        Watch = 5
    }

}
