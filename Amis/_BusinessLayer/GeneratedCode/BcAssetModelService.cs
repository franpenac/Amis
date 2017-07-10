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
    public class BcAssetModelService : ITsDropDownList
    {
        public void Copy(AssetModelService objSource, ref AssetModelService objDestination)
        {
            new DcAssetModelService().Copy(objSource, ref objDestination);
        }

        public AssetModelService Save(AssetModelService objSource, out string errorMessage)
        {
            AssetModelService obj = new DcAssetModelService().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El servicio de modelo '" + objSource.AssetModelServiceName + "' fue guardado correctamente.";

            else if (errorMessage == "Repeated model service name")
                errorMessage = "No fue posible guardar el servicio de modelo'" + objSource.AssetModelServiceName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el servicio de modelo, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(AssetModelService service, out string errorMessage)
        {
            if (!ValidateAssetModelServiceName(service.AssetModelServiceName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsAssetModelService(int AssetModelServiceId, out string errorMessage)
        {
            bool exist = new DcAssetModelService().ExistsAssetModelService(AssetModelServiceId, out errorMessage);
            return exist;
        }

        public List<AssetModelService> GetAssetModelServiceList(out string errorMessage)
        {
            List<AssetModelService> list = new DcAssetModelService().GetAssetModelServiceList(out errorMessage);
            return list;
        }

        public bool ValidateAssetModelServiceId(int AssetModelServiceId, out string errorMessage)
        {
            errorMessage = "";
            if (AssetModelServiceId == 0)
            {
                errorMessage = "El campo 'Id de servicio de modelo' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateAssetModelServiceName(string serviceName, out string errorMessage)
        {
            errorMessage = "";
            if (serviceName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de servicio de modelo' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteAssetModelService(int serviceId, string serviceName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcAssetModelService().DeleteAssetModelService(serviceId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El modelo fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el modelo '" + serviceName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El modelo '" + serviceName
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
            List<TsDropDownItem> list = new DcAssetModelService().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcAssetModelService().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcAssetModelService().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}