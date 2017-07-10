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
    public partial class WucSettingCat : System.Web.UI.UserControl
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

        protected SettingCat GetSettingCat
        {
            get
            {
                SettingCat obj = new SettingCat();
                obj.SettingCatId = 0;
                string capacity = "";
                for (int i = 0; i <= wneCapacity.Text.ToString().Length - 1; i++)
                {
                    if (wneCapacity.Text.Substring(i) != "." && wneCapacity.Text.Substring(i) != ",")
                    {
                        capacity = capacity + wneCapacity.Text.Substring(i);
                    }
                }
                obj.Capacity = int.Parse(capacity);
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
                NewSettingExtinguisher();
            }
        }

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveSettingCat();
        }

        public int SaveSettingCat()
        {
            string errorMessage = "";
            int id = 0;
                AssetModel obj = GetAssetModel;
                obj.BrandId = BrandId;
                AssetModel savedAsset = new BcAssetModel().Save(obj, out errorMessage);
                if (savedAsset != null)
                {
                    SettingCat setting = GetSettingCat;
                    setting.AssetModelId = savedAsset.AssetModelId;
                    SettingCat savedSetting = new BcSettingCat().Save(setting, out errorMessage);
                    if (savedSetting != null)
                    {
                        errorMessage = "Nuevo Modelo Agregado";
                        NewSettingExtinguisher();
                        id = savedAsset.AssetModelId;
                    }
                    else
                    {
                        new BcSettingCat().DeleteSettingCat(savedSetting.SettingCatId, out errorMessage);
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

            wteAssetModelName.Text = "";
            wneCapacity.Text = "0";
        }


    }
}