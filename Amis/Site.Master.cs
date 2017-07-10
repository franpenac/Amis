using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using Infragistics.Web.UI.NavigationControls;

namespace amis
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // El código siguiente ayuda a proteger frente a ataques XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Utilizar el token Anti-XSRF de la cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validar el token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
                   
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string errorMessage = "";
            if (!IsPostBack)
            {
                CreateLeftMenu(int.Parse(Session["UserId"].ToString()));

                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/_PresentationLayer/Users/LoginPage.aspx");
                }
                else
                {
                    AmisUser user = new BcAmisUser().GetUserById((int)Session["UserId"], out errorMessage);
                    lnkBtnUserNameInSession.Text = user.Name;
                    if (user.AmisUserId == 1)
                    {
                        lnkBtnTextAdmin.Visible = true;
                    }
                    else
                    {
                        lnkBtnTextAdmin.Visible = false;
                    }
                }
            }
        }

        protected void CreateLeftMenu(int userId)
        {
            List<MenuOption> modules = new BcUserMenuOption().UserAuthorizedModules(userId);

            string line = GetStartMenuScript();

            foreach (MenuOption module in modules)
            {
                line = line + "<li>";
                line = line + GetAccordionMenuScript(module.Name, module.MenuOptionId);
                line = line + "<ul class=\"nav sub-nav\">";

                List <MenuOption> modulePages = new BcUserMenuOption().PagesOfModules(module.MenuOptionId, userId);
                foreach (MenuOption pag in modulePages)
                {
                    line = line + GetPageMenuScript(pag.Name, pag.PageURL);
                }
                line = line + "</ul>";
                line = line + "</li>";
            }
            line = line + "</ul>";
            line = line + "</div>";
            line = line + "</aside>";
            litMenu.Text = line;
        }

        protected string GetStartMenuScript()
        {
            string s1 = "<!-- AQUI COMIENZA TODO EL MENU LATERAL -->";
            string s2 = "<aside id=\"sidebar_left\" class=\"nano nano-light affix\">";
            string s3 = "<!-- Start: Sidebar Left Content -->";
            string s4 = "<div class=\"sidebar-left-content nano-content\">";
            string s5 = "<!-- Start: Sidebar Menu -->";
            string s6 = "<ul class=\"nav sidebar-menu\">";
            string s7 = "<li class=\"sidebar-label pt15\"></li>";
            return s1 + s2 + s3 + s4 + s5 + s6 + s7;

        }

        protected string GetAccordionMenuScript(string name, int menuId)
        {
            string icon = "";
            if (menuId == 100) icon = "fa-user";
            if (menuId == 200) icon = "fa-group";
            if (menuId == 300) icon = "fa-wrench";
            if (menuId == 400) icon = "fa-folder-open-o";
            if (menuId == 500) icon = "fa-road";
            if (menuId == 600) icon = "fa-gears";
            if (menuId == 700) icon = "fa-bar-chart-o";
            if (menuId == 1100) icon = "fa-android";

            string s1 = "<a class=\"accordion-toggle\" href=\"#\">";
            string s2 = "<span class=\"fa " + icon + "\"></span>";
            string s3 = "<span class=\"sidebar-title\">" + name.ToUpper() + "</span>";
            string s4 = "<span class=\"caret\"></span>";
            string s5 = "</a>";
            return s1 + s2 + s3 + s4 + s5;
        }

        protected string GetPageMenuScript(string name, string url)
        {
            string s1 = "<li>";
            string s2 = "<a href=\"" + url + "\">";
            string s3 = "<span class=\"\"></span>";
            string s4 = name;
            string s5 = "</a>";
            string s6 = "</li>";
            return s1 + s2 + s3 + s4 + s5 + s6;
    }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }


        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            string errorMessage = "";
            AmisUser user = new BcAmisUser().GetUserById(int.Parse(Session["UserId"].ToString()), out errorMessage);
            new BcAmisUser().LogOut(user.AmisUserId, user.Name);
            Session["UserId"] = null;
            Response.Redirect("~/_PresentationLayer/Users/LoginPage.aspx");
        }

    }

}