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
    public partial class ChangeTyreToAnotherUnit : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnReadTag_Click(object sender, EventArgs e)
        {

                txbTagUnit.Style.Value = "Display:visibility";
                txbTagUnit.Text = "";
                txbTagUnit.Visible = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            int CodeAction = 0;
            if (!new BcInspectionAndroid().ValidateSearchUnit(txbTagUnit.Text, out CodeAction))
            {
                Session["Contador2"] = null;
                Session["ErrorNumber"] = CodeAction;
                Session["SendEmail"] = null;
                Session["FromInspectionChange"] = 1;
                Response.Redirect("ErrorAndroidPage.aspx");
            }

            UnitRegister unitRegister = new BcInspectionAndroid().SearchUnitByTag2(txbTagUnit.Text, out errorMessage);
            if (unitRegister != null)
            {
                lblPatentSelected.Visible = true;
                lblInternalNumberSelected.Visible = true;
                lblInternalNumberSelected.Text = unitRegister.InternalNumber.ToString();
                lblPatentSelected.Text = unitRegister.PatentNumber.ToString();
                txbTagUnit.Style.Value = "Display:none";
                Session["Patent2"] = unitRegister.PatentNumber;
                Session["internalNumber2"] = unitRegister.InternalNumber;
                ///////////////////////
                Session["UnitRegisterFind2"] = new BcInspectionAndroid().GetUnitRegisterIdByPatent(unitRegister.PatentNumber.ToString()).ToString();
                int id = new BcInspectionAndroid().GetUnitIdByPatent(unitRegister.PatentNumber.ToString());
                if (Session["FromReplace"] != null)
                {
                    Response.Redirect("SelectionAnotherUnitToReplacePage.aspx");
                }
                else if (Session["FromInspection"] != null)
                {
                    Session["FromInspection"] = null;
                    Response.Redirect("SelectionAnotherUnitTyrePage.aspx");
                }
                    
            }
            else
            {
                Session["Contador2"] = null;
                Page.ShowSmallPopupMessage(errorMessage);
            }
        }

        protected void btnCantReadTag_Click(object sender, EventArgs e)
        {
            Session["ErrorNumber"] = 7;
            Session["SendEmail"] = null;
            Response.Redirect("ErrorAndroidPage.aspx");
        }

        protected void btnWrongFacility_Click(object sender, EventArgs e)
        {
            Response.Redirect("WrongTagInspectionPage.aspx");
        }
    }
}