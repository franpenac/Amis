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
    public class BcFireType : ITsDropDownList
    {
        public void Copy(FireType objSource, ref FireType objDestination)
        {
            new DcFireType().Copy(objSource, ref objDestination);
        }

        public FireType Save(FireType objSource, out string errorMessage)
        {
            FireType obj = new DcFireType().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El tipo de fuego '" + objSource.FireTypeName + "' fue guardado correctamente.";

            else if (errorMessage == "Repeated fire name")
                errorMessage = "No fue posible guardar el tipo de fuego'" + objSource.FireTypeName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el tipo de fuego, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(FireType FireType, out string errorMessage)
        {
            if (!ValidateFireTypeName(FireType.FireTypeName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsFireType(int FireTypeId, out string errorMessage)
        {
            bool exist = new DcFireType().ExistsFireType(FireTypeId, out errorMessage);
            return exist;
        }

        public List<FireType> GetFireTypeList(out string errorMessage)
        {
            List<FireType> list = new DcFireType().GetFireTypeList(out errorMessage);
            return list;
        }

        public bool ValidateFireTypeId(int FireTypeId, out string errorMessage)
        {
            errorMessage = "";
            if (FireTypeId == 0)
            {
                errorMessage = "El campo 'Id de tipo de fuego' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateFireTypeName(string FireTypeName, out string errorMessage)
        {
            errorMessage = "";
            if (FireTypeName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de tipo de fuego' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteFireType(int FireTypeId, string FireTypeName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcFireType().DeleteFireType(FireTypeId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El tipo de fuego fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el tipo de fuego '" + FireTypeName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El tipo de fuego '" + FireTypeName
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
            List<TsDropDownItem> list = new DcFireType().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcFireType().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcFireType().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}