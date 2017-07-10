using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using amis._DataLayer.GeneratedCode;
using amis.Models;
using Infragistics.Web.UI.GridControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class SelectReplaceToSameUnitTyre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errorMessage = "";
            int idUnitRegister = (int)Session["UnitRegisterFind"];
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(idUnitRegister, out errorMessage);
            Session["UnitFind"] = new BcUnit().GetUnitByUnitRegisterId(idUnitRegister).UnitId.ToString();
            lblPatentSelected.Text = (string)Session["Patent"];
            lblInternalNumberSelected.Text = (string)Session["InternalNumber"];
            Session["EventAssetTypeId"] = 1;
            if (!IsPostBack)
            {
                InitializeControls();
            }
            ChargeButtons();
        }

        protected void PositionTyres()
        {
            List<Button> listButtons = new List<Button>();
            string errorMessage = "";
            int unitId = int.Parse((string)Session["UnitFind"]);
            Unit unitInSession = new BcUnit().GetUnitById(unitId, out errorMessage);
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(unitInSession.UnitRegisterId, out errorMessage);
            ConfigurationUnitType unitConfig = new BcConfigurationUnitType().GetConfigurationUnitType(unitRegister.UnitTypeConfigurationId, out errorMessage);
            List<ConfigurationAxleUnitType> axleConf = new BcConfigurationAxleUnitType().GetConfigurationAxleUnitTypeByAxleConfigId(unitConfig.ConfigurationUnitTypeId);
            Session["ListConfigAxleUnitType"] = axleConf;
            Session["CountTyres"] = 0;
            foreach (ConfigurationAxleUnitType item in axleConf)
            {
                List<AssetPosition> assetPosition = new BcAssetPosition().GetAssetPositionByAxleId(item.AxleConfigurationId);
                foreach (AssetPosition item2 in assetPosition)
                {
                    string buttonId = "btn0" + item.Position.ToString();
                    if (item2.AssetColumn.ToString().Length == 1)
                    {
                        buttonId = buttonId + "0" + item2.AssetColumn.ToString();
                    }
                    else
                    {
                        buttonId = buttonId + item2.AssetColumn.ToString();
                    }
                    Button btn = (Button)imgTable.FindControl(buttonId);
                    listButtons.Add(btn);
                    btn.Enabled = true;
                }
                Session["ListButtons"] = listButtons;
            }
        }

        protected void ChargeButtons()
        {
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            foreach (Button item in listButtons)
            {
                Button btn = (Button)imgTable.FindControl(item.ID);
                btn.CssClass = item.CssClass;
                btn.Enabled = item.Enabled;
            }
        }

        protected void InitializeControls()
        {
            string errorMessage = "";
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById((int)Session["UnitRegisterFind"], out errorMessage);
            int unitId = new BcUnit().GetUnitByUnitRegisterId(unitRegister.UnitRegisterId).UnitId;
            Unit unitInSession = new BcUnit().GetUnitById(unitId, out errorMessage);
            ConfigurationUnitType unitConfig = new BcConfigurationUnitType().GetConfigurationUnitType(unitRegister.UnitTypeConfigurationId, out errorMessage);
            string imgPath = unitConfig.Path;
            imgPath = imgPath.Replace("~", "");
            imgTable.Style["background-image"] = "url('" + imgPath + "')";
        }

        protected void imgbtn_Click(object sender, EventArgs e)
        {
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            Session["TyreTagPosition2"] = null;
            Button btn = (Button)sender;
            Session["TyreTagPosition2"] = btn.ID;
            if (btn.CssClass != "imgWrongRequest" || btn.CssClass != "imgInspectionSuccessful")
            {
                foreach (Button item in listButtons)
                {
                    if (item.ID == btn.ID)
                    {
                        item.CssClass = "imgInProgress";
                    }
                }
                ChargeButtons();
                if (Session["ToScrap"] != null)
                {
                    mpeConffirmInspectionChange.Show();
                }else
                {
                    mpeConfirmar.Show();
                }               
                Session["ListButtons"] = listButtons;
            }
        }

        protected void btnYesChange_Click(object sender, EventArgs e)
        {
            List<ConfigurationAxleUnitType> confList = (List<ConfigurationAxleUnitType>)Session["ListConfigAxleUnitType"];
            string buttonId = (string)Session["TyreTagPosition2"];
            string digit1 = buttonId.Substring(4, 1);
            string digit2 = buttonId.Substring(6, 1);
            string digit3 = buttonId.Substring(5, 2);
            int idAxle = 0;
            int idAssetPosition = 0;
            foreach (var item in confList)
            {
                if (digit1 == item.Position.ToString())
                {
                    idAxle = item.AxleConfigurationId;
                    break;
                }
            }
            List<AssetPosition> assetPosition = new BcAssetPosition().GetAssetPositionByAxleId(idAxle);
            foreach (var item in assetPosition)
            {
                if (item.AssetColumn.ToString().Length == 1)
                {
                    if (item.AssetColumn == int.Parse(digit2))
                    {
                        idAssetPosition = item.AssetPositionId;
                        break;
                    }
                }
                else
                {
                    if (item.AssetColumn == int.Parse(digit3))
                    {
                        idAssetPosition = item.AssetPositionId;
                        break;
                    }
                }
            }
            int unitId = int.Parse((string)Session["UnitFind"]);
            int assetId = (int)Session["AssetId"];
            UnitAsset unitAsset = new BcUnitAsset().GetUnitAssetByAssetPositionIdAndUnitId(idAssetPosition, unitId);
            if (unitAsset == null)
            {
                new BcUnitAsset().ChangeAssetPositionId(assetId, idAssetPosition);



                Session["ListButtons"] = null;
                Session["FinishChange"] = 1;
                Session["AssetId"] = null;
                Session["TyreTagPosition2"] = null;
                Session["TyreTagPosition"] = null;
                mpeConfirmar.Hide();
                Session["isChange"] = null;
                Session["IsReplace"] = null;
                Response.Redirect("SelectionReplaceTyrePage.aspx");
            }
            else
            {
                mpeHasTyreOk.Show();
            }
        }

        protected void btnNoChange_Click(object sender, EventArgs e)
        {
            mpeConfirmar.Hide();
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            string buttonId = (string)Session["TyreTagPosition2"];
            foreach (Button item in listButtons)
            {
                if (item.ID == buttonId)
                {
                    item.CssClass = "imgHidden";
                    item.Enabled = true;
                }
                if (item.CssClass == "imgHidden" && item.Enabled == false)
                {
                    item.Enabled = true;
                }
            }
            ChargeButtons();
        }

        protected void btnYesInspectionChange_Click(object sender, EventArgs e)
        {
            List<ConfigurationAxleUnitType> confList = (List<ConfigurationAxleUnitType>)Session["ListConfigAxleUnitType"];
            string buttonId = (string)Session["TyreTagPosition2"];
            string digit1 = buttonId.Substring(4, 1);
            string digit2 = buttonId.Substring(6, 1);
            string digit3 = buttonId.Substring(5, 2);
            int idAxle = 0;
            int idAssetPosition = 0;
            foreach (var item in confList)
            {
                if (digit1 == item.Position.ToString())
                {
                    idAxle = item.AxleConfigurationId;
                    break;
                }
            }
            List<AssetPosition> assetPosition = new BcAssetPosition().GetAssetPositionByAxleId(idAxle);
            foreach (var item in assetPosition)
            {
                if (item.AssetColumn.ToString().Length == 1)
                {
                    if (item.AssetColumn == int.Parse(digit2))
                    {
                        idAssetPosition = item.AssetPositionId;
                        break;
                    }
                }
                else
                {
                    if (item.AssetColumn == int.Parse(digit3))
                    {
                        idAssetPosition = item.AssetPositionId;
                        break;
                    }
                }
            }
            int unitId = int.Parse((string)Session["UnitFind"]);
            int assetId = (int)Session["AssetId"];
            UnitAsset unitAsset = new BcUnitAsset().GetUnitAssetByAssetPositionIdAndUnitId(idAssetPosition, unitId);
            if (unitAsset.UnassignedDate != null)
            {
                new BcUnitAsset().ChangeAssetPositionId(assetId, idAssetPosition);
                Session["AssetId"] = null;
                Session["TyreTagPosition2"] = null;
                Session["TyreTagPosition"] = null;
                Session["isChange"] = null;
                Session["IsReplace"] = null;
                mpeConffirmInspectionChange.Hide();
                List<Button> list = (List<Button>)Session["ListButtons"];
                string buttonId2 = (string)Session["TyreTagPosition"];
                Session["FinishInspectionChangeSameUnit"] = 1;
                foreach (Button item in list)
                {
                    if (item.ID == buttonId)
                    {
                        item.CssClass = "imgInspectionSuccessful";
                        item.Enabled = false;
                    }
                    else if (item.CssClass != "imgInspectionSuccessful" && item.CssClass != "imgWrongRequest")
                    {
                        item.Enabled = true;
                        item.CssClass = "imgHidden";
                    }
                }
                Session["ListButtonsChanged"] = list;
                Response.Redirect("SelectionTyrePage.aspx");
            }
            else
            {
                mpeHasTyreOk.Show();
            }
        }

        protected void btnNoInspectionChange_Click(object sender, EventArgs e)
        {
            mpeConffirmInspectionChange.Hide();
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            string buttonId = (string)Session["TyreTagPosition2"];
            foreach (Button item in listButtons)
            {
                if (item.ID == buttonId)
                {
                    item.CssClass = "imgHidden";
                    item.Enabled = true;
                }
                if (item.CssClass == "imgHidden" && item.Enabled == false)
                {
                    item.Enabled = true;
                }
            }
            ChargeButtons();
        }

        protected void btnOkW_Click(object sender, EventArgs e)
        {
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            string buttonId = (string)Session["TyreTagPosition2"];
            foreach (Button item in listButtons)
            {
                if (item.ID == buttonId)
                {
                    item.CssClass = "imgHidden";
                    item.Enabled = true;
                }
            }
            Session["ListButtons"] = listButtons;
            ChargeButtons();
            mpeHasTyreOk.Hide();
        }

        private void SaveChageTyreEvent()
        {

            AssetEvent assetEvent = new AssetEvent();

        }
    }
}