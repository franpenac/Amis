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
    public partial class DcSubEventAssetType
    {

        public SubEventAssetType GetSubEventAssetTypeToScrap(int assetId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    SubEventAssetType obj = (from asset in context.Asset
                                             where asset.AssetId == assetId
                                             join aui in context.AssetUniqueIdentification on asset.AssetUniqueIdentificationId
                                             equals aui.AssetUniqueIdentificationId
                                             join assetType in context.AssetType on asset.AssetUniqueIdentification.AssetTypeId
                                             equals assetType.AssetTypeId
                                             join eventAssetType in context.EventAssetType on asset.AssetUniqueIdentification.AssetType.AssetTypeId
                                             equals eventAssetType.AssetTypeId
                                             where eventAssetType.EventAssetTypeName == "Remover"
                                             join subEventAssetType in context.SubEventAssetType on eventAssetType.EventAssetTypeId
                                             equals subEventAssetType.AssetEventTypeId
                                             where subEventAssetType.SubEventAssetTypeName == "Remover por scrap"
                                             select subEventAssetType
                                                ).FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public SubEventAssetType GetSubEventAssetTypeToRepair(int assetId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    SubEventAssetType obj = (from asset in context.Asset
                                             where asset.AssetId == assetId
                                             join aui in context.AssetUniqueIdentification on asset.AssetUniqueIdentificationId
                                             equals aui.AssetUniqueIdentificationId
                                             join assetType in context.AssetType on asset.AssetUniqueIdentification.AssetTypeId
                                             equals assetType.AssetTypeId
                                             join eventAssetType in context.EventAssetType on asset.AssetUniqueIdentification.AssetType.AssetTypeId
                                             equals eventAssetType.AssetTypeId
                                             where eventAssetType.EventAssetTypeName == "Remover"
                                             join subEventAssetType in context.SubEventAssetType on eventAssetType.EventAssetTypeId
                                             equals subEventAssetType.AssetEventTypeId
                                             where subEventAssetType.SubEventAssetTypeName == "Remover por reparación"
                                             select subEventAssetType
                                                ).FirstOrDefault();
                    return obj;
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
