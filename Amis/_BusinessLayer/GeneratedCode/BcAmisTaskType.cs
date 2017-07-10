using amis._DataLayer.GeneratedCode;
using amis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcAmisTaskType : ITsDropDownList
    {
        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            List<TsDropDownItem> list = new DcAmisTaskType().GetComboList(out errorMessage);
            list.Insert(0, new TsDropDownItem() { ComboId = "-1", ComboName = "Todas" });
            return list;
        }

        List<TsDropDownItem> ITsDropDownList.GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}