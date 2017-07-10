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
    public partial class DcSettingExtinguisher
    {
        public void Copy(SettingExtinguisher objSource, ref SettingExtinguisher objDestination)
        {
            
            objDestination.SettingExtinguisherId = objSource.SettingExtinguisherId;
            objDestination.AssetModelId = objSource.AssetModelId;
            objDestination.FireTypeId = objSource.FireTypeId;
            objDestination.FireSize = objSource.FireSize;
            objDestination.EndLifeDate = objSource.EndLifeDate;

        }
        
        public SettingExtinguisher Save(SettingExtinguisher objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                    using (TransactionScope transaction = new TransactionScope())
                    {
                        SettingExtinguisher row = context.SettingExtinguisher.Where(r => r.SettingExtinguisherId == objSource.SettingExtinguisherId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new SettingExtinguisher();
                            Copy(objSource, ref row);
                            context.SettingExtinguisher.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha añadido la configuracion de extintor con el id:" + row.SettingExtinguisherId;
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

        public bool ExistsSettingExtinguisher(int SettingExtinguisherId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                SettingExtinguisher obj = null;
                using (var context = new Entity())
                {
                    obj = context.SettingExtinguisher.Where(r => r.SettingExtinguisherId != SettingExtinguisherId).FirstOrDefault();
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

        public List<SettingExtinguisher> GetSettingExtinguisherList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<SettingExtinguisher> list = context.SettingExtinguisher.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteSettingExtinguisher(int ISettingExtinguisherId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    SettingExtinguisher obj = context.SettingExtinguisher.Where(r => r.SettingExtinguisherId == ISettingExtinguisherId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.SettingExtinguisher.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la configuracion de extintor con el id:" + obj.SettingExtinguisherId;
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