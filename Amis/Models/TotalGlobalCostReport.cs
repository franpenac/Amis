using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models
{
    public class TotalGlobalCostReport
    {
        public int TotalUnitNew { get; set; }
        public int TotalCostNew { get; set; }
        public int TotalUnitRetreaiding { get; set; }
        public int TotalCostRetreading { get; set; }
        public int TotalUnitRecBase { get; set; }
        public int TotalCostRecBase { get; set; }
        public int TotalUnitRecTerr { get; set; }
        public int TotalCostRecTerr { get; set; }
        public int TotalUnitDispFin { get; set; }
        public int TotalCostDispFin { get; set; }
        public int TotalUnitVentCasc { get; set; }
        public int TotalCostVentCasc { get; set; }
        public int AllCost { get; set; }
        public int AllIngresado { get; set; }
        public int AllKm { get; set; }
        public int AllCostKm { get; set; }
    }
}