using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

using System.Globalization;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Configuration;
using amis.Models;

namespace amis._Common
{
    public static class StringRoutines
    {
        public static string getVerDataModel = "5.19";

        public static string GetAmisWebVersion()
        {
            string s1 = @"<table style='margin: 0 auto;'><tr><td>Sitio Web</td><td></td><td>{0}</td></tr><tr><td>Versión Web</td><td></td><td>{1}</td></tr>";
            string s2 = @"<tr><td>Servidor BD</td><td></td><td>{2}</td></tr>";
            string s3 = @"<tr><td>Base de Datos</td><td></td><td>{3}</td></tr><tr><td>Versión BD</td><td></td><td>{4}</td></tr>";
            string s4 = @"<tr><td>Modelo de Datos</td><td></td><td>{5}</td></tr></table></br>";

            string format = s1 + s2 + s3 + s4;

            string version = string.Format(format, getWebSiteUrl(), getWebVersion(), getDataBaseServer(), getDataBaseName(), 
                getVerDataBase(), getVerDataModel);

            return version;
        }

        public static string GetAmisAppVersion(string webAppAndroid, string verAppAndroid)
        {
            string s1 = @"<table><tr><td>Sitio Web</td><td>{0}</td></tr><tr><td>Versión Web</td><td>{1}</td></tr>";
            string s2 = @"<tr><td>Servidor BD</td><td>{2}</td></tr>";
            string s3 = @"<tr><td>Base de Datos</td><td>{3}</td></tr><tr><td>Versión BD</td><td>{4}</td></tr>";
            string s4 = @"<tr><td>Modelo de Datos</td><td>{5}</td></tr>";
            string s5 = @"<tr><td>Web APP</td><td>{6}</td></tr><tr><td>Versión APP</td><td>{7}</td></tr></table>";

            string format = s1 + s2 + s3 + s4 + s5;

            string version = string.Format(format, getWebSiteUrl(), getWebVersion(), getDataBaseServer(), getDataBaseName(),
                getVerDataBase(), webAppAndroid, verAppAndroid, getVerDataModel);

            return version;
        }

        public static string getWebSiteUrl()
        {
            string webSiteUrl = HttpContext.Current.Request.Url.GetComponents(UriComponents.HostAndPort, UriFormat.Unescaped);
            return webSiteUrl;
        }

        public static string getWebVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string webVersion = fvi.FileVersion.ToString();
            return webVersion;
        }

