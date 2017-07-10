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
    public partial class DcSettingLigthPole
    {
        public void Copy(SettingLigthPole objSource, ref SettingLigthPole objDestination)
        {
            
            objDestination.SettingLigthPoleId = objSource.SettingLigthPoleId;
            objDestination.AssetModelId = objSource.AssetModelId;
            objDestination.InstallDate = objSource.InstallDate;

        }

        public SettingLigthPole Save(SettingLigthPole objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        SettingLigthPole row = context.SettingLigthPole.Where(r => r.SettingLigthPoleId == objSource.SettingLigthPoleId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new SettingLigthPole();
                            Copy(objSource, ref row);
                            context.SettingLigthPole.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha añadido la configuracion de pertiga con el id:" + row.SettingLigthPoleId;
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

        public bool ExistsSettingLigthPole(int SettingLigthPoleId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                SettingLigthPole obj = null;
                using (var context = new Entity())
                {
                    obj = context.SettingLigthPole.Where(r => r.SettingLigthPoleId != SettingLigthPoleId).FirstOrDefault();
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

        public List<SettingLigthPole> GetSettingLigthPoleList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<SettingLigthPole> list = context.SettingLigthPole.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteSettingLigthPole(int ISettingLigthPoleId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    SettingLigthPole obj = context.SettingLigthPole.Where(r => r.SettingLigthPoleId == ISettingLigthPoleId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.SettingLigthPole.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la configuracion de pertiga con el id:" + obj.SettingLigthPoleId;
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