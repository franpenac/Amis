using amis._DataLayer.GeneratedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcAssignedAssetToUnit
    {
        public bool ValidateReadAsset(string tagCode, int unitId, int assetTypeId, out int CodeAtion)
        {
            CodeAtion = 0;

            Tag tag = new DcInspectionAndroid().SearchTag(tagCode);
            if (tag == null) { CodeAtion = 1; return false; }

            TagAssigned assigned = new DcInspectionAndroid().SearchAssigned(tag.TagId);
            if (assigned == null) { CodeAtion = 2; return false; }
            
            string type = new DcInspectionAndroid().getAssetTypeByTag(tagCode);
            if (type == "Vehiculo") { CodeAtion = 10; return false; }

            bool ok = new DcAssignedAssetToUnit().SearchAssetTypeAssignedById(assigned.AssetId, assetTypeId);
            if (ok == false) { CodeAtion = 11; return false; }

            UnitAsset ua = new DcInspectionAndroid().ExistAssetAssigned(assigned.AssetId);
            if (ua != null)
            {
                if(ua.UnitId == unitId)
                {
                    CodeAtion = 0; return false;
                }
                else
                {
                    CodeAtion = 12; return false;
                }

            }
            else {
                return true;
            }
            
        }

        public UnitRegister SearchUnitRegisterByTag(string tagCode) { 

            string errorMessage="";
            return new BcInspectionAndroid().SearchUnitByTag(tagCode, out errorMessage);
        }

        public string GetAssetTypeById(int id)
        {
            return new DcAssignedAssetToUnit().GetAssetTypeById(id);
        }

        public string GetTagCodeUnitByTagAssigned(string assetTagCode)
        {
            return new DcAssignedAssetToUnit().GetTagCodeUnitByTagAssigned(assetTagCode);
        }

        public int GetUnitIdByUnitRegisterId(int unitRegisterId)
        {
            return new DcAssignedAssetToUnit().GetUnitIdByUnitRegisterId(unitRegisterId);
        }

        public bool ValidateReadAssetTyre(string tagCode, int unitId, out int CodeAtion)
        {
            CodeAtion = 0;
            Tag tag = new DcInspectionAndroid().SearchTag(tagCode);
            if (tag == null) { CodeAtion = 1; return false; }

            TagAssigned assigned = new DcInspectionAndroid().SearchAssigned(tag.TagId);
            if (assigned == null) { CodeAtion = 2; return false; }

            string type = new DcInspectionAndroid().getAssetTypeByTag(tagCode);
            if (type != "Neumático") { CodeAtion = 14; return false; }

            UnitAsset unitAsset = new DcInspectionAndroid().ExistAssetAssigned(assigned.AssetId);
            if(unitAsset != null)
            {
                if (unitId == unitAsset.UnitId)
                {
                    CodeAtion = 16;
                    return false;
                }
                else
                {
                    CodeAtion = 12;
                    return false;
                }
            }

            Asset asset = new DcInspectionAndroid().SearchAssetScraped(assigned.AssetId);
            if(asset == null) { CodeAtion = 15; return false; }
            return true;
            

        }
    }
}