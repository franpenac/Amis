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
    public partial class WucSettingExtinguisher : System.Web.UI.UserControl
    {

        public bool estado { get; set; }

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

        protected SettingExtinguisher GetSettingExtinguisher
        {
            get
            {
                SettingExtinguisher obj = new SettingExtinguisher();
                obj.SettingExtinguisherId = 0;
                obj.FireTypeId = 0;
                if (wddFireType.SelectedValue != "") obj.FireTypeId = int.Parse(wddFireType.SelectedValue);
                string FireSize = "";
                for (int i = 0; i <= wneFireSize.Text.ToString().Length - 1; i++)
                {
                    if (wneFireSize.Text.Substring(i) != "." && wneFireSize.Text.Substring(i) != ",")
                    {
                        FireSize = FireSize + wneFireSize.Text.Substring(i);
                    }
                }
                obj.FireSize = int.Parse(FireSize);
                obj.EndLifeDate = wdpEndDate.Date;
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
            estado = true;
        }

        protected void InitializeControls()
        {
            string errorMessage = "";
            if (!IsPostBack)
            {
                wddFireType.SelectedValue = "0";
                wddFireType.SetComboList(new BcFireType(), out errorMessage);

            }
        }

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveSettingExtinguisher();
        }

        public int SaveSettingExtinguisher()
        {
            string errorMessage = "";
            int id = 0;

            AssetModel obj = GetAssetModel;
            obj.BrandId = BrandId;
            AssetModel savedAsset = new BcAssetModel().Save(obj, out errorMessage);
            if (savedAsset != null)
            {
                SettingExtinguisher setting = GetSettingExtinguisher;
                setting.AssetModelId = savedAsset.AssetModelId;
                SettingExtinguisher savedSetting = new BcSettingExtinguisher().Save(setting, out errorMessage);
                if (savedSetting != null)
                {
                    errorMessage = "Nuevo Modelo Agregado";
                    NewSettingExtinguisher();
                    id = savedAsset.AssetModelId;
                }
                else
                {
                    errorMessage = "No se pudo agregar el modelo nuevo!";
                    
                }
            }
            else
            {
                errorMessage = "No se pudo agregar el modelo nuevo!";
            }
            Page.ShowPopupMessage(errorMessage);
            return id;
        }

        protected void NewSettingExtinguisher()
        {
            string errorMessage = "";

            wddFireType.SetComboList(new BcAssetType(), out errorMessage);
            wteAssetModelName.Text = "";
            wneFireSize.Text = "0";

        }

    }
}