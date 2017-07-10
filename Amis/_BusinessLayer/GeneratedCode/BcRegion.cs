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
    public class BcRegion : ITsDropDownList
    {
        public void Copy(Region objSource, ref Region objDestination)
        {
            new DcRegion().Copy(objSource, ref objDestination);
        }

        public Region Save(Region objSource, out string errorMessage)
        {
            Region obj = new DcRegion().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La region '" + objSource.RegionName + "' fue guardada correctamente.";

            else if (errorMessage == "Repeated Region name")
                errorMessage = "No fue posible guardar la region'" + objSource.RegionName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar la region, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(Region Region, out string errorMessage)
        {
            if (!ValidateRegionName(Region.RegionName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsRegion(int RegionId, out string errorMessage)
        {
            bool exist = new DcRegion().ExistsRegion(RegionId, out errorMessage);
            return exist;
        }

        public List<Region> GetRegionList(out string errorMessage)
        {
            List<Region> list = new DcRegion().GetRegionList(out errorMessage);
            return list;
        }

        public bool ValidateRegionId(int RegionId, out string errorMessage)
        {
            errorMessage = "";
            if (RegionId == 0)
            {
                errorMessage = "El campo 'Id de region' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateRegionName(string RegionName, out string errorMessage)
        {
            errorMessage = "";
            if (RegionName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de region' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteRegion(int RegionId, string RegionName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcRegion().DeleteRegion(RegionId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "La region fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró la region '" + RegionName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "La region '" + RegionName
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
            List<TsDropDownItem> list = new DcRegion().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcRegion().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcRegion().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}