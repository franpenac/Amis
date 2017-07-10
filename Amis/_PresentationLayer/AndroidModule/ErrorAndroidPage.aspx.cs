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
    public partial class ErrorAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["SendEmail"] == null)
            {
                if (Session["ErrorNumber"] != null)
                {
                    int number = (int)Session["ErrorNumber"];
                    switch (number)
                    {
                        case 1:
                            Case1();
                            break;

                        case 2:
                            Case2();
                            break;

                        case 3:
                            Case3();
                            break;
                        case 4:
                            Case4();
                            break;
                        case 5:
                            Case5();
                            break;
                        case 6:
                            Case6();
                            break;
                        case 7:
                            Case7();
                            break;
                        case 8:
                            Case8();
                            break;
                        case 9:
                            Case9();
                            break;
                        case 10:
                            Case10();
                            break;
                        case 11:
                            Case11();
                            break;
                        case 12:
                            Case12();
                            break;
                        case 13:
                            Case13();
                            break;
                        case 14:
                            Case14();
                            break;
                        case 15:
                            Case15();
                            break;
                    }
                }
            }
        }

        protected void imgNext_Click(object sender, ImageClickEventArgs e)
        {
            if (Session["Inventory"] != null)
            {
                Session["Contador"] = null;
                Session["ListAssetNoTyreFind"] = null;
                Session["ListAssetTyreFind"] = null;
                Session["UnitRegisterFind"] = null;
                Session["ListAssetTyre"] = null;
                Session["ListAssetNoTyre"] = null;
                Session["isCorrect"] = null;
                Session["internalNumber"] = null;
                Session["Patent"] = null;
                Session["ListButtons"] = null;
                Session["UnitFind"] = null;
                Session["EventAssetTypeId"] = null;
                Session["ListButtonsToSend"] = null;
                Session["ListButtonsToChangePosition"] = null;
                Session["ListButtonsToScrap"] = null;
                Session["FinishChange"] = null;
                Session["ToScrap"] = null;
                Session["ListConfigAxleUnitType"] = null;
                Session["TyreTagPosition"] = null;
                Session["AssetVehicule"] = null;
                Session["ErrorNumber"] = 0;
                Session["ListCode"] = null;
                Session["html"] = null;
                Response.Redirect("MenuAndroidPage.aspx");
            }
            if (Session["Page"] != null)
            {
                Session["ErrorNumber"] = 0;
                Session["Page"] = null;
                Response.Redirect("AssignedToUnitAndroidPage.aspx");
            }
            if (Session["ErrorAssigned"] != null)
            {
                Session["ErrorNumber"] = 0;
                Session["ErrorAssigned"] = null;
                Response.Redirect("AssignedTyreToUnitAndroidPage.aspx");
            }
            int number = (int)Session["ErrorNumber"];
            string toGoBack = "";
            if (Session["ToBackPage"] != null)
            {
                toGoBack = (string)Session["ToBackPage"];
            }
            if (number != 7)
            {
                if (toGoBack == "SelectionTyrePage.aspx")
                {
                    Session["ErrorNumber"] = 0;
                    Response.Redirect("SelectionTyrePage.aspx");
                }
                if (Session["isFromReplace"] != null)
                {
                    Session["ErrorNumber"] = 0;
                    Response.Redirect("SelectionReplaceTyrePage.aspx");
                }
                if (Session["fromReplaceError"] != null)
                {
                    Session["fromReplaceError"] = null;
                    Response.Redirect("SelectUnitToReplaceTyre.aspx");
                }
                Session["Contador"] = null;
                Session["SendEmail"] = null;
                Session["dllAssetType"] = null;
                Response.Redirect("InspectionIndexAndroidPage.aspx");
            }
            else
            {
                if (Session["BadTyreTag"] != null)
                {
                    Session["BadTyreTag"] = null;
                    Response.Redirect("SelectionReplaceTyrePage.aspx");
                }
                else
                {
                    Response.Redirect("WrongTagInspectionPage.aspx");
                }
            }
        }

        protected void Case1()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;
            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);

            lblSubTittle.Visible = true;
            lblSubTittle.Text = "Se ha leído un TAG que no está registrado en la empresa.";

            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = "El TAG que Ud. Ha leído no está registrado en la base de datos de su empresa, se sugiere aclarar la situación con su supervisor. " +
               "\n Se ha enviado un mensaje a su supervisor.";

            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "Se ha realizado la lectura de un TAG que " +
                "no está registrado como TAG de su empresa." + "<br>" + " Se sugiere para un mejor control " +
                " realize la busqueda del TAG leído y determine su procedencia." + "<br>" + "<br>" +
                "Para mayores antecedentes comuníquese con:" + "<br>" +
                "ID del usuario: " + user.Name + "<br>" +
                "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
                "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
                "Que tenga un buen día";

            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 1;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
        }

        protected void Case2()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);

            lblSubTittle.Visible = true;
            lblSubTittle.Text = "El tag leído, no está asignado ningun activo.";

            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = "El TAG leído por Ud. no está asignado a ninguna unidad o activo, se sugiere acercarse a sus supervisor para aclarar la situación. " +
               "Se ha enviado un mensaje a su supervisor para que lo ayude a aclarar la situación.";

            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "Se acaba de realizar la lectura de un TAG que " +
                "no está asignado a ningún activo o unidad." + "<br>" + " Para efectos de un mejor control una " +
                "buena práctica es que un TAG no asignado" + "<br>" + " a un Activo o Unidad esté sólo en manos" +
                " del responsable de la asignación" + "<br>" + "<br>" +
                "Para mayores antecedentes comuníquese con:" + "<br>" +
                "ID del usuario: " + user.Name + "<br>" +
                "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
                "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
                "Que tenga un buen día";


            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 2;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
        }

        protected void Case3()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);

            lblSubTittle.Visible = true;
            lblSubTittle.Text = "TAG leído pertenece a un activo pero se ha leído una unidad.";

            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = "El TAG leído por Ud. Está asignado a una UNIDAD y no al activo que Ud. intenta inspeccionar. " +
               "Se ha enviado un mensaje a su supervisor para que lo ayude a aclarar la situación";

            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "Recientemente se ha iniciado la inspección de un ACTIVO " +
                "que tiene asociado un TAG que fue asignado a una UNIDAD." + "<br>" + " Se sugiere revisar la inconsistencia y normalizar " +
                "la asignación del TAG." + "<br>" +
                "Se ha intentado inspeccionar el activo X que pertenece a la unidad X X" + "<br>" +
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

            Session["SendEmail"] = 1;
        }

        protected void Case4()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            string tipo = (string)Session["Type"];
            string tag = (string)Session["TagAsset"];

            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());

            UnitRegister unit2 = new DcInspectionAndroid().SearchUnitByTag(tag);

            lblSubTittle.Visible = true;
            lblSubTittle.Text = "Lectura de activos asociados a la unidad, se lee un activo no asociado a una unidad.";

            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = "El TAG del activo que inspecciona no está asociado a la unidad inspeccionada. " +
                                      "Se ha enviado un mensaje a su supervisor para que lo ayude a aclarar la situación";

            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "En la inspección de activo " + tipo +
                "de la unidad " + unit.InternalNumber + ", patente" + unit.PatentNumber + ".<br>" + "Se ha detectado la lectura de un TAG que pertenece " +
                "a la unidad: " + unit2.InternalNumber + ",patente " + unit2.PatentNumber + ".<br>" +
                "Para un mejor control se sugiere aclarar de inmediato la situación. " + "<br>" +
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

            Session["SendEmail"] = 1;
        }

        protected void Case5()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            string type = (string)Session["Type"];

            lblSubTittle.Visible = true;
            lblSubTittle.Text = "El tag leido, no esta asignado a ninguna unidad";

            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = " Se ha enviado un mensaje a su supervisor avisando de esta situación.";

            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "Recientemente se ha iniciado la inspección de la unidad" +
                 unit.InternalNumber + ", patente " + unit.PatentNumber + ", durante la inspección del activo " + type + " el sistema lo reconoce como." + "<br>" + "<br>" +
                "NO asignado a ninguna unidad." + "<br>" + "<br>" +
                "Se sugiere revisar lo antes posible la situación." +
                "la asignación del TAG." + "<br>" + "<br>" +
                "Para mayores antecedentes comuníquese con:" + "<br>" + "<br>" +
                "ID del usuario: " + user.Name + "<br>" +
                "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
                "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
                "Que tenga un buen día";



            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 2;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
        }

        protected void Case6()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            //Falta completar
            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            string tipo = (string)Session["Type"];
            string tag = (string)Session["TagAsset"];
            string typeName = new BcInspectionAndroid().getAssetTypeByTag(tag);

            lblSubTittle.Visible = true;
            lblSubTittle.Text = "El TAG leído no pertenece al tipo de activo que se quiere inspeccionar.";

            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = "El TAG leído pertenece a un " + typeName + " y no al activo " + tipo + " que Ud. quiere inspeccionar. Se ha enviado un mensaje de aviso a su supervisor";

            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "Sr. Supervisor:" + "<br>" + "<br>" +
                "Se ha intentado inspeccionar el Activo " + tipo + " que pertenece a la unidad " + unit.InternalNumber + ", patente, " + unit.PatentNumber + "<br>" +
                "sin embargo el tag leido pertenece a un " + typeName + "." + "<br>" + "Se sugiere revisar la inconsistencia y normalizar " +
                "la asignación del TAG." + "<br>" + "<br>" +
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

            Session["SendEmail"] = 1;
        }

        protected void Case7()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());


            lblSubTittle.Visible = true;
            lblSubTittle.Text = "No se logrado leer el TAG de la unidad";

            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = " Debido a la imposibilidad de leer el TAG de la unidad que desea intervenir, se ha enviado un mensaje a su supervisor con el fin que se dé solución a la situación.";

            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = " Debido a la imposibilidad de leer el TAG de la unidad que desea intervenir, se ha enviado" +
                "un mensaje a su supervisor con el fin que se dé solución a la situación." + " <br>"
                +
                "Para mayores antecedentes comuníquese con:" + "<br>" +
                "ID del usuario: " + user.Name + "<br>" +
                "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
                "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
                "Que tenga un buen día";



            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 2;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
        }

        protected void Case8()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            string tipo = (string)Session["Type"];
            int assetPositionId = (int)Session["assetPositionId"];
            string positionRead = new BcAssetPosition().GetAssetPositionById(assetPositionId).PositionDescription;
            int assetId = (int)Session["AssetId"];
            Asset asset = new BcAsset().GetAssetById(assetId, out errorMessage);
            UnitAsset unitAsset = new BcUnitAsset().GetUnitAssetByAssetId(asset.AssetId, out errorMessage);
            int assetpositionId = 0;
            if (unitAsset.AssetPositionId != null)
            {
                assetpositionId = unitAsset.AssetPositionId.GetValueOrDefault();
            }
            string correctPosition = new BcAssetPosition().GetAssetPositionById(assetpositionId).PositionDescription;

            lblSubTittle.Visible = true;
            lblSubTittle.Text = " Posición de activo leído no corresponde a la registrada en AMIS";

            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = " Se ha enviado un mensaje a su supervisor indicando que  el neumático inspeccionado se encuentra en una posición diferente a la registrada.";

            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "En la inspección de la unidad con N° Interno: " +
         unit.InternalNumber + "; Patente: " + unit.PatentNumber + " se ha realizado la lectura de un neumático " +
         "de la posición " + positionRead + ", siendo que el último registro en AMIS indica que corresponde a la posición " + correctPosition + "." + "<br>" +
         "Se sugiere revisar la situación a la brevedad con el fin de evitar falta de control futuros." + "<br>" + "<br>" +
         "Para mayores antecedentes comuníquese con:" + "<br>" +
         "ID del usuario: " + user.Name + "<br>" +
         "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
         "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
         "Que tenga un buen día";



            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 4;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
        }

        protected void Case9()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            string tipo = (string)Session["Type"];
            lblSubTittle.Visible = true;
            lblSubTittle.Text = "Activo leído ha sido previamente declarado en MAL estado.";

            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = " Se ha enviado un mensaje a su supervisor indicando que el activo inspeccionado se encuentra en la condición de MALO.";

            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "En la inspección de la unidad con N° Interno: " +
         unit.InternalNumber + "; Patente: " + unit.PatentNumber + " se ha realizado la lectura de un activo " +
         "que se encuentra en un estado declarado como MALO." + "<br>" +
         "Se sugiere revisar la situación a la brevedad con el fin de evitar inconvenientes futuros en la unidad." + "<br>" + "<br>" +
         "Para mayores antecedentes comuníquese con:" + "<br>" +
         "ID del usuario: " + user.Name + "<br>" +
         "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
         "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
         "Que tenga un buen día";



            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 4;

            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
        }

        protected void Case10()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            string tagCode = (string)Session["TagCode"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            UnitRegister unit2 = new BcAssignedAssetToUnit().SearchUnitRegisterByTag(tagCode);
            lblSubTittle.Visible = true;
            string type = (string)Session["Type"];
            lblSubTittle.Text = "El TAG que Ud. ha leído considerando un “Extintor” está asociado a una unidad y no al activo “Neumático, extintor, etc.”.";
            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = "Se ha enviado un mensaje a su supervisor indicando lo sucedido.";
            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "En el proceso de inspección de la unidad “" + unit.PatentNumber + "”, “" + unit.InternalNumber + "” <br>" +
                "se ha leído un TAG en un “" + type + "” que corresponde a la identificación de la unidad “" + unit2.InternalNumber + "”, “" + unit2.PatentNumber + "”" + "<br>" +
            "Se sugiere revisar lo antes posible la situación."
            + "<br>" +
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

            Session["SendEmail"] = 1;
        }

        protected void Case11()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            string tagCode = (string)Session["TagCode"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            string type = (string)Session["SelectedType"];
            string type2 = new BcInspectionAndroid().getAssetTypeByTag(tagCode);

            lblSubTittle.Visible = true;
            lblSubTittle.Text = "El TAG que Ud. ha leído inspeccionando un “" + type + "” está asociado a una “" + type2 + "”";
            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = "Se ha enviado un mensaje a su supervisor indicando lo sucedido.";
            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "En el proceso de inspección de la unidad “" + unit.PatentNumber + "”," + "<br>"
                + " “" + unit.InternalNumber + "” se ha leído un TAG que el técnico identificó como “" + "<br>" +
                type + "”  que en realidad está asociado a una “" + type2 + "”"
            + "<br>" +
            "Se sugiere revisar lo antes posible la situación."
            + "<br>" +
            "Para mayores antecedentes comuníquese con:" + "<br>" +
            "ID del usuario: " + user.Name + "<br>" +
            "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
            "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
            "Que tenga un buen día";

            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 4;
            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
        }

        protected void Case12()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            string tagCode = (string)Session["TagCode"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            string tagUnitCode = new BcAssignedAssetToUnit().GetTagCodeUnitByTagAssigned(tagCode);
            UnitRegister unit2 = new BcAssignedAssetToUnit().SearchUnitRegisterByTag(tagUnitCode);
            string type = new BcAssignedAssetToUnit().GetAssetTypeById(id);

            lblSubTittle.Visible = true;
            lblSubTittle.Text = "El tag leido, esta asignado a otra unidad.";
            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = "El activo que intenta asignar a la unidad “" + unit.PatentNumber + "”, “" + unit.InternalNumber + "” está previamente asignado a la unidad “" + unit2.InternalNumber + "”, “" + unit2.PatentNumber + "”";
            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = " En el proceso de asignación de activos a la unidad “" + unit.PatentNumber + "”, “" + unit.InternalNumber + "”" + "<br>" +
            "se ha intentado asignar el activo “extintor”  que está asignado previamente a la unidad “" + unit2.PatentNumber + "”, “" + unit2.InternalNumber + "”" +
            "<br>"
            + "<br>" +
            "Se sugiere revisar lo antes posible la situación."
            + "<br>" +
            "Para mayores antecedentes comuníquese con:" + "<br>" +
            "ID del usuario: " + user.Name + "<br>" +
            "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
            "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
            "Que tenga un buen día";
            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 4;
            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
        }

        protected void Case13()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());

            List<Asset> AssetTyre = (List<Asset>)Session["ListAssetTyre"];
            List<Asset> AssetNoTyre = (List<Asset>)Session["ListAssetNoTyre"];
            List<Asset> AssetNoTyreFind = (List<Asset>)Session["ListAssetNoTyreFind"];
            List<Asset> AssetTyreFind = (List<Asset>)Session["ListAssetTyreFind"];

            int TyreExist = AssetTyre.Count();
            int TyreInventored = AssetTyreFind.Count();

            int AssetExist = AssetNoTyre.Count();
            int AssetInventored = AssetNoTyreFind.Count();
            Smile.ImageUrl = "~/ig_common/images/fa-smile-green.png";

            lblSubTittle.Visible = true;
            lblSubTittle.Text = "Inventario realizado";
            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = "Se ha enviado un correo a su supervisor con el resultado del inventario.";
            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "Recientemente se ha realizado un inventario," +
            "a la unidad: " + unit.InternalNumber + ", patente: " + unit.PatentNumber + "<br>" +
            "Los resultados fueron los siguientes:" +
            "<br>"
            +
            "Neumaticos existentes: " + TyreExist.ToString() +
            "<br>" +
            "Neumaticos inventariados: " + TyreInventored.ToString() +
            "<br>" +
            "Activos No neumaticos existentes: " + AssetExist.ToString() +
            "<br>" +
            "Activos No neumaticos inventariados: " + AssetInventored.ToString() +
            "<br>" +
            "Para teminos de un mejor control, se sugiere confirmar en terreno la situación."
            + "<br>" +
            "Para mayores antecedentes comuníquese con:" + "<br>" +
            "ID del usuario: " + user.Name + "<br>" +
            "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
            "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
            "Que tenga un buen día";
            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 5;
            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
        }

        protected void Case14()
        {
            Session["item"] = null;
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            string tagCode = (string)Session["TagCode"];

            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            string type = new BcInspectionAndroid().getAssetTypeByTag(tagCode);

            lblSubTittle.Visible = true;
            lblSubTittle.Text = "El TAG del activo que intenta inspeccionar como “neumático” pertenece a un activo “" + type + "”";
            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = " Se ha enviado un mensaje a su supervisor para que ayude a solucionar la situación.";
            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "Sr. Supervisor:" + "<br> En el proceso de inspección de activos no neumáticos en la unidad “" + unit.PatentNumber + "”, “" + unit.InternalNumber + "” se ha detectado" + "<br>"
                + " que el TAG indicado como perteneciente a un “neumático” pertenece a un “" + type + "”" +
                "<br>" +
            "Para teminos de un mejor control, se sugiere exclarecer la situación lo antes posible."
            + "<br>" +
            "Para mayores antecedentes comuníquese con:" + "<br>" +
            "ID del usuario: " + user.Name + "<br>" +
            "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
            "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
            "Que tenga un buen día";
            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 4;
            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
        }

        protected void Case15()
        {
            Session["message"] = null;
            Session["emailList"] = null;

            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(this.UserId(), out errorMessage);
            int id = (int)Session["UnitRegisterFind"];
            string tagCode = (string)Session["TagCode"];
            UnitRegister unit = new BcInspectionAndroid().SearchUnitById(id.ToString());
            string type = new BcInspectionAndroid().getAssetTypeByTag(tagCode);
            UnitRegister lastUnit = new BcUnitAsset().FindLastUnit(tagCode);

            lblSubTittle.Visible = true;
            lblSubTittle.Text = " El TAG del activo que intenta asignar ha sido dado de baja previamente, avise a su supervisor..";
            lblMessageForeman.Visible = true;
            lblMessageForeman.Text = "Se ha enviado un mensaje a su supervisor para que ayude a solucionar la situación.";
            lblNext.Visible = true;
            imgNext.Visible = true;

            string message = "Sr. Supervisor:" + "<br>" + "<br>" + "En el proceso de asignación en la unidad “" + unit.PatentNumber + "”, “" + unit.InternalNumber + "” se ha detectado" + "<br>"
                + " que el TAG leído ha sido previamente dado de baja. Esta TAG perteneció a un activo “" + type + "”  y su última asignación" + "<br>"
                + " fue en la unidad “" + lastUnit.PatentNumber + "”, “" + lastUnit.InternalNumber + "”."
            + "<br>" +
            "Se sugiere revisar lo antes posible la situación."
            + "<br>" +
            "Para mayores antecedentes comuníquese con:" + "<br>" +
            "ID del usuario: " + user.Name + "<br>" +
            "Fecha: " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "<br>" +
            "Hora:" + DateTime.Now.Hour + ":" + DateTime.Now.Minute + "<br>" +
            "Que tenga un buen día";
            int branchOfficeid = (int)Session["BranchOfficeId"];
            int alarmId = 4;
            List<string> emails = new BcErrorAndroid().GetEmailListSend(branchOfficeid, alarmId);

            Session["message"] = message;
            Session["emailList"] = emails;

            BackgroundWorker task = new BackgroundWorker();
            task.DoWork += new DoWorkEventHandler(SendEmail);
            task.RunWorkerAsync();

            Session["SendEmail"] = 1;
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