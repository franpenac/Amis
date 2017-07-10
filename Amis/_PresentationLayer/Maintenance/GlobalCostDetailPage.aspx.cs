using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;

namespace amis._PresentationLayer.Maintenance
{
    public partial class GlobalCostDetailPage : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected int GlobalCostDetailId
        {
            get
            {
                if (ViewState["GlobalCostDetailPage_GlobalCostDetailId"] == null)
                {
                    ViewState["GlobalCostDetailPage_GlobalCostDetailId"] = 0;
                }
                int id = int.Parse(ViewState["GlobalCostDetailPage_GlobalCostDetailId"].ToString());
                return id;
            }
            set
            {
                ViewState["GlobalCostDetailPage_GlobalCostDetailId"] = value;
            }
        }

        protected GlobalCostDetail GetGlobalCostDetail
        {
            get
            {
                GlobalCostDetail obj = new GlobalCostDetail();
                obj.GlobalCostDetailId = GlobalCostDetailId;
                obj.GlobalCostId = 0;
                obj.Month = DateTime.Parse(wddAnno.SelectedItem.Text +"/"+wddMonth.SelectedItem.Text+"/"+"01");

                decimal cost = 0;
                decimal.TryParse(wneCost.Text, out cost);
                obj.Cost = cost;

                obj.Month = DateTime.Now;
                if (wddGlobalCost.SelectedValue != "") obj.GlobalCostId = int.Parse(wddGlobalCost.SelectedValue);
                return obj;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(701);
            h1OptionMenuPageName.InnerText = new BcMenuOption().GetMenuOptionById(int.Parse(Session["MenuOptionId"].ToString())).Name;

            this.CheckLogin();
            if (new BcUserMenuOption().ValidUserToPage(this.PageId(), this.UserId()))
            {
                this.ApplyUserPermissionsWithoutDelete(this.UserId(), this.PageId(),tdSave,tdNew,tdExportExcel);
                InitializeControls();
                string parameter = Request["__EVENTARGUMENT"];
                if (parameter != null)
                {
                    if (parameter.Split(';')[0] == "wdgMain")
                    {
                        SetControlValuesFromGrid(int.Parse(parameter.Split(';')[1]));
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
                wddGlobalCost.SetComboListByFiltrer(new BcGlobalCost(),1, out errorMessage);
                wddGlobalCost.SelectedValue = "0";
                GlobalCostDetailId = 0;
                wddMonth.SelectedValue = "1";
                wddAnno.SelectedValue = "2015";
            }
            wdgMain.SetTableList(new BcGlobalCostDetail());
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wibSave_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            SaveGlobalCostDetail();
        }

        protected void wibNew_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            NewGlobalCostDetail();
        }

        protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            ExportToExcel();
        }

        protected void wdgMain_ItemCommand(object sender, Infragistics.Web.UI.GridControls.HandleCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                DeleteGlobalCostDetail(int.Parse(e.CommandArgument.ToString()));
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
            wdgMain.SetTableList(new BcGlobalCostDetail());
            GlobalCostDetailId = wdgMain.GetItemIntByKey(rowIndex, "GlobalCostDetailId");
            wddGlobalCost.SelectedValue = wdgMain.GetItemByKey(rowIndex, "GlobalCostId");
            wneCost.Text = wdgMain.GetItemByKey(rowIndex, "Cost");
            DateTime date = DateTime.Parse(wdgMain.GetItemByKey(rowIndex, "Month"));
            wddMonth.SelectedValue = date.Month.ToString();
            wddAnno.SelectedValue = date.Year.ToString();
        }

        protected void SaveGlobalCostDetail()
        {
            string errorMessage = "";
            if (new BcGlobalCostDetail().Validate(GetGlobalCostDetail, out errorMessage))
            {
                GlobalCostDetail savedObj = new BcGlobalCostDetail().Save(GetGlobalCostDetail, out errorMessage);
                if (savedObj != null)
                {
                    GlobalCostDetailId = savedObj.GlobalCostDetailId;
                    wdgMain.SetTableList(new BcGlobalCostDetail());
                    this.NewGlobalCostDetail();
                }
            }
            Page.ShowPopupMessage(errorMessage);
        }

        protected void NewGlobalCostDetail()
        {
            GlobalCostDetailId = 0;
            wddGlobalCost.SelectedValue = "0";
            wneCost.Text = "";
            wddMonth.SelectedValue = "0";
            wddAnno.SelectedValue = "0";
        }

        protected void ExportToExcel()
        {
            wdgMain.SetTableList(new BcGlobalCostDetail());
            wdgMain.ExportToExcel();
        }

        protected void DeleteGlobalCostDetail(int rowIndex)
        {
            string errorMessage = "";
            int GlobalCostDetailId = wdgMain.GetItemIntByKey(rowIndex, "GlobalCostDetailId");
            CommonEnums.DeletedRecordStates deleteState = new BcGlobalCostDetail().DeleteGlobalCostDetail(GlobalCostDetailId, out errorMessage);
            if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                NewGlobalCostDetail();
                wdgMain.SetTableList(new BcGlobalCostDetail());
            }
            Page.ShowPopupMessage(errorMessage);
        }

        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        
    }
}