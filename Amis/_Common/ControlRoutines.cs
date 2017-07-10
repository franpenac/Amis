using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace amis._Common
{
    public static class ControlRoutines
    {
        public static void SetErrorLabel(Label label, string text)
        {
            label.ForeColor = System.Drawing.Color.Red;
            label.Visible = (text != "");
            label.Text = text;
        }

        public static void SetLabel(Label label, string text)
        {
            label.ForeColor = System.Drawing.Color.Black;
            label.Visible = (text != "");
            label.Text = text;
        }

        public static void ErrorLabelClear(params Label[] labels)
        {
            foreach (Label lbl in labels)
            {
                ControlRoutines.SetErrorLabel(lbl, "");
            }
        }

        public static bool ShowErrorLabel(bool bValid, Label lblErrorLabel, string errorMessage)
        {
            if (!bValid)
            {
                if (lblErrorLabel != null)
                {
                    ShowErrorLabel(lblErrorLabel, errorMessage);
                }
                return false;
            }
            if (lblErrorLabel != null)
            {
                ShowErrorLabel(lblErrorLabel, "");
            }
            return true;
        }

        private static void ShowErrorLabel(Label lblErrorLabel, string errorMessage)
        {
            if (errorMessage != "")
            {
                lblErrorLabel.Text = errorMessage;
                lblErrorLabel.ForeColor = System.Drawing.Color.Red;
                lblErrorLabel.Visible = true;
                return;
            }
            lblErrorLabel.Visible = false;
        }

        public static Control FindControlRecursive(Control ctrl)
        {
            if (ctrl is UpdatePanel)
            {
                return ctrl;
            }
            else
            {
                foreach (Control child in ctrl.Controls)
                {
                    Control lookFor = FindControlRecursive(child);
                    if (lookFor != null)
                        return lookFor;
                }
                return null;
            }
        }
    }
}