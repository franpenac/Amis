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
    public class BcWarehouse : ITsDropDownList
    {
        public void Copy(Warehouse objSource, ref Warehouse objDestination)
        {
            new DcWarehouse().Copy(objSource, ref objDestination);
        }

        public Warehouse Save(Warehouse objSource, out string errorMessage)
        {
            Warehouse obj = new DcWarehouse().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La bodega '" + objSource.WarehouseName + "' fue guardada correctamente.";

            else if (errorMessage == "Repeated Warehouse name")
                errorMessage = "No fue posible guardar la bodega'" + objSource.WarehouseName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar la bodega, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(Warehouse Warehouse, out string errorMessage)
        {
            if (!ValidateWarehouseName(Warehouse.WarehouseName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsWarehouse(int WarehouseId, out string errorMessage)
        {
            bool exist = new DcWarehouse().ExistsWarehouse(WarehouseId, out errorMessage);
            return exist;
        }

        public List<Warehouse> GetWarehouseList(out string errorMessage)
        {
            List<Warehouse> list = new DcWarehouse().GetWarehouseList(out errorMessage);
            return list;
        }

        public bool ValidateWarehouseId(int WarehouseId, out string errorMessage)
        {
            errorMessage = "";
            if (WarehouseId == 0)
            {
                errorMessage = "El campo 'Id de bodega' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateWarehouseName(string WarehouseName, out string errorMessage)
        {
            errorMessage = "";
            if (WarehouseName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de bodega' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            if (!new DcWarehouse().ValidateWarehouseName(WarehouseName))
            {
                errorMessage = "El nombre de bodega ya existe en la Base de Datos";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteWarehouse(int WarehouseId, string WarehouseName, out string errorMessage)
        {
            
			Facility obj = new Facility();
			if(! new DcFacility().HasWarehouse(WarehouseId,ref obj))
			{
				CommonEnums.DeletedRecordStates wasDeleted = new DcWarehouse().DeleteWarehouse(WarehouseId, out errorMessage);
				if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
				{
					errorMessage = "La bodega fue eliminado correctamente.";
					return CommonEnums.DeletedRecordStates.DeletedOk;
				}
				else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
				{
					errorMessage = "No se encontró la bodega '" + WarehouseName + "', por lo cual no pudo ser eliminado.";
					return CommonEnums.DeletedRecordStates.NotFound;
				}
			}
			else
			{
				errorMessage = "La bodega '" + WarehouseName
					+ " no pudo ser eliminado, debido a que tiene activos asociados a ella";
				return CommonEnums.DeletedRecordStates.NotDeleted;
			}
            
            errorMessage = "La bodega '" + WarehouseName
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
            List<TsDropDownItem> list = new DcWarehouse().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcWarehouse().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcWarehouse().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int BranchOfficeId, out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcWarehouse().GetComboListByBranchOfficeId(BranchOfficeId, out errorMessage);
            return list;
        }

        public List<Warehouse> GetWharehouseListByBranchOfficeId(int BranchOfficeId, out string errorMessage)
        {
            List<Warehouse> list = new DcWarehouse().GetWharehouseListByBranchOfficeId(BranchOfficeId, out errorMessage);
            Warehouse wh = new Warehouse();
            wh.WarehouseId = 0;
            wh.BranchOfficeId = 0;
            wh.WarehouseName = "Seleccione";
            list.Insert(0,wh);
            return list;
        }
    }

}