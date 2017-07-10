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
    public partial class DcSettingCat
    {
        public void Copy(SettingCat objSource, ref SettingCat objDestination)
        {

            objDestination.SettingCatId = objSource.SettingCatId;
            objDestination.AssetModelId = objSource.AssetModelId;
            objDestination.Capacity = objSource.Capacity;

        }

        public SettingCat Save(SettingCat objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                    using (TransactionScope transaction = new TransactionScope())
                    {
                        SettingCat row = context.SettingCat.Where(r => r.SettingCatId == objSource.SettingCatId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new SettingCat();
                            Copy(objSource, ref row);
                            context.SettingCat.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha añadido la configuracion de gata con el id:" + row.SettingCatId;
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

        public bool ExistsSettingCat(int SettingCatId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                SettingCat obj = null;
                using (var context = new Entity())
                {
                    obj = context.SettingCat.Where(r => r.SettingCatId != SettingCatId).FirstOrDefault();
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

        public List<SettingCat> GetSettingCatList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<SettingCat> list = context.SettingCat.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteSettingCat(int ISettingCatId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    SettingCat obj = context.SettingCat.Where(r => r.SettingCatId == ISettingCatId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.SettingCat.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la configuracion de gata con el id:" + obj.SettingCatId;
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