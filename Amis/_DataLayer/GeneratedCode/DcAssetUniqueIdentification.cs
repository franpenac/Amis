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
    public class DcAssetUniqueIdentification
    {
        public void Copy(AssetUniqueIdentification objSource, ref AssetUniqueIdentification objDestination)
        {
            objDestination.AssetUniqueIdentificationId = objSource.AssetUniqueIdentificationId;
            objDestination.OriginId = objSource.OriginId;
            objDestination.AssetModelId = objSource.AssetModelId;
            objDestination.AssetModelServiceId = objSource.AssetModelServiceId;
            objDestination.AssetTypeId = objSource.AssetTypeId;
        }

        public AssetUniqueIdentification Save(AssetUniqueIdentification objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();
                        AssetUniqueIdentification row = context.AssetUniqueIdentification.Where(r => r.AssetUniqueIdentificationId == objSource.AssetUniqueIdentificationId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new AssetUniqueIdentification();
                            Copy(objSource, ref row);
                            context.AssetUniqueIdentification.Add(row);
                            action = CommonEnums.PageActionEnum.Create;
                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;
                        }
                        context.SaveChanges();
                        string description = "Se ha agregado una nueva combinacion con el id: "+row.AssetUniqueIdentificationId;
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

        public bool ExistsAssetUniqueIdentification(int AssetUniqueIdentificationId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                AssetUniqueIdentification obj = null;
                using (var context = new Entity())
                {
                    obj = context.AssetUniqueIdentification.Where(r => r.AssetUniqueIdentificationId != AssetUniqueIdentificationId).FirstOrDefault();
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

        public List<AssetUniqueIdentification> GetAssetUniqueIdentificationList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<AssetUniqueIdentification> list = context.AssetUniqueIdentification.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }
        
        public CommonEnums.DeletedRecordStates DeleteAssetUniqueIdentification(int IAssetUniqueIdentificationId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    AssetUniqueIdentification obj = context.AssetUniqueIdentification.Where(r => r.AssetUniqueIdentificationId == IAssetUniqueIdentificationId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.AssetUniqueIdentification.Remove(obj);
                    context.SaveChanges();

                    string description = "Se ha eliminado la combinación con el Id"+obj.AssetUniqueIdentificationId;
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

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    IEnumerable<object> list =
                        (from unique in context.AssetUniqueIdentification
                         join type in context.AssetType on unique.AssetTypeId equals type.AssetTypeId
                         join origin in context.Origin on unique.OriginId equals origin.OriginId
                         join model in context.AssetModel on unique.AssetModelId equals model.AssetModelId
                         join service in context.AssetModelService on unique.AssetModelServiceId equals service.AssetModelServiceId
                         select new
                         {
                             AssetUniqueIdentificationId = unique.AssetUniqueIdentificationId,
                             AssetTypeId = unique.AssetType.AssetTypeId,
                             AssetTypeName = unique.AssetType.AssetTypeName,
                             OriginId = unique.Origin.OriginId,
                             OriginName = unique.Origin.OriginName,
                             BrandId = unique.AssetModel.BrandId,
                             BrandName = unique.AssetModel.Brand.BrandName,
                             AssetModelId = unique.AssetModel.AssetModelId,
                             AssetModelName = unique.AssetModel.AssetModelName,
                             AssetModelServiceId = unique.AssetModelService.AssetModelServiceId,
                             AssetModelServiceName = unique.AssetModelService.AssetModelServiceName

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

        public bool ValidateUniqueIdentification(AssetUniqueIdentification objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                AssetUniqueIdentification obj = null;
                using (var context = new Entity())
                {
                    obj = context.AssetUniqueIdentification.Where(r => r.AssetTypeId == objSource.AssetTypeId 
                    && r.OriginId == objSource.OriginId && r.AssetModelId == objSource.AssetModelId
                    && r.AssetModelServiceId == objSource.AssetModelServiceId && r.SettingTyreId == objSource.SettingTyreId).FirstOrDefault();
                    if (obj != null)
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

        public AssetUniqueIdentification GetUniqueIdentification(int type, int origin, int model, int service, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    AssetUniqueIdentification obj = context.AssetUniqueIdentification.Where(r => r.AssetTypeId == type
                    && r.OriginId == origin && r.AssetModelId == model
                    && r.AssetModelServiceId == service).FirstOrDefault();

                    return obj;
                }

            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        //Metodos con filtro propio

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListAssetType(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Infragistics.Web.UI.ListControls.DropDownItem> list =
                        (from obj in context.AssetUniqueIdentification
                         join type in context.AssetType on obj.AssetType.AssetTypeId equals type.AssetTypeId
                         select new Infragistics.Web.UI.ListControls.DropDownItem()
                         {
                             Value = obj.AssetTypeId.ToString(),
                             Text = obj.AssetType.AssetTypeName
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

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListOrigin(int assetId, out string errorMessage)
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
                         where (obj.AssetTypeId == assetId)
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

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListBrand(int assetId, int originId,out string errorMessage)
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
                         where (obj.AssetTypeId == assetId && obj.OriginId == originId)
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

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListAssetModel(int assetId, int originId, int brandId, out string errorMessage)
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
                         where (obj.AssetTypeId == assetId && obj.OriginId == originId && obj.AssetModel.BrandId == brandId)
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

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListAssetModelService(int assetId, int originId, int brandId, int modelId, out string errorMessage)
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
                         where (obj.AssetTypeId == assetId && obj.OriginId == originId && obj.AssetModel.BrandId == brandId && obj.AssetModelId == modelId)
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

        public AssetUniqueIdentification GetAssetUniqueIdentificationById(int assetUniqueIdentificationId)
        {
            string errorMessage = "";
            try
            {
                using (var contex = new Entity())
                {
                    AssetUniqueIdentification obj = (from astui in contex.AssetUniqueIdentification where astui.AssetUniqueIdentificationId == assetUniqueIdentificationId select astui).FirstOrDefault();
                    return obj;
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