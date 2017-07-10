using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;
using System.Net.Mail;

namespace amis._PresentationLayer.Configuration
{
    public partial class AmisHomePage : System.Web.UI.Page
    {
        //#region Propiedades, PageLoad e inicializacion de controles graficos

        //protected int WarehouseId
        //{
        //    get
        //    {
        //        if (ViewState["WarehousePage_WarehouseId"] == null)
        //        {
        //            ViewState["WarehousePage_WarehouseId"] = 0;
        //        }
        //        int id = int.Parse(ViewState["WarehousePage_WarehouseId"].ToString());
        //        return id;
        //    }
        //    set
        //    {
        //        ViewState["WarehousePage_WarehouseId"] = value;
        //    }
        //}

        //protected Warehouse GetWarehouse
        //{
        //    get
        //    {
        //        Warehouse obj = new Warehouse();
        //        obj.WarehouseId = WarehouseId;
        //        obj.WarehouseName = wteWarehouseName.Text;
        //        obj.BranchOfficeId = 0;
        //        if (wddBranchOffice.SelectedValue != "") obj.BranchOfficeId = int.Parse(wddBranchOffice.SelectedValue);
        //        return obj;
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CheckLogin();
            
        }

        //protected void InitializeControls()
        //{
        //    string errorMessage = "";
        //    if (!IsPostBack)
        //    {
        //        WarehouseId = 0;
        //        wteWarehouseName.Text = "";
        //        wddBranchOffice.SetComboList(new BcBranchOffice(), out errorMessage);
        //        wddBranchOffice.SelectedValue = "0";
        //    }

        //    wdgMain.SetTableList(new BcWarehouse());
        //}

        //#endregion Propiedades, PageLoad e inicializacion de controles graficos

        //#region Eventos de controles graficos

        //protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        //{
        //    SaveWarehouse();
        //}

        //protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        //{
        //    NewWarehouse();
        //}

        //protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        //{
        //    ExportToExcel();
        //}

        //protected void wdgMain_ItemCommand(object sender, Infragistics.Web.UI.GridControls.HandleCommandEventArgs e)
        //{
        //    if (e.CommandName == "DeleteRow")
        //    {
        //        DeleteWarehouse(int.Parse(e.CommandArgument.ToString()));
        //    }
        //}

        //protected void wdgMain_Selection_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        //{
        //    SetControlValuesFromGrid(e.CurrentSelectedRows[0].Index);
        //}


        //#endregion Eventos de controles graficos

        //#region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        //protected void SetControlValuesFromGrid(int rowIndex)
        //{
        //    string errorMessage = "";

        //    wdgMain.SetTableList(new BcWarehouse(), out errorMessage);
        //    WarehouseId = wdgMain.GetItemIntByKey(rowIndex, "WarehouseId");
        //    wteWarehouseName.Text = wdgMain.GetItemByKey(rowIndex, "WarehouseName");
        //    wddBranchOffice.SelectedValue = wdgMain.GetItemByKey(rowIndex, "BranchOfficeId");

        //}

        //protected void SaveWarehouse()
        //{
        //    string errorMessage = "";
        //    if (new BcWarehouse().Validate(GetWarehouse, out errorMessage))
        //    {
        //        Warehouse savedObjWarehouse = new BcWarehouse().Save(GetWarehouse, out errorMessage);
        //        if (savedObjWarehouse != null) WarehouseId = savedObjWarehouse.WarehouseId;
        //        wdgMain.SetTableList(new BcWarehouse());
        //    }

        //    Page.ShowPopupMessage(errorMessage);
        //}

        //protected void NewWarehouse()
        //{
        //    WarehouseId = 0;
        //    wteWarehouseName.Text = "";
        //    wddBranchOffice.SelectedValue = "0";

        //}

        //protected void ExportToExcel()
        //{
        //    wdgMain.SetTableList(new BcWarehouse());
        //    wdgMain.ExportToExcel();
        //}

        //protected void DeleteWarehouse(int rowIndex)
        //{
        //    string errorMessage = "";

        //    int WarehouseId = wdgMain.GetItemIntByKey(rowIndex, "WarehouseId");
        //    string WarehouseName = wdgMain.GetItemByKey(rowIndex, "WarehouseName");

        //    CommonEnums.DeletedRecordStates deleteState = new BcWarehouse().DeleteWarehouse(WarehouseId, WarehouseName, out errorMessage);
        //    if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
        //    {
        //        NewWarehouse();
        //        wdgMain.SetTableList(new BcWarehouse());
        //    }
        //    Page.ShowPopupMessage(errorMessage);

        //}



        //#endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones



    }
}