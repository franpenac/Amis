using amis._DataLayer.GeneratedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcInspectionAndroid
    {
        public int SearchScrapIdByName(string ScrapName)
        {
            return new DcInspectionAndroid().SearchScrapIdByName(ScrapName);
        }

        public void SendToScrap(int branchOfficeId, string tagAsset, int scrap)
        {
            new DcInspectionAndroid().SendToScrap(branchOfficeId, tagAsset, scrap);
        }

        public void SendToRepair(int branchOfficeId,string tagAsset)
        {
             new DcInspectionAndroid().SendToRepair(branchOfficeId, tagAsset);
        }

        public List<ListItem> GetComboList(int idUnit, out string errorMessage)
        {
            errorMessage = "";
            return new DcInspectionAndroid().GetComboList(idUnit, out errorMessage);
        }
        
        public List<ListItem> GetComboListBranchOfficeUser(int idUnit, out string errorMessage)
        {
            errorMessage = "";
            return new DcInspectionAndroid().GetComboListBranchOfficeUser(idUnit, out errorMessage);
        }
        
        public int GetCountOffice(int idUnit, out string errorMessage)
        {
            errorMessage = "";
            return new DcInspectionAndroid().GetCountOffice(idUnit, out errorMessage);


        }

        public int GetIdBranchOfficeByUser(int amisUserId, out string errorMessage)
        {
            errorMessage = "";
            return new DcInspectionAndroid().GetIdBranchOfficeByUser(amisUserId, out errorMessage);


        }

        public int GetIdBranchOfficeByName(string BranchOfficeName, out string errorMessage)
        {
            errorMessage = "";
            return new DcInspectionAndroid().GetIdBranchOfficeByName(BranchOfficeName, out errorMessage);

        }

        public int GetIdBranchOfficeUser(int idUnit, out string errorMessage)
        {
            errorMessage = "";
            return new DcInspectionAndroid().GetIdBranchOfficeUser(idUnit, out errorMessage);
        }

        public List<ListItem> GetComboListScrap(int idType, out string errorMessage)
        {
            errorMessage = "";
            return new DcInspectionAndroid().GetComboListScrap(idType, out errorMessage);
        }

        public List<ListItem> GetComboListScrapName(string TypeName, out string errorMessage)
        {
            errorMessage = "";
            return new DcInspectionAndroid().GetComboListScrapName(TypeName, out errorMessage);
        }

        public void ChangeState(string tag, string state)
        {
            new DcInspectionAndroid().ChangeState(tag,state);
        }

        public UnitRegister SearchUnitByTag(string tagCode, out string errorMessage)
        {
            errorMessage = "";
            UnitRegister unit = new DcInspectionAndroid().SearchUnitByTag(tagCode);
            new DcTag().GetTagByCode(tagCode, out errorMessage);
            if (unit == null)
            {
                errorMessage = "La unidad leida, no posee ningun activo asociado a ella.";
            }
            return unit;
        }

        public UnitRegister SearchUnitByTag2(string tagCode, out string errorMessage)
        {
            errorMessage = "";
            UnitRegister unit = new DcInspectionAndroid().SearchUnitByTag2(tagCode);
            new DcTag().GetTagByCode(tagCode, out errorMessage);
            if (unit == null)
            {
                errorMessage = "El tag leído no esta asignado a ninguna unidad.";
            }
            return unit;
        }

        public string SearchUrlByTag(string tagCode)
        {
            return new DcInspectionAndroid().SearchUrlByTag(tagCode);

        }

        public Asset SearchAssetByTag(string tagCode)
        {
            return new DcInspectionAndroid().SearchAssetByTag(tagCode);
        }

        public bool ValidateSearchUnit(string tagCode, out int CodeAtion)
        {
            CodeAtion = 0;

            Tag tag = new DcInspectionAndroid().SearchTag(tagCode);
            if (tag == null) { CodeAtion = 1; return false; }

            TagAssigned assigned = new DcInspectionAndroid().SearchAssigned(tag.TagId);
            if (assigned == null) { CodeAtion = 2; return false; }

            if (!new DcInspectionAndroid().AssignedInUnit(assigned.AssetId)) { CodeAtion = 3; return false; }

            return true;
        }

        public int GetAssetId(int id)
        {
            return new DcInspectionAndroid().GetAssetId(id);
        }

        public bool AssignedInUnit(int id)
        {
            return new DcInspectionAndroid().AssignedInUnit(id);
        }

        public int GetTypeById(string text)
        {
            return new DcAssetType().GetTypeById(text);
        }

        public bool ValidateReadAsset(string tagCode, int unitId, int assetTypeId, out int CodeAtion)
        {
            CodeAtion = 0;

            Tag tag = new DcInspectionAndroid().SearchTag(tagCode);
            if (tag == null) { CodeAtion = 1; return false; }

            TagAssigned assigned = new DcInspectionAndroid().SearchAssigned(tag.TagId);
            if (assigned == null) { CodeAtion = 2; return false; }



            bool next = new DcInspectionAndroid().SearchAssetAssigned(assigned.AssetId, unitId);
            if (next == false)
            {
                UnitAsset asset = new DcInspectionAndroid().ExistAssetAssigned(assigned.AssetId);

                if (asset != null)
                { CodeAtion = 4; return false; }
                CodeAtion = 5;
                return false;

            }

            next = new DcInspectionAndroid().SearchAssetTypeAssigned(assigned.AssetId, assetTypeId);
            if (next == false) { CodeAtion = 6; return false; }

            return true;
        }

        public int GetUnitRegisterIdByPatent(string patent)
        {
            return new DcInspectionAndroid().GetUnitRegisterIdByPatent(patent);

        }

        public int GetUnitIdByPatent(string patent)
        {
            return new DcInspectionAndroid().GetUnitIdByPatent(patent);
        }

        public UnitRegister SearchUnitById(string id)
        {
            UnitRegister unit = new DcInspectionAndroid().SearchUnitById(int.Parse(id));

            return unit;
        }

        public string getAssetTypeByTag(string tag)
        {
            return new DcInspectionAndroid().getAssetTypeByTag(tag);
        }
    }
}