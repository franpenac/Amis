using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class MenuAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.UserId() != 1)
            {
                regTag.Visible = false;
            }
            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            lblWelcome.Text = "Bienvenido "+user.Name;
            Session["UnitRegisterFind"] = null;
            Session["UnitRegister"] = null;
            Session["IsUnit"] = null;
            Session["Patent"] = null;
            Session["internalNumber"] = null;
            Session["NothingAction"] = null;
            Session["AssetTypeName"] = null;
            Session["TagCode"] = null;
            Session["UnitRegisterFind"] = null;
            Session["Contador"] = null;
            Session["UnitId"] = null;
            Session["ErrorNumber"] = null;
            Session["Contador"] = null;
            Session["AssetVehicule"] = null;
            Session["UnitRegister"] = null;
            Session["FromError"] = null;
            Session["ListButtons"] = null;
            Session["ListButtonsToSend"] = null;
            Session["ListButtonsToChangePosition"] = null;
            Session["ListButtonsChanged"] = null;
            Session["ListButtonsFromChangeAnotherUnit"] = null;
            Session["FinishChange"] = null;
            Session["ChangeToWarehouse"] = null;
            Session["ListButtonsFromChangeAnotherWarehouse"] = null;
            Session["ListConfigAxleUnitType"] = null;
            Session["TyreTagPosition"] = null;
            Session["AssetId"] = null;
            Session["TagAsset"] = null;
            Session["Tag"] = null;
            Session["Type"] = null;
            Session["TyreTagPosition2"] = null;
            Session["ToScrap"] = null;
            Session["EventAssetTypeId"] = null;
            Session["assetPositionId"] = null;
            Session["IsReplace"] = null;
        }

        protected void btnCloseSession_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            //new BcAmisUser().LogOut(user.AmisUserId, user.Name);
            Session["UserId"] = null;
            Response.Redirect("~/_PresentationLayer/AndroidModule/LoginAndroidPage.aspx");
        }

        protected void btnRegisterTag_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/SelectRegisterTagOption.aspx");
        }

        protected void btnAsignationTag_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AssetModule/SelectedAssignedPage.aspx");
        }

        protected void btnAsignationAsset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/AssignedAssetToUnitAndroidPage.aspx");
        }

        protected void btnInspection_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/InspectionIndexAndroidPage.aspx");
        }

        protected void btnInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/InventoryIndexAndroidPage.aspx");
        }

        protected void btnInconcist_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/InConstructionPage.aspx");
        }

        protected void btnConecction_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/InConstructionPage.aspx");

        }

        protected void btnConfiguration_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/InConstructionPage.aspx");

        }

        protected void btnCalibration_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/InConstructionPage.aspx");

        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/ChangePasswordInAndroidPage.aspx");

        }

        protected void btnReplaceTyre_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectUnitToReplaceTyre.aspx");
        }
    }
}