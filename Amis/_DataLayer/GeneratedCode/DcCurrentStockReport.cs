using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;

namespace amis._DataLayer.GeneratedCode
{
    public class DcCurrentStockReport
    {
        public List<AssetToCurrentReport> CurrentStockReportFiltered(int BranchOfficeId, int WarehouseId, int AssetTypeId, out string errorMessage)
        {
            try
            {
                List<AssetToCurrentReport> list = GetListCurrentStockReport(out errorMessage);

                foreach (var item in list)
                {
                    using (var context = new Entity())
                    {
                        int val = (from obj in context.Asset
                                   join fac in context.Facility on obj.FacilityId equals fac.FacilityId
                                   join unique in context.AssetUniqueIdentification on obj.AssetUniqueIdentificationId equals unique.AssetUniqueIdentificationId
                                   join model in context.AssetModel on unique.AssetModelId equals model.AssetModelId
                                   where fac.WarehouseId == item.WarehouseId && model.AssetModelName == item.AssetModelName
                                   select obj).Count();

                        item.Stock = val;
                    }
                }
                if (BranchOfficeId == 0 && WarehouseId == 0 && AssetTypeId == 0)
                {
                    return list;
                }
                if (BranchOfficeId != 0)
                {
                    list = list.Where(r => r.BranchOfficeId == BranchOfficeId).ToList();
                }

                if (WarehouseId != 0)
                    list = list.Where(r => r.WarehouseId == WarehouseId).ToList();

                if (AssetTypeId != 0)
                    list = list.Where(r => r.AssetTypeId == AssetTypeId).ToList();

                return list.OrderBy(r=>r.AssetTypeName).ToList();
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        private List<AssetToCurrentReport> GetListCurrentStockReport(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<AssetToCurrentReport> list =
                        (from assetuniqueidentification in context.AssetUniqueIdentification
                         join asset in context.Asset
                         on assetuniqueidentification.AssetUniqueIdentificationId equals asset.AssetUniqueIdentificationId
                         join assetType in context.AssetType
                         on assetuniqueidentification.AssetTypeId equals assetType.AssetTypeId
                         join assetModel in context.AssetModel
                         on assetuniqueidentification.AssetModelId equals assetModel.AssetModelId
                         join brand in context.Brand
                         on assetModel.BrandId equals brand.BrandId
                         join facility in context.Facility
                         on asset.FacilityId equals facility.FacilityId
                         join warehouse in context.Warehouse
                         on facility.WarehouseId equals warehouse.WarehouseId
                         join branchoffice in context.BranchOffice
                         on warehouse.BranchOfficeId equals branchoffice.BranchOfficeId
                         where facility.FacilityTypeId == 1
                         select new AssetToCurrentReport
                         {

                             AssetTypeId = assetuniqueidentification.AssetType.AssetTypeId,
                             AssetTypeName = assetuniqueidentification.AssetType.AssetTypeName,
                             BrandId = brand.BrandId,
                             BrandName = brand.BrandName,
                             AssetModelId = assetModel.AssetModelId,
                             AssetModelName = assetModel.AssetModelName,
                             Stock = 0,
                             WarehouseId = warehouse.WarehouseId,
                             WarehouseName = warehouse.WarehouseName,
                             BranchOfficeId = branchoffice.BranchOfficeId,
                             BranchOfficeName = branchoffice.BranchOfficeName

                         }).OrderBy(ast => ast.AssetTypeName).ThenBy(ast => ast.BrandName).ToList();

                    var distincList = list.GroupBy(r => new { r.AssetTypeId, r.AssetTypeName,r.BrandId, r.BrandName, r.AssetModelId, r.AssetModelName, r.Stock, r.WarehouseId, r.WarehouseName, r.BranchOfficeId, r.BranchOfficeName })
                        .Select(m => new { m.Key.AssetTypeId, m.Key.AssetTypeName, m.Key.BrandId, m.Key.BrandName, m.Key.AssetModelId, m.Key.AssetModelName, m.Key.Stock, m.Key.WarehouseId, m.Key.WarehouseName, m.Key.BranchOfficeId, m.Key.BranchOfficeName }).ToList();
                    List<AssetToCurrentReport> distinctList3 =
                        (from ast in distincList
                         select new AssetToCurrentReport()
                         {

                             AssetTypeId = ast.AssetTypeId,
                             AssetTypeName = ast.AssetTypeName,
                             BrandId = ast.BrandId,
                             BrandName = ast.BrandName,
                             AssetModelId = ast.AssetModelId,
                             AssetModelName = ast.AssetModelName,
                             Stock = ast.Stock,
                             WarehouseId = ast.WarehouseId,
                             WarehouseName = ast.WarehouseName,
                             BranchOfficeId = ast.BranchOfficeId,
                             BranchOfficeName = ast.BranchOfficeName

                         }).OrderBy(r => r.AssetModelId).ToList();


                    return distinctList3;
                }
            }
            catch (Exception ex)
            {

                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }
    }
}