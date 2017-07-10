using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class AnyObservationPage : System.Web.UI.Page
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
            lblPatentSelected.Text = (string)Session["Patent"];
            lblInternalNumberSelected.Text = (string)Session["InternalNumber"];
            ddlAssetSituation.DataSource = new BcAssetSituation().GetAssetSituationList();
            ddlAssetSituation.DataTextField = "AssetSituationName";
            ddlAssetSituation.DataValueField = "AssetSituationId";
            ddlAssetSituation.DataBind();
            ddlAssetSituation.SelectedValue = "0";
            Session["ToScrap"] = null;
        }

        protected void ddlAssetSituation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["AssetSituationId"] = ddlAssetSituation.SelectedValue;
            mpeNeedToRemove.Show();
        }

        protected void btnToScrapYes_Click(object sender, EventArgs e)
        {
            string assetTag = (string)Session["TagAsset"];
            Session["ToScrap"] = 1;
            Response.Redirect("MeassurementTyrePage.aspx");
        }

        protected void btnToScrapNo_Click(object sender, EventArgs e)
        {
            Response.Redirect("MeassurementTyrePage.aspx");
        }
    }
}