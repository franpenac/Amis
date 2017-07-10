using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amis.Models
{
    public class TsDropDownItem
    {
        public string ComboId { get; set; }
        public string ComboName { get; set; }

        public TsDropDownItem()
        {
        }

        public TsDropDownItem(string comboId, string comboName)
        {
            ComboId = comboId;
            ComboName = comboName;
        }
    }
}
