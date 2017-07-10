using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models.Configuration
{
    public class MoDepthSetting
    {
        public int Id { get; set; }
        public String Aplicacion  { get; set; }
        public String Modelo { get; set; }
        public String Operacion { get; set; }
        public int Presion_Min { get; set; }
    }
}