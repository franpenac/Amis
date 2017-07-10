using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;
using System.Web.UI.WebControls;

namespace amis._DataLayer.GeneratedCode
{
    public partial class DcSettingTyre
    {
        public void Copy(SettingTyre objSource, ref SettingTyre objDestination)
        {
            
            objDestination.SettingTyreId = objSource.SettingTyreId;
            objDestination.Original = objSource.Original;
            objDestination.DepthNumber = objSource.DepthNumber;
            objDestination.IndexWeghId = objSource.IndexWeghId;
            objDestination.MeasurementsTyreId = objSource.MeasurementsTyreId;
            objDestination.SpeedIndexId = objSource.SpeedIndexId;


        }

        public SettingTyre Save(SettingTyre objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        SettingTyre row = context.SettingTyre.Where(r => r.SettingTyreId == objSource.SettingTyreId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new SettingTyre();
                            Copy(objSource, ref row);
                            context.SettingTyre.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha añadido la configuracion de neumatico con el id:" + row.SettingTyreId;
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

        public bool ExistsSettingTyre(int SettingTyreId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                SettingTyre obj = null;
                using (var context = new Entity())
                {
                    obj = context.SettingTyre.Where(r => r.SettingTyreId != SettingTyreId).FirstOrDefault();
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

        public List<SettingTyre> GetSettingTyreList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<SettingTyre> list = context.SettingTyre.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteSettingTyre(int ISettingTyreId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    SettingTyre obj = context.SettingTyre.Where(r => r.SettingTyreId == ISettingTyreId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.SettingTyre.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la configuracion de neumatico con el id:" + obj.SettingTyreId;
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

        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list = new List<TsDropDownItem>();

                    list.Add(new TsDropDownItem { ComboId = "1", ComboName = "Nuevo" });
                    list.Add(new TsDropDownItem { ComboId = "2", ComboName = "Recapado" });
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public int GetNumberDepthByModel(int assetUniqueIdentificationId)
        {
            using (var context = new Entity())
            {
                int numberDepth = (from s in context.SettingTyre
                                   join a in context.AssetUniqueIdentification on s.SettingTyreId equals a.SettingTyreId
                                   where a.AssetUniqueIdentificationId == assetUniqueIdentificationId
                                   select s.DepthNumber).FirstOrDefault();

                return numberDepth;
            }
        }

        public List<ListItem> GetMeasurementTyreList()
        {
            using (var context = new Entity())
            {
                List<ListItem> list = (from m in context.MeasurementsTyre
                                       select new ListItem
                                       {
                                           Value = m.MeasurementsTyreId.ToString(),
                                           Text = m.MeasurementsTyreName
                                       }).ToList();
                return list;
            }
        }

        public List<ListItem> GetSpeedIndexList()
        {
            using (var context = new Entity())
            {
                List<ListItem> list = (from m in context.SpeedIndex
                                       select new ListItem
                                       {
                                           Value = m.SpeedIndexId.ToString(),
                                           Text = m.SpeedIndexName+" - "+m.EquivalentSpeed
                                       }).ToList();
                return list;
            }
        }

        public List<ListItem> GetWeighIndexList()
        {
            using (var context = new Entity())
            {
                List<ListItem> list = (from m in context.IndexWegh
                                       select new ListItem
                                       {
                                           Value = m.IndexWeghId.ToString(),
                                           Text = m.IndexWeghName + " - " + m.KgWegh
                                       }).ToList();
                return list;
            }
        }

        public SpeedIndex GetSpeedById(int speedIndexId)
        {
            using (var context = new Entity())
            {
                SpeedIndex speed = (from s in context.SpeedIndex
                                    where s.SpeedIndexId == speedIndexId
                                    select s).FirstOrDefault();
                return speed;
            }
        }

        public IndexWegh GetWeighById(int indexWeghId)
        {
            using (var context = new Entity())
            {
                IndexWegh speed = (from w in context.IndexWegh
                                    where w.IndexWeghId == indexWeghId
                                   select w).FirstOrDefault();
                return speed;
            }
        }

        public SettingTyre GetSettingTyreByAssetModelId(int assetUniqueIdentificationId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    SettingTyre obj = (from stt in context.SettingTyre
                                       join a in context.AssetUniqueIdentification 
                                       on stt.SettingTyreId equals a.SettingTyreId
                                       where a.AssetUniqueIdentificationId == assetUniqueIdentificationId
                                       select stt).FirstOrDefault();
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