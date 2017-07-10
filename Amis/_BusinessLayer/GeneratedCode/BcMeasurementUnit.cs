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
    public class BcMeasurementUnit : ITsDropDownList
    {
        public void Copy(MeasurementUnit objSource, ref MeasurementUnit objDestination)
        {
            new DcMeasurementUnit().Copy(objSource, ref objDestination);
        }

        public MeasurementUnit Save(MeasurementUnit objSource, out string errorMessage)
        {
            MeasurementUnit obj = new DcMeasurementUnit().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "la medicion '" + objSource.MeasurementUnitName + "' fue guardada correctamente.";

            else if (errorMessage == "Repeated fire name")
                errorMessage = "No fue posible guardar el la medicion'" + objSource.MeasurementUnitName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el la medicion, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(MeasurementUnit MeasurementUnit, out string errorMessage)
        {
            if (!ValidateMeasurementUnitName(MeasurementUnit.MeasurementUnitName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsMeasurementUnit(int MeasurementUnitId, out string errorMessage)
        {
            bool exist = new DcMeasurementUnit().ExistsMeasurementUnit(MeasurementUnitId, out errorMessage);
            return exist;
        }

        public List<MeasurementUnit> GetMeasurementUnitList(out string errorMessage)
        {
            List<MeasurementUnit> list = new DcMeasurementUnit().GetMeasurementUnitList(out errorMessage);
            return list;
        }

        public bool ValidateMeasurementUnitId(int MeasurementUnitId, out string errorMessage)
        {
            errorMessage = "";
            if (MeasurementUnitId == 0)
            {
                errorMessage = "El campo 'Id de la medicion' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateMeasurementUnitName(string MeasurementUnitName, out string errorMessage)
        {
            errorMessage = "";
            if (MeasurementUnitName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de la medicion' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteMeasurementUnit(int MeasurementUnitId, string MeasurementUnitName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcMeasurementUnit().DeleteMeasurementUnit(MeasurementUnitId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "la medicion fue eliminada correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró la medicion '" + MeasurementUnitName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "la medicion '" + MeasurementUnitName
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
            List<TsDropDownItem> list = new DcMeasurementUnit().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcMeasurementUnit().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcMeasurementUnit().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}