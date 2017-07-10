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
    public class BcSettingExtinguisher : ITsDropDownList
    {
        public void Copy(SettingExtinguisher objSource, ref SettingExtinguisher objDestination)
        {
            new DcSettingExtinguisher().Copy(objSource, ref objDestination);
        }

        public SettingExtinguisher Save(SettingExtinguisher objSource, out string errorMessage)
        {
            SettingExtinguisher obj = new DcSettingExtinguisher().Save(objSource, out errorMessage);
            return obj;
        }

        public bool ExistsSettingExtinguisher(int SettingExtinguisherId, out string errorMessage)
        {
            bool exist = new DcSettingExtinguisher().ExistsSettingExtinguisher(SettingExtinguisherId, out errorMessage);
            return exist;
        }

        public List<SettingExtinguisher> GetSettingExtinguisherList(out string errorMessage)
        {
            List<SettingExtinguisher> list = new DcSettingExtinguisher().GetSettingExtinguisherList(out errorMessage);
            return list;
        }

        public CommonEnums.DeletedRecordStates DeleteSettingExtinguisher(int SettingExtinguisherId, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcSettingExtinguisher().DeleteSettingExtinguisher(SettingExtinguisherId, out errorMessage);
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