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
    public partial class WucSettingBattery : System.Web.UI.UserControl
    {
        
        public int BrandId
        {
            get
            {
                if (ViewState["BrandPage_BrandId"] == null)
                {
                    ViewState["BrandPage_BrandId"] = 0;
                }
                int id = int.Parse(ViewState["BrandPage_BrandId"].ToString());
                return id;
            }
            set
            {
                ViewState["BrandPage_BrandId"] = value;
            }
        }
        
        protected SettingBattery GetSettingBattery
        {
            get
            {
                SettingBattery obj = new SettingBattery();
                obj.SettingBatteryId = 0;
                obj.PositionPolePositive = wddPolePositive.SelectedItem.Text;
                string voltage = "";
                for (int i = 0; i <= wneVoltage.Text.Length-1; i++)
                {
                    string indicate = wneVoltage.Text.ToString().Substring(i, 1);
                    if (indicate != "." && indicate != ",")
                    {
                        voltage = voltage + wneVoltage.Text.Substring(i,1);
                    }
                }
                obj.Voltage = int.Parse(voltage);
                string capacity = "";
                for (int i = 0; i <= wneCapacity.Text.ToString().Length-1; i++)
                {
                    if (wneCapacity.Text.Substring(i) != "." && wneCapacity.Text.Substring(i) != ",")
                    {
                        capacity = voltage + wneCapacity.Text.Substring(i);
                    }
                }
                obj.Capacity = int.Parse(capacity);
                obj.InstallDate = wdpInstallDate.Date;
                return obj;

            }
        }

        protected AssetModel GetAssetModel
        {
            get
            {
                AssetModel obj = new AssetModel();
                obj.AssetModelId = 0;
                obj.AssetModelName = wteAssetModelName.Text;
                return obj;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }

        protected void InitializeControls()
        {
            
            if (!IsPostBack)
            {
                
            }
        }

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveSettingBattery();
        }

        public int SaveSettingBattery()
        {
            string errorMessage = "";
            int id = 0;

            if (wddPolePositive.SelectedItem.Text != "Seleccione la posicion" || wddPolePositive.SelectedItem != null)
            {
                AssetModel obj = GetAssetModel;
                obj.BrandId = BrandId;
                AssetModel savedAsset = new BcAssetModel().Save(obj, out errorMessage);
                if (savedAsset != null)
                {
                    SettingBattery setting = GetSettingBattery;
                    setting.AssetModelId = savedAsset.AssetModelId;
                    SettingBattery savedSetting = new BcSettingBattery().Save(setting, out errorMessage);
                    if (savedSetting != null)
                    {
                        errorMessage = "Nuevo Modelo Agregado";
                        NewSettingExtinguisher();
                        id = savedAsset.AssetModelId;
                    }
                    else
                    {
                        new BcSettingBattery().DeleteSettingBattery(savedSetting.SettingBatteryId, out errorMessage);
                        errorMessage = "No se pudo agregar el modelo nuevo!";

                    }
                }
                else
                {
                    errorMessage = "No se pudo agregar el modelo nuevo!";
                }
            }
            else
            {
                errorMessage = "Debe ingresar una posicion para la bateria";
            }
            
            Page.ShowPopupMessage(errorMessage);
            return id;
        }

        protected void NewSettingExtinguisher()
        {
            
            wteAssetModelName.Text = "";
            wdpInstallDate.Date = DateTime.Now;
            wneCapacity.Text = "0";
            wneVoltage.Text = "0";

        }


    }
}