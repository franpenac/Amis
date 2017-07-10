using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;

namespace amis._PresentationLayer.OperationModule
{
    public partial class UnitRegisterToOperationPage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int AssignmentId
        {
            get
            {
                if (ViewState["AssignmentPage_AssignmentId"] == null)
                {
                    ViewState["AssignmentPage_AssignmentId"] = 0;
                }
                int id = int.Parse(ViewState["AssignmentPage_AssignmentId"].ToString());
                return id;
            }
            set
            {
                ViewState["AssignmentPage_AssignmentId"] = value;
            }
        }

        protected Assignment GetAssignment
        {
            get
            {
                Assignment obj = new Assignment();
                obj.AssignmentId = AssignmentId;
                obj.AssignmentDate = DateTime.Now;
                obj.OperationId = 0;
                if (wddOperation.SelectedValue != "") obj.OperationId = int.Parse(wddOperation.SelectedValue);
                obj.UnitId = 0;
                if (wddUnit.SelectedValue != "")
                {
                    obj.UnitId = new BcAssignedAssetToUnit().GetUnitIdByUnitRegisterId(int.Parse(wddUnit.SelectedValue));

                }
                return obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(502);
            h1OptionMenuPageName.InnerText = new BcMenuOption().GetMenuOptionById(int.Parse(Session["MenuOptionId"].ToString())).Name;

            this.CheckLogin();
            if (new BcUserMenuOption().ValidUserToPage(this.PageId(), this.UserId()))
            {
                this.ApplyUserPermissions(this.UserId(), this.PageId(), tdSave, tdNew, tdExportExcel, wdgMain, "DeleteRow".ToString());
                InitializeControls();
                string parameter = Request["__EVENTARGUMENT"];
                if (parameter != null)
                {
                    if (parameter.Split(';')[0] == "wdgMain")
                    {
                        SetControlValuesFromGrid(int.Parse(parameter.Split(';')[1]));
                    }

                    if (parameter.Split(';')[0] == "wdgEnd")
                    {
                        SetControlValuesFromGrid(int.Parse(parameter.Split(';')[1]));
                        EndOperation();
                    }
                }
            }
            else
            {
                Response.Redirect("~/_PresentationLayer/Configuration/AmisHomePage.aspx");
            }
           
        }

        protected void InitializeControls()
        {
            string errorMessage = "";
            if (!IsPostBack)
            {
                
                Infragistics.Web.UI.ListControls.DropDownItem item = new Infragistics.Web.UI.ListControls.DropDownItem();
                item.Value = "0";
                item.Text = "";
                wddSearchType.Items.Add(item);
                Infragistics.Web.UI.ListControls.DropDownItem item1 = new Infragistics.Web.UI.ListControls.DropDownItem();
                item1.Value = "1";
                item1.Text = "Patente";
                wddSearchType.Items.Add(item1);
                Infragistics.Web.UI.ListControls.DropDownItem item2 = new Infragistics.Web.UI.ListControls.DropDownItem();

                item2.Value = "2";
                item2.Text = "N° Interno";
                wddSearchType.Items.Add(item2);

                //wddUnit.SetComboList(new BcUnitRegister(),out errorMessage);
                wddOperation.SetComboList(new BcOperation(), out errorMessage);

                AssignmentId = 0;
                wddSearchType.SelectedValue = "0";
                wddUnit.SelectedValue = "0";
                wddOperation.SelectedValue = "0";

            }
            wdgMain.SetTableList(new BcAssignment());
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveAssignment();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            NewAssignment();
        }

        protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            ExportToExcel();
        }

        protected void wdgMain_ItemCommand(object sender, Infragistics.Web.UI.GridControls.HandleCommandEventArgs e)
        {
            if (e.CommandName == "CancelRow")
            {
                EndAssignment(int.Parse(e.CommandArgument.ToString()));
            }
        }

