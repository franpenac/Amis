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
    public class BcUnitAsset
    {
        public List<UnitAsset> GetListUnitAssetByAssetId(int assetId)
        {
            return new DcUnitAsset().GetListUnitAssetByAssetId(assetId);
        }

        public UnitAsset GetActiveUnitAsset(int assetId)
        {
            return new DcUnitAsset().GetActiveUnitAsset(assetId);
        }

        public void UnassignedAssetOfUnit(int assetId)
        {
            new DcUnitAsset().UnassignedAssetOfUnit(assetId);
        }

        public void UnassignedTyreOfUnit(int assetId)
        {
            new DcUnitAsset().UnassignedTyreOfUnit(assetId);
        }

        public UnitAsset GetUnitAssetByAssetPositionIdAndUnitId(int assetPositionId, int unitId)
        {
            return new DcUnitAsset().GetUnitAssetByAssetPositionIdAndUnitId(assetPositionId, unitId);
        }

        public void ChangeAssetPositionId(int assetId, int? newAssetPosition)
        {
            new DcUnitAsset().ChangeAssetPositionId(assetId, newAssetPosition);
        }

        public void ChangeTyrePositionSameUnit(int assetTyreId, int newAssetPosition)
        {
            ChangeAssetPositionId(assetTyreId, newAssetPosition);
        }

        public UnitAsset Save(UnitAsset objSource, out string errorMessage)
        {
            return new DcUnitAsset().Save(objSource, out errorMessage);
        }

        public void ChangeUnitToAsset(int newUnitId, int assetId)
        {
            new DcUnitAsset().ChangeUnitToAsset(newUnitId, assetId);
        }

        public List<Asset> GetListAssetInUnit(int unitId)
        {
            return new DcUnitAsset().GetListAssetInUnit(unitId);
        }

        public List<Asset> GetListAssetNoTyreInUnit(int unitId)
        {
            return new DcUnitAsset().GetListAssetNoTyreInUnit(unitId);
        }

        public List<Asset> GetListAssetTyreInUnit(int unitId)
        {
            return new DcUnitAsset().GetListAssetTyreInUnit(unitId);
        }

        public int TyresCounter(int unitId)
        {
            return new DcUnitAsset().TyresCounter(unitId);
        }

        public UnitRegister FindLastUnit(string tagCode)
        {
            return new DcUnitAsset().FindLastUnit(tagCode);
        }

        public List<UnitAsset> GetTyreList(int unitId)
        {
            return new DcUnitAsset().GetTyreList(unitId);
        }

        public UnitAsset GetUnitAssetByAssetId(int assetId, out string errorMessage)
        {
            return new DcUnitAsset().GetUnitAssetByAssetId(assetId, out errorMessage);
        }

        public int GetAssetIdByUnitIdAndPositionId(int unitId, int assetPositionId)
        {
            return new DcUnitAsset().GetAssetIdByUnitIdAndPositionId(unitId, assetPositionId);
        }
    }
}
