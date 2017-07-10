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
    public class BcFacility : ITsDropDownList
    {
        public void Copy(Facility objSource, ref Facility objDestination)
        {
            new DcFacility().Copy(objSource, ref objDestination);
        }

        public Facility Save(Facility objSource, out string errorMessage)
        {
            Facility obj = new DcFacility().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La ubicacion guardada correctamente.";

            else if (errorMessage == "Repeated Facility Id")
                errorMessage = "No fue posible guardar la ubicacion, pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar la ubicacion, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool ExistsFacility(int FacilityId, out string errorMessage)
        {
            bool exist = new DcFacility().ExistsFacility(FacilityId, out errorMessage);
            return exist;
        }

        public List<Facility> GetFacilityList(out string errorMessage)
        {
            List<Facility> list = new DcFacility().GetFacilityList(out errorMessage);
            return list;
        }

        public bool ValidateFacilityId(int FacilityId, out string errorMessage)
        {
            errorMessage = "";
            if (FacilityId == 0)
            {
                errorMessage = "El campo 'Id de ubicacion' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteFacility(int FacilityId, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcFacility().DeleteFacility(FacilityId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "La ubicacion fue eliminada correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró la ubicacion, por lo cual no pudo ser eliminada.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "La ubicacion no pudo ser eliminada. Comuníquese con el Administrador del Sistema. "
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
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int facilityId, out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcFacility().GetComboList(facilityId, out errorMessage);
            return list;
        }

        public int GetFacilityByWarehouse(int warehouseId)
        {
            return new DcFacility().GetFacilityByWarehouse(warehouseId);
        }

        public Facility GetFacilityByIdAndTypeId(int facilityId, int facilityTypeId)
        {
            return new DcFacility().GetFacilityByIdAndTypeId(facilityId, facilityTypeId);
        }
    }

}