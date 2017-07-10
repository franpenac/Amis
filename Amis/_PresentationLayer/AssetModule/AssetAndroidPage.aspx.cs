using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using amis._BusinessLayer.GeneratedCode;
using amis._DataLayer;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using amis._BusinessLayer;
using amis._Controls;

namespace amis._PresentationLayer.AssetModule
{
    public partial class AssetAndroidPage : System.Web.UI.Page
    {
        protected int DispatchProviderDocumentItemId
        {
            get
            {
                if (ViewState["DispatchProviderDocumentItemPage_DispatchProviderDocumentItemId"] == null)
                {
                    ViewState["DispatchProviderDocumentItemPage_DispatchProviderDocumentItemId"] = 0;
                }
                int id = int.Parse(ViewState["DispatchProviderDocumentItemPage_DispatchProviderDocumentItemId"].ToString());
                return id;
            }
            set
            {
                ViewState["DispatchProviderDocumentItemPage_DispatchProviderDocumentItemId"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeControls();
        }

        protected bool InitializeControls()
        {
            if (!IsPostBack)
            {
                string errorMessage = "";
                
                txtTagCodeAdd.Text = "";
                txtTagCodeRemove.Text = "";
                GridItem.Visible = false;
                SetComboProvider();

            }
            return true;
        }

        protected void imbAssetAdd_Click(object sender, ImageClickEventArgs e)
        {
            if(DispatchProviderDocumentItemId == -1)
            {
                GetTimeHide();
                lblError.Visible = true;
                lblError.Text = "Debe seleccionar alguna configuración antes de asignar el tag";
                //Page.ShowSmallPopupMessage("Debe seleccionar alguna configuración antes e asignar el tag");
                txtTagCodeAdd.Text = "";
                ddlNumber_SelectedIndexChanged(sender, e);
                return;
            }
            string errorMessage = "Debe seleccionar un item primero";
            DispatchProviderDocumentItem item = new BcDispatchProviderDocumentItem().GetObjById(DispatchProviderDocumentItemId);

            if (item.AssignedAmount<=item.DeclaratedAmount)
            {
                if (wdgItem.Rows.Count != 0)
                {
                    int tagId = new BcTag().GetTagByCode(txtTagCodeAdd.Text, out errorMessage);
                    if (tagId != 0)
                    {

                        Asset newAsset = new Asset();

                        newAsset.AssetId = 0;
                        newAsset.AssetUniqueIdentificationId = item.AssetUniqueIdentificationId;
                        newAsset.DispatchProviderDocumentId = int.Parse(ddlNumber.SelectedValue);
                        decimal valor = (item.ItemCost / item.ReceptionAmount);
                        newAsset.Cost = int.Parse(Math.Truncate(valor).ToString());
                        newAsset.WarrantyStartDate = DateTime.Now;
                        newAsset.IsGood = "Y";
                        newAsset.Kilometers = 0;
                        newAsset.ApplicationId = item.ApplicationId;
                        newAsset.Dot = item.Dot;
                        newAsset.ScrapTypeId = null;
                        newAsset.RepairTypeId = null;
                        newAsset.AssetSerie = null;
                        newAsset.WarrantyMounth = null;
                        newAsset.WarrantyKm = null;

                        Asset obj = new BcAsset().Save(newAsset, out errorMessage);
                        if (obj != null)
                        {
                            TagAssigned newAssigned = new TagAssigned();

                            newAssigned.AssetId = obj.AssetId;
                            newAssigned.TagId = tagId;
                            newAssigned.TagAssignedDate = DateTime.Now;
                            newAssigned.TagAssignedId = 0;

                            TagAssigned objAssig = new BcTagAssigned().Save(newAssigned, out errorMessage);
                            if (objAssig != null)
                            {
                                item.AssignedAmount = item.AssignedAmount + 1;
                                new BcDispatchProviderDocumentItem().Save(item, out errorMessage);
                                errorMessage = "Se ha asignado correctamente el activo!";

                            }
                            else
                            {
                                CommonEnums.DeletedRecordStates val = new BcAsset().DeleteAsset(obj.AssetId, out errorMessage);

                            }
                        }
                    }
                }
            }
            else
            {
                errorMessage = "Ya ha registrado el maximo posible de activos desde este item, por favor seleccionar otro item";
            }

            GetTimeHide();
            lblError.Visible = true;
            lblError.Text = errorMessage;
            //Page.ShowSmallPopupMessage(errorMessage);
            wdgItem.DataSource = new BcDispatchProviderDocumentItem().GetTableListByFilterValidate(int.Parse(ddlNumber.SelectedValue), out errorMessage);
            txtTagCodeAdd.Text = "";
        }

        protected void imbAssetRemove_Click(object sender, ImageClickEventArgs e)
        {
            if (DispatchProviderDocumentItemId == -1)
            {
                GetTimeHide();
                lblError.Visible = true;
                lblError.Text = "Debe seleccionar alguna configuración antes de desasignar el tag";
                //Page.ShowSmallPopupMessage("Debe seleccionar alguna configuración antes e asignar el tag");
                txtTagCodeAdd.Text = "";
                ddlNumber_SelectedIndexChanged(sender, e);
                return;
            }

            string errorMessage = "Debe seleccionar un item primero";
            DispatchProviderDocumentItem item = new BcDispatchProviderDocumentItem().GetObjById(DispatchProviderDocumentItemId);
            int tagId = new BcTag().GetTagButDelete(txtTagCodeRemove.Text, out errorMessage);
            TagAssigned tag = new BcTagAssigned().GetAssignedByTag(tagId,out errorMessage);
            Asset asset = new BcAsset().GetAssetById(tag.AssetId, out errorMessage);

            if (tag!=null)
            {
                if (item.AssetUniqueIdentificationId == asset.AssetUniqueIdentificationId)
                {
                    if (item.AssignedAmount >= 0)
                    {
                        new BcTagAssigned().DeleteTagAssigned(tag.TagAssignedId,out errorMessage);
                        new BcAsset().DeleteAsset(asset.AssetId,out errorMessage);
                        item.AssignedAmount = item.AssignedAmount - 1;
                        new BcDispatchProviderDocumentItem().Save(item,out errorMessage);
                        errorMessage = "El tag ha quedado limpio!";
                    }
                    else
                    {
                        errorMessage = "Ya no se puede disminuir menos el asignado de este item!";
                    }
                }
                else
                {
                    errorMessage = "Este tag no corresponde al item seleccionado! ";
                }
            }
            else
            {
                errorMessage = "El tag marcado no esta registrado!";
            }
            GetTimeHide();
            lblError.Visible = true;
            lblError.Text = errorMessage;
            //Page.ShowSmallPopupMessage(errorMessage);
            wdgItem.DataSource = new BcDispatchProviderDocumentItem().GetTableListByFilterValidate(int.Parse(ddlNumber.SelectedValue), out errorMessage);
            txtTagCodeRemove.Text = "";
        }
        
        protected void wdgItem_Selection_RowSelectionChanged(object sender, SelectedRowEventArgs e)
        {
            string errorMessage = "";
            wdgItem.DataSource = new BcDispatchProviderDocumentItem().GetTableListByFilterValidate(int.Parse(ddlNumber.SelectedValue), out errorMessage);

            DispatchProviderDocumentItemId = wdgItem.GetItemIntByKey(e.CurrentSelectedRows[0].Index, "DispatchProviderDocumentItemId");


        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Response.Redirect("SelectedAssignedPage.aspx",false);
        }

        protected void ddlProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetComboDispatchProviderNumber();
            
        }

        protected void ddlNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            string errorMessage = "";
            
            IEnumerable<object> list = new BcDispatchProviderDocumentItem().GetTableListByFilterValidate(int.Parse(ddlNumber.SelectedValue), out errorMessage);
            if (list.Count() == 0)
            {
                Page.ShowSmallPopupMessage("La guía seleccionada, no posee items para asignar.");
                if (wdgItem.Rows.Count != 0)
                {
                    GridItem.Visible = false;
                    
                }
                return;
            }
            GridItem.Visible = true;
            wdgItem.ClearDataSource();
            wdgItem.DataSource = new BcDispatchProviderDocumentItem().GetTableListByFilterValidate(int.Parse(ddlNumber.SelectedValue), out errorMessage);
            DispatchProviderDocumentItemId = -1;
        }

