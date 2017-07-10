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
    public partial class ChangePasswordFromAmisPage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CheckLogin();
            InitializeControls();
        }

        protected void InitializeControls()
        {
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos


        #endregion Eventos de controles graficos

        protected void CleanControls()
        {
            wteCurrentPassword.Text = "".Trim();
            wteNewPassword.Text = "".Trim();
            wteRepeatNewPassword.Text = "".Trim();
        }

        protected void wibChangePassword_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string errorMessage = "";
            string currentPassword = new BcAmisUser().EncryptUserPassword(wteCurrentPassword.Text);
            string newPassword = new BcAmisUser().EncryptUserPassword(wteNewPassword.Text);
            string repeatPassword = new BcAmisUser().EncryptUserPassword(wteRepeatNewPassword.Text);
            AmisUser userToChangePassword = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            if (currentPassword != userToChangePassword.Password)
            {
                Page.ShowPopupMessage("Contraseña actual invalida!");
                CleanControls();
            }
            else
            {
                if (new BcAmisUser().validatePasswordSecurity(wteNewPassword.Text, out errorMessage))
                {
                    if (new BcAmisUser().ComparePasswords(newPassword, repeatPassword, out errorMessage))
                    {
                        new BcAmisUser().ChangePassword(this.Page.UserId(), newPassword, out errorMessage);
                        Page.ShowPopupMessage(errorMessage);
                        CleanControls();
                    }
                    else
                        Page.ShowPopupMessage(errorMessage);
                        CleanControls();
                }
                else
                {
                    Page.ShowPopupMessage(errorMessage);
                    CleanControls();
                }
            }
        }
    }
  }