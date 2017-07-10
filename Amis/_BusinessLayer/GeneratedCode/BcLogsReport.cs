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
    public class BcLogsReport : ITsDropDownList
    {
        public const string cStrRowStart = "<!--ROW_START-->";
        public const string cStrRowEnd = "<!--ROW_END-->";

        public string GetXlsLogsPage(List<LogsObject> listaLogs, string userName, string menuOption, string action, string initDate, string endDate)
        {
            string errorMessage = "";
            try
            {
                string report = GetFileContent("LogsReportSheet.aspx");
                report = report.Replace("<%@ Page Language=\"" + "C#\" AutoEventWireup=\"true\" CodeBehind=\"LogsReportSheet.aspx.cs\" Inherits=\"amis._PresentationLayer.Report.LogsReportSheet\" %>", "");

                if (userName != "" && menuOption != "" && action != "" && initDate != "" && endDate != "")
                {
                    report = report.Replace("%USER%", userName);
                    report = report.Replace("%MENUOPTION%", menuOption);
                    report = report.Replace("%ACTION%", action);
                    string formatDate = initDate + "-" + endDate;
                    report = report.Replace("%DATE%", formatDate);
                }else
                {
                    report = report.Replace("%USER%", "Todos");
                    report = report.Replace("%MENUOPTION%", "Todas");
                    report = report.Replace("%ACTION%", "Todas");
                    report = report.Replace("%DATE%", "Todas");
                }

                int rowStart = report.IndexOf(cStrRowStart);
                int rowEnd = report.IndexOf(cStrRowEnd);

                string startText = report.Substring(0, rowStart);
                string rowText = report.Substring(rowStart + cStrRowStart.Length, rowEnd - rowStart - cStrRowStart.Length);
                string endText = report.Substring(rowEnd + cStrRowEnd.Length);

                string htmlRows = GetHtmlRowsXlsLogsReport(rowText, listaLogs);
                string sReport = startText + htmlRows + endText;
                return sReport;
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return "";
            }
        }

        public string GetHtmlRowsXlsLogsReport(string rowText, List<LogsObject> list)
        {
            string html = "";
            int index = 1;

            foreach (LogsObject obj in list)
            {

                string htmlRow = rowText;
                htmlRow = htmlRow.Replace("#USEREMAIL", obj.UserEmail);
                htmlRow = htmlRow.Replace("#USERNAME", obj.UserName);
                htmlRow = htmlRow.Replace("#MENUOPTION", obj.MenuOption);
                htmlRow = htmlRow.Replace("#ACTION", obj.Action);
                htmlRow = htmlRow.Replace("#DATE", obj.ActionDate.ToString());
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

        public List<LogsObject> LogsReportReportFiltered(int userId, int menuOptionId, int actionId, DateTime initDate, DateTime endDate ,out string errorMessage)
        {
            List<LogsObject> list = new DcLogsReport().LogsReportFiltered(userId, menuOptionId, actionId, initDate, endDate, out errorMessage);

            if (list == null || list.Count == 0)
            {
                errorMessage = "Su busqueda no ha dado resultados.";
                return null;
            }
            return list;
        }

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcLogsReport().GetComboActionList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}