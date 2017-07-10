using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using amis._DataLayer.GeneratedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class ChangePositionAssetPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errorMessage = "";
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            lblPatentSelected.Text = unit.PatentNumber;
            lblInternalNumberSelected.Text = unit.InternalNumber;
            int assetId = (int)Session["AssetId"];
            Asset asset = new BcAsset().GetAssetById(assetId, out errorMessage);
            AssetUniqueIdentification astU = new BcAssetUniqueIdentification().GetAssetUniqueIdentificationById(asset.AssetUniqueIdentificationId);
            lblAssetTypeText.Text = new BcAssetType().GetAssetTypeNameById(astU.AssetTypeId);
        }

        protected void btnToWarehouse_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeAssetToAnotherWarehouse.aspx");
        }

        protected void btnOtherUnit_Click(object sender, EventArgs e)
        {
            Session["FromInspection"] = 1;
            Response.Redirect("ChangeTyreToAnotherUnit.aspx");
        }

        protected void btnSameUnit_Click(object sender, EventArgs e)
        {
            string btnInInspectionId = (string)Session["TyreTagPosition"];
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            foreach (Button item in listButtons)
            {
                if (item.ID == btnInInspectionId)
                {
                    item.CssClass = "imgInProgress";
                }
                if (item.CssClass == "imgHidden")
                {
                    item.Enabled = true;
                }
            }
            Session["ListButtons"] = listButtons;
            if (Session["ToScrap"] != null)
            {
                Response.Redirect("SelectReplaceToSameUnitTyre.aspx");
            }else
            {
                Response.Redirect("SelectReplaceToSameUnitTyre.aspx");
            }
        }
    }
}