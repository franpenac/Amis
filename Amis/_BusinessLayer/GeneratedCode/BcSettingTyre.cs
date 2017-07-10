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
    public class BcSettingTyre : ITsDropDownList
    {
        public void Copy(SettingTyre objSource, ref SettingTyre objDestination)
        {
            new DcSettingTyre().Copy(objSource, ref objDestination);
        }

        public SettingTyre Save(SettingTyre objSource, out string errorMessage)
        {
            SettingTyre obj = new DcSettingTyre().Save(objSource, out errorMessage);
            return obj;
        }

        public bool ExistsSettingTyre(int SettingTyreId, out string errorMessage)
        {
            bool exist = new DcSettingTyre().ExistsSettingTyre(SettingTyreId, out errorMessage);
            return exist;
        }

        public List<SettingTyre> GetSettingTyreList(out string errorMessage)
        {
            List<SettingTyre> list = new DcSettingTyre().GetSettingTyreList(out errorMessage);
            return list;
        }

        public CommonEnums.DeletedRecordStates DeleteSettingTyre(int SettingTyreId, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcSettingTyre().DeleteSettingTyre(SettingTyreId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "La configuracion fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró la configuracion, por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "La configuracion no pudo ser eliminado. Comuníquese con el Administrador del Sistema. "
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
            return new DcSettingTyre().GetComboList(out errorMessage);
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public int GetNumberDepthByModel(int assetModelId)
        {
            return new DcSettingTyre().GetNumberDepthByModel(assetModelId);
        }

        public List<ListItem> GetMeasurementTyreList()
        {
            return new DcSettingTyre().GetMeasurementTyreList();
        }

        public List<ListItem> GetSpeedIndexList()
        {
            return new DcSettingTyre().GetSpeedIndexList();

        }

        public List<ListItem> GetWeighIndexList()
        {
            return new DcSettingTyre().GetWeighIndexList();

        }

        public SpeedIndex GetSpeedById(int speedIndexId)
        {
            return new DcSettingTyre().GetSpeedById(speedIndexId);

        }

        public IndexWegh GetWeighById(int indexWeghId)
        {
            return new DcSettingTyre().GetWeighById(indexWeghId);

        }

        public SettingTyre GetSettingTyreByAssetModelId(int assetModelId)
        {
            return new DcSettingTyre().GetSettingTyreByAssetModelId(assetModelId);
        }
    }

}