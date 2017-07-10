using System;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Text.RegularExpressions;
using amis._Controls;
using amis._Common;

namespace acreditaciones.PresentationLayer
{
    public partial class DocumentDownloader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string parameters = Session["DownloadDocumentParameters"].ToString();

            //string parameters = "<table><tr><td>Numero</td><td>UNO</td></tr><tr><td>Numero2</td><td>DOS</td></tr></table>" + Convert.ToChar(206) + "xls";

            string content = parameters.Split(Convert.ToChar(206))[0].ToString();
            string extension = parameters.Split(Convert.ToChar(206))[1].ToString();

            if (".jpg .jpeg".IndexOf(extension) >= 0)
            {
                OpenFileInPage(content);
                return;
            }

            content = ControlExtension.ConvertToHtmlEntityName(content);

            if (".doc .docx .pdf".IndexOf(extension) >= 0)
            {
            }
            else if (".xls .xlsx .htm".IndexOf(extension) >= 0)
            {
                DownloadTextContent(content, extension);
            }
        }

        private void OpenFileInPage(string fileName)
        {
            try
            {
                byte[] byteArray = null;
                this.Response.ClearContent();
                this.Response.ClearHeaders();
                this.Response.Clear();

                this.Response.ContentType = GetMimeType(Path.GetExtension(fileName));
                if (fileName.Remove(0, fileName.LastIndexOf(@".") + 1) == "pdf")
                    byteArray = File.ReadAllBytes(Server.MapPath("/") + "/exportaciones_pdf/" + fileName);
                else if (fileName.Remove(0, fileName.LastIndexOf(@".") + 1) == "jpg")
                    byteArray = File.ReadAllBytes(Server.MapPath("/") + fileName.Replace(@"/", @"\").Substring(1));
                this.Response.Buffer = true;
                Response.AddHeader("Content-Disposition",
                                   "attachment; filename=\"" + fileName +
                                   "\"");
                Response.BinaryWrite(byteArray);
                Response.Cache.SetNoServerCaching();
                Response.End();
            }
            catch (Exception)
            {
            }
        }

        protected void DownloadTextContent(string content, string extension)
        {
            try
            {
                
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=ReporteStockActual." + extension);
                Response.AddHeader("Content-Length", content.Length.ToString());
                Response.ContentType = "application/octet-stream";              
                Response.Write(content);
            }
            catch (Exception ex)
            {
                string errorMessage = ErrorController.GetErrorMessage(ex);
                alertMessage.Text = string.Format(@"<input id='message' type='hidden' value='{0}' />", errorMessage);
            }
        }

        private static string GetMimeType(string extension)
        {
            //For more MIME types list http://msdn.microsoft.com/en-us/library/ms775147%28VS.85%29.aspx
            var mime = "application/octetstream";
            var ext = extension.ToLower();
            var rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (rk != null && rk.GetValue("Content Type") != null)
                mime = rk.GetValue("Content Type").ToString();
            return mime;
        }

        public string getImage(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"<img(.|\n)+?>";
            string src = string.Empty;
            HttpContext context = HttpContext.Current;

            //Change the relative URL's to absolute URL's for an image, if any in the HTML code.
            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.RightToLeft))
            {
                if (m.Success)
                {
                    string tempM = m.Value;
                    string pattern1 = "src=[\'|\"](.+?)[\'|\"]";
                    Regex reImg = new Regex(pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    Match mImg = reImg.Match(m.Value);

                    if (mImg.Success)
                    {
                        src = mImg.Value.ToLower().Replace("src=", "").Replace("\"", "");

                        if (src.ToLower().Contains("http://") == false)
                        {
                            //Insert new URL in img tag
                            src = "src=\"" + context.Request.Url.Scheme + "://" +
                                context.Request.Url.Authority + src + "\"";
                            try
                            {
                                tempM = tempM.Remove(mImg.Index, mImg.Length);
                                tempM = tempM.Insert(mImg.Index, src);

                                //insert new url img tag in whole html code
                                tempInput = tempInput.Remove(m.Index, m.Length);
                                tempInput = tempInput.Insert(m.Index, tempM);
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                }
            }
            return tempInput;
        }

        string getSrc(string input)
        {
            string pattern = "src=[\'|\"](.+?)[\'|\"]";
            System.Text.RegularExpressions.Regex reImg = new System.Text.RegularExpressions.Regex(pattern,
                System.Text.RegularExpressions.RegexOptions.IgnoreCase |

            System.Text.RegularExpressions.RegexOptions.Multiline);
            System.Text.RegularExpressions.Match mImg = reImg.Match(input);
            if (mImg.Success)
            {
                return mImg.Value.Replace("src=", "").Replace("\"", ""); ;
            }

            return string.Empty;
        }

    }
}