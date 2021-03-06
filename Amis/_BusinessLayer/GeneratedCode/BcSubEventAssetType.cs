﻿using System.Transactions;
using amis._Common;
using amis._DataLayer;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infragistics.Web.UI;
using Infragistics.Web.UI.EditorControls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using amis._DataLayer.GeneratedCode;
using System.Collections.Generic;
using System;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcSubEventAssetType
    {
        public SubEventAssetType GetSubEventAssetTypeToScrap(int assetId)
        {
            return new DcSubEventAssetType().GetSubEventAssetTypeToScrap(assetId);
        }

        public SubEventAssetType GetSubEventAssetTypeToRepair(int assetId)
        {
            return new DcSubEventAssetType().GetSubEventAssetTypeToRepair(assetId);
        }
    }
}
