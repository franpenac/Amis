using amis._DataLayer.GeneratedCode;
using amis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcUserAlarmType : ITsDropDownList
    {
        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcUserAlarmType().GetComboList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}