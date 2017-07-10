using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using amis._Common;

namespace amis._PresentationLayer.Users
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(803);

            if (txtUserEmail.Text.ToUpper() == "VERSION")
            {
                litGetAmisWebVersion.Text = StringRoutines.GetAmisWebVersion();
                return;
            }

            if (!IsPostBack)
            {
                CleanPageValues();
                if (Session["FromChangePassword"] != null)
                {
                    Session["FromChangePassword"] = null;
                    Page.ShowPopupMessage("Contraseña modificada con éxito!");
                }
            }
        }

        public void CleanPageValues()
        {
            txtUserEmail.Text = "";
            txtUserPassword.Text = "";
        }

        protected void lnkbRecoveryPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPasswordPage.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string errorMessage = "";

            if (txtUserEmail.Text.ToUpper() == "VERSION") return;

                if (new BcAmisUser().CheckEmailFormat(txtUserEmail.Text, out errorMessage) == true)
            {
                AmisUser user = new BcAmisUser().GetUserByEmail(txtUserEmail.Text, out errorMessage);
                if (user != null)
                {
                    if (user.Enable == "Y")
                    {
                        string passWordEncrypted = new BcAmisUser().EncryptUserPassword(txtUserPassword.Text);
                        AmisUser usuarioToLogin = new BcAmisUser().GetUserInDB(txtUserEmail.Text, passWordEncrypted, out errorMessage);
                        if (usuarioToLogin != null)
                        {
                            this.SetUserId(usuarioToLogin.AmisUserId);
                            string description = "Se ha conectado el usuario: " + user.Name + ", con el id: " + user.AmisUserId;
                            //new DcPageLog().Save(CommonEnums.PageActionEnum.LogIn, description);
                            Response.Redirect("~/_PresentationLayer/Configuration/AmisHomePage.aspx");

                        }
                        else
                        {
                            Page.ShowPopupMessage(errorMessage);
                            CleanPageValues();
                            return;
                        }
                    }
                    else
                        errorMessage = "Su cuenta se encuentra deshabilitada";
                    Page.ShowPopupMessage(errorMessage);
                }
                else
                {
                    Page.ShowPopupMessage(errorMessage);
                    CleanPageValues();
                    return;
                }
            }
            else
                Page.ShowPopupMessage(errorMessage);
            CleanPageValues();
        }
    }
}