using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class SelectRegisterTagOption : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBackToMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/MenuAndroidPage.aspx");
        }

        protected void btnAsset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/RegisterTagAndroidPage.aspx");
        }

        protected void btnUnit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/RegisterManyTagsAndroidPage.aspx");
        }
    }
}