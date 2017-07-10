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
    public partial class DcRegion
    {
        public void Copy(Region objSource, ref Region objDestination)
        {
            objDestination.RegionId = objSource.RegionId;
            objDestination.RegionName = objSource.RegionName;
            objDestination.CountryId = objSource.CountryId;
        }

        public Region Save(Region objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        Region service = context.Region.Where(r => r.RegionName.ToUpper() == objSource.RegionName.ToUpper() && r.RegionId != objSource.RegionId).FirstOrDefault();
                        if (service != null) return (Region)ErrorController.SetErrorMessage("Repeated Region name", out errorMessage);

                        Region row = context.Region.Where(r => r.RegionId == objSource.RegionId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Region();
                            Copy(objSource, ref row);
                            context.Region.Add(row);
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

        public bool ExistsRegion(int RegionId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Region obj = null;
                using (var context = new Entity())
                {
                    obj = context.Region.Where(r => r.RegionId != RegionId).FirstOrDefault();
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

        public List<Region> GetRegionList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Region> list = context.Region.OrderBy(a => a.RegionName).ToList();
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
                        (from obj in context.Region
                         select new TsDropDownItem()
                         {
                             ComboId = obj.RegionId.ToString(),
                             ComboName = obj.RegionName
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
                        (from Region in context.Region
                         select new
                         {
                             RegionId = Region.RegionId,
                             RegionName = Region.RegionName,
                             CountryId = Region.CountryId,
                             CountryName = Region.Country.CountryName

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

        public CommonEnums.DeletedRecordStates DeleteRegion(int IRegionId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Region obj = context.Region.Where(r => r.RegionId == IRegionId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Region.Remove(obj);
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

    }
}
