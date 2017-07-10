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
    public partial class DcAsset
    {
        public void Copy(Asset objSource, ref Asset objDestination)
        {
            objDestination.AssetId = objSource.AssetId;
            objDestination.AssetSerie = objSource.AssetSerie;
            objDestination.AssetUniqueIdentificationId = objSource.AssetUniqueIdentificationId;
            objDestination.FacilityId = objSource.FacilityId;
            objDestination.DispatchProviderDocumentId = objSource.DispatchProviderDocumentId;
            objDestination.Cost = objSource.Cost;
            objDestination.WarrantyStartDate = objSource.WarrantyStartDate;
            objDestination.WarrantyMounth = objSource.WarrantyMounth;
            objDestination.WarrantyKm = objSource.WarrantyKm;
            objDestination.ScrapTypeId = objSource.ScrapTypeId;
            objDestination.IsGood = objSource.IsGood;
            objDestination.Kilometers = objSource.Kilometers;
            objDestination.Dot = objSource.Dot;
            objDestination.ApplicationId = objSource.ApplicationId;
            objDestination.RepairTypeId = objSource.RepairTypeId;
        }

        public Asset Save(Asset objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        Asset row = context.Asset.Where(r => r.AssetId == objSource.AssetId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Asset();
                            Copy(objSource, ref row);
                            context.Asset.Add(row);
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

        public bool ExistsAsset(int AssetId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Asset obj = null;
                using (var context = new Entity())
                {
                    obj = context.Asset.Where(r => r.AssetId != AssetId).FirstOrDefault();
                    if (obj == null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }

        public List<Asset> GetAssetList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Asset> list = context.Asset.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }
        
        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    IEnumerable<object> list =
                        (from Asset in context.Asset
                         join facility in context.Facility on Asset.FacilityId equals facility.FacilityId
                         join unique in context.AssetUniqueIdentification on Asset.AssetUniqueIdentificationId equals unique.AssetUniqueIdentificationId
                         join item in context.DispatchProviderDocument on Asset.DispatchProviderDocumentId equals item.DispatchProviderDocumentId
                         select new
                         {
                            AssetId = Asset.AssetId,
                             FacilityId = Asset.FacilityId,
                             DispatchProviderDocumentId = Asset.DispatchProviderDocumentId,
                             AssetUniqueIdentificationId = Asset.AssetUniqueIdentificationId,
                             AssetSerie = Asset.AssetSerie
                         }).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteAsset(int IAssetId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Asset obj = context.Asset.Where(r => r.AssetId == IAssetId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Asset.Remove(obj);
                    context.SaveChanges();
                    return CommonEnums.DeletedRecordStates.DeletedOk;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return CommonEnums.DeletedRecordStates.NotDeleted;
            }
        }

        public Asset GetAssetById(int id, out string errorMessage)
        {
            errorMessage = "";
            using (var context = new Entity())
            {
                Asset asset = (from a in context.Asset where(a.AssetId == id) select a).FirstOrDefault();

                if (asset!=null)
                {
                    return asset;
                }
                else
                {
                    errorMessage = "No existe el activo buscado!";
                    return asset;
                }
            }
        }
		
		public bool HasTag(int TagId, ref Asset first)
        {
            using (var context = new Entity())
            {
               TagAssigned obj = context.TagAssigned.Where(r => r.TagId == TagId).FirstOrDefault();
                first = context.Asset.Where(r => r.AssetId != obj.AssetId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }
        
		public bool HasDispatchProviderDocument(int DispatchProviderDocumentId, ref Asset first)
        {
            using (var context = new Entity())
            {
                first = context.Asset.Where(r => r.DispatchProviderDocumentId != DispatchProviderDocumentId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool HasAUI(int AUIId, ref Asset first)
        {
            using (var context = new Entity())
            {
                first = context.Asset.Where(r => r.AssetUniqueIdentificationId == AUIId).FirstOrDefault();
                if (first == null)
                {
                    return true;
                }
                return false;
            }
        }

        public bool ChangeFacility(int assetId, int facilityId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    Asset assetFound = (from asset in context.Asset where asset.AssetId == assetId select asset).FirstOrDefault();
                    if (assetFound != null)
                    {
                        assetFound.FacilityId = facilityId;
                        context.SaveChanges();
                        return true;
                    }else

                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }
        public Asset GetAssetByUnitRegisterId(int unitRegisterId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    Asset asset = (from a in context.Asset
                                   join u in context.Unit on a.AssetId equals u.AssetId
                                   where u.UnitRegisterId == unitRegisterId
                                   select a).FirstOrDefault();
                    return asset;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public Asset GetAssetByTag(string tagCode, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    Asset asset = (from a in context.Asset
                                   join tagAssigned in context.TagAssigned on a.AssetId equals tagAssigned.AssetId
                                   join tag in context.Tag on tagAssigned.TagId equals tag.TagId
                                   where tag.TagCode == tagCode
                                   select a).FirstOrDefault();
                    return asset;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }
    }
}