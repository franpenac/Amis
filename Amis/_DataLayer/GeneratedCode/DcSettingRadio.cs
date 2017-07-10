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
    public partial class DcSettingRadio
    {
        public void Copy(SettingRadio objSource, ref SettingRadio objDestination)
        {

            objDestination.SettingRadioId = objSource.SettingRadioId;
            objDestination.AssetModelId = objSource.AssetModelId;
            objDestination.EndOfUseDate = objSource.EndOfUseDate;
        }

        public SettingRadio Save(SettingRadio objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        SettingRadio row = context.SettingRadio.Where(r => r.SettingRadioId == objSource.SettingRadioId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new SettingRadio();
                            Copy(objSource, ref row);
                            context.SettingRadio.Add(row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha añadido la configuracion de radio con el id:" + row.SettingRadioId;
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

        public bool ExistsSettingRadio(int SettingRadioId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                SettingRadio obj = null;
                using (var context = new Entity())
                {
                    obj = context.SettingRadio.Where(r => r.SettingRadioId != SettingRadioId).FirstOrDefault();
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

        public List<SettingRadio> GetSettingRadioList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<SettingRadio> list = context.SettingRadio.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteSettingRadio(int ISettingRadioId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    SettingRadio obj = context.SettingRadio.Where(r => r.SettingRadioId == ISettingRadioId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.SettingRadio.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la configuracion de radio con el id:" + obj.SettingRadioId;
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