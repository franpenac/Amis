using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web;

namespace amis._PresentationLayer.Users
{
    public partial class RegisterUserPage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int UserId
        {
            get
            {
                if (ViewState["UserPage_UserId"] == null)
                {
                    ViewState["UserPage_UserId"] = 0;
                }
                int id = int.Parse(ViewState["UserPage_UserId"].ToString());
                return id;
            }
            set
            {
                ViewState["UserPage_UserId"] = value;
            }
        }

        protected AmisUser GetUser
        {
            get
            {
                string errorMessage = "";
                AmisUser obj = new AmisUser();
                Member member = new BcMember().GetMemberById(int.Parse(wddMember.SelectedValue.ToString()), out errorMessage);
                obj.AmisUserId = 0;
                obj.Email = member.MemberEmail;
                obj.Password = " ";
                obj.SecretQuestion = " ";
                obj.SecretAnswer = " ";
                obj.Enable = "N";
                obj.Name = member.MemberName;
                obj.CreatedDate = DateTime.Now;
                obj.ChangePasswordCode = new BcAmisUser().GenerateStringToChangePassword();
                obj.MemberId = member.MemberId;
                return obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(101);
            h1OptionMenuPageName.InnerText = new BcMenuOption().GetMenuOptionById(int.Parse(Session["MenuOptionId"].ToString())).Name;

            this.CheckLogin();
            if (new BcUserMenuOption().ValidUserToPage(this.PageId(), this.UserId()))
            {
                InitializeControls();
                string parameter = Request["__EVENTARGUMENT"];
                if (parameter != null)
                {
                    if (parameter.Split(';')[0] == "wdgMain")
                    {
                        SetControlValuesFromGrid(int.Parse(parameter.Split(';')[1]));
                    }
                    if (parameter.Split(';')[0] == "wdgProfile")
                    {
                        GoToUserMenuOptionPage(int.Parse(parameter.Split(';')[1]));
                    }
                    if (parameter.Split(';')[0] == "wdgEnable")
                    {
                        Session["rowIndex"] = int.Parse(parameter.Split(';')[1]);

                        Image button = (Image)wdgMain.Rows[int.Parse(parameter.Split(';')[1])].Items[8].FindControl("UserEnabled");
                        if (button.ImageUrl == @"~/ig_common/images/ButtonUnchecked16x16.png")
                        {
                            lblEnabledMessage.Text = "¿Desea HABILITAR a este usuario?";
                        }
                        else if (button.ImageUrl == @"~/ig_common/images/ButtonChecked16x16.png")
                        {
                            lblEnabledMessage.Text = "¿Desea DESHABILITAR a este usuario?";
                        }
                        mpeEnable.Show();
                    }
                    if (parameter.Split(';')[0] == "wdgAlarm")
                    {
                        GoToUserAlarmPage(int.Parse(parameter.Split(';')[1]));
                    }
                }
            }
            else
            {
                Response.Redirect("~/_PresentationLayer/Configuration/AmisHomePage.aspx");
            }
        }

        protected void InitializeControls()
        {
            string errorMessage = "";
            if (!IsPostBack)
            {
                UserId = 0;
                wddMember.SetComboListByFiltrer(new BcMember(), 2, out errorMessage);
                wddMember.SelectedValue = "0";
                lblUserId.Text = "0";
            }
            wdgMain.SetTableList(new BcAmisUser(), out errorMessage);
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            

            string errorMessage = "";
            if (wddMember.SelectedValue != "0")
            {
                if (new BcAmisUser().ValidateUserEmailExist(GetUser.Email, out errorMessage))
                {
                    AmisUser SavedUSer = new BcAmisUser().Save(GetUser, out errorMessage);
                    if (SavedUSer != null)
                    {
                        Page.ShowPopupMessage(errorMessage);
                        Session["userEmail"] = GetUser.Email;
                        Session["ChangePasswordCode"] = SavedUSer.ChangePasswordCode;
                        Session["lblWo"] = HttpContext.Current.Request.Url.GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped);
                        BackgroundWorker task = new BackgroundWorker();
                        task.DoWork += new DoWorkEventHandler(SendEmail);
                        task.RunWorkerAsync();
                    }
                    else
                    {
                        Page.ShowPopupMessage(errorMessage);
                    }
                }else
                {
                    Page.ShowPopupMessage(errorMessage);
                }
            }else
            {
                Page.ShowPopupMessage("Debe seleccionar Tipo Miembro/Miembro.");
            }       
            CleanValues();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            NewUser();
        }

