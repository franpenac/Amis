using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.Configuration
{
    public partial class WucSettingTyre : System.Web.UI.UserControl
    {
        protected SettingTyre GetSettingTyre
        {
            get
            {
                SettingTyre obj = new SettingTyre();
                obj.SettingTyreId = 0;
                if (ddlOriginal.SelectedItem.Text=="Nuevo")
                {
                    obj.Original = "Y";
                }
                if (ddlOriginal.SelectedItem.Text == "Recapado")
                {
                    obj.Original = "N";
                }
                obj.DepthNumber = int.Parse(txbDepthNumber.Text);
                obj.MeasurementsTyreId = int.Parse(ddlMeasurementTyre.SelectedValue);
                obj.SpeedIndexId = int.Parse(ddlSpeedIndex.SelectedValue);
                obj.IndexWeghId = int.Parse(ddlWeighIndex.SelectedValue);

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
                ChargeCombos();
                NewSetting();

                
            }
        }

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveSettingTyre();
        }

        public int SaveSettingTyre()
        {
            string errorMessage = "";
            int ID = 0;

            SettingTyre setting = GetSettingTyre;
                
            SettingTyre saveSetting = new BcSettingTyre().Save(setting, out errorMessage);
            if (saveSetting != null)
            {
                ID = saveSetting.SettingTyreId;
                NewSetting();
            }

            Page.ShowPopupMessage(errorMessage);
            return ID;

        }

        protected void NewSetting()
        {

            txbDepthNumber.Text = "";
            ddlOriginal.SelectedValue = "0";
            ddlMeasurementTyre.SelectedValue = "0";
            ddlSpeedIndex.SelectedValue = "0";
            ddlWeighIndex.SelectedValue = "0";
            lblSpeed.Text = "";
            lblWeigh.Text = "";
        }

        protected void ChargeCombos()
        {
            List<ListItem> measurements = new BcSettingTyre().GetMeasurementTyreList();
            List<ListItem> speeds = new BcSettingTyre().GetSpeedIndexList();
            List<ListItem> weighs = new BcSettingTyre().GetWeighIndexList();

            ListItem newTyre = new ListItem("Nuevo", "1");
            ListItem retraidingTyre = new ListItem("Recapado", "2");
            ListItem Default = new ListItem("", "0");

            ddlSpeedIndex.Items.Add(Default);
            ddlWeighIndex.Items.Add(Default);
            ddlMeasurementTyre.Items.Add(Default);

            foreach (ListItem measurement in measurements) { ddlMeasurementTyre.Items.Add(measurement); }
            foreach (ListItem speed in speeds) { ddlSpeedIndex.Items.Add(speed); }
            foreach (ListItem weigh in weighs) { ddlWeighIndex.Items.Add(weigh); }

            ddlSpeedIndex.SelectedValue="0";
            ddlWeighIndex.SelectedValue = "0";
            ddlMeasurementTyre.SelectedValue = "0";

            ddlOriginal.Items.Add(Default);
            ddlOriginal.Items.Add(newTyre);
            ddlOriginal.Items.Add(retraidingTyre);
        }

        protected void ddlSpeedIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpeedIndex speed = new BcSettingTyre().GetSpeedById(int.Parse(ddlSpeedIndex.SelectedValue));
            lblSpeed.Text = speed.SpeedIndexName;
        }

        protected void ddlWeighIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexWegh weigh = new BcSettingTyre().GetWeighById(int.Parse(ddlWeighIndex.SelectedValue));
            lblWeigh.Text = weigh.IndexWeghName;
        }
    }
}