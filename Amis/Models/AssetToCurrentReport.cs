using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models
{
    public class AssetToCurrentReport
    {
        public int AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int AssetModelId { get; set; }
        public string AssetModelName { get; set; }
        public int Stock { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int BranchOfficeId { get; set; }
        public string BranchOfficeName { get; set; }
        public int UniqueIdentificationId { get; set; }
    }
}