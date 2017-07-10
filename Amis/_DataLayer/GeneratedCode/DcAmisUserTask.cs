using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using amis._Common;
using amis.Models;

namespace amis._DataLayer.GeneratedCode
{
    public partial class DcAmisUserTask
    {
        public void Copy(AmisUserTask objSource, ref AmisUserTask objDestination)
        {
            objDestination.AmisUserTaskId = objSource.AmisUserTaskId;
            objDestination.AmisTaskId = objSource.AmisTaskId;
            objDestination.AmisUserTaskName = objSource.AmisUserTaskName;
            objDestination.AmisUserTaskDescription = objSource.AmisUserTaskDescription;
            objDestination.AmisUserTaskActionTaken = objSource.AmisUserTaskActionTaken;
            objDestination.AmisUserTaskDone = objSource.AmisUserTaskDone;
            objDestination.AmisUserTaskStartDate = objSource.AmisUserTaskStartDate;
            objDestination.AmisUserTaskFinishDate = objSource.AmisUserTaskFinishDate;
            objDestination.AmisUserId = objSource.AmisUserId;
        }

        public AmisUserTask Save(AmisUserTask objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        AmisUserTask row = context.AmisUserTask.Where(r => r.AmisUserTaskId == objSource.AmisUserTaskId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new AmisUserTask();
                            Copy(objSource, ref row);
                            context.AmisUserTask.Add(row);
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

        public bool ExistsAmisUserTask(int amisUserTaskId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                AmisUserTask obj = null;
                using (var context = new Entity())
                {
                    obj = context.AmisUserTask.Where(r => r.AmisUserTaskId != amisUserTaskId).FirstOrDefault();
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

        public List<AmisUserTask> GetAmisUserTaskList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<AmisUserTask> list = context.AmisUserTask.ToList();
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
                        (from ut in context.AmisUserTask
                         join au in context.AmisUser on ut.AmisUserId equals au.AmisUserId
                         join at in context.AmisTask on ut.AmisTaskId equals at.AmisTaskId
                         join tt in context.AmisTaskType on at.AmisTaskTypeId equals tt.AmisTaskTypeId
                         select new
                         {
                             AmisTaskTypeId = tt.AmisTaskTypeId,
                             AmisTaskTypeName = tt.AmisTaskTypeName,
                             AmisTaskTypeDescription = tt.AmisTaskTypeDescription,
                             AmisTaskTypeImage = tt.AmisTaskTypeImage,
                             AmisTaskId = at.AmisTaskId,
                             AmisTaskName = at.AmisTaskName,
                             AmisTaskDescription = at.AmisTaskDescription,
                             AmisUserTaskId = ut.AmisUserTaskId,
                             AmisUserTaskDescription = ut.AmisUserTaskDescription,
                             AmisUserTaskActionTaken = ut.AmisUserTaskActionTaken,
                             AmisUserTaskDone = ut.AmisUserTaskDone,
                             AmisUserTaskStartDate = ut.AmisUserTaskStartDate,
                             AmisUserTaskFinishDate = ut.AmisUserTaskFinishDate,
                             AmisUserId = ut.AmisUserId
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

        public bool ChangeAmisUserTaskDone(int amisUserTaskId, string done, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    AmisUserTask obj = context.AmisUserTask.Where(r => r.AmisUserTaskId == amisUserTaskId).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.AmisUserTaskDone = done;
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }

        public bool SaveAmisUserTaskActionTaken(int amisUserTaskId, string amisUserTaskActionTaken, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    AmisUserTask obj = context.AmisUserTask.Where(r => r.AmisUserTaskId == amisUserTaskId).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.AmisUserTaskActionTaken = amisUserTaskActionTaken;
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }

        public bool InvertAmisUserTaskDone(int amisUserTaskId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    AmisUserTask obj = context.AmisUserTask.Where(r => r.AmisUserTaskId == amisUserTaskId).FirstOrDefault();
                    if (obj != null)
                    {
                        string done = obj.AmisUserTaskDone;
                        done = done == "Y" ? "N" : "Y";
                        obj.AmisUserTaskDone = done;
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }

        public AmisUserTask GetAmisUserTaskById(int id, out string errorMessage)
        {
            try
            {
                errorMessage = "";
                using (var context = new Entity())
                {
                    AmisUserTask amisUserTask = (from a in context.AmisUserTask where(a.AmisUserTaskId == id) select a).FirstOrDefault();

                    if (amisUserTask != null)
                    {
                        return amisUserTask;
                    }
                    else
                    {
                        errorMessage = "No existe el activo buscado!";
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

        public IEnumerable<object> GetTableList2(CommonEnums.AmisUserTaskDoneState doneState, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                string sDoneState = "YN";
                if (doneState == CommonEnums.AmisUserTaskDoneState.Done) sDoneState = "Y";
                if (doneState == CommonEnums.AmisUserTaskDoneState.NotDone) sDoneState = "N";
                using (var context = new Entity())
                {
                    IEnumerable<object> list =
                        (from ut in context.AmisUserTask
                         join au in context.AmisUser on ut.AmisUserId equals au.AmisUserId
                         join at in context.AmisTask on ut.AmisTaskId equals at.AmisTaskId
                         join tt in context.AmisTaskType on at.AmisTaskTypeId equals tt.AmisTaskTypeId
                         where sDoneState.Contains(ut.AmisUserTaskDone)
                         select new
                         {
                             AmisTaskTypeId = tt.AmisTaskTypeId,
                             AmisTaskTypeName = tt.AmisTaskTypeName,
                             AmisTaskTypeDescription = tt.AmisTaskTypeDescription,
                             AmisTaskTypeImage = tt.AmisTaskTypeImage,
                             AmisTaskId = at.AmisTaskId,
                             AmisTaskName = at.AmisTaskName,
                             AmisTaskDescription = at.AmisTaskDescription,
                             AmisUserTaskId = ut.AmisUserTaskId,
                             AmisUserTaskDescription = ut.AmisUserTaskDescription,
                             AmisUserTaskActionTaken = ut.AmisUserTaskActionTaken,
                             AmisUserTaskDone = ut.AmisUserTaskDone,
                             AmisUserTaskStartDate = ut.AmisUserTaskStartDate,
                             AmisUserTaskFinishDate = ut.AmisUserTaskFinishDate,
                             AmisUserId = ut.AmisUserId
                         }).ToList().OrderByDescending(r => r.AmisUserTaskStartDate);
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<AmisUserTaskRow> GetFilterTableList(int amisTaskTypeId, CommonEnums.AmisUserTaskDoneState doneState, 
            string nameContains, DateTime? amisUserTaskStartDate, DateTime? amisUserTaskFinishDate, int amisUserId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<AmisUserTask> list2 = null;

                    if (amisUserId == -1)
                        list2 = context.AmisUserTask.ToList();
                    else
                        list2 = context.AmisUserTask.Where(r => r.AmisUserId == amisUserId).ToList();

                    if (doneState == CommonEnums.AmisUserTaskDoneState.Done) list2 = list2.Where(r => r.AmisUserTaskDone == "Y").ToList();
                    if (doneState == CommonEnums.AmisUserTaskDoneState.NotDone) list2 = list2.Where(r => r.AmisUserTaskDone == "N").ToList();

                    if (amisUserTaskStartDate != null)
                        list2 = list2.Where(r => r.AmisUserTaskStartDate >= amisUserTaskStartDate).ToList();

                    if (amisUserTaskFinishDate != null)
                        list2 = list2.Where(r => r.AmisUserTaskStartDate <= amisUserTaskFinishDate).ToList();

                    List<AmisUserTaskRow> list3 = (
                        from ut in list2
                        join at in context.AmisTask on ut.AmisTaskId equals at.AmisTaskId
                        join tt in context.AmisTaskType on at.AmisTaskTypeId equals tt.AmisTaskTypeId
                        select new AmisUserTaskRow()
                        {
                            AmisUserTaskId = ut.AmisUserTaskId,
                            AmisTaskTypeId = tt.AmisTaskTypeId,
                            AmisTaskTypeImage = tt.AmisTaskTypeImage,
                            AmisTaskId = at.AmisTaskId,
                            AmisTaskName = at.AmisTaskName,
                            AmisUserTaskDescription = ut.AmisUserTaskDescription,
                            AmisUserTaskActionTaken = ut.AmisUserTaskActionTaken,
                            AmisUserTaskDone = ut.AmisUserTaskDone,
                            AmisUserTaskStartDate = ut.AmisUserTaskStartDate,
                            AmisUserTaskFinishDate = ut.AmisUserTaskFinishDate
                        }).OrderByDescending(r => r.AmisUserTaskStartDate).ToList();

                    if (amisTaskTypeId != -1)
                    {
                        list3 = list3.Where(r => r.AmisTaskTypeId == amisTaskTypeId).ToList();
                    }

                    if (nameContains != "")
                    {
                        list3 = list3.Where(r => r.AmisTaskName.ToUpper().Contains(nameContains.ToUpper())).ToList();
                    }

                    return list3;
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