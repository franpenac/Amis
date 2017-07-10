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
    public partial class SelectBranchOfficeAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string errorMessage = "";
            ddlSelectedBranchOffice.DataSource = new BcInspectionAndroid().GetComboListBranchOfficeUser(this.UserId(), out errorMessage);
            ddlSelectedBranchOffice.DataBind();
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            Session["BranchOfficeId"] = new BcInspectionAndroid().GetIdBranchOfficeByName(ddlSelectedBranchOffice.SelectedValue, out errorMessage);
            Response.Redirect("~/_PresentationLayer/AndroidModule/MenuAndroidPage.aspx");
        }
    }
}