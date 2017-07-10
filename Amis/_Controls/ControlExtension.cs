using amis.Models;
using Infragistics.Web.UI.GridControls;
using Infragistics.Web.UI.LayoutControls;
using Infragistics.Web.UI.ListControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using amis._Common;
using System.Web.UI.HtmlControls;
using System.Data;
using amis._BusinessLayer.GeneratedCode;
using System.Web;
using Infragistics.Web.UI.NavigationControls;

namespace amis._Controls
{
    public static class ControlExtension
    {
        #region WebDropDown

        public static void SetComboList(this WebDropDown webDropDown, ITsDropDownList originClass, out string errorMessage)
        {
            errorMessage = "";

            webDropDown.ValueField = "ComboId";
            webDropDown.TextField = "ComboName";

            webDropDown.DataSource = "";
            webDropDown.DataBind();

            List<TsDropDownItem> originList = originClass.GetComboList(out errorMessage);
            List<TsDropDownItem> itemList = new List<TsDropDownItem>();
            TsDropDownItem selectItem = new TsDropDownItem() { ComboId = "0", ComboName = "" };
            itemList.Add(selectItem);
            
                foreach (TsDropDownItem obj in originList)
                {
                    TsDropDownItem newItem = new TsDropDownItem();
                    newItem.ComboId = obj.ComboId;
                    newItem.ComboName = obj.ComboName;
                    itemList.Add(newItem);
                }
           
            webDropDown.DataSource = itemList;
            webDropDown.DataBind();
        }

        public static void CleanDataSource(this WebDropDown obj)
        {
            obj.DataSource = null;
            obj.DataBind();
        }

        public static void SetComboListByFiltrer(this WebDropDown webDropDown, ITsDropDownList originClass, int id, out string errorMessage)
        {
            errorMessage = "";

            webDropDown.ValueField = "ComboId";
            webDropDown.TextField = "ComboName";

            webDropDown.DataSource = "";
            webDropDown.DataBind();

            List<TsDropDownItem> originList = originClass.GetComboListByFiltrer(id, out errorMessage);
            List<TsDropDownItem> itemList = new List<TsDropDownItem>();
            TsDropDownItem selectItem = new TsDropDownItem() { ComboId = "0", ComboName = "" };
            itemList.Add(selectItem);

            foreach (TsDropDownItem obj in originList)
            {
                TsDropDownItem newItem = new TsDropDownItem();
                newItem.ComboId = obj.ComboId;
                newItem.ComboName = obj.ComboName;
                itemList.Add(newItem);
            }

            webDropDown.DataSource = itemList;
            webDropDown.DataBind();
        }

        public static void LoadCombo(this WebDropDown webDropDown, object dataSource)
        {
            webDropDown.DataSource = dataSource;
            webDropDown.DataBind();
        }

        #endregion WebDropDown

        #region DropDownList

        public static void SetComboList(this DropDownList dropDownList, ITsDropDownList originClass, out string errorMessage)
        {
            errorMessage = "";

            dropDownList.DataValueField = "ComboId";
            dropDownList.DataTextField = "ComboName";

            dropDownList.DataSource = "";
            dropDownList.DataBind();

            List<TsDropDownItem> originList = originClass.GetComboList(out errorMessage);
            List<TsDropDownItem> itemList = new List<TsDropDownItem>();
            TsDropDownItem selectItem = new TsDropDownItem() { ComboId = "0", ComboName = "Seleccionar" };
            itemList.Add(selectItem);

            foreach (TsDropDownItem obj in originList)
            {
                TsDropDownItem newItem = new TsDropDownItem();
                newItem.ComboId = obj.ComboId;
                newItem.ComboName = obj.ComboName;
                itemList.Add(newItem);
            }

            dropDownList.DataSource = itemList;
            dropDownList.DataBind();
        }

        public static void LoadDataSource(this DropDownList dropDownList, object dataSource)
        {
            dropDownList.DataSource = null;
            dropDownList.DataBind();
            dropDownList.DataSource = dataSource;
            dropDownList.DataBind();
        }

        public static void CleanDataSource(this DropDownList dropDownList)
        {
            dropDownList.DataSource = null;
            dropDownList.DataBind();
        }

        #endregion DropDownList

        #region WebDataGrid

