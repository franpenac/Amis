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
    public partial class DcAssetModelService
    {
        public void Copy(AssetModelService objSource, ref AssetModelService objDestination)
        {
            objDestination.AssetModelServiceId = objSource.AssetModelServiceId;
            objDestination.AssetModelServiceName = objSource.AssetModelServiceName;
        }

        public AssetModelService Save(AssetModelService objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        AssetModelService service = context.AssetModelService.Where(r => r.AssetModelServiceName.ToUpper() == objSource.AssetModelServiceName.ToUpper() && r.AssetModelServiceId != objSource.AssetModelServiceId).FirstOrDefault();
                        if (service != null) return (AssetModelService)ErrorController.SetErrorMessage("Repeated model service name", out errorMessage);

                        AssetModelService row = context.AssetModelService.Where(r => r.AssetModelServiceId == objSource.AssetModelServiceId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new AssetModelService();
                            Copy(objSource, ref row);
                            context.AssetModelService.Add(row);
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

        public bool ExistsAssetModelService(int AssetModelServiceId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                AssetModelService obj = null;
                using (var context = new Entity())
                {
                    obj = context.AssetModelService.Where(r => r.AssetModelServiceId != AssetModelServiceId).FirstOrDefault();
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

        public List<AssetModelService> GetAssetModelServiceList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<AssetModelService> list = context.AssetModelService.OrderBy(a => a.AssetModelServiceName).ToList();
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
                        (from obj in context.AssetModelService
                         select new TsDropDownItem()
                         {
                             ComboId = obj.AssetModelServiceId.ToString(),
                             ComboName = obj.AssetModelServiceName
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
                        (from AssetModelService in context.AssetModelService
                         select new
                         {
                             AssetModelServiceId = AssetModelService.AssetModelServiceId,
                             AssetModelServiceName = AssetModelService.AssetModelServiceName

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

        public CommonEnums.DeletedRecordStates DeleteAssetModelService(int IAssetModelServiceId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    AssetModelService obj = context.AssetModelService.Where(r => r.AssetModelServiceId == IAssetModelServiceId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.AssetModelService.Remove(obj);
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

    }
}