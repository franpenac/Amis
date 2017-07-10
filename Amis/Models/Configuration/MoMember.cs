using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models.Configuration
{
    public class MoMember
    {

        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Rut { get; set; }
        public String Correo { get; set; }
        public String Tipo { get; set; }
    }
}