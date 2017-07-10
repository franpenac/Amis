using amis._Common;
using amis._DataLayer.GeneratedCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcErrorAndroid
    {
        public List<string> GetEmailListSend(int branchOfficeId, int alarmId)
        {
            return new DcErrorAndroid().GetEmailListSend(branchOfficeId, alarmId);
        }

        public bool SendMailAsync(string emailToSend,string messageForMail)
        {
            string errorMessage = "";
            try
            {
                SmtpClient sc = new SmtpClient("smtp.office365.com", 587);
                sc.Credentials = new System.Net.NetworkCredential("patricio.morales@techsource.cl", "PIApato2016");
                sc.EnableSsl = true;
                string msg = GetMailBody();
                msg = msg.Replace("#MESSAGE", messageForMail);
                MailMessage message = new MailMessage();
                message.Subject = "Alerta Amis "+DateTime.Now.Day+"/"+ DateTime.Now.Month+"/"+ DateTime.Now.Year+" "+DateTime.Now.Hour+":"+DateTime.Now.Minute;
                message.Body = msg;
                message.To.Add(new MailAddress(emailToSend));
                message.From = new MailAddress("patricio.morales@techsource.cl", "Amis", Encoding.UTF8);
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(msg, Encoding.UTF8, MediaTypeNames.Text.Plain);
                string html = msg + "<img src='cid:imagen' width='300px' height='100px'/>";
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
                string filepath = System.Web.Hosting.HostingEnvironment.MapPath(@"~\ig_common\images\PNG_BAJA.jpg");
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
                errorMessage = "Se ha producido un error al enviar el correo, error: " + ErrorController.GetErrorMessage(ex) + ", Por favor informe al administrador del sistema.";
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

        public string GetMailBody()
        {
            string fileName = "EmailToAlarmSheet.aspx";
            string path = System.Web.Hosting.HostingEnvironment.MapPath(@"~/_PresentationLayer/ViewMailSheet/");
            path += fileName;
            string message = File.ReadAllText(path);
            message = message.Replace("<%@ Page Language=\"" + "C#\" AutoEventWireup=\"true\" CodeBehind=\"EmailToAlarmSheet.aspx.cs\" Inherits=\"amis._PresentationLayer.ViewMailSheet.EmailToAlarmSheet\" %>", "");
            return message;
        }
    }
}