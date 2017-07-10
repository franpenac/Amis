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
    class DcUserAlarmType
    {
        public IEnumerable<object> GetUserAlarmList()
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    IEnumerable<object> list = (from alarms in context.UserAlarmType
                                                select new
                                                {
                                                    UserAlarmTypeId = alarms.UserAlarmTypeId,
                                                    UserAlarmTypeName = alarms.UserAlarmTypeName

                                                }).ToList();
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

        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.UserAlarmType
                         select new TsDropDownItem()
                         {
                             ComboId = obj.UserAlarmTypeId.ToString(),
                             ComboName = obj.UserAlarmTypeName
                         }).ToList();
                    return list;
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
