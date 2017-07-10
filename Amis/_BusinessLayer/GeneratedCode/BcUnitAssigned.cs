using amis._DataLayer.GeneratedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcUnitAssigned
    {
        //public List<ListItem> GetComboListOrigin(out string errorMessage)
        //{
        //    List<ListItem> List
        //        = new DcUnitAssigned().GetOriginList( out errorMessage);
        //    return List;

        //}

        //public List<ListItem> GetComboListBrand( int originId, out string errorMessage)
        //{
        //    List<ListItem> List =
        //        new DcUnitAssigned().GetComboListBrand( originId, out errorMessage);
        //    return List;

        //}

        //public List<ListItem> GetComboListModel( int originId, int brandId, out string errorMessage)
        //{
        //    List<ListItem> List =
        //        new DcUnitAssigned().GetComboListAssetModel( originId, brandId, out errorMessage);
        //    return List;

        //}

        //public List<ListItem> GetComboListService(int originId, int brandId, int modelId, out string errorMessage)
        //{
        //    List<ListItem> List =
        //        new DcUnitAssigned().GetComboListAssetModelService( originId, brandId, modelId, out errorMessage);
        //    return List;

        //}

        public List<UnitRegister> GetComboUnitRegister(out string errorMessage)
        {
            return new DcUnitAssigned().GetComboUnitRegister(out errorMessage);
        }

        public Unit Save(Unit unit,out string errorMessage)
        {
            return new DcUnitAssigned().Save(unit,out errorMessage);
        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListOrigin(out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List 
                = new DcUnitAssigned().GetComboListOrigin(out errorMessage);
            return List;

        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListBrand(int originId, out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List = 
                new DcUnitAssigned().GetComboListBrand(originId, out errorMessage);
            return List;

        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListModel(int originId,int brandId, out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new DcUnitAssigned().GetComboListAssetModel(originId,brandId, out errorMessage);
            return List;

        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListService(int originId,int brandId,int modelId, out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new DcUnitAssigned().GetComboListAssetModelService(originId, brandId, modelId, out errorMessage);
            return List;

        }

        public Unit GetUnitByUnitRegisterId(int UnitRegisterId, out string errorMessage)
        {
            return new DcUnitAssigned().GetUnitByUnitRegisterId(UnitRegisterId, out errorMessage);
        }

        ///////////////////////////////////

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboOriginUnit(int brandId, int modelId, int servi, out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List
                = new DcUnitAssigned().GetComboOriginUnit(brandId, modelId, servi, out errorMessage);
            return List;

        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboBrandUnit(out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new DcUnitAssigned().GetComboBrandUnit(out errorMessage);
            return List;

        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboAssetModelUnit(int brandId, out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new DcUnitAssigned().GetComboAssetModelUnit(brandId, out errorMessage);
            return List;

        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboAssetModelServiceUnit(int brandId, int modelId, out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new DcUnitAssigned().GetComboAssetModelServiceUnit(brandId, modelId, out errorMessage);
            return List;

        }

        public Asset GetAssetById(int AssetId)
        {
            return new DcUnitAssigned().GetAssetById(AssetId);
        }

        public AssetUniqueIdentification GetAUItById(int AUIId)
        {
            return new DcUnitAssigned().GetAUItById(AUIId);
        }

        public Brand GetBrandbyModelId(int modelId)
        {
            return new DcUnitAssigned().GetBrandbyModelId(modelId);
        }

    }
}