        public static void SetTableList(this WebDataGrid webDataGrid, ITsDropDownList originClass, out string errorMessage)
        {
            webDataGrid.ClearDataSource();
            webDataGrid.Rows.Clear();
            webDataGrid.DataBind();
            webDataGrid.DataSource = originClass.GetTableList(out errorMessage);
            webDataGrid.DataBind();
        }

        public static void CleanDataSource(this WebDataGrid webDataGrid)
        {
            webDataGrid.ClearDataSource();
            webDataGrid.Rows.Clear();
            webDataGrid.DataBind();
        }

        public static void SetTableList(this WebDataGrid webDataGrid, ITsDropDownList originClass)
        {
            string errorMessage = "";
            webDataGrid.CleanDataSource();
            webDataGrid.Rows.Clear();
            webDataGrid.DataBind();
            webDataGrid.DataSource = originClass.GetTableList(out errorMessage);
            webDataGrid.DataBind();
        }

        public static string GetItemByKey(this WebDataGrid webDataGrid, int rowIndex, string fieldNameKey)
        {
            return webDataGrid.Rows[rowIndex].Items.FindItemByKey(fieldNameKey).Text;
        }

        public static GridRecordItem GetControlyKey(this WebDataGrid webDataGrid, int rowIndex, string fieldNameKey)
        {
            return webDataGrid.Rows[rowIndex].Items.FindItemByKey(fieldNameKey);
        }

        public static int GetItemIntByKey(this WebDataGrid webDataGrid, int rowIndex, string fieldNameKey)
        {
            if (webDataGrid.Rows[rowIndex]==null)
            {
                return 0;
            }
            return int.Parse(webDataGrid.Rows[rowIndex].Items.FindItemByKey(fieldNameKey).Text);
        }

        public static void ExportToExcel(this WebDataGrid webDataGrid)
        {
            WebExcelExporter exporter = new WebExcelExporter();
            exporter = new WebExcelExporter();
            exporter.DataExportMode = DataExportMode.AllDataInDataSource;
            exporter.DownloadName = "Export.xlsx";
            exporter.Export(webDataGrid);
        }

        #endregion WebDataGrid

        #region Page

        public static void ShowPopupMessage(this Page page, string message)
        {
            Control upanel = ControlRoutines.FindControlRecursive(page);
            if (upanel == null) return;

            WebDialogWindow dialog = new WebDialogWindow();
            dialog.Modal = true;
            dialog.WindowState = DialogWindowState.Normal;
            dialog.MaintainLocationOnScroll = true;
            dialog.InitialLocation = DialogWindowPosition.Centered;
            dialog.Width = new System.Web.UI.WebControls.Unit("500px");
            dialog.Height = new System.Web.UI.WebControls.Unit("200px");
            dialog.Font.Name = "Arial";
            dialog.Font.Size = new FontUnit("13px");
            dialog.Header.CaptionText = "AMIS";
            dialog.Header.CloseBox.Visible = true;
            dialog.Moveable = false;
            
            HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
            createDiv.ID = "createDiv";

            if (message.Length > 400)
            {
                createDiv.Style.Value = "margin-top:10px; width:100%; height:90%; display: flex; text-align: center; justify-content:center";
            }
            else
            {
                createDiv.Style.Value = "width:100%; height:100%; display: flex; align-items: center; text-align: center; justify-content:center";
            }

            createDiv.InnerHtml = message;

            dialog.ContentPane.Controls.Add(createDiv);

            ((UpdatePanel)upanel).ContentTemplateContainer.Controls.Add(dialog);
        }

        public static bool ShowPopupErrorMessage(this Page page, string message)
        {
            ShowPopupMessage(page, message);
            return false;
        }

