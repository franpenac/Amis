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
    public partial class wucDispatchItem : System.Web.UI.UserControl
    {
        
        #region Propiedades, PageLoad e inicializacion de controles graficos

        public int DispatchProviderDocumentId
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

        public DispatchProviderDocumentItem GetDispatchProviderDocumentItem
        {
            get
            {
                DispatchProviderDocumentItem obj = new DispatchProviderDocumentItem();
                obj.AssetUniqueIdentificationId = GetAssetUniqueIdentification.AssetUniqueIdentificationId;
                obj.DispatchProviderDocumentItemId = 0;
                obj.DispatchProviderDocumentId = DispatchProviderDocumentId;
                obj.DeclaratedAmount = int.Parse(wneDeclaredAmount.Value.ToString());
                obj.ReceptionAmount = int.Parse(wneReceptionAmount.Value.ToString());
                obj.ItemCost = int.Parse(wneCost.Value.ToString());
                obj.AssignedAmount = 0;
                obj.Observation = wteObservations.Value;
                if (int.Parse(wddAssetType.SelectedValue) != 1)
                {
                    obj.ManufacturerYear = int.Parse(wneManufacturerYear.Value.ToString());
                    obj.Dot = null;
                    obj.ApplicationId = null;
                }
                else
                {
                    obj.ManufacturerYear = 0;
                    obj.Dot = wteDot.Text;
                    obj.ApplicationId = int.Parse(wddApplication.SelectedValue);
                }
                if (int.Parse(wneDeclaredAmount.Value.ToString())== int.Parse(wneReceptionAmount.Value.ToString()))
                {
                    obj.DispatchProviderDocumentStateId = 1;
                }
                else
                {
                    obj.DispatchProviderDocumentStateId = 2;
                }
                
                return obj;
            }
        }

        protected AssetUniqueIdentification GetAssetUniqueIdentification
        {
            get
            {
                string errorMessage = "";
                AssetUniqueIdentification obj =
                    new BcAssetUniqueIdentification().GetUniqueIdentification(int.Parse(wddAssetType.SelectedValue), int.Parse(wddOrigin.SelectedValue),
                    int.Parse(wddAssetModel.SelectedValue), int.Parse(wddAssetModelService.SelectedValue), out errorMessage);

                return obj;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeControls();
            }

        }

        public void InitializeControls()
        {
            string errorMessage = "";
            
                wddAssetType.ClearSelection();
                wddAssetType.Items.Clear();
                wddAssetType.DataSource = null;
                List<Infragistics.Web.UI.ListControls.DropDownItem> AssetTypeList = new BcAssetUniqueIdentification().GetComboListAssetType(out errorMessage);
                foreach (Infragistics.Web.UI.ListControls.DropDownItem item in AssetTypeList)
                {
                if (item.Value != "17")
                {
                    wddAssetType.Items.Add(item);
                }
            }
                wddAssetType.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "Seleccione tipo de Activo" });
                wddAssetType.DataBind();
                wddAssetType.SelectedValue = "0";
                wneDispatchProviderDocument.Text = DispatchProviderDocumentId.ToString();

            
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wddAssetType_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            string errorMessage = "";
            if (wddAssetType.SelectedValue!="0")
            {
                wddOrigin.Items.Clear();
                wddBrand.Items.Clear();
                wddAssetModel.Items.Clear();
                wddAssetModelService.Items.Clear();
                int assetId = int.Parse(wddAssetType.SelectedValue);
                List<Infragistics.Web.UI.ListControls.DropDownItem> OriginList = new BcAssetUniqueIdentification().GetComboListOrigin(assetId, out errorMessage);
                foreach (Infragistics.Web.UI.ListControls.DropDownItem item in OriginList)
                {
                    wddOrigin.Items.Add(item);

                }
                wddOrigin.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "Seleccione Procedencia" });
                wddOrigin.DataBind();
                wddOrigin.SelectedValue = "0";
            }
            else
            {
                wddOrigin.SelectedValue = "0";
                wddOrigin.SelectedItem.Text = "";
                wddOrigin.Items.Clear();
                wddOrigin.DataSource = null;
                wddOrigin.DataBind();

                wddBrand.SelectedValue = "0";
                wddBrand.SelectedItem.Text = "";
                wddBrand.Items.Clear();
                wddBrand.DataSource = null;
                wddBrand.DataBind();

                wddAssetModel.SelectedValue = "0";
                wddAssetModel.SelectedItem.Text = "";
                wddAssetModel.Items.Clear();
                wddAssetModel.DataSource = null;
                wddAssetModel.DataBind();

                wddAssetModelService.SelectedValue = "0";
                wddAssetModelService.SelectedItem.Text = "";
                wddAssetModelService.Items.Clear();
                wddAssetModelService.DataSource = null;
                wddAssetModelService.DataBind();
            }

            if (wddAssetType.SelectedItem.Text == "Neumático")
            {
                wteDot.Enabled = true;
                wneManufacturerYear.Enabled = false;
                wneManufacturerYear.Text = "";
                wddApplication.Enabled = true;
                wddApplication.SetComboList(new BcApplication(), out errorMessage);
            }
            else
            {
                wneManufacturerYear.Enabled = true;
                wteDot.Enabled = false;
                wteDot.Text = "";
                wddApplication.Enabled = false;
                wddApplication.Items.Clear();
                wddApplication.DataSource = null;
                wddApplication.DataBind();
            }
        }

        protected void wddOrigin_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            string errorMessage = "";
            if (wddOrigin.SelectedValue != "0")
            {
                wddBrand.Items.Clear();
                wddAssetModel.Items.Clear();
                wddAssetModelService.Items.Clear();

                int assetId = int.Parse(wddAssetType.SelectedValue);
                int originId = int.Parse(wddOrigin.SelectedValue);
                List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                    new BcAssetUniqueIdentification().GetComboListBrand(assetId, originId, out errorMessage);
                foreach (Infragistics.Web.UI.ListControls.DropDownItem item in List)
                {
                    wddBrand.Items.Add(item);

                }
                wddBrand.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "Seleccione una Marca" });
                wddBrand.DataBind();
                wddBrand.SelectedValue = "0";
            }
            else
            {

                wddBrand.SelectedValue = "0";
                wddBrand.SelectedItem.Text = "";
                wddBrand.Items.Clear();
                wddBrand.DataSource = null;
                wddBrand.DataBind();

                wddAssetModel.SelectedValue = "0";
                wddAssetModel.SelectedItem.Text = "";
                wddAssetModel.Items.Clear();
                wddAssetModel.DataSource = null;
                wddAssetModel.DataBind();

                wddAssetModelService.SelectedValue = "0";
                wddAssetModelService.SelectedItem.Text = "";
                wddAssetModelService.Items.Clear();
                wddAssetModelService.DataSource = null;
                wddAssetModelService.DataBind();
            }
            
        }

        protected void wddBrand_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            string errorMessage = "";

            if (wddBrand.SelectedValue != "0")
            {
                wddAssetModel.Items.Clear();
                wddAssetModelService.Items.Clear();

                int assetId = int.Parse(wddAssetType.SelectedValue);
                int originId = int.Parse(wddOrigin.SelectedValue);
                int brandId = int.Parse(wddBrand.SelectedValue);
                List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                    new BcAssetUniqueIdentification().GetComboListModel(assetId, originId, brandId, out errorMessage);
                foreach (Infragistics.Web.UI.ListControls.DropDownItem item in List)
                {
                    wddAssetModel.Items.Add(item);

                }
                wddAssetModel.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "Seleccione un valor" });
                wddAssetModel.DataBind();
                wddAssetModel.SelectedValue = "0";
            }
            else
            {

                wddAssetModel.SelectedValue = "0";
                wddAssetModel.SelectedItem.Text = "";
                wddAssetModel.Items.Clear();
                wddAssetModel.DataSource = null;
                wddAssetModel.DataBind();

                wddAssetModelService.SelectedValue = "0";
                wddAssetModelService.SelectedItem.Text = "";
                wddAssetModelService.Items.Clear();
                wddAssetModelService.DataSource = null;
                wddAssetModelService.DataBind();
            }
            
        }

        protected void wddAssetModel_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {
            string errorMessage = "";

            if (wddAssetModel.SelectedValue != "0")
            {

                wddAssetModelService.Items.Clear();

                int assetId = int.Parse(wddAssetType.SelectedValue);
                int originId = int.Parse(wddOrigin.SelectedValue);
                int brandId = int.Parse(wddBrand.SelectedValue);
                int modelId = int.Parse(wddAssetModel.SelectedValue);

                List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                    new BcAssetUniqueIdentification().GetComboListService(assetId, originId, brandId, modelId, out errorMessage);
                foreach (Infragistics.Web.UI.ListControls.DropDownItem item in List)
                {
                    wddAssetModelService.Items.Add(item);

                }
                wddAssetModelService.Items.Add(new Infragistics.Web.UI.ListControls.DropDownItem { Value = "0", Text = "Seleccione un servicio" });
                wddAssetModelService.DataBind();
                wddAssetModelService.SelectedValue = "0";
            }
            else
            {
                wddAssetModelService.SelectedValue = "0";
                wddAssetModelService.SelectedItem.Text = "";
                wddAssetModelService.Items.Clear();
                wddAssetModelService.DataSource = null;
                wddAssetModelService.DataBind();
            }
            

        }

        protected void wddAssetModelService_SelectionChanged(object sender, Infragistics.Web.UI.ListControls.DropDownSelectionChangedEventArgs e)
        {

        }

        #endregion Eventos de controles graficos

        #region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones


        public void SaveDispatchProviderDocument()
        {
            string errorMessage = "";

            DispatchProviderDocumentItem savedObj = GetDispatchProviderDocumentItem;

            DispatchProviderDocumentItem obj = new BcDispatchProviderDocumentItem().Save(savedObj, out errorMessage);

            Page.ShowPopupMessage(errorMessage);
            NewDispatchProviderDocument();
        }

        public void NewDispatchProviderDocument()
        {
            wddAssetType.SelectedValue = "0";
            wddOrigin.SelectedValue = "0";
            wddBrand.SelectedValue = "0";
            wddAssetModel.SelectedValue = "0";
            wddAssetModelService.SelectedValue = "0";

            wneManufacturerYear.Text = "0";
            wneDeclaredAmount.Text = "0";
            wneReceptionAmount.Text = "0";
            wneCost.Text = "0";

            InitializeControls();

        }

        public void GetId(int id)
        {

            wneDispatchProviderDocument.ReadOnly = false;
            wneDispatchProviderDocument.Text = id.ToString();
            wneDispatchProviderDocument.ReadOnly=true;
        }

        public bool Validate(out string errorMessage)
        {
            int year = new BcDispatchProviderDocumentItem().ParseWneToString(wneManufacturerYear.Text);
            int cost = new BcDispatchProviderDocumentItem().ParseWneToString(wneCost.Text);
            int declared = new BcDispatchProviderDocumentItem().ParseWneToString(wneDeclaredAmount.Text);
            int recepted = new BcDispatchProviderDocumentItem().ParseWneToString(wneReceptionAmount.Text);

            string type = wddAssetType.SelectedValue;
            string origin = wddOrigin.SelectedValue;
            string brand = wddBrand.SelectedValue;
            string model = wddAssetModel.SelectedValue;
            string service = wddAssetModelService.SelectedValue;

            errorMessage = "";

            
            if (!new BcDispatchProviderDocumentItem().ValidateWdd(type,origin,brand,model,service,out errorMessage))
            {
                return false;
            }
            if (!new BcDispatchProviderDocumentItem().ValidateWne(year, declared, recepted, cost, int.Parse(wddAssetType.SelectedValue) ,out errorMessage))
            {
                return false;
            }
            return true;
        }

        public void ChargeLbl()
        {
            lblNumber.Text = "Guia N°"+(string)Session["number"];
            lblProvider.Text = "Proveedor: " + (string)Session["provider"];

        }

        protected void wneDot_TextChanged(object sender, EventArgs e)
        {
            string Dot = wteDot.Text;
            while (Dot.Length < 4)
            {
                Dot = "0" + Dot;
            }
            int week = int.Parse(Dot.Substring(0, 2));
            int year = int.Parse(Dot.Substring(2, 2));
            string currentYear = DateTime.Now.Year.ToString();
            int currentYear2 = int.Parse(currentYear.Substring(2,2));

            int acceptedYear = currentYear2 - year;

            if (week > 52 || week <= 0 || acceptedYear > 3 || wteDot.Text == "")
            {
                Page.ShowPopupMessage("El número de semana debe estar entre 01 a 52, tambíe el año de fabricación no puede superar los tres años de antiguedad desde el año actual.");
                wteDot.Text = "";
                wteDot.Focus();
            }
            wneManufacturerYear.Text = "0000";
        }

        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

    }
}
