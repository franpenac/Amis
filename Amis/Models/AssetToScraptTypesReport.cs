using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace amis.Models
{
    public class AssetToScraptTypesReport
    {
        public int AssetId { get; set; }
        public int AssetOperationId { get; set; }
        public string AssetOperationName { get; set; }
        public int AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }
        public DateTime DateScraped { get; set; }
        public int ScrapTypeId { get; set; }
        public string ScrapTypeName { get; set; }
    }
}