using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;
using Infragistics.Web.UI.ListControls;

namespace amis._PresentationLayer.Configuration
{
    public partial class BranchOfficePage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int BranchOfficeId
        {
            get
            {
                if (ViewState["BranchOfficePage_BranchOfficeId"] == null)
                {
                    ViewState["BranchOfficePage_BranchOfficeId"] = 0;
                }
                int id = int.Parse(ViewState["BranchOfficePage_BranchOfficeId"].ToString());
                return id;
            }
            set
            {
                ViewState["BranchOfficePage_BranchOfficeId"] = value;
            }
        }

        protected BranchOffice GetBranchOffice
        {
            get
            {
                BranchOffice obj = new BranchOffice();
                obj.BranchOfficeId = BranchOfficeId;
                obj.BranchOfficeName = wteBranchOfficeName.Text;
                
                return obj;
            }
        }

        protected Location GetLocation
        {
            get
            {
                Location obj = new Location();
                obj.LocationId = 0;
                obj.LocationName = wteLocationName.Text;
                obj.CommuneId = 0;
                if (wddCommune.SelectedValue != "") obj.CommuneId = int.Parse(wddCommune.SelectedValue);
                if (obj.LocationName=="")
                {
                    obj.LocationName = "Sin Asignar";
                }
                return obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(402);
            h1OptionMenuPageName.InnerText = new BcMenuOption().GetMenuOptionById(int.Parse(Session["MenuOptionId"].ToString())).Name;
            this.CheckLogin();
            if (new BcUserMenuOption().ValidUserToPage(this.PageId(), this.UserId()))
            {
                this.ApplyUserPermissions(this.UserId(), this.PageId(), tdSave, tdNew, tdExportExcel, wdgMain, "DeleteRow".ToString());
                InitializeControls();
                
                if (wdgMain.Rows.Count < 11)
                {
                    wdgMain.Behaviors.Paging.Enabled = false;
                }
            }
            else
            {
                Response.Redirect("~/_PresentationLayer/Configuration/AmisHomePage.aspx");
            }

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

        protected void InitializeControls()
        {
            string errorMessage = "";
            if (!IsPostBack)
            {
                BranchOfficeId = 0;
                wteBranchOfficeName.Text = "";

                wddRegion.SetComboList(new BcRegion(), out errorMessage);

                wddRegion.SelectedValue = "0";

                wteLocationName.Text = "";
            }
            wdgMain.SetTableList(new BcBranchOffice());
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveBranchOffice();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            NewBranchOffice();
        }

        protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            ExportToExcel();
        }

        protected void wibExportToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            this.wibExportTableToExcel_Click(sender, e);
        }
        
