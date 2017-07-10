using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amis.Models
{
    public class DispatchDocumentItemRow
    {
        public int DispatchDocumentId { get; set; }
        public int DispatchDocumentItemId { get; set; }
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public int TagId { get; set; }
        public string TagCode { get; set; }
        public int AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int AssetModelId { get; set; }
        public string AssetModelName { get; set; }
        public int Quantity { get; set; }
    }
}
