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
    public partial class ChangePasswordAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                    Page.ShowSmallPopupMessage(errorMessage);
                }
                else
                {
                    Page.ShowSmallPopupMessage(errorMessage);
                }
            }
            else
            {
                Page.ShowSmallPopupMessage(errorMessage);
            }
        }

        protected void btnBackToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginAndroidPage.aspx");
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
            }
            else
            {
                Page.ShowPopupMessage(errorMessage);
                divNewPassword.Visible = false;
            }
        }
    }
}