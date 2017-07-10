using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models
{
    public class UserAlarmSaved
    {
        public int UserAlarmId { get; set; }
        public int AmisUserId { get; set; }
        public int AlarmId { get; set; }
        public string AlarmName { get; set; }
        public int UserAlarmTypeId { get; set; }
        public string UserAlarmTypeName { get; set; }
    }
}