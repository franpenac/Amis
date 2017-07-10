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
    public partial class DcAssetType
    {
        public int GetTypeById(string text)
        {
            try
            {
                using (var context = new Entity())
                {
                    AssetType type =
                        (from obj in context.AssetType
                         where obj.AssetTypeName == text
                         select obj).FirstOrDefault();
                    return type.AssetTypeId;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public void Copy(AssetType objSource, ref AssetType objDestination)
        {
            objDestination.AssetTypeId = objSource.AssetTypeId;
            objDestination.AssetTypeName = objSource.AssetTypeName;
        }

        public AssetType Save(AssetType objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        AssetType service = context.AssetType.Where(r => r.AssetTypeName.ToUpper() == objSource.AssetTypeName.ToUpper() && r.AssetTypeId != objSource.AssetTypeId).FirstOrDefault();
                        if (service != null) return (AssetType)ErrorController.SetErrorMessage("Repeated type name", out errorMessage);

                        AssetType row = context.AssetType.Where(r => r.AssetTypeId == objSource.AssetTypeId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new AssetType();
                            Copy(objSource, ref row);
                            context.AssetType.Add(row);
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

        public bool ExistsAssetType(int AssetTypeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                AssetType obj = null;
                using (var context = new Entity())
                {
                    obj = context.AssetType.Where(r => r.AssetTypeId != AssetTypeId).FirstOrDefault();
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

        public List<AssetType> GetAssetTypeList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<AssetType> list = context.AssetType.OrderBy(a => a.AssetTypeName).ToList();
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
                        (from obj in context.AssetType
                         select new TsDropDownItem()
                         {
                             ComboId = obj.AssetTypeId.ToString(),
                             ComboName = obj.AssetTypeName
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
                        (from AssetType in context.AssetType
                         select new
                         {
                             AssetTypeId = AssetType.AssetTypeId,
                             AssetTypeName = AssetType.AssetTypeName

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

        public CommonEnums.DeletedRecordStates DeleteAssetType(int IAssetTypeId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    AssetType obj = context.AssetType.Where(r => r.AssetTypeId == IAssetTypeId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.AssetType.Remove(obj);
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

        public string GetAssetTypeNameById(int assetTypeId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    AssetType AssetType = (from assetType in context.AssetType where assetType.AssetTypeId == assetTypeId select assetType).FirstOrDefault();
                    string typeName = AssetType.AssetTypeName;
                    if (typeName != null)
                    {
                        return typeName;
                    }else
                    {
                        typeName = "";
                        return typeName;
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public string GetAssetTypeNameByAssetId(int assetId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    AssetType AssetType = (from assetType in context.AssetType
                                           join aui in context.AssetUniqueIdentification on assetType.AssetTypeId equals aui.AssetTypeId
                                           join asset in context.Asset on aui.AssetUniqueIdentificationId equals asset.AssetUniqueIdentificationId
                                           where asset.AssetId == assetId
                                           select assetType).FirstOrDefault();
                    if (AssetType != null)
                    {
                        return AssetType.AssetTypeName;
                    }
                    else
                    {
                        return AssetType.AssetTypeName;
                    }
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