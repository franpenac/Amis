using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;

namespace amis._PresentationLayer.Inventory
{
    public partial class DispatchProviderDocumentPage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int DispatchProviderDocumentId
        {
            get
            {
                if (ViewState["DispatchProviderDocumentPage_DispatchProviderDocumentId"] == null)
                {
                    ViewState["DispatchProviderDocumentPage_DispatchProviderDocumentId"] = 0;
                }
                int id = int.Parse(ViewState["DispatchProviderDocumentPage_DispatchProviderDocumentId"].ToString());
                return id;
            }
            set
            {
                ViewState["DispatchProviderDocumentPage_DispatchProviderDocumentId"] = value;
            }
        }

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


        protected int RowSelected
        {
            get
            {
                if (ViewState["RowSelected"] == null)
                {
                    ViewState["RowSelected"] = 0;
                }
                int id = int.Parse(ViewState["RowSelected"].ToString());
                return id;
            }
            set
            {
                ViewState["RowSelected"] = value;
            }
        }

        protected DispatchProviderDocument GetDispatchProviderDocument
        {
            get
            {
                DispatchProviderDocument obj = new DispatchProviderDocument();
                obj.DispatchProviderDocumentId = DispatchProviderDocumentId;
                obj.DispatchProviderDocumentStateId = 2;
                obj.DocumentNumber = int.Parse(wneDispatchProviderNumber.Text);
                obj.ProviderMemberId = int.Parse(wddProvider.SelectedValue.ToString());
                obj.DispatchDate = DateTime.Now;
                return obj;
            }
        }

        protected Facility GetFacility
        {
            get
            {
                Facility obj = new Facility();

                obj.FacilityId = 0;
                obj.UnitId = null;
                obj.FacilityTypeId = 1;
                obj.WarehouseId = int.Parse(wddFacility.SelectedValue);


                return obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(601);
            h1OptionMenuPageName.InnerText = new BcMenuOption().GetMenuOptionById(int.Parse(Session["MenuOptionId"].ToString())).Name;

            this.CheckLogin();
            if (new BcUserMenuOption().ValidUserToPage(this.PageId(), this.UserId()))
            {
                this.ApplyUserPermissionsWithoutDelete(this.UserId(), this.PageId(), tdSave, tdNew, tdExportExcel);
                InitializeControls();
                SetComboMainPage();
                string parameter = Request["__EVENTARGUMENT"];
                if (parameter != null)
                {
                    if (parameter.Split(';')[0] == "wdgMain")
                    {
                        SetControlValuesFromGrid(int.Parse(parameter.Split(';')[1]));
                    }
                    if (parameter.Split(';')[0] == "ReceptionRow")
                    {
                        
                        ReceptionDispatchProviderDocument(int.Parse(parameter.Split(';')[1]));
                    }
                    if (parameter.Split(';')[0] == "AddItem")
                    {
                        SetControlValuesFromGrid(int.Parse(parameter.Split(';')[1]));
                        AddItem(int.Parse(parameter.Split(';')[1]));
                    }
                }
            }
            else
            {
                Response.Redirect("~/_PresentationLayer/Configuration/AmisHomePage.aspx");
            }
            if (wdgMain.Rows.Count < 11)
            {
                wdgMain.Behaviors.Paging.Enabled = false;
            }
            if (wdgItem.Rows.Count < 11)
            {
                wdgItem.Behaviors.Paging.Enabled = false;
            }

        }

        protected void InitializeControls()
        {
            string errorMessage = "";
            if (!IsPostBack)
            {
                New.Visible = true;
                DispatchProviderDocumentId = 0;
                wneDispatchProviderNumber.Text = "0";
                BodyDocument.Visible = false;
                wddFacility.SetComboList(new BcWarehouse(), out errorMessage);

                wddProvider.SetComboListByFiltrer(new BcMember(), 1, out errorMessage);
                DispatchProviderDocumentItemId = 0;
                wddFacility.SelectedValue = "0";
                wddProvider.SelectedValue = "0";
                wdgItem.Visible = false;

            }
            SetComboMainPage();
            if (DispatchProviderDocumentItemId != 0)
            {
                SetComboItemPage();
            }
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveDispatchProviderDocument();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            NewDispatchProviderDocument();
            
        }

        protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            ExportToExcel();
        }

