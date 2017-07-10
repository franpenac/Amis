using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using amis._Common;
using amis._DataLayer;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infragistics.Web.UI;
using Infragistics.Web.UI.EditorControls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using amis._DataLayer.GeneratedCode;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcAmisUserTask: ITsDropDownList
    {
        public void Copy(AmisUserTask objSource, ref AmisUserTask objDestination)
        {
            new DcAmisUserTask().Copy(objSource, ref objDestination);
        }

        public AmisUserTask Save(AmisUserTask objSource, out string errorMessage)
        {
            AmisUserTask obj = new DcAmisUserTask().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La tarea del usuario fue guardada correctamente.";

            else
                errorMessage = "No fue posible guardar la tarea del usuario, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool ExistsAmisUserTask(int amisUserTaskId, out string errorMessage)
        {
            bool exist = new DcAmisUserTask().ExistsAmisUserTask(amisUserTaskId, out errorMessage);
            return exist;
        }

        public List<AmisUserTask> GetAmisUserTaskList(out string errorMessage)
        {
            List<AmisUserTask> list = new DcAmisUserTask().GetAmisUserTaskList(out errorMessage);
            return list;
        }

        public bool ChangeAmisUserTaskDone(int amisUserTaskId, string done, out string errorMessage)
        {
            return new DcAmisUserTask().ChangeAmisUserTaskDone(amisUserTaskId, done, out errorMessage);
        }

        public bool SaveAmisUserTaskActionTaken(int amisUserTaskId, string amisUserTaskActionTaken, out string errorMessage)
        {
            return new DcAmisUserTask().SaveAmisUserTaskActionTaken(amisUserTaskId, amisUserTaskActionTaken, out errorMessage);
        }

        public bool InvertAmisUserTaskDone(int amisUserTaskId, out string errorMessage)
        {
            return new DcAmisUserTask().InvertAmisUserTaskDone(amisUserTaskId, out errorMessage);
        }

        public AmisUserTask GetAmisUserTaskById(int id, out string errorMessage)
        {
            errorMessage = "";
            return new DcAmisUserTask().GetAmisUserTaskById(id, out errorMessage);
        }
        
        // Implementacion de las interfaces

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcAmisUserTask().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(CommonEnums.AmisUserTaskDoneState amisUserTaskDone, out string errorMessage)
        {
            IEnumerable<object> list = new DcAmisUserTask().GetTableList2(amisUserTaskDone, out errorMessage);
            return list;
        }

        public List<AmisUserTaskRow> GetFilterTableList(int amisTaskTypeId, CommonEnums.AmisUserTaskDoneState doneState, string nameContains, DateTime? amisUserTaskStartDate, DateTime? amisUserTaskFinishDate, int amisUserId, out string errorMessage)
        {
            List<AmisUserTaskRow> list = new DcAmisUserTask().GetFilterTableList(amisTaskTypeId, doneState, nameContains, amisUserTaskStartDate, amisUserTaskFinishDate, amisUserId, out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<TsDropDownItem> GetDoneList()
        {
            List<TsDropDownItem> list = new List<TsDropDownItem>();
            list.Add(new TsDropDownItem() { ComboId = "0", ComboName = "Todos" });
            list.Add(new TsDropDownItem() { ComboId = "1", ComboName = "Realizados" });
            list.Add(new TsDropDownItem() { ComboId = "2", ComboName = "No realizados" });
            return list;
        }
    }
}