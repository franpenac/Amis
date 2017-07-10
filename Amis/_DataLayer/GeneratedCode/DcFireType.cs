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
    public partial class DcFireType
    {
        public void Copy(FireType objSource, ref FireType objDestination)
        {
            objDestination.FireTypeId = objSource.FireTypeId;
            objDestination.FireTypeName = objSource.FireTypeName;
        }

        public FireType Save(FireType objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        FireType service = context.FireType.Where(r => r.FireTypeName.ToUpper() == objSource.FireTypeName.ToUpper() && r.FireTypeId != objSource.FireTypeId).FirstOrDefault();
                        if (service != null) return (FireType)ErrorController.SetErrorMessage("Repeated fire name", out errorMessage);

                        FireType row = context.FireType.Where(r => r.FireTypeId == objSource.FireTypeId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new FireType();
                            Copy(objSource, ref row);
                            context.FireType.Add(row);
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

        public bool ExistsFireType(int FireTypeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                FireType obj = null;
                using (var context = new Entity())
                {
                    obj = context.FireType.Where(r => r.FireTypeId != FireTypeId).FirstOrDefault();
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

        public List<FireType> GetFireTypeList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<FireType> list = context.FireType.OrderBy(a => a.FireTypeName).ToList();
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
                        (from obj in context.FireType
                         select new TsDropDownItem()
                         {
                             ComboId = obj.FireTypeId.ToString(),
                             ComboName = obj.FireTypeName
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
                        (from FireType in context.FireType
                         select new
                         {
                             FireTypeId = FireType.FireTypeId,
                             FireTypeName = FireType.FireTypeName

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

        public CommonEnums.DeletedRecordStates DeleteFireType(int IFireTypeId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    FireType obj = context.FireType.Where(r => r.FireTypeId == IFireTypeId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.FireType.Remove(obj);
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