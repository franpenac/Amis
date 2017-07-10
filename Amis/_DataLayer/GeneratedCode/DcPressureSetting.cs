using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;
using System.Globalization;

namespace amis._DataLayer.GeneratedCode
{
    public partial class DcPressureSetting
    {
        public void Copy(PressureSetting objSource, ref PressureSetting objDestination)
        {
            objDestination.PressureSettingId = objSource.PressureSettingId;
            objDestination.ApplicationId = objSource.ApplicationId;
            objDestination.AssetModelId = objSource.AssetModelId;
            objDestination.Pressure = objSource.Pressure;
        }

        public PressureSetting Save(PressureSetting objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        PressureSetting row = context.PressureSetting.Where(r => r.PressureSettingId == objSource.PressureSettingId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new PressureSetting();
                            Copy(objSource, ref row);
                            context.PressureSetting.Add(row);
                            action = CommonEnums.PageActionEnum.Create;
                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;
                        }
                        context.SaveChanges();
                        string description = "Se ha agregado la configuracion de Id: "+row.PressureSettingId;
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

        public bool ExistsPressureSetting(int PressureSettingId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                PressureSetting obj = null;
                using (var context = new Entity())
                {
                    obj = context.PressureSetting.Where(r => r.PressureSettingId != PressureSettingId).FirstOrDefault();
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

        public List<PressureSetting> GetPressureSettingList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<PressureSetting> list = context.PressureSetting.ToList();
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
                        (from depthSetting in context.PressureSetting
                         join application in context.Application on depthSetting.ApplicationId equals application.ApplicationId
                         join asset in context.AssetModel on depthSetting.AssetModelId equals asset.AssetModelId
                         join brand in context.Brand on asset.BrandId equals brand.BrandId
                         select new
                         {
                             PressureSettingId = depthSetting.PressureSettingId,
                             ApplicationId = depthSetting.ApplicationId,
                             ApplicationName = depthSetting.Application.ApplicationName,
                             BrandId = depthSetting.AssetModel.BrandId,
                             BrandName = depthSetting.AssetModel.Brand.BrandName,
                             AssetModelId = depthSetting.AssetModelId,
                             AssetModelName = depthSetting.AssetModel.AssetModelName,
                             Pressure = depthSetting.Pressure.ToString() + "psi"
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

        public CommonEnums.DeletedRecordStates DeletePressureSetting(int IPressureSettingId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    PressureSetting obj = context.PressureSetting.Where(r => r.PressureSettingId == IPressureSettingId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.PressureSetting.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la configuracion con Id: "+obj.PressureSettingId;
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

        public bool ValidateSavePressureSetting(PressureSetting objSource, out string errorMessage)
        {
            using (var context = new Entity())
            {
                errorMessage = "";

                PressureSetting pressure = (from obj in context.PressureSetting
                                         where obj.ApplicationId == objSource.ApplicationId &&
                                      obj.AssetModelId == objSource.AssetModelId
                                            select obj).FirstOrDefault();

                if (pressure != null)
                {
                    errorMessage = "No fue posible guardar la configuración," +
                                    "debido a que los datos ingresados, ya existen en una configuración.";
                    return false;
                }
                return true;
            }
        }

        public PressureSetting GetPressureSettingByAssetModelId(int assetModelId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    PressureSetting obj = (from pressureSetting in context.PressureSetting where pressureSetting.AssetModelId == assetModelId select pressureSetting).FirstOrDefault();
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