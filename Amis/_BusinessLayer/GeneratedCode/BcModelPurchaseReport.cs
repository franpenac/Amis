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
    public class BcModelPurchaseReport
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

        public const string cStrColumnStart = "<!--COLUMN_START-->";

        public const string cStrColumnEnd = "<!--COLUMN_END-->";

        public const string cStrHeaderStart = "<!--HEADER_START-->";

        public const string cStrHeaderEnd = "<!--HEADER_END-->";

        public string GetFileContent(string fileName)
        {
            string path = System.Web.HttpContext.Current.Server.MapPath(@"~/_PresentationLayer/Report/");
            path += fileName;
            string text = File.ReadAllText(path);
            return text;
        }

        public string GetHtmlModelXlsModelPurchaseReport(string rowText, List<int> list, List<ModelPurchaseReport> fechas)
        {
            string html = "";
            foreach (var item in fechas)
            {
                string htmlRow = rowText;


                int valor1 = int.Parse(item.Mont.Substring(0, item.Mont.IndexOf("/")));
                string valor2 = item.Mont.Substring(item.Mont.IndexOf("/")+1);

                String mont = MonthName(valor1).Substring(0, 1).ToUpper()
                + MonthName(valor1).Substring(1);
                //string mont = MonthName(valor1);
                List<DispatchProviderDocumentItem> ListItems = new DcModelPurchaseReport().GetReportDontFilter(valor1, int.Parse(valor2));

                htmlRow = "<td style =\"border:solid 1px; width:100px\">"+mont+" de "+valor2+"</td>";
                html += htmlRow + "\n";
                int total = 0;
                foreach (var num in list)
                {
                    
                    int count = 0;
                    foreach (var dispItem in ListItems)
                    {
                        DateTime date = new DcModelPurchaseReport().GetDateItem(dispItem.DispatchProviderDocumentItemId);
                        if (date.Month==valor1 && dispItem.AssetUniqueIdentificationId== num)
                        {
                            count++;
                        }
                    }
                    htmlRow = "<td style =\"border:solid 1px; text-align:right; width:50px\">"+count.ToString()+"</td>" + "\n";
                    html += htmlRow + "\n";
                    total = total + count;
                }
                htmlRow = "<td style =\"border:solid 1px; text-align:right; width:100px\">" + total.ToString()+"</td>";
                html += htmlRow + "\n";
                htmlRow = "</tr><tr>" + "\n";
                html += htmlRow + "\n";
            }

            return html;
        }

        public string GetHtmlHeaderXlsModelPurchaseReport(string rowText, List<int> list)
        {
            string html = "";

            foreach (var num in list)
            {
                string htmlRow = rowText;
                string brandName = new DcModelPurchaseReport().GetBrandHeader(num);
                htmlRow = "<td style =\"border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white\">"+brandName+"</td>";

                html = html + htmlRow;
            }
            string end = "<td style =\"border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white\"></td>";
            string tr = "</tr><tr>";
            string init = "<td style =\"border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white\">Meses</td>";
            html = html +end+ tr+init;

            foreach (var num in list)
            {
                string htmlRow = rowText;
                string modelName = new DcModelPurchaseReport().GetModelHeader(num);
                htmlRow = "<td style =\"border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white\">"+modelName+"</td>";

                html = html + htmlRow;
            }
            return html;
        }

        // Metodos anteriores//
        public string GetXlsModelPurchaseReportDontFilter(string Provider, int Mount, int Year)
        {
            List<int> listaActivos = new BcModelPurchaseReport().listDontFilter(Mount, Year);
            if (listaActivos.Count == 0)
            {
                return "Listado 0";
            }
            List<ModelPurchaseReport> fechas = GetListWithDate(Mount,Year);
            
            string errorMessage = "";
            try
            {
                string report = GetFileContent("ModelPurchaseSheet.aspx");

                GetXlsFilterModelPurchaseReport(ref report,Provider,Mount,Year);
                
                //MARCAS
                int rowStart = report.IndexOf(cStrHeaderStart);
                int rowEnd = report.IndexOf(cStrHeaderEnd);

                string startText = report.Substring(0, rowStart);
                string rowText = report.Substring(rowStart + cStrColumnStart.Length, rowEnd - rowStart - cStrColumnStart.Length);
                string endText = report.Substring(rowEnd + cStrColumnEnd.Length);

                string htmlRows = GetHtmlHeaderXlsModelPurchaseReport(rowText, listaActivos);
                string sReport = startText + htmlRows + endText;
                //FIN MARCAS

                //MODELOS
                rowStart = sReport.IndexOf(cStrColumnStart);
                rowEnd = sReport.IndexOf(cStrColumnEnd);

                startText = sReport.Substring(0, rowStart);
                rowText = sReport.Substring(rowStart + cStrColumnStart.Length, rowEnd - rowStart - cStrColumnStart.Length);
                endText = sReport.Substring(rowEnd + cStrColumnEnd.Length);
                
                htmlRows = GetHtmlModelXlsModelPurchaseReport(rowText, listaActivos, fechas);
                sReport = startText + htmlRows + endText;
                // FIN MODELOS
                return sReport;
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return "";
            }
        }

        public string GetXlsModelPurchaseReportByFilter(string Provider, int Mount, int Year)
        {
            List<int> listaActivos = new BcModelPurchaseReport().listWithFilter(Provider,Mount, Year);
            if (listaActivos.Count==0)
            {
                return "Listado 0";
            }
            List<ModelPurchaseReport> fechas = GetListWithDate(Mount, Year);
            string errorMessage = "";
            try
            {
                string report = GetFileContent("ModelPurchaseSheet.aspx");

                GetXlsFilterModelPurchaseReport(ref report, Provider, Mount, Year);

                //MARCAS
                int rowStart = report.IndexOf(cStrHeaderStart);
                int rowEnd = report.IndexOf(cStrHeaderEnd);

                string startText = report.Substring(0, rowStart);
                string rowText = report.Substring(rowStart + cStrColumnStart.Length, rowEnd - rowStart - cStrColumnStart.Length);
                string endText = report.Substring(rowEnd + cStrColumnEnd.Length);

                string htmlRows = GetHtmlHeaderXlsModelPurchaseReport(rowText, listaActivos);
                string sReport = startText + htmlRows + endText;
                //FIN MARCAS

                //MODELOS
                rowStart = sReport.IndexOf(cStrColumnStart);
                rowEnd = sReport.IndexOf(cStrColumnEnd);

                startText = sReport.Substring(0, rowStart);
                rowText = sReport.Substring(rowStart + cStrColumnStart.Length, rowEnd - rowStart - cStrColumnStart.Length);
                endText = sReport.Substring(rowEnd + cStrColumnEnd.Length);

                htmlRows = GetHtmlModelXlsModelPurchaseReport(rowText, listaActivos, fechas);
                sReport = startText + htmlRows + endText;
                // FIN MODELOS
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
            string report = GetFileContent("ModelPurchaseSheet.aspx");
            report = report.Replace("<%@ Page Language=\"" + "C#\" AutoEventWireup=\"true\" CodeBehind=\"GlobalCostSheet.aspx.cs\" Inherits=\"amis._PresentationLayer.Report.GlobalCostSheet\" %>", "");
            return report;
        }

        //public List<GlobalCostReport> GetListReportDontFilter(int month, int year)
        //{
        //    List<Asset> ListAsset = new DcGlobalCostReport().GetListReportDontFilter(month, year);
        //    List<ModelPurchaseReport> Report = GetListWithDate(month, year);
        //    List<GlobalCostDetail> ListCost = new DcGlobalCostReport().GetListReport(month, year);

        //    //Prueba
        //    foreach (var rep in Report)
        //    {
        //        string reportDate = rep.Mont.Substring(0, rep.Mont.IndexOf("/"));
        //        foreach (var asset in ListAsset)
        //        {
        //            int assetDate = asset.WarrantyStartDate.Month;

        //            if (assetDate == int.Parse(reportDate))
        //            {
        //                String New = new DcGlobalCostReport().GetTypeTyre(asset.AssetUniqueIdentificationId);
        //                if (New == "Y")
        //                {
        //                    rep.CostNew = rep.CostNew + int.Parse(asset.Cost.ToString());
        //                    rep.UnitNew = rep.UnitNew + 1;

        //                }
        //                if (New == "N")
        //                {
        //                    rep.CostRetrearding = rep.CostRetrearding + int.Parse(asset.Cost.ToString());
        //                    rep.UnitRetreaiding = rep.UnitRetreaiding + 1;
        //                }
        //                rep.TotalKm = rep.TotalKm + asset.Kilometers;
        //            }
        //        }

        //        foreach (var cost in ListCost)
        //        {
        //            if (cost.Month.Month == int.Parse(reportDate))
        //            {
        //                switch (cost.GlobalCostId)
        //                {
        //                    case 3:
        //                        rep.CostRBase = int.Parse(cost.Cost.ToString());
        //                        rep.UnitRBase = int.Parse(cost.CountUnit.ToString());
        //                        break;
        //                    case 4:
        //                        rep.CostRTerreno = int.Parse(cost.Cost.ToString());
        //                        rep.UnitRTerrereno = int.Parse(cost.CountUnit.ToString());
        //                        break;
        //                    case 5:
        //                        rep.CostDispTotal = int.Parse(cost.Cost.ToString());
        //                        rep.UnitDispTotal = int.Parse(cost.CountUnit.ToString());
        //                        break;
        //                    case 6:
        //                        rep.CostVentCasc = int.Parse(cost.Cost.ToString());
        //                        rep.UnitVentCasc = int.Parse(cost.CountUnit.ToString());
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //        }
        //        rep.TotalCost = rep.CostDispTotal + rep.CostNew + rep.CostRBase + rep.CostRetrearding + rep.CostRTerreno + rep.CostVentCasc;
        //        rep.TotalIngreso = rep.CostVentCasc;
        //        if (rep.TotalKm > 0)
        //        {
        //            rep.CostKm = float.Parse((((rep.TotalCost - rep.TotalIngreso) / rep.TotalKm).ToString()).Substring(0, 4));
        //        }
        //        else
        //        {
        //            rep.CostKm = 0;
        //        }

        //    }
        //    //
        //    return Report;
        //}

        //public List<GlobalCostReport> GetListReportFilterWarehouse(int warehouseId, int month, int year)
        //{
        //    List<Asset> ListAsset = new DcGlobalCostReport().GetListReportFilterWarehouse(warehouseId, month, year);
        //    List<GlobalCostReport> Report = GetListWithDate(month, year);
        //    List<GlobalCostDetail> ListCost = new DcGlobalCostReport().GetListReport(month, year);

        //    //Prueba
        //    foreach (var rep in Report)
        //    {
        //        string reportDate = rep.Mount.Substring(0, rep.Mount.IndexOf("/"));
        //        foreach (var asset in ListAsset)
        //        {
        //            int assetDate = asset.WarrantyStartDate.Month;

        //            if (assetDate == int.Parse(reportDate))
        //            {
        //                String New = new DcGlobalCostReport().GetTypeTyre(asset.AssetUniqueIdentificationId);
        //                if (New == "Y")
        //                {
        //                    rep.CostNew = rep.CostNew + int.Parse(asset.Cost.ToString());
        //                    rep.UnitNew = rep.UnitNew + 1;

        //                }
        //                if (New == "N")
        //                {
        //                    rep.CostRetrearding = rep.CostRetrearding + int.Parse(asset.Cost.ToString());
        //                    rep.UnitRetreaiding = rep.UnitRetreaiding + 1;
        //                }
        //                rep.TotalKm = rep.TotalKm + asset.Kilometers;
        //            }
        //        }

        //        foreach (var cost in ListCost)
        //        {
        //            if (cost.Month.Month == int.Parse(reportDate))
        //            {
        //                switch (cost.GlobalCostId)
        //                {
        //                    case 3:
        //                        rep.CostRBase = int.Parse(cost.Cost.ToString());
        //                        rep.UnitRBase = int.Parse(cost.CountUnit.ToString());
        //                        break;
        //                    case 4:
        //                        rep.CostRTerreno = int.Parse(cost.Cost.ToString());
        //                        rep.UnitRTerrereno = int.Parse(cost.CountUnit.ToString());
        //                        break;
        //                    case 5:
        //                        rep.CostDispTotal = int.Parse(cost.Cost.ToString());
        //                        rep.UnitDispTotal = int.Parse(cost.CountUnit.ToString());
        //                        break;
        //                    case 6:
        //                        rep.CostVentCasc = int.Parse(cost.Cost.ToString());
        //                        rep.UnitVentCasc = int.Parse(cost.CountUnit.ToString());
        //                        break;
        //                    default:
        //                        break;
        //                }
        //            }
        //        }
        //        rep.TotalCost = rep.CostDispTotal + rep.CostNew + rep.CostRBase + rep.CostRetrearding + rep.CostRTerreno + rep.CostVentCasc;
        //        rep.TotalIngreso = rep.CostVentCasc;
        //        if (rep.TotalKm > 0)
        //        {
        //            rep.CostKm = float.Parse((((rep.TotalCost - rep.TotalIngreso) / rep.TotalKm).ToString()).Substring(0, 3));
        //        }
        //        else
        //        {
        //            rep.CostKm = 0;
        //        }

        //    }
        //    //
        //    return Report;
        //}

        public List<ModelPurchaseReport> GetListWithDate(int month, int year)
        {

            //Creacion de objetos seteados solo con fechas

            List<ModelPurchaseReport> list = new List<ModelPurchaseReport>();
            for (int i = month; i < 13; i++)
            {
                ModelPurchaseReport obj = new ModelPurchaseReport();

                obj.Mont = i.ToString() + "/" + year.ToString();
                list.Add(obj);
            }
            year = year + 1;
            for (int i = 1; i < month; i++)
            {
                ModelPurchaseReport obj = new ModelPurchaseReport();

                obj.Mont = i.ToString() + "/" + year.ToString();
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

        public List<int> listDontFilter(int mont, int year)
        {
            List<DispatchProviderDocumentItem> list = new DcModelPurchaseReport().GetReportDontFilter(mont, year);

            List<int> ids = new List<int>();

            foreach (var item in list)
            {
                if (ids.Count==0)
                {
                    int val = item.AssetUniqueIdentificationId;
                    ids.Add(val);
                }
                else
                {
                    foreach (var id in ids)
                    {
                        
                        if (ids.Contains(item.AssetUniqueIdentificationId))
                        {
                            break;
                        }
                        int val = item.AssetUniqueIdentificationId;
                        ids.Add(val);
                        break;
                    }
                }
            }

            return ids;
        }

        public List<int> listWithFilter(string provider,int mont, int year)
        {
            List<DispatchProviderDocumentItem> list = new DcModelPurchaseReport().GetReportByFilter(provider,mont, year);

            List<int> ids = new List<int>();

            foreach (var item in list)
            {
                if (ids.Count == 0)
                {
                    int val = item.AssetUniqueIdentificationId;
                    ids.Add(val);
                }
                else
                {
                    foreach (var id in ids)
                    {

                        if (ids.Contains(item.AssetUniqueIdentificationId))
                        {
                            break;
                        }
                        int val = item.AssetUniqueIdentificationId;
                        ids.Add(val);
                        break;
                    }
                }
            }

            return ids;
        }

        public void GetXlsFilterModelPurchaseReport(ref string report, string Provider, int Mount, int Year)
        {
            report = report.Replace("<%@ Page Language=\"" + "C#\" AutoEventWireup=\"true\" CodeBehind=\"GlobalCostSheet.aspx.cs\" Inherits=\"amis._PresentationLayer.Report.GlobalCostSheet\" %>", "");

            if (Year != 0 && Provider != "Todos" && Mount != 0)
            {
                String mont = MonthName(int.Parse(Mount.ToString())).Substring(0, 1).ToUpper()
                + MonthName(int.Parse(Mount.ToString())).Substring(1);

                report = report.Replace("%DATEFILTER%", mont + " Del " + Year.ToString());
                report = report.Replace("%PROVIDER%", Provider);
            }
            else
            {
                String mont = MonthName(int.Parse(Mount.ToString())).Substring(0, 1).ToUpper()
                + MonthName(int.Parse(Mount.ToString())).Substring(1);

                report = report.Replace("%DATEFILTER%", mont + " Del " + Year.ToString());
                report = report.Replace("%PROVIDER%", "Todos");
            }
            
        }

        public List<Member> GetComboProvider()
        {
            return new DcModelPurchaseReport().GetComboProvider();
        }

    }
}