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
    public partial class InventoryTyreAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errorMessage = "";
            string idUnitRegister = (string)Session["UnitRegisterFind"];
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(int.Parse(idUnitRegister), out errorMessage);
            Session["UnitFind"] = new BcUnit().GetUnitByUnitRegisterId(int.Parse(idUnitRegister)).UnitId.ToString();
            lblPatent.Text = (string)Session["Patent"];
            lblInternalNumber.Text = (string)Session["InternalNumber"];
            Session["EventAssetTypeId"] = 1;
            if (!IsPostBack)
            {
                InitializeControls();
                if(Session["isCorrect"] == null)
                {
                    Session["isCorrect"] = null;
                    PositionTyres();
                }              
            }
            if (Session["ListButtonsToSend"] != null)
            {
                Session["ListButtons"] = (List<Button>)Session["ListButtonsToSend"];
            }
            if (Session["ListButtonsToChangePosition"] != null)
            {
                Session["ListButtons"] = (List<Button>)Session["ListButtonsToChangePosition"];
            }
            if (Session["ListButtonsToScrap"] != null)
            {
                Session["ListButtons"] = (List<Button>)Session["ListButtonsToScrap"];
            }

            if (Session["FinishChange"] != null)
            {
                Page.ShowSmallPopupMessage("Se ha realizado el cambio correctamente.");
                Session["FinishChange"] = null;
            }
            ChargeButtons();
            Session["ToScrap"] = null;
            
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
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(int.Parse((string)Session["UnitRegisterFind"]), out errorMessage);
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
            Session["TyreTagPosition"] = null;
            string change = "";
            if (Session["isChange"] != null)
            {
                change = (string)Session["isChange"];
            }
            Button btn = (Button)sender;
            if (btn.CssClass != "imgWrongRequest" || btn.CssClass != "imgInspectionSuccessful")
            {
                foreach (Button item in listButtons)
                {
                    if (item.ID != btn.ID)
                    {
                        if (change != "Y")
                        {
                            item.Enabled = false;
                        }
                    }
                }
                if (change != "Y")
                {
                    if (btn.CssClass == "imgHidden")
                    {
                        btn.CssClass = "imgInProgress";
                        Session["TyreTagPosition"] = btn.ID;
                        listButtons.Where(r => r.ID == btn.ID).First().CssClass = btn.CssClass;
                        listButtons.Where(r => r.ID == btn.ID).First().Enabled = false;
                    }
                }

                Session["ListButtons"] = listButtons;
            }
            if ((string)Session["isChange"] == "Y")
            {
                if (btn.CssClass == "imgHidden")
                {
                    btn.CssClass = "imgInProgress";
                    Session["TyreTagPosition2"] = btn.ID;
                    listButtons.Where(r => r.ID == btn.ID).First().CssClass = btn.CssClass;
                    listButtons.Where(r => r.ID == btn.ID).First().Enabled = false;
                }
            }
            ChargeButtons();
        }

        public void readTyreTag()
        {
            string errorMessage = "";
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            int errorNumber = 0;
            List<ConfigurationAxleUnitType> confList = (List<ConfigurationAxleUnitType>)Session["ListConfigAxleUnitType"];
            string buttonId = (string)Session["TyreTagPosition"];
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
            bool isOk = new BcUnitRegister().IsTagCorrect(idAssetPosition, txtTyreTag.Text, int.Parse((string)Session["UnitFind"]), out errorNumber);
            if (isOk)
            {
                Tag tagRead = new BcTag().GetTagByCodeTag(txtTyreTag.Text, out errorMessage);
                TagAssigned assigned = new DcInspectionAndroid().SearchAssigned(tagRead.TagId);
                Tag tag = new BcTag().GetTagByCodeTag(txtTyreTag.Text, out errorMessage);
                TagAssigned tagAssigned = new BcTagAssigned().GetAssignedByTag(tag.TagId, out errorMessage);
                if (tagAssigned != null)
                {
                    Session["AssetId"] = tagAssigned.AssetId;
                    Session["TagAsset"] = txtTyreTag.Text;
                }
                foreach(Button item in listButtons)
                {
                    if(item.ID == buttonId)
                    {
                        item.CssClass = "imgInspectionSuccessful";
                        Asset newAsset = new BcAsset().GetAssetByTag(tag.TagCode, out errorMessage);
                        List<Asset> listado = (List<Asset>)Session["ListAssetTyreFind"];
                        listado.Add(newAsset);
                        Session["ListAssetTyreFind"] = listado;
                        item.Enabled = false;
                    }
                    item.Enabled = true;
                }
                Session["ListButtons"] = listButtons;
                
            }else
            {
                foreach (Button item in listButtons)
                {   
                    if(item.CssClass == "imgHidden" || item.CssClass == "imgInProgress")
                    {
                        item.CssClass = "imgHidden";
                        item.Enabled = true;
                    }
                }
            }
            Session["isCorrect"] = 1;
            Response.Redirect("InventoryTyreAndroidPage.aspx", false);
        }

        protected void btnReadTag_Click(object sender, EventArgs e)
        {
            readTyreTag();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("InventoryEndAndroidPage.aspx", false);
        }
    }
}