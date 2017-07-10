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
using System.Globalization;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcScrapTypesReport
    {

        public const string cStrColumnStart = "<!--COLUMN_START-->";

        public const string cStrColumnEnd = "<!--COLUMN_END-->";

        public const string cStrHeaderStart = "<!--HEADER_START-->";

        public const string cStrHeaderEnd = "<!--HEADER_END-->";

        List<TotalCount> listaTotal = new List<TotalCount>();

        public string GetXlsScrapTypeReport(List<AssetToScraptTypesReport> listaActivosScrapeados, string AssetId, string Operation, string AssetType, DateTime Periodo, int assetTypeId)
        {
            string errorMessage = "";
            List<ScrapTypesNames> listaScrapTypes = new DcScrapTypesReport().GetAssetScrypeTypes(assetTypeId);
            try
            {
                string report = GetFileContent("ScrapTypesReportSheet.aspx");
                report = report.Replace("<%@ Page Language=\"" + "C#\" AutoEventWireup=\"true\" CodeBehind=\"ScrapTypesReportSheet.aspx.cs\" Inherits=\"amis._PresentationLayer.Report.ScrapTypesReportSheet\" %>", "");

                if (AssetId == "" || Operation == "Seleccionar")
                {
                    report = report.Replace("%ASSETID%", "-");
                    report = report.Replace("%OPERATION%", "-");
                    report = report.Replace("%ASSETTYPE%", AssetType);
                    string FilterDate = string.Format(MonthName(Periodo.Month) + "-" + Periodo.Year);
                    report = report.Replace("%PERIOD%", FilterDate);
                }else
                { 
                    report = report.Replace("%ASSETID%", AssetId);
                    report = report.Replace("%OPERATION%", Operation);
                    report = report.Replace("%ASSETTYPE%", AssetType);
                    string FilterDate = string.Format(MonthName(Periodo.Month) + "-" + Periodo.Year);
                    report = report.Replace("%PERIOD%", FilterDate);
                }


                int rowStart = report.IndexOf(cStrHeaderStart);
                int rowEnd = report.IndexOf(cStrHeaderEnd);

                string startText = report.Substring(0, rowStart);
                string rowText = report.Substring(rowStart + cStrHeaderStart.Length, rowEnd - rowStart - cStrHeaderStart.Length);
                string endText = report.Substring(rowEnd + cStrHeaderEnd.Length);
                
                string htmlRows = GetHtmlHeadersXlsScrapTypesReport(listaScrapTypes, rowText);
                string sReport = startText + htmlRows + endText;

                // colmun

                rowStart = sReport.IndexOf(cStrColumnStart);
                rowEnd = sReport.IndexOf(cStrColumnEnd);

                startText = sReport.Substring(0, rowStart);
                rowText = sReport.Substring(rowStart + cStrColumnStart.Length, rowEnd - rowStart - cStrColumnStart.Length);
                endText = sReport.Substring(rowEnd + cStrColumnEnd.Length);

                List<DateTime> lista = listaFechas(Periodo.Month, Periodo.Year);
                htmlRows = GetHtmlRowsXlsScrapTypesReport(listaScrapTypes, rowText, lista, listaActivosScrapeados);
                sReport = startText + htmlRows + endText;

                return sReport;
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return "";
            }
        }

        public string GetHtmlHeadersXlsScrapTypesReport(List<ScrapTypesNames> list, string rowText)
        {
            string html = "";
            foreach (ScrapTypesNames item in list)
            {
                string htmlRow = rowText;
                htmlRow = "<td style =\"border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white\">" + item.ScrapName + "</td>";
                html = html + htmlRow;
            }
            return html;
        }

        public string GetHtmlRowsXlsScrapTypesReport(List<ScrapTypesNames> listaScrapTypesNames, string rowText, List<DateTime> fechas, List<AssetToScraptTypesReport> listDatos)
        {

            foreach (var item in listaScrapTypesNames)
            {
                TotalCount tot = new TotalCount();
                tot.TotalScrapType = item.ScrapName;
                listaTotal.Add(tot);
            }
            string html = "";
            foreach (DateTime item in fechas)
            {
                string monthName = MonthName(item.Month);
                string shortMonthName = monthName.Substring(0,3);
                string dateToReport = shortMonthName + "-" + item.Year;
                string htmlRow = rowText;
                htmlRow = "<td style =\"border:solid 1px; width:100px\">" + dateToReport + "</td>";
                html = html + htmlRow;
                int countTotalRight = 0;
                foreach (ScrapTypesNames item2 in listaScrapTypesNames)
                {
                    int count = 0;
                    foreach (AssetToScraptTypesReport item3 in listDatos)
                    {
                        if (item3.ScrapTypeName == item2.ScrapName && item3.DateScraped.Month == item.Date.Month)
                        {
                            count++;
                        }
                    }
                    countTotalRight = countTotalRight + count;
                    foreach (var tot in listaTotal)
                    {
                        if (tot.TotalScrapType==item2.ScrapName)
                        {
                            tot.FinalCount = tot.FinalCount+count;
                        }
                    }
                    htmlRow = "<td style =\"border:solid 1px; text-align:right; width:100px\">" + count.ToString() + "</td>";
                    html = html + htmlRow;
                }
                htmlRow = "<td style =\"border:solid 1px; text-align:right; width:100px\">" + countTotalRight + "</td>";
                html += htmlRow + "\n";
                htmlRow = "</tr><tr>" + "\n";
                html += htmlRow + "\n";
            }
            html = html + "<td style =\"border:solid 1px; width:100px; text-align:left; background-color:#2F75B5;color:white\">" + "Total" + "</td>";
            foreach (var item in listaTotal)
            {
                string totalC =item.FinalCount.ToString();
                html = html + "<td style =\"border:solid 1px; text-align:right; width:100px\">" + totalC + "</td>";
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

        public List<AssetToScraptTypesReport> ScraptTypesReportFiltered(int assetId, int assetOperation, int assetType, DateTime period, out string errorMessage)
        {
            List<AssetToScraptTypesReport> list = new DcScrapTypesReport().ScraptTypesReportFiltered(assetId, assetOperation, assetType, period, out errorMessage);
            if (list == null || list.Count == 0)
            {
                errorMessage = "Su busqueda no ha dado resultados.";
                return null;
                
            }else
            {
                return list;
            }
        }

        public List<string> GetScraptEventYears()
        {
            List<string> list = new DcScrapTypesReport().GetScraptEvenYears();
            list.Insert(0, "Seleccione");
            return list;
        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        public List<DateTime> listaFechas(int month, int year)
        {
            List<DateTime> list = new List<DateTime>();
            for (int i = month; i < 13; i++)
            {
                DateTime dt = Convert.ToDateTime("01-"+i+"-"+year);
                list.Add(dt);
            }
            year = year + 1;
            for (int i = 1; i < month; i++)
            {
                DateTime dt = Convert.ToDateTime("01-" + i + "-" + year);
                list.Add(dt);
            }
            //Termino de creacion de fechas

            return list;
        }
    }
}