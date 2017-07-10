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
    public partial class RepairAssetAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            lblPatentSelected.Text = unit.PatentNumber;
            lblInternalNumberSelected.Text = unit.InternalNumber;

            string type = (string)Session["TagAsset"];

            string typeName = new BcInspectionAndroid().getAssetTypeByTag(type);
            lblAssetType.Text = lblAssetType.Text + " " + typeName;
        }

        protected void imgNext_Click(object sender, ImageClickEventArgs e)
        {
            string errorMessage = "";
            Session["message"] = null;
            Session["emailList"] = null;

            //TODO: Guardar el evento que se realize
            int id = (int)Session["UnitRegisterFind"];
            string tipo = (string)Session["Type"];
            string tag = (string)Session["TagAsset"];
            Tag tagRead = new BcTag().GetTagByCodeTag(tag, out errorMessage);
            TagAssigned tagAssigned = new BcTagAssigned().GetAssignedByTag(tagRead.TagId, out errorMessage);
            Asset asset = new BcAsset().GetAssetById(tagAssigned.AssetId, out errorMessage);
            UnitAsset unitAsset = new BcUnitAsset().GetUnitAssetByAssetId(asset.AssetId, out errorMessage);
            int? assetPositionId = unitAsset.AssetPositionId;
            AssetUniqueIdentification assetUnique = new BcAssetUniqueIdentification().GetAssetUniqueIdentificationById(asset.AssetUniqueIdentificationId);
            AssetModel model = new BcAssetModel().GetAssetModelById(assetUnique.AssetModelId, out errorMessage);
            Brand brand = new BcBrand().GetBrandById(model.BrandId, out errorMessage);
            string positionName = "";
            if (assetPositionId != null)
            {
                positionName = new BcAssetPosition().GetAssetPositionById(assetPositionId.GetValueOrDefault()).PositionDescription;
            }


            if ((string)Session["IsTyre"] == "Y")
            {
                new BcInspectionAndroid().ChangeState(tag, "N");

                int assetId = (int)Session["AssetId"];
                string unitId = (string)Session["UnitFind"];
                Asset assetS = new BcAsset().GetAssetById(assetId, out errorMessage);
                AssetUniqueIdentification assetuniq = new BcAssetUniqueIdentification().GetAssetUniqueIdentificationById(assetS.AssetUniqueIdentificationId);
                int assetTypeId = assetuniq.AssetTypeId;

                SubEventAssetType subEvent = new BcSubEventAssetType().GetSubEventAssetTypeToRepair(assetId);
                int assetPositionIdS = (int)Session["assetPositionId"];
                Assignment assignment = new BcAssignment().GetAssignmentByUnitId(int.Parse(unitId), out errorMessage);
                int? assignmentID = null;
                string assetSituationId = (string)Session["AssetSituationId"];
                if (assignment != null)
                {
                    assignmentID = assignment.AssignmentId;
                }
                int? facilityId = new BcAsset().GetAssetById(assetId, out errorMessage).FacilityId;
                decimal meassurementDepth1 = decimal.Parse((string)Session["DepthMeassure0"], CultureInfo.InvariantCulture);
                decimal meassurementDepth2 = decimal.Parse((string)Session["DepthMeassure1"], CultureInfo.InvariantCulture);
                decimal meassurementDepth3 = decimal.Parse((string)Session["DepthMeassure2"], CultureInfo.InvariantCulture);
                decimal meassurementDepth4 = 0;
                decimal meassurementDepth5 = 0;
                decimal meassurementDepth6 = 0;
                decimal meassurementDepth7 = 0;
                decimal meassurementDepth8 = 0;
                decimal meassurementDepth9 = 0;
                decimal meassurementDepth10 = 0;

                List<decimal> PressureList = (List<decimal>)Session["PressureMeassurementList"];

                //
                int? meassurementUnit = null;
                if (assetTypeId == 1)
                {
                    meassurementUnit = 5;
                }
                int kilometers = int.Parse((string)Session["UnitKilometers"]);

                SaveScrapEvent(assetId, subEvent.SubEventAssetTypeId, meassurementUnit, assetPositionId, assignmentID, int.Parse(assetSituationId), this.UserId(), facilityId, int.Parse(unitId), assetS.AssetUniqueIdentificationId, DateTime.Today, asset.Cost, 0, kilometers, PressureList.First(), PressureList.Last(), meassurementDepth1, meassurementDepth2, meassurementDepth3, meassurementDepth4, meassurementDepth5, meassurementDepth6, meassurementDepth7, meassurementDepth8, meassurementDepth9, meassurementDepth10, this.UserId(), this.UserId(), "N");
            }
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());


            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            string message = "Sr. Supervisor "+ "<br>" + "<br>" + "En la reciente inspeccion se ha enviado a reparar el activo '" + tipo + "' de la unidad “Nº interno; " + unit.InternalNumber + "”, Patente: " + unit.PatentNumber + "<br>" + "<br>" +
                "Para mayor información comuníquese con el usuario: " + "<br>" + "<br>" +
                "ID del usuario: " + user.Name + "<br>" +
                "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
                "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
                "Que tenga un buen día";

            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 5;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            string type = (string)Session["TagAsset"];
            new BcInspectionAndroid().SendToRepair(branchOfficeid, type);

            if (Session["IsTyre"] != null)
            {
                List<Button> listButtons = (List<Button>)Session["ListButtons"];
                string buttonId = (string)Session["TyreTagPosition"];
                foreach (var item in listButtons)
                {
                    if (item.ID == buttonId)
                    {
                        item.CssClass = "imgInspectionSuccessful";
                        item.Enabled = false;
                    }
                    else if (item.CssClass == "imgHidden")
                    {
                        item.Enabled = true;
                    }
                }
                Session["ListButtonsToScrap"] = listButtons;
                Session["TyreTagPosition"] = null;
                Session["IsTyre"] = null;
                Session["TagAsset"] = null;
                Response.Redirect("SelectionTyrePage.aspx", false);
            }
            else
            {
                Response.Redirect("SelectedInspectionAndroidPage.aspx", false);
            }
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

        private void SaveScrapEvent(int assetId, int subEventAssetTypeId, int? meassurementUnitId, int? assetPositionId, int? asignmentId, int assetSituationId, int assetEventMemberId, int? facilityId, int unitId, int assetUniqueIdentificationId, DateTime assetEventDate, decimal assetEventCost, decimal meassurementAsset, int meassurementKm, decimal startPressureMeassurement, decimal finishPressureMeassurement, decimal meassurementTireTreadDepth1, decimal meassurementTireTreadDepth2, decimal meassurementTireTreadDepth3, decimal meassurementTireTreadDepth4, decimal meassurementTireTreadDepth5, decimal meassurementTireTreadDepth6, decimal meassurementTireTreadDepth7, decimal meassurementTireTreadDepth8, decimal meassurementTireTreadDepth9, decimal meassurementTireTreadDepth10, int executingUserId, int authorizingUserId, string isGood)
        {
            string errorMessage = "";
            AssetEvent assetEvent = new AssetEvent();
            assetEvent.AssetEventId = 0;
            assetEvent.AssetId = assetId;
            assetEvent.SubEventAssetTypeId = subEventAssetTypeId;
            assetEvent.MeasurementUnitId = meassurementUnitId;
            assetEvent.AssetPositionId = assetPositionId;
            assetEvent.AsignmentId = asignmentId;
            assetEvent.AssetSituationId = assetSituationId;
            assetEvent.AssetEventMemberId = assetEventMemberId;
            assetEvent.FacilityId = facilityId;
            assetEvent.UnitId = unitId;
            assetEvent.AssetUniqueIdentificationId = assetUniqueIdentificationId;
            assetEvent.AssetEventDate = assetEventDate;
            assetEvent.AssetEventCost = assetEventCost;
            assetEvent.MeasurementAsset = meassurementAsset;
            assetEvent.MeasurementKm = meassurementKm;
            assetEvent.StartPressureMeasurement = startPressureMeassurement;
            assetEvent.FinishPressureMeasurement = finishPressureMeassurement;
            assetEvent.MeasurementTireTreadDepth1 = meassurementTireTreadDepth1;
            assetEvent.MeasurementTireTreadDepth2 = meassurementTireTreadDepth2;
            assetEvent.MeasurementTireTreadDepth3 = meassurementTireTreadDepth3;
            assetEvent.MeasurementTireTreadDepth4 = 0;
            assetEvent.MeasurementTireTreadDepth5 = 0;
            assetEvent.MeasurementTireTreadDepth6 = 0;
            assetEvent.MeasurementTireTreadDepth7 = 0;
            assetEvent.MeasurementTireTreadDepth8 = 0;
            assetEvent.MeasurementTireTreadDepth9 = 0;
            assetEvent.MeasurementTireTreadDepth10 = 0;
            assetEvent.ExecutingUserId = executingUserId;
            assetEvent.AuthorizingUserId = authorizingUserId;
            assetEvent.IsGood = "N";
            new BcAssetEvent().Save(assetEvent, out errorMessage);
        }
    }
}