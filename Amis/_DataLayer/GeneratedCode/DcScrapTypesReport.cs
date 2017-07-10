using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;
using amis.Models.Configuration;

namespace amis._DataLayer.GeneratedCode
{
    public class DcScrapTypesReport
    {
        public List<AssetToScraptTypesReport> ScraptTypesReportFiltered(int assetId, int operationId, int assetType, DateTime period, out string errorMessage)
        {
            errorMessage = "";
            List<AssetToScraptTypesReport> list = GetListScrapTypesReport(out errorMessage);
            if (assetId == 0 && operationId == 0 && assetType == 0 && period == new DateTime())
            {
                return list;
            }
            if (assetId != 0)
            {
                list = list.Where(a => a.AssetId == assetId).ToList();
            }
            if (operationId != 0)
            {
                list = list.Where(a => a.AssetOperationId == operationId).ToList();
            }
            if (assetType != 0)
            {
                list = list.Where(a => a.AssetTypeId == assetType).ToList();
            }
            if (period != new DateTime())
            {
                list = list.Where(a => a.DateScraped >= new DateTime(period.Year, period.Month, 1) && a.DateScraped <= new DateTime(period.Year+1, period.Month,1)).ToList();
            }
            return list;
        }

        private List<AssetToScraptTypesReport> GetListScrapTypesReport(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<AssetToScraptTypesReport> list = (from assetEvent in context.AssetEvent
                                                           where assetEvent.SubEventAssetTypeId == 1
                                                           join unit in context.Unit on assetEvent.AssetId equals unit.AssetId
                                                           join assignment in context.Assignment on unit.UnitId equals assignment.UnitId
                                                           join operation in context.Operation on assignment.OperationId equals operation.OperationId
                                                           join asset in context.Asset on assetEvent.AssetId equals asset.AssetId
                                                           join scrap in context.ScrapType on asset.ScrapTypeId equals scrap.ScrapTypeId
                                                           join assetUniqueIdentification in context.AssetUniqueIdentification on asset.AssetUniqueIdentificationId equals assetUniqueIdentification.AssetUniqueIdentificationId
                                                           join assetType in context.AssetType on assetUniqueIdentification.AssetTypeId equals assetType.AssetTypeId
                                                           select new AssetToScraptTypesReport
                                                           {
                                                               AssetId = asset.AssetId,
                                                               AssetOperationId = operation.OperationId,
                                                               AssetOperationName = operation.OperationName,
                                                               AssetTypeId = assetType.AssetTypeId,
                                                               AssetTypeName = assetType.AssetTypeName,
                                                               DateScraped = assetEvent.AssetEventDate,
                                                               ScrapTypeId = scrap.ScrapTypeId,
                                                               ScrapTypeName = scrap.ScrapName

                                                           }).ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<string> GetScraptEvenYears()
        {
            using (var context = new Entity())
            {
                List<string> list = (from assetEvent in context.AssetEvent
                                  join subEventAssetType in context.SubEventAssetType
                                  on assetEvent.SubEventAssetTypeId equals subEventAssetType.SubEventAssetTypeId
                                  join eventAssetType in context.EventAssetType
                                  on subEventAssetType.AssetEventTypeId equals eventAssetType.EventAssetTypeId select assetEvent.AssetEventDate.Year.ToString()).Distinct().ToList();
                return list;                                                               
            }
        }

        public List<ScrapTypesNames> GetAssetScrypeTypes(int assetTypeId)
        {
            using (var context = new Entity())
            {
                List<ScrapTypesNames> list = (from scrt in context.ScrapType where scrt.AssetTypeId == assetTypeId
                                              select new ScrapTypesNames
                                              {
                                                  ScrapName = scrt.ScrapName
                                              }
                    ).ToList();
                return list;
            }
        }
    }
}