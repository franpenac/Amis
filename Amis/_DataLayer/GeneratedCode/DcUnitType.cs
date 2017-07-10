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
    public partial class DcUnitType
    {
        public void Copy(UnitType objSource, ref UnitType objDestination)
        {
            objDestination.UnitTypeId = objSource.UnitTypeId;
            objDestination.UnitTypeName = objSource.UnitTypeName;
        }
        
        public UnitType Save(UnitType objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        UnitType service = context.UnitType.Where(r => r.UnitTypeName.ToUpper() == objSource.UnitTypeName.ToUpper() && r.UnitTypeId != objSource.UnitTypeId).FirstOrDefault();
                        if (service != null) return (UnitType)ErrorController.SetErrorMessage("Repeated UnitType name", out errorMessage);

                        UnitType row = context.UnitType.Where(r => r.UnitTypeId == objSource.UnitTypeId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new UnitType();
                            Copy(objSource, ref row);
                            context.UnitType.Add(row);
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

        public bool ExistsUnitType(int UnitTypeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                UnitType obj = null;
                using (var context = new Entity())
                {
                    obj = context.UnitType.Where(r => r.UnitTypeId != UnitTypeId).FirstOrDefault();
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

        public List<UnitType> GetUnitTypeList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<UnitType> list = context.UnitType.OrderBy(a => a.UnitTypeName).ToList();
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
                        (from obj in context.UnitType
                         select new TsDropDownItem()
                         {
                             ComboId = obj.UnitTypeId.ToString(),
                             ComboName = obj.UnitTypeName
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
                        (from UnitType in context.UnitType
                         select new
                         {
                             UnitTypeId = UnitType.UnitTypeId,
                             UnitTypeName = UnitType.UnitTypeName

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

        public CommonEnums.DeletedRecordStates DeleteUnitType(int IUnitTypeId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    UnitType obj = context.UnitType.Where(r => r.UnitTypeId == IUnitTypeId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.UnitType.Remove(obj);
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
