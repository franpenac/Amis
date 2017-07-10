using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;
using amis._Controls;

namespace amis._DataLayer.GeneratedCode
{
    public partial class DcUserAlarm
    {
        public void Copy(UserAlarm objSource, ref UserAlarm objDestination)
        {
            objDestination.UserAlarmId = objSource.UserAlarmId;
            objDestination.AmisUserId = objSource.AmisUserId;
            objDestination.AlarmId = objSource.AlarmId;
            objDestination.UserAlarmTypeId = objSource.UserAlarmTypeId;
        }

        public UserAlarm Save(UserAlarm objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        UserAlarm row = context.UserAlarm.Where(r => r.UserAlarmId == objSource.UserAlarmId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new UserAlarm();
                            Copy(objSource, ref row);
                            context.UserAlarm.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha asignado alarma al usuario:" + row.AmisUserId + " con el id:" + row.UserAlarmId;
                        new DcPageLog().Save(action, description);
                        transaction.Complete();
                        return row;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public UserAlarm GetUserAlarmById(int Id, int userId)
        {
            try
            {
                UserAlarm obj = null;
                using (var context = new Entity())
                {
                    obj = context.UserAlarm.Where(r => r.AlarmId == Id && r.AmisUserId == userId).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<UserAlarmSaved> GetUserAlarmList(int userId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<UserAlarmSaved> list = (from userAlarms in context.UserAlarm
                                                 join amisUser in context.AmisUser
                                                 on userAlarms.AmisUserId equals amisUser.AmisUserId
                                                 join alarm in context.Alarm 
                                                 on userAlarms.AlarmId equals alarm.AlarmId
                                                 join userAlarmtype in context.UserAlarmType
                                                 on userAlarms.UserAlarmTypeId equals userAlarmtype.UserAlarmTypeId
                                                 where userAlarms.AmisUserId == userId
                                                 select new UserAlarmSaved
                                                 {
                                                     UserAlarmId = userAlarms.UserAlarmId,
                                                     AmisUserId = amisUser.AmisUserId,
                                                     AlarmId = alarm.AlarmId,
                                                     AlarmName = alarm.AlarmName,
                                                     UserAlarmTypeId = userAlarmtype.UserAlarmTypeId,
                                                     UserAlarmTypeName = userAlarmtype.UserAlarmTypeName

                                                 }).OrderBy(r => r.AlarmName).ToList();
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
