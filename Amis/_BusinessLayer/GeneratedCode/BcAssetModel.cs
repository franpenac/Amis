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
    public class BcAssetModel : ITsDropDownList
    {
        public void Copy(AssetModel objSource, ref AssetModel objDestination)
        {
            new DcAssetModel().Copy(objSource, ref objDestination);
        }

        public AssetModel Save(AssetModel objSource, out string errorMessage)
        {
            AssetModel obj = new DcAssetModel().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El modelo '" + objSource.AssetModelName + "' fue guardado correctamente.";

            else if (errorMessage == "Repeated model name")
                errorMessage = "No fue posible guardar el modelo'" + objSource.AssetModelName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el modelo, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(AssetModel model, out string errorMessage)
        {
            if (!ValidateAssetModelName(model.AssetModelName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsAssetModel(int AssetModelId, out string errorMessage)
        {
            bool exist = new DcAssetModel().ExistsAssetModel(AssetModelId, out errorMessage);
            return exist;
        }

        public List<AssetModel> GetAssetModelList(out string errorMessage)
        {
            List<AssetModel> list = new DcAssetModel().GetAssetModelList(out errorMessage);
            return list;
        }

        public bool ValidateAssetModelId(int AssetModelId, out string errorMessage)
        {
            errorMessage = "";
            if (AssetModelId == 0)
            {
                errorMessage = "Debe seleccionar un modelo, debido a que es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateAssetModelName(string modelName, out string errorMessage)
        {
            errorMessage = "";
            if (modelName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteAssetModel(int modelId, string modelName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcAssetModel().DeleteAssetModel(modelId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El modelo fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el modelo '" + modelName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El modelo '" + modelName
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
            List<TsDropDownItem> list = new DcAssetModel().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcAssetModel().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcAssetModel().GetTableList(out errorMessage);
            return list;
        }


        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcAssetModel().GetComboListByFilter(id,out errorMessage);
            return list;
        }

        public AssetModel GetAssetModelById(int assetModelId, out string errorMessage)
        {
            return new DcAssetModel().GetAssetModelById(assetModelId, out errorMessage);
        }

        public List<TsDropDownItem> GetComboListAssetModelTyreByBrandId(int id, out string errorMessage)
        {
            return new DcAssetModel().GetComboListAssetModelTyreByBrandId(id, out errorMessage);
        }
    }
}