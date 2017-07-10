using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using amis._DataLayer.GeneratedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class ReplaceTyreOnRoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            message1.Text = "El cambio en terreno está autorizado, no olvide regularizar la situación una vez terminado el cambio.";
            message2.Text = "Se ha enviado un mensaje a su supervisor.";
            if (!IsPostBack)
            {
                NewAssigned();
            }         
        }

        protected void imgNext_Click(object sender, ImageClickEventArgs e)
        {
            SendOnRoadReplaceMessage();
            Session["Type"] = null;
            Session["AssetId"] = null;
            Session["ListConfigAxleUnitType"] = null;
            Session["TyreTagReplacePosition"] = null;
            Session["ListButtons"] = null;
            Session["TyreTagReplacePosition2"] = null;
            Session["FinishChange"] = 1;
            Response.Redirect("SelectionReplaceTyrePage.aspx", false);
        }

        protected void SendOnRoadReplaceMessage()
        {
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            UnitRegister ureg = null;
            
            if (ddlPatentOrInternalNumber.SelectedValue == "1")
            {
                 ureg = new BcUnitRegister().GetUnitRegisterByPatentNumberOrInternalNumber(ddlOptionSelected.SelectedItem.Text, "", out errorMessage);
            }
            else if (ddlPatentOrInternalNumber.SelectedValue == "2")
            {
                 ureg = new BcUnitRegister().GetUnitRegisterByPatentNumberOrInternalNumber("",ddlOptionSelected.SelectedItem.Text, out errorMessage);
            }
            Unit newUnit = new BcUnit().GetUnitByUnitRegisterId(ureg.UnitRegisterId);
            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "Se ha realizado un cambio de neumático desde la unidad N°Interno: " +
         unit.InternalNumber + "; Patente: " + unit.PatentNumber + " a la unidad N°Interno: "+ureg.InternalNumber+";Patente: "+ureg.PatentNumber+ "\n"+
         " que se encuentra fuera del taller. " + "<br>" +
         "Para mayores antecedentes comuníquese con:" + "<br>" +
         "ID del usuario: " + user.Name + "<br>" +
         "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
         "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
         "Que tenga un buen día";



            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 3;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = null;
            int assetId = 0;
            if (Session["AssetId"] != null)
            {
                 assetId = (int)Session["AssetId"];
            }
            new BcUnitAsset().ChangeUnitToAsset(newUnit.UnitId, assetId);
            new BcUnitAsset().ChangeAssetPositionId(assetId, null);
        }

        protected void NewAssigned()
        {
            ddlPatentOrInternalNumber.ClearSelection();
            ListItem Default = new ListItem("Seleccione", "0");
            ListItem Patent = new ListItem("Patente", "1");
            ListItem InternalNumber = new ListItem("N° interno", "2");

            ddlPatentOrInternalNumber.Items.Add(Default);
            ddlPatentOrInternalNumber.Items.Add(Patent);
            ddlPatentOrInternalNumber.Items.Add(InternalNumber);
            ddlPatentOrInternalNumber.DataBind();

            ddlOptionSelected.Enabled = false;
        }

        protected void ddlPatentOrInternalNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPatentOrInternalNumber.SelectedValue != "0")
            {
                ddlOptionSelected.Items.Clear();
                ddlOptionSelected.Enabled = true;
                ddlPatentOrInternalNumber.Enabled = false;
                ListItem Index = new ListItem("Seleccione", "0");
                ddlOptionSelected.Items.Add(Index);
                List<UnitRegister> list = new DcWrongTagInspection().SearchUnitRegister();
                if (list != null)
                {
                    if (ddlPatentOrInternalNumber.SelectedValue == "1")
                    {
                        foreach (UnitRegister item in list)
                        {
                            ListItem Default = new ListItem(item.PatentNumber, item.UnitRegisterId.ToString());
                            ddlOptionSelected.Items.Add(Default);

                        }
                    }
                    if (ddlPatentOrInternalNumber.SelectedValue == "2")
                    {
                        foreach (UnitRegister item in list)
                        {
                            ListItem Default = new ListItem(item.InternalNumber.ToString(), item.UnitRegisterId.ToString());
                            ddlOptionSelected.Items.Add(Default);

                        }
                    }
                    ddlOptionSelected.DataBind();
                }
                else
                {
                    ddlOptionSelected.Enabled = false;
                    Page.ShowSmallPopupMessage("No hay unidades registradas!");
                }
            }
        }

        private void SendEmail(object o, DoWorkEventArgs e)
        {
            List<string> emails = (List<string>)Session["emailList"];
            string message = (string)Session["message"];
            foreach (var item in emails)
            {
                new BcErrorAndroid().SendMailAsync(item, message);
            }
        }
    }
}