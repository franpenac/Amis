using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class SelectReplaceTyreDestiny : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIntoTheSameUnit_Click(object sender, EventArgs e)
        {
            string buttonId = (string)Session["TyreTagReplacePosition"];
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            foreach (Button item in listButtons)
            {
                if (item.ID != buttonId)
                {
                    item.Enabled = true;
                }
            }
            Session["IsReplace"] = 1;
            Session["ListButtonsToReplace"] = listButtons;
            Response.Redirect("SelectReplaceToSameUnitTyre.aspx");
        }

        protected void btnToWareHouse_Click(object sender, EventArgs e)
        {
            Session["isReplace"] = 1;
            Response.Redirect("ChangeAssetToAnotherWarehouse.aspx");
        }

        protected void btnToAnotherUnit_Click(object sender, EventArgs e)
        {
            Session["FromReplace"] = 1;
            Response.Redirect("ChangeTyreToAnotherUnit.aspx");
        }

        protected void btnToAnotherUnitOnRoad_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReplaceTyreOnRoad.aspx");
        }
    }
}