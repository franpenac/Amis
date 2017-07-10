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
    public partial class DcAssignment
    {
        public void Copy(Assignment objSource, ref Assignment objDestination)
        {
            objDestination.AssignmentId = objSource.AssignmentId;
            objDestination.OperationId = objSource.OperationId;
            objDestination.AssignmentDate = objSource.AssignmentDate;
            objDestination.EndAssignmentDate = objSource.EndAssignmentDate;
            objDestination.UnitId = objSource.UnitId;

        }

        public Assignment Save(Assignment objSource,out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        Assignment row = context.Assignment.Where(r => r.AssignmentId == objSource.AssignmentId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Assignment();
                            Copy(objSource, ref row);
                            context.Assignment.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha añadido la asignacion a operaciones con el id:" + row.AssignmentId;
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

        public bool ExistsAssignment(int AssignmentId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Assignment obj = null;
                using (var context = new Entity())
                {
                    obj = context.Assignment.Where(r => r.AssignmentId != AssignmentId).FirstOrDefault();
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

        public Assignment GetAssignmentById(int AssignmentId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Assignment obj = null;
                using (var context = new Entity())
                {
                    obj = context.Assignment.Where(r => r.AssignmentId == AssignmentId).FirstOrDefault();
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

        public List<Assignment> GetAssignmentList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Assignment> list = context.Assignment.ToList();
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
                        (from Assignment in context.Assignment
                         join operation in context.Operation on Assignment.OperationId equals operation.OperationId
                         join unit in context.Unit on Assignment.UnitId equals unit.UnitId
                         //where Assignment.EndAssignmentDate!=null
                         select new
                         {
                             AssignmentId = Assignment.AssignmentId,
                             AssignmentDate = Assignment.AssignmentDate,
                             EndAssignmentDate = Assignment.EndAssignmentDate.ToString().Substring(3, 3) + Assignment.EndAssignmentDate.ToString().Substring(0, 2) + Assignment.EndAssignmentDate.ToString().Substring(6, 4),
                             OperationId = Assignment.OperationId,
                             OperationName = Assignment.Operation.OperationName,
                             PatentNumber = Assignment.Unit.UnitRegister.PatentNumber,
                             UnitId = Assignment.UnitId
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

        public CommonEnums.DeletedRecordStates DeleteAssignment(int IAssignmentId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Assignment obj = context.Assignment.Where(r => r.AssignmentId == IAssignmentId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Assignment.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la asignacion a operaciones con el id:" + obj.AssignmentId;
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

        public bool HasOperation(int OperationId, ref Assignment first)
        {
            using (var context = new Entity())
            {
                first = context.Assignment.Where(r => r.OperationId != OperationId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool HasUnit(int UnitId, ref Assignment first)
        {
            using (var context = new Entity())
            {
                first = context.Assignment.Where(r => r.UnitId!= UnitId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }

        public Operation GetOperationByUnitRegisterId(int unitRegisterId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    Operation operation = (from o in context.Operation
                                           join a in context.Assignment on o.OperationId equals a.OperationId
                                           join u in context.Unit on a.UnitId equals u.UnitId
                                           where u.UnitRegisterId == unitRegisterId && a.EndAssignmentDate == null
                                           select o).FirstOrDefault();
                    if (operation == null)
                    {
                        errorMessage = "";
                        return operation;
                    }
                    else
                    {
                        errorMessage = "La unidad esta actualmente asignada a la operación: " + operation.OperationName;
                        return operation;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public Assignment GetAssignmentByUnitId(int unitId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    Assignment obj = (from assignment in context.Assignment where assignment.UnitId == unitId select assignment).First();
                    if (obj != null)
                    {
                        return obj;
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
    }
}