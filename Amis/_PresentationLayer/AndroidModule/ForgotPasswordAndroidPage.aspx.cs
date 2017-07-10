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
    public partial class ForgotPasswordAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "Para recuperar su contraseña, ingrese su correo registrado, a continuación "+
                "recibirá un correo para proceder a la recuperación de su clave de acceso a AMIS";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/LoginAndroidPage.aspx");
        }

        protected void btnRestore_Click(object sender, EventArgs e)
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
                            string code = new BcAmisUser().GenerateStringToChangePassword();
                            new BcAmisUser().SendMailAsync(txtRecoveryUserEmail.Text, code, code);
                            new BcAmisUser().ChangeUserPasswordCode(code, txtRecoveryUserEmail.Text);
                            errorMessage="Revise su correo para validar el cambio.";
                        }
                        else
                        {
                            errorMessage="No puede realizar esta acción, ya que su cuenta se encuenta deshabilitada, contactese con el administrador.";
                        }
                    }
                }

            }
            if (errorMessage != "")
            {
                lblError.Text =errorMessage;
            }
        }
    }
}