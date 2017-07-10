using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Infragistics.Web.UI.EditorControls;
using System.Web;
using System.ComponentModel;

namespace amis._PresentationLayer.Users
{
    public partial class ForgotPasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["lblWo"] = null;
                Session["userEmail"] = null;
                Session["ChangePasswordCode"] = null;
            }
        }

        protected void btnRecoveryPassword_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            BcAmisUser bcUser = new BcAmisUser();
            if (bcUser.CheckEmailFormat(txtRecoveryUserEmail.Text, out errorMessage))
            {
                AmisUser ams = new BcAmisUser().GetUserByEmail(txtRecoveryUserEmail.Text, out errorMessage);
                if (ams != null)
                {
                    if (wbcRecoveryPassword.IsValid == true && wbcRecoveryPassword.InputValueEditor.Text != "")
                    {
                        if (ams.Enable == "Y")
                        {
                            Page.ShowPopupMessage("Revise su correo para validar el cambio.");                                       
                            Session["lblWo"] = HttpContext.Current.Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped);
                            Session["userEmail"] = ams.Email;
                            Session["ChangePasswordCode"] = ams.ChangePasswordCode;
                            BackgroundWorker task = new BackgroundWorker();
                            task.DoWork += new DoWorkEventHandler(SendEmail);
                            task.RunWorkerAsync();
                        }
                        else
                        {
                            Page.ShowPopupMessage("No puede realizar esta acción, ya que su cuenta se encuenta deshabilitada, contactese con el administrador.");
                        }
                    }
                }
                else
                {
                    Page.ShowPopupMessage(errorMessage);
                }

            }else
            {
                Page.ShowPopupMessage(errorMessage);
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void SendEmail(object o, DoWorkEventArgs e)
        {
            string userEmail = (string)Session["userEmail"];
            string changePass = (string)Session["ChangePasswordCode"];
            string lbl = (string)Session["lblWo"];
            new BcAmisUser().SendMailAsync(userEmail, changePass, lbl);           
        }
    }
}