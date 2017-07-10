using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models
{
    public class ItemReceptionDocument
    {
        public int AUI { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Cantidad { get; set; }
    }
}