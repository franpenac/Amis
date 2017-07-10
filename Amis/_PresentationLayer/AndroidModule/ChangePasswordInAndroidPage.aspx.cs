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
    public partial class ChangePasswordInAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {

            string errorMessage = "";
            string currentPassword = new BcAmisUser().EncryptUserPassword(txtCurrentPassword.Text);
            string newPassword = new BcAmisUser().EncryptUserPassword(txtNewPassword.Text);
            string repeatPassword = new BcAmisUser().EncryptUserPassword(txtRepeatNewPassword.Text);
            AmisUser userToChangePassword = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            if (currentPassword != userToChangePassword.Password)
            {
                //Page.ShowSmallPopupMessage("Contraseña actual invalida!");
                CleanControls();
                GetTimeHide();
                lblError.Text = "Contraseña actual invalida!";

            }
            else
            {
                if (new BcAmisUser().validatePasswordSecurity(txtNewPassword.Text, out errorMessage))
                {
                    if (new BcAmisUser().ComparePasswords(newPassword, repeatPassword, out errorMessage))
                    {
                        new BcAmisUser().ChangePassword(this.Page.UserId(), newPassword, out errorMessage);
                        //Page.ShowSmallPopupMessage(errorMessage);
                        lblError.Text = errorMessage;
                        CleanControls();
                        GetTimeHide();
                        lblError.Text = errorMessage;

                    }
                    else
                        //Page.ShowSmallPopupMessage(errorMessage);
                    lblError.Text = errorMessage;
                    CleanControls();
                    GetTimeHide();
                    lblError.Text = errorMessage;

                }
                else
                {
                    //Page.ShowSmallPopupMessage(errorMessage);
                    lblError.Text = errorMessage;
                    CleanControls();
                    GetTimeHide();
                    lblError.Text = errorMessage;

                }
            }
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAndroidPage.aspx");

        }

        protected void CleanControls()
        {
            txtCurrentPassword.Text = "".Trim();
            txtNewPassword.Text = "".Trim();
            txtRepeatNewPassword.Text = "".Trim();
        }

        protected void timer_Tick(object sender, EventArgs e)
        {
            if (Session["timer"] != null)
            {
                int tiempo = (int)Session["timer"];
                if (tiempo == DateTime.Now.Second)
                {
                    timer.Enabled = false;
                    Error.Visible = false;
                    password.Visible = true;
                    Session["timer"] = null;
                }
            }
        }

        protected void GetTimeHide()
        {
            timer.Enabled = true;
            timer.Interval = 25;
            int valor = 2;
            if (DateTime.Now.Second + valor > 59)
            {
                Session["timer"] = 2;
            }
            else { Session["timer"] = DateTime.Now.Second + valor; }
            Error.Visible = true;
            password.Visible = false;
        }
    }
}