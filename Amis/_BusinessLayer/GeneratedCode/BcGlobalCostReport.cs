using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using amis.Models;
using amis._DataLayer.GeneratedCode;
using System.IO;
using amis._Common;
using System.Globalization;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcGlobalCostReport
    {
        public List<int> GetYearDetail()
        {
            List<int> years = new DcGlobalCostDetail().GetYearDetail();
            return years;
        }

        public List<Warehouse> GetWarehouseDetail()
        {
            List<Warehouse> Warehouses = new DcGlobalCostReport().GetWarehouseDetail();
            return Warehouses;
        }

        public const string cStrRowStart = "<!--ROW_START-->";

        public const string cStrRowEnd = "<!--ROW_END-->";

        public string GetFileContent(string fileName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(@"~/_PresentationLayer/Report/");
            path += fileName;
            string text = File.ReadAllText(path);
            return text;
        }

        public string GetHtmlRowsXlsGlobalCostReport(string rowText, List<GlobalCostReport> list, ref TotalGlobalCostReport total)
        {
            string html = "";
            int index = 1;

            CultureInfo culture = new CultureInfo("en-US");
            foreach (GlobalCostReport obj in list)
            {
                string htmlRow = rowText;

                String mont = MonthName(int.Parse(obj.Mount.Substring(0, obj.Mount.IndexOf("/")))).Substring(0, 1).ToUpper()
                    + MonthName(int.Parse(obj.Mount.Substring(0, obj.Mount.IndexOf("/")))).Substring(1);
                string year = obj.Mount.Substring(obj.Mount.IndexOf("/")+1);

                htmlRow = htmlRow.Replace("#MOUNT", mont+" Del "+ year);
                htmlRow = htmlRow.Replace("#UNITNEW", obj.UnitNew.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#COSTNEW", obj.CostNew.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#URETREA", obj.UnitRetreaiding.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#CRETREA", obj.CostRetrearding.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#RBASE", obj.UnitRBase.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#CBASE", obj.CostRBase.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#RTERRE", obj.UnitRTerrereno.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#CTERRE", obj.CostRTerreno.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#UDISP", obj.UnitDispTotal.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#CDISP", obj.CostDispTotal.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#UVENT", obj.UnitVentCasc.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#CVENT", obj.CostVentCasc.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#TOTALCOST", obj.TotalCost.ToString("#,##0"));
                htmlRow = htmlRow.Replace("#TOTALINGR", obj.TotalIngreso.ToString("#,##0"));
                
                htmlRow = htmlRow.Replace("#TOTALKM", int.Parse(obj.TotalKm.ToString()).ToString("#,##0"));
                htmlRow = htmlRow.Replace("#COSTKM", obj.CostKm.ToString());
                html += htmlRow + "\n";
                index++;
                
            }
            return html;
        }

        public string GetXlsGlobalCostReport(List<GlobalCostReport> listaActivos,string Warehouse, int Mount, int Year)
        {
            string errorMessage = "";
            try
            {
                string report = GetFileContent("GlobalCostSheet.aspx");

                report = report.Replace("<%@ Page Language=\"" + "C#\" AutoEventWireup=\"true\" CodeBehind=\"GlobalCostSheet.aspx.cs\" Inherits=\"amis._PresentationLayer.Report.GlobalCostSheet\" %>", "");

                if (Year != 0 && Warehouse != "Todos"  && Mount != 0)
                {
                    String mont = MonthName(int.Parse(Mount.ToString())).Substring(0, 1).ToUpper()
                    + MonthName(int.Parse(Mount.ToString())).Substring(1);
                    
                    report = report.Replace("%DATEFILTER%", mont + " Del "+Year.ToString());
                    report = report.Replace("%WAREHOUSE%", Warehouse);
                }
                else
                {
                    report = report.Replace("%DATEFILTER%", "Defecto");
                    report = report.Replace("%WAREHOUSE%", "Todos");
                }

                int rowStart = report.IndexOf(cStrRowStart);
                int rowEnd = report.IndexOf(cStrRowEnd);

                string startText = report.Substring(0, rowStart);
                string rowText = report.Substring(rowStart + cStrRowStart.Length, rowEnd - rowStart - cStrRowStart.Length);
                string endText = report.Substring(rowEnd + cStrRowEnd.Length);

                TotalGlobalCostReport total = new TotalGlobalCostReport();
                string htmlRows = GetHtmlRowsXlsGlobalCostReport(rowText, listaActivos, ref total);
                string sReport = startText + htmlRows + endText;
                return sReport;
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return "";
            }
        }

        public string GetFilterCurrentStockReport()
        {
            string report = GetFileContent("GlobalCostSheet.aspx");
            report = report.Replace("<%@ Page Language=\"" + "C#\" AutoEventWireup=\"true\" CodeBehind=\"GlobalCostSheet.aspx.cs\" Inherits=\"amis._PresentationLayer.Report.GlobalCostSheet\" %>", "");
            return report;
        }

        public List<GlobalCostReport> GetListReportDontFilter(int month, int year)
        {
            List<Asset> ListAsset = new DcGlobalCostReport().GetListReportDontFilter(month, year);
            List<GlobalCostReport> Report = GetListWithDate(month, year);
            List<GlobalCostDetail> ListCost = new DcGlobalCostReport().GetListReport(month, year);

            //Prueba
            foreach (var rep in Report)
            {
                string reportDate = rep.Mount.Substring(0, rep.Mount.IndexOf("/"));
                foreach (var asset in ListAsset)
                {
                    int assetDate = asset.WarrantyStartDate.Month;

                    if (assetDate == int.Parse(reportDate))
                    {
                        String New = new DcGlobalCostReport().GetTypeTyre(asset.AssetUniqueIdentificationId);
                        if (New == "Y")
                        {
                            rep.CostNew = rep.CostNew+int.Parse(asset.Cost.ToString());
                            rep.UnitNew = rep.UnitNew + 1;

                        }
                        if (New == "N")
                        {
                            rep.CostRetrearding = rep.CostRetrearding+int.Parse(asset.Cost.ToString());
                            rep.UnitRetreaiding = rep.UnitRetreaiding + 1;
                        }
                        rep.TotalKm = rep.TotalKm + asset.Kilometers;
                    }
                }

                foreach(var cost in ListCost)
                {
                    if (cost.Month.Month == int.Parse(reportDate))
                    {
                        switch (cost.GlobalCostId)
                        {
                            case 3:
                                rep.CostRBase = int.Parse(cost.Cost.ToString());
                                rep.UnitRBase = int.Parse(cost.CountUnit.ToString());
                                break;
                            case 4:
                                rep.CostRTerreno = int.Parse(cost.Cost.ToString());
                                rep.UnitRTerrereno = int.Parse(cost.CountUnit.ToString());
                                break;
                            case 5:
                                rep.CostDispTotal = int.Parse(cost.Cost.ToString());
                                rep.UnitDispTotal = int.Parse(cost.CountUnit.ToString());
                                break;
                            case 6:
                                rep.CostVentCasc = int.Parse(cost.Cost.ToString());
                                rep.UnitVentCasc = int.Parse(cost.CountUnit.ToString());
                                break;
                            default:
                                break;
                        }
                    }
                }
                rep.TotalCost = rep.CostDispTotal + rep.CostNew + rep.CostRBase + rep.CostRetrearding + rep.CostRTerreno + rep.CostVentCasc;
                rep.TotalIngreso = rep.CostVentCasc;
                if (rep.TotalKm>0)
                {
                    rep.CostKm = float.Parse((((rep.TotalCost - rep.TotalIngreso) / rep.TotalKm).ToString()).Substring(0,4));
                }
                else
                {
                    rep.CostKm = 0;
                }
                
            }
            //
            return Report;
        }

        public List<GlobalCostReport> GetListReportFilterWarehouse(int warehouseId,int month, int year)
        {
            List<Asset> ListAsset = new DcGlobalCostReport().GetListReportFilterWarehouse(warehouseId,month, year);
            List<GlobalCostReport> Report = GetListWithDate(month, year);
            List<GlobalCostDetail> ListCost = new DcGlobalCostReport().GetListReport(month, year);

            //Prueba
            foreach (var rep in Report)
            {
                string reportDate = rep.Mount.Substring(0, rep.Mount.IndexOf("/"));
                foreach (var asset in ListAsset)
                {
                    int assetDate = asset.WarrantyStartDate.Month;

                    if (assetDate == int.Parse(reportDate))
                    {
                        String New = new DcGlobalCostReport().GetTypeTyre(asset.AssetUniqueIdentificationId);
                        if (New == "Y")
                        {
                            rep.CostNew = rep.CostNew + int.Parse(asset.Cost.ToString());
                            rep.UnitNew = rep.UnitNew + 1;

                        }
                        if (New == "N")
                        {
                            rep.CostRetrearding = rep.CostRetrearding + int.Parse(asset.Cost.ToString());
                            rep.UnitRetreaiding = rep.UnitRetreaiding + 1;
                        }
                        rep.TotalKm = rep.TotalKm + asset.Kilometers;
                    }
                }

                foreach (var cost in ListCost)
                {
                    if (cost.Month.Month == int.Parse(reportDate))
                    {
                        switch (cost.GlobalCostId)
                        {
                            case 3:
                                rep.CostRBase = int.Parse(cost.Cost.ToString());
                                rep.UnitRBase = int.Parse(cost.CountUnit.ToString());
                                break;
                            case 4:
                                rep.CostRTerreno = int.Parse(cost.Cost.ToString());
                                rep.UnitRTerrereno = int.Parse(cost.CountUnit.ToString());
                                break;
                            case 5:
                                rep.CostDispTotal = int.Parse(cost.Cost.ToString());
                                rep.UnitDispTotal = int.Parse(cost.CountUnit.ToString());
                                break;
                            case 6:
                                rep.CostVentCasc = int.Parse(cost.Cost.ToString());
                                rep.UnitVentCasc = int.Parse(cost.CountUnit.ToString());
                                break;
                            default:
                                break;
                        }
                    }
                }
                rep.TotalCost = rep.CostDispTotal + rep.CostNew + rep.CostRBase + rep.CostRetrearding + rep.CostRTerreno + rep.CostVentCasc;
                rep.TotalIngreso = rep.CostVentCasc;
                if (rep.TotalKm > 0)
                {
                    rep.CostKm = float.Parse((((rep.TotalCost - rep.TotalIngreso) / rep.TotalKm).ToString()).Substring(0, 3));
                }
                else
                {
                    rep.CostKm = 0;
                }

            }
            //
            return Report;
        }

        public List<GlobalCostReport> GetListWithDate(int month, int year)
        {
            
            //Creacion de objetos seteados solo con fechas

            List<GlobalCostReport> list = new List<GlobalCostReport>();
            for (int i = month; i < 13; i++)
            {
                GlobalCostReport obj = new GlobalCostReport();

                obj.Mount = i.ToString() + "/" + year.ToString();
                list.Add(obj);
            }
            year = year + 1;
            for (int i = 1; i < month; i++)
            {
                GlobalCostReport obj = new GlobalCostReport();

                obj.Mount = i.ToString() + "/" + year.ToString();
                list.Add(obj);
            }
            //Termino de creacion de fechas

            return list;
        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }
    }
}