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
using Infragistics.Web.UI.NavigationControls;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcUserMenuOption : ITsDropDownList
    {
        public void Copy(UserMenuOption objSource, ref UserMenuOption objDestination)
        {
            new DcUserMenuOption().Copy(objSource, ref objDestination);
        }

        public UserMenuOption Save(UserMenuOption objSource, out string errorMessage)
        {
            UserMenuOption obj = new DcUserMenuOption().Save(objSource, out errorMessage);
            if (obj != null)
            {
                errorMessage = "Se han asignado permisos correctamente.";
            }
            else
                errorMessage = "No fue posible guardar UserMenuOption, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public UserMenuOption GetUserMenuOptionById(int menuOption, int userId, out string errorMessage)
        {
            UserMenuOption usm = new DcUserMenuOption().GetUserMenuOptionById(menuOption, userId,out errorMessage);
            if (usm!=null)
            {
                errorMessage = "Acción Realizada!";
                return usm;
            }else
            {
                errorMessage = "Debe autorizar permiso a pagina en primer lugar";
                return null;
            }
        }

        public UserMenuOption GetUserMenuOptionByUserId(int userId)
        {
            return new DcUserMenuOption().GetUserMenuOptionByUserId(userId);
        }

        public List<MenuOption> UserAuthorizedPages(int userId)
        {
            return new DcUserMenuOption().UserAuthorizedPages(userId);
        }

        public List<MenuOption> UserAuthorizedModules(int userId)
        {
            return new DcUserMenuOption().UserAuthorizedModules(userId);
        }

        public List<MenuOption> PagesOfModules(int moduleMenuOptionId, int userId)
        {
            return new DcUserMenuOption().UserAuthorizedPages(userId).Where(r => r.ParentMenuOptionId == moduleMenuOptionId).OrderBy(r => r.Name).ToList();

        }

        public bool ValidUserToPage(int menuOptionId, int userId)
        {
            return new DcUserMenuOption().ValidUserToPage(menuOptionId, userId);
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
            IEnumerable<object> list = new DcUserMenuOption().GetTableList(out errorMessage);
            return list;
        }

        public List<UserMenuOptionAuthorization> GetPagesList(int userId)
        {
            List<UserMenuOptionAuthorization> list = new DcUserMenuOption().GetPagesList(userId);
            list = list.Where(r => r.MenuOptionId != 8).ToList();
            foreach (UserMenuOptionAuthorization item in list)
            {
                if (item.CanAuthorize == "Y")
                {
                    item.CanAuthorizeBool = true;
                }
                else if (item.CanAuthorize == "N")
                {
                    item.CanAuthorizeBool = false;
                }
                if (item.CanCreate == "Y")
                {
                    item.CanCreateBool = true;
                }
                else if (item.CanCreate == "N")
                {
                    item.CanCreateBool = false;
                }
                if (item.CanDelete == "Y")
                {
                    item.CanDeleteBool = true;
                }
                else if (item.CanDelete == "N")
                {
                    item.CanDeleteBool = false;
                }
                if (item.CanGenerateReport == "Y")
                {
                    item.CanGenerateReportBool = true;
                }
                else if (item.CanGenerateReport == "N")
                {
                    item.CanGenerateReportBool = false;
                }
                if (item.ParentMenuOptionName == "Activos por unidad")
                {
                    item.ParentMenuOptionName = "Reportes";
                }
            }
            
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}