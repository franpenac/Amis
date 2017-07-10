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
    public class BcPressureSetting : ITsDropDownList
    {
        public void Copy(PressureSetting objSource, ref PressureSetting objDestination)
        {
            new DcPressureSetting().Copy(objSource, ref objDestination);
        }

        public PressureSetting Save(PressureSetting objSource, out string errorMessage)
        {
            PressureSetting obj = new DcPressureSetting().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La configuración fue guardada correctamente.";
            else
                errorMessage = "No fue posible guardar el configuración, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(PressureSetting setting, out string errorMessage)
        {
            if (!new BcApplication().ValidateApplicationId(setting.ApplicationId, out errorMessage)) return false;
            if (!new BcAssetModel().ValidateAssetModelId(setting.AssetModelId, out errorMessage)) return false;
            if (!new DcPressureSetting().ValidateSavePressureSetting(setting, out errorMessage)) return false;

            return true;
        }

        public bool ExistsPressureSetting(int PressureSettingId, out string errorMessage)
        {
            bool exist = new DcPressureSetting().ExistsPressureSetting(PressureSettingId, out errorMessage);
            return exist;
        }

        public List<PressureSetting> GetPressureSettingList(out string errorMessage)
        {
            List<PressureSetting> list = new DcPressureSetting().GetPressureSettingList(out errorMessage);
            return list;
        }

        public bool ValidatePressureSettingId(int PressureSettingId, out string errorMessage)
        {
            errorMessage = "";
            if (PressureSettingId == 0)
            {
                errorMessage = "El campo 'Id de configuración' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeletePressureSetting(int settingId, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcPressureSetting().DeletePressureSetting(settingId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "La configuración fue eliminada correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el configuración por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El configuración '"
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
            throw new NotImplementedException();
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcPressureSetting().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcPressureSetting().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public AssetUniqueIdentification GetAssetUniqueIdentificationById(int assetUniqueIdentificationId)
        {
            return new DcAssetUniqueIdentification().GetAssetUniqueIdentificationById(assetUniqueIdentificationId);
        }

        public PressureSetting GetPressureSettingByAssetModelId(int assetModelId)
        {
            return new DcPressureSetting().GetPressureSettingByAssetModelId(assetModelId);
        }
    }

}