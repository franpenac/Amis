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
    public partial class DcUnit
    {

        public bool ExistsUnit(int UnitId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Unit obj = null;
                using (var context = new Entity())
                {
                    obj = context.Unit.Where(r => r.UnitId != UnitId).FirstOrDefault();
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

        public List<Unit> GetUnitList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Unit> list = context.Unit.ToList();
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
                        (from obj in context.Unit
                         select new TsDropDownItem()
                         {
                             ComboId = obj.UnitId.ToString(),
                             ComboName = ""
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

        public CommonEnums.DeletedRecordStates DeleteUnit(int IUnitId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Unit obj = context.Unit.Where(r => r.UnitId == IUnitId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Unit.Remove(obj);
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

        public bool HasAsset(int AssetId, ref Unit first)
        {
            using (var context = new Entity())
            {
                first = context.Unit.Where(r => r.AssetId != AssetId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }

        public Unit GetUnitByUnitRegisterId(int unitRegisterId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    Unit obj = (from unit in context.Unit where unit.UnitRegisterId == unitRegisterId select unit).FirstOrDefault();
                    return obj;
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