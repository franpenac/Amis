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
    public partial class DcBrand
    {
        public void Copy(Brand objSource, ref Brand objDestination)
        {
            objDestination.BrandId = objSource.BrandId;
            objDestination.BrandName = objSource.BrandName;
            objDestination.ManufacturerId = objSource.ManufacturerId;
        }

        public Brand Save(Brand objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();
                        Brand row = context.Brand.Where(r => r.BrandId == objSource.BrandId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Brand();
                            Copy(objSource, ref row);
                            context.Brand.Add(row);
                            action = CommonEnums.PageActionEnum.Create;
                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;
                        }
                        context.SaveChanges();
                        string description = string.Format("Nombre marca: {0}, Id: {1}", row.BrandName, row.BrandId);
                        new DcPageLog().Save(action, description);
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

        public bool ExistsBrand(int BrandId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Brand obj = null;
                using (var context = new Entity())
                {
                    obj = context.Brand.Where(r => r.BrandId != BrandId).FirstOrDefault();
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

        public List<Brand> GetBrandList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Brand> list = context.Brand.OrderBy(r => r.BrandName).ToList();
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
                        (from obj in context.Brand orderby(obj.BrandName)
                         select new TsDropDownItem()
                         {
                             ComboId = obj.BrandId.ToString(),
                             ComboName = obj.BrandName
                         }).ToList();
                    if (list!=null)
                    {
                        list.Add(new TsDropDownItem {ComboId= (list.Count+1).ToString(), ComboName="Agregar Marca"});
                    }
                    else
                    {
                        list.Add(new TsDropDownItem { ComboId = "1", ComboName = "Agregar Marca" });
                    }
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
                        (from brand in context.Brand
                         join manufacturer in context.Manufacturer on brand.ManufacturerId equals manufacturer.ManufacturerId
                         select new 
                         {
                             BrandId = brand.BrandId,
                             BrandName = brand.BrandName,
                             ManufacturerId = manufacturer.ManufacturerId,
                             ManufacturerName = manufacturer.ManufacturerName
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

        public CommonEnums.DeletedRecordStates DeleteBrand(int IBrandId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Brand obj = context.Brand.Where(r => r.BrandId == IBrandId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Brand.Remove(obj);
                    context.SaveChanges();
                    string description = string.Format("Nombre marca: {0}, Id: {1}", obj.BrandName, obj.BrandId);
                    new DcPageLog().Save(CommonEnums.PageActionEnum.Delete, description);
                    return CommonEnums.DeletedRecordStates.DeletedOk;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return CommonEnums.DeletedRecordStates.NotDeleted;
            }
        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListExistModel(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Infragistics.Web.UI.ListControls.DropDownItem> list =
                        (from obj in context.Brand
                         join mo in context.AssetModel on obj.BrandId equals mo.BrandId

                         orderby (obj.BrandName)
                         select new Infragistics.Web.UI.ListControls.DropDownItem
                         {
                             Value = obj.BrandId.ToString(),
                             Text = obj.BrandName
                         }).Distinct().ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public Brand GetBrandById(int brandId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    Brand obj = (from brand in context.Brand where brand.BrandId == brandId select brand).FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex) 
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListExistModelTyre(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Infragistics.Web.UI.ListControls.DropDownItem> list =
                        (from obj in context.Brand
                         join mo in context.AssetModel on obj.BrandId equals mo.BrandId
                         join aui in context.AssetUniqueIdentification on mo.AssetModelId equals aui.AssetModelId
                         where aui.AssetTypeId == 1

                         orderby (obj.BrandName)
                         select new Infragistics.Web.UI.ListControls.DropDownItem
                         {
                             Value = obj.BrandId.ToString(),
                             Text = obj.BrandName
                         }).Distinct().ToList();

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