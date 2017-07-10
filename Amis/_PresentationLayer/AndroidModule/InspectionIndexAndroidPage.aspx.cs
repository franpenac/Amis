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
    public partial class InspectionIndexAndroidPage : System.Web.UI.Page
    {
        protected int Contador
        {
            get
            {
                if (Session["Contador"] == null)
                {
                    Session["Contador"] = 0;
                }
                int id = int.Parse(Session["Contador"].ToString());
                return id;
            }
            set
            {
                Session["Contador"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnReadRfiTag.Visible = true;
                btnReadRfiTag2.Visible = false;
                Session["SelectedType"] = null;
            }
                Session["TagAsset"] = null;
                Session["ErrorNumber"] = null;

                if (Session["UnitRegisterFind"] != null)
                {
                btnCantReadTag.Enabled = false;
                    if (Session["dllAssetType"] != null)
                    {
                        LoadControl2();
                    }else
                { LoadControl(); }
                }
                
                if (Session["IsUnit"] == null)
                {
                    Session["IsUnit"] = true;
                }

                
                if (Session["Contador"] != null)
                {
                    string parameter = Request["__EVENTARGUMENT"];
                    if (parameter != null)
                    {
                        if (parameter.Split(';')[0] == "TagUnidad")
                        {

                            btnSearch_Click(sender, e);

                        }
                        if (parameter.Split(';')[0] == "TagActivo")
                        {
                            AssetReadTag();

                        }
                    }
                
            }
        }

        protected void btnReadTag_Click(object sender, EventArgs e)
        {
            if (Session["Contador"] == null)
            {
                txbTagUnit.Style.Value = "Display:visibility";
                txbTagUnit.Text = "";
                txbTagUnit.Visible = true;
                if (lblPatentSelected.Text == "" && lblInternalNumberSelected.Text == "")
                {
                    Session["Contador"] = 1;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            int CodeAction = 0;
            if (!new BcInspectionAndroid().ValidateSearchUnit(txbTagUnit.Text, out CodeAction))
            {
                Session["Contador"] = null;
                Session["ErrorNumber"] = CodeAction;
                Session["SendEmail"] = null;
                Session["SelectedType"] = ddlAssetType.SelectedItem;
                Response.Redirect("ErrorAndroidPage.aspx", false);
            }

            UnitRegister unitRegister = new BcInspectionAndroid().SearchUnitByTag(txbTagUnit.Text, out errorMessage);
            if (unitRegister != null)
            {
                if(Session["AssetVehicule"] == null)
                {
                    Asset asset = new BcAsset().GetAssetByUnitRegisterId(unitRegister.UnitRegisterId, out errorMessage);
                    Session["AssetVehicule"] = asset;
                    Session["UnitRegister"] = unitRegister;
                    lblText.Text = lblText.Text + unitRegister.KilometersOfTravel.ToString();
                    mpeConfirmar.Show();
                    btnCantReadTag.Enabled = false;
                    btnWrongFacility.Enabled = true;
                }
                else
                {
                    ChargeUnit(unitRegister);
                }

            }
            else
            {
                Session["Contador"] = null;
                Page.ShowSmallPopupMessage(errorMessage);
                txbTagUnit.Focus();
            }

        }

        protected void btnCantReadTag_Click(object sender, EventArgs e)
        {
			Session["CantRead"] = 7;
            Response.Redirect("WrongTagInspectionPage.aspx", false);           
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["dllAssetType"] = null;
            Session["UnitRegister"] = null;
            Session["UnitRegisterFind"] = null;
            Session["Contador"] = null;
            Session["ErrorNumber"] = null;
            Session["AssetVehicule"] = null;
            Response.Redirect("MenuAndroidPage.aspx", false);
        }

        protected void btnWrongFacility_Click(object sender, EventArgs e)
        {

            Response.Redirect("WrongTagInspectionPage.aspx", false);
        }

        protected void LoadControl()
        {
            
                int id = (int)Session["UnitRegisterFind"];
                int assetId = new BcInspectionAndroid().GetAssetId(int.Parse(id.ToString()));
            if (new BcInspectionAndroid().AssignedInUnit(assetId))
            {
                string errorMessage = "";
                UnitRegister unit = new BcUnitRegister().GetUnitRegisterById(int.Parse(id.ToString()), out errorMessage);
                lblPatentSelected.Visible = true;
                lblInternalNumberSelected.Visible = true;
                lblInternalNumberSelected.Text = unit.InternalNumber.ToString();
                lblPatentSelected.Text = unit.PatentNumber.ToString();
                txbTagUnit.Style.Value = "Display:none";
                Asset.Visible = true;
                Session["IsUnit"] = true;
                int id2 = new BcInspectionAndroid().GetUnitIdByPatent(unit.PatentNumber.ToString());
                ddlAssetType.DataSource = new BcInspectionAndroid().GetComboList(id2, out errorMessage);
                ddlAssetType.DataBind();
                Session["dllAssetType"] = true;
                btnReadRfiTag.Visible = false;
                btnReadRfiTag2.Visible = true;
            }
            else
            {
                if (!(bool)Session["IsUnit"])
                {
                    Page.ShowSmallPopupMessage("El tag leido, no esta asignado ningun activo.");
                }
            }
    }

        protected void LoadControl2()
        {
            int id = (int)Session["UnitRegisterFind"];
            int assetId = new BcInspectionAndroid().GetAssetId(int.Parse(id.ToString()));
            if (new BcInspectionAndroid().AssignedInUnit(assetId))
            {
                string errorMessage = "";
                UnitRegister unit = new BcUnitRegister().GetUnitRegisterById(int.Parse(id.ToString()), out errorMessage);
                lblPatentSelected.Visible = true;
                lblInternalNumberSelected.Visible = true;
                lblInternalNumberSelected.Text = unit.InternalNumber.ToString();
                lblPatentSelected.Text = unit.PatentNumber.ToString();
                txbTagUnit.Style.Value = "Display:none";
                Asset.Visible = true;
                Session["IsUnit"] = true;
                
            }
            else
            {
                if (!(bool)Session["IsUnit"])
                {
                    Page.ShowSmallPopupMessage("El tag leido, no esta asignado ningun activo.");
                }
            }
        }

        protected void btnInpection_Click(object sender, EventArgs e)
        {
            //if (txbKilometer.Text != "" || int.Parse(txbKilometer.Text) > 0)
            //{
                Session["Contador"] = null;
                Session["ErrorNumber"] = null;
                Response.Redirect("SelectionTyrePage.aspx", false);
                Session["HasKilometer"] = true;
            //}
            //else { Page.ShowSmallPopupMessage("Debe digitar el kilometraje actual!"); }
        }

        protected void ChangeImage()
        {
            if (ddlAssetType.SelectedItem.Text== "Batería") { imgOtherAsset.ImageUrl = "~/ig_common/images/BateriaImg.png"; return; }
            if (ddlAssetType.SelectedItem.Text == "Cono") { imgOtherAsset.ImageUrl = "~/ig_common/images/ConoImg.png"; return; }
            if (ddlAssetType.SelectedItem.Text == "Pala") { imgOtherAsset.ImageUrl = "~/ig_common/images/PalaImg.png"; return; }
            if (ddlAssetType.SelectedItem.Text == "Botiquín") { imgOtherAsset.ImageUrl= "~/ig_common/images/botiquin.jpg"; return; }
            if (ddlAssetType.SelectedItem.Text == "Celular") { imgOtherAsset.ImageUrl = "~/ig_common/images/celular.jpg"; return; }
            if (ddlAssetType.SelectedItem.Text == "Cuña") { imgOtherAsset.ImageUrl = "~/ig_common/images/cuña.gif"; return; }
            if (ddlAssetType.SelectedItem.Text == "Extintor") { imgOtherAsset.ImageUrl = "~/ig_common/images/extintor.jpg"; return; }
            if (ddlAssetType.SelectedItem.Text == "Gata") { imgOtherAsset.ImageUrl = "~/ig_common/images/gata.jpg"; return; }
            if (ddlAssetType.SelectedItem.Text == "Pértiga") { imgOtherAsset.ImageUrl = "~/ig_common/images/pertiga.jpg"; return; }
            if (ddlAssetType.SelectedItem.Text == "Radio") { imgOtherAsset.ImageUrl = "~/ig_common/images/radio.jpg"; return; }
            if (ddlAssetType.SelectedItem.Text == "Tapa Ad Blue") { imgOtherAsset.ImageUrl = "~/ig_common/images/tapa-adblue.jpg"; return; }
            if (ddlAssetType.SelectedItem.Text == "Tapas petróleo") { imgOtherAsset.ImageUrl = "~/ig_common/images/tapa-petroleo.jpg"; return; }
            if (ddlAssetType.SelectedItem.Text == "Triángulos") { imgOtherAsset.ImageUrl = "~/ig_common/images/triangulos.jpg"; return; }
            if (ddlAssetType.SelectedItem.Text == "Yegua") { imgOtherAsset.ImageUrl = "~/ig_common/images/yegua.jpg"; return; }
            if (ddlAssetType.SelectedItem.Text == "Compresor Equipo de frio") { imgOtherAsset.ImageUrl = "~/ig_common/images/compresor.jpg"; return; }
            if (ddlAssetType.SelectedItem.Text == "Motor Equipo de Frio") { imgOtherAsset.ImageUrl = "~/ig_common/images/motor-diesel.gif"; return; }

            DivImage.Visible = false;

        }

        protected void AssetReadTag()
        {
            int id = new BcInspectionAndroid().GetUnitIdByPatent(lblPatentSelected.Text);
            int CodeAction = 0;
            int value = new BcInspectionAndroid().GetTypeById(ddlAssetType.SelectedValue);
            bool next =new BcInspectionAndroid().ValidateReadAsset(txbAsset.Text, id, value,  out CodeAction);

            if (next)
            {
                txbAsset.Style.Value = "Display:none";
                Session["TagAsset"] = txbAsset.Text;
                Session["Type"] = ddlAssetType.SelectedItem.Text.ToString();
                Response.Redirect("InspectionAssetPage.aspx", false);
            }
            else
            {
                Session["Contador"] = null;
                Session["CheckingType"] = ddlAssetType.SelectedItem;
                Session["ErrorNumber"] = CodeAction;
                Session["Type"] = ddlAssetType.SelectedItem.Text.ToString();
                Session["TagAsset"] = txbAsset.Text.ToString();
                Session["SendEmail"] = null;
                Session["SelectedType"] = ddlAssetType.SelectedItem;
                Response.Redirect("ErrorAndroidPage.aspx", false);
            }
            
        }

        protected void txbTagUnit_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        protected void txbAsset_TextChanged(object sender, EventArgs e)
        {
            AssetReadTag();
        }

        protected void ddlAssetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAssetType.SelectedItem.Text != "")
            {

                if (ddlAssetType.SelectedItem.Text != "Neumático")
                {


                    TyreSelected.Visible = false;
                    DivImage.Visible = true;
                    ChangeImage();
                    Session["Authorize"] = 1;
                    txbAsset.Visible = true;
                    txbAsset.Style.Value = "Display:visibility";
                }
                else
                {
                    TyreSelected.Visible = true;
                    DivImage.Visible = false;
                    txbTagUnit.Visible = true;
                    Session["Authorize"] = 1;
                    txbAsset.Visible = false;
                    txbTagUnit.Visible = false;
                    btnReadRfiTag2.Disabled = true;
                    txbAsset.Style.Value = "Display:none";
                }
            }
            else
            {
                TyreSelected.Visible = false;
                DivImage.Visible = false;
                txbAsset.Visible = false;
                txbAsset.Style.Value = "Display:none";
            }
        }

        protected void ChargeUnit(UnitRegister unitRegister)
        {
            string errorMessage = "";
            lblPatentSelected.Visible = true;
            lblInternalNumberSelected.Visible = true;
            lblInternalNumberSelected.Text = unitRegister.InternalNumber.ToString();
            lblPatentSelected.Text = unitRegister.PatentNumber.ToString();
            txbTagUnit.Style.Value = "Display:none";
            Asset.Visible = true;
            Session["Patent"] = unitRegister.PatentNumber;
            Session["internalNumber"] = unitRegister.InternalNumber;
            ///////////////////////
            Session["UnitRegisterFind"] = new BcInspectionAndroid().GetUnitRegisterIdByPatent(unitRegister.PatentNumber.ToString());
            int id = new BcInspectionAndroid().GetUnitIdByPatent(unitRegister.PatentNumber.ToString());
            ddlAssetType.DataSource = new BcInspectionAndroid().GetComboList(id, out errorMessage);
            ddlAssetType.DataBind();
            Session["dllAssetType"] = true;
            Session["UnitRegister"] = null;
            btnReadRfiTag.Visible = false;
            btnReadRfiTag2.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["Contador"] = null;
            Session["AssetVehicule"] = null;
            Session["UnitRegister"] = null;
            Response.Redirect("~/_PresentationLayer/AndroidModule/InspectionIndexAndroidPage.aspx", false);
        }

        protected void btnConfirmarPoppup_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            int kilometer = 0;
            UnitRegister unitRegister = (UnitRegister)Session["UnitRegister"];

            if (int.TryParse(txtObservation.Text, out kilometer))
                {
                if (unitRegister.KilometersOfTravel > kilometer)
                {
                    mpeConfirmar.Show();
                    lblError.Text = "Cantidad no valida";

                }
                else
                {
                    Session["UnitKilometers"] = txtObservation.Text;
                    unitRegister.KilometersOfTravel = kilometer;
                    new BcUnitRegister().Save(unitRegister, out errorMessage);
                    mpeConfirmar.Hide();
                    unitRegister = (UnitRegister)Session["UnitRegister"];
                    ChargeUnit(unitRegister);
                }
            }
            else
            {
                mpeConfirmar.Show();
                lblError.Text = "Digite solo numeros porfavor";
            }
            
        }
    }
}