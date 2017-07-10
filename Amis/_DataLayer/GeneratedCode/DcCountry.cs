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
    public partial class DcCountry
    {
        public void Copy(Country objSource, ref Country objDestination)
        {
            objDestination.CountryId = objSource.CountryId;
            objDestination.CountryName = objSource.CountryName;
        }
        
        public Country Save(Country objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        Country service = context.Country.Where(r => r.CountryName.ToUpper() == objSource.CountryName.ToUpper() && r.CountryId != objSource.CountryId).FirstOrDefault();
                        if (service != null) return (Country)ErrorController.SetErrorMessage("Repeated Country name", out errorMessage);

                        Country row = context.Country.Where(r => r.CountryId == objSource.CountryId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Country();
                            Copy(objSource, ref row);
                            context.Country.Add(row);
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

        public bool ExistsCountry(int CountryId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Country obj = null;
                using (var context = new Entity())
                {
                    obj = context.Country.Where(r => r.CountryId != CountryId).FirstOrDefault();
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

        public List<Country> GetCountryList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Country> list = context.Country.OrderBy(a => a.CountryName).ToList();
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
                        (from obj in context.Country
                         select new TsDropDownItem()
                         {
                             ComboId = obj.CountryId.ToString(),
                             ComboName = obj.CountryName
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
                        (from Country in context.Country
                         select new
                         {
                             CountryId = Country.CountryId,
                             CountryName = Country.CountryName

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

        public CommonEnums.DeletedRecordStates DeleteCountry(int ICountryId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Country obj = context.Country.Where(r => r.CountryId == ICountryId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Country.Remove(obj);
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
