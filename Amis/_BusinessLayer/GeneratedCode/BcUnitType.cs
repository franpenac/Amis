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
    public class BcUnitType : ITsDropDownList
    {
        public void Copy(UnitType objSource, ref UnitType objDestination)
        {
            new DcUnitType().Copy(objSource, ref objDestination);
        }

        public UnitType Save(UnitType objSource, out string errorMessage)
        {
            UnitType obj = new DcUnitType().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El tipo de unidad '" + objSource.UnitTypeName + "' fue guardada correctamente.";

            else if (errorMessage == "Repeated UnitType name")
                errorMessage = "No fue posible guardar el tipo de unidad '" + objSource.UnitTypeName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el tipo de unidad, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(UnitType UnitType, out string errorMessage)
        {
            if (!ValidateUnitTypeName(UnitType.UnitTypeName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsUnitType(int UnitTypeId, out string errorMessage)
        {
            bool exist = new DcUnitType().ExistsUnitType(UnitTypeId, out errorMessage);
            return exist;
        }

        public List<UnitType> GetUnitTypeList(out string errorMessage)
        {
            List<UnitType> list = new DcUnitType().GetUnitTypeList(out errorMessage);
            return list;
        }

        public bool ValidateUnitTypeId(int UnitTypeId, out string errorMessage)
        {
            errorMessage = "";
            if (UnitTypeId == 0)
            {
                errorMessage = "El campo 'Id de tipo de unidad' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateUnitTypeName(string UnitTypeName, out string errorMessage)
        {
            errorMessage = "";
            if (UnitTypeName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Tipo de unidad' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteUnitType(int UnitTypeId, string UnitTypeName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcUnitType().DeleteUnitType(UnitTypeId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El tipo de unidad fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el tipo de unidad '" + UnitTypeName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El tipo de unidad '" + UnitTypeName
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
            List<TsDropDownItem> list = new DcUnitType().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcUnitType().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcUnitType().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}