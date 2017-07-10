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
    public partial class DcConfigurationUnitType
    {
        public void Copy(ConfigurationUnitType objSource, ref ConfigurationUnitType objDestination)
        {
            objDestination.ConfigurationUnitTypeId = objSource.ConfigurationUnitTypeId;
            objDestination.ConfigurationUnitTypeName = objSource.ConfigurationUnitTypeName;
        }
        
        public ConfigurationUnitType Save(ConfigurationUnitType objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        ConfigurationUnitType service = context.ConfigurationUnitType.Where(r => r.ConfigurationUnitTypeName.ToUpper() == objSource.ConfigurationUnitTypeName.ToUpper() && r.ConfigurationUnitTypeId != objSource.ConfigurationUnitTypeId).FirstOrDefault();
                        if (service != null) return (ConfigurationUnitType)ErrorController.SetErrorMessage("Repeated ConfigurationUnitType name", out errorMessage);

                        ConfigurationUnitType row = context.ConfigurationUnitType.Where(r => r.ConfigurationUnitTypeId == objSource.ConfigurationUnitTypeId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new ConfigurationUnitType();
                            Copy(objSource, ref row);
                            context.ConfigurationUnitType.Add(row);
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

        public bool ExistsConfigurationUnitType(int ConfigurationUnitTypeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                ConfigurationUnitType obj = null;
                using (var context = new Entity())
                {
                    obj = context.ConfigurationUnitType.Where(r => r.ConfigurationUnitTypeId != ConfigurationUnitTypeId).FirstOrDefault();
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

        public List<ConfigurationUnitType> GetConfigurationUnitTypeList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<ConfigurationUnitType> list = context.ConfigurationUnitType.OrderBy(a => a.ConfigurationUnitTypeName).ToList();
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
                        (from obj in context.ConfigurationUnitType
                         select new TsDropDownItem()
                         {
                             ComboId = obj.ConfigurationUnitTypeId.ToString(),
                             ComboName = obj.ConfigurationUnitTypeName
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

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    IEnumerable<object> list =
                        (from ConfigurationUnitType in context.ConfigurationUnitType
                         select new
                         {
                             ConfigurationUnitTypeId = ConfigurationUnitType.ConfigurationUnitTypeId,
                             ConfigurationUnitTypeName = ConfigurationUnitType.ConfigurationUnitTypeName

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

        public CommonEnums.DeletedRecordStates DeleteConfigurationUnitType(int IConfigurationUnitTypeId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    ConfigurationUnitType obj = context.ConfigurationUnitType.Where(r => r.ConfigurationUnitTypeId == IConfigurationUnitTypeId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.ConfigurationUnitType.Remove(obj);
                    context.SaveChanges();
                    return CommonEnums.DeletedRecordStates.DeletedOk;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return CommonEnums.DeletedRecordStates.NotDeleted;
            }
        }

        public ConfigurationUnitType GetConfigurationUnitType(int configurationUnitTypeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    ConfigurationUnitType obj = context.ConfigurationUnitType.Where(r => r.ConfigurationUnitTypeId == configurationUnitTypeId).FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public ConfigurationUnitType GetMinConfigurationUnitType(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    ConfigurationUnitType obj = context.ConfigurationUnitType.OrderBy(r => r.ConfigurationUnitTypeId).Take(1).FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public ConfigurationUnitType GetMaxConfigurationUnitType(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    ConfigurationUnitType obj = context.ConfigurationUnitType.OrderByDescending(r => r.ConfigurationUnitTypeId).Take(1).FirstOrDefault();
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
