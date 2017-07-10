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
    public partial class SelectUnitToReplaceTyre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            InitializeControls();
            }

        }

        private void InitializeControls()
        {
            Session["Contador"] = null;
            Session["ErrorNumber"] = null;
            Session["SendEmail"] = null;
            Session["Patent"] = null;
            Session["internalNumber"] = null;
            Session["UnitRegisterFind"] = null;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            int CodeAction = 0;
            if (!new BcInspectionAndroid().ValidateSearchUnit(txbTagUnit.Text, out CodeAction))
            {
                Session["Contador"] = null;
                Session["ErrorNumber"] = CodeAction;
                Session["SendEmail"] = null;
                Session["fromReplaceError"] = 1;
                Response.Redirect("ErrorAndroidPage.aspx");
            }

            UnitRegister unitRegister = new BcInspectionAndroid().SearchUnitByTag(txbTagUnit.Text, out errorMessage);
            if (unitRegister != null)
            {
                lblPatentSelected.Visible = true;
                lblInternalNumberSelected.Visible = true;
                lblInternalNumberSelected.Text = unitRegister.InternalNumber.ToString();
                lblPatentSelected.Text = unitRegister.PatentNumber.ToString();
                txbTagUnit.Style.Value = "Display:none";
                Session["Patent"] = unitRegister.PatentNumber;
                Session["internalNumber"] = unitRegister.InternalNumber;
                ///////////////////////
                Session["UnitRegisterFind"] = new BcInspectionAndroid().GetUnitRegisterIdByPatent(unitRegister.PatentNumber.ToString());
                int id = new BcInspectionAndroid().GetUnitIdByPatent(unitRegister.PatentNumber.ToString());
                Response.Redirect("SelectionReplaceTyrePage.aspx");
            }
            else
            {
                Session["Contador"] = null;
                Page.ShowSmallPopupMessage(errorMessage);
            }

        }

        protected void btnCantReadTag_Click(object sender, EventArgs e)
        {
            Session["CantRead"] = 7;
            Session["BadTyreTag"] = 1;
            Response.Redirect("WrongTagInspectionPage.aspx", false);
            //Session["ErrorNumber"] = 7;
            //Session["SendEmail"] = null;
            //Response.Redirect("ErrorAndroidPage.aspx");
        }

        protected void btnWrongFacility_Click(object sender, EventArgs e)
        {
            Response.Redirect("WrongTagInspectionPage.aspx");
        }

        protected void txbTagUnit_TextChanged(object sender, EventArgs e)
        {
            
            btnSearch_Click(sender, e);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["ErrorNumber"] = null;
            Session["SendEmail"] = null;
            Session["Contador"] = null;
            Session["Patent"] = null;
            Session["internalNumber"] = null;
            Session["UnitRegisterFind"] = null;
            Response.Redirect("MenuAndroidPage.aspx");
        }
    }
}