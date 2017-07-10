using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class InventoryEndAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Asset> listNoTyreFind = (List<Asset>)Session["ListAssetNoTyreFind"];
            List<Asset> listTyreFind = (List<Asset>)Session["ListAssetTyreFind"];

            List<Asset> listNoTyre = (List<Asset>)Session["ListAssetNoTyre"];
            List<Asset> listTyre = (List<Asset>)Session["ListAssetTyre"];

           
            lblNoTyre.Text = lblNoTyre.Text + (listNoTyreFind.Count()/2).ToString();
            lblTyre.Text = lblTyre.Text + listTyreFind.Count().ToString();
            lblMessageNoTyre.Text = lblMessageNoTyre.Text + listNoTyre.Count().ToString();
            lblMessageTyre.Text = lblMessageTyre.Text + listTyre.Count().ToString();
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Session["isCorrect"] = 1;
            Response.Redirect("InventoryNoTyreAndroidPage.aspx",false);
        }

        protected void btnEnd_Click(object sender, EventArgs e)
        {
            Session["Inventory"] = 1;
            Session["ErrorNumber"] = 13;
            Session["SendEmail"] = null;
            Response.Redirect("ErrorAndroidPage.aspx", false);
        }
    }
}