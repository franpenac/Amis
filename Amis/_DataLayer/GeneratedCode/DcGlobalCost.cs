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
    public partial class DcGlobalCost
    {
        public void Copy(GlobalCost objSource, ref GlobalCost objDestination)
        {
            objDestination.GlobalCostId = objSource.GlobalCostId;
            objDestination.GlobalCostName = objSource.GlobalCostName;
        }

        public GlobalCost Save(GlobalCost objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        GlobalCost service = context.GlobalCost.Where(r => r.GlobalCostName.ToUpper() == objSource.GlobalCostName.ToUpper() && r.GlobalCostId != objSource.GlobalCostId).FirstOrDefault();
                        if (service != null) return (GlobalCost)ErrorController.SetErrorMessage("Repeated globalCost name", out errorMessage);

                        GlobalCost row = context.GlobalCost.Where(r => r.GlobalCostId == objSource.GlobalCostId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new GlobalCost();
                            Copy(objSource, ref row);
                            context.GlobalCost.Add(row);
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

        public bool ExistsGlobalCost(int GlobalCostId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                GlobalCost obj = null;
                using (var context = new Entity())
                {
                    obj = context.GlobalCost.Where(r => r.GlobalCostId != GlobalCostId).FirstOrDefault();
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

        public List<GlobalCost> GetGlobalCostList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<GlobalCost> list = context.GlobalCost.OrderBy(a => a.GlobalCostName).ToList();
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
                        (from obj in context.GlobalCost
                         select new TsDropDownItem()
                         {
                             ComboId = obj.GlobalCostId.ToString(),
                             ComboName = obj.GlobalCostName
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

        public List<TsDropDownItem> GetComboListFilter(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.GlobalCost
                         where obj.GlobalCostId != 1 && obj.GlobalCostId != 2
                         select new TsDropDownItem()
                         {
                             ComboId = obj.GlobalCostId.ToString(),
                             ComboName = obj.GlobalCostName
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

        public bool ExistCostDate(DateTime date, int id, out string errorMessage)
        {
            using (var context = new Entity())
            {
                GlobalCostDetail obj = (from g in context.GlobalCostDetail where id == g.GlobalCostId && date.Month == g.Month.Month && date.Year == g.Month.Year select g).FirstOrDefault();

                if (obj == null)
                {
                    errorMessage = "";
                    return true;
                }

                errorMessage = "Ya existe un registro de costo en la fecha digitada, por favor digite otra fecha.";
                return false;
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
                        (from GlobalCost in context.GlobalCost
                         select new
                         {
                             GlobalCostId = GlobalCost.GlobalCostId,
                             GlobalCostName = GlobalCost.GlobalCostName

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

        public CommonEnums.DeletedRecordStates DeleteGlobalCost(int IGlobalCostId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    GlobalCost obj = context.GlobalCost.Where(r => r.GlobalCostId == IGlobalCostId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.GlobalCost.Remove(obj);
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