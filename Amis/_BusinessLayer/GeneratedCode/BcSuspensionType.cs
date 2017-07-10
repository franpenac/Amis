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
    public class BcSuspensionType : ITsDropDownList
    {
        public void Copy(SuspensionType objSource, ref SuspensionType objDestination)
        {
            new DcSuspensionType().Copy(objSource, ref objDestination);
        }

        public SuspensionType Save(SuspensionType objSource, out string errorMessage)
        {
            SuspensionType obj = new DcSuspensionType().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El tipo de suspensión '" + objSource.SuspensionTypeName + "' fue guardada correctamente.";

            else if (errorMessage == "Repeated SuspensionType name")
                errorMessage = "No fue posible guardar el tipo de suspensión'" + objSource.SuspensionTypeName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el tipo de suspensión, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(SuspensionType SuspensionType, out string errorMessage)
        {
            if (!ValidateSuspensionTypeName(SuspensionType.SuspensionTypeName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsSuspensionType(int SuspensionTypeId, out string errorMessage)
        {
            bool exist = new DcSuspensionType().ExistsSuspensionType(SuspensionTypeId, out errorMessage);
            return exist;
        }

        public List<SuspensionType> GetSuspensionTypeList(out string errorMessage)
        {
            List<SuspensionType> list = new DcSuspensionType().GetSuspensionTypeList(out errorMessage);
            return list;
        }

        public bool ValidateSuspensionTypeId(int SuspensionTypeId, out string errorMessage)
        {
            errorMessage = "";
            if (SuspensionTypeId == 0)
            {
                errorMessage = "El campo 'Id de tipo de suspensión' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateSuspensionTypeName(string SuspensionTypeName, out string errorMessage)
        {
            errorMessage = "";
            if (SuspensionTypeName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de tipo de suspensión' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteSuspensionType(int SuspensionTypeId, string SuspensionTypeName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcSuspensionType().DeleteSuspensionType(SuspensionTypeId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El tipo de suspensión fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el tipo de suspensión '" + SuspensionTypeName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El tipo de suspensión '" + SuspensionTypeName
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
            List<TsDropDownItem> list = new DcSuspensionType().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcSuspensionType().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcSuspensionType().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}