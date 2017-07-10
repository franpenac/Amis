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
    public class BcSettingCat : ITsDropDownList
    {
        public void Copy(SettingCat objSource, ref SettingCat objDestination)
        {
            new DcSettingCat().Copy(objSource, ref objDestination);
        }

        public SettingCat Save(SettingCat objSource, out string errorMessage)
        {
            SettingCat obj = new DcSettingCat().Save(objSource, out errorMessage);
            return obj;
        }

        public bool ExistsSettingCat(int SettingCatId, out string errorMessage)
        {
            bool exist = new DcSettingCat().ExistsSettingCat(SettingCatId, out errorMessage);
            return exist;
        }

        public List<SettingCat> GetSettingCatList(out string errorMessage)
        {
            List<SettingCat> list = new DcSettingCat().GetSettingCatList(out errorMessage);
            return list;
        }

        public CommonEnums.DeletedRecordStates DeleteSettingCat(int SettingCatId, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcSettingCat().DeleteSettingCat(SettingCatId, out errorMessage);
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