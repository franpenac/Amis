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
    public partial class DcGlobalCostDetail
    {
        public void Copy(GlobalCostDetail objSource, ref GlobalCostDetail objDestination)
        {
            objDestination.GlobalCostDetailId = objSource.GlobalCostDetailId;
            objDestination.GlobalCostDetailId = objSource.GlobalCostDetailId;
            objDestination.GlobalCostId = objSource.GlobalCostId;
            objDestination.Month = objSource.Month;
            objDestination.Cost = objSource.Cost;
        }

        public GlobalCostDetail Save(GlobalCostDetail objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        bool ok = new DcGlobalCost().ExistsGlobalCost(objSource.GlobalCostId, out errorMessage);
                        if (!ok) return (GlobalCostDetail)ErrorController.SetErrorMessage("GlobalCost not found", out errorMessage);

                        if (objSource.Cost <= 0) return (GlobalCostDetail)ErrorController.SetErrorMessage("Cost not valid", out errorMessage);

                        GlobalCostDetail row = context.GlobalCostDetail.Where(r => r.GlobalCostDetailId == objSource.GlobalCostDetailId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new GlobalCostDetail();
                            Copy(objSource, ref row);
                            context.GlobalCostDetail.Add(row);
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

        public bool ExistsGlobalCostDetail(int GlobalCostDetailId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                GlobalCostDetail obj = null;
                using (var context = new Entity())
                {
                    obj = context.GlobalCostDetail.Where(r => r.GlobalCostDetailId != GlobalCostDetailId).FirstOrDefault();
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

        public List<GlobalCostDetail> GetGlobalCostDetailList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<GlobalCostDetail> list = context.GlobalCostDetail.ToList();
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
                        (from GlobalCostDetail in context.GlobalCostDetail
                         join globalCost in context.GlobalCost on GlobalCostDetail.GlobalCostId equals globalCost.GlobalCostId
                         select new
                         {
                             GlobalCostDetailId = GlobalCostDetail.GlobalCostDetailId,
                             GlobalCostId = GlobalCostDetail.GlobalCostId,
                             GlobalCostName = GlobalCostDetail.GlobalCost.GlobalCostName,
                             Cost = GlobalCostDetail.Cost,
                             Month = GlobalCostDetail.Month

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

        public CommonEnums.DeletedRecordStates DeleteGlobalCostDetail(int IGlobalCostDetailId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    GlobalCostDetail obj = context.GlobalCostDetail.Where(r => r.GlobalCostDetailId == IGlobalCostDetailId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.GlobalCostDetail.Remove(obj);
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

        public List<int> GetYearDetail()
        {
            using (var context = new Entity())
            {
                List<int> years = (from date in context.GlobalCostDetail select date.Month.Year).Distinct().ToList();

                return years;
            }
        }

    }
}