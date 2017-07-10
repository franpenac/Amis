using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models
{
    public class GlobalCostReport
    {
        public String Mount { get; set; }
        public int UnitNew { get; set; }
        public int CostNew { get; set; }
        public int UnitRetreaiding { get; set; }
        public int CostRetrearding { get; set; }
        public int UnitRBase { get; set; }
        public int CostRBase { get; set; }
        public int UnitRTerrereno { get; set; }
        public int CostRTerreno { get; set; }
        public int UnitDispTotal { get; set; }
        public int CostDispTotal { get; set; }
        public int UnitVentCasc { get; set; }
        public int CostVentCasc { get; set; }
        public float TotalCost { get; set; }
        public float TotalIngreso { get; set; }
        public float TotalKm { get; set; }
        public float CostKm { get; set; }

    }
}