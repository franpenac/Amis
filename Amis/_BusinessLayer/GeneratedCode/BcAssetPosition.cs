using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis._DataLayer;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infragistics.Web.UI;
using Infragistics.Web.UI.EditorControls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using amis._DataLayer.GeneratedCode;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcAssetPosition
    {
        public List<AssetPosition> GetAssetPositionByAxleId(int axleId)
        {
            return new DcAssetPosition().GetAssetPositionByAxleId(axleId);
        }

        public AssetPosition GetAssetPositionById(int assetPositionId)
        {
            return new DcAssetPosition().GetAssetPositionById(assetPositionId);
        }
    }
}
