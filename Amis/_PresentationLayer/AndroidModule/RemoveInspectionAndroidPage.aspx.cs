using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class RemoveInspectionAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["NothingAction"] == null)
            {
                Response.Redirect("RemoveAssetAndroidPage.aspx");
            }
            else
            {
                Session["NothingAction"] = null;
                Session["TagAsset"] = null;
                Session["Contador"] = null;
                Session["ErrorNumber"] = null;
                Session["dllAssetType"] = null;
                Response.Redirect("InspectionIndexAndroidPage.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Session["NothingAction"] == null)
            {
                Response.Redirect("RepairAssetAndroidPage.aspx");
            }
            else
            {
                Session["NothingAction"] = null;
                Session["TagAsset"] = null;
                Session["UnitRegisterFind"] = null;
                Session["Contador"] = null;
                Session["ErrorNumber"] = null;
                Response.Redirect("InspectionIndexAndroidPage.aspx");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Session["NothingAction"] == null)
            {
                tittle.InnerText = "Inspeccionar";
                lblSubTittle.ForeColor = System.Drawing.Color.Red;
                lblSubTittle.Text = "Se ha enviado un mensaje de aviso a su supervisor con su " +
                    "desición de no hacer nada con el activo en malas condiciones";
                tblNewInspection.Visible = true;
                Button1.Text = "Misma unidad";
                Button2.Text = "Otra unidad";
                Button3.Text = "No deseo";

                Session["NothingAction"] = 1;
            }
            else
            {
                Session["NothingAction"] = null;
                Session["TagAsset"] = null;
                Session["UnitRegisterFind"] = null;
                Session["Contador"] = null;
                Session["ErrorNumber"] = null;
                Response.Redirect("MenuAndroidPage.aspx");
            }
        }

      
    }
}