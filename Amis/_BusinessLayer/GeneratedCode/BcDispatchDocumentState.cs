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
    public class BcDispatchDocumentState : ITsDropDownList
    {
        public void Copy(DispatchProviderDocumentState objSource, ref DispatchProviderDocumentState objDestination)
        {
            new DcDispatchProviderDocumentState().Copy(objSource, ref objDestination);
        }

        public DispatchProviderDocumentState Save(DispatchProviderDocumentState objSource, out string errorMessage)
        {
            DispatchProviderDocumentState obj = new DcDispatchProviderDocumentState().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El estado '" + objSource.DispatchProviderDocumentStateName + "' fue guardado correctamente.";

            else if (errorMessage == "Repeated state name")
                errorMessage = "No fue posible guardar el estado'" + objSource.DispatchProviderDocumentStateName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el estado, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(DispatchProviderDocumentState DispatchDocumentState, out string errorMessage)
        {
            if (!ValidateDispatchProviderDocumenName(DispatchDocumentState.DispatchProviderDocumentStateName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsDispatchDocumentState(int DispatchDocumentStateId, out string errorMessage)
        {
            bool exist = new DcDispatchProviderDocumentState().ExistsDispatchProviderDocumentState(DispatchDocumentStateId, out errorMessage);
            return exist;
        }

        public List<DispatchProviderDocumentState> GetDispatchDocumentStateList(out string errorMessage)
        {
            List<DispatchProviderDocumentState> list = new DcDispatchProviderDocumentState().GetDispatchProviderDocumentStateList(out errorMessage);
            return list;
        }

        public bool ValidateDispatchDocumentStateId(int DispatchDocumentStateId, out string errorMessage)
        {
            errorMessage = "";
            if (DispatchDocumentStateId == 0)
            {
                errorMessage = "El campo 'Id de estado' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateDispatchProviderDocumenName(string DispatchProviderDocumenName, out string errorMessage)
        {
            errorMessage = "";
            if (DispatchProviderDocumenName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de estado' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteDispatchDocumentState(int DispatchDocumentStateId, string DispatchProviderDocumenName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcDispatchProviderDocumentState().DeleteDispatchProviderDocumentState(DispatchDocumentStateId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El estado fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el estado '" + DispatchProviderDocumenName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El estado '" + DispatchProviderDocumenName
                + " no pudo ser eliminado. Comuníquese con el Administrador del Sistema. "
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
            errorMessage = "";
            List<TsDropDownItem> list = new DcDispatchProviderDocumentState().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcDispatchProviderDocumentState().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcDispatchProviderDocumentState().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}