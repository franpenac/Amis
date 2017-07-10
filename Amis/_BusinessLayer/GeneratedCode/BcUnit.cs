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
    public class BcUnit
    {
        public Unit GetUnitById(int unitId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    Unit unitFound = (from unit in context.Unit where unit.UnitId == unitId select unit).FirstOrDefault();
                    if (unitFound!=null)
                    {
                        errorMessage = "";
                        return unitFound;
                    }else
                    {
                        errorMessage = "";
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public Unit GetUnitByUnitRegisterId(int unitRegisterId)
        {
            return new DcUnit().GetUnitByUnitRegisterId(unitRegisterId);
        }
    }
}