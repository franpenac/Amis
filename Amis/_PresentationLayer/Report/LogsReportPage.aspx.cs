using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Infragistics.Web.UI.ListControls;
using System.Web;
using Infragistics.Documents.Excel;
using Infragistics.Web.UI.EditorControls;

namespace amis._PresentationLayer.Report
{
    public partial class LogsReportPage : System.Web.UI.Page
    {
        public const string cStrRowStart = "<!--initHeader-->";
        public const string cStrRowEnd = "<!--endHeader-->";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(713);
            h1OptionMenuPageName.InnerText = new BcMenuOption().GetMenuOptionById(int.Parse(Session["MenuOptionId"].ToString())).Name;

            this.CheckLogin();
            if (new BcUserMenuOption().ValidUserToPage(this.PageId(), this.UserId()))
            {
                this.ApplyUserPermissionsWithoutDelete(this.UserId(), this.PageId(), tdSearch, tdNew, tdExportExcel);
                InitializeControls();
            }
            else
            {
                Response.Redirect("~/_PresentationLayer/Configuration/AmisHomePage.aspx");
            }
        }

        private void InitializeControls()
        {
            if (!IsPostBack)
            {
                string errorMessage = "";
                wddUser.SetComboList(new BcAmisUser(), out errorMessage);
                wddUser.SelectedValue = "0";
                wddMenuOption.SetComboList(new BcMenuOption(), out errorMessage);
                wddMenuOption.SelectedValue = "0";
                wddAction.SetComboList(new BcLogsReport(), out errorMessage);
                wddAction.SelectedValue = "0";
            }
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            wddUser.SelectedValue = "0";
            wddMenuOption.SelectedValue = "0";
            wddAction.SelectedValue = "0";
            wdpInitDate.Date = DateTime.Today;
            wdpEndDate.Date = DateTime.Today;
            divReport.InnerText = "";
        }

        protected void wibExportExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string report = (string)ViewState["reportToExport"];
            if (report == null || report == "\r\n                " || report == "")
            {
                Page.ShowPopupMessage("No hay datos que exportar.");
            }else
            {
                Session["DownloadDocumentParameters"] = report + Convert.ToChar(206) + "xls";
                Response.Redirect("DocumentDownloader.aspx");
            }
        }

        protected void wibSearchResults_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            divReport.InnerHtml = "";
            if (wdpInitDate.Date == Convert.ToDateTime("01/01/0001 0:00:00") && wdpInitDate.Date == Convert.ToDateTime("01/01/0001 0:00:00"))
            {
                Page.ShowPopupMessage("Debe seleccionar obligatoriamente fecha/termino");
            }else
            {
                string errorMessage = "";
                List<LogsObject> list = new BcLogsReport().LogsReportReportFiltered(int.Parse(wddUser.SelectedValue), int.Parse(wddMenuOption.SelectedValue), int.Parse(wddAction.SelectedValue), wdpInitDate.Date, wdpEndDate.Date, out errorMessage);
                if (list == null || list.Count == 0)
                {
                    Page.ShowPopupMessage(errorMessage);
                }
                else
                {
                    string initD = wdpInitDate.Date.Day + "/" + wdpInitDate.Date.Month + "/" + wdpInitDate.Date.Year;
                    string endD = wdpEndDate.Date.Day + "/" + wdpEndDate.Date.Month + "/" + wdpEndDate.Date.Year;
                    string report = new BcLogsReport().GetXlsLogsPage(list, wddUser.SelectedItem.Text, wddMenuOption.SelectedItem.Text, wddAction.SelectedItem.Text, initD, endD);

                    ViewState["reportToExport"] = report;

                    int rowStart = report.IndexOf(cStrRowStart);
                    int rowEnd = report.IndexOf(cStrRowEnd);
                    string startText = report.Substring(0, rowStart);
                    string rowText = report.Substring(rowStart + cStrRowStart.Length, rowEnd - rowStart - cStrRowStart.Length);
                    report = report.Replace(rowText, "");

                    divReport.InnerHtml = report;
                }
            }
        }
    }
}