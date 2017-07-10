using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amis._Common;
using amis.Models;
using System.Transactions;

namespace amis._DataLayer.GeneratedCode
{
    public class DcDispatchDocument
    {
        public void Copy(DispatchDocumentItem objSource, ref DispatchDocumentItem objDestination)
        {
            objDestination.DispatchDocumentItemId = objSource.DispatchDocumentItemId;
            objDestination.DispatchDocumentId = objSource.DispatchDocumentId;
            objDestination.AssetId = objSource.AssetId;
        }

        public int CreateNewDispatchDocument(int facilityOriginId, int facilityDestinationId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        int newNumber = 1;
                        if (context.DispatchDocument.Count() != 0)
                        {
                            newNumber = context.DispatchDocument.Max(r => r.DispatchDocumentNumber) + 1;
                        }
                        DispatchDocument doc = new DispatchDocument();
                        doc.DispatchDocumentId = 0;
                        doc.FacilityOriginId = facilityOriginId;
                        //doc.FacilityDestinationId = facilityDestinationId;
                        doc.DispatchDate = DateTime.Now;
                        doc.DispatchDocumentNumber = newNumber;
                        //doc.DispatchDocumentStateId = 0;
                        context.DispatchDocument.Add(doc);
                        context.SaveChanges();
                        transaction.Complete();
                        return newNumber;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return 0;
            }
        }

        public List<DispatchDocumentItemRow> GetDispatchDocumentItemTable(int dispatchDocumentNumber, out string errorMessage)
        {
            errorMessage = "";
            //try
            //{
            //    using (var context = new Entity())
            //    {
            //        List<DispatchDocumentItemRow> list =
            //            (from item in context.DispatchDocumentItem
            //             join doc in context.DispatchDocument on item.DispatchDocumentId equals doc.DispatchDocumentId
            //             join asset in context.Asset on item.AssetId equals asset.AssetId
            //             join assettype in context.AssetType on asset.AssetTypeId equals assettype.AssetTypeId
            //             join tag in context.Tag on asset.TagId equals tag.TagId
            //             join model in context.AssetModel on asset.AssetModelId equals model.AssetModelId
            //             join brand in context.Brand on  model.BrandId equals brand.BrandId
            //             where doc.DispatchDocumentNumber == dispatchDocumentNumber
            //             select new DispatchDocumentItemRow()
            //             {
            //                 DispatchDocumentId = doc.DispatchDocumentId,
            //                 DispatchDocumentItemId = item.DispatchDocumentItemId,
            //                 AssetId = asset.AssetId,
            //                 AssetName = asset.AssetName,
            //                 TagId = tag.TagId,
            //                 TagCode = tag.TagCode,
            //                 AssetTypeId = assettype.AssetTypeId,
            //                 AssetTypeName = assettype.AssetTypeName,
            //                 BrandId = brand.BrandId,
            //                 BrandName = brand.BrandName,
            //                 AssetModelId = model.AssetModelId,
            //                 AssetModelName = model.AssetModelName
            //             }).ToList();
            //        return list;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            //}
        }

        public DispatchDocumentItemRow GetDispatchDocumentItem(string tagCode, out string errorMessage)
        {
            errorMessage = "";
            //try
            //{
            //    using (var context = new Entity())
            //    {
            //        DispatchDocumentItemRow obj =
            //            (from tag in context.Tag
            //             join asset in context.Asset on tag.TagId equals asset.TagId 
            //             join assettype in context.AssetType on asset.AssetTypeId equals assettype.AssetTypeId
            //             join model in context.AssetModel on asset.AssetModelId equals model.AssetModelId
            //             join brand in context.Brand on model.BrandId equals brand.BrandId
            //             where tag.TagCode == tagCode
            //             select new DispatchDocumentItemRow()
            //             {
            //                 TagId = tag.TagId,
            //                 TagCode = tag.TagCode,
            //                 AssetId = asset.AssetId,
            //                 AssetName = asset.AssetName,
            //                 AssetTypeId = assettype.AssetTypeId,
            //                 AssetTypeName = assettype.AssetTypeName,
            //                 BrandId = brand.BrandId,
            //                 BrandName = brand.BrandName,
            //                 AssetModelId = model.AssetModelId,
            //                 AssetModelName = model.AssetModelName
            //             }).FirstOrDefault();
            //        return obj;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            //}
        }

        public List<DispatchDocumentSummaryRow> GetDispatchDocumentSummaryTable(int dispatchDocumentNumber, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                List<DispatchDocumentItemRow> assetList = GetDispatchDocumentItemTable(dispatchDocumentNumber, out errorMessage);

                if (errorMessage != "") return null;

                List<DispatchDocumentSummaryRow> assetSummarytList =
                    (from t in assetList
                     group t by new { t.BrandId, t.AssetModelId, t.BrandName, t.AssetModelName }
                     into grp
                     select new DispatchDocumentSummaryRow()
                     {
                         BrandId = grp.Key.BrandId,
                         AssetModelId = grp.Key.AssetModelId,
                         BrandName = grp.Key.BrandName,
                         AssetModelName = grp.Key.AssetModelName,
                         Quantity = grp.Count()
                     }).OrderBy(r => r.BrandName).ThenBy(r => r.AssetModelName).ToList();

                return assetSummarytList;
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }
        
