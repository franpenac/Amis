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
    public partial class AssignedToUnitAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string type = (string)Session["AssetTypeName"];
                ChangeImageBlack(type);
                
                int id = (int)Session["UnitRegisterFind"];
                string errorMessage = "";
                UnitRegister unit = new BcUnitRegister().GetUnitRegisterById(id, out errorMessage);
                lblPatentSelected.Visible = true;
                lblInternalNumberSelected.Visible = true;
                lblInternalNumberSelected.Text = unit.InternalNumber.ToString();
                lblPatentSelected.Text = unit.PatentNumber.ToString();
                btnAssigned.Enabled = false;
                
            }
        }

        protected void btnAssigned_Click(object sender, EventArgs e)
        {
                int unitId = (int)Session["UnitId"];
                string tagCode = (string)Session["TagCode"];
                Asset asset = new BcInspectionAndroid().SearchAssetByTag(tagCode);
                UnitAsset ua = new UnitAsset();
                ua.AssetId = asset.AssetId;
                ua.UnitId = unitId;
                ua.AssignedDate = DateTime.Now;
                string errorMessage = "";

                if (new BcUnitAsset().Save(ua, out errorMessage)!=null)
                {
                    //lblError.Text = "Se ha asignado correctamente el activo!";
                    // GetTimeHide();
                    btnAssigned.Enabled = false;
                mpeAnotherReplace.Show();
                    btnBack.Visible = false;

                }
                else
                {
                lblError.Text = errorMessage;
                GetTimeHide();

                }
        }

        protected void ImageButton1_Click(object sender, EventArgs e)
        {
            //imgchkYe.ImageUrl = "~/ig_common/images/check-ed.png";
            //imgchkNo.ImageUrl = "~/ig_common/images/unchecked.png";
            mpeAnotherReplace.Hide();
            mpeConfirmar.Show();
        }

        protected void imgchkNo_Click(object sender, EventArgs e)
        {
            Session["NothingAction"] = null;
            Session["AssetTypeName"] = null;
            Session["TagCode"] = null;
            Session["UnitRegisterFind"] = null;
            Session["Contador"] = null;
            Session["UnitId"] = null;
            Session["ErrorNumber"] = null;

            Response.Redirect("MenuAndroidPage.aspx", false);
        }

        protected void imgchkSame_Click(object sender, EventArgs e)
        {
            Session["NothingAction"] = null;
            Session["AssetTypeName"] = null;
            Session["TagCode"] = null;
            Session["Contador"] = null;
            Session["UnitId"] = null;
            Session["ErrorNumber"] = null;

            Response.Redirect("AssignedAssetToUnitAndroidPage.aspx", false);
        }

        protected void imgchkOther_Click(object sender, EventArgs e)
        {
            Session["NothingAction"] = null;
            Session["AssetTypeName"] = null;
            Session["TagCode"] = null;
            Session["UnitRegisterFind"] = null;
            Session["Contador"] = null;
            Session["UnitId"] = null;
            Session["ErrorNumber"] = null;

            Response.Redirect("AssignedAssetToUnitAndroidPage.aspx", false);
        }

        protected void ChangeImage(string type)
        {

            if (type == "Batería") { imgAssetType.ImageUrl = "~/ig_common/images/BateriaImg.png"; return; }
            if (type == "Cono") { imgAssetType.ImageUrl = "~/ig_common/images/ConoImg.png"; return; }
            if (type == "Pala") { imgAssetType.ImageUrl = "~/ig_common/images/PalaImg.png"; return; }
            if (type == "Botiquín") { imgAssetType.ImageUrl = "~/ig_common/images/botiquin.jpg"; return; }
            if (type == "Celular") { imgAssetType.ImageUrl = "~/ig_common/images/celular.jpg"; return; }
            if (type == "Cuña") { imgAssetType.ImageUrl = "~/ig_common/images/cuña.gif"; return; }
            if (type == "Cuñas") { imgAssetType.ImageUrl = "~/ig_common/images/cuña.gif"; return; }
            if (type == "Extintor") { imgAssetType.ImageUrl = "~/ig_common/images/extintor.jpg"; return; }
            if (type == "Gata") { imgAssetType.ImageUrl = "~/ig_common/images/gata.jpg"; return; }
            if (type == "Pértiga") { imgAssetType.ImageUrl = "~/ig_common/images/pertiga.jpg"; return; }
            if (type == "Radio") { imgAssetType.ImageUrl = "~/ig_common/images/radio.jpg"; return; }
            if (type == "Tapa Ad Blue") { imgAssetType.ImageUrl = "~/ig_common/images/tapa-adblue.jpg"; return; }
            if (type == "Tapas petróleo") { imgAssetType.ImageUrl = "~/ig_common/images/tapa-petroleo.jpg"; return; }
            if (type == "Triángulos") { imgAssetType.ImageUrl = "~/ig_common/images/triangulos.jpg"; return; }
            if (type == "Yegua") { imgAssetType.ImageUrl = "~/ig_common/images/yegua.jpg"; return; }
            if (type == "Compresor Equipo de frio") { imgAssetType.ImageUrl = "~/ig_common/images/compresor.jpg"; return; }
            if (type == "Motor Equipo de Frio") { imgAssetType.ImageUrl = "~/ig_common/images/motor-diesel.gif"; return; }

        }

        protected void ChangeImageBlack(string type)
        {

            if (type == "Batería") { imgAssetType.ImageUrl = "~/ig_common/images/Bateria_negra.png"; return; }
            if (type == "Cono") { imgAssetType.ImageUrl = "~/ig_common/images/Cono_negra.png"; return; }
            if (type == "Pala") { imgAssetType.ImageUrl = "~/ig_common/images/Pala_negra.png"; return; }
            if (type == "Botiquín") { imgAssetType.ImageUrl = "~/ig_common/images/botiquin_negra.png"; return; }
            if (type == "Celular") { imgAssetType.ImageUrl = "~/ig_common/images/celular_negra.png"; return; }
            if (type == "Cuña") { imgAssetType.ImageUrl = "~/ig_common/images/cuña_negra.png"; return; }
            if (type == "Cuñas") { imgAssetType.ImageUrl = "~/ig_common/images/cuña_negra.png"; return; }
            if (type == "Extintor") { imgAssetType.ImageUrl = "~/ig_common/images/extintor_negro.png"; return; }
            if (type == "Gata") { imgAssetType.ImageUrl = "~/ig_common/images/gata_negra.png"; return; }
            if (type == "Pértiga") { imgAssetType.ImageUrl = "~/ig_common/images/pertiga_negra.png"; return; }
            if (type == "Radio") { imgAssetType.ImageUrl = "~/ig_common/images/radio_negra.png"; return; }
            if (type == "Tapa Ad Blue") { imgAssetType.ImageUrl = "~/ig_common/images/tapa-adblue_negra.png"; return; }
            if (type == "Tapas petróleo") { imgAssetType.ImageUrl = "~/ig_common/images/tapa-petroleo_negra.png"; return; }
            if (type == "Triángulos") { imgAssetType.ImageUrl = "~/ig_common/images/triangulos_negra.png"; return; }
            if (type == "Yegua") { imgAssetType.ImageUrl = "~/ig_common/images/yegua_negra.png"; return; }
            if (type == "Compresor Equipo de frio") { imgAssetType.ImageUrl = "~/ig_common/images/compresor_negra.png"; return; }
            if (type == "Motor Equipo de Frio") { imgAssetType.ImageUrl = "~/ig_common/images/motor-diesel_negra.png"; return; }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["NothingAction"] = null;
            Session["AssetTypeName"] = null;
            Session["TagCode"] = null;
            Session["Contador"] = null;
            Session["UnitId"] = null;
            Session["ErrorNumber"] = null;

            Response.Redirect("AssignedAssetToUnitAndroidPage.aspx", false);
        }

        protected void timer_Tick(object sender, EventArgs e)
        {
            if (Session["timer"] != null)
            {
                int tiempo = (int)Session["timer"];
                if (tiempo == DateTime.Now.Second)
                {
                    timer.Enabled = false;
                    Error.Visible = false;
                    Session["timer"] = null;
                }
            }
        }

        protected void GetTimeHide()
        {
            timer.Enabled = true;
            timer.Interval = 25;
            int valor = 2;
            if (DateTime.Now.Second + valor > 59)
            {
                Session["timer"] = 2;
            }
            else { Session["timer"] = DateTime.Now.Second + valor; }
            Error.Visible = true;
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            string tagCode = txbAssetRead.Text;
            int assetTypeId = (int)Session["AssetTypeId"];
            int unitId = (int)Session["UnitId"];
            int CodeAction = 0;

            bool ok = new BcAssignedAssetToUnit().ValidateReadAsset(tagCode, unitId, assetTypeId, out CodeAction);

            if (!ok)
            {
                if (CodeAction == 0)
                {
                    lblError.Text = "El activo seleccionado, ya esta asignado a la unidad inspeccionada.";
                    GetTimeHide();
                    return;
                }
                else
                {
                    Session["SendEmail"] = null;
                    Session["ErrorNumber"] = CodeAction;
                    Session["Page"] = 1;
                    Session["TagCode"] = tagCode;
                    Session["AssetAssignedPage"] = true;
                    string assetTypeName = new BcAssetType().GetAssetTypeNameById(assetTypeId);
                    Session["Type"] = assetTypeName;
                    Response.Redirect("ErrorAndroidPage.aspx", false);
                }
            }
            txbAssetRead.Visible = false;
            string type = (string)Session["AssetTypeName"];
            Session["TagCode"] = txbAssetRead.Text;
            ChangeImage(type);
            btnAssigned.Enabled = true;
        }
    }
}