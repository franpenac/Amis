using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace amis._PresentationLayer.Users
{
    public partial class UserMenuOptionPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = int.Parse((string)Session["IdToApplyPermissions"]);
            this.SetPageId(901);
            h1OptionMenuPageName.InnerText = new BcMenuOption().GetMenuOptionById(int.Parse(Session["MenuOptionId"].ToString())).Name;

            this.CheckLogin();
            if (new BcUserMenuOption().ValidUserToPage(this.PageId(), this.UserId()))
            {
                if (!IsPostBack)
                {
                    InitializeControls();
                }
                List<UserMenuOptionAuthorization> list = new BcUserMenuOption().GetPagesList(userId);
                wdgMain.DataSource = list;
                wdgMain.DataBind();
            }else
            {
                Response.Redirect("~/_PresentationLayer/Configuration/AmisHomePage.aspx");
            }
        }

        protected void InitializeControls()
        {
            string errorMessage = "";
            if (!IsPostBack)
            {
                lblUserName.Text = new BcAmisUser().GetUserById(int.Parse((string)Session["IdToApplyPermissions"]), out errorMessage).Name;
                int userId = int.Parse(Session["IdToApplyPermissions"].ToString());
                List<UserMenuOptionAuthorization> list = new BcUserMenuOption().GetPagesList(userId);
                wdgMain.DataSource = list;
                wdgMain.DataBind();

            }
        }

        protected void wibExportExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {

        }

        protected void wibReturn_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/Users/RegisterUserPage.aspx");
        }

        protected void wibExportTableToExcel_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {

        }

        protected void wibSaveChanges_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string errorMessage = "";
            foreach (GridRecord row in wdgMain.Rows)
            {
                int userId = int.Parse(row.Items[2].Value.ToString());
                int menuOptionId = int.Parse(row.Items[3].Value.ToString());
                UserMenuOption userMenuOption = new BcUserMenuOption().GetUserMenuOptionById(menuOptionId,userId, out errorMessage);
                if (userMenuOption == null)
                {
                    UserMenuOption newUseM = new UserMenuOption();
                    newUseM.UserMenuOptionId = 0;
                    newUseM.AmisUserId = userId;
                    newUseM.MenuOptionId = menuOptionId;
                    CheckBox chkCanAuthorize = ((CheckBox)row.Items[4].FindControl("chkAuthorize"));
                    if (chkCanAuthorize.Checked)
                    {
                        newUseM.CanAuthorize = chkCanAuthorize.Checked ? "Y" : "N";
                        CheckBox chkCanCreate = ((CheckBox)row.Items[5].FindControl("chkCreate"));
                        newUseM.CanCreate = chkCanCreate.Checked ? "Y" : "N";
                        newUseM.CanRead = "N";
                        newUseM.CanUpdate = "N";
                        CheckBox chkCanDelete = ((CheckBox)row.Items[6].FindControl("chkDelete"));
                        newUseM.CanDelete = chkCanDelete.Checked ? "Y" : "N";
                        newUseM.CanFind = "N";
                        newUseM.CanExecute = "N";
                        newUseM.CanChange = "N";
                        newUseM.CanDoAction1 = "N";
                        newUseM.CanDoAction2 = "N";
                        newUseM.CanDoAction3 = "N";
                        newUseM.CanDoAction4 = "N";
                        newUseM.CanDoAction5 = "N";
                        newUseM.CanDoAction6 = "N";
                        newUseM.CanDoAction7 = "N";
                        CheckBox chkCanGenerateReport = ((CheckBox)row.Items[7].FindControl("chkGenerateReport"));
                        newUseM.CanGenerateReport = chkCanGenerateReport.Checked ? "Y" : "N";
                    }else
                    {
                        newUseM.CanAuthorize = "N";
                        newUseM.CanCreate = "N";
                        newUseM.CanRead = "N";
                        newUseM.CanUpdate = "N";
                        newUseM.CanDelete = "N";
                        newUseM.CanFind = "N";
                        newUseM.CanExecute = "N";
                        newUseM.CanChange = "N";
                        newUseM.CanDoAction1 = "N";
                        newUseM.CanDoAction2 = "N";
                        newUseM.CanDoAction3 = "N";
                        newUseM.CanDoAction4 = "N";
                        newUseM.CanDoAction5 = "N";
                        newUseM.CanDoAction6 = "N";
                        newUseM.CanDoAction7 = "N";
                        newUseM.CanGenerateReport = "N";
                    }
                    UserMenuOption saveUsm = new BcUserMenuOption().Save(newUseM, out errorMessage);
                }else
                {
                    CheckBox chkCanAuthorize = ((CheckBox)row.Items[4].FindControl("chkAuthorize"));
                    if (chkCanAuthorize.Checked)
                    {
                        userMenuOption.CanAuthorize = chkCanAuthorize.Checked ? "Y" : "N";
                        CheckBox chkCanCreate = ((CheckBox)row.Items[5].FindControl("chkCreate"));
                        userMenuOption.CanCreate = chkCanCreate.Checked ? "Y" : "N";
                        CheckBox chkCanDelete = ((CheckBox)row.Items[6].FindControl("chkDelete"));
                        userMenuOption.CanDelete = chkCanDelete.Checked ? "Y" : "N";
                        CheckBox chkCanGenerateReport = ((CheckBox)row.Items[7].FindControl("chkGenerateReport"));
                        userMenuOption.CanGenerateReport = chkCanGenerateReport.Checked ? "Y" : "N";
                    }else
                    {
                        userMenuOption.CanAuthorize = "N";
                        userMenuOption.CanCreate = "N";
                        userMenuOption.CanDelete = "N";
                        userMenuOption.CanGenerateReport = "N";
                    }
                    UserMenuOption saveUsm = new BcUserMenuOption().Save(userMenuOption, out errorMessage);
                }
            }
            Page.ShowPopupMessage(errorMessage);
        }

        protected void chkAuthorizeAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            foreach (GridRecord row in wdgMain.Rows)
            {
                CheckBox chkCanAuthorize = ((CheckBox)row.Items[4].FindControl("chkAuthorize"));
                if (chk.Checked)
                {
                    chkCanAuthorize.Checked = true;
                }
                else if (!chk.Checked)
                {
                    chkCanAuthorize.Checked = false;
                }
            }
        }

        protected void chkCanSaveAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            foreach (GridRecord row in wdgMain.Rows)
            {
                CheckBox chkCanAuthorize = ((CheckBox)row.Items[5].FindControl("chkCreate"));
                if (chk.Checked)
                {
                    chkCanAuthorize.Checked = true;
                }
                else if (!chk.Checked)
                {
                    chkCanAuthorize.Checked = false;
                }
            }
        }

        protected void chkCanDeleteAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            foreach (GridRecord row in wdgMain.Rows)
            {
                CheckBox chkCanAuthorize = ((CheckBox)row.Items[6].FindControl("chkDelete"));
                if (chk.Checked)
                {
                    chkCanAuthorize.Checked = true;
                }
                else if (!chk.Checked)
                {
                    chkCanAuthorize.Checked = false;
                }
            }
        }

        protected void chkGenerateReportAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            foreach (GridRecord row in wdgMain.Rows)
            {
                CheckBox chkCanAuthorize = ((CheckBox)row.Items[7].FindControl("chkGenerateReport"));
                if (chk.Checked)
                {
                    chkCanAuthorize.Checked = true;
                }
                else if (!chk.Checked)
                {
                    chkCanAuthorize.Checked = false;
                }
            }
        }
    }
}