        protected void wdgMain_Selection_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            SetControlValuesFromGrid(e.CurrentSelectedRows[0].Index);
        }

        #endregion Eventos de controles graficos

        #region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void SetControlValuesFromGrid(int rowIndex)
        {
            string errorMessage = "";
            wdgMain.SetTableList(new BcAssignment());
            AssignmentId = wdgMain.GetItemIntByKey(rowIndex, "AssignmentId");
            wddSearchType.SelectedValue = "1";
            wddUnit.SetComboList(new BcUnitRegister(), out errorMessage);

            wddUnit.SelectedValue = wdgMain.GetItemByKey(rowIndex, "UnitId");
            wddOperation.SelectedValue = wdgMain.GetItemByKey(rowIndex, "OperationId");
        }

        protected void SaveAssignment()
        {
            if(wddUnit.SelectedValue == "0" || wddUnit.SelectedValue=="")
            {
                Page.ShowPopupMessage("Debe seleccionar una patente para poder registrarse");
                return;
            }
            if (wddOperation.SelectedValue == "0" || wddOperation.SelectedValue == "")
            {
                Page.ShowPopupMessage("Debe seleccionar una operación para poder registrarse");
                return;
            }
            string errorMessage = "";
            if (GetAssignment.AssignmentId == 0)
            {
                Operation operation = new BcAssignment().GetOperationByUnitRegisterId(int.Parse(wddUnit.SelectedValue), out errorMessage);
                if (operation == null)
                {
                    Assignment savedObjAssignment = new BcAssignment().Save(GetAssignment, out errorMessage);
                    if (savedObjAssignment != null) AssignmentId = savedObjAssignment.AssignmentId;
                    NewAssignment();
                    wdgMain.SetTableList(new BcAssignment());
                }
            }
            else
            {
                Assignment assigned = new BcAssignment().GetAssignmentById(GetAssignment.AssignmentId, out errorMessage);
                assigned.OperationId = int.Parse(wddOperation.SelectedValue);
                assigned.UnitId = GetAssignment.UnitId;
                Assignment savedObjAssignment = new BcAssignment().Save(GetAssignment, out errorMessage);
                if (savedObjAssignment != null) AssignmentId = savedObjAssignment.AssignmentId;
                NewAssignment();
                wdgMain.SetTableList(new BcAssignment());
            }
            
            Page.ShowPopupMessage(errorMessage);
        }

        protected void NewAssignment()
        {
            AssignmentId = 0;
            wddOperation.SelectedValue = "0";

            wddUnit.Items.Clear();
            Infragistics.Web.UI.ListControls.DropDownItem Default = new Infragistics.Web.UI.ListControls.DropDownItem();
            Default.Text = "";
            Default.Value = "0";
            wddUnit.Items.Add(Default);

            wddUnit.SelectedValue = "0";
            wddSearchType.SelectedValue = "0";

        }

        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcAssignment());
            wdgMain.ExportToExcel();
        }

        protected void EndAssignment(int rowIndex)
        {
            string errorMessage = "";
            int AssignmentId = wdgMain.GetItemIntByKey(rowIndex, "AssignmentId");
            Assignment obj = new BcAssignment().GetAssignmentById(AssignmentId, out errorMessage);
            //obj.EndAssignmentDate = DateTime.Now;
            obj = new BcAssignment().Save(obj,out errorMessage);
            if (obj!=null)
            {
                errorMessage = "Se ha dado de baja la operacion "+obj.Operation.OperationName;
                NewAssignment();
                wdgMain.SetTableList(new BcAssignment());
            }
            else
            {
                errorMessage = "No se ha dado de baja la operacion " + obj.Operation.OperationName;
            }
            Page.ShowPopupMessage(errorMessage);
        }

        protected void EndOperation()
        {
            string errorMessage = "No se ha podido liberar a la unidad de la operación";
            if (GetAssignment.EndAssignmentDate == null)
            {

                Assignment assigned = new BcAssignment().GetAssignmentById(GetAssignment.AssignmentId, out errorMessage);
                DateTime? date = DateTime.Now;
                assigned.EndAssignmentDate = date;
                Assignment savedObjAssignment = new BcAssignment().Save(assigned, out errorMessage);
                if (savedObjAssignment != null)
                {
                    AssignmentId = savedObjAssignment.AssignmentId;
                    errorMessage = "La unidad ha quedado disponible para otra operación";
                    
                }
            }
            else { errorMessage = "Esta unidad ya termino su asignación a la operación"; }
            wdgMain.SetTableList(new BcAssignment());
            Page.ShowPopupMessage(errorMessage);
        }

        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void wddSearchType_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            if (wddSearchType.SelectedValue == "0") { return; }

            string errorMessage = "";
            if (wddSearchType.SelectedValue == "1")
            {
                wddUnit.SetComboList(new BcUnitRegister(), out errorMessage);
                return;
            }

            if (wddSearchType.SelectedValue == "2")
            {
                wddUnit.Items.Clear();
                List<Infragistics.Web.UI.ListControls.DropDownItem> list = new BcUnitRegister().GetInternalNumberList();

                Infragistics.Web.UI.ListControls.DropDownItem Default = new Infragistics.Web.UI.ListControls.DropDownItem();
                Default.Text = "";
                Default.Value = "0";
                wddUnit.Items.Add(Default);
                foreach (Infragistics.Web.UI.ListControls.DropDownItem item in list)
                {
                    wddUnit.Items.Add(item);
                }
                
                return;
            }
        }
    }
}