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
    public partial class DcMeasurementUnit
    {
        public void Copy(MeasurementUnit objSource, ref MeasurementUnit objDestination)
        {
            objDestination.MeasurementUnitId = objSource.MeasurementUnitId;
            objDestination.MeasurementUnitName = objSource.MeasurementUnitName;
        }
        
        public MeasurementUnit Save(MeasurementUnit objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        MeasurementUnit service = context.MeasurementUnit.Where(r => r.MeasurementUnitName.ToUpper() == objSource.MeasurementUnitName.ToUpper() && r.MeasurementUnitId != objSource.MeasurementUnitId).FirstOrDefault();
                        if (service != null) return (MeasurementUnit)ErrorController.SetErrorMessage("Repeated measurementUnit name", out errorMessage);

                        MeasurementUnit row = context.MeasurementUnit.Where(r => r.MeasurementUnitId == objSource.MeasurementUnitId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new MeasurementUnit();
                            Copy(objSource, ref row);
                            context.MeasurementUnit.Add(row);
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

        public bool ExistsMeasurementUnit(int MeasurementUnitId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                MeasurementUnit obj = null;
                using (var context = new Entity())
                {
                    obj = context.MeasurementUnit.Where(r => r.MeasurementUnitId != MeasurementUnitId).FirstOrDefault();
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

        public List<MeasurementUnit> GetMeasurementUnitList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<MeasurementUnit> list = context.MeasurementUnit.OrderBy(a => a.MeasurementUnitName).ToList();
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
                        (from obj in context.MeasurementUnit
                         select new TsDropDownItem()
                         {
                             ComboId = obj.MeasurementUnitId.ToString(),
                             ComboName = obj.MeasurementUnitName
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
                        (from MeasurementUnit in context.MeasurementUnit
                         select new
                         {
                             MeasurementUnitId = MeasurementUnit.MeasurementUnitId,
                             MeasurementUnitName = MeasurementUnit.MeasurementUnitName

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

        public CommonEnums.DeletedRecordStates DeleteMeasurementUnit(int IMeasurementUnitId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    MeasurementUnit obj = context.MeasurementUnit.Where(r => r.MeasurementUnitId == IMeasurementUnitId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.MeasurementUnit.Remove(obj);
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