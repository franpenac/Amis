using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models.Configuration
{
    public class MoTag
    {
        public int Id { get; set; }
        public String Codigo { get; set; }
        public String Obtenido { get; set; }
        public DateTime Registro { get; set; }
        public DateTime Entrega { get; set; }
        public DateTime De_Baja { get; set; }
    }
}