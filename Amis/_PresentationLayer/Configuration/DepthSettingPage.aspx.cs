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
    public partial class DepthSettingPage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int DepthSettingId
        {
            get
            {
                if (ViewState["DepthSettingPage_DepthSettingId"] == null)
                {
                    ViewState["DepthSettingPage_DepthSettingId"] = 0;
                }
                int id = int.Parse(ViewState["DepthSettingPage_DepthSettingId"].ToString());
                return id;
            }
            set
            {
                ViewState["DepthSettingPage_DepthSettingId"] = value;
            }
        }

        protected DepthSetting GetDepthSetting
        {
            get
            {
                DepthSetting obj = new DepthSetting();
                obj.DepthSettingId = DepthSettingId;
                       
                decimal depth = 0;
                decimal.TryParse(wneScrapDetph.Text, out depth);
                obj.ScrapDepth = depth;

                obj.ApplicationId = 0;
                if (wddApplication.SelectedValue != "") obj.ApplicationId = int.Parse(wddApplication.SelectedValue);
                obj.AssetModelId = 0;
                if (wddAssetModel.SelectedValue != "") obj.AssetModelId = int.Parse(wddAssetModel.SelectedValue);
                return obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(302);
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

                DepthSettingId = 0;

                wneScrapDetph.Text = "";
                wddApplication.SelectedValue = "0";
                wddBrand.SelectedValue = "0";
            }
            wdgMain.SetTableList(new BcDepthSetting());
            wdgMain.HeaderCaptionCssClass = "HCENTER";
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveDepthSetting();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            NewDepthSetting();
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

        #endregion Eventos de controles graficos

        #region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void SetControlValuesFromGrid(int rowIndex)
        {
            wdgMain.SetTableList(new BcDepthSetting());
            DepthSettingId = wdgMain.GetItemIntByKey(rowIndex, "DepthSettingId");
            wddApplication.SelectedValue = wdgMain.GetItemByKey(rowIndex, "ApplicationId");
            wddBrand.SelectedValue = wdgMain.GetItemByKey(rowIndex, "BrandId");

            wddAssetModel.CleanDataSource();
            wddAssetModel.DataSource = "";
            wddAssetModel.DataBind();

            string errorMessage = "";

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
            string Depth = wdgMain.GetItemByKey(rowIndex, "ScrapDepth");
            wneScrapDetph.Text = Depth.Substring(0, Depth.Length - 2);
        }

        protected void SaveDepthSetting()
        {
            string errorMessage = "";

            if (new BcDepthSetting().Validate(GetDepthSetting, out errorMessage))
            {
                if (int.Parse(wneScrapDetph.Text) > 0)
                {
                    DepthSetting savedObj = new BcDepthSetting().Save(GetDepthSetting, out errorMessage);
                    if (savedObj != null) DepthSettingId = savedObj.DepthSettingId;
                    wdgMain.SetTableList(new BcDepthSetting());
                    NewDepthSetting();
                }
                else
                {
                    errorMessage = "La profundidad de huella debe ser mayor que 0";
                }
                
            }
            Page.ShowPopupMessage(errorMessage);
        }

        protected void NewDepthSetting()
        {
            DepthSettingId = 0;
            wddAssetModel.SelectedValue = "0";
            wddApplication.SelectedValue = "0";
            wddBrand.SelectedValue = "0";
            wneScrapDetph.Text = "0";
        }

        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcDepthSetting());
            wdgMain.ExportToExcel();
        }

        protected void DeleteDepthSetting(int rowIndex)
        {
            string errorMessage = "";
            int DepthSettingId = wdgMain.GetItemIntByKey(rowIndex, "DepthSettingId");
            CommonEnums.DeletedRecordStates deleteState = new BcDepthSetting().DeleteDepthSetting(DepthSettingId, out errorMessage);
            if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                NewDepthSetting();
                wdgMain.SetTableList(new BcDepthSetting());
            }
            Page.ShowPopupMessage(errorMessage);
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
            DeleteDepthSetting(id);
            mpeConfirmar.Hide();
        }
    }
}