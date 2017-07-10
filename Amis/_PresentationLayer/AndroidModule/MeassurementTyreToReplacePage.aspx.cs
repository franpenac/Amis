using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class MeassurementTyreToReplacePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeControls();
            }
            if (Session["DepthMeassure1"] != null)
            {
                txtMeassureDepth1.Text = ((string)Session["DepthMeassure1"]);
            }
            if (Session["DepthMeassure2"] != null)
            {
                txtMeassureDepth2.Text = ((string)Session["DepthMeassure2"]);
            }
            if (Session["DepthMeassure3"] != null)
            {
                txtMeassureDepth3.Text = ((string)Session["DepthMeassure3"]);
            }
            if (Session["PressureMeassure1"] != null)
            {
                txtMeassurementPressure.Text = ((string)Session["PressureMeassure1"]);
            }
        }

        private void InitializeControls()
        {
            lblPatentSelected.Text = (string)Session["Patent"];
            lblInternalNumberSelected.Text = (string)Session["InternalNumber"];
            Session["PressureMeassurementList"] = null;
            Session["PressureMeassure1"] = null;
            Session["PressureMeassurementStatus"] = null;
            Session["DepthMeassure1"] = null;
            Session["DepthMeassure2"] = null;
            Session["DepthMeassure3"] = null;
            Session["DepthMeassurementStatus"] = null;
            Session["CountTimes"] = null;
        }

        protected void btnNoAnotherMeassurement_Click(object sender, EventArgs e)
        {
            Session["AssetChecked"] = null;
            Session["UnitFind"] = null;
            Session["UnitRegisterFind"] = null;
            Session["Patent"] = null;
            Session["InternalNumber"] = null;
            Response.Redirect("InspectionIndexAndroidPage.aspx");
        }

        protected void txtMeassurementPressure_TextChanged(object sender, EventArgs e)
        {
            List<double> PressureMeassureList = new List<double>();
            if (Session["PressureMeassurementList"] != null)
            {
                PressureMeassureList = (List<double>)Session["PressureMeassurementList"];
            }
            PressureMeassureList.Add(double.Parse(txtMeassurementPressure.Text));
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
            if (pressureMed < double.Parse(pressure.Pressure.ToString()) + 2 && pressureMed > double.Parse(pressure.Pressure.ToString()) - 2)
            {
                count = 5;
                Session["PressureMeassure1"] = int.Parse(txtMeassurementPressure.Text);
                Session["PressureMeassurementStatus"] = "G";
                btnNext.Visible = true;
            }
            else
            {
                if (!ChkAutoInflate.Checked)
                {
                    count = 1 + (int)Session["CountTimes"];
                    txtMeassurementPressure.Text = "";
                    if (count < 4)
                    {
                        lblErrorPressureMeassurement.Text = "La presión medida es de " + pressureMed + "PSI , y la presión correcta para el neumático que esta inspeccionando es de " + pressure.Pressure + "PSI, por favor rectifique la presión y vuelva a medir.";
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
                        lblErrorAutoinflate.Text = "Se sugiere revisar el sistema de autoinflado por descrepancia entre la presión deseada para el neumático (" + pressure.Pressure + "PSI) y la presión medida. Se ha enviado un mensaje a su supervisor avisando de ésta situación.";
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
                mpeToScrap.Show();
            }
        }

        protected void btnCancelMeassureDepth_Click(object sender, EventArgs e)
        {
            mpeCancelDepthMeassurement.Show();
        }

        protected void btnCancelMeassurementPressure_Click(object sender, EventArgs e)
        {
            mpeCancelPressureMeassurement.Show();
        }

        protected void wibYesToScrap_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReasonRemoveAndroidPage.aspx");
        }

        protected void wibNotToScrap_Click(object sender, EventArgs e)
        {
            mpeToScrap.Hide();
            Session["PressureMeassurementList"] = null;
            Session["CountTimes"] = null;
            Session["PressureMeassure1"] = null;
            txtMeassurementPressure.Text = "";
            countTimes.Text = "Oportunidad: " + 0 + " de 3.";
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

                btnCancelMeassurementPressure.Enabled = false;
                btnTakePressure.Disabled = false;
                btnNext.Visible = true;
                btnNext.Enabled = true;
            }
            else
            {
                if (!ChkAutoInflate.Checked)
                {
                    count = 1 + (int)Session["CountTimes"];
                    txtMeassurementPressure.Text = "";
                    if (count < 4)
                    {
                        lblErrorPressureMeassurement.Text = "La presión medida es de " + pressureMed + "PSI , y la presión correcta para el neumático que esta inspeccionando es de " + pressure.Pressure + "PSI, por favor rectifique la presión y vuelva a medir.";
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
                        lblErrorAutoinflate.Text = "Se sugiere revisar el sistema de autoinflado por descrepancia entre la presión deseada para el neumático (" + pressure.Pressure + "PSI) y la presión medida. Se ha enviado un mensaje a su supervisor avisando de ésta situación.";
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
                mpeToScrap.Show();
            }
        }

        protected void btnDoDepth_Click(object sender, EventArgs e)
        {
            Session["DepthMeassure1"] = txtMeassureDepth1.Text;
            Session["DepthMeassure2"] = txtMeassureDepth2.Text;
            Session["DepthMeassure3"] = txtMeassureDepth3.Text;
            btnTakePressure.Disabled = false;
            btnTakeMeasurements.Disabled = true;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectReplaceTyreDestiny.aspx", false);
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

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "Recientemente se ha iniciado el proceso de recambio de un neumático de la unidad" +
                " N° interno " + unit.InternalNumber + " Patente " + unit.PatentNumber + "." + "<br>" + "<br>" +
                "En el proceso se ha cancelado la medición de profundidad, para un mejor control se sugiere contactar al resposable de la medición." + "<br>" + "<br>" +
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

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "Recientemente se ha iniciado el proceso de recambio de un neumático de la unidad" +
                " con n° interno " + unit.InternalNumber + " Patente " + unit.PatentNumber + "." + "<br>" + "<br>" +
                "En el proceso se ha cancelado la medición de presión, para un mejor control se sugiere contactar al resposable de la medición." + "<br>" + "<br>" +
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
               "con n° interno " + unit.InternalNumber + " Patente " + unit.PatentNumber + "." + "<br>" + "<br>" +
               "Se ha informado que el neumático en la posición " + tyrePosition + "<br>" +
               " posee sistema de autoinflado, la presión detectada es de " + detectedPressure + " PSI " + "<br>" +
               " y el neumático está seteado " + pressureConf + " PSI." + "<br>" + "<br>" +
               "Se sugiere inspeccionar el sistema de autoinflado por posibles problemas." +
               "<br>" + "<br>" +
               "Para mayores antecedentes comuníquese con:" + "<br>" + "\n" +
               "ID del usuario: " + user.Name + "<br>" +
               "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
               "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" + "<br>" +
               "Que tenga un buen día";

            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 3;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["PressureMeassure1"] = null;
            Session["SendEmail"] = 1;
        }

        protected void btnYesCancelDepthMeassurement_Click(object sender, EventArgs e)
        {
            mpeCancelDepthMeassurement.Hide();
            Session["DepthMeassure1"] = "0";
            Session["DepthMeassure2"] = "0";
            Session["DepthMeassure3"] = "0";
            txtMeassureDepth1.Text = "0";
            txtMeassureDepth2.Text = "0";
            txtMeassureDepth3.Text = "0";
            btnTakePressure.Disabled = false;
            btnTakeMeasurements.Disabled = true;
            Session["DepthMeassurementStatus"] = "B";
            SendEmailAbortDepthMeassurement();
        }

        protected void btnNoCancelDepthMeassurement_Click(object sender, EventArgs e)
        {
            mpeCancelDepthMeassurement.Hide();
            txtMeassureDepth1.Text = "";
            txtMeassureDepth2.Text = "";
            txtMeassureDepth3.Text = "";
            Session["CancelAll"] = null;
        }

        protected void btnYesCancelPressureMeassurement_Click(object sender, EventArgs e)
        {
            Session["PressureMeassure1"] = "0";
            Session["Status"] = "imgWrongRequest";
            txtMeassurementPressure.Text = "0";
            txtMeassurementPressure.Text = "0";
            Session["PressureMeassure1"] = "0";
            Session["PressureMeassurementList"] = new List<decimal>();
            List<decimal> PressureMeassureList = (List<decimal>)Session["PressureMeassurementList"];
            PressureMeassureList.Insert(0, 0);
            btnCancelMeassureDepth.Enabled = false;
            mpeCancelDepthMeassurement.Hide();
            btnTakePressure.Disabled = true;
            btnNext.Visible = true;
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
            txtMeassureDepth1.Text = "";
            txtMeassureDepth2.Text = "";
            txtMeassureDepth3.Text = "";
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
    }
}