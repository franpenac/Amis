using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;

namespace amis._DataLayer.GeneratedCode
{
    public partial class DcUnitAsset
    {
        public void Copy(UnitAsset objSource, ref UnitAsset objDestination)
        {
            objDestination.UnitAssetId = objSource.UnitAssetId;
            objDestination.AssetId = objSource.AssetId;
            objDestination.UnitId = objSource.UnitId;
            objDestination.AssetPositionId = objSource.AssetPositionId;
            objDestination.AssignedDate = objSource.AssignedDate;
            objDestination.UnassignedDate = objSource.UnassignedDate;
        }

        public UnitAsset Save(UnitAsset objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        UnitAsset row = context.UnitAsset.Where(r => r.UnitAssetId == objSource.UnitAssetId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new UnitAsset();
                            Copy(objSource, ref row);
                            context.UnitAsset.Add(row);
                        }
                        else
                        {
                            Copy(objSource, ref row);
                        }
                        context.SaveChanges();
                        transaction.Complete();
                        return row;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public bool HasAsset(int AssetId, ref UnitAsset first)
        {
            using (var context = new Entity())
            {
                first = context.UnitAsset.Where(r => r.AssetId != AssetId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }
        
		public bool HasUnit(int UnitId, ref UnitAsset first)
        {
            using (var context = new Entity())
            {
                first = context.UnitAsset.Where(r => r.UnitId != UnitId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }

        public List<UnitAsset> GetListUnitAssetByAssetId(int assetId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<UnitAsset> unitAs = (from unitAsset in context.UnitAsset where unitAsset.AssetId == assetId select unitAsset).ToList();
                    if (unitAs != null)
                    {
                        return unitAs;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public UnitAsset GetActiveUnitAsset(int assetId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    UnitAsset obj = (from unitAsset in context.UnitAsset where unitAsset.AssetId == assetId && unitAsset.UnassignedDate == null select unitAsset).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public void UnassignedAssetOfUnit(int assetId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    UnitAsset UnitAsset = (from unitAsset in context.UnitAsset where unitAsset.AssetId == assetId select unitAsset).FirstOrDefault();
                    UnitAsset.UnassignedDate = DateTime.Now;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
            }
        }

        public void UnassignedTyreOfUnit(int assetId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    UnitAsset UnitAsset = (from unitAsset in context.UnitAsset where unitAsset.AssetId == assetId select unitAsset).FirstOrDefault();
                    UnitAsset.UnitId = null;
                    UnitAsset.AssetPositionId = null;
                    UnitAsset.UnassignedDate = DateTime.Now;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
            }
        }

        public UnitAsset GetUnitAssetByAssetPositionIdAndUnitId(int assetPositionId, int unitId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    UnitAsset unitAsset = (from unitA in context.UnitAsset where unitA.AssetPositionId == assetPositionId && unitA.UnitId == unitId select unitA).FirstOrDefault();
                    return unitAsset;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public void ChangeAssetPositionId(int assetId, int? newAssetPosition)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    UnitAsset asset = (from ast in context.UnitAsset where ast.AssetId == assetId select ast).FirstOrDefault();
                    asset.AssetPositionId = newAssetPosition;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
            }
        }

        public void ChangeUnitToAsset(int newUnitId, int assetId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    UnitAsset unitAsset = (from ua in context.UnitAsset where ua.AssetId == assetId select ua).FirstOrDefault();
                    unitAsset.UnitId = newUnitId;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
            }
        }

        public List<Asset> GetListAssetInUnit(int unitId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Asset> asset = (from unitAsset in context.UnitAsset
                                         join unit in context.Unit on unitAsset.UnitId equals unit.UnitId
                                         join a in context.Asset on unitAsset.AssetId equals a.AssetId
                                         where unitAsset.UnitId == unitId && unitAsset.UnassignedDate == null
                                         select a).ToList();
                    if (asset != null)
                    {
                        return asset;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<Asset> GetListAssetNoTyreInUnit(int unitId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Asset> asset = (from unitAsset in context.UnitAsset
                                         join unit in context.Unit on unitAsset.UnitId equals unit.UnitId
                                         join a in context.Asset on unitAsset.AssetId equals a.AssetId
                                         join aui in context.AssetUniqueIdentification on a.AssetUniqueIdentificationId equals aui.AssetUniqueIdentificationId
                                         join type in context.AssetType on aui.AssetTypeId equals type.AssetTypeId
                                         where unitAsset.UnitId == unitId && unitAsset.UnassignedDate == null && type.AssetTypeName != "Neumático"
                                         select a).ToList();
                    if (asset != null)
                    {
                        return asset;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<Asset> GetListAssetTyreInUnit(int unitId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Asset> asset = (from unitAsset in context.UnitAsset
                                         join unit in context.Unit on unitAsset.UnitId equals unit.UnitId
                                         join a in context.Asset on unitAsset.AssetId equals a.AssetId
                                         join aui in context.AssetUniqueIdentification on a.AssetUniqueIdentificationId equals aui.AssetUniqueIdentificationId
                                         join type in context.AssetType on aui.AssetTypeId equals type.AssetTypeId
                                         where unitAsset.UnitId == unitId && unitAsset.UnassignedDate == null && type.AssetTypeName == "Neumático"
                                         select a).ToList();
                    if (asset != null)
                    {
                        return asset;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public int TyresCounter(int unitId)
        {
            using (var context = new Entity())
            {
                List<UnitAsset> list = (from ua in context.UnitAsset where ua.UnitId == unitId && ua.AssetPosition != null && ua.UnassignedDate == null
                                  join ast in context.Asset on ua.AssetId equals ast.AssetId
                                  join aue in context.AssetUniqueIdentification on ast.AssetUniqueIdentificationId equals aue.AssetUniqueIdentificationId
                                  where aue.AssetTypeId == 1 select ua).ToList();
                return list.Count();
            }
        }

        public UnitRegister FindLastUnit(string tagCode)
        {
            using (var context = new Entity())
            {
                UnitAsset ua = (from a in context.UnitAsset
                                join asset in context.Asset on a.AssetId equals asset.AssetId
                                join assigned in context.TagAssigned on asset.AssetId equals assigned.AssetId
                                join tag in context.Tag on assigned.TagId equals tag.TagId
                                where tag.TagCode == tagCode && a.UnassignedDate != null
                                select a).Last();
                UnitRegister unitRegister = (from ur in context.UnitRegister
                                             join unit in context.Unit on ur.UnitRegisterId equals unit.UnitRegisterId
                                             where unit.UnitId == ua.UnitId
                                             select ur).FirstOrDefault();
                return unitRegister;
            }
        }

        public List<UnitAsset> GetTyreList(int unitId)
        {
            using (var context = new Entity())
            {
                List<UnitAsset> list = (from ua in context.UnitAsset where ua.UnitId == unitId && ua.AssetPositionId != null && ua.UnassignedDate == null select ua).ToList();
                return list;
            }
        }

        public UnitAsset GetUnitAssetByAssetId(int assetId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    UnitAsset obj = (from unitAsset in context.UnitAsset where unitAsset.AssetId == assetId select unitAsset).First();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public int GetAssetIdByUnitIdAndPositionId(int unitId, int assetPositionId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    int assetId = (from unitAsset in context.UnitAsset where unitAsset.UnitId == unitId && unitAsset.AssetPositionId == assetPositionId && unitAsset.UnassignedDate == null select unitAsset.AssetId).FirstOrDefault();
                    return assetId;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return 0;
            }
        }
    }
}