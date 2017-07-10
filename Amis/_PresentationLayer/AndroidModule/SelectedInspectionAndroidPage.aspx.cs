using amis._BusinessLayer.GeneratedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class SelectedInspectionAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string tittle = (string)Session["Tittle"];
            lblTittle.Text = tittle;
            string tag = (string)Session["TagAsset"];
            string url = new BcInspectionAndroid().SearchUrlByTag(tag);
            ChangeImage(url);
            mpeAnotherReplace.Show();
        }

        protected void ChangeImage(string type)
        {

            if (type == "Batería") { Image1.ImageUrl = "~/ig_common/images/BateriaImg.png"; return; }
            if (type == "Cono") { Image1.ImageUrl = "~/ig_common/images/ConoImg.png"; return; }
            if (type == "Pala") { Image1.ImageUrl = "~/ig_common/images/PalaImg.png"; return; }
            if (type == "Botiquín") { Image1.ImageUrl = "~/ig_common/images/botiquin.jpg"; return; }
            if (type == "Celular") { Image1.ImageUrl = "~/ig_common/images/celular.jpg"; return; }
            if (type == "Cuña") { Image1.ImageUrl = "~/ig_common/images/cuña.gif"; return; }
            if (type == "Extintor") { Image1.ImageUrl = "~/ig_common/images/extintor.jpg"; return; }
            if (type == "Gata") { Image1.ImageUrl = "~/ig_common/images/gata.jpg"; return; }
            if (type == "Pértiga") { Image1.ImageUrl = "~/ig_common/images/pertiga.jpg"; return; }
            if (type == "Radio") { Image1.ImageUrl = "~/ig_common/images/radio.jpg"; return; }
            if (type == "Tapa Ad Blue") { Image1.ImageUrl = "~/ig_common/images/tapa-adblue.jpg"; return; }
            if (type == "Tapas petróleo") { Image1.ImageUrl = "~/ig_common/images/tapa-petroleo.jpg"; return; }
            if (type == "Triángulos") { Image1.ImageUrl = "~/ig_common/images/triangulos.jpg"; return; }
            if (type == "Yegua") { Image1.ImageUrl = "~/ig_common/images/yegua.jpg"; return; }
            if (type == "Compresor Equipo de frio") { Image1.ImageUrl = "~/ig_common/images/compresor.jpg"; return; }
            if (type == "Motor Equipo de Frio") { Image1.ImageUrl = "~/ig_common/images/motor-diesel.gif"; return; }
            if (type == "Neumático") { Image1.ImageUrl = "~/ig_common/configurations/BlackTyre.png"; return; }
        }


        protected void btnConfirmarPoppup_Click(object sender, EventArgs e)
        {
            string tag = (string)Session["TagAsset"];
            Session["dllAssetType"] = null;
            Session["NothingAction"] = null;
            Session["TagAsset"] = null;
            Session["Contador"] = null;

            Session["ErrorNumber"] = null;
            Response.Redirect("InspectionIndexAndroidPage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session["NothingAction"] = null;
            Session["dllAssetType"] = null;
            Session["AssetVehicule"] = null;
            Session["TagAsset"] = null;
            Session["UnitRegisterFind"] = null;
            Session["Contador"] = null;
            Session["ErrorNumber"] = null;

            Response.Redirect("InspectionIndexAndroidPage.aspx");
        
    }

        protected void btnConffirmAnotherReplace_Click(object sender, EventArgs e)
        {
            //imgchkYe.ImageUrl = "~/ig_common/images/check-ed.png";
            //imgchkNo.ImageUrl = "~/ig_common/images/unchecked.png";
            mpeAnotherReplace.Hide();
            mpeConfirmar.Show();
            //Option.Visible = true;
        }

        protected void btnNoAnotherReplace_Click(object sender, EventArgs e)
        {
            Session["NothingAction"] = null;
            Session["dllAssetType"] = null;
            Session["TagAsset"] = null;
            Session["UnitRegisterFind"] = null;
            Session["Contador"] = null;
            Session["ErrorNumber"] = null;
            Session["AssetVehicule"] = null;
            Response.Redirect("MenuAndroidPage.aspx");
        }
    }
}