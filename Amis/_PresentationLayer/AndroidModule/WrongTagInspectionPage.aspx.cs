using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using amis._DataLayer.GeneratedCode;
using Infragistics.Web.UI.ListControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._PresentationLayer.AndroidModule
{
    public partial class WrongTagInspectionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CantRead"] != null)
                {
                    lblMessageForeman.Text = "Se ha enviado un mensaje a su supervisor de lectura \" No Posible\". Favor ingrese manualente la identificación de la unidad";

                }
                else
                {
                    lblMessageForeman.Text = "Se ha enviado un mensaje a su supervisor de lectura \" Tag en unidad equivocada\". Favor ingrese manualente la identificación de la unidad";
                }

                ddlSearchType.Items.Clear();
                System.Web.UI.WebControls.ListItem Default = new System.Web.UI.WebControls.ListItem("", "0");
                System.Web.UI.WebControls.ListItem Patent = new System.Web.UI.WebControls.ListItem("Patente", "1");
                System.Web.UI.WebControls.ListItem InternalNumber = new System.Web.UI.WebControls.ListItem("N° interno", "2");
                ddlSearchType.Items.Add(Default);
                ddlSearchType.Items.Add(Patent);
                ddlSearchType.Items.Add(InternalNumber);
                ddlSearchType.DataBind();
                ddlTypeSelected.Enabled = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlTypeSelected.SelectedValue != "0")
            {
                Session["IsUnit"] = false;
                Session["UnitRegisterFind"] = ddlTypeSelected.SelectedValue;
                string message = "";
                if (Session["CantRead"] != null)
                {
                    UnitRegister unit = new BcInspectionAndroid().SearchUnitById(ddlTypeSelected.SelectedValue);
                    string errorMessage = "";

                    AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
                    message = "Sr.Supervisor"+ "<br>" + "<br>" +
                        "En la revisión de la unidad " + unit.InternalNumber + "”, Patente: " + unit.PatentNumber + " no ha sido posible la lectura del TAG que identifica esa unidad." + "<br>" + "<br>" +
                        "Se sugiere revisar la situación para asegurar que exista un TAG asociado." + "<br>" + "<br>" +
                        "Para mayor información contacte con:" + "<br>" + "<br>" + 
                        "ID del usuario: " + user.Name + "<br>" + "<br>" + 
                        "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
                        "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
                        "Que tenga un buen día";
                    Session["CantRead"] = null;
                }
                else
                {
                    UnitRegister unit = new BcInspectionAndroid().SearchUnitById(ddlTypeSelected.SelectedValue);
                    Session["item"] = null;
                    Session["message"] = null;
                    Session["emailList"] = null;
                    string errorMessage = "";

                    AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
                    message = "Sr. Supervisor durante el proceso de inspección, se la realizado la lectura de la unidad " + unit.InternalNumber + "”, Patente: " + unit.PatentNumber + "<br>" +
                        "El TAG leido, no corresponde a dicha unidad. Se sugiere aclarar la situación lo antes posible."+"<br>"+
                        "Para mayor información contacte con:"+
                        "ID del usuario: " + user.Name + "<br>" +
                        "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
                        "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
                        "Que tenga un buen día";

                    
                }

                int branchOfficeid = (int)Session["BranchOfficeId"];
                int alarmId = 1;
                List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);
                Session["message"] = message;
                Session["emailList"] = emails;

                BackgroundWorker task = new BackgroundWorker();
                task.DoWork += new DoWorkEventHandler(SendEmail);
                task.RunWorkerAsync();
                if(Session["BadTyreTag"] != null)
                {
                    Session["BadTyreTag"] = null;
                    Response.Redirect("SelectionReplaceTyrePage.aspx",false);
                    return;
                }
                Session["dllAssetType"] = null;
                Response.Redirect("InspectionIndexAndroidPage",false);
            }
            else { Page.ShowSmallPopupMessage("Debe selecionar un valor para realizar la busqueda"); }
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

        protected void ddlSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSearchType.SelectedValue != "0")
            {
                ddlTypeSelected.Items.Clear();
                ddlTypeSelected.Enabled = true;

                List<UnitRegister> list = new DcWrongTagInspection().SearchUnitRegister();
                if (list != null)
                {
                    if (ddlSearchType.SelectedValue == "1")
                    {
                        foreach (UnitRegister item in list)
                        {
                            System.Web.UI.WebControls.ListItem Default = new System.Web.UI.WebControls.ListItem(item.PatentNumber, item.UnitRegisterId.ToString());
                            ddlTypeSelected.Items.Add(Default);

                        }
                    }
                    if (ddlSearchType.SelectedValue == "2")
                    {
                        foreach (UnitRegister item in list)
                        {
                            System.Web.UI.WebControls.ListItem Default = new System.Web.UI.WebControls.ListItem(item.InternalNumber.ToString(), item.UnitRegisterId.ToString());
                            ddlTypeSelected.Items.Add(Default);

                        }
                    }
                    ddlTypeSelected.DataBind();
                }
                else { Page.ShowSmallPopupMessage("No hay unidades registradas!"); }
            }

        }
    }
}