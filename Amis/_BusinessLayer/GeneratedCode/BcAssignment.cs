using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class BcAssignment : ITsDropDownList
    {
        public void Copy(Assignment objSource, ref Assignment objDestination)
        {
            new DcAssignment().Copy(objSource, ref objDestination);
        }

        public Assignment Save(Assignment objSource, out string errorMessage)
        {
            Assignment obj = new DcAssignment().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La asignacion fue guardado correctamente.";
            
            else
                errorMessage = "No fue posible guardar la asignacion, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }
        
        public bool ExistsAssignment(int AssignmentId, out string errorMessage)
        {
            bool exist = new DcAssignment().ExistsAssignment(AssignmentId, out errorMessage);
            return exist;
        }

        public List<Assignment> GetAssignmentList(out string errorMessage)
        {
            List<Assignment> list = new DcAssignment().GetAssignmentList(out errorMessage);
            return list;
        }

        public Assignment GetAssignmentById(int AssignmentId, out string errorMessage)
        {
            return new DcAssignment().GetAssignmentById(AssignmentId, out errorMessage);
            
        }

        public CommonEnums.DeletedRecordStates DeleteAssignment(int AssignmentId, out string errorMessage)
        {
           AssetEvent obj = new AssetEvent();
			if(! new DcAssetEvent().HasAssignment(AssignmentId, ref obj))
			{
				CommonEnums.DeletedRecordStates wasDeleted = new DcAssignment().DeleteAssignment(AssignmentId, out errorMessage);
				if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
				{
					errorMessage = "La asignacion fue eliminado correctamente.";
					return CommonEnums.DeletedRecordStates.DeletedOk;
				}
				else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
				{
					errorMessage = "No se encontró la asignacion, por lo cual no pudo ser eliminado.";
					return CommonEnums.DeletedRecordStates.NotFound;
				}
			}
			else
			{
				errorMessage = "La asignacion no pudo ser eliminado, debido a que tiene eventos asociados a ella.";
				return CommonEnums.DeletedRecordStates.NotDeleted;
			}
		   
            errorMessage = "La asignacion no pudo ser eliminado. Comuníquese con el Administrador del Sistema. "
                + "El Servidor entregó el siguiente mensaje: " + errorMessage;
            return CommonEnums.DeletedRecordStates.NotDeleted;
        }

        public void ExportWebDataGridToExcel(WebExcelExporter webExcelExporter, WebDataGrid webDataGrid)
        {
            webExcelExporter.DataExportMode = Infragistics.Web.UI.GridControls.DataExportMode.AllDataInDataSource;
            webExcelExporter.DownloadName = "amis_exported_file.xlsx";
            webExcelExporter.Export(webDataGrid);
        }

        // Implementacion de las interfaces

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcAssignment().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcAssignment().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public Operation GetOperationByUnitRegisterId(int unitRegisterId, out string errorMessage)
        {
            return new  DcAssignment().GetOperationByUnitRegisterId(unitRegisterId, out errorMessage);
        }

        public Assignment GetAssignmentByUnitId(int unitId, out string errorMessage)
        {
            return new DcAssignment().GetAssignmentByUnitId(unitId, out errorMessage);
        }
    }

}