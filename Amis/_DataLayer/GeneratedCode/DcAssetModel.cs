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
    public partial class DcAssetModel
    {
        public void Copy(AssetModel objSource, ref AssetModel objDestination)
        {
            objDestination.AssetModelId = objSource.AssetModelId;
            objDestination.AssetModelName = objSource.AssetModelName;
            objDestination.BrandId = objSource.BrandId;
        }

        public AssetModel Save(AssetModel objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();
                        AssetModel row = context.AssetModel.Where(r => r.AssetModelId == objSource.AssetModelId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new AssetModel();
                            Copy(objSource, ref row);
                            context.AssetModel.Add(row);
                            action = CommonEnums.PageActionEnum.Create;
                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;
                        }
                        context.SaveChanges();
                        string description = string.Format("Nombre modelo: {0}, Id: {1}", row.AssetModelName, row.AssetModelId);
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

        public bool ExistsAssetModel(int AssetModelId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                AssetModel obj = null;
                using (var context = new Entity())
                {
                    obj = context.AssetModel.Where(r => r.AssetModelId != AssetModelId).FirstOrDefault();
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

        public List<AssetModel> GetAssetModelList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<AssetModel> list = context.AssetModel.OrderBy(a=> a.AssetModelName).ToList();
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
                        (from obj in context.AssetModel
                         orderby (obj.AssetModelName)
                         select new TsDropDownItem()
                         {
                             ComboId = obj.AssetModelId.ToString(),
                             ComboName = obj.AssetModelName
                         }).ToList();

                    if (list != null)
                    {
                        list.Add(new TsDropDownItem { ComboId = (list.Count + 1).ToString(), ComboName = "Agregar Modelo" });
                    }
                    else
                    {
                        list.Add(new TsDropDownItem { ComboId = "1", ComboName = "Agregar Modelo" });
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

        public List<TsDropDownItem> GetComboListByFilter(int id,out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.AssetModel where obj.BrandId==id
                         orderby (obj.AssetModelName)
                         select new TsDropDownItem()
                         {
                             ComboId = obj.AssetModelId.ToString(),
                             ComboName = obj.AssetModelName
                         }).ToList();

                    if (list != null)
                    {
                        list.Add(new TsDropDownItem { ComboId = (list.Count + 1).ToString(), ComboName = "Agregar Modelo" });
                    }
                    else
                    {
                        list.Add(new TsDropDownItem { ComboId = "1", ComboName = "Agregar Modelo" });
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
                        (from AssetModel in context.AssetModel
                         select new
                         {
                             AssetModelId = AssetModel.AssetModelId,
                             AssetModelName = AssetModel.AssetModelName,
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

        public CommonEnums.DeletedRecordStates DeleteAssetModel(int IAssetModelId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    AssetModel obj = context.AssetModel.Where(r => r.AssetModelId == IAssetModelId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.AssetModel.Remove(obj);
                    context.SaveChanges();
                    string description = string.Format("Nombre modelo: {0}, Id: {1}", obj.AssetModelName, obj.AssetModelId);
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

        public AssetModel GetAssetModelById(int assetModelId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    AssetModel obj = (from assetModel in context.AssetModel where assetModel.AssetModelId == assetModelId select assetModel).FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<TsDropDownItem> GetComboListAssetModelTyreByBrandId(int id, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.AssetModel
                         join aui in context.AssetUniqueIdentification on obj.AssetModelId equals aui.AssetModelId
                         where obj.BrandId == id && aui.AssetTypeId == 1
                         orderby (obj.AssetModelName)
                         select new TsDropDownItem()
                         {
                             ComboId = obj.AssetModelId.ToString(),
                             ComboName = obj.AssetModelName
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