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
    public partial class DcSettingBattery
    {
        public void Copy(SettingBattery objSource, ref SettingBattery objDestination)
        {

            objDestination.SettingBatteryId = objSource.SettingBatteryId;
            objDestination.AssetModelId = objSource.AssetModelId;
            objDestination.Capacity = objSource.Capacity;
            objDestination.Voltage = objSource.Voltage;
            objDestination.PositionPolePositive = objSource.PositionPolePositive;
            objDestination.InstallDate = objSource.InstallDate;

        }

        public SettingBattery Save(SettingBattery objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {

                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        SettingBattery row = context.SettingBattery.Where(r => r.SettingBatteryId == objSource.SettingBatteryId).FirstOrDefault();
                        if (row == null)
                        {

                            row = new SettingBattery();
                            Copy(objSource, ref row);
                            context.SettingBattery.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha añadido la configuracion de baterias con el id:" + row.SettingBatteryId;
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

        public bool ExistsSettingBattery(int SettingBatteryId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                SettingBattery obj = null;
                using (var context = new Entity())
                {
                    obj = context.SettingBattery.Where(r => r.SettingBatteryId != SettingBatteryId).FirstOrDefault();
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

        public List<SettingBattery> GetSettingBatteryList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<SettingBattery> list = context.SettingBattery.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteSettingBattery(int ISettingBatteryId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    SettingBattery obj = context.SettingBattery.Where(r => r.SettingBatteryId == ISettingBatteryId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.SettingBattery.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la configuracion de baterias con el id:" + obj.SettingBatteryId;
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

    }
}