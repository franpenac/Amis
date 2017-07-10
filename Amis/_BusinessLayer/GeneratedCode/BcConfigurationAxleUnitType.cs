using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis._DataLayer;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infragistics.Web.UI;
using Infragistics.Web.UI.EditorControls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using amis._DataLayer.GeneratedCode;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcConfigurationAxleUnitType
    {
        public List<ConfigurationAxleUnitType> GetConfigurationAxleUnitTypeByAxleConfigId(int configurationUnitTypeId)
        {
            return new DcConfigurationAxleUnitType().GetConfigurationAxleUnitTypeByAxleConfigId(configurationUnitTypeId);
        }
    }
}
