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
    public class BcCommune : ITsDropDownList
    {
        public void Copy(Commune objSource, ref Commune objDestination)
        {
            new DcCommune().Copy(objSource, ref objDestination);
        }

        public Commune Save(Commune objSource, out string errorMessage)
        {
            Commune obj = new DcCommune().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La comuna '" + objSource.CommuneName + "' fue guardada correctamente.";

            else if (errorMessage == "Repeated Commune name")
                errorMessage = "No fue posible guardar la comuna'" + objSource.CommuneName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar la comuna, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(Commune Commune, out string errorMessage)
        {
            if (!ValidateCommuneName(Commune.CommuneName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsCommune(int CommuneId, out string errorMessage)
        {
            bool exist = new DcCommune().ExistsCommune(CommuneId, out errorMessage);
            return exist;
        }

        public List<Commune> GetCommuneList(out string errorMessage)
        {
            List<Commune> list = new DcCommune().GetCommuneList(out errorMessage);
            return list;
        }

        public bool ValidateCommuneId(int CommuneId, out string errorMessage)
        {
            errorMessage = "";
            if (CommuneId == 0)
            {
                errorMessage = "El campo 'Id de Commune' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateCommuneName(string CommuneName, out string errorMessage)
        {
            errorMessage = "";
            if (CommuneName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de Commune' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteCommune(int CommuneId, string CommuneName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcCommune().DeleteCommune(CommuneId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "La comuna fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró la comuna '" + CommuneName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "La comuna '" + CommuneName
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
            List<TsDropDownItem> list = new DcCommune().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcCommune().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcCommune().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcCommune().GetComboListByRegionId(id,out errorMessage);
            return list;
        }
    }

}