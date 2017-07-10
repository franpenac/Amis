using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amis.Models
{
    public interface ITsDropDownList
    {
        List<TsDropDownItem> GetComboList(out string errorMessage);

        List<TsDropDownItem> GetComboListByFiltrer(int id,out string errorMessage);

        IEnumerable<object> GetTableList(out string errorMessage);
    }
}