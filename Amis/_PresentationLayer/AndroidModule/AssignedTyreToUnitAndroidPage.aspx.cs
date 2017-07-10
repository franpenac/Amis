using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class AssignedTyreToUnitAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errorMessage = "";
            if (!IsPostBack)
            {
                InitializeControls();
                PositionTyres();
            }
            int unitRegisterId = (int)Session["UnitRegisterFind"];
            int unitId = (int)Session["UnitId"];
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(unitRegisterId, out errorMessage);
            lblPatentSelected.Text = unitRegister.PatentNumber;
            lblInternalNumberSelected.Text = unitRegister.InternalNumber;
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
            btnReadRfiTag.Disabled = true;
        }

        protected void PositionTyres()
        {
            List<Button> listButtons = new List<Button>();
            string errorMessage = "";
            int unitId = (int)Session["UnitId"];
            Unit unitInSession = new BcUnit().GetUnitById(unitId, out errorMessage);
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(unitInSession.UnitRegisterId, out errorMessage);
            ConfigurationUnitType unitConfig = new BcConfigurationUnitType().GetConfigurationUnitType(unitRegister.UnitTypeConfigurationId, out errorMessage);
            List<ConfigurationAxleUnitType> axleConf = new BcConfigurationAxleUnitType().GetConfigurationAxleUnitTypeByAxleConfigId(unitConfig.ConfigurationUnitTypeId);
            Session["ListConfigAxleUnitType"] = axleConf;
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

        protected void imgbtn_Click(object sender, EventArgs e)
        {
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            Session["TyreTagPosition"] = null;
            Button btn = (Button)sender;
            if (btn.CssClass != "imgWrongRequest" || btn.CssClass != "imgInspectionSuccessful")
            {
                foreach (Button item in listButtons)
                {
                    if (item.ID != btn.ID)
                    {
                            item.Enabled = false;
                    }
                }
                    if (btn.CssClass == "imgHidden")
                    {
                        btn.CssClass = "imgInProgress";
                        
                        Session["TyreTagPosition"] = btn.ID;
                        listButtons.Where(r => r.ID == btn.ID).First().CssClass = btn.CssClass;
                        listButtons.Where(r => r.ID == btn.ID).First().Enabled = false;
                    }
                Session["ListButtons"] = listButtons;
            }
                if (btn.CssClass == "imgHidden")
                {
                    btn.CssClass = "imgInProgress";
                    
                    Session["TyreTagPosition2"] = btn.ID;
                    listButtons.Where(r => r.ID == btn.ID).First().CssClass = btn.CssClass;
                    listButtons.Where(r => r.ID == btn.ID).First().Enabled = false;
                }
            btnReadRfiTag.Disabled = false;
            ChargeButtons();
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

        protected void btnReadTag_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            int unitId = (int)Session["UnitId"];
            int CodeAction = 0;
            if(new BcAssignedAssetToUnit().ValidateReadAssetTyre(txtTyreTag.Text,unitId, out CodeAction))
            {
                Asset asset = new BcInspectionAndroid().SearchAssetByTag(txtTyreTag.Text);

                Session["AssetIdToAssign"] = asset.AssetId;

                AssetUniqueIdentification assetUniqueIdentification = new BcAssetUniqueIdentification().GetAssetUniqueIdentificationById(asset.AssetUniqueIdentificationId);
                DepthSetting depthSetting = new BcDepthSetting().GetDepthSettingByAssetModelId(assetUniqueIdentification.AssetModelId, out errorMessage);
                PressureSetting pressureSetting = new BcPressureSetting().GetPressureSettingByAssetModelId(assetUniqueIdentification.AssetModelId);

                if (pressureSetting != null)
                {
                    if (depthSetting != null)
                    {
                        btnAssign_Click(sender, e);
                        if (Session["GoodAssigned"] != null)
                        {
                            Session["GoodAssigned"] = null;
                            mpeAnotherAssign.Show();
                        }
                    }
                    else
                    {
                        mpeNotDepthSetting.Show();
                        List<Button> listButtons = (List<Button>)Session["ListButtons"];
                        string buttonId = (string)Session["TyreTagPosition"];
                        foreach (Button item in listButtons)
                        {
                            if (item.ID == buttonId)
                            {
                                item.CssClass = "imgHidden";
                                item.Enabled = true;
                            }
                            if (item.CssClass == "imgHidden")
                            {
                                item.Enabled = true;
                            }
                        }
                        Session["ListButtons"] = listButtons;
                        ChargeButtons();
                    }
                }else
                {
                    mpeNotPressureSetting.Show();
                    List<Button> listButtons = (List<Button>)Session["ListButtons"];
                    string buttonId = (string)Session["TyreTagPosition"];
                    foreach (Button item in listButtons)
                    {
                        if (item.ID == buttonId)
                        {
                            item.CssClass = "imgHidden";
                            item.Enabled = true;
                        }
                        if (item.CssClass == "imgHidden")
                        {
                            item.Enabled = true;
                        }
                    }
                    Session["ListButtons"] = listButtons;
                    ChargeButtons();
                }
            }
            else
            {
                if (CodeAction == 16)
                {
                    Page.ShowSmallPopupMessage("El activo ya ha sido asignado a esta unidad.");
                    List<Button> listButtons = (List<Button>)Session["ListButtons"];
                    string buttonId = (string)Session["TyreTagPosition"];
                    foreach (Button item in listButtons)
                    {
                        if (item.ID  == buttonId)
                        {
                            item.CssClass = "imgHidden";
                            item.Enabled = true;
                        }
                        if (item.CssClass == "imgHidden")
                        {
                            item.Enabled = true;
                        }
                    }
                    Session["ListButtons"] = listButtons;
                    ChargeButtons();
                }
                else
                {
                    Session["ErrorNumber"] = CodeAction;
                    Session["TagCode"] = txtTyreTag.Text;
                    Session["ErrorAssigned"] = 1;
                    Session["SendEmail"] = null;
                    Response.Redirect("ErrorAndroidPage.aspx");
                }
            }          
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            string position = (string)Session["TyreTagPosition"];
            List<ConfigurationAxleUnitType> confList = (List<ConfigurationAxleUnitType>)Session["ListConfigAxleUnitType"];
            string buttonId = position;
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
            int unitId = (int)Session["UnitId"];
            int assetId = (int)Session["AssetIdToAssign"];
            UnitAsset unitAsset = new BcUnitAsset().GetUnitAssetByAssetPositionIdAndUnitId(idAssetPosition, unitId);
            if (unitAsset == null)
            {
                string errorMessage = "";
                UnitAsset newUnitAsset = new UnitAsset();
                newUnitAsset.UnitAssetId = 0;
                newUnitAsset.AssetId = assetId;
                newUnitAsset.UnitId = unitId;
                newUnitAsset.AssetPositionId = idAssetPosition;
                newUnitAsset.AssignedDate = DateTime.Now;
                newUnitAsset.UnassignedDate = null;
                new BcUnitAsset().Save(newUnitAsset, out errorMessage);

                List<Button> listB = (List<Button>)Session["ListButtons"];
                foreach (Button item in listB)
                {
                    if (item.ID == buttonId)
                    {
                        item.CssClass = "imgInspectionSuccessful";
                    }
                    if (item.CssClass == "imgInProgress")
                    {
                        item.CssClass = "imgHidden";
                        item.Enabled = true;
                    }
                }
                Session["ListButtons"] = listB;
                ChargeButtons();
                Session["FinishChange"] = 1;
                Session["AssetId"] = null;
                Session["TyreTagPosition"] = null;
                Session["isChange"] = null;
                Session["GoodAssigned"] = 1;
            }
            else
            {
                Page.ShowSmallPopupMessage("Esta posición ya posee un neumático asignado.");
            }
        }

        protected void btnYesAnotherAssign_Click(object sender, EventArgs e)
        {
            mpeSameUnit.Show();
            mpeAnotherAssign.Hide();
        }

        protected void btnNoAnotherAssign_Click(object sender, EventArgs e)
        {
            Session["UnitRegisterFind"] = null;
            Session["UnitId"] = null;
            Session["ListConfigAxleUnitType"] = null;
            Session["ListButtons"] = null;
            Session["TyreTagPosition"] = null;
            Session["AssetIdToAssign"] = null;
            Session["GoodAssigned"] = null;
            Session["ErrorNumber"] = null;
            Response.Redirect("MenuAndroidPage.aspx");
        }

        protected void btnNoSameUnit_Click(object sender, EventArgs e)
        {
            Session["UnitRegisterFind"] = null;
            Session["UnitId"] = null;
            Session["ListConfigAxleUnitType"] = null;
            Session["ListButtons"] = null;
            Session["TyreTagPosition"] = null;
            Session["AssetIdToAssign"] = null;
            Session["GoodAssigned"] = null;
            Session["ErrorNumber"] = null;
            Response.Redirect("AssignedAssetToUnitAndroidPage.aspx");
        }

        protected void btnYesSameUnit_Click(object sender, EventArgs e)
        {
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            string buttonId = (string)Session["TyreTagPosition"];
            foreach (Button item in listButtons)
            {
                if (item.ID != buttonId && item.CssClass == "imgHidden")
                {
                    item.Enabled = true;
                }else
                {
                    item.Enabled = false;
                }
            }
            Session["ListButtons"] = listButtons;
            ChargeButtons();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["NothingAction"] = null;
            Session["AssetTypeName"] = null;
            Session["TagCode"] = null;
            Session["Contador"] = null;
            Session["UnitId"] = null;
            Session["ErrorNumber"] = null;

            Response.Redirect("AssignedAssetToUnitAndroidPage.aspx", false);
        }

        protected void btnNotPressureSettingOk_Click(object sender, EventArgs e)
        {
            mpeNotPressureSetting.Hide();
        }

        protected void btnNotDepthSettingOk_Click(object sender, EventArgs e)
        {
            mpeNotDepthSetting.Hide();
        }
    }
}