using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis._DataLayer.GeneratedCode
{
    public class DcWrongTagInspection
    {
        public List<UnitRegister> SearchUnitRegister()
        {
            using (var context = new Entity())
            {
                List<UnitRegister> list = (from u in context.UnitRegister
                                           join unit in context.Unit on u.UnitRegisterId equals unit.UnitRegisterId
                                           select u).Distinct().ToList();
                return list;
            }
        }

        public Unit SearchUnit(int id)
        {
            using (var context = new Entity())
            {
                Unit unit = (from u in context.Unit
                             join reg in context.UnitRegister on u.UnitRegisterId equals reg.UnitRegisterId
                             select u).FirstOrDefault();
                return unit;
            }
        }
    }
}