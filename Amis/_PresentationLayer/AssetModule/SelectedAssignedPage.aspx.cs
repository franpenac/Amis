using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AssetModule
{
    public partial class SelectedAssignedPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConecction_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssetAndroidPage",false);
        }

        protected void btnCalibration_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnitAndroidPage", false);

        }

        protected void btnAsignationTag_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/MenuAndroidPage.aspx");
        }
    }
}