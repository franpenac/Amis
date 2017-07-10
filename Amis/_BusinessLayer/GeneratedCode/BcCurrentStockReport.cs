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
using System.IO;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcCurrentStockReport
    {
        public const string cStrRowStart = "<!--ROW_START-->";
        public const string cStrRowEnd = "<!--ROW_END-->";

        public string GetXlsCurrentStockReport(List<AssetToCurrentReport> listaActivos, string BranchOffice, string WareHouse, string AssetType)
        {
            string errorMessage = "";
            try
            {
                string report = GetFileContent("CurrentStockReportSheet.aspx");

                report = report.Replace("<%@ Page Language=\"" + "C#\" AutoEventWireup=\"true\" CodeBehind=\"CurrentStockReportSheet.aspx.cs\" Inherits=\"amis._PresentationLayer.Report.CurrentStockReportSheet\" %>", "");

                if (BranchOffice != "" && WareHouse != "" && AssetType != "")
                {
                    report = report.Replace("%BRANCHOFFICE%", BranchOffice);
                    report = report.Replace("%WAREHOUSE%", WareHouse);
                    report = report.Replace("%ASSETTYPE%", AssetType);
                }else
                {
                    report = report.Replace("%BRANCHOFFICE%", "Todos");
                    report = report.Replace("%WAREHOUSE%", "Todos");
                    report = report.Replace("%ASSETTYPE%", "Todos");
                }

                int rowStart = report.IndexOf(cStrRowStart);
                int rowEnd = report.IndexOf(cStrRowEnd);

                string startText = report.Substring(0, rowStart);
                string rowText = report.Substring(rowStart + cStrRowStart.Length, rowEnd - rowStart - cStrRowStart.Length);
                string endText = report.Substring(rowEnd + cStrRowEnd.Length);

                string htmlRows = GetHtmlRowsXlsCurrentStockReport(rowText, listaActivos);
                string sReport = startText + htmlRows + endText;
                return sReport;
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return  "";
            }
        }

        public string GetHtmlRowsXlsCurrentStockReport(string rowText, List<AssetToCurrentReport> list)
        {
            string html = "";
            int index = 1;
        
            foreach (AssetToCurrentReport obj in list)
            {

                string htmlRow = rowText;
                htmlRow = htmlRow.Replace("#ASSETTYPE", obj.AssetTypeName);
                htmlRow = htmlRow.Replace("#BRANDNAME", obj.BrandName);
                htmlRow = htmlRow.Replace("#MODELNAME", obj.AssetModelName);
                htmlRow = htmlRow.Replace("#STOCK", obj.Stock.ToString());
                htmlRow = htmlRow.Replace("#WAREHOUSENAME", obj.WarehouseName);
                html += htmlRow + "\n";
                index++;
            }

            return html;
        }

        public string GetFileContent(string fileName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(@"~/_PresentationLayer/Report/");
            path += fileName;
            string text = File.ReadAllText(path);
            return text;
        }

        public List<AssetToCurrentReport> CurrentStockReportFiltered(int BranchOfficeId, int WareouseId, int AssetTypeId, out string errorMessage)
        {
            List<AssetToCurrentReport> list = new DcCurrentStockReport().CurrentStockReportFiltered(BranchOfficeId, WareouseId, AssetTypeId,out errorMessage);

            if (list == null || list.Count == 0)
            {
                errorMessage = "Su busqueda no ha dado resultados.";
                return null;
            }
            return list;
        }
    }
}