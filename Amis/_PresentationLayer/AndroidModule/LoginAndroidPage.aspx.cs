using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using amis._DataLayer.GeneratedCode;
using amis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class LoginAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
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
                            if (new BcInspectionAndroid().GetCountOffice(this.UserId(), out errorMessage) > 1)
                            {
                                Response.Redirect("~/_PresentationLayer/AndroidModule/SelectBranchOfficeAndroidPage.aspx");
                            }
                            else {
                                Session["BranchOfficeId"] = new BcInspectionAndroid().GetIdBranchOfficeByUser(this.UserId(), out errorMessage);

                                Response.Redirect("~/_PresentationLayer/AndroidModule/MenuAndroidPage.aspx");
                            }

                        }
                        else
                        {
                            Page.ShowSmallPopupMessage(errorMessage);
                            //CleanPageValues();
                            txtUserPassword.Text = "";
                            return;
                        }
                    }
                    else
                        errorMessage = "Su cuenta se encuentra deshabilitada";
                    Page.ShowSmallPopupMessage(errorMessage);
                }
                else
                {
                    Page.ShowSmallPopupMessage(errorMessage);
                    //CleanPageValues();
                    txtUserEmail.Text = "";
                    return;
                }
            }
            else
                Page.ShowSmallPopupMessage(errorMessage);
            CleanPageValues();
        }

        public void CleanPageValues()
        {
            txtUserEmail.Text = "";
            txtUserPassword.Text = "";
        }

        protected void lnkbRecoveryPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/ForgotPasswordAndroidPage.aspx");
        }
    }
}