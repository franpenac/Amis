using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;
using System.Net.Mail;

namespace amis._PresentationLayer.Inventory
{
    public partial class WarehousePage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int WarehouseId
        {
            get
            {
                if (ViewState["WarehousePage_WarehouseId"] == null)
                {
                    ViewState["WarehousePage_WarehouseId"] = 0;
                }
                int id = int.Parse(ViewState["WarehousePage_WarehouseId"].ToString());
                return id;
            }
            set
            {
                ViewState["WarehousePage_WarehouseId"] = value;
            }
        }

        protected Warehouse GetWarehouse
        {
            get
            {
                Warehouse obj = new Warehouse();
                obj.WarehouseId = WarehouseId;
                obj.WarehouseName = wteWarehouseName.Text;
                obj.BranchOfficeId = 0;
                if (wddBranchOffice.SelectedValue != "") obj.BranchOfficeId = int.Parse(wddBranchOffice.SelectedValue);
                return obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(403);
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
                if (wdgMain.Rows.Count < 11)
                {
                    wdgMain.Behaviors.Paging.Enabled = false;
                }
            }
            else
            {
                Response.Redirect("~/_PresentationLayer/Configuration/AmisHomePage.aspx");
            }
           
        }

        protected void InitializeControls()
        {
            this.SetPageId(403);
            h1OptionMenuPageName.InnerText = new BcMenuOption().GetMenuOptionById(int.Parse(Session["MenuOptionId"].ToString())).Name;

            this.CheckLogin();
            if (new BcUserMenuOption().ValidUserToPage(this.PageId(), this.UserId()))
            {
                string errorMessage = "";
                if (!IsPostBack)
                {
                    WarehouseId = 0;
                    wteWarehouseName.Text = "";
                    wddBranchOffice.SetComboList(new BcBranchOffice(), out errorMessage);
                    wddBranchOffice.SelectedValue = "0";
                }

                wdgMain.SetTableList(new BcWarehouse());
            }
            else
            {
                Response.Redirect("~/_PresentationLayer/Configuration/AmisHomePage.aspx");
            }

        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveWarehouse();
            NewWarehouse();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            NewWarehouse();
        }

        protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            ExportToExcel();
        }

        protected void wibExportToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            this.wibExportTableToExcel_Click(sender,e);
        }

        protected void wibCancel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            Session["Delete"] = null;
            mpeConfirmar.Hide();
        }

        protected void wibConfirmar_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            int id = (int)Session["Delete"];
            DeleteWarehouse(id);
            mpeConfirmar.Hide();
        }

        protected void wdgMain_Selection_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            SetControlValuesFromGrid(e.CurrentSelectedRows[0].Index);
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


        protected void SetControlValuesFromGrid(int rowIndex)
        {
            string errorMessage = "";

            wdgMain.SetTableList(new BcWarehouse(),out errorMessage);
            WarehouseId = wdgMain.GetItemIntByKey(rowIndex, "WarehouseId");
            string name = wdgMain.GetItemByKey(rowIndex, "WarehouseName");
            string vName = "";
            if (ValidateÑ(name, out vName))
            {
                wteWarehouseName.Text = vName;
            }
            else
            {
                wteWarehouseName.Text = name;
            }
            wddBranchOffice.SelectedValue = wdgMain.GetItemByKey(rowIndex, "BranchOfficeId");

        }

        protected void SaveWarehouse()
        {
            string errorMessage = "";
            if (new BcWarehouse().Validate(GetWarehouse, out errorMessage))
            {
                Warehouse savedObjWarehouse = new BcWarehouse().Save(GetWarehouse, out errorMessage);
                if (savedObjWarehouse != null) WarehouseId = savedObjWarehouse.WarehouseId;
                wdgMain.SetTableList(new BcWarehouse());
            }

            Page.ShowPopupMessage(errorMessage);
        }

        protected void NewWarehouse()
        {
            WarehouseId = 0;
            wteWarehouseName.Text = "";
            wddBranchOffice.SelectedValue = "0";

        }

        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcWarehouse());
            wdgMain.ExportToExcel();
        }

        protected void DeleteWarehouse(int rowIndex)
        {
            string errorMessage = "";

            int WarehouseId = wdgMain.GetItemIntByKey(rowIndex, "WarehouseId");
            string WarehouseName = wdgMain.GetItemByKey(rowIndex, "WarehouseName");

            CommonEnums.DeletedRecordStates deleteState = new BcWarehouse().DeleteWarehouse(WarehouseId, WarehouseName, out errorMessage);
            if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                NewWarehouse();
                wdgMain.SetTableList(new BcWarehouse());
            }
            Page.ShowPopupMessage(errorMessage);
            
        }



        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones



    }
}