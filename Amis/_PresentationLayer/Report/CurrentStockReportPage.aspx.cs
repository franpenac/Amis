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

namespace amis._PresentationLayer.Report
{
    public partial class CurrentStockReportPage : System.Web.UI.Page
    {
        public const string cStrRowStart = "<!--initHeader-->";
        public const string cStrRowEnd = "<!--endHeader-->";

        protected int BranchOfficeId
        {
            get
            {
                if (wddBranchOffice.SelectedValue == "")
                {
                    return 0;
                }
                else
                {
                    return int.Parse(wddBranchOffice.SelectedValue);
                }
            }
            set
            {
                wddBranchOffice.SelectedValue = value.ToString();
            }
        }

        protected int WarehouseId
        {
            get
            {
                if (wddWarehouse.SelectedValue == "")
                {
                    return 0;
                }
                else
                {
                    return int.Parse(wddWarehouse.SelectedValue);
                }
            }
            set
            {
                wddWarehouse.SelectedValue = value.ToString();
            }
        }

        protected int AssetTypeId
        {
            get
            {
                if (wddAssetType.SelectedValue == "")
                {
                    return 0;
                }
                else
                {
                    return int.Parse(wddAssetType.SelectedValue);
                }
            }
            set
            {
                wddAssetType.SelectedValue = value.ToString();
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(710);
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
                wddBranchOffice.SetComboListToReport(new BcBranchOffice(), out errorMessage);
                wddBranchOffice.SelectedValue = "0";
                wddWarehouse.SetComboListToReport(new BcWarehouse(), out errorMessage);
                wddWarehouse.SelectedValue = "0";
                wddAssetType.SetComboListToReport(new BcAssetType(), out errorMessage);
                wddAssetType.SelectedValue = "0";
            }
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            wddBranchOffice.SelectedValue = "0";
            wddWarehouse.SelectedValue = "0";
            wddAssetType.SelectedValue = "0";
            divReport.InnerText = "";
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

        protected void wddBranchOffice_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            wddWarehouse.SelectedValue = "0";
            string errorMessage = "";
            int id = 0;
            if (wddBranchOffice.SelectedValue != "") id = int.Parse(wddBranchOffice.SelectedValue);
            wddWarehouse.SetComboListByFiltrer(new BcWarehouse(), id, out errorMessage);
        }

        protected void GetFilterParameterCurrentStockReport(ref int BranchOfficeId, ref int WarehouseId, ref int AssetTypeId)
        {
            BranchOfficeId = int.Parse(wddBranchOffice.SelectedValue);
            WarehouseId = int.Parse(wddWarehouse.SelectedValue);
            AssetTypeId = int.Parse(wddAssetType.SelectedValue);
        }

        protected void wibSearchResults_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            divReport.InnerHtml = "";
            string errorMessage = "";
            List<AssetToCurrentReport> list = new BcCurrentStockReport().CurrentStockReportFiltered(BranchOfficeId, WarehouseId, AssetTypeId, out errorMessage);
            if (list == null || list.Count == 0)
            {
                Page.ShowPopupMessage(errorMessage);
                wddBranchOffice.SelectedValue = "0";
                wddWarehouse.SelectedValue = "0";
                wddAssetType.SelectedValue = "0";
                divReport.InnerText = "";
            }
            else
            {
                string report = new BcCurrentStockReport().GetXlsCurrentStockReport(list, wddBranchOffice.SelectedItem.Text, wddWarehouse.SelectedItem.Text, wddAssetType.SelectedItem.Text);
                int TotalStock = 0;
                foreach (AssetToCurrentReport item in list)
                {
                    TotalStock = TotalStock + item.Stock;
                }
                report = report.Replace("#TOTALSTOCK", TotalStock.ToString());

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