using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models
{
    public class LogsObject
    {
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string MenuOption { get; set; }
        public int MenuOptionId { get; set; }
        public string Action { get; set; }
        public int ActionId { get; set; }
        public DateTime ActionDate { get; set; }
    }
}