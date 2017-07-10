using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using static amis.Models.CommonEnums;
using amis._Controls;
using System.Web;

namespace amis._DataLayer.GeneratedCode
{
    public class DcPageLog
    {
        public void Save(PageActionEnum pageAction, string description)
        {
            using (var context = new Entity())
            {
                PageLog pl = new PageLog();

                int iPageAction = (int)pageAction;

                PageAction action = context.PageAction.Where(r => r.PageActionId == iPageAction).FirstOrDefault();

                description = action.PageActionDescription + ". " + description;

                if (HttpContext.Current.Session["MenuOptionId"] == null) throw new Exception("Error en el método Save de DcPageLog, Session[\"MenuOptionId\"] no puede ser nulo.");

                if (HttpContext.Current.Session["UserId"] == null) throw new Exception("Error en el método Save de DcPageLog, Session[\"UserId\"] no puede ser nulo.");

                pl.MenuOptionId = int.Parse(HttpContext.Current.Session["MenuOptionId"].ToString());
                pl.AmisUserId = int.Parse(HttpContext.Current.Session["UserId"].ToString());
                pl.PageActionId = iPageAction;
                pl.Description = description;
                pl.ActionDateTime = DateTime.Now;
                context.PageLog.Add(pl);
                context.SaveChanges();
            }
        }
    }
}
