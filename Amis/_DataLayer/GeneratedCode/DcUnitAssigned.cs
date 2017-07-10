using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;
using System.Web.UI.WebControls;

namespace amis._DataLayer.GeneratedCode
{
    public class DcUnitAssigned
    {
        //public List<ListItem> GetOriginList(out string errorMessage)
        //{
        //    errorMessage = "";
        //    try
        //    {
        //        using (var context = new Entity())
        //        {
        //            List<ListItem> list = (from obj in context.AssetUniqueIdentification
        //                                   join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
        //                                   join origin in context.Origin on obj.OriginId equals origin.OriginId
        //                                   where (type.AssetTypeName== "Vehiculo")
        //                                   select new ListItem()
        //                                   {
        //                                       Value = obj.OriginId.ToString(),
        //                                       Text = obj.Origin.OriginName
        //                                   }).Distinct().ToList();
        //            ListItem Default = new ListItem();
        //            Default.Text = "Seleccione";
        //            Default.Value = "0";
        //            list.Insert(0, Default);

        //            return list;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = ErrorController.GetErrorMessage(ex);
        //        return null;
        //    }
        //}

        //public List<ListItem> GetComboListBrand(int originId, out string errorMessage)
        //{
        //    errorMessage = "";
        //    try
        //    {
        //        using (var context = new Entity())
        //        {
        //            List<ListItem> list =
        //                (from obj in context.AssetUniqueIdentification
        //                 join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
        //                 join origin in context.Origin on obj.OriginId equals origin.OriginId
        //                 where (type.AssetTypeName == "Vehiculo" && obj.OriginId == originId)
        //                 select new ListItem()
        //                 {
        //                     Value = obj.AssetModel.BrandId.ToString(),
        //                     Text = obj.AssetModel.Brand.BrandName
        //                 }).Distinct().ToList();
        //            ListItem Default = new ListItem();
        //            Default.Text = "Seleccione";
        //            Default.Value = "0";
        //            list.Insert(0, Default);
        //            return list;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = ErrorController.GetErrorMessage(ex);
        //        return null;
        //    }
        //}

        //public List<ListItem> GetComboListAssetModel(int originId, int brandId, out string errorMessage)
        //{
        //    errorMessage = "";
        //    try
        //    {
        //        using (var context = new Entity())
        //        {
        //            List<ListItem> list =
        //                (from obj in context.AssetUniqueIdentification
        //                 join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
        //                 join origin in context.Origin on obj.OriginId equals origin.OriginId
        //                 join brand in context.Brand on obj.AssetModel.BrandId equals brand.BrandId
        //                 join model in context.AssetModel on obj.AssetModelId equals model.AssetModelId
        //                 where (type.AssetTypeName == "Vehiculo" && obj.OriginId == originId && obj.AssetModel.BrandId == brandId)
        //                 select new ListItem()
        //                 {
        //                     Value = obj.AssetModelId.ToString(),
        //                     Text = obj.AssetModel.AssetModelName
        //                 }).Distinct().ToList();

        //            ListItem Default = new ListItem();
        //            Default.Text = "Seleccione";
        //            Default.Value = "0";
        //            list.Insert(0, Default);

        //            return list;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = ErrorController.GetErrorMessage(ex);
        //        return null;
        //    }
        //}

        //public List<ListItem> GetComboListAssetModelService(int originId, int brandId, int modelId, out string errorMessage)
        //{
        //    errorMessage = "";
        //    try
        //    {
        //        using (var context = new Entity())
        //        {
        //            List<ListItem> list =
        //                (from obj in context.AssetUniqueIdentification
        //                 join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
        //                 join origin in context.Origin on obj.OriginId equals origin.OriginId
        //                 join brand in context.Brand on obj.AssetModel.BrandId equals brand.BrandId
        //                 join model in context.AssetModel on obj.AssetModelId equals model.AssetModelId
        //                 join service in context.AssetModelService on obj.AssetModelServiceId equals service.AssetModelServiceId
        //                 where (type.AssetTypeName == "Vehiculo" && obj.OriginId == originId && obj.AssetModel.BrandId == brandId && obj.AssetModelId == modelId)
        //                 select new ListItem()
        //                 {
        //                     Value = obj.AssetUniqueIdentificationId.ToString(),
        //                     Text = obj.AssetModelService.AssetModelServiceName
        //                 }).Distinct().ToList();

