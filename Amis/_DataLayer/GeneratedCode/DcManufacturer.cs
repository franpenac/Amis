using amis._Common;
using amis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace amis._DataLayer.GeneratedCode
{
    public class DcManufacturer
    {
        public void Copy(Manufacturer objSource, ref Manufacturer objDestination)
        {
            objDestination.ManufacturerId = objSource.ManufacturerId;
            objDestination.ManufacturerName = objSource.ManufacturerName;
        }

        public Manufacturer Save(Manufacturer objSource)
        {
            
                using (var context = new Entity())
                {
                    Manufacturer row = context.Manufacturer.Where(r => r.ManufacturerId == objSource.ManufacturerId).FirstOrDefault();

                    using (TransactionScope transaction = new TransactionScope())
                    {
                        if (row == null)
                        {
                            row = new Manufacturer();
                            Copy(objSource, ref row);
                            context.Manufacturer.Add(row);
                        }
                        else
                        {
                            Copy(objSource, ref row);
                        }

                        context.SaveChanges();
                        transaction.Complete();
                    }
                    return row;
                }
           
        }

        public bool ExistsManufacturer(int ManufacturerId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Manufacturer obj = null;
                using (var context = new Entity())
                {
                    obj = context.Manufacturer.Where(r => r.ManufacturerId == ManufacturerId).FirstOrDefault();
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

        public List<Manufacturer> GetManufacturerList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Manufacturer> list = context.Manufacturer.OrderBy(r => r.ManufacturerName).ToList();
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
                        (from obj in context.Manufacturer
                         select new TsDropDownItem()
                         {
                             ComboId = obj.ManufacturerId.ToString(),
                             ComboName = obj.ManufacturerName
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

        public int GetNewManufacturerId()
        {
            using (var context = new Entity())
            {
                int maxId = 0;
                int numOrigins = context.Manufacturer.Count();
                if (numOrigins == 0)
                {
                    maxId = 1;
                }
                else
                {
                    maxId = context.Manufacturer.Max(r => r.ManufacturerId);
                }
                return maxId + 1;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteManufacturer(int iManufacturerId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Manufacturer obj = context.Manufacturer.Where(r => r.ManufacturerId == iManufacturerId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Manufacturer.Remove(obj);
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

        public List<String> GetManufacturer()
        {
            List<Manufacturer> list = new List<Manufacturer>();
            List<String> fabricantes = new List<String>();

            using (var context = new Entity())
            {
                list = context.Manufacturer.OrderBy(r => r.ManufacturerName).ToList();
            }

            foreach (Manufacturer p in list)
            {
                fabricantes.Add(p.ManufacturerName);
            }
            return fabricantes;
        }

        public int GetIdManufacturer(String manufacturerName)
        {
            int Id = 0;
            using (var context = new Entity())
            {
                Manufacturer obj = context.Manufacturer.Where(r => r.ManufacturerName == manufacturerName).FirstOrDefault();
                if (obj == null)
                {

                }
                else
                { Id = obj.ManufacturerId; }
            }
            return Id;
        }
        
        public String GetManufacturerName(int manufacturerId)
        {
            using (var context = new Entity())
            {
                String fabricanteBuscado = "";
                Manufacturer obj = context.Manufacturer.Where(r => r.ManufacturerId == manufacturerId).FirstOrDefault();
                if (obj != null)
                {
                    fabricanteBuscado = obj.ManufacturerName;
                }
                return fabricanteBuscado;
            }
        }

        public bool FindBrandByManufacturerId(int manufacturerId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Brand obj = null;
                using (var context = new Entity())
                {
                    obj = context.Brand.Where(r => r.ManufacturerId == manufacturerId).FirstOrDefault();
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

        public bool ExistsManufacturerName(string ManufacturerName, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Manufacturer obj = null;
                using (var context = new Entity())
                {
                    obj = context.Manufacturer.Where(r => r.ManufacturerName == ManufacturerName).FirstOrDefault();
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
    }
}