        protected void wibExportToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            this.wibExportTableToExcel_Click(sender,e);
        }

        protected void wdgMain_ItemCommand(object sender, Infragistics.Web.UI.GridControls.HandleCommandEventArgs e)
        {
            
            if (e.CommandName == "ReceptionRow")
            {
                ReceptionDispatchProviderDocument(int.Parse(e.CommandArgument.ToString()));
            }
            if (e.CommandName == "AddItem")
            {
                AddItem(int.Parse(e.CommandArgument.ToString()));
            }

        }

        protected void wdgItem_ItemCommand(object sender, Infragistics.Web.UI.GridControls.HandleCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                DeleteDispatchProviderDocument(int.Parse(e.CommandArgument.ToString()));
            }
            if (e.CommandName == "PendingRow")
            {
                PendingDispatchProviderDocument(int.Parse(e.CommandArgument.ToString()));
            }
            if (e.CommandName == "ReceptionRow")
            {
                ReceptionDispatchProviderDocument(int.Parse(e.CommandArgument.ToString()));
            }
            if (e.CommandName == "AddItem")
            {
                AddItem(int.Parse(e.CommandArgument.ToString()));

            }
        }

        protected void wdgMain_Selection_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            SetControlValuesFromGrid(e.CurrentSelectedRows[0].Index);
        }

        protected void wdgItem_Selection_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            wucDispatchItem.Visible = true;

        }


        #endregion Eventos de controles graficos

        #region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void SetControlValuesFromGrid(int rowIndex)
        {
            SetComboMainPage();
            DispatchProviderDocumentId = wdgMain.GetItemIntByKey(rowIndex, "DispatchProviderDocumentId");
            wddFacility.SelectedValue = wdgMain.GetItemByKey(rowIndex, "WarehouseId");
            wneDispatchProviderNumber.Text = wdgMain.GetItemByKey(rowIndex, "DocumentNumber");
            wddProvider.SelectedValue = wdgMain.GetItemByKey(rowIndex, "MemberId");

            New.Visible = true;        }

        protected void SaveDispatchProviderDocument()
        {

            string errorMessage = "";

            if (true == new BcDispatchProviderDocument().ValidateNumberProvider(int.Parse(wneDispatchProviderNumber.Text), int.Parse(wddProvider.SelectedValue)))
            {
                if (wddProvider.SelectedValue == "0")
                {
                    Page.ShowPopupMessage("Debe seleccionar un proveedor");
                }
                    if (wddFacility.SelectedValue != "0")
                {
                    int id = new BcFacility().GetFacilityByWarehouse(int.Parse(wddFacility.SelectedValue));

                    Facility savedObjFacility = new Facility();
                    if (id == 0)
                    {
                        savedObjFacility = new BcFacility().Save(GetFacility, out errorMessage);
                    }
                    else
                    {
                        savedObjFacility.FacilityId = id;
                    }

                    if (savedObjFacility != null)
                    {
                        int FacilityId = savedObjFacility.FacilityId;

                        DispatchProviderDocument savedObj = GetDispatchProviderDocument;
                        savedObj.FacilityId = FacilityId;

                        DispatchProviderDocument obj = new BcDispatchProviderDocument().Save(savedObj, out errorMessage);
                        if (obj != null) { DispatchProviderDocumentId = obj.DispatchProviderDocumentId;
                            NewDispatchProviderDocument();
                        }
                        SetComboMainPage();
                    }
                }
                else
                {
                    errorMessage = "Debe seleccionar los datos de la bodega para poder registrar el documento.";
                }
            }
            else
            {
                errorMessage = "El numero del documento, ya existe. El proveedor "+wddProvider.SelectedItem.Text+" ya ha entregado una guia con el mismo numero.";
            }

            

            Page.ShowPopupMessage(errorMessage);
        }

        protected void NewDispatchProviderDocument()
        {
            DispatchProviderDocumentId = 0;
            wneDispatchProviderNumber.Text = "0";
            wddProvider.SelectedValue = "0";
            wddFacility.SelectedValue = "0";

        }

        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcDispatchProviderDocument());
            wdgMain.ExportToExcel();
        }

        protected void DeleteDispatchProviderDocument(int rowIndex)
        {
            string errorMessage = "";

            int Id = wdgMain.GetItemIntByKey(rowIndex, "DispatchProviderDocumentId");
            int guide = int.Parse(wdgMain.GetItemByKey(rowIndex, "DocumentNumber"));

            CommonEnums.DeletedRecordStates deleteState = new BcDispatchProviderDocument().DeleteDispatchProviderDocument(Id, guide, out errorMessage);
            if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                NewDispatchProviderDocument();
                SetComboMainPage();
            }
            Page.ShowPopupMessage(errorMessage);
        }

        protected void ReceptionDispatchProviderDocumentItem(int rowIndex)
        {
            string errorMessage = "";
            int id= wdgItem.GetItemIntByKey(rowIndex, "DispatchProviderDocumentItemId");
            DispatchProviderDocumentItem savedObj = new BcDispatchProviderDocumentItem().GetObjById(id);
            savedObj.DispatchProviderDocumentStateId = 1;
            savedObj.Observation = wteObservation.Text;
            DispatchProviderDocumentItem obj = new BcDispatchProviderDocumentItem().Save(savedObj, out errorMessage);
            if (obj == null)
            {
                errorMessage = "No fue posible cambiar el estado del item";
            }
            else
            {
                errorMessage = "Se ha cambiado el estado del item";
            }
            SetComboItemPage();
            Page.ShowPopupMessage(errorMessage);
            wucDispatchItem.Visible = true;
        }

        protected void ReceptionDispatchProviderDocument(int rowIndex)
        {
            string errorMessage = "";

            SetControlValuesFromGrid(rowIndex);
            DispatchProviderDocument savedObj = new BcDispatchProviderDocument().GetDocumentById(DispatchProviderDocumentId);
            if (savedObj.DispatchProviderDocumentStateId != 1) {
                savedObj.FacilityId = new BcFacility().GetFacilityByWarehouse(int.Parse(wddFacility.SelectedValue));
                savedObj.DispatchProviderDocumentStateId = 1;
                DispatchProviderDocument obj = new BcDispatchProviderDocument().Save(savedObj, out errorMessage);
                if (obj == null)
                {
                    lblMessage.Text = "No fue posible cambiar el estado del documento n°" + savedObj.DocumentNumber + ".";
                }
            
                else
                {
                    lblMessage.Text = "Se ha cambiado el estado del documento n°" + obj.DocumentNumber + ".";
                }
            }
            else { lblMessage.Text = "El documento n°" + savedObj.DocumentNumber + " ya ha sido recepcionado previamente."; }
            SetComboMainPage();
            mpeMessage.Show();
            mpeConfirmar.Hide();
            //Page.ShowPopupMessage(errorMessage);
        }

        protected void PendingDispatchProviderDocument(int rowIndex)
        {
            string errorMessage = "";

            SetControlValuesFromGrid(rowIndex);
            DispatchProviderDocument savedObj = GetDispatchProviderDocument;
            savedObj.FacilityId = new BcFacility().GetFacilityByWarehouse(int.Parse(wddFacility.SelectedValue));
            savedObj.DispatchProviderDocumentStateId = 3;
            DispatchProviderDocument obj = new BcDispatchProviderDocument().Save(savedObj, out errorMessage);
            if (obj == null)
            {
                errorMessage = "No fue posible cambiar el estado del documento n°" + savedObj.DocumentNumber + ".";
            }
            else
            {
                errorMessage = "Se ha cambiado el estado del documento n°" + obj.DocumentNumber + ".";
            }

        }

        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones


        protected void wibAddItem_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            //this.wucDispatchItem.InitializeControls();
            string errorMessage = "";
            if (new BcDispatchProviderDocument().ValidateStateDocument(GetDispatchProviderDocument.DispatchProviderDocumentId,out errorMessage))
            {
                if (new BcDispatchProviderDocument().ExistsDispatchProviderDocument(DispatchProviderDocumentId, out errorMessage) && DispatchProviderDocumentId != 0)
                {
                    HeaderDocument.Visible = false;
                    BodyDocument.Visible = true;
                    this.wucDispatchItem.DispatchProviderDocumentId = DispatchProviderDocumentId;
                    DispatchProviderDocumentItemId = DispatchProviderDocumentId;
                    this.wucDispatchItem.GetId(DispatchProviderDocumentId);

                    wdgMain.Visible = false;
                    wdgItem.Visible = true;
                    Buttons.Visible = false;
                    SetComboItemPage();
                }
                else
                {
                    errorMessage = "Debe seleccionar primero una guia, para poder asignarle items.";
                    Page.ShowPopupMessage(errorMessage);
                }
            }
            else
            {
                Page.ShowPopupMessage(errorMessage);
            }
            
            
        }

        protected void wibSaveItem_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string errorMessage = "";
            if (this.wucDispatchItem.Validate(out errorMessage))
            {
                this.wucDispatchItem.SaveDispatchProviderDocument();
                SetComboMainPage();
                HeaderDocument.Visible = false;
                BodyDocument.Visible = true;
                wdgMain.Visible = false;
                wdgItem.Visible = true;
                Buttons.Visible = false;
                //this.wucDispatchItem.EnableViewState = false;
                //wibBackItem_Click(sender, e);
                //wibAddItem_Click(sender, e);
                SetComboItemPage();
            }
            else
            {
                Page.ShowPopupMessage(errorMessage);
                this.wucDispatchItem.EnableViewState = true;
            }
            
        }

        protected void wibBackItem_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            this.wucDispatchItem.NewDispatchProviderDocument();

            NewDispatchProviderDocument();

            BodyDocument.Visible = false;
            HeaderDocument.Visible = true;
            Buttons.Visible = true;
            wdgMain.Visible = true;
            wdgItem.Visible = false;
        }

        protected void wibSearch_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {

            string errorMessage = "";
            int number;
            int provider;
            int indicador =0;
            
            if (wddNumberSearch.SelectedValue != "" && wddProviederSearch.SelectedValue != "" && wddNumberSearch.SelectedValue != "0" && wddProviederSearch.SelectedValue != "0")
            {
                indicador = 3;
            }
            else
            {
                if (wddNumberSearch.SelectedValue != "" && wddNumberSearch.SelectedValue != "0")
                {
                    indicador = 1;

                }

                if (wddProviederSearch.SelectedValue != "" && wddProviederSearch.SelectedValue != "0")
                {
                    indicador = 2;

                }
            }

            switch (indicador)
            {
                case 1:
                        number = int.Parse(wddNumberSearch.SelectedItem.Text);
                        wdgMain.ClearDataSource();
                        wdgMain.DataSource = new BcDispatchProviderDocument().GetTableListByFilter(number, 0, out errorMessage);
                        wdgMain.DataBind();
                        wdgMain.Visible = true;
                    break;
                case 2:
                        provider = int.Parse(wddProviederSearch.SelectedValue);
                        wdgMain.ClearDataSource();
                        wdgMain.DataSource = new BcDispatchProviderDocument().GetTableListByFilter(0, provider, out errorMessage);
                        wdgMain.DataBind();
                        wdgMain.Visible = true;
                    break;
                case 3:

                        provider = int.Parse(wddProviederSearch.SelectedValue);
                        number = int.Parse(wddNumberSearch.SelectedItem.Text);
                        wdgMain.ClearDataSource();
                        if (null != new BcDispatchProviderDocument().GetTableListByFilter(number, provider, out errorMessage))
                        {
                            wdgMain.DataSource = new BcDispatchProviderDocument().GetTableListByFilter(number, provider, out errorMessage);
                            wdgMain.DataBind();
                            if (0==wdgMain.Rows.Count)
                            {
                            errorMessage = "No se encuentra el documento con dichas caracteristicas!";
                            Page.ShowPopupMessage(errorMessage);
                            SetComboMainPage();
                            wdgMain.DataBind();
                            }

                        wdgMain.Visible = true;

                        }
                        
                        
                    break;
                default:


                    errorMessage = "El numero de guia no coincide con el proveedor.";
                    Page.ShowPopupMessage(errorMessage);

                    break;
                    
            }


        }

        protected void wibOpenSearch_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string errorMessage = "";
            wddProviederSearch.SelectedItems.Clear();
            wddNumberSearch.SelectedItems.Clear();
            wddNumberSearch.SetComboList(new BcDispatchProviderDocument(), out errorMessage);
            wddNumberSearch.SelectedValue = "0";
            wddProviederSearch.SetComboListByFiltrer(new BcMember(), 1, out errorMessage);
            wddProviederSearch.SelectedValue = "0";
            mpeAjuste.Show();
        }

        protected void wibExportExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            ExportToExcel();
            //wdgMain.SetTableList(new BcDispatchProviderDocument());
            //wdgMain.ExportToExcel();
        }

        protected void SetComboMainPage()
        {
            string errorMessage = "";
            wdgMain.SetTableList(new BcDispatchProviderDocument(), out errorMessage);
            
        }

        protected void SetComboItemPage()
        {
            string errorMessage = "";
            wdgItem.ClearDataSource();
            wdgItem.DataSource = new BcDispatchProviderDocumentItem().GetTableListByFilter(DispatchProviderDocumentId, out errorMessage);
            wdgItem.DataBind();
            for (int i = 0; i < wdgItem.Rows.Count; i++)
            {
                if (wdgItem.GetItemByKey(i, "DispatchProviderDocumentStateId").ToString() == "1")
                {
                    wdgItem.Rows[i].Items[0].FindControl("imgReception").Visible = false;

                }
            }
        }

        protected void wibConfirmar_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            ReceptionDispatchProviderDocumentItem(RowSelected);
        }

        protected void AddItem(int rowIndex)
        {
            
            
            string errorMessage = "";
            SetControlValuesFromGrid(rowIndex);
            if (new BcDispatchProviderDocument().ValidateStateDocument(GetDispatchProviderDocument.DispatchProviderDocumentId, out errorMessage))
            {
                if (new BcDispatchProviderDocument().ExistsDispatchProviderDocument(DispatchProviderDocumentId, out errorMessage) && DispatchProviderDocumentId != 0)
                {
                    Session["number"] = wdgMain.GetItemByKey(rowIndex, "DocumentNumber");
                    Session["provider"] = wdgMain.GetItemByKey(rowIndex, "MemberName");
                    this.wucDispatchItem.ChargeLbl();

                    HeaderDocument.Visible = false;
                    BodyDocument.Visible = true;
                    this.wucDispatchItem.DispatchProviderDocumentId = DispatchProviderDocumentId;
                    DispatchProviderDocumentItemId = DispatchProviderDocumentId;
                    this.wucDispatchItem.GetId(DispatchProviderDocumentId);

                    wdgMain.Visible = false;
                    wdgItem.Visible = true;
                    Buttons.Visible = false;
                    SetComboItemPage();
                }
                else
                {
                    lblMessage.Text = "Debe seleccionar primero una guia, para poder asignarle items.";
                    mpeMessage.Show();
                    mpeConfirmar.Hide();
                    //Page.ShowPopupMessage(errorMessage);
                }
            }
            else
            {
                lblMessage.Text =errorMessage;
                mpeMessage.Show();
                mpeConfirmar.Hide();
            }
            
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            mpeMessage.Hide();
            mpeConfirmar.Hide();
        }
    }
}