        //            ListItem Default = new ListItem();
        //            Default.Text = "Seleccione";
        //            Default.Value = "0";
        //            list.Insert(0, Default);

        //            return list;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = ErrorController.GetErrorMessage(ex);
        //        return null;
        //    }
        //}

        public List<UnitRegister> GetComboUnitRegister(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    
                    List<UnitRegister> list2 =
                        (from obj in context.UnitRegister
                         join unit in context.Unit on obj.UnitRegisterId equals unit.UnitRegisterId
                         join asset in context.TagAssigned on unit.AssetId equals asset.AssetId
                         select obj).Distinct().ToList();

                    List<UnitRegister> list =
                        (from obj in context.UnitRegister
                         join unit in context.Unit on obj.UnitRegisterId equals unit.UnitRegisterId
                         select obj).Distinct().ToList();

                    foreach (UnitRegister item2 in list2)
                    {
                        foreach (UnitRegister item in list)
                        {
                            if(item.UnitRegisterId == item2.UnitRegisterId)
                            {
                                list.Remove(item);
                                break;
                            }
                        }
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

        public void Copy(Unit objSource, ref Unit objDestination)
        {
            objDestination.UnitId = objSource.UnitId;
            objDestination.AssetId = objSource.AssetId;
            objDestination.UnitRegisterId = objSource.UnitRegisterId;
            
        }

        public Unit Save(Unit objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        Unit row = context.Unit.Where(r => r.UnitId == objSource.UnitId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Unit();
                            Copy(objSource, ref row);
                            context.Unit.Add(row);
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

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListOrigin(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Infragistics.Web.UI.ListControls.DropDownItem> list =
                        (from obj in context.AssetUniqueIdentification
                         join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
                         join origin in context.Origin on obj.OriginId equals origin.OriginId
                         where (type.AssetTypeName == "Vehiculo")
                         select new Infragistics.Web.UI.ListControls.DropDownItem()
                         {
                             Value = obj.OriginId.ToString(),
                             Text = obj.Origin.OriginName
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

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListBrand(int originId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Infragistics.Web.UI.ListControls.DropDownItem> list =
                        (from obj in context.AssetUniqueIdentification
                         join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
                         join origin in context.Origin on obj.OriginId equals origin.OriginId
                         where (type.AssetTypeName == "Vehiculo" && obj.OriginId == originId)
                         select new Infragistics.Web.UI.ListControls.DropDownItem()
                         {
                             Value = obj.AssetModel.BrandId.ToString(),
                             Text = obj.AssetModel.Brand.BrandName
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

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListAssetModel(int originId, int brandId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Infragistics.Web.UI.ListControls.DropDownItem> list =
                        (from obj in context.AssetUniqueIdentification
                         join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
                         join origin in context.Origin on obj.OriginId equals origin.OriginId
                         join brand in context.Brand on obj.AssetModel.BrandId equals brand.BrandId
                         join model in context.AssetModel on obj.AssetModelId equals model.AssetModelId
                         where (type.AssetTypeName == "Vehiculo" && obj.OriginId == originId && obj.AssetModel.BrandId == brandId)
                         select new Infragistics.Web.UI.ListControls.DropDownItem()
                         {
                             Value = obj.AssetModelId.ToString(),
                             Text = obj.AssetModel.AssetModelName
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

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListAssetModelService(int originId, int brandId, int modelId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Infragistics.Web.UI.ListControls.DropDownItem> list =
                        (from obj in context.AssetUniqueIdentification
                         join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
                         join origin in context.Origin on obj.OriginId equals origin.OriginId
                         join brand in context.Brand on obj.AssetModel.BrandId equals brand.BrandId
                         join model in context.AssetModel on obj.AssetModelId equals model.AssetModelId
                         join service in context.AssetModelService on obj.AssetModelServiceId equals service.AssetModelServiceId
                         where (type.AssetTypeName == "Vehiculo" && obj.OriginId == originId && obj.AssetModel.BrandId == brandId && obj.AssetModelId == modelId)
                         select new Infragistics.Web.UI.ListControls.DropDownItem()
                         {
                             Value = obj.AssetModelServiceId.ToString(),
                             Text = obj.AssetModelService.AssetModelServiceName
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

        public Unit GetUnitByUnitRegisterId(int UnitRegisterId, out string errorMessage)
        {
            try
            {
                errorMessage = "";
                using (var context = new Entity())
                {
                    Unit unit = (from u in context.Unit where u.UnitRegisterId == UnitRegisterId select u).FirstOrDefault();

                    if(unit != null)
                    {
                        
                        return unit;
                    }
                    else { return null; }

                }
            }catch(Exception ex)
            {
                errorMessage = ex.ToString();
                return null;
            }
        }

       
        /// /////////////////////
        /// 
        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboOriginUnit(int brandId, int modelId, int servi, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Infragistics.Web.UI.ListControls.DropDownItem> list =
                        (from obj in context.AssetUniqueIdentification
                         join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
                         join origin in context.Origin on obj.OriginId equals origin.OriginId
                         join brand in context.Brand on obj.AssetModel.BrandId equals brand.BrandId
                         join model in context.AssetModel on obj.AssetModelId equals model.AssetModelId
                         join service in context.AssetModelService on obj.AssetModelServiceId equals service.AssetModelServiceId
                         where (type.AssetTypeName == "Vehiculo" && obj.AssetModel.BrandId == brandId && obj.AssetModelId == modelId && obj.AssetModelServiceId == servi )
                         select new Infragistics.Web.UI.ListControls.DropDownItem()
                         {
                             Value = obj.AssetUniqueIdentificationId.ToString(),
                             Text = obj.Origin.OriginName
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

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboBrandUnit(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Infragistics.Web.UI.ListControls.DropDownItem> list =
                        (from obj in context.AssetUniqueIdentification
                         join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
                         join origin in context.Origin on obj.OriginId equals origin.OriginId
                         where (type.AssetTypeName == "Vehiculo")
                         select new Infragistics.Web.UI.ListControls.DropDownItem()
                         {
                             Value = obj.AssetModel.BrandId.ToString(),
                             Text = obj.AssetModel.Brand.BrandName
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

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboAssetModelUnit(int brandId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Infragistics.Web.UI.ListControls.DropDownItem> list =
                        (from obj in context.AssetUniqueIdentification
                         join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
                         join origin in context.Origin on obj.OriginId equals origin.OriginId
                         join brand in context.Brand on obj.AssetModel.BrandId equals brand.BrandId
                         join model in context.AssetModel on obj.AssetModelId equals model.AssetModelId
                         where (type.AssetTypeName == "Vehiculo" && obj.AssetModel.BrandId == brandId)
                         select new Infragistics.Web.UI.ListControls.DropDownItem()
                         {
                             Value = obj.AssetModelId.ToString(),
                             Text = obj.AssetModel.AssetModelName
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

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboAssetModelServiceUnit(int brandId, int modelId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Infragistics.Web.UI.ListControls.DropDownItem> list =
                        (from obj in context.AssetUniqueIdentification
                         join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
                         join origin in context.Origin on obj.OriginId equals origin.OriginId
                         join brand in context.Brand on obj.AssetModel.BrandId equals brand.BrandId
                         join model in context.AssetModel on obj.AssetModelId equals model.AssetModelId
                         join service in context.AssetModelService on obj.AssetModelServiceId equals service.AssetModelServiceId
                         where (type.AssetTypeName == "Vehiculo" && obj.AssetModel.BrandId == brandId && obj.AssetModelId == modelId)
                         select new Infragistics.Web.UI.ListControls.DropDownItem()
                         {
                             Value = obj.AssetModelServiceId.ToString(),
                             Text = obj.AssetModelService.AssetModelServiceName
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

        public Asset GetAssetById(int AssetId)
        {
            using (var context = new Entity())
            {
                Asset asset = (from a in context.Asset
                               where a.AssetId == AssetId
                               select a).FirstOrDefault();
                return asset;
            }
        }

        public AssetUniqueIdentification GetAUItById(int AUIId)
        {
            using (var context = new Entity())
            {
                AssetUniqueIdentification AUI = (from a in context.AssetUniqueIdentification
                               where a.AssetUniqueIdentificationId == AUIId
                                                 select a).FirstOrDefault();
                return AUI;
            }
        }

        public Brand GetBrandbyModelId(int modelId)
        {
            using (var context = new Entity())
            {
                Brand brand = (from a in context.Brand
                               join m in context.AssetModel on a.BrandId equals m.BrandId
                               where m.AssetModelId == modelId
                               select a).FirstOrDefault();
                return brand;
            }
        }
    }
}