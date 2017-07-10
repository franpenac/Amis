using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models
{
    public class UnitRegisterTableRow
    {
        public int UnitRegisterId { get; set; }
        public int UnitTypeId { get; set; }
        public string UnitTypeName { get; set; }
        public int ConfigurationUnitTypeId { get; set; }
        public string ConfigurationUnitTypeName { get; set; }
        public string PatentNumber { get; set; }
        public string InternalNumber { get; set; }
        public DateTime? RevTec { get; set; }
        public DateTime? HabDate { get; set; }
    }
}