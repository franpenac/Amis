using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models
{
    public class ModelPurchaseReport
    {
        public int AssetUniqueIdentificationId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int Count { get; set; }
        public string Mont { get; set; }
    }
}