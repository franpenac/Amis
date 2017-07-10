using amis._BusinessLayer;
using amis._BusinessLayer.GeneratedCode;
using System;
using System.Web.UI;
using amis._Controls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace amis.Models
{
    [Serializable]
    public class UserMenuOptionAuthorization 
    {
        public int UserMenuOptionId { get; set; }
        public int UserId { get; set; }
        public int MenuOptionId { get; set; }
        public string CanAuthorize { get; set; }
        public bool CanAuthorizeBool { get; set; }
        public string CanCreate { get; set; }
        public bool CanCreateBool { get; set; }
        public string CanDelete { get; set; }
        public bool CanDeleteBool { get; set; }
        public string CanGenerateReport { get; set; }
        public bool CanGenerateReportBool { get; set; }
        public string MenuOptionName { get; set; }
        public string ParentMenuOptionName { get; set; }
    }
}