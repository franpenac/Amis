using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis._DataLayer;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infragistics.Web.UI;
using Infragistics.Web.UI.EditorControls;
using System.Net.Mail;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using amis._DataLayer.GeneratedCode;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Infragistics.Documents.Excel;
using System.IO;
using System.Net.Mime;
using System.Web;
using System.ComponentModel;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcAmisUser : ITsDropDownList
    {
        public void Copy(AmisUser objSource, ref AmisUser objDestination)
        {
            new DcAmisUser().Copy(objSource, ref objDestination);
        }

        public AmisUser Save(AmisUser objSource, out string errorMessage)
        {
            AmisUser obj = new DcAmisUser().Save(objSource, out errorMessage);
            if (obj != null)
            {
                errorMessage = "El usuario '" + objSource.Name + "' fue guardado correctamente.";
            }
            else
                errorMessage = "No fue posible guardar usuario, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;

        }

        public bool CheckEmailFormat(string EmailAComprobar, out string errorMessage)
        {
            errorMessage = "";
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(EmailAComprobar, sFormato))
            {
                if (Regex.Replace(EmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    errorMessage = "Formato de Email inválido.";
                    return false;
                }
            }
            else
            {
                errorMessage = "Formato de Email inválido.";
                return false;
            }
        }

        public AmisUser GetUserInDB(string email, string password, out string errorMessage)
        {
            errorMessage = "";
            AmisUser user = new DcAmisUser().GetUserInDB(email, password, out errorMessage);
            if (user != null)
            {
                return user;
            }
            else
                errorMessage = "Usuario o contraseña invalidos!";
            return null;

        }

        public List<AmisUser> GetUserList(out string errorMessage)
        {
            List<AmisUser> list = new DcAmisUser().GetUserList(out errorMessage);
            AmisUser us = new AmisUser();
            us.AmisUserId = 0;
            us.Email = "-";
            us.Password = "-";
            us.Enable = "-";
            us.Name = "Seleccione";
            us.CreatedDate = new DateTime();
            us.ChangePasswordCode = "-";
            us.SecretAnswer = "-";
            us.SecretQuestion = "-";
            list.Insert(0,us);
            return list;
        }

        public AmisUser GetUserByCode(string code, out string errorMessage)
        {
            AmisUser usuario = new DcAmisUser().GetUserByCode(code, out errorMessage);
            if (usuario != null)
            {
                return usuario;
            }else
            {
                errorMessage = "Codigo inválido";
                return null;
            }
        }

        public AmisUser GetUserById(int Id, out string errorMessage)
        {
            AmisUser usuario = new DcAmisUser().GetUserById(Id, out errorMessage);
            if (errorMessage == "Usuario encontrado")
            {
                errorMessage = "Usuario encontrado";
            }
            else if (errorMessage == "Usuario no encontrado")
            {
                errorMessage = "Usuario no encontrado";
                return null;
            }
            return usuario;
        }

        public string GenerateStringToChangePassword()
        {
            return Guid.NewGuid().ToString();
        }

        public string EncryptUserPassword(string str)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public bool validatePasswordSecurity(string password, out string errorMessage)
        {
            Regex regexObj = new Regex(@"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,})$");
            Boolean Matched = regexObj.IsMatch(password);
            if (Matched == false)
            {
                errorMessage = "Contraseña inválida, debe contener a lo menos 8 caracteres, números y letras. Intente nuevamente.";
                return false;
            }else
            {
                errorMessage = "";
                return true;
            }        
        }

        public bool ComparePasswords(string firstPass, string secondPass, out string errorMessage)
        {
            errorMessage = "";
            if (firstPass == secondPass)
                return true;
            else
                errorMessage = "Contraseña nueva no coincide con su confirmación.";
                return false;
        }

        public bool ValidateUserEmailExist(string UserEmail, out string errorMessage)
        {
            errorMessage = "";
            if (!new DcAmisUser().ValidateUserEmailExist(UserEmail,out errorMessage))
            {
                errorMessage = "Este miembro ya cuenta con un usuario registrado, por favor seleccione otro miembro.";
                return false;
            }
            return true;
        }

        public AmisUser GetUserByEmail(string email, out string errorMessage)
        {
            AmisUser user = new DcAmisUser().GetUserByEmail(email, out errorMessage);
            if (user != null)
            {
                return user;
            }
            else {
                errorMessage = "Este email no se encuentra registrado o es incorrecto!";
                return null;
            }
        }

        public bool SendMailAsync(string emailToSend, string verificationCode,string lbl)
        {
            string errorMessage = "";
            try
            {
                SmtpClient sc = new SmtpClient("smtp.office365.com", 587);
                sc.Credentials = new System.Net.NetworkCredential("patricio.morales@techsource.cl", "PIApato2016");
                sc.EnableSsl = true;
                string msg = GetMailBody();
                msg = msg.Replace("#CODE", verificationCode);
                msg = msg.Replace("#WEB_SITE", lbl + @"/");
                MailMessage message = new MailMessage();
                message.Subject = "Cambio de password AMIS";
                message.Body = msg;
                message.To.Add(new MailAddress(emailToSend));
                message.From = new MailAddress("patricio.morales@techsource.cl", "Amis", Encoding.UTF8);
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(msg, Encoding.UTF8, MediaTypeNames.Text.Plain);
                string html = msg + "<img src='cid:imagen' width='300px' height='100px'/>";
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
                string filepath = System.Web.Hosting.HostingEnvironment.MapPath(@"~\ig_common\images\TechnologySource1Logo.jpg");
                LinkedResource img = new LinkedResource(filepath, MediaTypeNames.Image.Jpeg);
                img.ContentId = "imagen";
                htmlView.LinkedResources.Add(img);
                message.AlternateViews.Add(plainView);
                message.AlternateViews.Add(htmlView);
                message.IsBodyHtml = true;
                sc.SendAsync(message, message);
                errorMessage += new SendCompletedEventHandler(MailSendCompleted);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Se ha producido un error al enviar el correo, error: "+ErrorController.GetErrorMessage(ex)+ ", Por favor informe al administrador del sistema.";
                return false;
            }
            
        }

        public static void MailSendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string errorMessage = "";
            MailMessage m = e.UserState as MailMessage;
            if (e.Cancelled)
            {
                errorMessage = "Email para " + m.To + "fue cancelado.";
            }
            if (e.Error != null)
            {
                errorMessage = "Email para " + m.To + "falló.";
            }
            else
            {
                errorMessage = "Email Enviado";
            }
        }

        public void ChangeUserPasswordCode(string code, string email)
        {
            string errorMessage = "";
            new DcAmisUser().ChangeUserPasswordCode(code,email, out errorMessage);
        }

        public void ChangePassword(int userId, string newPassword, out string errorMessage)
        {
            new DcAmisUser().ChangePassword(userId, newPassword, out errorMessage);
            errorMessage = "Contraseña modificada con éxito!";
        }

       public void EnabledUser(int userId, string Enabled)
        {
            string errorMessage = "";
            new DcAmisUser().EnabledUser(userId, Enabled, out errorMessage);
        }

        public string GetMailBody()
        {
            string fileName = "EmailToChangePasswordSheet.aspx";
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/_PresentationLayer/ViewMailSheet/");
            path += fileName;
            string message = File.ReadAllText(path);
            message = message.Replace("<%@ Page Language=\"" + "C#\" AutoEventWireup=\"true\" CodeBehind=\"EmailToChangePasswordSheet.aspx.cs\" Inherits=\"amis._PresentationLayer.ViewMailSheet.EmailToChangePasswordSheet\" %>", "");
            return message;
        }

        public void ChangeAmisUserFromMember(int memberId, string memberName, string memberEmail)
        {
            new DcAmisUser().ChangeAmisUserFromMember(memberId, memberName, memberEmail);
        }

        public CommonEnums.DeletedRecordStates DeleteUser(int UserId, string UserName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcAmisUser().DeleteUser(UserId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El Usuario fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el Usuario '" + UserName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El usuario '" + UserName
                + " no pudo ser eliminado. Comuníquese con el Administrador del Sistema. "
                + "El Servidor entregó el siguiente mensaje: " + errorMessage;
            return CommonEnums.DeletedRecordStates.NotDeleted;
        }

        //Metodos para enviar correo
        public string MakeImageSrcData(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] filebytes = new byte[fs.Length];
            fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
            return "data:image/jpg;base64," +
              Convert.ToBase64String(filebytes, Base64FormattingOptions.None);
        }

        public void ExportWebDataGridToExcel(WebExcelExporter webExcelExporter, WebDataGrid webDataGrid)
        {
            webExcelExporter.DataExportMode = Infragistics.Web.UI.GridControls.DataExportMode.AllDataInDataSource;
            webExcelExporter.DownloadName = "amis_exported_file.xlsx";
            webExcelExporter.Export(webDataGrid);
        }

        // Implementacion de las interfaces

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcAmisUser().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcAmisUser().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcAmisUser().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public void LogOut(int userId, string userName)
        {
            string description = "Se ha desconectado el usuario: " + userName + ", con el id: " + userId.ToString();
            new DcPageLog().Save(CommonEnums.PageActionEnum.LogOut, description);
        }
    }

}