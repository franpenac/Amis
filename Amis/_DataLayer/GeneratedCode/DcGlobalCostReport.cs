using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Transactions;
using amis._Common;
using amis.Models;

namespace amis._DataLayer.GeneratedCode
{
    public class DcGlobalCostReport
    {
        public List<GlobalCostDetail> GetListReport(int month, int year)
        {
            DateTime init = new DateTime();
            DateTime end = new DateTime();
            if (month.ToString().Length==1)
            {

                init = DateTime.Parse(year.ToString() + "-0" + month.ToString() + "-01");
                end = DateTime.Parse((year + 1).ToString() + "-0" + (month).ToString() + "-01");
            }
            else
            {

                init = DateTime.Parse(year.ToString() + "-" + month.ToString() + "-01");
                end = DateTime.Parse((year + 1).ToString() + "-" + (month).ToString() + "-01");
            }

            using (var context = new Entity())
            {
                GlobalCostDetail list = new GlobalCostDetail();
                
                List<GlobalCostDetail> listado = (from GlobalCostDetail in context.GlobalCostDetail
                         join globalCost in context.GlobalCost on GlobalCostDetail.GlobalCostId equals globalCost.GlobalCostId
                         where GlobalCostDetail.Month>=init && GlobalCostDetail.Month<=end
                         select GlobalCostDetail).ToList();
                    return listado;
            }
        }

        public List<Asset> GetListReportFilterWarehouse(int warehouse,int month, int year)
        {
            DateTime init = new DateTime();
            DateTime end = new DateTime();
            GeneratedDate(ref init, ref end, month, year);

            using (var context = new Entity())
            {
                Asset list = new Asset();

                List<Asset> listado = (from asset in context.Asset
                                                  join unique in context.AssetUniqueIdentification on asset.AssetUniqueIdentificationId equals unique.AssetUniqueIdentificationId
                                                  join facility in context.Facility on asset.FacilityId equals facility.FacilityId
                                                  join ware in context.Warehouse on facility.WarehouseId equals ware.WarehouseId
                                                  where asset.WarrantyStartDate >= init && asset.WarrantyStartDate <= end &&
                                                  facility.FacilityTypeId==1 && unique.AssetTypeId==1 && facility.WarehouseId==warehouse
                                                  select asset).ToList();
                return listado;
            }
        }

        public List<Asset> GetListReportDontFilter(int month, int year)
        {
            DateTime init = new DateTime();
            DateTime end = new DateTime();
            GeneratedDate(ref init, ref end, month, year);

            using (var context = new Entity())
            {
                Asset list = new Asset();

                List<Asset> listado = (from asset in context.Asset
                                       join unique in context.AssetUniqueIdentification on asset.AssetUniqueIdentificationId equals unique.AssetUniqueIdentificationId
                                       join facility in context.Facility on asset.FacilityId equals facility.FacilityId
                                       join ware in context.Warehouse on facility.WarehouseId equals ware.WarehouseId
                                       where asset.WarrantyStartDate >= init && asset.WarrantyStartDate <= end &&
                                       facility.FacilityTypeId == 1 && unique.AssetTypeId == 1
                                       select asset).ToList();
                return listado;
            }
        }

        public String GetTypeTyre(int UniqueId)
        {
            using (var context = new Entity())
            {
                
                //int modelId = (from model in context.AssetUniqueIdentification.Where(m => m.AssetUniqueIdentificationId == UniqueId) select model.AssetModelId).FirstOrDefault();

                //String New = (from setting in context.SettingTyre.Where(s=> s.AssetModelId==modelId) select setting.Original).FirstOrDefault();

                return "";
            }
        }

        public List<Warehouse> GetWarehouseDetail()
        {
            using (var context = new Entity())
            {
                List<Warehouse> list = (from asset in context.Asset
                                        join unique in context.AssetUniqueIdentification on asset.AssetUniqueIdentificationId equals unique.AssetUniqueIdentificationId
                                        join type in context.AssetType on unique.AssetTypeId equals type.AssetTypeId
                                        join facility in context.Facility on asset.FacilityId equals facility.FacilityId
                                        join ware in context.Warehouse on facility.WarehouseId equals ware.WarehouseId
                                        where type.AssetTypeId == 1 && facility.FacilityTypeId == 1
                                        select ware).Distinct().ToList();
                return list;
            }
            
        }

        public void GeneratedDate(ref DateTime init, ref DateTime end, int month, int year)
        {
            if (month.ToString().Length == 1)
            {

                init = DateTime.Parse(year.ToString() + "-0" + month.ToString() + "-01");
                end = DateTime.Parse((year + 1).ToString() + "-0" + (month).ToString() + "-01");
            }
            else
            {

                init = DateTime.Parse(year.ToString() + "-" + month.ToString() + "-01");
                end = DateTime.Parse((year + 1).ToString() + "-" + (month).ToString() + "-01");
            }
        }
    }
}