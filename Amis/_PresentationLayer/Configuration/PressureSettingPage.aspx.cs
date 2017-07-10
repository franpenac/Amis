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
    public partial class PressureSettingPage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int PressureSettingId
        {
            get
            {
                if (ViewState["PressureSettingPage_PressureSettingId"] == null)
                {
                    ViewState["PressureSettingPage_PressureSettingId"] = 0;
                }
                int id = int.Parse(ViewState["PressureSettingPage_PressureSettingId"].ToString());
                return id;
            }
            set
            {
                ViewState["PressureSettingPage_PressureSettingId"] = value;
            }
        }

        protected PressureSetting GetPressureSetting
        {
            get
            {
                PressureSetting obj = new PressureSetting();
                obj.PressureSettingId = PressureSettingId;
                obj.ApplicationId = 0;

                decimal pressure = 0;
                decimal.TryParse(wnePressure.Text, out pressure);

                obj.Pressure = pressure;
                if (wddApplication.SelectedValue != "") obj.ApplicationId = int.Parse(wddApplication.SelectedValue);
                obj.AssetModelId = 0;
                if (wddAssetModel.SelectedValue != "") obj.AssetModelId = int.Parse(wddAssetModel.SelectedValue);
                return obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            this.SetPageId(303);
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
                wddApplication.SetComboList(new BcApplication(), out errorMessage);

                wddBrand.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "" });
                wddBrand.DataBind();
                wddBrand.SelectedValue = "0";

                List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                    new BcBrand().GetComboListExistModelTyre(out errorMessage);

                foreach (Infragistics.Web.UI.ListControls.DropDownItem item in List)
                {
                    wddBrand.Items.Add(item);

                }
                PressureSettingId = 0;

                wnePressure.Text = "0";
                wddApplication.SelectedValue = "0";
            }
            wdgMain.SetTableList(new BcPressureSetting());
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SavePressureSetting();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            NewPressureSetting();
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
            wdgMain.SetTableList(new BcPressureSetting());
            PressureSettingId = wdgMain.GetItemIntByKey(rowIndex, "PressureSettingId");
            wddApplication.SelectedValue = wdgMain.GetItemByKey(rowIndex, "ApplicationId");
            wddBrand.SelectedValue = wdgMain.GetItemByKey(rowIndex, "BrandId");
            string errorMessage = "";

            wddAssetModel.CleanDataSource();
            wddAssetModel.DataSource = "";
            wddAssetModel.DataBind();

            if (wddBrand.SelectedValue != "0")
            {
                Infragistics.Web.UI.ListControls.DropDownItem Default = new Infragistics.Web.UI.ListControls.DropDownItem("", "0");
                wddAssetModel.Items.Add(Default);
                List<TsDropDownItem> list = new BcAssetModel().GetComboListAssetModelTyreByBrandId(int.Parse(wddBrand.SelectedValue.ToString()), out errorMessage);
                foreach (TsDropDownItem item in list)
                {
                    Infragistics.Web.UI.ListControls.DropDownItem ddItem = new Infragistics.Web.UI.ListControls.DropDownItem(item.ComboName, item.ComboId);
                    wddAssetModel.Items.Add(ddItem);
                }
            }

            wddAssetModel.SelectedValue = wdgMain.GetItemByKey(rowIndex, "AssetModelId");
            string Pressure = (wdgMain.GetItemByKey(rowIndex, "Pressure"));

            wnePressure.Text = Pressure.Substring(0, Pressure.Length - 2);
        }

        protected void SavePressureSetting()
        {
            string errorMessage = "";

            if (new BcPressureSetting().Validate(GetPressureSetting, out errorMessage))
            {
                if (double.Parse(wnePressure.Text) > 0)
                {
                    if (double.Parse(wnePressure.Text) <= 200)
                    {
                        PressureSetting savedObj = new BcPressureSetting().Save(GetPressureSetting, out errorMessage);
                        if (savedObj != null) PressureSettingId = savedObj.PressureSettingId;
                        wdgMain.SetTableList(new BcPressureSetting());
                        NewPressureSetting();
                    }
                    else
                    {
                        errorMessage = "La presión mínima no debe superar los 200 psi";
                    }

                }
                else
                {
                    errorMessage = "La presión mínima debe ser mayor que 0";
                }

            }
            Page.ShowPopupMessage(errorMessage);
        }

        protected void NewPressureSetting()
        {
            PressureSettingId = 0;
            wddAssetModel.SelectedValue = "0";
            wddApplication.SelectedValue = "0";
            wddBrand.SelectedValue = "0";
            wnePressure.Text = "0";
        }

        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcPressureSetting());
            wdgMain.ExportToExcel();
        }

        protected void DeletePressureSetting(int rowIndex)
        {
            string errorMessage = "";
            int PressureSettingId = wdgMain.GetItemIntByKey(rowIndex, "PressureSettingId");
            CommonEnums.DeletedRecordStates deleteState = new BcPressureSetting().DeletePressureSetting(PressureSettingId, out errorMessage);
            if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                NewPressureSetting();
                wdgMain.SetTableList(new BcPressureSetting());
            }
            Page.ShowPopupMessage(errorMessage);
            Session["Delete"] = null;
        }

        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void wddBrand_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            string errorMessage = "";
            wddAssetModel.CleanDataSource();
            wddAssetModel.DataSource = "";
            wddAssetModel.DataBind();
            if (wddBrand.SelectedValue != "0")
            {
                Infragistics.Web.UI.ListControls.DropDownItem Default = new Infragistics.Web.UI.ListControls.DropDownItem("", "0");
                wddAssetModel.Items.Add(Default);
                List<TsDropDownItem> list = new BcAssetModel().GetComboListAssetModelTyreByBrandId(int.Parse(wddBrand.SelectedValue.ToString()), out errorMessage);
                foreach (TsDropDownItem item in list)
                {
                    Infragistics.Web.UI.ListControls.DropDownItem ddItem = new Infragistics.Web.UI.ListControls.DropDownItem(item.ComboName, item.ComboId);
                    wddAssetModel.Items.Add(ddItem);
                }
            }

            wddAssetModel.SelectedValue = "0";
        }

        protected void wibCancel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            Session["Delete"] = null;
            mpeConfirmar.Hide();
        }

        protected void wibConfirmar_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            int id = (int)Session["Delete"];
            DeletePressureSetting(id);
            mpeConfirmar.Hide();

        }
    }
}