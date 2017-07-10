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
    public partial class DcSuspensionType
    {
        public void Copy(SuspensionType objSource, ref SuspensionType objDestination)
        {
            objDestination.SuspensionTypeId = objSource.SuspensionTypeId;
            objDestination.SuspensionTypeName = objSource.SuspensionTypeName;
        }
        
        public SuspensionType Save(SuspensionType objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        SuspensionType service = context.SuspensionType.Where(r => r.SuspensionTypeName.ToUpper() == objSource.SuspensionTypeName.ToUpper() && r.SuspensionTypeId != objSource.SuspensionTypeId).FirstOrDefault();
                        if (service != null) return (SuspensionType)ErrorController.SetErrorMessage("Repeated SuspensionType name", out errorMessage);

                        SuspensionType row = context.SuspensionType.Where(r => r.SuspensionTypeId == objSource.SuspensionTypeId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new SuspensionType();
                            Copy(objSource, ref row);
                            context.SuspensionType.Add(row);
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

        public bool ExistsSuspensionType(int SuspensionTypeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                SuspensionType obj = null;
                using (var context = new Entity())
                {
                    obj = context.SuspensionType.Where(r => r.SuspensionTypeId != SuspensionTypeId).FirstOrDefault();
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

        public List<SuspensionType> GetSuspensionTypeList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<SuspensionType> list = context.SuspensionType.OrderBy(a => a.SuspensionTypeName).ToList();
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
                        (from obj in context.SuspensionType
                         select new TsDropDownItem()
                         {
                             ComboId = obj.SuspensionTypeId.ToString(),
                             ComboName = obj.SuspensionTypeName
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
                        (from SuspensionType in context.SuspensionType
                         select new
                         {
                             SuspensionTypeId = SuspensionType.SuspensionTypeId,
                             SuspensionTypeName = SuspensionType.SuspensionTypeName

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

        public CommonEnums.DeletedRecordStates DeleteSuspensionType(int ISuspensionTypeId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    SuspensionType obj = context.SuspensionType.Where(r => r.SuspensionTypeId == ISuspensionTypeId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.SuspensionType.Remove(obj);
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
