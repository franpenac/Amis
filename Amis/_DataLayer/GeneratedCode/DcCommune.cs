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
    public partial class DcCommune
    {
        public void Copy(Commune objSource, ref Commune objDestination)
        {
            objDestination.CommuneId = objSource.CommuneId;
            objDestination.CommuneName = objSource.CommuneName;
            objDestination.RegionId = objSource.RegionId;
        }

        public Commune Save(Commune objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        Commune service = context.Commune.Where(r => r.CommuneName.ToUpper() == objSource.CommuneName.ToUpper() && r.CommuneId != objSource.CommuneId).FirstOrDefault();
                        if (service != null) return (Commune)ErrorController.SetErrorMessage("Repeated Commune name", out errorMessage);

                        Commune row = context.Commune.Where(r => r.CommuneId == objSource.CommuneId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Commune();
                            Copy(objSource, ref row);
                            context.Commune.Add(row);
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

        public bool ExistsCommune(int CommuneId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Commune obj = null;
                using (var context = new Entity())
                {
                    obj = context.Commune.Where(r => r.CommuneId != CommuneId).FirstOrDefault();
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

        public List<Commune> GetCommuneList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Commune> list = context.Commune.OrderBy(a => a.CommuneName).ToList();
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
                        (from obj in context.Commune
                         orderby obj.CommuneName
                         select new TsDropDownItem()
                         {
                             ComboId = obj.CommuneId.ToString(),
                             ComboName = obj.CommuneName
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
                        (from Commune in context.Commune
                         select new
                         {
                             CommuneId = Commune.CommuneId,
                             CommuneName = Commune.CommuneName,
                             RegionId = Commune.RegionId,
                             RegionName = Commune.Region.RegionName

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

        public CommonEnums.DeletedRecordStates DeleteCommune(int ICommuneId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Commune obj = context.Commune.Where(r => r.CommuneId == ICommuneId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Commune.Remove(obj);
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

        public List<TsDropDownItem> GetComboListByRegionId(int RegionId,out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.Commune where obj.RegionId == RegionId
                         orderby obj.CommuneName
                         select new TsDropDownItem()
                         {
                             ComboId = obj.CommuneId.ToString(),
                             ComboName = obj.CommuneName
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

    }
}