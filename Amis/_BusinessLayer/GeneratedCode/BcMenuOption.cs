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
using System.Net.Mail;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using amis._DataLayer.GeneratedCode;
using System.Security.Cryptography;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcMenuOption : ITsDropDownList
    {
        public void Copy(MenuOption objSource, ref MenuOption objDestination)
        {
            new DcMenuOption().Copy(objSource, ref objDestination);
        }

        public MenuOption Save(MenuOption objSource, out string errorMessage)
        {
            MenuOption obj = new DcMenuOption().Save(objSource, out errorMessage);
            if (obj != null)
            {
                errorMessage = "El menu de opciones '" + objSource.MenuOptionId + "' fue guardado correctamente.";
            }
            else if (errorMessage == "Repeated MenuOption")
                errorMessage = "No fue posible guardar Menu de opciones'" + objSource.MenuOptionId + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar menu de opciones, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }


        public MenuOption GetMenuOptionById(int MenuOptionId)
        {
            return new DcMenuOption().GetMenuOptionById(MenuOptionId);
        }
        public string GetParentMenuOptionById(int ParentMenuOptionId)
        {
            return new DcMenuOption().GetParentMenuOptionNameById(ParentMenuOptionId);
        }

        public List<MenuOption> GetMenuOptionList(out string errorMessage)
        {
            List<MenuOption> list = new DcMenuOption().GetMenuOptionList(out errorMessage);
            return list;
        }
        public CommonEnums.DeletedRecordStates DeleteMenuOption(int MenuOptionId, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcMenuOption().DeleteMenuOption(MenuOptionId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "La Opcion fue eliminada correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró la opcion '" + MenuOptionId + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El usuario '" + MenuOptionId
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
            List<TsDropDownItem> list = new DcMenuOption().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcMenuOption().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcMenuOption().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}