        protected void wdgMain_Selection_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            SetControlValuesFromGrid(e.CurrentSelectedRows[0].Index);
        }

        protected void wddRegion_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            string errorMessage = "";
            int Id = 0;
            if (wddRegion.SelectedValue != "") Id = int.Parse(wddRegion.SelectedValue);
            wddCommune.SetComboListByFiltrer(new BcCommune(), Id, out errorMessage);
            if (Id != 0)
            {
                wddCommune.Visible = true;
                lblCommune.Visible = true;
                divCommune.Visible = true;
                wddCommune.SelectedValue = "0";
            }
            else
            {
                wddCommune.Visible = false;
                lblCommune.Visible = false;
                divCommune.Visible = false;
            }
        }

        protected void wddCommune_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            int Id = 0;
            if (wddCommune.SelectedValue != "") Id = int.Parse(wddCommune.SelectedValue);
            if (Id != 0)
            {
                lblLocationName.Visible = true;
                wteLocationName.Visible = true;
                divLocation.Visible = true;
            }
            else
            {
                lblLocationName.Visible = false;
                wteLocationName.Visible = false;
                divLocation.Visible = false;
            }
        }

        protected void wddRegion_ValueChanged(object sender, Infragistics.Web.UI.ListControls.DropDownValueChangedEventArgs e)
        {

        }


        #endregion Eventos de controles graficos

        #region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        public bool ValidateÑ(string text, out string result)
        {
            result = text;
            if (result.Contains("&#241;"))
            {

                int value = result.IndexOf("&#241;");
                result = result.Substring(0, value) + "ñ" + result.Substring(value + 6, result.Length - (value + 6));
                return true;
            }
            return false;
        }


        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcBranchOffice());
            wdgMain.ExportToExcel();
        }

        protected void SetControlValuesFromGrid(int rowIndex)
        {
            string errorMessage = "";
            wdgMain.SetTableList(new BcBranchOffice());
            BranchOfficeId = wdgMain.GetItemIntByKey(rowIndex, "BranchOfficeId");
            string name = wdgMain.GetItemByKey(rowIndex, "BranchOfficeName");
            string vName = "";
            if(ValidateÑ(name,out vName))
            {
                wteBranchOfficeName.Text = vName;
            }
            else
            {
                wteBranchOfficeName.Text = name;
            }

            wddRegion.SelectedValue = wdgMain.GetItemByKey(rowIndex, "RegionId");
            wddCommune.SetComboListByFiltrer(new BcCommune(), int.Parse(wddRegion.SelectedValue), out errorMessage);
            divCommune.Visible = true;
            divLocation.Visible = true;
            lblCommune.Visible = true;
            lblLocationName.Visible = true;
            wddCommune.Visible = true;
            wteLocationName.Visible = true;
            wddCommune.SelectedValue = wdgMain.GetItemByKey(rowIndex, "CommuneId");
            string location = wdgMain.GetItemByKey(rowIndex, "LocationName");
            string vLocation = "";
            if (ValidateÑ(location, out vLocation))
            {
                wteLocationName.Text = vLocation;
            }
            else
            {
                wteLocationName.Text = location;
            }
        }

        protected void SaveBranchOffice()
        {

            bool ok = true;
            string errorMessage = "";
            ok = (wddRegion.SelectedValue != "0");
            if (ok == true)
            {
                ok = (wddCommune.SelectedValue != "0");
            }
            if (ok == true)
            {
                Location savedObjLocation = new Location();
                if (BranchOfficeId == 0)
                {
                    savedObjLocation = new BcLocation().Save(GetLocation, out errorMessage);
                }else
                {
                    BranchOffice branchOffice = new BcBranchOffice().GetBranchOfficeById(BranchOfficeId, out errorMessage);
                    savedObjLocation = GetLocation;
                    savedObjLocation.LocationId = branchOffice.LocationId;
                    Location loc = new BcLocation().Save(savedObjLocation, out errorMessage);
                    if (loc == null)
                    {
                        Page.ShowPopupErrorMessage("La direccion elegida, ya esta asignada a otra oficina");
                        return;
                    }

                }
                if (savedObjLocation != null)
                {
                    int LocationId = savedObjLocation.LocationId;

                    BranchOffice savedObj = new BcBranchOffice().Save(GetBranchOffice, LocationId, out errorMessage);
                    if (savedObj != null) BranchOfficeId = savedObj.BranchOfficeId;
                    wdgMain.SetTableList(new BcBranchOffice());
                    NewBranchOffice();
                }
            }
            else
            {
                errorMessage = "Debe seleccionar los datos de ubicacion para poder registrar su bodega.";
            }

            
            Page.ShowPopupMessage(errorMessage);
        }

        protected void NewBranchOffice()
        {
            BranchOfficeId = 0;
            wteBranchOfficeName.Text = "";
            wddCommune.Items.Clear();
            DropDownItem d = new DropDownItem();
            d.Text = ""; d.Value = "0";
            wddCommune.Items.Add(d);
            wddRegion.SelectedValue = "0";
            wddCommune.SelectedValue = "0";
            wteLocationName.Text = "";
        }

        protected void DeleteBranchOffice(int rowIndex)
        {
            string errorMessage = "No pudo ser eliminado";

            int branchOfficeId = wdgMain.GetItemIntByKey(rowIndex, "BranchOfficeId");
            string branchOfficeName = wdgMain.GetItemByKey(rowIndex, "BranchOfficeName");
            NewBranchOffice();

            CommonEnums.DeletedRecordStates deleteState = new BcBranchOffice().DeleteBranchOffice(branchOfficeId, branchOfficeName, out errorMessage);
            if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                
                wdgMain.SetTableList(new BcBranchOffice());
                Page.ShowPopupMessage(errorMessage);
            }
            else {

                Page.ShowPopupMessage(errorMessage);
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
            DeleteBranchOffice(id);
            mpeConfirmar.Hide();
        }

        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones


    }
}