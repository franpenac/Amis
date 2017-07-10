using amis._Common;
using amis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace amis._DataLayer.GeneratedCode
{
    public class DcTagAssigned
    {
        public void Copy(TagAssigned objSource, ref TagAssigned objDestination)
        {
            objDestination.TagAssignedId = objSource.TagAssignedId;
            objDestination.TagId = objSource.TagId;
            objDestination.TagAssignedDate = objSource.TagAssignedDate;
            objDestination.AssetId = objSource.AssetId;
        }

        public TagAssigned Save(TagAssigned objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        TagAssigned row = context.TagAssigned.Where(r => r.TagAssignedId == objSource.TagAssignedId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new TagAssigned();
                            Copy(objSource, ref row);
                            context.TagAssigned.Add(row);
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

        public bool ExistsTagAssigned(int TagAssignedId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                TagAssigned obj = null;
                using (var context = new Entity())
                {
                    obj = context.TagAssigned.Where(r => r.TagAssignedId != TagAssignedId).FirstOrDefault();
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

        public List<TagAssigned> GetTagAssignedList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TagAssigned> list = context.TagAssigned.ToList();
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
                        (from GlobalCost in context.TagAssigned
                         select new
                         {
                             TagAssignedId = GlobalCost.TagAssignedId,
                             TagId = GlobalCost.TagId,
                             TagCode = GlobalCost.Tag.TagCode,
                             AssetId = GlobalCost.AssetId,
                             TagAssignedDate = GlobalCost.TagAssignedDate

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

        public CommonEnums.DeletedRecordStates DeleteTagAssigned(int iTagAssignedId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    TagAssigned obj = context.TagAssigned.Where(r => r.TagAssignedId == iTagAssignedId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.TagAssigned.Remove(obj);
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

        public bool FindTagAssignedAssignedByTagId(int TagId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                TagAssigned obj = null;
                using (var context = new Entity())
                {
                    obj = context.TagAssigned.Where(r => r.TagId == TagId).FirstOrDefault();
                    if (obj == null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }
		
		public bool HasTag(int TagId, ref TagAssigned first)
        {
            using (var context = new Entity())
            {
                first = context.TagAssigned.Where(r => r.TagId != TagId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }
		
		public bool HasAsset(int AssetId, ref TagAssigned first)
        {
            using (var context = new Entity())
            {
                first = context.TagAssigned.Where(r => r.AssetId != AssetId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }

        public TagAssigned GetAsseginedByTag(int tagId, out string errorMessage)
        {
            errorMessage = "";
            using (var context = new Entity())
            {
                TagAssigned tag = (from t in context.TagAssigned where (t.TagId== tagId) select t).FirstOrDefault();
                if (tag!=null)
                {
                    return tag;
                }
                else
                {
                    return tag;
                }
            }
        }

        public TagAssigned GetAsseginedByAssetId(int AssetId, out string errorMessage)
        {
            errorMessage = "";
            using (var context = new Entity())
            {
                TagAssigned tag = (from t in context.TagAssigned where (t.AssetId == AssetId) select t).FirstOrDefault();
                if (tag != null)
                {
                    return tag;
                }
                else
                {
                    return tag;
                }
            }
        }
    }
}