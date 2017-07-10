using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using amis._DataLayer.GeneratedCode;
using amis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AssetModule
{
    public partial class UnitAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialComponents();

            }
        }

        protected void InitialComponents()
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

        }

        protected void ddlTypeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTypeSearch.SelectedValue != "0")
            {
                ddlUnitSelectValue.Items.Clear();
                ddlUnitSelectValue.Enabled = true;
                ListItem Index = new ListItem("Seleccione", "0");
                ddlUnitSelectValue.Items.Add(Index);
                string errorMessage = "";
                List<UnitRegister> list = new BcUnitAssigned().GetComboUnitRegister(out errorMessage);
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
                else
                {
                    ddlUnitSelectValue.Enabled = false;
                    Page.ShowSmallPopupMessage("No hay unidades registradas!");
                }
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
           
        }
        
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectedAssignedPage.aspx", false);
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            UnitRegister unitRegister = new BcUnitRegister().GetUnitRegisterById(int.Parse(ddlUnitSelectValue.SelectedValue), out errorMessage);

            Unit unit = new BcUnitAssigned().GetUnitByUnitRegisterId(unitRegister.UnitRegisterId, out errorMessage);

            Tag saveTag = new BcTag().GetTagByCodeTag(txbTag.Text, out errorMessage);

            if (saveTag != null)
            {
                TagAssigned assigned = new TagAssigned();
                assigned.TagId = saveTag.TagId;
                assigned.AssetId = unit.AssetId;
                assigned.TagAssignedDate = DateTime.Now;
                TagAssigned validate = new BcTagAssigned().GetAsseginedByAssetId(unit.AssetId, out errorMessage);
                if (validate != null)
                {
                    Page.ShowPopupMessage("La unidad " + unitRegister.PatentNumber+" ya ha sido asignada previamente a un tag");
                    return;
                }
                TagAssigned saveAssigned = new BcTagAssigned().Save(assigned, out errorMessage);

                if (saveAssigned != null)
                {
                    errorMessage = "Se ha asignado correctamente el TAG a la unidad "+ unitRegister.PatentNumber;
                }
                else
                {
                    CommonEnums.DeletedRecordStates error = new BcTag().DeleteTag(saveTag.TagId, saveTag.TagCode, out errorMessage);
                }
            }

            Page.ShowSmallPopupMessage(errorMessage);
        }
    }
}