        public DispatchDocumentItem SaveDispatchDocumentItem(DispatchDocumentItem objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        DispatchDocumentItem row = context.DispatchDocumentItem.Where(r => r.DispatchDocumentId == objSource.DispatchDocumentId && r.DispatchDocumentItemId == objSource.DispatchDocumentItemId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new DispatchDocumentItem();
                            Copy(objSource, ref row);
                            context.DispatchDocumentItem.Add(row);
                            context.SaveChanges();
                            transaction.Complete();
                        }
                        else
                        {
                            return (DispatchDocumentItem)ErrorController.SetErrorMessage("Dispatch document item repeated", out errorMessage);
                        }
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

        public bool RemoveDispatchDocumentItem(int itemId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        DispatchDocumentItem row = context.DispatchDocumentItem.Where(r => r.DispatchDocumentItemId == itemId).FirstOrDefault();
                        if (row != null)
                        {
                            context.DispatchDocumentItem.Remove(row);
                            context.SaveChanges();
                            transaction.Complete();
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }

        public List<DispatchDocumentSummaryRow> AddItem(int dispatchDocumentNumber, string tagCode, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    DispatchDocument doc = context.DispatchDocument.Where(r => r.DispatchDocumentNumber == dispatchDocumentNumber).FirstOrDefault();
                    if (doc == null) return (List<DispatchDocumentSummaryRow>)ErrorController.SetErrorMessage("Dispatch document not found", out errorMessage);
                    int docId = doc.DispatchDocumentId;

                    Tag tag = context.Tag.Where(r => r.TagCode == tagCode).FirstOrDefault();
                    if (tag == null) return (List<DispatchDocumentSummaryRow>)ErrorController.SetErrorMessage("Tag not found", out errorMessage);
                    int tagId = tag.TagId;

                    //Asset asset = context.Asset.Where(r => r.TagId == tagId).FirstOrDefault();
                    //if (asset == null) return (List<DispatchDocumentSummaryRow>)ErrorController.SetErrorMessage("Asset not found", out errorMessage);
                    //int assetId = asset.AssetId;

                    //DispatchDocumentItem assetItem = context.DispatchDocumentItem.Where(r => r.DispatchDocumentId == docId && r.AssetId == assetId).FirstOrDefault();
                    //if (assetItem != null) return (List<DispatchDocumentSummaryRow>)ErrorController.SetErrorMessage("Asset repeated", out errorMessage);

                    DispatchDocumentItem objSource = new DispatchDocumentItem();
                    objSource.DispatchDocumentItemId = 0;
                    objSource.DispatchDocumentId = docId;
                    //objSource.AssetId = assetId;

                    DispatchDocumentItem row = SaveDispatchDocumentItem(objSource, out errorMessage);
                    if (row == null) return null;

                    List<DispatchDocumentSummaryRow> list = GetDispatchDocumentSummaryTable(dispatchDocumentNumber, out errorMessage);
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<DispatchDocumentSummaryRow> RemoveItem(int dispatchDocumentNumber, string tagCode, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    DispatchDocument doc = context.DispatchDocument.Where(r => r.DispatchDocumentNumber == dispatchDocumentNumber).FirstOrDefault();
                    if (doc == null) return (List<DispatchDocumentSummaryRow>)ErrorController.SetErrorMessage("Dispatch document not found", out errorMessage);
                    int docId = doc.DispatchDocumentId;

                    Tag tag = context.Tag.Where(r => r.TagCode == tagCode).FirstOrDefault();
                    if (tag == null) return (List<DispatchDocumentSummaryRow>)ErrorController.SetErrorMessage("Tag not found", out errorMessage);
                    int tagId = tag.TagId;

                    //Asset asset = context.Asset.Where(r => r.TagId == tagId).FirstOrDefault();
                    //if (asset == null) return (List<DispatchDocumentSummaryRow>)ErrorController.SetErrorMessage("Asset not found", out errorMessage);
                    //int assetId = asset.AssetId;

                    //DispatchDocumentItem assetItem = context.DispatchDocumentItem.Where(r => r.DispatchDocumentId == docId && r.AssetId == assetId).FirstOrDefault();
                    //if (assetItem == null) return (List<DispatchDocumentSummaryRow>)ErrorController.SetErrorMessage("Asset allready removed", out errorMessage);

                    //bool deleted = RemoveDispatchDocumentItem(assetItem.DispatchDocumentItemId, out errorMessage);

                    List<DispatchDocumentSummaryRow> list = GetDispatchDocumentSummaryTable(dispatchDocumentNumber, out errorMessage);
                    return list;
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
