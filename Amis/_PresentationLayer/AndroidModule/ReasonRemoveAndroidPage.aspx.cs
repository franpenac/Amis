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
    public partial class ReasonRemoveAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Action"] == null)
            {
                string tag = (string)Session["TagAsset"];
                string url = new BcInspectionAndroid().SearchUrlByTag(tag);
                ChangeImage(url);

                string errorMesage = "";
                ddlScrapType.DataSource = new BcInspectionAndroid().GetComboListScrapName(url, out errorMesage);
                ddlScrapType.DataBind();
                Session["Action"] = 1;
            }
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

        protected void btnPhoto_Click(object sender, EventArgs e)
        {
            int id = new BcInspectionAndroid().SearchScrapIdByName(ddlScrapType.SelectedItem.Text);
            Session["ScrapType"] = id;
            if (ddlScrapType.SelectedValue != "0")
            {
                Session["Action"] = null;
                Response.Redirect("PhotoAndroidPage.aspx");
            }
            else
            {
                Page.ShowSmallPopupMessage("Debe seleccionar una razón antes de poder sacar la fotografía");
            }
        }

        protected void ddlScrapType_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}