using amis._Common;
using amis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace amis._DataLayer.GeneratedCode
{
    public class DcTag
    {
        public void Copy(Tag objSource, ref Tag objDestination)
        {
            objDestination.TagId = objSource.TagId;
            objDestination.TagCode = objSource.TagCode;
            objDestination.TSOwner = objSource.TSOwner;
            objDestination.StartDate = objSource.StartDate;
            objDestination.TagAssigned = objSource.TagAssigned;
            objDestination.CancellationDate = objSource.CancellationDate;
        }

        public Tag Save(Tag objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        Tag service = context.Tag.Where(r => r.TagCode.ToUpper() == objSource.TagCode.ToUpper() && r.TagId != objSource.TagId).FirstOrDefault();
                        if (service != null) return (Tag)ErrorController.SetErrorMessage("Repeated tag code name", out errorMessage);

                        Tag row = context.Tag.Where(r => r.TagId == objSource.TagId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Tag();
                            Copy(objSource, ref row);
                            context.Tag.Add(row);
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

        public bool ExistsTag(int TagId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Tag obj = null;
                using (var context = new Entity())
                {
                    obj = context.Tag.Where(r => r.TagId != TagId).FirstOrDefault();
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

        public List<Tag> GetTagList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Tag> list = context.Tag.OrderBy(r => r.TagCode).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.Tag
                         select new TsDropDownItem()
                         {
                             ComboId = obj.TagId.ToString(),
                             ComboName = obj.TagCode
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
        
        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    IEnumerable<object> list =
                        (from GlobalCost in context.Tag
                         select new
                         {
                             TagId = GlobalCost.TagId,
                             TagCode = GlobalCost.TagCode,
                             StartDate = GlobalCost.StartDate,
                             TSOwner = GlobalCost.TSOwner,
                             CustomerAssignationDate = GlobalCost.CustomerAssignationDate,
                             CancellationDate = GlobalCost.CancellationDate

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

        public CommonEnums.DeletedRecordStates DeleteTag(int iTagId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Tag obj = context.Tag.Where(r => r.TagId == iTagId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Tag.Remove(obj);
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

        public int GetTagByCode(string tagCode, out string errorMessage) {

            errorMessage = "";
            try
            {
                
                using (var context = new Entity())
                {
                    Tag obj = context.Tag.Where(r => r.TagCode == tagCode).FirstOrDefault();
                    if (obj != null)
                    {
                        TagAssigned tag = context.TagAssigned.Where(r => r.TagId == obj.TagId).FirstOrDefault();
                        if (tag==null)
                        {
                            return obj.TagId;
                        }
                        errorMessage = "El tag ya esta asignado a otro activo!";
                        return 0;
                        
                    }
                    errorMessage = "El tag no esta registrado!";
                    return 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return 0;
            }
        }

        public int GetTagButDelete(string tagCode, out string errorMessage)
        {

            errorMessage = "";
            try
            {

                using (var context = new Entity())
                {
                    Tag obj = context.Tag.Where(r => r.TagCode == tagCode).FirstOrDefault();
                    if (obj != null)
                    {
                        
                            return obj.TagId;

                    }
                    errorMessage = "El tag no esta registrado!";
                    return 0;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return 0;
            }
        }

        public bool FindTagAssignedByTagId(int TagId, out string errorMessage)
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

        public Tag GetTagByCodeTag(string tagCode, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    Tag tag = (from Tag in context.Tag where Tag.TagCode == tagCode select Tag).FirstOrDefault();
                    if (tag != null)
                    {
                        errorMessage = "";
                        return tag;
                    }
                    else
                    {
                        errorMessage = "";
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

        public Tag GetTagByAssetId(int id)
        {
            string errorMessasge = "";
            try
            {
                using (var context = new Entity())
                {
                    Tag tag = (from Tag in context.Tag
                               join tagAssigned in context.TagAssigned on Tag.TagId equals tagAssigned.TagId
                               where tagAssigned.AssetId == id
                               select Tag).FirstOrDefault();
                    if (tag != null)
                    {
                        return tag;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessasge = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

       
    }
}