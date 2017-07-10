using Infragistics.Web.UI.ListControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amis.Models
{
    public class AlarmWebGrid
    {
        public int AlarmId { get; set; }
        public string AlarmName { get; set; }
        public WebDropDown UserAlarmType { get; set; }
    }
}
