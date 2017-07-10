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
using System.Web.UI.HtmlControls;

namespace amis._PresentationLayer.Report
{
    public partial class ModelPurchasedReportPage : System.Web.UI.Page
    {
        public const string cStrRowStart = "<!--initHeader-->";
        public const string cStrRowEnd = "<!--endHeader-->";

        protected int ProviderId
        {
            get
            {
                if (wddProvider.SelectedValue == "")
                {
                    return 0;
                }
                else
                {
                    return int.Parse(wddProvider.SelectedValue);
                }
            }
            set
            {
                wddProvider.SelectedValue = value.ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(707);
            h1OptionMenuPageName.InnerText = new BcMenuOption().GetMenuOptionById(int.Parse(Session["MenuOptionId"].ToString())).Name;

            this.CheckLogin();
            if (new BcUserMenuOption().ValidUserToPage(this.PageId(), this.UserId()))
            {
                this.ApplyUserPermissionsWithoutDelete(this.UserId(), this.PageId(), tdFilter, tdNewSearch, tdExportExcel);
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
                DropDownItem it = new DropDownItem();
                it.Text = "Todos";
                it.Value = "0";
                wddProvider.Items.Add(it);

                DropDownItem it2 = new DropDownItem();
                it2.Text = "Seleccione el año";
                it2.Value = "0";
                wddYear.Items.Add(it2);

                foreach (var item in new BcModelPurchaseReport().GetComboProvider())
                {
                    DropDownItem mem = new DropDownItem();
                    mem.Text = item.MemberName;
                    mem.Value = item.MemberId.ToString();
                    wddProvider.Items.Add(mem);
                }

                foreach (var item in new BcGlobalCostReport().GetYearDetail())
                {
                    DropDownItem year = new DropDownItem();
                    year.Text = item.ToString();
                    year.Value = item.ToString();
                    wddYear.Items.Add(year);
                }
                wddYear.DataBind();
                wddMount.SelectedValue = "0";
                wddYear.SelectedValue = "0";
                wddProvider.SelectedValue = "0";
                tdExportExcel.Visible = false;

            }
        }

        protected void wibExportExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {

            string report = (string)ViewState["reportToExport"];
            if (report == null || report == "\r\n                " || report == "")
            {
                Page.ShowPopupMessage("No hay datos que exportar.");
            }
            else
            {
                Session["DownloadDocumentParameters"] = report + Convert.ToChar(206) + "xls";
                Response.Redirect("DocumentDownloader.aspx");

            }


        }

        protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {

        }

        protected void wibBuscar_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string errorMessage = "";
            if (ValidateControlsSearch(out errorMessage))
            {
                
                if (wddProvider.SelectedValue == "0")
                {
                    string report = new BcModelPurchaseReport().GetXlsModelPurchaseReportDontFilter(wddProvider.SelectedItem.Text, int.Parse(wddMount.SelectedValue), int.Parse(wddYear.SelectedValue));
                    if ("Listado 0"== report)
                    {
                        Page.ShowPopupMessage("No hay registro de compras de este proveedor en las determinadas fechas");
                        divReport.InnerHtml = "";
                        tdExportExcel.Visible = false;
                    }
                    else
                    {
                        ViewState["reportToExport"] = report;

                        int rowStart = report.IndexOf(cStrRowStart);
                        int rowEnd = report.IndexOf(cStrRowEnd);
                        string startText = report.Substring(0, rowStart);
                        string rowText = report.Substring(rowStart + cStrRowStart.Length, rowEnd - rowStart - cStrRowStart.Length);
                        report = report.Replace(rowText, "");

                        divReport.InnerHtml = report;
                        tdExportExcel.Visible = true;
                    }
                    
                }
                else
                {
                    string report = new BcModelPurchaseReport().GetXlsModelPurchaseReportByFilter(wddProvider.SelectedItem.Text, int.Parse(wddMount.SelectedValue), int.Parse(wddYear.SelectedValue));
                    if ("Listado 0" == report)
                    {
                        Page.ShowPopupMessage("No hay registro de compras dentro de estas fechas");
                        divReport.InnerHtml = "";
                        tdExportExcel.Visible = false;
                    }
                    else
                    {
                        ViewState["reportToExport"] = report;

                        int rowStart = report.IndexOf(cStrRowStart);
                        int rowEnd = report.IndexOf(cStrRowEnd);
                        string startText = report.Substring(0, rowStart);
                        string rowText = report.Substring(rowStart + cStrRowStart.Length, rowEnd - rowStart - cStrRowStart.Length);
                        report = report.Replace(rowText, "");

                        divReport.InnerHtml = report;
                        tdExportExcel.Visible = true;
                    }
                }
            }
            else
            {
                Page.ShowPopupMessage(errorMessage);
            }
        }

        protected bool ValidateControlsSearch(out string errorMessage)
        {
            errorMessage = "";
            if (wddMount.SelectedValue == "0")
            {
                errorMessage = "Debe seleccionar el mes para realizar la busqueda";
                return false;
            }
            if (wddYear.SelectedValue == "0")
            {
                errorMessage = "Debe seleccionar el año para realizar la busqueda";
                return false;
            }
            return true;
        }

    }
}