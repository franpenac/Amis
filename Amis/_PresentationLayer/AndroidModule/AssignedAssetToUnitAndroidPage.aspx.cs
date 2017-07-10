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
    public partial class AssignedAssetToUnitAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                NewAssigned();

                if (Session["UnitRegisterFind"] !=null)
                {
                    RepeatAssigned();
                }

            }
        }

        protected void ddlTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTypeSearch.SelectedValue != "0")
            {
                ddlUnitSelectValue.Items.Clear();
                ddlUnitSelectValue.Enabled = true;
                ddlAssetType.Enabled = false;
                ListItem Index = new ListItem("Seleccione", "0");
                ddlUnitSelectValue.Items.Add(Index);
                List<UnitRegister> list = new DcWrongTagInspection().SearchUnitRegister();
                if (list != null)
                {
                    if (ddlTypeSearch.SelectedValue == "1")
                    {
                        foreach (UnitRegister item in list)
                        {
                            ListItem Default = new ListItem(item.PatentNumber, item.UnitRegisterId.ToString());
                            ddlUnitSelectValue.Items.Add(Default);

                        }
                    }
                    if (ddlTypeSearch.SelectedValue == "2")
                    {
                        foreach (UnitRegister item in list)
                        {
                            ListItem Default = new ListItem(item.InternalNumber.ToString(), item.UnitRegisterId.ToString());
                            ddlUnitSelectValue.Items.Add(Default);

                        }
                    }
                    ddlUnitSelectValue.DataBind();
                }
                else { ddlUnitSelectValue.Enabled = false;
                        ddlAssetType.Enabled = false;
                        Page.ShowSmallPopupMessage("No hay unidades registradas!"); }
            }
        }

        protected void ddlUnitSelectValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTypeSearch.SelectedValue != "0")
            {
                ddlAssetType.Enabled = true;
                string errorMessage = "";
                ddlAssetType.SetComboList(new BcAssetType(), out errorMessage);
                ddlAssetType.Items.Remove(ddlAssetType.Items.FindByText("Vehiculo"));
            }
            else { ddlAssetType.Enabled = false;
                Page.ShowSmallPopupMessage("Debe seleccionar una patente o numero interno primero."); }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            if (ddlTypeSearch.SelectedItem.Text!="Seleccione")
            {
                if(ddlUnitSelectValue.SelectedItem.Text == "Seleccione") { Page.ShowSmallPopupMessage("Debe seleccionar una unidad primero"); return; }
                if(ddlAssetType.SelectedItem.Text == "Seleccionar") { Page.ShowSmallPopupMessage("Debe seleccionar un tipo de activo primero"); return; }

                if (ddlAssetType.SelectedItem.Text != "Neumático")
                {
                    Session["AssetTypeName"] = ddlAssetType.SelectedItem.Text;
                    Session["AssetTypeId"] = int.Parse(ddlAssetType.SelectedItem.Value);
                    Session["UnitRegisterFind"] = int.Parse(ddlUnitSelectValue.SelectedItem.Value);

                    Session["UnitId"] = new BcAssignedAssetToUnit().GetUnitIdByUnitRegisterId(int.Parse(ddlUnitSelectValue.SelectedItem.Value));
                    Response.Redirect("AssignedToUnitAndroidPage.aspx", false);
                }
                else
                {
                    Session["UnitId"] = new BcAssignedAssetToUnit().GetUnitIdByUnitRegisterId(int.Parse(ddlUnitSelectValue.SelectedItem.Value));
                    Session["UnitRegisterFind"] = int.Parse(ddlUnitSelectValue.SelectedItem.Value);
                    Response.Redirect("AssignedTyreToUnitAndroidPage.aspx", false);
                }
            }
            else
            {
                Page.ShowSmallPopupMessage("Debe seleccionar una unidad primero");
            }
        }

        protected void NewAssigned()
        {
            ddlTypeSearch.ClearSelection();
            ListItem Default = new ListItem("Seleccione", "0");
            ListItem Patent = new ListItem("Patente", "1");
            ListItem InternalNumber = new ListItem("N° interno", "2");

            ddlTypeSearch.Items.Add(Default);
            ddlTypeSearch.Items.Add(Patent);
            ddlTypeSearch.Items.Add(InternalNumber);
            ddlTypeSearch.DataBind();

            ddlUnitSelectValue.Enabled = false;
            ddlAssetType.Enabled = false;
        }

        protected void RepeatAssigned()
        {
            ddlTypeSearch.SelectedValue = "1";
            ddlUnitSelectValue.Enabled = true;

            List<UnitRegister> list = new DcWrongTagInspection().SearchUnitRegister();
            foreach (UnitRegister item in list)
            {
                ListItem DefaultItem = new ListItem(item.PatentNumber, item.UnitRegisterId.ToString());
                ddlUnitSelectValue.Items.Add(DefaultItem);

            }
            ddlUnitSelectValue.DataBind();

            int value = (int)Session["UnitRegisterFind"];
            ddlUnitSelectValue.SelectedValue = value.ToString();
            ddlAssetType.Enabled = true;

            ddlAssetType.Enabled = true;
            string errorMessage = "";
            ddlAssetType.SetComboList(new BcAssetType(), out errorMessage);
            ddlAssetType.Items.Remove(ddlAssetType.Items.FindByText("Vehiculo"));
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Session["NothingAction"] = null;
            Session["AssetTypeName"] = null;
            Session["TagCode"] = null;
            Session["UnitRegisterFind"] = null;
            Session["Contador"] = null;
            Session["UnitId"] = null;
            Session["ErrorNumber"] = null;

            Response.Redirect("MenuAndroidPage.aspx", false);
        }
    }
}