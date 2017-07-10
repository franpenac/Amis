using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;

namespace amis._DataLayer.GeneratedCode
{
    public partial class DcAlarm
    { 
        public List<Alarm> GetAlarmsList()
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Alarm> list = (from alarms in context.Alarm select alarms).ToList();
                    if (list != null)
                    {
                        return list;
                    }else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    IEnumerable<object> list =
                        (from alarm in context.Alarm
                         select new AlarmWebGrid
                         {
                             AlarmId = alarm.AlarmId,
                             AlarmName = alarm.AlarmName,
                             UserAlarmType = new Infragistics.Web.UI.ListControls.WebDropDown()

                         }).OrderBy(r => r.AlarmId).ToList();
                    if (list != null)
                    {
                        return list;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }
    }
}