using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Infragistics.Web.UI.ListControls;

namespace amis._PresentationLayer.Users
{
    public partial class AlarmSystemPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string errorMessage = "";
            lblUserName.Text = new BcAmisUser().GetUserById(int.Parse((string)Session["IdToApplyAlarms"]), out errorMessage).Name;
            InitializeControls();
        }

        public void InitializeControls()
        {
            string errorMessage = "";
            if (!IsPostBack)
            {
                wdgMain.SetTableList(new BcAlarm(), out errorMessage);
                foreach (GridRecord row in wdgMain.Rows)
                {
                    List<UserAlarmSaved> list2 = new BcUserAlarm().GetUserAlarmList(int.Parse((string)Session["IdToApplyAlarms"]));
                    WebDropDown wddAlarms = (WebDropDown)row.Items[2].FindControl("wddUserAlarmType");
                        wddAlarms.SelectedValue = "3";
                        wddAlarms.SetComboList(new BcUserAlarmType(), out errorMessage);
                        foreach (UserAlarmSaved item in list2)
                        {
                            int alarmId = int.Parse(row.Items[0].Value.ToString());
                            if (item.AlarmId == alarmId)
                            {
                                wddAlarms.SelectedValue = item.UserAlarmTypeId.ToString();
                                wddAlarms.SetComboList(new BcUserAlarmType(), out errorMessage);
                            }
                        }
                }
            }
            else
            {
                wdgMain.SetTableList(new BcAlarm(), out errorMessage);
                foreach (GridRecord row in wdgMain.Rows)
                {
                    WebDropDown wddAlarms = (WebDropDown)row.Items[2].FindControl("wddUserAlarmType");
                    wddAlarms.SetComboList(new BcUserAlarmType(), out errorMessage);
                }
            }
        }

        protected void wibSaveChanges_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            string errorMessage = "";
            foreach (GridRecord row in wdgMain.Rows)
            {
                int userId = int.Parse((string)Session["IdToApplyAlarms"]);
                int alarmId = int.Parse(row.Items[0].Value.ToString());
                WebDropDown wddAlarms = (WebDropDown)row.Items[2].FindControl("wddUserAlarmType");
                int UserAlarmTypeId = int.Parse(wddAlarms.SelectedValue);
                UserAlarm uAlarm = new BcUserAlarm().GetUserAlarmById(alarmId, userId);

                if (uAlarm == null)
                {
                    UserAlarm newUserAlarm = new UserAlarm();
                    newUserAlarm.UserAlarmId = 0;
                    newUserAlarm.AmisUserId = userId;
                    newUserAlarm.AlarmId = alarmId;
                    newUserAlarm.UserAlarmTypeId = int.Parse(wddAlarms.SelectedValue);
                    new BcUserAlarm().Save(newUserAlarm, out errorMessage);
                }else
                {
                    uAlarm.UserAlarmTypeId = int.Parse(wddAlarms.SelectedValue);
                    new BcUserAlarm().Save(uAlarm, out errorMessage);
                }  
            }
            Page.ShowPopupMessage(errorMessage);
        }

        protected void wibReturn_Click(object sender, Infragistics.WebUI.WebDataInput.ButtonEventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/Users/RegisterUserPage.aspx");
        }
    }
}