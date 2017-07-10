using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using amis._DataLayer.GeneratedCode;
using amis.Models;
using Infragistics.Web.UI.GridControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class SelectionTyrePage : System.Web.UI.Page
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
                if (Session["FromError"] == null)
                {
                    PositionTyres();
                }               
            }
            if (Session["ListButtons"] != null)
            {
                Session["ListButtons"] = Session["ListButtons"];
            }
            if (Session["ListButtonsToSend"] != null)
            {
                Session["ListButtons"] = Session["ListButtonsToSend"];
                Session["ListButtonsToSend"] = null;
            }
            if (Session["ListButtonsToChangePosition"] != null)
            {
                Session["ListButtons"] = Session["ListButtonsToChangePosition"];
                Session["ListButtonsToChangePosition"] = null;
            }
            if (Session["ListButtonsToScrap"] != null)
            {
                Session["ListButtons"] = Session["ListButtonsToScrap"];
                Session["ListButtonsToScrap"] = null;
            }
            ///Desde cambio en la misma unidad
            if (Session["ListButtonsChanged"] != null)
            {
                Session["ListButtons"] = Session["ListButtonsChanged"];
                Session["ListButtonsChanged"] = null;
            }
            if (Session["FinishInspectionChangeSameUnit"] != null)
            {
                Session["FinishInspectionChangeSameUnit"] = null;
                mpeAnotherInspection.Show();
            }
            ///
            ///Desde cambio en otra unidad
            ///
            if (Session["ListButtonsFromChangeAnotherUnit"] != null)
            {
                Session["ListButtons"] = Session["ListButtonsFromChangeAnotherUnit"];
                Session["ListButtonsFromChangeAnotherUnit"] = null;
            }
            if (Session["FinishChange"] != null)
            {
                mpeAnotherInspection1.Show();
                Session["FinishChange"] = null;
            }
            ///
            //Desde cambio a bodega
            if (Session["ChangeToWarehouse"] != null)
            {
                if (Session["ListButtonsFromChangeAnotherWarehouse"] != null)
                {
                    Session["ListButtons"] = Session["ListButtonsFromChangeAnotherWarehouse"];
                }
                Session["ChangeToWarehouse"] = null;
                Session["ListButtonsFromChangeAnotherWarehouse"] = null;
                mpeOkWarehouse.Show();
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
                    }else {
                        buttonId = buttonId + item2.AssetColumn.ToString();
                    }
                    Button btn =  (Button)imgTable.FindControl(buttonId);
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
            Session["assetPositionId"] = null;
            Session["SelectedType"] = null;
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
            if (ExistTyre(btn.ID))
            {
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
                            btnReadTag.Enabled = true;
                            txtTyreTag.Visible = true;
                            Session["TyreTagPosition"] = btn.ID;
                            listButtons.Where(r => r.ID == btn.ID).First().CssClass = btn.CssClass;
                            listButtons.Where(r => r.ID == btn.ID).First().Enabled = false;
                        }
                    }
                    else
                    {

                    }
                    Session["ListButtons"] = listButtons;
                }
                if ((string)Session["isChange"] == "Y")
                {
                    if (btn.CssClass == "imgHidden")
                    {
                        btn.CssClass = "imgInProgress";
                        btnReadTag.Enabled = true;
                        txtTyreTag.Visible = true;
                        Session["TyreTagPosition2"] = btn.ID;
                        listButtons.Where(r => r.ID == btn.ID).First().CssClass = btn.CssClass;
                        listButtons.Where(r => r.ID == btn.ID).First().Enabled = false;
                    }
                }
                ChargeButtons();
                btnReadRfiTag.Disabled = false;
                BtnCantReadTyreTag.Enabled = true;
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
                    mpeAnyObservation.Show();
                }
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
               
                Session["CheckingType"] = "Neumático";
                Session["ListButtons"] = listButtons;
                btnReadTag.Enabled = false;
                txtTyreTag.Visible = false;
                Session["ErrorNumber"] = errorNumber;
                Session["TyreTagPosition"] = null;
                Session["Tag"] = txtTyreTag.Text;
                Session["Type"] = "Neumático";
                Session["ToBackPage"] = "SelectionTyrePage.aspx";
                Session["SendEmail"] = null;
                Session["FromError"] = 1;
                Session["SelectedType"] = "Neumático";
                Response.Redirect("ErrorAndroidPage.aspx", false);
            }
        }

        protected void btnReadTag_Click(object sender, EventArgs e)
        {
            readTyreTag();
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
                Session["TyreTagPosition2"] = null;
                Session["TyreTagPosition"] = null;
                Session["isChange"] = null;
                Response.Redirect("SelectionTyrePage.aspx", false);
            }
            else
            {
                Page.ShowSmallPopupMessage("Antes de cambiar un neumático a esta posición debe remover el que se encuentra ubicado en ésta.");
            }
        }

        protected void btnFinishInspection_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            int counter = 0;
            foreach (Button item in listButtons)
            {
                if (item.CssClass == "imgInspectionSuccessful" || item.CssClass == "imgWrongRequest")
                {
                    counter = counter + 1;
                }
            }
            int idUnitRegister = (int)Session["UnitRegisterFind"];
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(idUnitRegister, out errorMessage);
            Unit unit = new BcUnit().GetUnitByUnitRegisterId(idUnitRegister);

            if (counter < new BcUnitAsset().TyresCounter(unit.UnitId))
            {
                mpeIncompleteInspection.Show();
            }else
            {
                mpeOtherInspection.Show();
            }
        }        

        protected void btnAnyObservationYes_Click(object sender, EventArgs e)
        {
            Response.Redirect("AnyObservationPage.aspx", false);
        }

        protected void btnAnyObservationNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("MeassurementTyrePage.aspx", false);
        }

        protected void SendMailIncompleteInspection()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int idUnitRegister = (int)Session["UnitRegisterFind"];
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(idUnitRegister, out errorMessage);

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "En el proceso de inspección de la unidad " +
                            unitRegister.InternalNumber + "; Patente: " + unitRegister.PatentNumber + " se ha dado término a esta sin finalizar " +
                            "la totalidad de la rutina."+ "<br>" + "<br>" +
                            "Se sugiere revisar lo antes posible la situación." + "<br>" + "<br>" +
                            "Para mayores antecedentes comuníquese con:" + "<br>" + "<br>" +
                            "ID del usuario: " + user.Name + "<br>" +
                            "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
                            "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
                            "Que tenga un buen día";



            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 3;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = null;
        }

        protected void btnYesFinishIncomplete_Click(object sender, EventArgs e)
        {
            SendMailIncompleteInspection();
            mpeOtherInspection.Show();
        }

        protected void btnNoFinishIncomplete_Click(object sender, EventArgs e)
        {
            mpeIncompleteInspection.Hide();
        }

        protected void btnOtherYes_Click(object sender, EventArgs e)
        {
            mpeUnit.Show();
        }

        protected void btnOtherNo_Click(object sender, EventArgs e)
        {
            Session["assetPositionId"] = null;
            Session["FinishChange"] = null;
            Session["TyreTagPosition2"] = null;
            Session["TyreTagPosition"] = null;
            Session["ErrorNumber"] = null;
            Session["AssetId"] = null;
            Session["Tag"] = null;
            Session["Type"] = null;
            Session["ToBackPage"] = null;
            Session["SendEmail"] = null;
            Session["EventAssetTypeId"] = null;
            Session["UnitFind"] = null;
            Session["FinishChange"] = null;
            Session["Patent"] = null;
            Session["InternalNumber"] = null;
            Session["ListButtons"] = null;
            Session["ListButtonsToSend"] = null;
            Session["ListButtonsToScrap"] = null;
            Session["ToScrap"] = null;
            Session["dllAssetType"] = null;
            Session["UnitRegister"] = null;
            Session["UnitRegisterFind"] = null;
            Session["Contador"] = null;
            Session["ErrorNumber"] = null;
            Session["AssetVehicule"] = null;
            Session["FromError"] = null;
            Response.Redirect("MenuAndroidPage.aspx", false);
        }

        protected void btnSameUnitNo_Click(object sender, EventArgs e)
        {
            Session["assetPositionId"] = null;
            Session["FinishChange"] = null;
            Session["TyreTagPosition2"] = null;
            Session["TyreTagPosition"] = null;
            Session["ErrorNumber"] = null;
            Session["AssetId"] = null;
            Session["Tag"] = null;
            Session["Type"] = null;
            Session["ToBackPage"] = null;
            Session["SendEmail"] = null;
            Session["EventAssetTypeId"] = null;
            Session["UnitFind"] = null;
            Session["FinishChange"] = null;
            Session["Patent"] = null;
            Session["InternalNumber"] = null;
            Session["ListButtons"] = null;
            Session["ListButtonsToSend"] = null;
            Session["ListButtonsToScrap"] = null;
            Session["ToScrap"] = null;
            Session["dllAssetType"] = null;
            Session["UnitRegister"] = null;
            Session["UnitRegisterFind"] = null;
            Session["Contador"] = null;
            Session["ErrorNumber"] = null;
            Session["FromError"] = null;
            Session["AssetVehicule"] = null;
            Response.Redirect("InspectionIndexAndroidPage.aspx", false);
        }

        protected void btnSameUnitYes_Click(object sender, EventArgs e)
        {
            Session["assetPositionId"] = null;
            Session["FinishChange"] = null;
            Session["TyreTagPosition2"] = null;
            Session["TyreTagPosition"] = null;
            Session["ErrorNumber"] = null;
            Session["AssetId"] = null;
            Session["Tag"] = null;
            Session["Type"] = null;
            Session["ToBackPage"] = null;
            Session["SendEmail"] = null;
            Session["EventAssetTypeId"] = null;
            Session["UnitFind"] = null;
            Session["FinishChange"] = null;
            Session["ListButtons"] = null;
            Session["ListButtonsToSend"] = null;
            Session["ListButtonsToScrap"] = null;
            Session["ToScrap"] = null;
            Session["dllAssetType"] = null;
            Session["Contador"] = null;
            Session["ErrorNumber"] = null;
            Session["AssetVehicule"] = null;
            Session["FromError"] = null;
            Response.Redirect("InspectionIndexAndroidPage.aspx", false);
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            mpeAnotherInspection.Hide();
            ChargeButtons();
        }

        protected void btnOkW_Click(object sender, EventArgs e)
        {
            mpeOkWarehouse.Hide();
            ChargeButtons();
        }

        protected void btnOk2_Click(object sender, EventArgs e)
        {
            mpeAnotherInspection1.Hide();
            ChargeButtons();
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

        protected void btnErrorTagOk_Click(object sender, EventArgs e)
        {
            mpeErrorTag.Hide();
            btnReadRfiTag.Disabled = false;
            List<Button> listTagError = (List<Button>)Session["ListButtons"];
            string buttonId = (string)Session["TyreTagPosition"];
            foreach (Button item in listTagError)
            {
                if (item.ID == buttonId)
                {
                    item.CssClass = "imgHidden";
                    item.Enabled = true;
                }
                else if (item.CssClass != "imgWrongRequest" || item.CssClass != "imgInspectionSuccessful")
                {
                    item.CssClass = "imgHidden";
                    item.Enabled = true;
                }
            }
            Session["ListButtons"] = listTagError;
            ChargeButtons();
        }

        protected void btnTagError_Click(object sender, EventArgs e)
        {
            mpeErrorTag.Show();
        }

        protected void BtnCantReadTyreTag_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById((int)Session["UnitRegisterFind"], out errorMessage);
            int unitId = new BcUnit().GetUnitByUnitRegisterId(unitRegister.UnitRegisterId).UnitId;
            //
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
            int assetId = new BcUnitAsset().GetAssetIdByUnitIdAndPositionId(unitId, idAssetPosition);
            Tag tag = new BcTag().GetTagByAssetId(assetId);
            Session["AssetId"] = assetId;
            Session["TagAsset"] = tag.TagCode;
            SendEmailCantReadTag();
            mpeAnyObservation.Show();
            //
        }

        protected void SendEmailCantReadTag()
        {
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            string tipo = (string)Session["Type"];
            string detectedPressure = (string)Session["PressureMeassure1"];
            int assetId = (int)Session["AssetId"];
            UnitAsset unitAsset = new BcUnitAsset().GetUnitAssetByAssetId(assetId, out errorMessage);
            int? assetPositionId = 0;
            if (unitAsset.AssetPositionId != null)
            {
                assetPositionId = unitAsset.AssetPositionId;
            }
            AssetPosition astPosition = new BcAssetPosition().GetAssetPositionById(assetPositionId.Value);

            string tyrePosition = astPosition.PositionDescription;
            Asset ast = new BcAsset().GetAssetById(assetId, out errorMessage);
            AssetUniqueIdentification astUni = new BcAssetUniqueIdentification().GetAssetUniqueIdentificationById(ast.AssetUniqueIdentificationId);
            PressureSetting pressure = new BcPressureSetting().GetPressureSettingByAssetModelId(astUni.AssetModelId);
            decimal pressureConf = Math.Round(pressure.Pressure);

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "En la inspección de la unidad " +
                "con n° interno " + unit.InternalNumber + " Patente " + unit.PatentNumber + "." + "<br>" +
                "Se ha informado que el tag del neumático en la posición " + tyrePosition + "<br>" +
                " no ha podido ser leído, sin embargo el proceso de medición siguio en curso." + "<br>" +
                "Se sugiere revisar el problema del tag para llevar un correcto control del neumático." +
                "<br>" + "<br>" + "\n" +
                "Para mayores antecedentes comuníquese con:" + "<br>" + "\n" +
                "ID del usuario: " + user.Name + "<br>" +
                "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
                "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" + "<br>" +
                "Que tenga un buen día";

            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 6;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();
            Session["PressureMeassure1"] = null;
            Session["SendEmail"] = 1;
        }

        private void SendEmail(object o, DoWorkEventArgs e)
        {
            List<string> emails = (List<string>)Session["emailList"];
            string message = (string)Session["message"];
            foreach (var item in emails)
            {
                new BcErrorAndroid().SendMailAsync(item, message);
            }
        }
    }
}