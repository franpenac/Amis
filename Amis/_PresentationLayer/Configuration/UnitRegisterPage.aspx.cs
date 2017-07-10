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
    public partial class UnitRegisterPage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int UnitRegisterId
        {
            get
            {
                if (ViewState["UnitRegisterPage_UnitRegisterId"] == null)
                {
                    ViewState["UnitRegisterPage_UnitRegisterId"] = 0;
                }
                int id = int.Parse(ViewState["UnitRegisterPage_UnitRegisterId"].ToString());
                return id;
            }
            set
            {
                ViewState["UnitRegisterPage_UnitRegisterId"] = value;
            }
        }

        protected UnitRegister GetUnitRegister
        {
            get
            {
                UnitRegister obj = new UnitRegister();

                obj.UnitRegisterId = UnitRegisterId;

                obj.UnitTypeId = 0;
                if (wddUnitType.SelectedValue != "") obj.UnitTypeId = int.Parse(wddUnitType.SelectedValue);

                obj.UnitTypeConfigurationId = 0;
                if (wddConfigurationUnitType.SelectedValue != "") obj.UnitTypeConfigurationId = int.Parse(wddConfigurationUnitType.SelectedValue);

                obj.PatentNumber = wmePatentNumber.Text;

                obj.UnitName = wteUnitName.Text;

                obj.InternalNumber = wteInternalNumber.Text;

                obj.SuspensionTypeId = 0;
                if (wddSuspensionType.SelectedValue != "") obj.SuspensionTypeId = int.Parse(wddSuspensionType.SelectedValue);

                obj.KilometersOfTravel = int.Parse(wneKilometersOfTrave.Text);

                obj.UnitTara = (int)wneUnitTara.Value;

                obj.Vin = wteVin.Text;

                obj.NewOrUsed = wddNewOrUsed.SelectedValue;

                int unitManufacturingYear = 0;
                int.TryParse(wteUnitManufacturingYea.Text, out unitManufacturingYear);
                obj.UnitManufacturingYear = unitManufacturingYear;

                DateTime time1 = wdpUnitPurchaseDate.Date;
                obj.UnitPurchaseDate = DateTime.Parse(time1.Year + "-" + time1.Month + "-" + time1.Day);
                DateTime time = wdpDriveLicence.Date;
                obj.NextDrivingLicenseDate = DateTime.Parse(time.Year + "-"+time.Month+"-"+time.Day);
                DateTime time2 = wdpQuality.Date;
                obj.NextQualificationDate = DateTime.Parse(time2.Year + "-" + time2.Month + "-" + time2.Day);
                DateTime time3 = wdpTechnicalReview.Date;
                obj.NextTechnicalReviewDate = DateTime.Parse(time3.Year + "-" + time3.Month + "-" + time3.Day);

                obj.UnitOwnerMemberId = 0;
                if (wddMember.SelectedValue != "") obj.UnitOwnerMemberId = int.Parse(wddMember.SelectedValue);

                return obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //todo: USUARIO DE PRUEBA PARA ENTRAR MAS RAPIDO, QUITAR EN VERSION FINAL
            this.CheckLogin();
            this.SetPageId(401);
            h1OptionMenuPageName.InnerText = new BcMenuOption().GetMenuOptionById(int.Parse(Session["MenuOptionId"].ToString())).Name;

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
                NewUnitRegister();
            }
            List<UnitRegisterTableRow> list = new BcUnitRegister().GetUnitRegisterTable(out errorMessage);
            wdgMain.DataSource = list;
            wdgMain.DataBind();
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveUnitRegister();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            NewUnitRegister();
        }

        protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            ExportToExcel();
        }

        

        protected void wdgMain_Selection_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            SetControlValuesFromGrid(e.CurrentSelectedRows[0].Index);
        }

        protected void wddConfigurationUnitType_SelectionChanged(object sender, DropDownSelectionChangedEventArgs e)
        {
            ChangeConfigurationUnitType(int.Parse(wddConfigurationUnitType.SelectedValue));
        }

        protected void wddUnitType_SelectionChanged(object sender, DropDownSelectionChangedEventArgs e)
        {
            string errorMessage = "";
            int unitTypeId = int.Parse(wddUnitType.SelectedValue);
            wddConfigurationUnitType.SetComboListByFiltrer(new BcUnitRegister(), unitTypeId, out errorMessage);
            wddConfigurationUnitType.SelectedValue = "0";
            ChangeConfigurationUnitType(0);
        }

        protected void imbLeftArrow_Click(object sender, ImageClickEventArgs e)
        {
            string errorMessage = "";
            ConfigurationUnitType conf = new BcConfigurationUnitType().GetMinConfigurationUnitType(out errorMessage);
            int currentIndex = wddConfigurationUnitType.SelectedItemIndex;
            if (currentIndex > 0) currentIndex--;
            wddConfigurationUnitType.SelectedItemIndex = currentIndex;
            ChangeConfigurationUnitType(currentIndex);
        }

        protected void imbRightArrow_Click(object sender, ImageClickEventArgs e)
        {
            string errorMessage = "";
            ConfigurationUnitType conf = new BcConfigurationUnitType().GetMaxConfigurationUnitType(out errorMessage);
            int maxIndex = wddConfigurationUnitType.Items.Count - 1;
            int currentIndex = wddConfigurationUnitType.SelectedItemIndex;
            if (currentIndex < maxIndex) currentIndex++;
            wddConfigurationUnitType.SelectedItemIndex = currentIndex;
            ChangeConfigurationUnitType(currentIndex);
        }

        #endregion Eventos de controles graficos

        #region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void ChangeConfigurationUnitType(int index)
        {
            string errorMessage = "";
            if (index == 0)
            {
                imgConfigurationImage.ImageUrl = "~/ig_common/configurations/blank_configuration.png";
            }
            else
            {
                int id = int.Parse(wddConfigurationUnitType.SelectedValue);
                ConfigurationUnitType obj = new BcConfigurationUnitType().GetConfigurationUnitType(id, out errorMessage);
                imgConfigurationImage.ImageUrl = obj.Path;
            }
        }

        protected void SetControlValuesFromGrid(int rowIndex)
        {
            NewUnitRegister();

            string errorMessage = "";
            string patentNumber = wdgMain.GetItemByKey(rowIndex, "PatentNumber");
            UnitRegister unitreg = new BcUnitRegister().GetUnitRegisterByPatentNumber(patentNumber, out errorMessage);
            wddUnitType.SetComboList(new BcUnitType(), out errorMessage);
            wddUnitType.SelectedValue = unitreg.UnitTypeId.ToString();
            wddConfigurationUnitType.SetComboList(new BcConfigurationUnitType(), out errorMessage);
            wddConfigurationUnitType.SelectedValue = unitreg.UnitTypeConfigurationId.ToString();
            wmePatentNumber.Text  = unitreg.PatentNumber;
            wteUnitName.Text = unitreg.UnitName;
            wteInternalNumber.Text = unitreg.InternalNumber;
            wddSuspensionType.SetComboList(new BcSuspensionType(), out errorMessage);
            wddSuspensionType.SelectedValue = unitreg.SuspensionTypeId.ToString();
            wneKilometersOfTrave.Text = unitreg.KilometersOfTravel.ToString();
            wneUnitTara.Value = unitreg.UnitTara;
            wteVin.Text = unitreg.Vin;
            wddNewOrUsed.SelectedValue = unitreg.NewOrUsed;
            wteUnitManufacturingYea.Text = unitreg.UnitManufacturingYear.ToString();
            wdpUnitPurchaseDate.Date = unitreg.UnitPurchaseDate;
            wdpDriveLicence.Date = DateTime.Parse(unitreg.NextDrivingLicenseDate.ToString());
            wdpTechnicalReview.Date = (DateTime)unitreg.NextTechnicalReviewDate;
            string defaultValue= "01-01-2001 0:00:00";
            if (unitreg.NextQualificationDate.ToString() != defaultValue)
            {
                string cadena = unitreg.NextQualificationDate.ToString();
                wdpQuality.Date = (DateTime)unitreg.NextQualificationDate;
            }
            else
            {
                wdpQuality.Text = "";
                wdpQuality.Date = new DateTime();
            }

            Member member = new BcMember().GetMemberById(unitreg.UnitOwnerMemberId, out errorMessage);

            //wddMember.SetComboListByFiltrer(new BcMember(), member.MemberTypeId, out errorMessage);
            //wddMember.SelectedValue = unitreg.UnitOwnerMemberId.ToString();
            wddMember.Items.Clear();
            List<DropDownItem> items = new BcMember().GetComboProvider();
            foreach(DropDownItem item in items)
            {
                wddMember.Items.Add(item);
            }
            wddMember.DataBind();
            wddMember.SelectedValue = unitreg.UnitOwnerMemberId.ToString();

            wddService.Items.Clear();
            wddService.DataSource = null;

            wddModel.Items.Clear();
            wddModel.DataSource = null;

            wddOrigin.Items.Clear();
            wddOrigin.DataSource = null;

            UnitRegisterId = unitreg.UnitRegisterId;
            Unit unit = new BcUnitAssigned().GetUnitByUnitRegisterId(UnitRegisterId, out errorMessage);
            Asset asset = new BcUnitAssigned().GetAssetById(unit.AssetId);
            AssetUniqueIdentification aui = new BcUnitAssigned().GetAUItById(asset.AssetUniqueIdentificationId);
            Brand brand = new BcUnitAssigned().GetBrandbyModelId(aui.AssetModelId);
            wddBrand.SelectedValue = brand.BrandId.ToString();

            ChargeModelCombo(brand.BrandId);
            wddModel.SelectedValue = aui.AssetModelId.ToString();

            ChargeServiceCombo(brand.BrandId, aui.AssetModelId);
            string id = aui.AssetModelServiceId.ToString();
            wddService.SelectedValue = aui.AssetModelServiceId.ToString();
            wddService.SelectedValue = id;
            ChargeOriginCombo(brand.BrandId, aui.AssetModelId, aui.AssetModelServiceId);
            wddOrigin.SelectedValue = aui.AssetUniqueIdentificationId.ToString();

            List<UnitRegisterTableRow> list = new BcUnitRegister().GetUnitRegisterTable(out errorMessage);
            wdgMain.DataSource = list;
            wdgMain.DataBind();

            ChangeConfigurationUnitType(int.Parse(wddConfigurationUnitType.SelectedValue));
         }

        protected void SaveUnitRegister()
        {
            int km;
            if (!int.TryParse(wneKilometersOfTrave.Text, out km))
            {
                Page.ShowPopupMessage("El kilometraje solo acepta numeros");
                return;
            }

            int year;
            if(!int.TryParse(wteUnitManufacturingYea.Text,out year))
            {
                Page.ShowPopupMessage("El año de fabricación solo acepta numeros");
                return;
            }
            string errorMessage = "Debe seleccionar una configuracion de marca/modelo/servicio";
            if (wddOrigin.SelectedValue != "0")
            {
                //Validar que el service no sea 0//
                if (UnitRegisterId != 0)
                {
                    Update(out errorMessage);
                    wdgMain.SetTableList(new BcUnitRegister());
                    Page.ShowPopupMessage(errorMessage);
                    return;
                }

                if (new BcUnitRegister().Validate(GetUnitRegister, out errorMessage))
                {
                    if (!validateDate(out errorMessage))
                    {
                        Page.ShowPopupMessage(errorMessage);
                        return;
                    }
                    int AUI = int.Parse(wddOrigin.SelectedValue);
                    Asset asset = new Asset();
                    asset.AssetUniqueIdentificationId = AUI;
                    asset.Cost = 0;
                    asset.WarrantyStartDate = DateTime.Now;
                    asset.DispatchProviderDocumentId = 1;
                    asset.Kilometers = 0;
                    asset.IsGood = "Y";
                    asset.Kilometers = 0;
                    asset.ApplicationId = null;
                    asset.Dot = null;
                    asset.ScrapTypeId = null;
                    asset.RepairTypeId = null;
                    asset.AssetSerie = null;
                    asset.WarrantyMounth = null;
                    asset.WarrantyKm = null;

                    Asset savedObj = new BcAsset().Save(asset, out errorMessage);
                    if (savedObj != null)
                    {
                        UnitRegister savedObjUnit = new BcUnitRegister().Save(GetUnitRegister, out errorMessage);
                        if (savedObjUnit != null)
                        {
                            UnitRegisterId = savedObjUnit.UnitRegisterId;
                            NewUnitRegister();
                            Unit unit = new Unit();

                            unit.AssetId = savedObj.AssetId;
                            unit.UnitRegisterId = savedObjUnit.UnitRegisterId;
                            Unit SavedUnit = new BcUnitAssigned().Save(unit, out errorMessage);

                            if (SavedUnit!=null)
                            {
                                errorMessage = "Se ha registrado exitosamente la unidad con patente: "+ savedObjUnit.PatentNumber;
                                Page.ShowPopupMessage(errorMessage);
                            }
                            else
                            {
                                Page.ShowPopupMessage(errorMessage);
                            }
                        }
                        wdgMain.SetTableList(new BcUnitRegister());

                    }
                    Page.ShowPopupMessage(errorMessage);
                }
               
            }
            else
            {
                Page.ShowPopupMessage(errorMessage);
            }
        }

        protected void NewUnitRegister()
        {
            string errorMessage = "";

            List<Infragistics.Web.UI.ListControls.DropDownItem> BrandList = new BcUnitAssigned().GetComboBrandUnit(out errorMessage);
            foreach (Infragistics.Web.UI.ListControls.DropDownItem item in BrandList)
            {
                wddBrand.Items.Add(item);
            }
            wddBrand.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "" });
            wddBrand.DataBind();
            wddBrand.SelectedValue = "0";

            wddService.Items.Clear();
            wddService.DataSource = null;
            wddService.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "" });
            wddService.DataBind();
            wddService.SelectedValue = "0";

            wddModel.Items.Clear();
            wddModel.DataSource = null;
            wddModel.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "" });
            wddModel.DataBind();
            wddModel.SelectedValue = "0";

            wddOrigin.Items.Clear();
            wddOrigin.DataSource = null;
            wddOrigin.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "" });
            wddOrigin.DataBind();
            wddOrigin.SelectedValue = "0";

            wdpUnitPurchaseDate.Date = new DateTime();
            wdpDriveLicence.Date = new DateTime();
            wdpTechnicalReview.Date = new DateTime();
            wdpQuality.Date = new DateTime();

            UnitRegisterId = 0;
            wddUnitType.SetComboList(new BcUnitType(), out errorMessage);
            wddUnitType.SelectedValue = "0";
            wddConfigurationUnitType.Items.Clear();
            wddConfigurationUnitType.Items.Add(new DropDownItem("", "0"));
            wddConfigurationUnitType.SelectedValue = "0";
            wmePatentNumber.Text = "";
            wteUnitName.Text = "";
            wteInternalNumber.Text = "";
            wddSuspensionType.SetComboList(new BcSuspensionType(), out errorMessage);
            wddSuspensionType.SelectedValue = "0";
            wneKilometersOfTrave.Text = "";
            wneUnitTara.Value = "";
            wteVin.Text = "";
            wddNewOrUsed.SelectedValue = "0";
            wteUnitManufacturingYea.Text = "";
            wdpUnitPurchaseDate.Date = new DateTime();
            wdpUnitPurchaseDate.Text = "";
            //wddMember.DataSource = new BcMember().GetComboProvider();
            //wddMember.SelectedValue = "0";
            //List<UnitRegisterTableRow> list = new BcUnitRegister().GetUnitRegisterTable(out errorMessage);
            //wdgMain.DataSource = list;
            //wdgMain.DataBind();
            wddMember.Items.Clear();
            List<DropDownItem> items = new BcMember().GetComboProvider();
            foreach (DropDownItem item in items)
            {
                wddMember.Items.Add(item);
            }
            wddMember.DataBind();
            wddMember.SelectedValue = "0";

            ChangeConfigurationUnitType(0);
        }

        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcUnitRegister());
            wdgMain.ExportToExcel();
        }

        protected void DeleteUnitRegister(int rowIndex)
        {
            string errorMessage = "";

            int unitRegisterId = wdgMain.GetItemIntByKey(rowIndex, "UnitRegisterId");
            string patentNumber = wdgMain.GetItemByKey(rowIndex, "PatentNumber");

            CommonEnums.DeletedRecordStates deleteState = new BcUnitRegister().DeleteUnitRegister(unitRegisterId, patentNumber, out errorMessage);
            if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                NewUnitRegister();
                string errorMessage1 = "";
                wdgMain.CleanDataSource();
                List<UnitRegisterTableRow> list = new BcUnitRegister().GetUnitRegisterTable(out errorMessage1);
                wdgMain.DataSource = list;
                wdgMain.DataBind();
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
            DeleteUnitRegister(id);
            mpeConfirmar.Hide();
        }

        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void wddModel_SelectionChanged(object sender, DropDownSelectionChangedEventArgs e)
        {
            wddService.Items.Clear();
            wddService.DataSource = null;
            wddService.DataBind();

            wddOrigin.Items.Clear();
            wddOrigin.DataSource = null;
            wddOrigin.DataBind();

            string errorMessage = "";
            
            int brandId = int.Parse(wddBrand.SelectedValue);
            int modelId = int.Parse(wddModel.SelectedValue);

            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new BcUnitAssigned().GetComboAssetModelServiceUnit( brandId, modelId, out errorMessage);
            foreach (Infragistics.Web.UI.ListControls.DropDownItem item in List)
            {
                wddService.Items.Add(item);

            }
            wddService.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "Seleccione un servicio" });
            wddService.DataBind();
            wddService.SelectedValue = "0";
        }

        protected void wddBrand_SelectionChanged(object sender, DropDownSelectionChangedEventArgs e)
        {
            wddService.Items.Clear();
            wddService.DataSource = null;
            wddService.DataBind();

            wddModel.Items.Clear();
            wddModel.DataSource = null;
            wddModel.DataBind();

            wddOrigin.Items.Clear();
            wddOrigin.DataSource = null;
            wddOrigin.DataBind();

            string errorMessage = "";
            
            int brandId = int.Parse(wddBrand.SelectedValue);

            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                  new BcUnitAssigned().GetComboAssetModelUnit( brandId, out errorMessage);
            foreach (Infragistics.Web.UI.ListControls.DropDownItem item in List)
            {
                wddModel.Items.Add(item);

            }
            wddModel.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "Seleccione un modelo" });
            wddModel.DataBind();
            wddModel.SelectedValue = "0";
        }

        protected void wddService_SelectionChanged(object sender, DropDownSelectionChangedEventArgs e)
        {
            
            wddOrigin.Items.Clear();
            wddOrigin.DataSource = null;
            wddOrigin.DataBind();

            string errorMessage = "";

            int brandId = int.Parse(wddBrand.SelectedValue);
            int modelId = int.Parse(wddModel.SelectedValue);
            int serviceId = int.Parse(wddService.SelectedValue);

            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new BcUnitAssigned().GetComboOriginUnit(brandId, modelId, serviceId, out errorMessage);
            foreach (Infragistics.Web.UI.ListControls.DropDownItem item in List)
            {
                wddOrigin.Items.Add(item);

            }
            wddOrigin.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "Seleccione un País" });
            wddOrigin.DataBind();
            wddOrigin.SelectedValue = "0";
        }

        protected void ChargeBrandCombo()
        {
            string errorMessage = "";
            List<Infragistics.Web.UI.ListControls.DropDownItem> BrandList = new BcUnitAssigned().GetComboBrandUnit(out errorMessage);
            foreach (Infragistics.Web.UI.ListControls.DropDownItem item in BrandList)
            {
                wddBrand.Items.Add(item);

            }
            wddBrand.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "" });
            wddBrand.DataBind();
            wddBrand.SelectedValue = "0";
        }

        protected void ChargeModelCombo(int brandId )
        {
            wddService.Items.Clear();
            wddService.DataSource = null;
            wddService.DataBind();

            wddModel.Items.Clear();
            wddModel.DataSource = null;
            wddModel.DataBind();

            wddOrigin.Items.Clear();
            wddOrigin.DataSource = null;
            wddOrigin.DataBind();

            string errorMessage = "";

            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                  new BcUnitAssigned().GetComboAssetModelUnit(brandId, out errorMessage);
            foreach (Infragistics.Web.UI.ListControls.DropDownItem item in List)
            {
                wddModel.Items.Add(item);

            }
            wddModel.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "Seleccione un modelo" });
            wddModel.DataBind();
            wddModel.SelectedValue = "0";
        }

        protected void ChargeServiceCombo(int brandId, int modelId)
        {
            wddService.Items.Clear();
            wddService.DataSource = null;
            wddService.DataBind();

            wddOrigin.Items.Clear();
            wddOrigin.DataSource = null;
            wddOrigin.DataBind();

            string errorMessage = "";

            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new BcUnitAssigned().GetComboAssetModelServiceUnit(brandId, modelId, out errorMessage);
            foreach (Infragistics.Web.UI.ListControls.DropDownItem item in List)
            {
                wddService.Items.Add(item);

            }
            wddService.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "Seleccione un servicio" });
            wddService.DataBind();
            wddService.SelectedValue = "0";
        }

        protected void ChargeOriginCombo(int brandId, int modelId, int serviceId)
        {
            wddOrigin.Items.Clear();
            wddOrigin.DataSource = null;
            wddOrigin.DataBind();
            string errorMessage = "";

            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new BcUnitAssigned().GetComboOriginUnit(brandId, modelId, serviceId, out errorMessage);
            foreach (Infragistics.Web.UI.ListControls.DropDownItem item in List)
            {
                wddOrigin.Items.Add(item);

            }
            wddOrigin.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "Seleccione un País" });
            wddOrigin.DataBind();
            wddOrigin.SelectedValue = "0";
        }

        protected void Update(out string errorMessage)
        {
            
            if(!validateDate(out errorMessage))
            {
                return;
            }
            errorMessage = "Error al actualizar los datos.";
            if (wddOrigin.SelectedValue != "" || wddOrigin.SelectedValue != "0")
            {
                
                try
                {
                    
                    UnitRegisterId = UnitRegisterId;
                    Unit unit = new BcUnitAssigned().GetUnitByUnitRegisterId(UnitRegisterId, out errorMessage);
                    Asset asset = new BcUnitAssigned().GetAssetById(unit.AssetId);
                    AssetUniqueIdentification aui = new BcUnitAssigned().GetAUItById(asset.AssetUniqueIdentificationId);

                    aui.AssetUniqueIdentificationId = int.Parse(wddOrigin.SelectedValue);
                    asset.AssetUniqueIdentificationId = aui.AssetUniqueIdentificationId;

                    UnitRegister Register = GetUnitRegister;
                    
                    errorMessage = "Error la ingresar la configuración marca/modelo/servicio";
                    new BcAsset().Save(asset, out errorMessage);
                    errorMessage = "Error con el ingreso de datos de la unidad";
                    new BcUnitRegister().Save(Register, out errorMessage);
                    errorMessage = "Se ha actualizado los datos correctamente";
                }catch (Exception ex)
                {
                    
                }
            }
            else
            {
                errorMessage="Debe completar la configuración de marca/modelo/servicio";
            }
        }

        protected bool validateDate(out string errorMessage)
        {
            errorMessage = "";
            
            if (int.Parse(wneKilometersOfTrave.Text) < 0) { errorMessage = "El kilometraje no puede ser menor a 0"; return false; }

            if (wdpUnitPurchaseDate.Date > DateTime.Now) { errorMessage = "La fecha de compra no puede ser superior a la actulidad"; return false; }
            int time = (DateTime.Now.Year) + 1;

            if (int.Parse(wteUnitManufacturingYea.Text)> time) { errorMessage = "La fecha de fabricación no puede ser superior a " + time; return false; }

            if (wdpTechnicalReview.Text == "") { errorMessage = "Debe selecionar una fecha de vencimiento de revisión"; return false; }

            //if (wdpQuality.Text == "") { errorMessage = "Debe selecionar una fecha de proxima habilitación"; return false; }

            if (wdpTechnicalReview.Date <= DateTime.Now) { errorMessage = "El vencimiento de la revisión tecnica no puede ser inferior a la actualidad"; return false; }

            if (wdpQuality.Text != ""){
                if (wdpQuality.Date <= DateTime.Now) { errorMessage = "La proxima habilitación no puede ser inferior a la actualidad"; return false; }
            }

            if (wddNewOrUsed.SelectedValue == "0") { errorMessage = "Debe seleccionar si el vehiculo esta nuevo o usado"; return false; }
            return true;
        }
    }
}