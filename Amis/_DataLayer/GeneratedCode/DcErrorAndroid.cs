using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis._DataLayer.GeneratedCode
{
    public class DcErrorAndroid
    {
        public List<string> GetEmailListSend(int branchOfficeId, int alarmId)
        {
            using (var context = new Entity())
            {
                List<string> emails = new List<string>();

                List<string> emails1 = (from user in context.AmisUser
                                        join m in context.Member on user.MemberId equals m.MemberId
                                        join mb in context.MemberBranchOffice on m.MemberId equals mb.MemberId
                                        join b in context.BranchOffice on mb.BranchOfficeId equals b.BranchOfficeId
                                        where b.BranchOfficeId == branchOfficeId
                                        join ua in context.UserAlarm on user.AmisUserId equals ua.AmisUserId
                                        join a in context.Alarm on ua.AlarmId equals a.AlarmId
                                        where a.AlarmId == alarmId
                                        join type in context.UserAlarmType on ua.UserAlarmTypeId equals type.UserAlarmTypeId
                                        where type.UserAlarmTypeId == 1
                                        select user.Email).ToList();

                List<string> emails2 = (from user in context.AmisUser
                                        join m in context.Member on user.MemberId equals m.MemberId
                                        join mb in context.MemberBranchOffice on m.MemberId equals mb.MemberId
                                        join b in context.BranchOffice on mb.BranchOfficeId equals b.BranchOfficeId
                                        join ua in context.UserAlarm on user.AmisUserId equals ua.AmisUserId
                                        join a in context.Alarm on ua.AlarmId equals a.AlarmId
                                        where a.AlarmId == alarmId
                                        join type in context.UserAlarmType on ua.UserAlarmTypeId equals type.UserAlarmTypeId
                                        where type.UserAlarmTypeId == 2
                                        select user.Email).ToList();

                
                if (ListEmail1(emails1, emails2, out emails)) { return emails; }
                if (ListEmail2(emails1, emails2, out emails)) { return emails; }
                if (ListEmail2(emails1, emails2, out emails)) { return emails; }

                return emails;
            }
        }

        public bool ListEmail1(List<string> list1, List<string> list2, out List<string> emails)
        {
            emails = new List<string>();

            if (list1.Count == 0 && list2.Count != 0)
            {
                emails = list2;
                return true;
            }

            if (list1.Count == 0 && list2.Count == 0)
            {
                emails = list2;
                return true;
            }

            return false;
        }

        public bool ListEmail2(List<string> list1, List<string> list2, out List<string> emails)
        {
            emails = new List<string>();

            if (list1.Count > 1)
            {
                if (list2.Count != 0)
                {

                    foreach (string item in list1)
                    {
                        foreach (string item2 in list2)
                        {
                            if (item != item2)
                            {
                                emails.Add(item2);
                                break;
                            }
                        }
                    }
                }
                return true;
            }
            if (list1.Count == 1)
            {
                emails.Add(list1[0]);
                if (list2 != null)
                {


                    foreach (string item2 in list2)
                    {
                        if (list1[0] != item2)
                        {
                            emails.Add(item2);

                        }
                    }

                }
                return true;
            }

            return false;
        }

        public bool ListEmail3(List<string> list1, List<string> list2, out List<string> emails)
        {
            emails = new List<string>();

            if (list2.Count > 1)
            {
                if (list1 != null)
                {

                    foreach (string item in list2)
                    {
                        foreach (string item3 in list1)
                        {
                            if (item != item3)
                            {
                                emails.Add(item3);
                                break;
                            }
                        }
                    }
                }
                return true;
            }
            if (list2.Count == 1)
            {
                emails.Add(list2[0]);
                if (list1 != null)
                {


                    foreach (string item3 in list1)
                    {
                        if (list1[0] != item3)
                        {
                            emails.Add(item3);

                        }
                    }

                }
                return true;
            }

            return false;
        }
    }
}