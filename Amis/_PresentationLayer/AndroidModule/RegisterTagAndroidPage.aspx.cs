using amis._BusinessLayer.GeneratedCode;
using amis._Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace amis._PresentationLayer.AndroidModule
{
    public partial class RegisterTagAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txbTagRead.Text = "";
                Label1.Text = "";
                
            }
        }

        protected void imbAssetAdd_Click(object sender, ImageClickEventArgs e)
        {
            Tag tag = new Tag();
            string errorMessage = "";

            tag.TagId = 0;
            tag.TagCode = txbTagRead.Text;
            tag.StartDate = DateTime.Now;
            tag.TSOwner = "Y";

            Tag result = new BcTag().Save(tag, out errorMessage);
            if(result!=null){
                txbTagRead.Text = "";
                GetTimeHide();
                
                Label1.Text = "Tag registrado";
            }
            else
            {
                txbTagRead.Text = "";
                GetTimeHide();
                Label1.Text = "El TAG que intenta registrar ya está registrado previamente en AMIS";
                
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_PresentationLayer/AndroidModule/MenuAndroidPage.aspx");
        }

        protected void timer_Tick(object sender, EventArgs e)
        {
            if (Session["timer"] != null)
            {
                int tiempo = (int)Session["timer"];
                if (tiempo == DateTime.Now.Second)
                {
                    timer.Enabled = false;
                    Label1.Text = "";
                    Session["timer"] = null;
                }
            }
        }

        protected void GetTimeHide()
        {
            timer.Enabled = true;
            timer.Interval = 25;
            int valor = 2;
            if (DateTime.Now.Second + valor > 59)
            {
                Session["timer"] = 2;
            }
            else { Session["timer"] = DateTime.Now.Second + valor; }
        }
    }
}