        public static void ShowSmallPopupMessage(this Page page, string message)
        {
            Control upanel = ControlRoutines.FindControlRecursive(page);
            if (upanel == null) return;

            WebDialogWindow dialog = new WebDialogWindow();
            dialog.Modal = true;
            dialog.WindowState = DialogWindowState.Normal;
            dialog.MaintainLocationOnScroll = true;
            dialog.InitialLocation = DialogWindowPosition.Centered;
            //dialog.Width = new System.Web.UI.WebControls.Unit("500px");
            //dialog.Height = new System.Web.UI.WebControls.Unit("200px");
            dialog.Font.Name = "Arial";
            dialog.Font.Size = new FontUnit("13px");
            dialog.Header.CloseBox.Visible = true;
            dialog.Moveable = false;

            HtmlGenericControl createDiv = new HtmlGenericControl("DIV");
            createDiv.ID = "createDiv";

            if (message.Length > 400)
            {
                createDiv.Style.Value = "margin-top:10px; width:100%; height:90%; display: flex; text-align: center; justify-content:center";
            }
            else
            {
                createDiv.Style.Value = "width:100%; height:100%; display: flex; align-items: center; text-align: center; justify-content:center";
            }

            createDiv.InnerHtml = message;

            dialog.ContentPane.Controls.Add(createDiv);

            ((UpdatePanel)upanel).ContentTemplateContainer.Controls.Add(dialog);
        }

        public static bool ShowSmallPopupErrorMessage(this Page page, string message)
        {
            ShowSmallPopupMessage(page, message);
            return false;
        }
        
        #endregion Page

        #region GridView