        protected void wdgMain_Selection_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            SetControlValuesFromGrid(e.CurrentSelectedRows[0].Index);
        }

        protected void wibExportExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            this.wibExportTableToExcel_Click(sender, e);
        }

        #endregion Eventos de controles graficos

        #region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void SetControlValuesFromGrid(int rowIndex)
        {
            string errorMessage = "";

            wdgMain.SetTableList(new BcAmisUser(), out errorMessage);
            UserId = wdgMain.GetItemIntByKey(rowIndex, "MemberId");
            Member member = new BcMember().GetMemberById(int.Parse(wdgMain.GetItemByKey(rowIndex,"MemberId")), out errorMessage);
            wddMember.SetComboListByFiltrer(new BcMember(),member.MemberTypeId, out errorMessage);
            wddMember.SelectedValue = member.MemberId.ToString();
            wddMember.Enabled = false;
            wteUserEmail.Text = wdgMain.GetItemByKey(rowIndex, "Email");
            lblUserId.Text = UserId.ToString();
        }

        protected void NewUser()
        {
            UserId = 0;
            wteUserEmail.Text = "";
            wddMember.SelectedValue = "0";
            lblUserId.Text = "0";
            wddMember.Enabled = true;
        }

        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcAmisUser());
            wdgMain.ExportToExcel();
        }

        public void GoToUserMenuOptionPage(int rowIndex)
        {
            string errorMessage = "";
            int UserId = wdgMain.GetItemIntByKey(rowIndex, "UserId");
            AmisUser user = new BcAmisUser().GetUserById(UserId, out errorMessage);
            if (user.Enable == "Y")
            {
                Session["IdToApplyPermissions"] = UserId.ToString();
                Response.Redirect("UserMenuOptionPage.aspx");
            }else
            {
                //Page.ShowPopupMessage("No se le puede asignar permisos a este usuario, ya que este se encuentra deshabilitado");
                mpeConfirmar.Show();
            }
        }

        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            ExportToExcel();
        }

        protected void wivForwardPasswordEmail_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string errorMessage = "";
            if (new BcAmisUser().CheckEmailFormat(wteUserEmail.Text.Trim(), out errorMessage))
            {
                if (new BcAmisUser().GetUserByEmail(wteUserEmail.Text.Trim(), out errorMessage) != null)
                {
                    if (new BcAmisUser().GetUserByEmail(wteUserEmail.Text.Trim(), out errorMessage).Enable== "Y")
                    {
                        string changePasswordCode = new BcAmisUser().GenerateStringToChangePassword();
                        new BcAmisUser().ChangeUserPasswordCode(changePasswordCode, wteUserEmail.Text.Trim());
                        if (new BcAmisUser().SendMailAsync(wteUserEmail.Text.Trim(), changePasswordCode, changePasswordCode))
                        {
                            Page.ShowPopupMessage("Cambio para de contraseña enviado.");
                            CleanValues();
                        }
                        else
                        {
                            Page.ShowPopupMessage("Hubo un error al enviar el correo, si esto persiste, informe al administrador del sistema.");
                        }
                    }else
                    {
                        Page.ShowPopupErrorMessage("No puede enviar contraseña a un usuario DESHABILITADO");
                    }
                }else
                {
                    Page.ShowPopupMessage(errorMessage);
                }

            }else
            {
                Page.ShowPopupMessage(errorMessage);
            }
        }

        protected void wivSecondaryPasswordEmail_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string errorMessage = "";
            string changePasswordCode = new BcAmisUser().GenerateStringToChangePassword();
            new BcAmisUser().ChangeUserPasswordCode(changePasswordCode, wteUserEmail.Text);
            if (new BcAmisUser().CheckEmailFormat(wteSecondaryEmail.Text.Trim(), out errorMessage))
            {
                if (new BcAmisUser().GetUserByEmail(wteUserEmail.Text.Trim(),out errorMessage).Enable == "Y")
                {
                    if (new BcAmisUser().SendMailAsync(wteSecondaryEmail.Text.Trim(), changePasswordCode, changePasswordCode))
                    {
                        Page.ShowPopupMessage("Cambio para de contraseña enviado.");
                        CleanValues();
                    }
                    else
                    {
                        Page.ShowPopupMessage("Hubo un error al enviar el correo, si esto persiste, informe al administrador del sistema.");
                    }
                }else
                {
                    Page.ShowPopupErrorMessage("No puede enviar contraseña a un usuario DESHABILITADO");
                }
 
            }else
            {
                Page.ShowPopupMessage(errorMessage);
                wteSecondaryEmail.Text = "";
            }
        }

        protected void CleanValues()
        { 
            string errorMessage = "";
            wteUserEmail.Text = "";
            wddMember.SelectedValue = "0";
            wteSecondaryEmail.Text = "";
            wdgMain.SetTableList(new BcAmisUser(), out errorMessage);
        }

        protected void wibConfirmar_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            mpeConfirmar.Hide();
        }

        protected void wibConfirmEnable_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string errorMessage = "";
            string Enabled = "";
            bool enabled = false;
            int rowIndex = (int)Session["rowIndex"];
            int userId = int.Parse(wdgMain.GetItemByKey(rowIndex, "UserId"));
            if (new BcAmisUser().GetUserById(userId, out errorMessage).Enable == "Y")
            {
                enabled = true;
            }
            else
                enabled = false;
            Image button = (Image)wdgMain.Rows[rowIndex].Items[8].FindControl("UserEnabled");
            if (enabled)
            {

                Enabled = "N";
                button.ImageUrl = @"~/ig_common/images/ButtonUnchecked16x16.png";
                new BcAmisUser().EnabledUser(userId, Enabled);
                wdgMain.SetTableList(new BcAmisUser(), out errorMessage);
            }
            else
            {
                Enabled = "Y";
                button.ImageUrl = @"~/ig_common/images/ButtonChecked16x16.png";
                new BcAmisUser().EnabledUser(userId, Enabled);
                wdgMain.SetTableList(new BcAmisUser(), out errorMessage);
            }
        }

        protected void wibCancelEnable_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            mpeEnable.Hide();
        }

        protected void wddMember_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            string errorMessage = "";
            if (wddMember.SelectedItem != null)
            {
                wteUserEmail.Text = new BcMember().GetMemberById(int.Parse(wddMember.SelectedValue), out errorMessage).MemberEmail;
            }        
        }

        protected void SendEmail(object o, DoWorkEventArgs e)
        {
            string userEmail = (string)Session["userEmail"];
            string changePass = (string)Session["ChangePasswordCode"];
            string lbl = (string)Session["lblWo"];
            new BcAmisUser().SendMailAsync(userEmail, changePass, lbl);
        }

        public void GoToUserAlarmPage(int rowIndex)
        {
            string errorMessage = "";
            int UserId = wdgMain.GetItemIntByKey(rowIndex, "UserId");
            AmisUser user = new BcAmisUser().GetUserById(UserId, out errorMessage);
            if (user.Enable == "Y")
            {
                Session["IdToApplyAlarms"] = UserId.ToString();
                Response.Redirect("AlarmSystemPage.aspx");
            }
            else
            {
                lblPermission.Text = "No pude asignar alarmas a usuarios deshabilitados.";
                mpeConfirmar.Show();
            }
        }
    }
}