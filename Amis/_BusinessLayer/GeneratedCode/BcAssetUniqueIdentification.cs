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
    public class BcAssetUniqueIdentification : ITsDropDownList
    {
        public void Copy(AssetUniqueIdentification objSource, ref AssetUniqueIdentification objDestination)
        {
            new DcAssetUniqueIdentification().Copy(objSource, ref objDestination);
        }

        public AssetUniqueIdentification Save(AssetUniqueIdentification objSource, out string errorMessage)
        {
            AssetUniqueIdentification obj = new DcAssetUniqueIdentification().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La configuracion del activo fue guardado correctamente.";

            else if (errorMessage == "Repeated id")
                errorMessage = "No fue posible guardar la configuración pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar la configuracion, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool ExistsAssetUniqueIdentification(int AssetUniqueIdentificationId, out string errorMessage)
        {
            bool exist = new DcAssetUniqueIdentification().ExistsAssetUniqueIdentification(AssetUniqueIdentificationId, out errorMessage);
            return exist;
        }

        public List<AssetUniqueIdentification> GetAssetUniqueIdentificationList(out string errorMessage)
        {
            List<AssetUniqueIdentification> list = new DcAssetUniqueIdentification().GetAssetUniqueIdentificationList(out errorMessage);
            return list;
        }

        public bool ValidateAssetUniqueIdentificationId(AssetUniqueIdentification AssetUniqueIdentification, out string errorMessage)
        {
            errorMessage = "";

            if (!new DcAssetUniqueIdentification().ValidateUniqueIdentification(AssetUniqueIdentification, out errorMessage))
            {
                errorMessage = "La combinación que ha digitado, ya existe. Por favor intente otra combinación.";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteAssetUniqueIdentification(int serviceId, out string errorMessage)
        {

            Asset assetObj = new Asset();
            if (!new DcAsset().HasAUI(serviceId, ref assetObj))
            {
                errorMessage = "La confuración no pudo ser eliminada, debido a que posee activos asociados a ella..";
                return CommonEnums.DeletedRecordStates.NotDeleted;

            }

            DispatchProviderDocumentItem dispObj = new DispatchProviderDocumentItem();
            if (!new DcDispatchProviderDocumentItem().HasAUI(serviceId, ref dispObj))
            {
                errorMessage = "La confuración no pudo ser eliminada, debido a que posee items de guias asociados a ella..";
                return CommonEnums.DeletedRecordStates.NotDeleted;

            }

            CommonEnums.DeletedRecordStates wasDeleted = new DcAssetUniqueIdentification().DeleteAssetUniqueIdentification(serviceId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "La confuración fue eliminada correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró la configuración por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "La configuracion no pudo ser eliminada. Comuníquese con el Administrador del Sistema. "
                + "El Servidor entregó el siguiente mensaje: " + errorMessage;
            return CommonEnums.DeletedRecordStates.NotDeleted;
        }

        public void ExportWebDataGridToExcel(WebExcelExporter webExcelExporter, WebDataGrid webDataGrid)
        {
            webExcelExporter.DataExportMode = Infragistics.Web.UI.GridControls.DataExportMode.AllDataInDataSource;
            webExcelExporter.DownloadName = "amis_exported_file.xlsx";
            webExcelExporter.Export(webDataGrid);
        }

        public AssetUniqueIdentification GetUniqueIdentification(int type, int origin, int model, int service, out string errorMessage)
        {
            AssetUniqueIdentification obj = new DcAssetUniqueIdentification().GetUniqueIdentification(type, origin, model, service, out errorMessage);
            errorMessage = "";
            if (obj!=null)
            {
                return obj;
            }
            else
            {
                errorMessage = "No existe la combinacion deseada, dirijase a la pagina de combinaciones para crearla.";
                return null;
            }
        }

        // Implementacion de las interfaces

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcAssetUniqueIdentification().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        // Metodos con filtro propio

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListAssetType(out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List 
                = new DcAssetUniqueIdentification().GetComboListAssetType(out errorMessage);
            return List;

        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListOrigin(int assetId, out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List 
                = new DcAssetUniqueIdentification().GetComboListOrigin(assetId, out errorMessage);
            return List;

        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListBrand(int assetId, int originId, out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List = 
                new DcAssetUniqueIdentification().GetComboListBrand(assetId,originId, out errorMessage);
            return List;

        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListModel(int assetId, int originId,int brandId, out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new DcAssetUniqueIdentification().GetComboListAssetModel(assetId, originId,brandId, out errorMessage);
            return List;

        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListService(int assetId, int originId,int brandId,int modelId, out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new DcAssetUniqueIdentification().GetComboListAssetModelService(assetId, originId, brandId, modelId, out errorMessage);
            return List;

        }

        public AssetUniqueIdentification GetAssetUniqueIdentificationById(int assetUniqueIdentificationId)
        {
            return new DcAssetUniqueIdentification().GetAssetUniqueIdentificationById(assetUniqueIdentificationId);
        }
    }

}