        public static DataTable GetDataTable(this GridView gridView)
        {
            DataTable dt = new DataTable();
            for (int j = 0; j < gridView.Rows.Count; j++)
            {
                DataRow dr;
                GridViewRow row = gridView.Rows[j];
                dr = dt.NewRow();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dr[i] = row.Cells[i].Text;
                }

                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static void LoadDataSource(this GridView gridView, object dataSource)
        {
            gridView.DataSource = null;
            gridView.DataBind();
            gridView.DataSource = dataSource;
            gridView.DataBind();
        }

        public static void CleanDataSource(this GridView gridView)
        {
            gridView.DataSource = null;
            gridView.DataBind();
        }

        #endregion GridView

        public static void SetTableList2(this WebDataGrid webDataGrid, BcUserMenuOption originClass,int userId)
        {
            webDataGrid.ClearDataSource();
            webDataGrid.Rows.Clear();
            webDataGrid.DataBind();
            webDataGrid.DataSource = originClass.GetPagesList(userId);
            webDataGrid.DataBind();
        }

        public static int UserId(this Page page)
        {
            return int.Parse(HttpContext.Current.Session["UserId"].ToString());
        }

        public static void SetUserId(this Page page, int userId)
        {
            HttpContext.Current.Session["UserId"] = userId;
        }

        public static void SetPageId (this Page page, int pageId)
        {
            HttpContext.Current.Session["MenuOptionId"] = pageId;
        }

        public static int PageId(this Page page)
        {
            return int.Parse(HttpContext.Current.Session["MenuOptionId"].ToString());
        }

        public static void ApplyUserPermissions(this Page page, int userId, int menuOptionId, HtmlControl tdSave, HtmlControl tdNew, HtmlControl tdGenerateReport, WebDataGrid toDelButton, string templateKey)
        {
            //En este metodo se recibe como parametro la pagina como tal, el id de usuario que lo entregaremos por la variable UserId (variable creada mediante metodo extendido),
            //la variable MenuOptionId la cual se recupera desde la base de datos, donde se debe reconocer el ID de la pagina en la cual estamos trabajando, y los demas parametros
            //de entrada son controles con los cuales interactuaremos en el siguiente metodo.
            string errorMessage = "";
            UserMenuOption userMenuOption = new BcUserMenuOption().GetUserMenuOptionById(menuOptionId, userId, out  errorMessage);
            if (userMenuOption.CanCreate == "Y")
            {
                tdSave.Visible = true;
                tdNew.Visible = true;
            } else
            {
                tdSave.Visible = false;
                tdNew.Visible = false;
            }
            if (userMenuOption.CanDelete == "Y")
            {
                toDelButton.FindColumn(templateKey).Hidden = false;
            } else
            {
                toDelButton.FindColumn(templateKey).Hidden = true;
            }
            if (userMenuOption.CanGenerateReport == "Y")
            {
                tdGenerateReport.Visible = true;
            } else
            {
                tdGenerateReport.Visible = false;
            }
        }
        public static void ApplyUserPermissionsWithoutDelete(this Page page, int userId, int menuOptionId, HtmlControl tdSave, HtmlControl tdNew, HtmlControl tdGenerateReport)
        {
            string errorMessage = "";
            UserMenuOption userMenuOption = new BcUserMenuOption().GetUserMenuOptionById(menuOptionId, userId, out errorMessage);
            if (userMenuOption.CanCreate == "Y")
            {
                tdSave.Visible = true;
                tdNew.Visible = true;
            }
            else
            {
                tdSave.Visible = false;
                tdNew.Visible = false;
            }
            if (userMenuOption.CanGenerateReport == "Y")
            {
                tdGenerateReport.Visible = true;
            }
            else
            {
                tdGenerateReport.Visible = false;
            }
        }

        public static bool VerifyLogin(this Page page)
        {
            if (HttpContext.Current.Session["UserId"] == null) return false;

            if (HttpContext.Current.Session["UserId"].ToString().Trim() == "") return false;

            return true;
        }

        public static void CheckLogin(this Page page)
        {
            if (!page.VerifyLogin()) HttpContext.Current.Response.Redirect("~/_PresentationLayer/Users/LoginPage.aspx");
        }

        public static string IdBarItem(this ExplorerBarItem barItem)
        {
            return barItem.Value;
        }

        static public string ConvertToHtmlEntityName(string text)
        {
            var html = text;
            html = html.Replace("À", "&Agrave;"); // capital a, grave accent
            html = html.Replace("Á", "&Aacute;"); // capital a, acute accent
            html = html.Replace("Â", "&Acirc;"); // capital a, circumflex accent
            html = html.Replace("Ã", "&Atilde;"); // capital a, tilde
            html = html.Replace("Ä", "&Auml;"); // capital a, umlaut mark
            html = html.Replace("Å", "&Aring;"); // capital a, ring
            html = html.Replace("Æ", "&AElig;"); // capital ae
            html = html.Replace("Ç", "&Ccedil;"); // capital c, cedilla
            html = html.Replace("È", "&Egrave;"); // capital e, grave accent
            html = html.Replace("É", "&Eacute;"); // capital e, acute accent
            html = html.Replace("Ê", "&Ecirc;"); // capital e, circumflex accent
            html = html.Replace("Ë", "&Euml;"); // capital e, umlaut mark
            html = html.Replace("Ì", "&Igrave;"); // capital i, grave accent
            html = html.Replace("Í", "&Iacute;"); // capital i, acute accent
            html = html.Replace("Î", "&Icirc;"); // capital i, circumflex accent
            html = html.Replace("Ï", "&Iuml;"); // capital i, umlaut mark
            html = html.Replace("Ð", "&ETH;"); // capital eth, Icelandic
            html = html.Replace("Ñ", "&Ntilde;"); // capital n, tilde
            html = html.Replace("Ò", "&Ograve;"); // capital o, grave accent
            html = html.Replace("Ó", "&Oacute;"); // capital o, acute accent
            html = html.Replace("Ô", "&Ocirc;"); // capital o, circumflex accent
            html = html.Replace("Õ", "&Otilde;"); // capital o, tilde
            html = html.Replace("Ö", "&Ouml;"); // capital o, umlaut mark
            html = html.Replace("Ø", "&Oslash;"); // capital o, slash
            html = html.Replace("Ù", "&Ugrave;"); // capital u, grave accent
            html = html.Replace("Ú", "&Uacute;"); // capital u, acute accent
            html = html.Replace("Û", "&Ucirc;"); // capital u, circumflex accent
            html = html.Replace("Ü", "&Uuml;"); // capital u, umlaut mark
            html = html.Replace("Ý", "&Yacute;"); // capital y, acute accent
            html = html.Replace("Þ", "&THORN;"); // capital THORN, Icelandic
            html = html.Replace("ß", "&szlig;"); // small sharp s, German
            html = html.Replace("à", "&agrave;"); // small a, grave accent
            html = html.Replace("á", "&aacute;"); // small a, acute accent
            html = html.Replace("â", "&acirc;"); // small a, circumflex accent
            html = html.Replace("ã", "&atilde;"); // small a, tilde
            html = html.Replace("ä", "&auml;"); // small a, umlaut mark
            html = html.Replace("å", "&aring;"); // small a, ring
            html = html.Replace("æ", "&aelig;"); // small ae
            html = html.Replace("ç", "&ccedil;"); // small c, cedilla
            html = html.Replace("è", "&egrave;"); // small e, grave accent
            html = html.Replace("é", "&eacute;"); // small e, acute accent
            html = html.Replace("ê", "&ecirc;"); // small e, circumflex accent
            html = html.Replace("ë", "&euml;"); // small e, umlaut mark
            html = html.Replace("ì", "&igrave;"); // small i, grave accent
            html = html.Replace("í", "&iacute;"); // small i, acute accent
            html = html.Replace("î", "&icirc;"); // small i, circumflex accent
            html = html.Replace("ï", "&iuml;"); // small i, umlaut mark
            html = html.Replace("ð", "&eth;"); // small eth, Icelandic
            html = html.Replace("ñ", "&ntilde;"); // small n, tilde
            html = html.Replace("ò", "&ograve;"); // small o, grave accent
            html = html.Replace("ó", "&oacute;"); // small o, acute accent
            html = html.Replace("ô", "&ocirc;"); // small o, circumflex accent
            html = html.Replace("õ", "&otilde;"); // small o, tilde
            html = html.Replace("ö", "&ouml;"); // small o, umlaut mark
            html = html.Replace("ø", "&oslash;"); // small o, slash
            html = html.Replace("ù", "&ugrave;"); // small u, grave accent
            html = html.Replace("ú", "&uacute;"); // small u, acute accent
            html = html.Replace("û", "&ucirc;"); // small u, circumflex accent
            html = html.Replace("ü", "&uuml;"); // small u, umlaut mark
            html = html.Replace("ý", "&yacute;"); // small y, acute accent
            html = html.Replace("þ", "&thorn;"); // small thorn, Icelandic
            html = html.Replace("ÿ", "&yuml;"); // small y, umlaut mark
            html = html.Replace("°", "&deg;");
            //html = html.Replace("±", "&plusmn;");
            //html = html.Replace("²", "&sup2;");
            //html = html.Replace("³", "&sup3;");
            //html = html.Replace("´", "&acute;");
            //html = html.Replace("µ", "&micro;");
            //html = html.Replace("¶", "&para;");
            //html = html.Replace("·", "&middot;");
            //html = html.Replace("¸", "&cedil;");
            //html = html.Replace("¹", "&sup1;");
            //html = html.Replace("º", "&ordm;");
            //html = html.Replace("»", "&raquo;");
            //html = html.Replace("¼", "&frac14;");
            //html = html.Replace("½", "&frac12;");
            //html = html.Replace("¾", "&frac34;");
            //html = html.Replace("¿", "&iquest;");
            //html = html.Replace(" ", "&nbsp;");
            //html = html.Replace("¡", "&iexcl;");
            //html = html.Replace("¢", "&cent;");
            //html = html.Replace("£", "&pound;");
            //html = html.Replace("¤", "&curren;");
            //html = html.Replace("¥", "&yen;");
            //html = html.Replace("¦", "&brvbar;");
            //html = html.Replace("§", "&sect;");
            //html = html.Replace("¨", "&uml;");
            //html = html.Replace("©", "&copy;");
            //html = html.Replace("ª", "&ordf;");
            //html = html.Replace("«", "&laquo;");
            //html = html.Replace("¬", "&not;");
            //html = html.Replace("-", "&shy;");
            //html = html.Replace("®", "&reg;");
            //html = html.Replace("¯", "&macr;");
            //html = html.Replace("×", "&times;");
            //html = html.Replace("÷", "&divide;");
            //html = html.Replace("þ", "&thorn;");
            //html = html.Replace("ÿ", "&yuml;");
            //html = html.Replace("€", "&euro;");
            return html;
        }

        public static void SetComboListToReport(this WebDropDown webDropDown, ITsDropDownList originClass, out string errorMessage)
        {
            errorMessage = "";

            webDropDown.ValueField = "ComboId";
            webDropDown.TextField = "ComboName";

            webDropDown.DataSource = "";
            webDropDown.DataBind();

            List<TsDropDownItem> originList = originClass.GetComboList(out errorMessage);
            List<TsDropDownItem> itemList = new List<TsDropDownItem>();
            TsDropDownItem selectItem = new TsDropDownItem() { ComboId = "0", ComboName = "Todos" };
            itemList.Add(selectItem);

            foreach (TsDropDownItem obj in originList)
            {
                TsDropDownItem newItem = new TsDropDownItem();
                newItem.ComboId = obj.ComboId;
                newItem.ComboName = obj.ComboName;
                itemList.Add(newItem);
            }


            webDropDown.DataSource = itemList;
            webDropDown.DataBind();
        }
    }
}
