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
    public partial class DcDepthSetting
    {
        public void Copy(DepthSetting objSource, ref DepthSetting objDestination)
        {
            objDestination.DepthSettingId = objSource.DepthSettingId;
            objDestination.ApplicationId = objSource.ApplicationId;
            objDestination.AssetModelId = objSource.AssetModelId;
            objDestination.ScrapDepth = objSource.ScrapDepth;
        }
        
        public DepthSetting Save(DepthSetting objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();
                        DepthSetting row = context.DepthSetting.Where(r => r.DepthSettingId == objSource.DepthSettingId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new DepthSetting();
                            Copy(objSource, ref row);
                            context.DepthSetting.Add(row);
                            action = CommonEnums.PageActionEnum.Create;
                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;
                        }
                        context.SaveChanges();
                        string description = "Se ha registrado una nueva configuración de profundidad con el id: "+row.DepthSettingId;
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

        public bool ExistsDepthSetting(int DepthSettingId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                DepthSetting obj = null;
                using (var context = new Entity())
                {
                    obj = context.DepthSetting.Where(r => r.DepthSettingId != DepthSettingId).FirstOrDefault();
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

        public List<DepthSetting> GetDepthSettingList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<DepthSetting> list = context.DepthSetting.ToList();
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
            //No requiere ComboList
            errorMessage = "";
            List<TsDropDownItem> listado = null;
            return listado;
        }

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    IEnumerable<object> list =
                        (from depthSetting in context.DepthSetting
                         join application in context.Application on depthSetting.ApplicationId equals application.ApplicationId
                         join asset in context.AssetModel on depthSetting.AssetModelId equals asset.AssetModelId
                         join brand in context.Brand on asset.BrandId equals brand.BrandId
                         select new
                         {
                             DepthSettingId = depthSetting.DepthSettingId,
                             ApplicationId = depthSetting.ApplicationId,
                             ApplicationName = depthSetting.Application.ApplicationName,
                             BrandId = depthSetting.AssetModel.BrandId,
                             BrandName = depthSetting.AssetModel.Brand.BrandName,
                             AssetModelId = depthSetting.AssetModelId,
                             AssetModelName = depthSetting.AssetModel.AssetModelName,
                             ScrapDepth = depthSetting.ScrapDepth.ToString().Substring(0, 3) + "mm"
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

        public CommonEnums.DeletedRecordStates DeleteDepthSetting(int IDepthSettingId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    DepthSetting obj = context.DepthSetting.Where(r => r.DepthSettingId == IDepthSettingId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.DepthSetting.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la configuración con el Id: " + obj.DepthSettingId;
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

        public bool ValidateSaveDepthSetting(DepthSetting objSource, out string errorMessage)
        {
            using (var context = new Entity())
            {
                errorMessage = "";

                DepthSetting depth = (from obj in context.DepthSetting
                                      where obj.ApplicationId == objSource.ApplicationId &&
                                      obj.AssetModelId == objSource.AssetModelId &&
                                      obj.DepthSettingId == objSource.DepthSettingId
                                      select obj).FirstOrDefault();

                if (depth != null)
                {
                    errorMessage = "No fue posible guardar la configuración,"+
                                    "debido a que los datos ingresados, ya existen en una configuración.";
                    return false;
                }
                return true;
            }
        }
        
        public DepthSetting GetDepthSettingByAssetModelId(int assetModelId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    DepthSetting obj = (from depthSetting in context.DepthSetting where depthSetting.AssetModelId == assetModelId select depthSetting).FirstOrDefault();
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