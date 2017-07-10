using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.OperationModule
{
    public partial class OperationRegisterPage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int OperationId
        {
            get
            {
                
                if (ViewState["OperationPage_OperationId"] == null)
                {
                    ViewState["OperationPage_OperationId"] = 0;
                }
                int id = int.Parse(ViewState["OperationPage_OperationId"].ToString());
                return id;
            }
            set
            {
                ViewState["OperationPage_OperationId"] = value;
            }
        }

        protected Operation GetOperation
        {
            get
            {
                Operation obj = new Operation();
                obj.OperationId = OperationId;
                obj.OperationName = wteOperationName.Text;
                obj.BranchOfficeId = int.Parse(ddlBranchOffice.SelectedValue);
                obj.MemberId = int.Parse(ddlClientMember.SelectedValue);

                return obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(404);
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
                    if (parameter.Split(';')[0] == "wdgDelete")
                    {
                        Session["Delete"] = int.Parse(parameter.Split(';')[1]);
                        mpeConfirmar.Show();
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

        }

        protected void InitializeControls()
        {
            if (!IsPostBack)
            {
                wteOperationName.Text = "";
                OperationId = 0;
                LoadComboBranchOffice();
            }
            wdgMain.SetTableList(new BcOperation());
            wdgMain.HeaderCaptionCssClass = "igg_HeaderCaption";
          

        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void ddlBranchOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboClient();
        }

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveOperation();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            NewOperation();
        }

        protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            ExportToExcel();
        }

        protected void wibExportToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            this.wibExportTableToExcel_Click(sender,e);
        }

        protected void wibCancel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            Session["Delete"] = null;
            mpeConfirmar.Hide();
        }

        protected void wibConfirmar_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            int id = (int)Session["Delete"];
            DeleteOperation(id);
            mpeConfirmar.Hide();
        }


        protected void wdgMain_Selection_RowSelectionChanged(object sender, Infragistics.Web.UI.GridControls.SelectedRowEventArgs e)
        {
            SetControlValuesFromGrid(e.CurrentSelectedRows[0].Index);
        }

        #endregion Eventos de controles graficos

        #region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        public bool ValidateÑ(string text, out string result)
        {
            result = text;
            if (result.Contains("&#241;"))
            {

                int value = result.IndexOf("&#241;");
                result = result.Substring(0, value) + "ñ" + result.Substring(value + 6, result.Length - (value + 6));
                return true;
            }
            return false;
        }

        protected void SetControlValuesFromGrid(int rowIndex)
        {
            string errorMessage = "";
            wdgMain.SetTableList(new BcOperation());
            OperationId = wdgMain.GetItemIntByKey(rowIndex, "OperationId");
            Operation operation = new BcOperation().GetOperationById(OperationId,out errorMessage);
            string name = operation.OperationName;/*wdgMain.GetItemByKey(rowIndex, "OperationName");*/
            
            string vName = "";
            if (ValidateÑ(name, out vName))
            {
                wteOperationName.Text = vName;
            }
            else
            {
                wteOperationName.Text = name;
            }
            LoadComboBranchOffice();
            ddlBranchOffice.SelectedValue = operation.BranchOfficeId.ToString(); /*wdgMain.GetItemByKey(rowIndex, "BranchOfficeId");*/
            ddlClientMember.SelectedValue = "0";
            LoadComboClient();
                ddlClientMember.CleanDataSource();
            ddlClientMember.SelectedValue = operation.MemberId.ToString();/*wdgMain.GetItemByKey(rowIndex, "MemberId");*/
        }

        protected void SaveOperation()
        {
            string errorMessage = "";
            if (new BcOperation().Validate(GetOperation, out errorMessage))
            {
                Operation savedObj = new BcOperation().Save(GetOperation, out errorMessage);
                if (savedObj != null) OperationId = savedObj.OperationId;
                wdgMain.SetTableList(new BcOperation());
                NewOperation();
            }
            Page.ShowPopupMessage(errorMessage);
        }

        protected void NewOperation()
        {
            OperationId = 0;
            wteOperationName.Text = "";
            LoadComboBranchOffice();
            ddlBranchOffice.SelectedValue = "0";
            ddlClientMember.DataSource = null;
            ddlClientMember.Items.Clear();
            ListItem item = new ListItem();
            item.Value = "0";
            item.Text = "";
            ddlClientMember.Items.Add(item);
            ddlClientMember.SelectedValue = "0";

        }

        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcOperation());
            wdgMain.ExportToExcel();
        }

        protected void DeleteOperation(int rowIndex)
        {
            string errorMessage = "";
            int OperationId = wdgMain.GetItemIntByKey(rowIndex, "OperationId");
            string OperationName = wdgMain.GetItemByKey(rowIndex, "OperationName");
            CommonEnums.DeletedRecordStates deleteState = new BcOperation().DeleteOperation(OperationId, OperationName, out errorMessage);
            if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                NewOperation();
                wdgMain.SetTableList(new BcOperation());
            }
            Page.ShowPopupMessage(errorMessage);
        }
       
        protected void LoadComboBranchOffice()
        {
            string errorMessage = "";
            ddlBranchOffice.Items.Clear();

            List<ListItem> list = new BcOperation().GetBranchOfficeItemList(out errorMessage);

            foreach(ListItem item in list)
            {
                ddlBranchOffice.Items.Add(item);
            }
            ddlBranchOffice.SelectedValue = "0"; ;

        }

        protected void LoadComboClient()
        {
            string errorMessage = "";

            ddlClientMember.Items.Clear();

            List<ListItem> list = new BcOperation().GetClientBranchOfficeList(int.Parse(ddlBranchOffice.SelectedValue),out errorMessage);

            foreach (ListItem item in list)
            {
                ddlClientMember.Items.Add(item);
            }

            ddlClientMember.SelectedValue = "0";
        }

        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

    }
}