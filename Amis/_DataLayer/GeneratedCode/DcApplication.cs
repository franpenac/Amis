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
    public partial class DcApplication
    {
        public void Copy(Application objSource, ref Application objDestination)
        {
            objDestination.ApplicationId = objSource.ApplicationId;
            objDestination.ApplicationName = objSource.ApplicationName;
            
        }

        public Application Save(Application objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        Application service = context.Application.Where(r => r.ApplicationName.ToUpper() == objSource.ApplicationName.ToUpper() && r.ApplicationId != objSource.ApplicationId).FirstOrDefault();
                        if (service != null) return (Application)ErrorController.SetErrorMessage("Repeated application name", out errorMessage);

                        Application row = context.Application.Where(r => r.ApplicationId == objSource.ApplicationId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Application();
                            Copy(objSource, ref row);
                            context.Application.Add(row);
                        }
                        else
                        {
                            Copy(objSource, ref row);
                        }
                        context.SaveChanges();
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

        public bool ExistsApplication(int ApplicationId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Application obj = null;
                using (var context = new Entity())
                {
                    obj = context.Application.Where(r => r.ApplicationId != ApplicationId).FirstOrDefault();
                    if (obj == null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }

        public List<Application> GetApplicationList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Application> list = context.Application.OrderBy(a => a.ApplicationName).ToList();
                    return list;
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
                        (from obj in context.Application
                         select new TsDropDownItem()
                         {
                             ComboId = obj.ApplicationId.ToString(),
                             ComboName = obj.ApplicationName
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

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    IEnumerable<object> list =
                        (from Application in context.Application
                         select new
                         {
                             ApplicationId = Application.ApplicationId,
                             ApplicationName = Application.ApplicationName

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

        public CommonEnums.DeletedRecordStates DeleteApplication(int IApplicationId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Application obj = context.Application.Where(r => r.ApplicationId == IApplicationId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Application.Remove(obj);
                    context.SaveChanges();
                    return CommonEnums.DeletedRecordStates.DeletedOk;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return CommonEnums.DeletedRecordStates.NotDeleted;
            }
        }

    }
}