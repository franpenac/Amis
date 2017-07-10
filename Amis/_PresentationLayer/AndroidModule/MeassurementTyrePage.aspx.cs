using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using amis._DataLayer.GeneratedCode;
using amis.Models;
using Infragistics.Web.UI.GridControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class MeassurementTyrePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblPatentSelected.Text = (string)Session["Patent"];
            lblInternalNumberSelected.Text = (string)Session["InternalNumber"];
            if (!IsPostBack)
            {
                InitializeControls();
            }
            if (Session["DepthMeassure0"] != null)
            {
                txtMeassureDepth0.Text = ((string)Session["DepthMeassure0"]);
            }
            if (Session["DepthMeassure1"] != null)
            {
                txtMeassureDepth1.Text = ((string)Session["DepthMeassure1"]);
            }
            if (Session["DepthMeassure2"] != null)
            {
                txtMeassureDepth2.Text = ((string)Session["DepthMeassure2"]);
            }
            //if (Session["DepthMeassure3"] != null)
            //{
            //    txtMeassureDepth3.Text = ((string)Session["DepthMeassure3"]);
            //}
            //if (Session["DepthMeassure4"] != null)
            //{
            //    txtMeassureDepth4.Text = ((string)Session["DepthMeassure4"]);
            //}
            //if (Session["DepthMeassure5"] != null)
            //{
            //    txtMeassureDepth5.Text = ((string)Session["DepthMeassure5"]);
            //}
            //if (Session["DepthMeassure6"] != null)
            //{
            //    txtMeassureDepth6.Text = ((string)Session["DepthMeassure6"]);
            //}
            //if (Session["DepthMeassure7"] != null)
            //{
            //    txtMeassureDepth7.Text = ((string)Session["DepthMeassure7"]);
            //}
            //if (Session["DepthMeassure8"] != null)
            //{
            //    txtMeassureDepth8.Text = ((string)Session["DepthMeassure8"]);
            //}
            //if (Session["DepthMeassure9"] != null)
            //{
            //    txtMeassureDepth9.Text = ((string)Session["DepthMeassure9"]);
            //}
            if (Session["PressureMeassure1"] != null)
            {
                txtMeassurementPressure.Text = ((string)Session["PressureMeassure1"]);
            }
        }

        private void InitializeControls()
        {
            string errorMessage = "";
            lblPatentSelected.Text = (string)Session["Patent"];
            lblInternalNumberSelected.Text = (string)Session["InternalNumber"];
            Session["DepthMeassure0"] = null;
            Session["DepthMeassure1"] = null;
            Session["DepthMeassure2"] = null;
            //Session["DepthMeassure3"] = null;
            //Session["DepthMeassure4"] = null;
            //Session["DepthMeassure5"] = null;
            //Session["DepthMeassure6"] = null;
            //Session["DepthMeassure7"] = null;
            //Session["DepthMeassure8"] = null;
            //Session["DepthMeassure9"] = null;
            Session["PressureMeassure1"] = null;
            Session["PressureMeassurementList"] = null;
            Session["CountTimes"] = 0;
            //int assetId = (int)Session["AssetId"];
            //Asset asset = new BcAsset().GetAssetById(assetId, out errorMessage);
            //AssetUniqueIdentification assetUnique = new BcAssetUniqueIdentification().GetAssetUniqueIdentificationById(asset.AssetUniqueIdentificationId);
            //SettingTyre setting = new BcSettingTyre().GetSettingTyreByAssetModelId(assetUnique.AssetModelId);
            //txtDepthNumber.Text = setting.DepthNumber.ToString();
        }

        protected void btnCancelMeassureDepth_Click(object sender, EventArgs e)
        {
            mpeCancellDepthMeassurement.Show();
        }

        protected void btnCancelMeassurementPressure_Click(object sender, EventArgs e)
        {
            mpeCancelPressureMeassurement.Show();
        }

        protected void wibYesToScrap_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReasonRemoveAndroidPage.aspx", false);
        }

        protected void wibNotToScrap_Click(object sender, EventArgs e)
        {
            mpeToScrapt.Hide();
            Session["PressureMeassurementList"] = null;
            Session["CountTimes"] = null;
            Session["PressureMeassure1"] = null;
            txtMeassurementPressure.Text = "";
            countTimes.Text = "Oportunidad: " + 0 + " de 3.";           
    }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("RemoveTyreInspectionAndroidPage.aspx", false);
        }

        protected void btnDoPressureMethod_Click(object sender, EventArgs e)
        {
            List<decimal> PressureMeassureList = new List<decimal>();
            if (Session["PressureMeassurementList"] != null)
            {
                PressureMeassureList = (List<decimal>)Session["PressureMeassurementList"];
            }
            PressureMeassureList.Add(decimal.Parse(txtMeassurementPressure.Text, CultureInfo.InvariantCulture));
            Session["PressureMeassurementList"] = PressureMeassureList;
            if (Session["CountTimes"] == null)
            {
                Session["CountTimes"] = 0;
            }
            if (Session["CountTimesAutoinflate"] == null)
            {
                Session["CountTimesAutoinflate"] = 0;
            }
            string errorMessage = "";
            Asset asset = new BcAsset().GetAssetById((int)Session["AssetId"], out errorMessage);
            AssetUniqueIdentification assetUnique = new BcAssetUniqueIdentification().GetAssetUniqueIdentificationById(asset.AssetUniqueIdentificationId);
            PressureSetting pressure = new BcPressureSetting().GetPressureSettingByAssetModelId(assetUnique.AssetModelId);
            int count = 0;
            int countAutoinflate = 0;
            double pressureMed = double.Parse(txtMeassurementPressure.Text, CultureInfo.InvariantCulture);
            Session["PressureMeassure1"] = pressureMed.ToString();

            if (pressureMed < double.Parse(pressure.Pressure.ToString()) + 2 && pressureMed > double.Parse(pressure.Pressure.ToString()) - 2)
            {

                count = 5;
                Session["PressureMeassure1"] = txtMeassurementPressure.Text;
                if (Session["ToScrap"] != null)
                {
                    btnNext.Visible = true;
                    btnPressureMeassurement.Disabled = false;
                }
                else
                {
                    btnFinishMeassurement.Visible = true;
                    SavePressureMeassurement();
                    btnCancelMeassurementPressure.Enabled = false;
                    btnPressureMeassurement.Disabled = false;
                }
            }
            else
            {
                if (!ChkAutoInflate.Checked)
                {
                    count = 1 + (int)Session["CountTimes"];
                    txtMeassurementPressure.Text = "";
                    if (count < 4)
                    {
                        lblErrorPressureMeassurement.Text = "La presión medida es de "+ pressureMed +"PSI , y la presión correcta para el neumático que esta inspeccionando es de "+ pressure.Pressure +"PSI, por favor rectifique la presión y vuelva a medir.";
                        mpeErrorPressure.Show();
                        countTimes.Text = "Oportunidad: " + count + " de 3.";
                    }
                    Session["PressureMeassure1"] = null;
                }
                else
                {
                    countAutoinflate = 1 + (int)Session["CountTimesAutoinflate"];
                    txtMeassurementPressure.Text = "";
                    if (countAutoinflate < 4)
                    {
                        lblErrorAutoinflate.Text = "Se sugiere revisar el sistema de autoinflado por descrepancia entre la presión deseada para el neumático ("+ pressure.Pressure +"PSI) y la presión medida. Se ha enviado un mensaje a su supervisor avisando de ésta situación.";
                        SendEmailCheckAutoinflate();
                        mpeErrorAutoInflate.Show();
                        countTimes.Text = "Oportunidad: " + count + " de 3.";
                        countTimes.Text = "Oportunidad: " + countAutoinflate + " de 3.";
                    }                 
                }
            }
            Session["CountTimes"] = count;
            Session["CountTimesAutoinflate"] = countAutoinflate;
            if (count == 4 || countAutoinflate == 4)
            {
                Session["AssetToScrap"] = asset;
                mpeToScrapt.Show();
            }
        }

        protected void btnDoDepth_Click(object sender, EventArgs e)
        {
            Session["DepthMeassure0"] = txtMeassureDepth0.Text;
            Session["DepthMeassure1"] = txtMeassureDepth1.Text;
            Session["DepthMeassure2"] = txtMeassureDepth2.Text;
            //Session["DepthMeassure3"] = txtMeassureDepth3.Text;
            //Session["DepthMeassure4"] = txtMeassureDepth4.Text;
            //Session["DepthMeassure5"] = txtMeassureDepth5.Text;
            //Session["DepthMeassure6"] = txtMeassureDepth6.Text;
            //Session["DepthMeassure7"] = txtMeassureDepth7.Text;
            //Session["DepthMeassure8"] = txtMeassureDepth8.Text;
            //Session["DepthMeassure9"] = txtMeassureDepth9.Text;
            if (Session["ToScrap"] == null)
            {
                SaveDepthMeassurement();
            }
            btnPressureMeassurement.Disabled = false;
            btnDepthMeassurement.Disabled = true; 
                      
        }

        protected void SendEmailAbortDepthMeassurement()
        {
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            string tipo = (string)Session["Type"];

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "Recientemente se ha iniciado la inspección de un neumático de la unidad" +
                " N° interno "+unit.InternalNumber +" Patente "+unit.PatentNumber+"."+ "<br>" + "<br>" +
                "En el proceso se ha cancelado la medición de profundidad, para un mejor control se sugiere contactar al resposable de la medición." +"<br>"+ "<br>" +
                "Para mayores antecedentes comuníquese con:" + "<br>" + "<br>" +
                "ID del usuario: " + user.Name + "<br>" +
                "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
                "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
                "Que tenga un buen día";

            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 6;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
        }

        protected void SendEmailAbortPressureMeassurement()
        {
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            string tipo = (string)Session["Type"];

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "Recientemente se ha iniciado la inspección de un neumático de la unidad" +
                "con n° interno " + unit.InternalNumber + " Patente " + unit.PatentNumber + "." + "<br>"  +"<br>" +
                "En el proceso se ha cancelado la medición de presión, para un mejor control se sugiere contactar al resposable de la medición." + "<br>" + "<br>" +
                "Para mayores antecedentes comuníquese con:" + "<br>" + "<br>" +
                "ID del usuario: " + user.Name + "<br>" +
                "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
                "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
                "Que tenga un buen día";

            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 6;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
        }

        protected void SendEmailCheckAutoinflate()
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
                "con n° interno " + unit.InternalNumber + " Patente " + unit.PatentNumber + "."+ "<br>" + "<br>" +
                "Se ha informado que el neumático en la posición "+ tyrePosition + "<br>" +
                " posee sistema de autoinflado, la presión detectada es de "+ detectedPressure+ " PSI " + "<br>"+
                " y el neumático está seteado "+ pressureConf + " PSI." + "<br>" + "<br>" +
                "Se sugiere inspeccionar el sistema de autoinflado por posibles problemas."+ 
                "<br>" + "<br>"+
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

        protected void btnOkMeassurement_Click(object sender, EventArgs e)
        {
            Session["AssetChecked"] = (string)Session["TyreTagPosition"];
            if ((string)Session["DepthMeassurementStatus"] == "B" || (string)Session["PressureMeassurementStatus"] == "B")
            {
                Session["AssetCheckedStatus"] = "imgWrongRequest";
            }
            else if ((string)Session["DepthMeassurementStatus"] == "G" && (string)Session["PressureMeassurementStatus"] == "G")
            {
                Session["AssetCheckedStatus"] = "imgInspectionSuccessful";
            }
            List<Button> listButtons = (List<Button>)Session["ListButtons"];
            foreach (Button item in listButtons)
            {
                if (item.ID == (string)Session["TyreTagPosition"])
                {
                    item.CssClass = (string)Session["AssetCheckedStatus"];
                }
            }
            foreach (Button item in listButtons)
            {
                string btnId = (string)Session["TyreTagPosition"];
                if (item.ID != btnId)
                {
                    item.Enabled = true;
                }
            }
            Session["ListButtonsToSend"] = listButtons;
            Session["TyreTagPosition"] = null;
            Session["CountTimes"] = 0;
            Response.Redirect("SelectionTyrePage.aspx", false);
        }

        protected void btnYesCancelDepthMeassurement_Click(object sender, EventArgs e)
        {
            mpeCancellDepthMeassurement.Hide();
            Session["DepthMeassure0"] = "0";
            Session["DepthMeassure1"] = "0";
            Session["DepthMeassure2"] = "0";
            txtMeassureDepth0.Text = "0";
            txtMeassureDepth1.Text = "0";
            txtMeassureDepth2.Text = "0";
            btnPressureMeassurement.Disabled = false;
            btnDepthMeassurement.Disabled = true;
            Session["DepthMeassurementStatus"] = "B";
            SendEmailAbortDepthMeassurement();
        }

        protected void btnNoCancelDepthMeassurement_Click(object sender, EventArgs e)
        {
            mpeCancellDepthMeassurement.Hide();
            txtMeassureDepth0.Text = "";
            txtMeassureDepth1.Text = "";
            txtMeassureDepth2.Text = "";
            Session["CancelAll"] = null;
        }

        protected void btnYesCancelPressureMeassurement_Click(object sender, EventArgs e)
        {
            Session["PressureMeassure1"] = "0";
            Session["Status"] = "imgWrongRequest";
            txtMeassurementPressure.Text = "0";            
            txtMeassurementPressure.Text = "0";
            Session["PressureMeassure1"] = "0";
            if (Session["ToScrap"] == null)
            {
                btnFinishMeassurement.Enabled = true;
                btnFinishMeassurement.Visible = true;
            }else
            {
                btnNext.Visible = true;
            }
            Session["PressureMeassurementList"] = new List<decimal>();
            List<decimal> PressureMeassureList = (List<decimal>)Session["PressureMeassurementList"];
            PressureMeassureList.Insert(0, 0);
            btnCancelMeassureDepth.Enabled = false;
            mpeCancellDepthMeassurement.Hide();
            btnPressureMeassurement.Disabled = true;
            btnFinishMeassurement.Visible = true;
            btnFinishMeassurement.Enabled = true;
            Session["PressureMeassurementStatus"] = "B";
            SendEmailAbortPressureMeassurement();
        }

        protected void btnNoCancelPressureMeassurement_Click(object sender, EventArgs e)
        {
            mpeCancelPressureMeassurement.Hide();
        }

        protected void btnErrorAutoinflateOk_Click(object sender, EventArgs e)
        {          
            mpeErrorAutoInflate.Hide();
            txtMeassurementPressure.Text = "";
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

        protected void btnDepthErrorControl_Click(object sender, EventArgs e)
        {
            mpeErrorDepthController.Show();
        }

        protected void btnErrorDepthOk_Click(object sender, EventArgs e)
        {
            txtMeassureDepth0.Text = "";
            txtMeassureDepth1.Text = "";
            txtMeassureDepth2.Text = "";
            mpeErrorDepthController.Hide();
        }

        protected void btnErrorPressureController_Click(object sender, EventArgs e)
        {
            mpeErrorPressureController.Show();
        }

        protected void btnErrorPressureOk_Click(object sender, EventArgs e)
        {
            txtMeassurementPressure.Text = "";
            mpeErrorPressureController.Hide();
        }

        protected void btnErrorPressureMeassurementOk_Click(object sender, EventArgs e)
        {
            mpeErrorPressure.Hide();
        }

        protected void SaveDepthMeassurement()
        {
            string errorMessage = "";
            AssetEvent assetEvent = new AssetEvent();
            assetEvent.AssetEventId = 0;
            assetEvent.AssetId = (int)Session["AssetId"];
            assetEvent.SubEventAssetTypeId = 13;
            assetEvent.MeasurementUnitId = 5;
            UnitAsset unitAsset = new BcUnitAsset().GetActiveUnitAsset((int)Session["AssetId"]);
            assetEvent.AssetPositionId = unitAsset.AssetPositionId;
            assetEvent.AsignmentId = null;
            if (Session["AssetSituationId"] != null)
            {
                assetEvent.AssetSituationId = int.Parse((string)Session["AssetSituationId"]);
            }
            else
            {
                assetEvent.AssetSituationId = null;
            }
            assetEvent.AssetEventMemberId = this.UserId();
            Asset assetInSession = new BcAsset().GetAssetById((int)Session["AssetId"], out errorMessage);
            assetEvent.FacilityId = assetInSession.FacilityId;
            assetEvent.UnitId = unitAsset.UnitId;
            assetEvent.AssetEventDate = DateTime.Now;
            assetEvent.AssetEventCost = 0;
            assetEvent.MeasurementAsset = 0;
            assetEvent.MeasurementKm = int.Parse((string)Session["UnitKilometers"]);
            assetEvent.StartPressureMeasurement = 0;
            assetEvent.FinishPressureMeasurement = 0;
            assetEvent.MeasurementTireTreadDepth1 = decimal.Parse((string)Session["DepthMeassure0"], CultureInfo.InvariantCulture);
            assetEvent.MeasurementTireTreadDepth2 = decimal.Parse((string)Session["DepthMeassure1"], CultureInfo.InvariantCulture);
            assetEvent.MeasurementTireTreadDepth3 = decimal.Parse((string)Session["DepthMeassure2"], CultureInfo.InvariantCulture);
            assetEvent.MeasurementTireTreadDepth4 = 0;
            assetEvent.MeasurementTireTreadDepth5 = 0;
            assetEvent.MeasurementTireTreadDepth6 = 0;
            assetEvent.MeasurementTireTreadDepth7 = 0;
            assetEvent.MeasurementTireTreadDepth8 = 0;
            assetEvent.MeasurementTireTreadDepth9 = 0;
            assetEvent.MeasurementTireTreadDepth10 = 0;
            assetEvent.ExecutingUserId = this.UserId();
            assetEvent.AuthorizingUserId = this.UserId();
            new BcAssetEvent().Save(assetEvent, out errorMessage);
            Session["DepthMeassurementStatus"] = "G";
        }

        protected void SavePressureMeassurement()
        {
            string errorMessage = "";

            List<decimal> PressureList = (List<decimal>)Session["PressureMeassurementList"];
            AssetEvent assetEvent = new AssetEvent();
            assetEvent.AssetEventId = 0;
            assetEvent.AssetId = (int)Session["AssetId"];
            assetEvent.SubEventAssetTypeId = 12;
            assetEvent.MeasurementUnitId = 6;
            UnitAsset unitAsset = new BcUnitAsset().GetActiveUnitAsset((int)Session["AssetId"]);
            assetEvent.AssetPositionId = unitAsset.AssetPositionId;
            assetEvent.AsignmentId = null;
            if (Session["AssetSituationId"] != null)
            {
                assetEvent.AssetSituationId = int.Parse((string)Session["AssetSituationId"]);
            }
            else
            {
                assetEvent.AssetSituationId = null;
            }

            assetEvent.AssetEventMemberId = this.UserId();
            Asset assetInSession = new BcAsset().GetAssetById((int)Session["AssetId"], out errorMessage);
            assetEvent.FacilityId = assetInSession.FacilityId;
            assetEvent.UnitId = unitAsset.UnitId;
            assetEvent.AssetEventDate = DateTime.Now;
            assetEvent.AssetEventCost = 0;
            assetEvent.MeasurementAsset = 0;
            assetEvent.MeasurementKm = int.Parse((string)Session["UnitKilometers"]);
            assetEvent.StartPressureMeasurement = PressureList.First();
            assetEvent.FinishPressureMeasurement = PressureList.Last();
            assetEvent.MeasurementTireTreadDepth1 = 0;
            assetEvent.MeasurementTireTreadDepth2 = 0;
            assetEvent.MeasurementTireTreadDepth3 = 0;
            assetEvent.MeasurementTireTreadDepth4 = 0;
            assetEvent.MeasurementTireTreadDepth5 = 0;
            assetEvent.MeasurementTireTreadDepth6 = 0;
            assetEvent.MeasurementTireTreadDepth7 = 0;
            assetEvent.MeasurementTireTreadDepth8 = 0;
            assetEvent.MeasurementTireTreadDepth9 = 0;
            assetEvent.MeasurementTireTreadDepth10 = 0;
            assetEvent.ExecutingUserId = this.UserId();
            assetEvent.AuthorizingUserId = this.UserId();
            new BcAssetEvent().Save(assetEvent, out errorMessage);
            Session["PressureMeassurementStatus"] = "G";
        }

        protected void btnFinishMeassurement_Click(object sender, EventArgs e)
        {
            mpeOk.Show();
        }
    }
}