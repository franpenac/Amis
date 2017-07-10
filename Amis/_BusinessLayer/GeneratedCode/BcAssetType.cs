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
    public class BcAssetType : ITsDropDownList
    {
        public void Copy(AssetType objSource, ref AssetType objDestination)
        {
            new DcAssetType().Copy(objSource, ref objDestination);
        }

        public AssetType Save(AssetType objSource, out string errorMessage)
        {
            AssetType obj = new DcAssetType().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El tipo de activo '" + objSource.AssetTypeName + "' fue guardado correctamente.";

            else if (errorMessage == "Repeated fire name")
                errorMessage = "No fue posible guardar el tipo de activo'" + objSource.AssetTypeName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el tipo de activo, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(AssetType AssetType, out string errorMessage)
        {
            if (!ValidateAssetTypeName(AssetType.AssetTypeName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsAssetType(int AssetTypeId, out string errorMessage)
        {
            bool exist = new DcAssetType().ExistsAssetType(AssetTypeId, out errorMessage);
            return exist;
        }

        public List<AssetType> GetAssetTypeList(out string errorMessage)
        {
            List<AssetType> list = new DcAssetType().GetAssetTypeList(out errorMessage);
            return list;
        }

        public bool ValidateAssetTypeId(int AssetTypeId, out string errorMessage)
        {
            errorMessage = "";
            if (AssetTypeId == 0)
            {
                errorMessage = "El campo 'Id de tipo de activo' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateAssetTypeName(string AssetTypeName, out string errorMessage)
        {
            errorMessage = "";
            if (AssetTypeName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de tipo de activo' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteAssetType(int AssetTypeId, string AssetTypeName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcAssetType().DeleteAssetType(AssetTypeId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El tipo de activo fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el tipo de activo '" + AssetTypeName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El tipo de activo '" + AssetTypeName
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
            List<TsDropDownItem> list = new DcAssetType().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcAssetType().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcAssetType().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public string GetAssetTypeNameById(int assetTypeId)
        {
            return new DcAssetType().GetAssetTypeNameById(assetTypeId);
        }

        public string GetAssetTypeNameByAssetId(int assetId)
        {
            return new DcAssetType().GetAssetTypeNameByAssetId(assetId);
        }
    }

}