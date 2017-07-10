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
    public partial class MemberBranchOfficePage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int MemberBranchOfficeId
        {
            get
            {
                if (ViewState["MemberBranchOfficePage_MemberBranchOfficeId"] == null)
                {
                    ViewState["MemberBranchOfficePage_MemberBranchOfficeId"] = 0;
                }
                int id = int.Parse(ViewState["MemberBranchOfficePage_MemberBranchOfficeId"].ToString());
                return id;
            }
            set
            {
                ViewState["MemberBranchOfficePage_MemberBranchOfficeId"] = value;
            }
        }

        protected MemberBranchOffice GetMemberBranchOffice
        {
            get
            {
                MemberBranchOffice obj = new MemberBranchOffice();
                obj.MemberBranchOfficeId = MemberBranchOfficeId;
                obj.MemberId = 0;
                if (wddMember.SelectedValue != "") obj.MemberId = int.Parse(wddMember.SelectedValue);
                obj.BranchOfficeId = 0;
                if (wddBranchOffice.SelectedValue != "") obj.BranchOfficeId = int.Parse(wddBranchOffice.SelectedValue);
                return obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(501);
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

                wddMemberType.SelectedValue = "0";
                wddMember.SetComboList(new BcMember(), out errorMessage);
                wddBranchOffice.SetComboList(new BcBranchOffice(), out errorMessage);

                MemberBranchOfficeId = 0;

                
                wddMember.SelectedValue = "0";
                wddBranchOffice.SelectedValue = "0";
            }
            wdgMain.SetTableList(new BcMemberBranchOffice());
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveMemberBranchOffice();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            NewMemberBranchOffice();
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
            wdgMain.SetTableList(new BcMemberBranchOffice());
            MemberBranchOfficeId = wdgMain.GetItemIntByKey(rowIndex, "MemberBranchOfficeId");
            wddBranchOffice.SelectedValue = wdgMain.GetItemByKey(rowIndex, "BranchOfficeId");
            wddMember.SelectedValue = wdgMain.GetItemByKey(rowIndex, "MemberId");
            wddMemberType.SelectedValue = wdgMain.GetItemByKey(rowIndex, "MemberTypeId");

            DivBranchOffice.Visible = true;
            DivMember.Visible = true;
            
        }

        protected void SaveMemberBranchOffice()
        {
            string errorMessage = "";
            if (wddMemberType.SelectedValue!="0")
            {
                if (new BcMemberBranchOffice().Validate(GetMemberBranchOffice, out errorMessage))
                {
                    MemberBranchOffice savedObj = new BcMemberBranchOffice().Save(GetMemberBranchOffice, out errorMessage);
                    if (savedObj != null) MemberBranchOfficeId = savedObj.MemberBranchOfficeId;
                    wdgMain.SetTableList(new BcMemberBranchOffice());
                    NewMemberBranchOffice();
                }
            }
            else
            {
                errorMessage = "Debe seleccionar un tipo de integrante, este campo no puede estar vacío";
            }
            
            Page.ShowPopupMessage(errorMessage);
        }

        protected void NewMemberBranchOffice()
        {
            MemberBranchOfficeId = 0;

            wddMember.SelectedValue = "0";
            wddMemberType.SelectedValue = "0";
            wddBranchOffice.SelectedValue = "0";
        }

        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcMemberBranchOffice());
            wdgMain.ExportToExcel();
        }

        protected void DeleteMemberBranchOffice(int rowIndex)
        {
            string errorMessage = "";
            int MemberBranchOfficeId = wdgMain.GetItemIntByKey(rowIndex, "MemberBranchOfficeId");
            CommonEnums.DeletedRecordStates deleteState = new BcMemberBranchOffice().DeleteMemberBranchOffice(MemberBranchOfficeId, out errorMessage);
            if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                NewMemberBranchOffice();
                wdgMain.SetTableList(new BcMemberBranchOffice());
            }
            Page.ShowPopupMessage(errorMessage);
        }

        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void wddMemberType_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            string errorMessage = "";
            int Id = 0;
            if (wddMemberType.SelectedValue != "") Id = int.Parse(wddMemberType.SelectedValue);
            
            if (Id != 0)
            {
                wddMember.SetComboListByFiltrer(new BcMember(), Id, out errorMessage);
            }
            else
            {
               
            }
        }

        protected void wddMember_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            string errorMessage = "";
            int Id = 0;
            if (wddMember.SelectedValue != "") Id = int.Parse(wddMember.SelectedValue);

            if (Id != 0)
            {
                
                wddBranchOffice.SetComboList(new BcBranchOffice(), out errorMessage);
            }
            else
            {
                
            }

        }

        protected void wibCancel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            Session["Delete"] = null;
            mpeConfirmar.Hide();
        }

        protected void wibConfirmar_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            int id = (int)Session["Delete"];
            DeleteMemberBranchOffice(id);
            mpeConfirmar.Hide();
        }
    }
}