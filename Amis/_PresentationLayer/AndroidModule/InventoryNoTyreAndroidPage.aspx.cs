using amis._Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using amis._BusinessLayer.GeneratedCode;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class InventoryNoTyreAndroidPage : System.Web.UI.Page
    {
        private string openTable = "<table style=\"width: 100%;\">";
        private string closeTable = "</table>";

        private string openTr = "<tr>";
        private string closeTr = "</tr>";

        private string openTd = "<td style=\"width: 20%\"></td>";
        private string closeTd = "<td style=\"width: 20%\"></td>";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ListCode"] != null)
                {
                    lblPatentSelected.Text = (string)Session["Patent"];
                    lblInternalNumberSelected.Text = (string)Session["internalNumber"];

                    List<string> listCode = (List<string>)Session["ListCode"];
                    ChargeDivChange(listCode);
                }
                else
                {
                    lblPatentSelected.Text = (string)Session["Patent"];
                    lblInternalNumberSelected.Text = (string)Session["internalNumber"];
                    ChargeDivInit();
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["Contador"] = null;
            Response.Redirect("InventoryIndexAndroidPage.aspx");
        }

        protected void ChargeDivInit()
        {
            List<Asset> listAsset = (List<Asset>)Session["ListAssetNoTyre"];
            int contador = 1;
            divAssets.InnerHtml = "";
            string html = "";
            if (Session["html"] != null)
            {
                html = (string)Session["hmtl"];
                divAssets.InnerHtml = html;
            }
            else
            {
                html = openTable + openTr + openTd;
                foreach (Asset asset in listAsset)
                {
                    Tag tag = new BcTag().GetTagByAssetId(asset.AssetId);
                    string assetType = new BcAssetType().GetAssetTypeNameByAssetId(asset.AssetId);
                    string url = ChangeImageBlack(assetType);
                    html = html + "<td style=\"width: 20%\">" + "<img id='" + "btn" + tag.TagCode + "' width='60px' height='60px' src='"+url+"' />" + "</td>";
                    if (contador == 3)
                    {
                        html = html + closeTd + closeTr + openTr + openTd;
                        contador = 0;
                    }
                    contador = contador + 1;
                }
                Session["html"] = html = html + closeTd + closeTr + closeTable;
                divAssets.InnerHtml = html;
            }
        }

        protected void ChargeDivChange(List<string> listCode)
        {
            List<Asset> listAsset = (List<Asset>)Session["ListAssetNoTyre"];
            
            int contador = 1;
            bool ok = true;

            divAssets.InnerHtml = "";
            string html = openTable + openTr + openTd;

            foreach(Asset asset in listAsset)
            {
                Tag tag = new BcTag().GetTagByAssetId(asset.AssetId);
                string assetType = new BcAssetType().GetAssetTypeNameByAssetId(asset.AssetId);
                string urlBlack = ChangeImageBlack(assetType);
                string url = ChangeImage(assetType);
                ok = true;
                
                foreach (string code in listCode)
                {
                    if (code == tag.TagCode)
                    {
                        string errorMessage = "";
                        html = html + "<td style=\"width: 20%\">" + "<img id='" + "btn" + tag.TagCode + "' width='60px' height='60px' src='"+url+"' />" + "</td>";
                        Asset newAsset =new BcAsset().GetAssetByTag(tag.TagCode, out errorMessage);
                        List<Asset> listado =(List<Asset>)Session["ListAssetNoTyreFind"];
                     
                            { listado.Add(newAsset); }
                        
                        listado.Add(newAsset);
                        Session["ListAssetNoTyreFind"] = listado;
                        ok = false;
                        break;
                    }
                }

                if (ok == true)
                {
                    html = html + "<td style=\"width: 20%\">" + "<img id='" + "btn" + tag.TagCode + "' width='60px' height='60px' src='"+ urlBlack+"' />" + "</td>";
                }

                if (contador == 3)
                {
                    html = html + closeTd + closeTr + openTr + openTd;
                    contador = 0;
                }
                contador = contador + 1;
            }
           
            Session["html"] = html = html + closeTd + closeTr + closeTable;
            divAssets.InnerHtml = html;
        }

        protected string ChangeImage(string type)
        {
            if (type == "Batería") { return "../../ig_common/images/BateriaImg.png"; }
            if (type == "Cono") { return "../../ig_common/images/ConoImg.png"; }
            if (type == "Pala") { return "../../ig_common/images/PalaImg.png"; }
            if (type == "Botiquín") { return "../../ig_common/images/botiquin.jpg"; }
            if (type == "Celular") { return "../../ig_common/images/celular.jpg"; }
            if (type == "Cuña") { return "../../ig_common/images/cuña.gif"; }
            if (type == "Extintor") { return "../../ig_common/images/extintor.jpg"; }
            if (type == "Gata") { return "../../ig_common/images/gata.jpg"; }
            if (type == "Pértiga") { return "../../ig_common/images/pertiga.jpg"; }
            if (type == "Radio") { return "../../ig_common/images/radio.jpg"; }
            if (type == "Tapa Ad Blue") { return "../../ig_common/images/tapa-adblue.jpg"; }
            if (type == "Tapas petróleo") { return "../../ig_common/images/tapa-petroleo.jpg"; }
            if (type == "Triángulos") { return "../../ig_common/images/triangulos.jpg"; }
            if (type == "Yegua") { return "../../ig_common/images/yegua.jpg"; }
            if (type == "Compresor Equipo de frio") { return "../../ig_common/images/compresor.jpg"; }
            if (type == "Motor Equipo de Frio") { return "../../ig_common/images/motor-diesel.gif"; }
            return "";
        }

        protected string ChangeImageBlack(string type)
        {

            if (type == "Batería") { return "../../ig_common/images/Bateria_negra.png"; }
            if (type == "Cono") { return "../../ig_common/images/Cono_negra.png"; }
            if (type == "Pala") { return "../../ig_common/images/Pala_negra.png"; }
            if (type == "Botiquín") { return "../../ig_common/images/botiquin_negra.png"; }
            if (type == "Celular") { return "../../ig_common/images/celular_negra.png"; }
            if (type == "Cuña") { return "../../ig_common/images/cuña_negra.png"; }
            if (type == "Extintor") { return "../../ig_common/images/extintor_negro.png"; }
            if (type == "Gata") { return "../../ig_common/images/gata_negra.png"; }
            if (type == "Pértiga") { return "../../ig_common/images/pertiga_negra.png"; }
            if (type == "Radio") { return "../../ig_common/images/radio_negra.png"; }
            if (type == "Tapa Ad Blue") { return "../../ig_common/images/tapa-adblue_negra.png"; }
            if (type == "Tapas petróleo") { return "../../ig_common/images/tapa-petroleo_negra.png"; }
            if (type == "Triángulos") { return "../../ig_common/images/triangulos_negra.png"; }
            if (type == "Yegua") { return "../../ig_common/images/yegua_negra.png"; }
            if (type == "Compresor Equipo de frio") { return "../../ig_common/images/compresor_negra.png"; }
            if (type == "Motor Equipo de Frio") { return "../../ig_common/images/motor-diesel_negra.png"; }
            return "";
        }

        protected void btnReadTag_Click(object sender, EventArgs e)
        {
            if (Session["ListCode"] == null)
            {
                string code = TextBox1.Text;
                List<string> listCode = new List<string>();
                listCode.Add(code);
                Session["ListCode"] = listCode;
                Response.Redirect("InventoryNoTyreAndroidPage.aspx", false);
            }
            else
            {
                string code = TextBox1.Text;
                List<string> listCode = (List<string>)Session["ListCode"];
                listCode.Add(code);
                Session["ListCode"] = listCode;
                Response.Redirect("InventoryNoTyreAndroidPage.aspx", false);
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("InventoryTyreAndroidPage.aspx",false);
        }
    }
}