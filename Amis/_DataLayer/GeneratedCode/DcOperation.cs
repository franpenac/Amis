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
    public partial class DcOperation
    {
        public void Copy(Operation objSource, ref Operation objDestination)
        {
            objDestination.OperationId = objSource.OperationId;
            objDestination.OperationName = objSource.OperationName;
            objDestination.MemberId = objSource.MemberId;
            objDestination.BranchOfficeId = objSource.BranchOfficeId;

        }

        public Operation Save(Operation objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        Operation service = context.Operation.Where(r => r.OperationName.ToUpper() == objSource.OperationName.ToUpper() && r.OperationId != objSource.OperationId).FirstOrDefault();
                        if (service != null) return (Operation)ErrorController.SetErrorMessage("Repeated operation name", out errorMessage);
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        Operation row = context.Operation.Where(r => r.OperationId == objSource.OperationId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Operation();
                            Copy(objSource, ref row);
                            context.Operation.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha añadido la operacion:" + row.OperationName + ", con el id:" + row.OperationId;
                        new DcPageLog().Save(action, description);
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

        public bool ExistsOperation(int OperationId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Operation obj = null;
                using (var context = new Entity())
                {
                    obj = context.Operation.Where(r => r.OperationId == OperationId).FirstOrDefault();
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

        public Operation GetOperationById(int OperationId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Operation obj = null;
                using (var context = new Entity())
                {
                    obj = context.Operation.Where(r => r.OperationId == OperationId).FirstOrDefault();
                    if (obj == null)
                    {
                        return null;
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<Operation> GetOperationList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Operation> list = context.Operation.OrderBy(a => a.OperationName).ToList();
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
                        (from obj in context.Operation
                         select new TsDropDownItem()
                         {
                             ComboId = obj.OperationId.ToString(),
                             ComboName = obj.OperationName
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
                        (from Operation in context.Operation
                         join m in context.Member on Operation.MemberId equals m.MemberId
                         join bc in context.BranchOffice on Operation.BranchOfficeId equals bc.BranchOfficeId
                         select new
                         {
                             OperationId = Operation.OperationId,
                             OperationName = Operation.OperationName,
                             BranchOfficeId = Operation.BranchOfficeId,
                             BranchOfficeName = Operation.BranchOffice.BranchOfficeName,
                             MemberId = Operation.MemberId,
                             MemberName = Operation.Member.MemberName

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

        public CommonEnums.DeletedRecordStates DeleteOperation(int IOperationId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Operation obj = context.Operation.Where(r => r.OperationId == IOperationId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Operation.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la operacion:" + obj.OperationName + ", con el id:" + obj.OperationId;
                    new DcPageLog().Save(CommonEnums.PageActionEnum.Delete, description);
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