using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class RemoveTyreInspectionAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnChangePosition_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePositionAssetPage.aspx");
        }

        protected void btnDiscardTyre_Click(object sender, EventArgs e)
        {
            Session["ToRemove"] = "Y";
            Session["IsTyre"] = "Y";
            Session["Type"] = "Neumático";
            Response.Redirect("ReasonRemoveAndroidPage.aspx");
        }

        protected void btnRepair_Click(object sender, EventArgs e)
        {
            Session["IsTyre"] = "Y";
            Session["Type"] = "Neumático";
            Session["ToRepair"] = "Y";
            Response.Redirect("ReasonRemoveAndroidPage.aspx");
        }
    }
}