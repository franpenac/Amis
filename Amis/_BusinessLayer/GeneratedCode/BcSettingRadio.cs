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
    public class BcSettingRadio : ITsDropDownList
    {
        public void Copy(SettingRadio objSource, ref SettingRadio objDestination)
        {
            new DcSettingRadio().Copy(objSource, ref objDestination);
        }

        public SettingRadio Save(SettingRadio objSource, out string errorMessage)
        {
            SettingRadio obj = new DcSettingRadio().Save(objSource, out errorMessage);
            return obj;
        }

        public bool ExistsSettingRadio(int SettingRadioId, out string errorMessage)
        {
            bool exist = new DcSettingRadio().ExistsSettingRadio(SettingRadioId, out errorMessage);
            return exist;
        }

        public List<SettingRadio> GetSettingRadioList(out string errorMessage)
        {
            List<SettingRadio> list = new DcSettingRadio().GetSettingRadioList(out errorMessage);
            return list;
        }

        public CommonEnums.DeletedRecordStates DeleteSettingRadio(int SettingRadioId, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcSettingRadio().DeleteSettingRadio(SettingRadioId, out errorMessage);
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

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}