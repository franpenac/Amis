using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;

namespace amis._PresentationLayer.Users
{
    public partial class ChangePasswordPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divNewPassword.Visible = false;
            }

        }

        protected void btnCheckCode_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            AmisUser userToValidateCode = new BcAmisUser().GetUserByCode(txtChangePasswordCode.Text, out errorMessage);
            if (userToValidateCode != null)
            {
                divNewPassword.Visible = true;
                txtChangePasswordCode.ReadOnly = true;
                btnCheckCode.Enabled = false;
            }else
            {
                Page.ShowPopupMessage(errorMessage);
                divNewPassword.Visible = false;
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            AmisUser userChangePassword = new BcAmisUser().GetUserByCode(txtChangePasswordCode.Text, out errorMessage);
            string newPassword = new BcAmisUser().EncryptUserPassword(txtNewPassword.Text);
            string repeatPassword = new BcAmisUser().EncryptUserPassword(txtRepeatPassword.Text);
            if (new BcAmisUser().validatePasswordSecurity(txtNewPassword.Text, out errorMessage))
            {
                if (new BcAmisUser().ComparePasswords(newPassword, repeatPassword, out errorMessage))
                {
                    new BcAmisUser().ChangePassword(userChangePassword.AmisUserId, newPassword, out errorMessage);
                    string changePasswordCode = new BcAmisUser().GenerateStringToChangePassword();
                    new BcAmisUser().ChangeUserPasswordCode(changePasswordCode, userChangePassword.Email);
                    if (userChangePassword.Enable == "N")
                    {
                        new BcAmisUser().EnabledUser(userChangePassword.AmisUserId, "Y");
                    }
                    Session["FromChangePassword"] = 1;
                    Response.Redirect("LoginPage.aspx");
                }else
                {
                    Page.ShowPopupMessage(errorMessage);
                }
            }
            else
            {
                Page.ShowPopupMessage(errorMessage);
            }
        }
        protected void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}