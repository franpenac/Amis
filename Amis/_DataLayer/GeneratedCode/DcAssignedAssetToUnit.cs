using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis._DataLayer.GeneratedCode
{
    public class DcAssignedAssetToUnit
    {
        public int GetUnitIdByUnitRegisterId(int unitRegisterId)
        {
            using (var context = new Entity())
            {
                Unit unit = (from u in context.Unit
                               where u.UnitRegisterId == unitRegisterId
                               select u).FirstOrDefault();

                if (unit != null)
                {
                    return unit.UnitId;
                }

                return 0;
            }
        }


        public string GetAssetTypeById(int id)
        {
            try
            {
                using (var context = new Entity())
                {
                    AssetType type =
                        (from obj in context.AssetType
                         where obj.AssetTypeId == id
                         select obj).FirstOrDefault();
                    return type.AssetTypeName;
                }
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        public bool SearchAssetTypeAssignedById(int assetId, int assetTypeId)
        {
            using (var context = new Entity())
            {
                Asset asset = (from a in context.Asset
                               join aui in context.AssetUniqueIdentification on a.AssetUniqueIdentificationId equals aui.AssetUniqueIdentificationId
                               join type in context.AssetType on aui.AssetTypeId equals type.AssetTypeId
                               where type.AssetTypeId == assetTypeId && a.AssetId == assetId
                               select a).FirstOrDefault();

                if (asset != null)
                {
                    return true;
                }

                return false;
            }
        }

        public string GetTagCodeUnitByTagAssigned(string assetTagCode)
        {
            using (var context = new Entity())
            {
                Unit unit = (from u in context.Unit
                             join ua in context.UnitAsset on u.UnitId equals ua.UnitId
                             join a in context.Asset on ua.AssetId equals a.AssetId
                             join ta in context.TagAssigned on a.AssetId equals ta.AssetId
                             join t in context.Tag on ta.TagId equals t.TagId
                             where t.TagCode == assetTagCode
                             select u).FirstOrDefault();

                Tag tag = (from t in context.Tag
                           join ta in context.TagAssigned on t.TagId equals ta.TagId
                           join a in context.Asset on ta.AssetId equals a.AssetId
                           join u in context.Unit on a.AssetId equals u.AssetId
                           where u.UnitId == unit.UnitId
                           select t).FirstOrDefault();

                if (tag != null)
                {
                    return tag.TagCode;
                }

                return "";
            }
        }
    }
}