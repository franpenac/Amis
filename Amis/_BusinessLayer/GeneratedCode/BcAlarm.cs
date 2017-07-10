using amis._DataLayer.GeneratedCode;
using amis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcAlarm : ITsDropDownList
    {
        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcAlarm().GetTableList(out errorMessage);
            return list;
        }
    }
}