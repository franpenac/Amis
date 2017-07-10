using amis._DataLayer.GeneratedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcWrongTagInspection
    {
        public List<UnitRegister> SearchUnitRegister()
        {
            return new DcWrongTagInspection().SearchUnitRegister();
        }

        public Unit SearchUnit(int id)
        {
            return new DcWrongTagInspection().SearchUnit(id);
        }
    }
}