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
    public partial class SelectionAnotherUnitTyrePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errorMessage = "";
            string idUnitRegister = (string)Session["UnitRegisterFind2"];
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(int.Parse(idUnitRegister), out errorMessage);
            Session["UnitFind2"] = new BcUnit().GetUnitByUnitRegisterId(int.Parse(idUnitRegister)).UnitId.ToString();
            lblPatentSelected.Text = (string)Session["Patent2"];
            lblInternalNumberSelected.Text = (string)Session["InternalNumber2"];
            if (!IsPostBack)
            {
                InitializeControls();
                PositionTyres();
            }
        }

        protected void InitializeControls()
        {
            string errorMessage = "";
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(int.Parse((string)Session["UnitRegisterFind2"]), out errorMessage);
            int unitId = new BcUnit().GetUnitByUnitRegisterId(unitRegister.UnitRegisterId).UnitId;
            Unit unitInSession = new BcUnit().GetUnitById(unitId, out errorMessage);
            ConfigurationUnitType unitConfig = new BcConfigurationUnitType().GetConfigurationUnitType(unitRegister.UnitTypeConfigurationId, out errorMessage);
            string imgPath = unitConfig.Path;
            imgPath = imgPath.Replace("~", "");
            imgTable.Style["background-image"] = "url('" + imgPath + "')";
        }

        protected void PositionTyres()
        {
            List<Button> listButtons = new List<Button>();
            string errorMessage = "";
            int unitId = int.Parse((string)Session["UnitFind2"]);
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
                Session["ListButtons2"] = listButtons;
            }
        }

        protected void imgbtn_Click(object sender, EventArgs e)
        {
            List<Button> listButtons = (List<Button>)Session["ListButtons2"];
            Session["TyreTagPosition2"] = null;
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
                        Session["TyreTagPosition2"] = btn.ID;
                        listButtons.Where(r => r.ID == btn.ID).First().CssClass = btn.CssClass;
                        listButtons.Where(r => r.ID == btn.ID).First().Enabled = false;
                    }
                mpeConfirmar.Show();
                Session["ListButtons2"] = listButtons;
            }
        }

        protected void ChargeButtons()
        {
            List<Button> listButtons = (List<Button>)Session["ListButtons2"];
            foreach (Button item in listButtons)
            {
                Button btn = (Button)imgTable.FindControl(item.ID);
                btn.CssClass = item.CssClass;
                btn.Enabled = item.Enabled;
            }
        }

        protected void btnConffirmTyreAsset_Click(object sender, EventArgs e)
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
            int unitId = int.Parse((string)Session["UnitFind2"]);
            int assetId = (int)Session["AssetId"];
            UnitAsset unitAsset = new BcUnitAsset().GetUnitAssetByAssetPositionIdAndUnitId(idAssetPosition, unitId);
            if (unitAsset == null)
            {
                new BcUnitAsset().ChangeUnitToAsset(unitId, assetId);
                new BcUnitAsset().ChangeAssetPositionId(assetId, idAssetPosition);
                List<Button> listB = (List<Button>)Session["ListButtons"];
                string buttonId2 = (string)Session["TyreTagPosition"];
                foreach (Button item in listB)
                {
                    if (item.ID == buttonId2)
                    {
                        item.CssClass = "imgInspectionSuccessful";
                        item.Enabled = false;
                    }
                    else if (item.CssClass != "imgInspectionSuccessful" && item.CssClass != "imgWrongRequest")
                    {
                        item.CssClass = "imgHidden";
                        item.Enabled = true;
                    }
                }
                Session["ListButtonsFromChangeAnotherUnit"] = listB;
                Session["FinishChange"] = 1;
                Session["AssetId"] = null;
                Session["TyreTagPosition3"] = null;
                Session["TyreTagPosition2"] = null;
                Session["isChange"] = null;
                Session["internalNumber2"] = null;
                Session["Patent2"] = null;
                Session["Contador2"] = null;
                Response.Redirect("SelectionTyrePage.aspx");
            }
            else
            {
                Page.ShowSmallPopupMessage("Antes de cambiar un neumático a esta posición debe remover el que se encuentra ubicado en ésta.");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            List<Button> list = (List<Button>)Session["ListButtons2"];
            string buttonId = (string)Session["TyreTagPosition2"];
            foreach (Button item in list)
            {
                if (item.ID == buttonId)
                {
                    item.CssClass = "imgHidden";
                    item.Enabled = true;
                    break;
                }
                else
                {
                    item.Enabled = true;
                }
            }
            Session["ListButtons2"] = list;
            Session["TyreTagPosition2"] = null;
            ChargeButtons();
            mpeConfirmar.Hide();
        }

        protected void btnOkW_Click(object sender, EventArgs e)
        {

        }
    }
}