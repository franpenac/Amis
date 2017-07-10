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
    public partial class RegisterManyTagsAndroidPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTagsReady.Text = "";
                txtCountTimes.Text = "";
                txtContador.Text = "";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuAndroidPage.aspx");
        }

        protected void btnSaveTags_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtContador.Text) == int.Parse(txtCountTimes.Text))
            {
                string errorMessage = "";
                string tags = txtTagsReady.Text.Trim();
                char delimitador = ';';
                List<string> substrings = tags.Split(delimitador).ToList();
                foreach (var substring in substrings)
                {
                    Tag newTag = new Tag();
                    string tagCode = "";
                    tagCode = substring;
                    newTag.TagId = 0;
                    newTag.TagCode = tagCode;
                    newTag.TSOwner = "Y";
                    newTag.StartDate = DateTime.Now;
                    newTag.CustomerAssignationDate = null;
                    newTag.CancellationDate = null;
                    if (tagCode != "")
                    {
                        new BcTag().Save(newTag, out errorMessage);
                    }
                }
                tags = "";
                Page.ShowSmallPopupMessage("Tags registrados con exito!");
                txtCountTimes.Text = "";
                txtContador.Text = "";
                txtTagsReady.Text = "";
                substrings = null;
            }else
            {
                mpeOk.Show();
            }          
        }

        protected void btnNoTyreOk_Click(object sender, EventArgs e)
        {
            mpeOk.Hide();
            txtContador.Text = "";
            txtCountTimes.Text = "";
            txtTagsReady.Text = "";
        }

        protected void btnErrorCount_Click(object sender, EventArgs e)
        {
            mpeErrorCount.Show();
        }

        protected void btnErrorCountOk_Click(object sender, EventArgs e)
        {
            mpeErrorCount.Hide();
            txtCountTimes.Text = "";
        }
    }
}