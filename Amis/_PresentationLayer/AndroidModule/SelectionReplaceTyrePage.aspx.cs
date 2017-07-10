using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using amis._DataLayer.GeneratedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class SelectionReplaceTyrePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errorMessage = "";
            int idUnitRegister = (int)Session["UnitRegisterFind"];
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(idUnitRegister, out errorMessage);
            Session["UnitFind"] = new BcUnit().GetUnitByUnitRegisterId(idUnitRegister).UnitId.ToString();
            lblPatentSelected.Text = (string)Session["Patent"];
            lblInternalNumberSelected.Text = (string)Session["InternalNumber"];
            lblPatentSelected.Visible = true;
            lblInternalNumberSelected.Visible = true;
            if (!IsPostBack)
            {
                InitializeControls();
                PositionTyres();              
            }
            if (Session["FinishChange"] != null)
            {
                Session["FinishChange"] = null;
                mpeAnotherReplace.Show();
            }
            ChargeButtons();
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
            Session["assetPositionId"] = null;
            Session["SelectedType"] = null;
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
            }
            Session["ListButtons"] = listButtons;
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

        protected void imgbtn_Click(object sender, EventArgs e)
        {
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            Session["TyreTagReplacePosition"] = null;
            Button btn = (Button)sender;
            if (ExistTyre(btn.ID))
            {
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
                        txtTyreTag.Visible = true;
                        Session["TyreTagReplacePosition"] = btn.ID;
                        listButtons.Where(r => r.ID == btn.ID).First().CssClass = btn.CssClass;
                        listButtons.Where(r => r.ID == btn.ID).First().Enabled = false;
                        btnReadRfiTag.Disabled = false;
                    }
                    if (Session["IsReplace"] != null)
                    {
                        btn.CssClass = "imgInProgress";
                        txtTyreTag.Visible = true;
                        Session["TyreTagReplacePosition2"] = btn.ID;
                        listButtons.Where(r => r.ID == btn.ID).First().CssClass = btn.CssClass;
                        listButtons.Where(r => r.ID == btn.ID).First().Enabled = false;
                        txtTyreTag.Visible = false;
                        mpeConfirmar.Show();
                    }
                    Session["ListButtons"] = listButtons;
                }
                if (btn.CssClass == "imgHidden")
                {
                    btn.CssClass = "imgInProgress";
                    txtTyreTag.Visible = true;
                    Session["TyreTagReplacePosition"] = btn.ID;
                    listButtons.Where(r => r.ID == btn.ID).First().CssClass = btn.CssClass;
                    listButtons.Where(r => r.ID == btn.ID).First().Enabled = false;
                }
                ChargeButtons();
            }else
            {
                Session["TyreTagPosition"] = null;
                mpeNoTyre.Show();
            }           
        }

        public void readTyreTag()
        {
            string errorMessage = "";
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            int errorNumber = 0;
            List<ConfigurationAxleUnitType> confList = (List<ConfigurationAxleUnitType>)Session["ListConfigAxleUnitType"];
            string buttonId = (string)Session["TyreTagReplacePosition"];
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
            Session["assetPositionId"] = idAssetPosition;
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
                Session["IsReplace"] = 1;
                Response.Redirect("MeassurementTyreToReplacePage.aspx");
            }
            else
            {
                listButtons.Where(r => r.ID == buttonId).FirstOrDefault().CssClass = "imgHidden";
                foreach (Button item in listButtons)
                {
                    if (item.CssClass == "imgHidden" && item.Enabled == false)
                    {
                        item.Enabled = true;
                    }
                }
                Tag wrongTag = new BcTag().GetTagByCodeTag(txtTyreTag.Text, out errorMessage);
                if (wrongTag != null)
                {
                    TagAssigned tagAssigned = new BcTagAssigned().GetAssignedByTag(wrongTag.TagId, out errorMessage);
                    int assetId = tagAssigned.AssetId;
                    Session["AssetId"] = assetId;
                }
                Session["ListButtons"] = listButtons;
                Session["ErrorNumber"] = errorNumber;
                Session["ListButtonsToReplace"] = null;
                Session["Tag"] = txtTyreTag.Text;
                Session["Type"] = "Neumático";
                Session["SendEmail"] = null;
                Session["isFromReplace"] = 1;
                Response.Redirect("ErrorAndroidPage.aspx", false);
            }
        }

        protected void btnReadTyreTag_Click(object sender, EventArgs e)
        {
            readTyreTag();
        }

        protected void btnCantReadTag_Click(object sender, EventArgs e)
        {
            
            Session["ErrorNumber"] = 7;
            Session["SendEmail"] = null;
            Session["BadTyreTag"] = 1;
            Response.Redirect("ErrorAndroidPage.aspx");
        }

        protected void btnConfirmarPoppup_Click(object sender, EventArgs e)
        {
            List<ConfigurationAxleUnitType> confList = (List<ConfigurationAxleUnitType>)Session["ListConfigAxleUnitType"];
            string buttonId = (string)Session["TyreTagReplacePosition2"];
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
                    if (item.CssClass == "imgHidden")
                    {
                        item.Enabled = true;
                    }
                }
                Session["ListButtons"] = listB;
                ChargeButtons();
                Session["AssetId"] = null;
                Session["TyreTagPosition2"] = null;
                Session["TyreTagPosition"] = null;
                Session["wasChange"] = 1;
                Session["IsReplace"] = null;
                mpeConfirmar.Hide();
                mpeAnotherReplace.Show();
            }
            else
            {
                Page.ShowSmallPopupMessage("Antes de cambiar un neumático a esta posición debe remover el que se encuentra ubicado en ésta.");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string buttonId = (string)Session["TyreTagReplacePosition2"];
            List<Button> listButtons = (List<Button>)Session["ListButtonsToReplace"];
            foreach (Button item in listButtons)
            {
                if (item.ID == buttonId)
                {
                    item.CssClass = "imgHidden";
                    item.Enabled = true;
                }
                else if (item.CssClass != "imgInProgress" || item.CssClass != "imgWrongRequest")
                {
                    item.Enabled = true;
                }
            }
            Session["ListButtons"] = listButtons;
            ChargeButtons();
        }

        protected void btnConffirmAnotherReplace_Click(object sender, EventArgs e)
        {
            Session["IsReplace"] = null;
            Session["ListButtons"] = null;
            Session["TyreTagReplacePosition"] = null;
            Session["TyreTagReplacePosition2"] = null;
            Session["AssetId"] = null;
            Session["Tag"] = null;
            Response.Redirect("SelectionReplaceTyrePage.aspx");
        }

        protected void btnNoAnotherReplace_Click(object sender, EventArgs e)
        {
            Session["UnitRegisterFind"] = null;
            Session["UnitFind"] = null;
            Session["Patent"] = null;
            Session["InternalNumber"] = null;
            Session["IsReplace"] = null;
            Session["ListConfigAxleUnitType"] = null;
            Session["ListButtons"] = null;
            Session["TyreTagReplacePosition"] = null;
            Session["TyreTagReplacePosition2"] = null;
            Session["AssetId"] = null;
            Session["TagAsset"] = null;
            Response.Redirect("MenuAndroidPage.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["UnitRegisterFind"] = null;
            Session["UnitFind"] = null;
            Session["UnitRegister"] = null;
            Session["Patent"] = null;
            Session["InternalNumber"] = null;
            Session["IsReplace"] = null;
            Session["ListConfigAxleUnitType"] = null;
            Session["ListButtons"] = null;
            Session["TyreTagReplacePosition"] = null;
            Session["TyreTagReplacePosition2"] = null;
            Session["AssetId"] = null;
            Session["TagAsset"] = null;
            Session["Contador"] = null;
            Session["IsUnit"] = null;
            Session["AssetVehicule"] = null;
            Response.Redirect("MenuAndroidPage.aspx");
        }

        protected bool ExistTyre(string TyrePosition)
        {
            string errorMessage = "";
            bool exist = false;
            int idUnitRegister = (int)Session["UnitRegisterFind"];
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(idUnitRegister, out errorMessage);
            int unitId = new BcUnit().GetUnitByUnitRegisterId(idUnitRegister).UnitId;
            List<UnitAsset> list = new BcUnitAsset().GetTyreList(unitId);

            List<ConfigurationAxleUnitType> confList = (List<ConfigurationAxleUnitType>)Session["ListConfigAxleUnitType"];
            string digit1 = TyrePosition.Substring(4, 1);
            string digit2 = TyrePosition.Substring(6, 1);
            string digit3 = TyrePosition.Substring(5, 2);
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
            foreach (UnitAsset item in list)
            {
                if (item.AssetPositionId == idAssetPosition)
                {
                    exist = true;
                    break;
                }
                else
                    exist = false;
            }
            return exist;
        }

        protected void btnNoTyreOk_Click(object sender, EventArgs e)
        {
            mpeNoTyre.Hide();
        }
    }
}