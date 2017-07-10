using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using amis._DataLayer.GeneratedCode;
using amis.Models;
using Infragistics.Web.UI.GridControls;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class ChangeAssetToAnotherWarehouse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeControls();
            }
        }

        private void InitializeControls()
        {
            string errorMessage = ""; 
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            lblPatentSelected.Text = unit.PatentNumber;
            lblInternalNumberSelected.Text = unit.InternalNumber;
            int BranchOfficeId = (int)Session["BranchOfficeId"];
            ddlSelectWarehouse.DataSource = new BcWarehouse().GetWharehouseListByBranchOfficeId(BranchOfficeId, out errorMessage);
            ddlSelectWarehouse.DataValueField = "WarehouseId";
            ddlSelectWarehouse.DataTextField = "WarehouseName";
            ddlSelectWarehouse.DataBind();
            ddlSelectWarehouse.SelectedValue = "0";
        }

        protected void ddlSelectWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSelectWarehouse.SelectedValue != "0")
            {
                mpeWarehouseCorrect.Show();
            }else
            {
                mpeWarehouseCorrect.Hide();
            }
        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            AssetEvent assetEvent = new AssetEvent();
            assetEvent.AssetEventId = 0;
            assetEvent.AssetId = (int)Session["AssetId"];
            assetEvent.SubEventAssetTypeId = 5;
            assetEvent.MeasurementUnitId = 6;
            UnitAsset unitAsset = new BcUnitAsset().GetActiveUnitAsset((int)Session["AssetId"]);
            assetEvent.AssetPositionId = unitAsset.AssetPositionId;
            assetEvent.AsignmentId = null;
            if (Session["AssetSituationId"] != null)
            {
                assetEvent.AssetSituationId = int.Parse((string)Session["AssetId"]);
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
            assetEvent.AssetEventCost = null;
            assetEvent.MeasurementAsset = null;
            int unitRegister = new BcUnit().GetUnitById(unitAsset.UnitId.Value, out errorMessage).UnitRegisterId;
            int km = new BcUnitRegister().GetUnitRegisterById(unitRegister, out errorMessage).KilometersOfTravel;
            assetEvent.MeasurementKm = km;
            List<decimal> PressureMeassureList = (List<decimal>)Session["PressureMeassurementList"];
            assetEvent.StartPressureMeasurement = PressureMeassureList.First();
            assetEvent.FinishPressureMeasurement = PressureMeassureList.Last() ;
            assetEvent.MeasurementTireTreadDepth1 = decimal.Parse((string)Session["DepthMeassure1"], CultureInfo.InvariantCulture);
            assetEvent.MeasurementTireTreadDepth2 = decimal.Parse((string)Session["DepthMeassure2"], CultureInfo.InvariantCulture);
            assetEvent.MeasurementTireTreadDepth3 = decimal.Parse((string)Session["DepthMeassure3"], CultureInfo.InvariantCulture);
            assetEvent.MeasurementTireTreadDepth4 = null;
            assetEvent.MeasurementTireTreadDepth5 = null;
            assetEvent.ExecutingUserId = this.UserId();
            assetEvent.AuthorizingUserId = this.UserId();
            AssetEvent AssetEvent = new BcAssetEvent().Save(assetEvent, out errorMessage);
            if (AssetEvent != null)
            {
                if (ChangeWarehouse((int)Session["AssetId"]))
                {
                    if (Session["isReplace"] != null)
                    {
                        Session["FinishChange"] = 1;
                        Response.Redirect("SelectionReplaceTyrePage.aspx");
                    }else
                    {
                        btnAnotherChangePosition();
                    }
                }else
                {
                    Page.ShowSmallPopupMessage("Error al cambiar de bodega.");
                }

            }else
            {
                Page.ShowSmallPopupMessage(errorMessage);
            }
        }

        private bool ChangeWarehouse(int assetId)
        {
            string errorMessage = "";
            try
            {
                Asset asset = new BcAsset().GetAssetById(assetId, out errorMessage);
                int wareHouseId = int.Parse(ddlSelectWarehouse.SelectedValue);
                int faciliTyId = new BcFacility().GetFacilityByWarehouse(wareHouseId);
                Facility facilityById = new BcFacility().GetFacilityByIdAndTypeId(faciliTyId, 1);
                if (facilityById != null)
                {
                    if (new BcAsset().ChangeFacility(asset.AssetId, facilityById.FacilityId))
                    {
                        UnassignedAssetByChangeToWarehouse(assetId);
                        return true;
                    }else
                    {
                        return false;
                    }
                }
                else
                {
                    Facility newFacility = new Facility();
                    newFacility.FacilityId = 0;
                    newFacility.FacilityTypeId = 1;
                    newFacility.WarehouseId = int.Parse(ddlSelectWarehouse.SelectedValue);
                    newFacility.UnitId = null;
                    new BcFacility().Save(newFacility, out errorMessage);
                    
                    if (new BcAsset().ChangeFacility(asset.AssetId, facilityById.FacilityId))
                    {
                        UnassignedAssetByChangeToWarehouse(assetId);
                        return true;
                    }else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        private void UnassignedAssetByChangeToWarehouse(int assetId)
        {
            new BcUnitAsset().UnassignedAssetOfUnit(assetId);
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            ddlSelectWarehouse.SelectedValue = "0";
            mpeWarehouseCorrect.Hide();
        }

        protected void btnAnotherChangePosition()
        {
            List<Button> listButton = (List<Button>)Session["ListButtons"];
            string buttonId = (string)Session["TyreTagPosition"];
            foreach (Button item in listButton)
            {
                if (item.ID == buttonId)
                {
                    item.Enabled = false;
                    item.CssClass = "imgInspectionSuccessful";
                }
                else if (item.CssClass != "imgInspectionSuccessful" && item.CssClass != "imgWrongRequest")
                {
                    item.Enabled = true;
                    item.CssClass = "imgHidden";
                }
            }
            Session["ListButtonsFromChangeAnotherWarehouse"] = listButton;
            Session["ChangeToWarehouse"] = 1;
            Session["AssetId"] = null;
            Session["TyreTagPosition"] = null;
            Response.Redirect("SelectionTyrePage.aspx");
        }

        protected void btnNoAnotherChangePosition_Click(object sender, EventArgs e)
        {
            if (Session["isReplace"] == null)
            {
                Session["Tittle"] = "Inspección";
                Response.Redirect("SelectedInspectionAndroidPage.aspx");
            }else
            {
                Session["isReplace"] = null;
                Response.Redirect("MenuAndroidPage.aspx");
            }

        }
    }
}