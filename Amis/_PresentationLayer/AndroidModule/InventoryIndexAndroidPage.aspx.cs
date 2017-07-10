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
    public partial class InventoryIndexAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            int CodeAction = 0;
            if (!new BcInspectionAndroid().ValidateSearchUnit(txbTagUnit.Text, out CodeAction))
            {
                Session["ErrorNumber"] = CodeAction;
                Session["SendEmail"] = null;
                Response.Redirect("ErrorAndroidPage.aspx", false);
            }

            UnitRegister unitRegister = new BcInspectionAndroid().SearchUnitByTag(txbTagUnit.Text, out errorMessage);
            if (unitRegister != null)
            {
                if (Session["AssetVehicule"] == null)
                {
                    Asset asset = new BcAsset().GetAssetByUnitRegisterId(unitRegister.UnitRegisterId, out errorMessage);
                    Session["AssetVehicule"] = asset;
                    Session["UnitRegister"] = unitRegister;
                    lblText.Text = lblText.Text + unitRegister.KilometersOfTravel.ToString();
                    mpeConfirmar.Show();
                }
                else
                {
                    ChargeUnit(unitRegister);
                }

            }
            else
            {
                Page.ShowSmallPopupMessage(errorMessage);
            }

        }

        protected void btnCantReadTag_Click(object sender, EventArgs e)
        {
            Session["ErrorNumber"] = 7;
            Session["SendEmail"] = null;
            Response.Redirect("ErrorAndroidPage.aspx", false);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["dllAssetType"] = null;
            Session["UnitRegister"] = null;
            Session["Contador"] = null;
            Session["ErrorNumber"] = null;
            Session["AssetVehicule"] = null;
            Response.Redirect("MenuAndroidPage.aspx", false);
        }

        protected void ChargeUnit(UnitRegister unitRegister)
        {

            lblPatentSelected.Visible = true;
            lblInternalNumberSelected.Visible = true;
            lblInternalNumberSelected.Text = unitRegister.InternalNumber.ToString();
            lblPatentSelected.Text = unitRegister.PatentNumber.ToString();
            txbTagUnit.Style.Value = "Display:none";
            Session["Patent"] = unitRegister.PatentNumber;
            Session["internalNumber"] = unitRegister.InternalNumber;

            int id = new BcInspectionAndroid().GetUnitIdByPatent(unitRegister.PatentNumber.ToString());
            Session["ListAssetNoTyre"] = new BcUnitAsset().GetListAssetNoTyreInUnit(id);
            Session["ListAssetNoTyreFind"] = new List<Asset>();
            Session["ListAssetTyre"] = new BcUnitAsset().GetListAssetTyreInUnit(id);
            Session["ListAssetTyreFind"] = new List<Asset>();
            Session["UnitRegister"] = null;
            Session["UnitRegisterFind"] = unitRegister.UnitRegisterId.ToString();
            Session["ListCode"] = null;
            Response.Redirect("InventoryNoTyreAndroidPage.aspx",false);
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["Contador"] = null;
            Session["AssetVehicule"] = null;
            Session["UnitRegister"] = null;
            Response.Redirect("~/_PresentationLayer/AndroidModule/InventoryIndexAndroidPage.aspx", false);
        }

        protected void btnConfirmarPoppup_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            int kilometer = 0;
            UnitRegister unitRegister = (UnitRegister)Session["UnitRegister"];

            if (txtObservation.Text.Length > 10)
            {
                mpeConfirmar.Show();
                lblError.Text = "La cantidad digitada supera el maximo aceptado por el sistema";
                return;
            }

            if (int.TryParse(txtObservation.Text, out kilometer))
            {
                if (unitRegister.KilometersOfTravel > kilometer)
                {
                    mpeConfirmar.Show();
                    lblError.Text = "Kilometraje no válida";

                }
                else
                {
                    unitRegister.KilometersOfTravel = kilometer;
                    new BcUnitRegister().Save(unitRegister, out errorMessage);
                    mpeConfirmar.Hide();
                    unitRegister = (UnitRegister)Session["UnitRegister"];
                    ChargeUnit(unitRegister);
                }
            }
            if(txtObservation.Text.Length>10)
            {
                mpeConfirmar.Show();
                lblError.Text = "Digite solo numeros";
            }

        }
    }
}