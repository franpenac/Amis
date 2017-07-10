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
    public class BcLocation : ITsDropDownList
    {
        public void Copy(Location objSource, ref Location objDestination)
        {
            new DcLocation().Copy(objSource, ref objDestination);
        }

        public Location Save(Location objSource, out string errorMessage)
        {
            Location obj = new DcLocation().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La localizacion '" + objSource.LocationName + "' fue guardada correctamente.";

            else if (errorMessage == "Repeated Location name")
                errorMessage = "No fue posible guardar la localizacion'" + objSource.LocationName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar la localizacion, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(Location Location, out string errorMessage)
        {
            if (!ValidateLocationName(Location.LocationName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsLocation(int LocationId, out string errorMessage)
        {
            bool exist = new DcLocation().ExistsLocation(LocationId, out errorMessage);
            return exist;
        }

        public List<Location> GetLocationList(out string errorMessage)
        {
            List<Location> list = new DcLocation().GetLocationList(out errorMessage);
            return list;
        }

        public bool ValidateLocationId(int LocationId, out string errorMessage)
        {
            errorMessage = "";
            if (LocationId == 0)
            {
                errorMessage = "El campo 'Id de Location' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateLocationName(string LocationName, out string errorMessage)
        {
            errorMessage = "";
            if (LocationName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de Location' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteLocation(int LocationId, string LocationName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcLocation().DeleteLocation(LocationId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "La localizacion fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró la localizacion '" + LocationName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "La localizacion '" + LocationName
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
            List<TsDropDownItem> list = new DcLocation().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcLocation().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcLocation().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}