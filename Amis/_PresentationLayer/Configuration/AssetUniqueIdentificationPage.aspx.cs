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
    public partial class AssetUniqueIdentificationPage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected AssetModel GetAssetModel
        {
            get
            {
                AssetModel obj = new AssetModel();
                obj.AssetModelId = int.Parse(wddBrand.SelectedValue);
                obj.AssetModelName = wteNewModel.Text;
                return obj;

            }
        }

        protected int AssetUniqueIdentificationId
        {
            get
            {
                if (ViewState["AssetUniqueIdentificationPage_AssetUniqueIdentificationId"] == null)
                {
                    ViewState["AssetUniqueIdentificationPage_AssetUniqueIdentificationId"] = 0;
                }
                int id = int.Parse(ViewState["AssetUniqueIdentificationPage_AssetUniqueIdentificationId"].ToString());
                return id;
            }
            set
            {
                ViewState["AssetUniqueIdentificationPage_AssetUniqueIdentificationId"] = value;
            }
        }

        protected AssetUniqueIdentification GetAssetUniqueIdentification
        {
            get
            {
                AssetUniqueIdentification obj = new AssetUniqueIdentification();
                obj.AssetUniqueIdentificationId = AssetUniqueIdentificationId;
                obj.AssetTypeId = 0;
                if (wddAssetType.SelectedValue != "") obj.AssetTypeId = int.Parse(wddAssetType.SelectedValue);
                obj.OriginId = 0;
                if (wddOrigin.SelectedValue != "") obj.OriginId = int.Parse(wddOrigin.SelectedValue);
                obj.AssetModelId = 0;
                if (wddAssetModel.SelectedValue != "") obj.AssetModelId = int.Parse(wddAssetModel.SelectedValue);
                obj.AssetModelServiceId = 0;
                if (wddAssetModelService.SelectedValue != "") obj.AssetModelServiceId = int.Parse(wddAssetModelService.SelectedValue);

                return obj;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(301);
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
        }

        protected void InitializeControls()
        {
            string errorMessage = "";
            if (!IsPostBack)
            {

                wddAssetType.SelectedValue = "0";
                wddAssetType.SetComboList(new BcAssetType(), out errorMessage);

                wddOrigin.SetComboList(new BcOrigin(), out errorMessage);
                wddOrigin.SelectedValue = "0";

                wddBrand.SetComboList(new BcBrand(), out errorMessage);
                wddBrand.SelectedValue = "0";

                wddAssetModel.SetComboListByFiltrer(new BcAssetModel(), int.Parse(wddBrand.SelectedValue.ToString()), out errorMessage);
                wddAssetModel.SelectedValue = "0";

                wddAssetModelService.SetComboList(new BcAssetModelService(), out errorMessage);
                wddAssetModelService.SelectedValue = "0";

                DivNewModel.Visible = false;
                DivNewBrand.Visible = false;
                DivUserControl.Visible = false;

            }
            wdgMain.SetTableList(new BcAssetUniqueIdentification());

            WucSettingExtinguisher.Visible = false;
            WucSettingCat.Visible = false;
            WucSettingBattery.Visible = false;
            WucSettingLigthPole.Visible = false;
            WucSettingRadio.Visible = false;
            WucSettingTyre.Visible = false;

        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveAssetUniqueIdentification();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
           NewAssetUniqueIdentification();
        }

        protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            ExportToExcel();
        }

        protected void wdgMain_ItemCommand(object sender, Infragistics.Web.UI.GridControls.HandleCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                DeleteAssetUniqueIdentification(int.Parse(e.CommandArgument.ToString()));
            }
        }

        protected void wibExportToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            this.wibExportTableToExcel_Click(sender, e);
        }

        protected void wdgMain_Selection_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            SetControlValuesFromGrid(e.CurrentSelectedRows[0].Index);
        }
 
        protected void wddAssetModelService_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            int Id = 0;
            if (wddAssetModelService.SelectedValue != "") Id = int.Parse(wddAssetModelService.SelectedValue);
            if (Id != 0)
            {
                DivButtons.Visible = true;

            }
            else
            {
                DivButtons.Visible = false;
            }
        }

        protected void wibSaveNewBrand_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string errorMessage = "";
            if (wteNewBrand.Text!="")
            {
                Manufacturer Manu = new Manufacturer();
                Manu.ManufacturerName = wteNewBrand.Text;
                if (!new BcManufacturer().ExistsManufacturerName(Manu.ManufacturerName, out errorMessage))
                {
                    Manufacturer SaveManu = new BcManufacturer().Save(Manu);
                    Manu.ManufacturerId = SaveManu.ManufacturerId;
                }
                else
                {
                    Manu.ManufacturerId = new BcManufacturer().GetIdManufacturer(Manu.ManufacturerName);
                }

                Brand obj = new Brand();
                obj.BrandName = wteNewBrand.Text;
                obj.ManufacturerId = Manu.ManufacturerId;

                Brand Saveobj = new BcBrand().Save(obj, out errorMessage);
                if (Saveobj != null)
                {
                    wddBrand.SetComboList(new BcBrand(), out errorMessage);
                    wddBrand.SelectedValue = Saveobj.BrandId.ToString();
                    DivNewBrand.Visible = false;
                    wddAssetModel.SetComboList(new BcAssetModel(), out errorMessage);
                    wddAssetModel.SelectedValue = "0";
                    wteNewBrand.Text = "";
                    
                    DivUserControl.Visible = false;

                    errorMessage = "Se ha agregado '" + Saveobj.BrandName + "', como nueva marca disponible!";
                }
            }
            else
            {
                errorMessage = "El nombre de la nueva marca no puede estar vácio";
            }
            
            Page.ShowPopupMessage(errorMessage);
        }

        protected void wibSaveNewModel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string errorMessage = "";
            if (wteNewModel.Text!="")
            {
                AssetModel obj = new AssetModel { AssetModelId = 0, AssetModelName = wteNewModel.Text, BrandId = int.Parse(wddBrand.SelectedValue.ToString()) };
                obj.AssetModelName = wteNewModel.Text;

                AssetModel Saveobj = new BcAssetModel().Save(obj, out errorMessage);

                if (Saveobj != null)
                {
                    wddAssetModel.SetComboListByFiltrer(new BcAssetModel(), int.Parse(wddBrand.SelectedValue.ToString()), out errorMessage);

                    wddAssetModel.SelectedValue = Saveobj.AssetModelId.ToString();
                    DivNewModel.Visible = false;
                    wteNewModel.Text = "";
                    DivButtons.Visible = true;
                    if (wddAssetType.SelectedValue == "1")
                    {
                        showTyreSetting();
                    }
                    errorMessage = "Se ha agregado '" + Saveobj.AssetModelName + "', como nuevo modelo disponible!";

                }
            }
            else
            {
                errorMessage = "El nombre del nuevo modelo no puede estar vácio";
            }
            
            Page.ShowPopupMessage(errorMessage);
        }

        protected void wibSaveModel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string errorMessage = "";
            if (int.Parse(wddAssetType.SelectedValue) != 0)
            {
                int id = 0;
                int TypeId = int.Parse(wddAssetType.SelectedValue);
                if (/*TypeId == 1 || */TypeId == 2 || TypeId == 11 || TypeId == 4 || TypeId == 6 || TypeId == 9)
                {
                    DivUserControl.Visible = true;
                    //if (TypeId == 1) {id = this.WucSettingTyre.SaveSettingTyre();}
                    if (TypeId == 2) { id = this.WucSettingExtinguisher.SaveSettingExtinguisher();}
                    if (TypeId == 4) { id = this.WucSettingRadio.SaveSettingRadio(); }
                    if (TypeId == 6) { id = this.WucSettingLigthPole.SaveSettingLigthPole(); }
                    if (TypeId == 9) { id = this.WucSettingCat.SaveSettingCat();}
                    if (TypeId == 11) { id = this.WucSettingBattery.SaveSettingBattery();}

                    if (id != 0) { errorMessage = "Se ha agregado correctamente el modelo "; DivButtons.Visible = true; }
                }
                else
                {
                   id = createNewAssetModel(out errorMessage);
                }

                if (id != 0)
                {
                    wddAssetModel.SetComboListByFiltrer(new BcAssetModel(), int.Parse(wddBrand.SelectedValue.ToString()), out errorMessage);
                    wddAssetModel.SelectedValue = id.ToString();
                    DivNewModel.Visible = false;
                    DivUserControl.Visible = false;
                    //Page.ShowPopupMessage(errorMessage);
                }
            }
            
        }

        #endregion Eventos de controles graficos

        #region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void SetControlValuesFromGrid(int rowIndex)
        {
            wdgMain.SetTableList(new BcAssetUniqueIdentification());

            string errorMessage = "";

            wddOrigin.SetComboList(new BcOrigin(), out errorMessage);
            wddBrand.SetComboList(new BcBrand(), out errorMessage);
            wddAssetModel.SetComboList(new BcAssetModel(), out errorMessage);
            wddAssetModelService.SetComboList(new BcAssetModelService(), out errorMessage);

            AssetUniqueIdentificationId = wdgMain.GetItemIntByKey(rowIndex, "AssetUniqueIdentificationId");
            wddAssetType.SelectedValue = wdgMain.GetItemByKey(rowIndex, "AssetTypeId");
            wddOrigin.SelectedValue = wdgMain.GetItemByKey(rowIndex, "OriginId");
            wddBrand.SelectedValue = wdgMain.GetItemByKey(rowIndex, "BrandId");
            wddAssetModel.SelectedValue = wdgMain.GetItemByKey(rowIndex, "AssetModelId");
            wddAssetModelService.SelectedValue = wdgMain.GetItemByKey(rowIndex, "AssetModelServiceId");

        }

        protected void SaveAssetUniqueIdentification()
        {
            string errorMessage = "";
            AssetUniqueIdentification obj = GetAssetUniqueIdentification;
            if (wddAssetType.SelectedValue == "1")
            {
                int id = this.WucSettingTyre.SaveSettingTyre();
                if(id== 0)
                {
                    Page.ShowPopupMessage("Debe llenar todos los campos de la configuración de neumaticos");
                    return;
                }
                obj.SettingTyreId = id;
            }
            else { obj.SettingTyreId = null;}

            
            if (new BcAssetUniqueIdentification().ValidateAssetUniqueIdentificationId(GetAssetUniqueIdentification, out errorMessage))
            {
                AssetUniqueIdentification savedObj = new BcAssetUniqueIdentification().Save(GetAssetUniqueIdentification, out errorMessage);
                if (savedObj != null) AssetUniqueIdentificationId = savedObj.AssetUniqueIdentificationId;
                wdgMain.SetTableList(new BcAssetUniqueIdentification());
                NewAssetUniqueIdentification();
                Session["SettingTyre"] = null;
                
            }
            Page.ShowPopupMessage(errorMessage);
        }

        protected void NewAssetUniqueIdentification()
        {
            string errorMessage = "";

            wddAssetType.SetComboList(new BcAssetType(), out errorMessage);
            AssetUniqueIdentificationId = 0;

            wddAssetModel.Items.Clear();
            DropDownItem d = new DropDownItem();
            d.Value = "0";
            d.Text = "";
            wddAssetModel.Items.Clear();
            wddAssetModel.Items.Add(d);

            wddAssetModel.SelectedValue = "0";
            wddOrigin.SelectedValue = "0";
            wddBrand.SelectedValue = "0";
            wddAssetModelService.SelectedValue = "0";
            wddAssetType.SelectedValue = "0";
            
            DivButtons.Visible = false;

        }

        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcAssetUniqueIdentification());
            wdgMain.ExportToExcel();
        }

        protected void DeleteAssetUniqueIdentification(int rowIndex)
        {
            string errorMessage = "";

            int AssetUniqueIdentificationId = wdgMain.GetItemIntByKey(rowIndex, "AssetUniqueIdentificationId");

            CommonEnums.DeletedRecordStates deleteState = new BcAssetUniqueIdentification().DeleteAssetUniqueIdentification(AssetUniqueIdentificationId, out errorMessage);
            if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                NewAssetUniqueIdentification();
                wdgMain.SetTableList(new BcAssetUniqueIdentification());
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
            DeleteAssetUniqueIdentification(id);
            mpeConfirmar.Hide();
        }


        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void wddBrand_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            if (Session["SettingTyre"] != null)
            {
                showTyreSetting();
            }
            else { Session["SettingTyre"] = null; }
            DivUserControl.Visible = false;
            DivButtons.Visible = true;
            DivNewModel.Visible = false;
            DivNewBrand.Visible = false;
            string errorMessage = "";
            wddAssetModel.SelectedValue = "0";
            if (wddBrand.SelectedItem.Text == "Agregar Marca")
            {
                DivNewBrand.Visible = true;
            }
            else
            {
                wddAssetModel.SetComboListByFiltrer(new BcAssetModel(), int.Parse(wddBrand.SelectedValue.ToString()), out errorMessage);
                wddAssetModel.SelectedValue = "0";
            }
        }

        protected void wddAssetModel_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            //string errorMessage = "";
            DivNewModel.Visible = false;
            DivNewBrand.Visible = false;
            DivUserControl.Visible = false;
            if (wddAssetModel.SelectedItem.Text == "Agregar Modelo")
            {
                if (int.Parse(wddAssetType.SelectedValue)!=0)
                {
                    int id = int.Parse(wddAssetType.SelectedValue);
                    if (id == 2 || id == 11 || id == 4 || id == 6 || id == 9)
                    {
                        DivUserControl.Visible = true;
                        
                        if (id == 2) { showExtinguisherSetting(); }
                        if (id == 4) { showRadioSetting();  }
                        if (id == 6) { showPertigaSetting();  }
                        if (id == 9) { showGataSetting(); }
                        if (id == 11) { showBatterySetting(); }
                    }
                    else
                    {
                        wteNewModel.Text = "";
                        DivNewModel.Visible = true;
                        DivUserControl.Visible = false;
                        DivButtons.Visible = false;
                    }
                }
            }
            else
            {
                if (wddAssetType.SelectedValue == "1")
                {
                    DivUserControl.Visible = true;
                    SaveBtn.Visible = false;
                    showTyreSetting();
                    DivButtons.Visible = true;
                }
                else
                {
                    DivUserControl.Visible = false;
                    DivButtons.Visible = true;
                }
            }
            
        }

        protected void showTyreSetting()
        {
            WucSettingTyre.Visible = true;
            Session["SettingTyre"] = 1;
            wteNewModel.Text = "";
            DivNewModel.Visible = false;
            DivUserControl.Visible = true;
            DivButtons.Visible = true;
            SaveBtn.Visible = false;
            return;
        }

        protected void showExtinguisherSetting()
        {
            WucSettingExtinguisher.Visible = true;

            this.WucSettingExtinguisher.BrandId = int.Parse(wddBrand.SelectedValue.ToString());
            wteNewModel.Text = "";
            DivNewModel.Visible = false;
            DivUserControl.Visible = true;
            DivButtons.Visible = false;
            SaveBtn.Visible = true;

            return;
        }

        protected void showBatterySetting()
        {
            WucSettingBattery.Visible = true;

            this.WucSettingBattery.BrandId = int.Parse(wddBrand.SelectedValue.ToString());
            wteNewModel.Text = "";
            DivNewModel.Visible = false;
            DivUserControl.Visible = true;
            DivButtons.Visible = false;
            SaveBtn.Visible = true;

            return;
        }

        protected void showGataSetting()
        {
            WucSettingCat.Visible = true;

            this.WucSettingCat.BrandId = int.Parse(wddBrand.SelectedValue.ToString());
            wteNewModel.Text = "";
            DivNewModel.Visible = false;
            DivUserControl.Visible = true;
            DivButtons.Visible = false;
            SaveBtn.Visible = true;

            return;
        }

        protected void showPertigaSetting()
        {
            WucSettingLigthPole.Visible = true;

            this.WucSettingLigthPole.BrandId = int.Parse(wddBrand.SelectedValue.ToString());
            wteNewModel.Text = "";
            DivNewModel.Visible = false;
            DivUserControl.Visible = true;
            DivButtons.Visible = false;
            SaveBtn.Visible = true;

            return;
        }

        protected void showRadioSetting()
        {
            WucSettingRadio.Visible = true;

            this.WucSettingRadio.BrandId = int.Parse(wddBrand.SelectedValue.ToString());
            wteNewModel.Text = "";
            DivNewModel.Visible = false;
            DivUserControl.Visible = true;
            DivButtons.Visible = false;
            SaveBtn.Visible = true;

            return;
        }

        protected int createNewAssetModel(out string errorMessage)
        {
            AssetModel model = GetAssetModel;
            int id = 0;
            AssetModel result = new BcAssetModel().Save(model, out errorMessage);
            if (result != null)
            {
                id = result.AssetModelId;
                DivButtons.Visible = true;
                errorMessage="Se ha agregado correctamente el modelo " + model.AssetModelName;
                if (wddAssetType.SelectedValue == "1")
                {
                    showTyreSetting();
                }
            }
            else
            {
                errorMessage="No se ha podido grabar el modelo, por favor";
            }
            Page.ShowPopupMessage(errorMessage);
            return id;
        }

        protected void wddOrigin_SelectionChanged(object sender, DropDownSelectionChangedEventArgs e)
        {
            if (Session["SettingTyre"] != null)
            {
                showTyreSetting();
            }
            else { Session["SettingTyre"] = null; }
            DivUserControl.Visible = false;
            DivButtons.Visible = true;
            DivNewModel.Visible = false;
            DivNewBrand.Visible = false;
            wddAssetModel.SelectedValue = "0";
        }

        protected void wddAssetType_SelectionChanged(object sender, DropDownSelectionChangedEventArgs e)
        {

            Session["SettingTyre"] = null;
            DivUserControl.Visible = false;
            DivButtons.Visible = true;
            DivNewModel.Visible = false;
            DivNewBrand.Visible = false;
            wddAssetModel.SelectedValue = "0";
        }

        protected void wddAssetModelService_SelectionChanged1(object sender, DropDownSelectionChangedEventArgs e)
        {
            if (Session["SettingTyre"] != null)
            {
                showTyreSetting();
            }
            else { Session["SettingTyre"] = null; }
        }
    }
}