        protected void SetComboProvider()
        {
            string errorMessage = "";

            ddlProvider.Items.Clear();
            List<ListItem> list = new BcMember().GetProviderList(out errorMessage);

            foreach(ListItem item in list)
            {
                ddlProvider.Items.Add(item);
            }
            ddlProvider.DataBind();
        }

        protected void SetComboDispatchProviderNumber()
        {
            string errorMessage = "";
            ddlNumber.Items.Clear();
            ddlNumber.DataSource = null;
            
            List<ListItem> list = new BcDispatchProviderDocument().GetDispatchProviderDocumentNumber(int.Parse(ddlProvider.SelectedItem.Value), out errorMessage); 

            foreach (ListItem item in list)
            {
                ddlNumber.Items.Add(item);
            }
            ddlNumber.DataBind();
        }

        protected void timer_Tick(object sender, EventArgs e)
        {
            if (Session["timer"] != null)
            {
                int tiempo = (int)Session["timer"];
                if (tiempo == DateTime.Now.Second)
                {
                    timer.Enabled = false;
                    lblError.Text = "";
                    lblError.Visible = false;
                    wdgItem.Visible = true;
                    ddlNumber_SelectedIndexChanged(sender, e);
                    Session["timer"] = null;
                }
            }
        }

        protected void GetTimeHide()
        {
            timer.Enabled = true;
            timer.Interval = 25;
            int valor = 2;
            wdgItem.Visible = false;
            if (DateTime.Now.Second + valor > 59)
            {
                Session["timer"] = 2;
            }
            else { Session["timer"] = DateTime.Now.Second + valor; }
        }

    }
}