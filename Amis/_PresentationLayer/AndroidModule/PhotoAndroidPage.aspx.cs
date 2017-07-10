using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class PhotoAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string toRemove = "";
            string toRepair = "";
            if (Session["ToRemove"] != null)
            {
                 toRemove = (string)Session["ToRemove"]; ;
            }else
            if (Session["ToRepair"] != null)
            {
                 toRepair = (string)Session["ToRepair"];
            }

            if (toRemove != "Y" && toRepair != "Y")
            {
                Response.Redirect("RemoveInspectionAndroidPage.aspx");
            }
            else if (toRepair == "Y")
            {
                Session["ToRepair"] = null;
                Response.Redirect("RepairAssetAndroidPage.aspx");
            }
            else if (toRemove == "Y")
            {
                Session["ToRemove"] = null;
                Response.Redirect("RemoveAssetAndroidPage.aspx");
            } 
        }

        protected void btnRepetir_Click(object sender, EventArgs e)
        {

        }
    }
}