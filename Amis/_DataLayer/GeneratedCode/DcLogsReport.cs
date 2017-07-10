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
    public class DcLogsReport
    {
        public List<LogsObject> GetListLogsReport(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<LogsObject> list = (from pageLog in context.PageLog
                                             join amisUser in context.AmisUser 
                                             on pageLog.AmisUserId equals amisUser.AmisUserId
                                             join menuOption in context.MenuOption
                                             on pageLog.MenuOptionId equals menuOption.MenuOptionId
                                             join pageAction in context.PageAction
                                             on pageLog.PageActionId equals pageAction.PageActionId
                                             select new LogsObject
                                             {

                                                 UserEmail = amisUser.Email,
                                                 UserName = amisUser.Name,
                                                 UserId = amisUser.AmisUserId,
                                                 MenuOption = menuOption.Name,
                                                 MenuOptionId = menuOption.MenuOptionId,
                                                 Action = pageLog.Description,
                                                 ActionId = pageAction.PageActionId,
                                                 ActionDate = pageLog.ActionDateTime
                                                 

                                             }).ToList();
                    if (list!= null)
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

        public List<LogsObject> LogsReportFiltered(int userId, int menuOptionId, int actionId,DateTime initDate, DateTime endDate, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                List<LogsObject> list = GetListLogsReport(out errorMessage);
                if (userId == 0 && menuOptionId == 0 && actionId == 0 && initDate == new DateTime() && endDate == new DateTime())
                {
                    return list;
                }
                if (userId != 0)
                {
                    list = list.Where(r => r.UserId == userId).ToList();
                }
                if (menuOptionId != 0)
                {
                    list = list.Where(r => r.MenuOptionId == menuOptionId).ToList();
                }
                if (actionId != 0)
                {
                    list = list.Where(r => r.ActionId == actionId).ToList();
                }
                if (initDate != new DateTime() && endDate != new DateTime())
                {
                    list = list.Where(r => r.ActionDate >= initDate && r.ActionDate <= endDate).ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }

        }

        public List<TsDropDownItem> GetComboActionList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.PageAction where obj.PageActionId < 12
                         select new TsDropDownItem()
                         {
                             ComboId = obj.PageActionId.ToString(),
                             ComboName = obj.PageActionDescription
                         }).OrderBy(r => r.ComboName).ToList();
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