        public static string getDataBaseServer()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            string dataBaseServer = connectionString.Split(new string[] { "data source=" }, StringSplitOptions.None)[1].Split(';')[0];
            return dataBaseServer;
        }

        public static string getDataBaseName()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;
            string dataBaseName = connectionString.Split(new string[] { "initial catalog=" }, StringSplitOptions.None)[1].Split(';')[0];
            return dataBaseName;
        }

        public static string getVerDataBase()
        {
            string verDataBase = "2.1"; //todo: hacer SP
            return verDataBase;
        }

        public class EmailTools
        {
            bool invalid = false;

            public bool IsValidEmail(string strIn)
            {
                invalid = false;
                if (String.IsNullOrEmpty(strIn))
                    return false;

                // Use IdnMapping class to convert Unicode domain names.
                try
                {
                    strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                          RegexOptions.None, TimeSpan.FromMilliseconds(200));
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }

                if (invalid)
                    return false;

                // Return true if strIn is in valid e-mail format.
                try
                {
                    return Regex.IsMatch(strIn,
                          @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                          RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
                }
                catch (RegexMatchTimeoutException)
                {
                    return false;
                }
            }

            private string DomainMapper(Match match)
            {
                // IdnMapping class with default property values.
                IdnMapping idn = new IdnMapping();

                string domainName = match.Groups[2].Value;
                try
                {
                    domainName = idn.GetAscii(domainName);
                }
                catch (ArgumentException)
                {
                    invalid = true;
                }
                return match.Groups[1].Value + domainName;
            }
        }

        public static bool CheckEmptyString(ref string text, string fieldName, out string errorMessage)
        {
            errorMessage = "";
            text = text.Replace(" ", "");
            if (text == "")
            {
                errorMessage = string.Format("El campo '{0}' no puede estar vacío", fieldName);
                return false;
            }
            return true;
        }

        public static string FormatMontoToString(decimal monto)
        {
            return (long.Parse(monto.ToString())).ToString("#,##0");
        }

        public static string FormatMontoToString(int monto)
        {
            return (long.Parse(monto.ToString())).ToString("#,##0");
        }

        public static string FormatMontoToString(long monto)
        {
            return (long.Parse(monto.ToString())).ToString("#,##0");
        }

        public static string FormatNegativeMontoToString(long monto)
        {
            return (long.Parse(monto.ToString())).ToString("#,##0;-#,##0");
        }

        static public string ConvertToHtmlEntityName(string text)
        {
            var html = text;
            html = html.Replace("À", "&Agrave;"); // capital a, grave accent
            html = html.Replace("Á", "&Aacute;"); // capital a, acute accent
            html = html.Replace("Â", "&Acirc;"); // capital a, circumflex accent
            html = html.Replace("Ã", "&Atilde;"); // capital a, tilde
            html = html.Replace("Ä", "&Auml;"); // capital a, umlaut mark
            html = html.Replace("Å", "&Aring;"); // capital a, ring
            html = html.Replace("Æ", "&AElig;"); // capital ae
            html = html.Replace("Ç", "&Ccedil;"); // capital c, cedilla
            html = html.Replace("È", "&Egrave;"); // capital e, grave accent
            html = html.Replace("É", "&Eacute;"); // capital e, acute accent
            html = html.Replace("Ê", "&Ecirc;"); // capital e, circumflex accent
            html = html.Replace("Ë", "&Euml;"); // capital e, umlaut mark
            html = html.Replace("Ì", "&Igrave;"); // capital i, grave accent
            html = html.Replace("Í", "&Iacute;"); // capital i, acute accent
            html = html.Replace("Î", "&Icirc;"); // capital i, circumflex accent
            html = html.Replace("Ï", "&Iuml;"); // capital i, umlaut mark
            html = html.Replace("Ð", "&ETH;"); // capital eth, Icelandic
            html = html.Replace("Ñ", "&Ntilde;"); // capital n, tilde
            html = html.Replace("Ò", "&Ograve;"); // capital o, grave accent
            html = html.Replace("Ó", "&Oacute;"); // capital o, acute accent
            html = html.Replace("Ô", "&Ocirc;"); // capital o, circumflex accent
            html = html.Replace("Õ", "&Otilde;"); // capital o, tilde
            html = html.Replace("Ö", "&Ouml;"); // capital o, umlaut mark
            html = html.Replace("Ø", "&Oslash;"); // capital o, slash
            html = html.Replace("Ù", "&Ugrave;"); // capital u, grave accent
            html = html.Replace("Ú", "&Uacute;"); // capital u, acute accent
            html = html.Replace("Û", "&Ucirc;"); // capital u, circumflex accent
            html = html.Replace("Ü", "&Uuml;"); // capital u, umlaut mark
            html = html.Replace("Ý", "&Yacute;"); // capital y, acute accent
            html = html.Replace("Þ", "&THORN;"); // capital THORN, Icelandic
            html = html.Replace("ß", "&szlig;"); // small sharp s, German
            html = html.Replace("à", "&agrave;"); // small a, grave accent
            html = html.Replace("á", "&aacute;"); // small a, acute accent
            html = html.Replace("â", "&acirc;"); // small a, circumflex accent
            html = html.Replace("ã", "&atilde;"); // small a, tilde
            html = html.Replace("ä", "&auml;"); // small a, umlaut mark
            html = html.Replace("å", "&aring;"); // small a, ring
            html = html.Replace("æ", "&aelig;"); // small ae
            html = html.Replace("ç", "&ccedil;"); // small c, cedilla
            html = html.Replace("è", "&egrave;"); // small e, grave accent
            html = html.Replace("é", "&eacute;"); // small e, acute accent
            html = html.Replace("ê", "&ecirc;"); // small e, circumflex accent
            html = html.Replace("ë", "&euml;"); // small e, umlaut mark
            html = html.Replace("ì", "&igrave;"); // small i, grave accent
            html = html.Replace("í", "&iacute;"); // small i, acute accent
            html = html.Replace("î", "&icirc;"); // small i, circumflex accent
            html = html.Replace("ï", "&iuml;"); // small i, umlaut mark
            html = html.Replace("ð", "&eth;"); // small eth, Icelandic
            html = html.Replace("ñ", "&ntilde;"); // small n, tilde
            html = html.Replace("ò", "&ograve;"); // small o, grave accent
            html = html.Replace("ó", "&oacute;"); // small o, acute accent
            html = html.Replace("ô", "&ocirc;"); // small o, circumflex accent
            html = html.Replace("õ", "&otilde;"); // small o, tilde
            html = html.Replace("ö", "&ouml;"); // small o, umlaut mark
            html = html.Replace("ø", "&oslash;"); // small o, slash
            html = html.Replace("ù", "&ugrave;"); // small u, grave accent
            html = html.Replace("ú", "&uacute;"); // small u, acute accent
            html = html.Replace("û", "&ucirc;"); // small u, circumflex accent
            html = html.Replace("ü", "&uuml;"); // small u, umlaut mark
            html = html.Replace("ý", "&yacute;"); // small y, acute accent
            html = html.Replace("þ", "&thorn;"); // small thorn, Icelandic
            html = html.Replace("ÿ", "&yuml;"); // small y, umlaut mark
            html = html.Replace("°", "&deg;");
            //html = html.Replace("±", "&plusmn;");
            //html = html.Replace("²", "&sup2;");
            //html = html.Replace("³", "&sup3;");
            //html = html.Replace("´", "&acute;");
            //html = html.Replace("µ", "&micro;");
            //html = html.Replace("¶", "&para;");
            //html = html.Replace("·", "&middot;");
            //html = html.Replace("¸", "&cedil;");
            //html = html.Replace("¹", "&sup1;");
            //html = html.Replace("º", "&ordm;");
            //html = html.Replace("»", "&raquo;");
            //html = html.Replace("¼", "&frac14;");
            //html = html.Replace("½", "&frac12;");
            //html = html.Replace("¾", "&frac34;");
            //html = html.Replace("¿", "&iquest;");
            //html = html.Replace(" ", "&nbsp;");
            //html = html.Replace("¡", "&iexcl;");
            //html = html.Replace("¢", "&cent;");
            //html = html.Replace("£", "&pound;");
            //html = html.Replace("¤", "&curren;");
            //html = html.Replace("¥", "&yen;");
            //html = html.Replace("¦", "&brvbar;");
            //html = html.Replace("§", "&sect;");
            //html = html.Replace("¨", "&uml;");
            //html = html.Replace("©", "&copy;");
            //html = html.Replace("ª", "&ordf;");
            //html = html.Replace("«", "&laquo;");
            //html = html.Replace("¬", "&not;");
            //html = html.Replace("-", "&shy;");
            //html = html.Replace("®", "&reg;");
            //html = html.Replace("¯", "&macr;");
            //html = html.Replace("×", "&times;");
            //html = html.Replace("÷", "&divide;");
            //html = html.Replace("þ", "&thorn;");
            //html = html.Replace("ÿ", "&yuml;");
            //html = html.Replace("€", "&euro;");
            return html;
        }

        public static string ConvertToHtmlEntityNumber(string text)
        {
            var html = text;
            html = html.Replace("À", "&#192;");
            html = html.Replace("Á", "&#193;");
            html = html.Replace("Â", "&#194;");
            html = html.Replace("Ã", "&#195;");
            html = html.Replace("Ä", "&#196;");
            html = html.Replace("Å", "&#197;");
            html = html.Replace("Æ", "&#198;");
            html = html.Replace("Ç", "&#199;");
            html = html.Replace("È", "&#200;");
            html = html.Replace("É", "&#201;");
            html = html.Replace("Ê", "&#202;");
            html = html.Replace("Ë", "&#203;");
            html = html.Replace("Ì", "&#204;");
            html = html.Replace("Í", "&#205;");
            html = html.Replace("Î", "&#206;");
            html = html.Replace("Ï", "&#207;");
            html = html.Replace("Ð", "&#208;");
            html = html.Replace("Ñ", "&#209;");
            html = html.Replace("Ò", "&#210;");
            html = html.Replace("Ó", "&#211;");
            html = html.Replace("Ô", "&#212;");
            html = html.Replace("Õ", "&#213;");
            html = html.Replace("Ö", "&#214;");
            html = html.Replace("×", "&#215;");
            html = html.Replace("Ø", "&#216;");
            html = html.Replace("Ù", "&#217;");
            html = html.Replace("Ú", "&#218;");
            html = html.Replace("Û", "&#219;");
            html = html.Replace("Ü", "&#220;");
            html = html.Replace("Ý", "&#221;");
            html = html.Replace("Þ", "&#222;");
            html = html.Replace("ß", "&#223;");
            html = html.Replace("à", "&#224;");
            html = html.Replace("á", "&#225;");
            html = html.Replace("â", "&#226;");
            html = html.Replace("ã", "&#227;");
            html = html.Replace("ä", "&#228;");
            html = html.Replace("å", "&#229;");
            html = html.Replace("æ", "&#230;");
            html = html.Replace("ç", "&#231;");
            html = html.Replace("è", "&#232;");
            html = html.Replace("é", "&#233;");
            html = html.Replace("ê", "&#234;");
            html = html.Replace("ë", "&#235;");
            html = html.Replace("ì", "&#236;");
            html = html.Replace("í", "&#237;");
            html = html.Replace("î", "&#238;");
            html = html.Replace("ï", "&#239;");
            html = html.Replace("ð", "&#240;");
            html = html.Replace("ñ", "&#241;");
            html = html.Replace("ò", "&#242;");
            html = html.Replace("ó", "&#243;");
            html = html.Replace("ô", "&#244;");
            html = html.Replace("õ", "&#245;");
            html = html.Replace("ö", "&#246;");
            html = html.Replace("÷", "&#247;");
            html = html.Replace("ø", "&#248;");
            html = html.Replace("ù", "&#249;");
            html = html.Replace("ú", "&#250;");
            html = html.Replace("û", "&#251;");
            html = html.Replace("ü", "&#252;");
            html = html.Replace("ý", "&#253;");
            html = html.Replace("þ", "&#254;");
            html = html.Replace("ÿ", "&#255;");
            return html;
        }

        public static string GetStringDataImagePngBase64(string fileName)
        {
            var fs = new System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read);
            var buffer = new byte[fs.Length];
            fs.Read(buffer, 0, Convert.ToInt32(fs.Length));
            var stringDataImagePngBase64 = Convert.ToBase64String(buffer, Base64FormattingOptions.None);
            return "data:image/png;base64," + stringDataImagePngBase64;
        }

        public static bool ValidateEmailFormat(string email)
        {
            bool valid = new EmailTools().IsValidEmail(email);
            return valid;
        }
    }
}