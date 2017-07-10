using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amis.Models
{
    public class DispatchDocumentSummaryRow
    {
        public int BrandId { get; set; }
        public int AssetModelId { get; set; }
        public string BrandName { get; set; }
        public string AssetModelName { get; set; }
        public int Quantity { get; set; }
    }
}
