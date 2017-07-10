using amis._BusinessLayer.GeneratedCode;
using System;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Script.Services;

namespace amis._PresentationLayer.Report
{
    public partial class AmisUserTaskRegister : System.Web.UI.Page
    {
        #region Propiedades, PageLoad e inicializacion de controles graficos

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetPageId(714);
            h1OptionMenuPageName.InnerText = new BcMenuOption().GetMenuOptionById(int.Parse(Session["MenuOptionId"].ToString())).Name;

            this.CheckLogin();
            if (new BcUserMenuOption().ValidUserToPage(this.PageId(), this.UserId()))
            {
                if (!IsPostBack)
                {
                    InitializeControls();
                }
                else
                {
                    FilterAmisUserTask();

                    if (txtTaskId.Text != "")
                    {
                        SetHtmlTextBox(int.Parse(txtTaskId.Text.Split(';')[0]));
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
            wddTaskTypeId.SetComboList(new BcAmisTaskType(), out errorMessage);
            wddTaskTypeId.SelectedValue = "-1";
            wddAmisUserTaskDone.SelectedValue = "3"; // No realizadas
            txtName.Text = "";
            wdpStartDate.Value = null;
            wdpFinishDate.Value = null;
            wdgMain.DataSource = new BcAmisUserTask().GetFilterTableList(-1, 
                CommonEnums.AmisUserTaskDoneState.Both, "", null, null, this.UserId(), out errorMessage);
            wdgMain.DataBind();
            txtUserTaskDescription.Text = "";
            txtActionTaken.Text = "";
            txtActionTaken.ReadOnly = true;
            btnSaveAmisUserTaskActionTaken.Enabled = false;
        }

        #endregion Propiedades, PageLoad e inicializacion de controles graficos

        #region Eventos de controles graficos

        protected void wdgMain_InitializeRow(object sender, RowEventArgs e)
        {
            try
            {
                HtmlImage img = (HtmlImage)e.Row.Items[0].FindControl("imgAmisTaskTypeImageButton");
                img.Src = e.Row.Items[4].Text;

                ImageButton imgButton = (ImageButton)e.Row.Items[1].FindControl("imgAmisUserTaskDoneImageButton");

                if (e.Row.Items[9].Text == "Y")
                { 
                    imgButton.ImageUrl = "~/ig_common/images/ButtonChecked16x16.png";
                }
                else
                { 
                    imgButton.ImageUrl = "~/ig_common/images/ButtonUnchecked16x16.png";
                }

                string amisUserTaskId = e.Row.Items[2].Text;
                string done = e.Row.Items[9].Text;
                done = done == "Y" ? "N" : "Y";
                txtDone.Text = done;

                string js1 = "document.getElementById('txtDone').value = '" + done + "'; ";
                string js2 = "document.getElementById('txtTaskId').value = '" + amisUserTaskId + "' + ';' + '" + done + "'; ";
                string js3 = "document.getElementById('btnChangeDone').click(); ";
                string js4 = ""; // "alert(document.getElementById('txtTaskId').value + '   ' + document.getElementById('txtDone').value); ";

                imgButton.OnClientClick = js1 + js2 + js3 + js4;

            }
            catch (Exception) { }
        }

        #endregion Eventos de controles graficos

        #region Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void SetHtmlTextBox(int amisUserTaskId)
        {
            string errorMessage = "";
            

            if (wdgMain.Rows.Count > 0)
            {
                AmisUserTask ut = new BcAmisUserTask().GetAmisUserTaskById(amisUserTaskId, out errorMessage);
                if (ut != null)
                {
                    txtUserTaskDescription.Text = ut.AmisUserTaskDescription;
                    txtActionTaken.Text = ut.AmisUserTaskActionTaken;
                    txtActionTaken.ReadOnly = false;
                    btnSaveAmisUserTaskActionTaken.Enabled = true;
                    return;
                }
            }
            CleanHtmlTextBox();
        }

        protected void CleanHtmlTextBox()
        {
            txtUserTaskDescription.Text = "";
            txtActionTaken.Text = "";
            txtActionTaken.ReadOnly = true;
            btnSaveAmisUserTaskActionTaken.Enabled = false;
        }

        protected void FilterAmisUserTask()
        {
            string errorMessage = "";

            int amisTaskTypeId = int.Parse(wddTaskTypeId.SelectedValue);
            int amisUserTaskDone = int.Parse(wddAmisUserTaskDone.SelectedValue);

            CommonEnums.AmisUserTaskDoneState amisUserTaskDoneState = CommonEnums.AmisUserTaskDoneState.Both;
            if (amisUserTaskDone == 1) amisUserTaskDoneState = CommonEnums.AmisUserTaskDoneState.Done;
            if (amisUserTaskDone == 2) amisUserTaskDoneState = CommonEnums.AmisUserTaskDoneState.NotDone;

            DateTime startDate = (DateTime)wdpStartDate.Value;
            DateTime? startDate2 = null;
            if (startDate != new DateTime(1, 1, 1)) startDate2 = (DateTime)wdpStartDate.Value;

            DateTime finishDate = (DateTime)wdpFinishDate.Value;
            DateTime? finishDate2 = null;
            if (finishDate != new DateTime(1, 1, 1)) finishDate2 = (DateTime)wdpFinishDate.Value;

            wdgMain.Rows.Clear();

            wdgMain.DataSource = new BcAmisUserTask().GetFilterTableList(amisTaskTypeId, amisUserTaskDoneState, txtName.Text, startDate2, finishDate2, this.UserId(), out errorMessage);

            wdgMain.DataBind();

            if (wdgMain.Rows.Count == 0)
            {
                CleanHtmlTextBox();
            }
        }

        #endregion Validaciones y metodos para guardar, nuevo, eliminar y otras acciones

        protected void btnChangeDone_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            //if (txtDone.Text != "")
            if (txtTaskId.Text.Contains(";"))
            {
                int amisUserTaskId = int.Parse(txtTaskId.Text.Split(';')[0]);
                string done = txtTaskId.Text.Split(';')[1];
                new BcAmisUserTask().ChangeAmisUserTaskDone(amisUserTaskId, done, out errorMessage);
            }
            txtTaskId.Text = "";
            txtDone.Text = "";
            //FilterAmisUserTask();
        }

        protected void btnSaveAmisUserTaskActionTaken_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            int amisUserTaskId = int.Parse(txtTaskId.Text.Split(';')[0]);
            string done = txtTaskId.Text.Split(';')[1];
            new BcAmisUserTask().SaveAmisUserTaskActionTaken(amisUserTaskId, txtAction.Text, out errorMessage);
            txtActionTaken.Text = txtAction.Text;
        }
    }
}