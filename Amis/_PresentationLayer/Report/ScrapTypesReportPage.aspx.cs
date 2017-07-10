using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;

namespace amis._PresentationLayer.Report
{
    public partial class ScraptTypesReportPage : System.Web.UI.Page
    {
        public const string cStrRowStart = "<!--initHeader-->";
        public const string cStrRowEnd = "<!--endHeader-->";


        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int AssetId
        {
            get
            {
                if (ViewState["AssetPage_AssetId"] == null)
                {
                    ViewState["AssetPage_AssetId"] = 0;
                }
                int id = int.Parse(ViewState["AssetPage_AssetId"].ToString());
                return id;
            }
            set
            {
                ViewState["AssetPage_AssetId"] = value;
            }
        }

        protected int PageId
        {
            get
            {
                int pageId = 26;
                return pageId;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(708);
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

        protected void InitializeControls()
        {
            if (!IsPostBack)
            {
                string errorMessage = "";
                wddOPeration.SetComboList(new BcOperation(), out errorMessage);
                wddOPeration.SelectedValue = "0";
                wddAssetType.SetComboList(new BcAssetType(), out errorMessage);
                wddAssetType.SelectedValue = "0";
                wddPeriodYear.DataSource = new BcScrapTypesReport().GetScraptEventYears();
                wddPeriodYear.SelectedValue = "0";
                wddPeriodYear.DataBind();

            }
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            divReport.InnerHtml = "";
            wteAssetId.Text = "";
            wddOPeration.SelectedValue = "0";
            wddAssetType.SelectedValue = "0";
            wddPeriodMonth.SelectedValue = "0";
            wddPeriodYear.SelectedValue = "0";
        }

        #endregion Eventos de controles graficos

        #region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void ExportToExcel()
        {

        }



        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void wibSearchResults_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            divReport.InnerHtml = "";
            if (wddAssetType.SelectedValue != "0")
            {
                if (wddPeriodMonth.SelectedValue != "0" && wddPeriodYear.SelectedValue != "0")
                {
                    string errorMessage = "";
                    DateTime newDate = Convert.ToDateTime(wddPeriodYear.SelectedItem.Text + "-" + wddPeriodMonth.SelectedValue + "-" + 01);
                    string id = (wteAssetId.Text == "") ? "0" : wteAssetId.Text;
                    List<AssetToScraptTypesReport> list = new BcScrapTypesReport().ScraptTypesReportFiltered(int.Parse(id), int.Parse(wddOPeration.SelectedValue), int.Parse(wddAssetType.SelectedValue), newDate, out errorMessage);
                    if (list == null || list.Count == 0)
                    {
                        Page.ShowPopupMessage(errorMessage);
                    }
                    else
                    {

                        string report = new BcScrapTypesReport().GetXlsScrapTypeReport(list, wteAssetId.Text, wddOPeration.SelectedItem.Text, wddAssetType.SelectedItem.Text, newDate, int.Parse(wddAssetType.SelectedValue));

                        ViewState["reportToExport"] = report;

                        int rowStart = report.IndexOf(cStrRowStart);
                        int rowEnd = report.IndexOf(cStrRowEnd);
                        string startText = report.Substring(0, rowStart);
                        string rowText = report.Substring(rowStart + cStrRowStart.Length, rowEnd - rowStart - cStrRowStart.Length);
                        report = report.Replace(rowText, "");
                        divReport.InnerHtml = report;
                    }
                }
                else
                {
                    Page.ShowPopupMessage("Debe seleccionar obligatoriamente mes/año");
                }

            }else
            {
                Page.ShowPopupMessage("Debe seleccionar obligatoriamente un tipo de activo.");
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
    }
}
