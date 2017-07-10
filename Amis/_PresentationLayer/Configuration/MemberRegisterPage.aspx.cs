using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;

namespace amis._PresentationLayer.Configuration
{
    public partial class MemberRegisterPage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int MemberId
        {
            get
            {
                if (ViewState["MemberPage_MemberId"] == null)
                {
                    ViewState["MemberPage_MemberId"] = 0;
                }
                int id = int.Parse(ViewState["MemberPage_MemberId"].ToString());
                return id;
            }
            set
            {
                ViewState["MemberPage_MemberId"] = value;
            }
        }

        protected Member GetMember
        {
            get
            {
                Member obj = new Member();
                obj.MemberId = MemberId;
                obj.MemberName = wteMemberName.Text;
                obj.MemberRut = wteMemberRut.Text;
                obj.MemberEmail = wteMemberEmail.Text;
                obj.MemberTypeId = 0;
                if (wddMemberType.SelectedValue != "") obj.MemberTypeId = int.Parse(wddMemberType.SelectedValue);
                return obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(201);
            h1OptionMenuPageName.InnerText = new BcMenuOption().GetMenuOptionById(int.Parse(Session["MenuOptionId"].ToString())).Name;

            this.CheckLogin();
            if (new BcUserMenuOption().ValidUserToPage(this.PageId(), this.UserId()))
            {
                this.ApplyUserPermissions(this.UserId(), this.PageId(), tdSave, tdNew, tdExportExcel, wdgMain, "DeleteRow".ToString());
                InitializeControls();
                string parameter = Request["__EVENTARGUMENT"];
                if (parameter != null)
                {
                    if (parameter.Split(';')[0] == "wdgMain")
                    {
                        SetControlValuesFromGrid(int.Parse(parameter.Split(';')[1]));
                    }
                    if (parameter.Split(';')[0] == "wdgDelete")
                    {
                        Session["Delete"] = int.Parse(parameter.Split(';')[1]);
                        mpeConfirmar.Show();
                    }
                    if (parameter == "wdgrut")
                    {
                        formatearRut(wteMemberRut.Text);
                    }
                }
            }
            else
            {
                Response.Redirect("~/_PresentationLayer/Configuration/AmisHomePage.aspx");
            }
            if (wdgMain.Rows.Count < 11)
            {
                wdgMain.Behaviors.Paging.Enabled = false;
            }
        }

        protected void InitializeControls()
        {
            string errorMessage = "";
            if (!IsPostBack)
            {
                wddMemberType.SetComboList(new BcMemberType(), out errorMessage);

                MemberId = 0;
                wteMemberName.Text = "";
                wteMemberRut.Text = "";
                wteMemberEmail.Text = "";
                wddMemberType.SelectedValue = "0";
            }
            wdgMain.SetTableList(new BcMember());
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveMember();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            NewMember();
        }

        protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            ExportToExcel();
        }

        protected void wibExportToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            this.wibExportTableToExcel_Click(sender,e);
        }

        protected void wdgMain_Selection_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            SetControlValuesFromGrid(e.CurrentSelectedRows[0].Index);
        }

        #endregion Eventos de controles graficos

        #region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void SetControlValuesFromGrid(int rowIndex)
        {
            wdgMain.SetTableList(new BcMember());
            MemberId = wdgMain.GetItemIntByKey(rowIndex, "MemberId");
            string name = wdgMain.GetItemByKey(rowIndex, "MemberName");
            if (name.Contains("&#241;"))
            {
                
                int value = name.IndexOf("&#241;");
                name = name.Substring(0, value)+"ñ"+ name.Substring(value+6, name.Length- (value + 6));
                wteMemberName.Text = name;
            }
            else
            {
                wteMemberName.Text = wdgMain.GetItemByKey(rowIndex, "MemberName");

            }

            wteMemberRut.Text = wdgMain.GetItemByKey(rowIndex, "MemberRut");

            string email = wdgMain.GetItemByKey(rowIndex, "MemberEmail");
            if (email.Contains("&#241;"))
            {

                int value = name.IndexOf("&#241;");
                email = email.Substring(0, value) + "ñ" + email.Substring(value + 6, email.Length - (value + 6));
                wteMemberEmail.Text = email;
            }
            else
            {
                wteMemberEmail.Text = wdgMain.GetItemByKey(rowIndex, "MemberEmail");

            }
            wddMemberType.SelectedValue = wdgMain.GetItemByKey(rowIndex, "MemberTypeId");
        }

        protected void SaveMember()
        {
            string errorMessage = "Debe seleccionar un tipo de integrante.";
            if (wddMemberType.SelectedValue!="0")
            {
                Member savedObj = new BcMember().Save(GetMember, out errorMessage);
                if (savedObj != null)
                {
                    MemberId = savedObj.MemberId;
                    wdgMain.SetTableList(new BcMember());
                    NewMember();
                }
            }
            Page.ShowPopupMessage(errorMessage);
        }

        protected void NewMember()
        {
            MemberId = 0;
            wteMemberName.Text = "";
            wteMemberRut.Text = "";
            wteMemberEmail.Text = "";
            wddMemberType.SelectedValue = "0";
            wteMemberName.Focus();

        }

        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcMember());
            wdgMain.ExportToExcel();
        }

        protected void DeleteMember(int rowIndex)
        {
            
            string errorMessage = "";

            int memberId = wdgMain.GetItemIntByKey(rowIndex, "MemberId");
            string memberName = wdgMain.GetItemByKey(rowIndex, "MemberName");

            CommonEnums.DeletedRecordStates deleteState = new BcMember().DeleteMember(memberId, memberName, out errorMessage);
            if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                NewMember();
                wdgMain.SetTableList(new BcMember());
            }
            Page.ShowPopupMessage(errorMessage);
        }

        protected void wibCancel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            Session["Delete"] = null;
            mpeConfirmar.Hide();
        }

        protected void wibConfirmar_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            int id = (int)Session["Delete"];
            DeleteMember(id);
            mpeConfirmar.Hide();
        }

        protected string formatearRut(string rut)
        {
            int cont = 0;
            string format;
            if (rut.Length == 0)
            {
                return "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                wteMemberRut.Text= format;
                return format;
            }
        }

        protected bool validarRut(string rut,out string errorMessage)
        {

            rut = rut.ToUpper();
            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");
            int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

            char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

            int m = 0, s = 1;
            for (; rutAux != 0; rutAux /= 10)
            {
                s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
            }
            if (dv == (char)(s != 0 ? s + 47 : 75))
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = "El rut digitado no es válido, por favor digite un rut valido";
                return false;

            }
        }

        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void wibOk_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            mpeRut.Hide();
        }

        protected void wteMemberEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void wteMemberRut_TextChanged(object sender, EventArgs e)
        {
            string rut = wteMemberRut.Text;
            int cont = 0;
            string format;
            if (rut.Length == 0)
            {
                wteMemberRut.Text = "";
            }
            else
            {
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                format = "-" + rut.Substring(rut.Length - 1);
                for (int i = rut.Length - 2; i >= 0; i--)
                {
                    format = rut.Substring(i, 1) + format;
                    cont++;
                    if (cont == 3 && i != 0)
                    {
                        format = "." + format;
                        cont = 0;
                    }
                }
                wteMemberRut.Text = format;
            }
        }
    }


}
