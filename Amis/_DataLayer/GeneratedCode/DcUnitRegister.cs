using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;
using System.Collections;

namespace amis._DataLayer.GeneratedCode
{
    public partial class DcUnitRegister
    {
        public void Copy(UnitRegister objSource, ref UnitRegister objDestination)
        {
            objDestination.UnitRegisterId = objSource.UnitRegisterId;
            objDestination.UnitTypeId = objSource.UnitTypeId;
            objDestination.UnitTypeConfigurationId = objSource.UnitTypeConfigurationId;
            objDestination.PatentNumber = objSource.PatentNumber;
            objDestination.UnitName = objSource.UnitName;
            objDestination.InternalNumber = objSource.InternalNumber;
            objDestination.SuspensionTypeId = objSource.SuspensionTypeId;
            objDestination.KilometersOfTravel = objSource.KilometersOfTravel;
            objDestination.UnitTara = objSource.UnitTara;
            objDestination.Vin = objSource.Vin;
            objDestination.NewOrUsed = objSource.NewOrUsed;
            objDestination.UnitManufacturingYear = objSource.UnitManufacturingYear;
            objDestination.UnitPurchaseDate = objSource.UnitPurchaseDate;
            objDestination.UnitOwnerMemberId = objSource.UnitOwnerMemberId;
            objDestination.NextDrivingLicenseDate = objSource.NextDrivingLicenseDate;
            objDestination.NextQualificationDate = objSource.NextQualificationDate;
            objDestination.NextTechnicalReviewDate = objSource.NextTechnicalReviewDate;
        }

        public UnitRegister Save(UnitRegister objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();
                        UnitRegister row = context.UnitRegister.Where(r => r.UnitRegisterId == objSource.UnitRegisterId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new UnitRegister();
                            Copy(objSource, ref row);
                            context.UnitRegister.Add(row);
                            action = CommonEnums.PageActionEnum.Create;
                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;
                        }
                        context.SaveChanges();
                        //string description = string.Format("Registro de unidad. Patente: {0}, Id: {1}, Tipo de unidad: {2}", row.PatentNumber, row.UnitRegisterId, row.UnitTypeId);
                        //new DcPageLog().Save(action, description);
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

        public bool ExistsUnitRegister(int unitRegisterId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                UnitRegister obj = null;
                using (var context = new Entity())
                {
                    obj = context.UnitRegister.Where(r => r.UnitRegisterId != unitRegisterId).FirstOrDefault();
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

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    IEnumerable<object> list = (
                        from ureg in context.UnitRegister
                        join utype in context.UnitType on ureg.UnitTypeId equals utype.UnitTypeId
                        join conf in context.ConfigurationUnitType on ureg.UnitTypeConfigurationId equals conf.ConfigurationUnitTypeId
                        select new
                        {
                            UnitRegisterId = ureg.UnitRegisterId,
                            UnitTypeId = utype.UnitTypeId,
                            UnitTypeName = utype.UnitTypeName,
                            ConfigurationUnitTypeId = conf.ConfigurationUnitTypeId,
                            ConfigurationUnitTypeName = conf.ConfigurationUnitTypeName,
                            PatentNumber = ureg.PatentNumber,
                            InternalNumber = ureg.InternalNumber,
                            RevTec = ureg.NextTechnicalReviewDate.ToString().Substring(3,3)+ ureg.NextTechnicalReviewDate.ToString().Substring(0, 2)+ ureg.NextTechnicalReviewDate.ToString().Substring(6, 4),
                            HabDate = ureg.NextTechnicalReviewDate.ToString().Substring(3, 3) + ureg.NextTechnicalReviewDate.ToString().Substring(0, 2) + ureg.NextTechnicalReviewDate.ToString().Substring(6, 4)
                        }
                    ).OrderBy(r => r.UnitTypeId).ThenBy(r => r.ConfigurationUnitTypeName).ThenBy(r => r.PatentNumber).ToList();
                    
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<UnitRegisterTableRow> GetUnitRegisterTable(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<UnitRegisterTableRow> list = (
                        from ureg in context.UnitRegister
                        join utype in context.UnitType on ureg.UnitTypeId equals utype.UnitTypeId
                        join conf in context.ConfigurationUnitType on ureg.UnitTypeConfigurationId equals conf.ConfigurationUnitTypeId
                        select new UnitRegisterTableRow()
                        {
                            UnitRegisterId = ureg.UnitRegisterId,
                            UnitTypeId = utype.UnitTypeId,
                            UnitTypeName = utype.UnitTypeName,
                            ConfigurationUnitTypeId = conf.ConfigurationUnitTypeId,
                            ConfigurationUnitTypeName = conf.ConfigurationUnitTypeName,
                            PatentNumber = ureg.PatentNumber,
                            InternalNumber = ureg.InternalNumber,
                            RevTec = ureg.NextTechnicalReviewDate,
                            HabDate = ureg.NextQualificationDate
                        }
                    ).OrderBy(r => r.UnitTypeId).ThenBy(r => r.ConfigurationUnitTypeName).ThenBy(r => r.PatentNumber).ToList();

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
                        (from obj in context.UnitRegister
                         select new TsDropDownItem()
                         {
                             ComboId = obj.UnitRegisterId.ToString(),
                             ComboName = obj.PatentNumber
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

        public CommonEnums.DeletedRecordStates DeleteUnitRegister(int unitRegisterId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    UnitRegister obj = context.UnitRegister.Where(r => r.UnitRegisterId == unitRegisterId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.UnitRegister.Remove(obj);
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

        public bool HasUnit(int unitRegisterId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    Unit unit = context.Unit.Where(r => r.UnitRegisterId == unitRegisterId).FirstOrDefault();
                    if (unit == null)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }

        public UnitRegister GetUnitRegisterById(int unitRegisterId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    UnitRegister obj = context.UnitRegister.Where(r => r.UnitRegisterId == unitRegisterId).FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public UnitRegister GetUnitRegisterByPatentNumber(string patentNumber, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    UnitRegister obj = context.UnitRegister.Where(r => r.PatentNumber == patentNumber).FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from conf in context.ConfigurationUnitType
                         where conf.UnitTypeId == id
                         select new TsDropDownItem()
                         {
                             ComboId = conf.ConfigurationUnitTypeId.ToString(),
                             ComboName = conf.ConfigurationUnitTypeName.ToString()
                         }).Distinct().OrderBy(r => r.ComboName).ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public bool ValidateRepeatedPatentNumber(string patentNumber, int currenUnitRegisterId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    UnitRegister unit = context.UnitRegister.Where(r => r.UnitRegisterId != currenUnitRegisterId && r.PatentNumber.ToUpper() == patentNumber.ToUpper()).FirstOrDefault();
                    if (unit == null) return true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }

        public UnitRegister GetUnitRegisterByPatentNumberOrInternalNumber(string patentNumber, string internalNumber, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    UnitRegister obj = (from ur in context.UnitRegister where ur.PatentNumber == patentNumber || ur.InternalNumber == internalNumber select ur).FirstOrDefault();
                    if (obj != null)
                    {
                        errorMessage = "";
                        return obj;
                    }
                    else
                        errorMessage = "";
                        return null;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetInternalNumberList()
        {
            using (var context = new Entity())
            {
                List<Infragistics.Web.UI.ListControls.DropDownItem> list = (from u in context.UnitRegister
                                                                            select new Infragistics.Web.UI.ListControls.DropDownItem()
                                                                            {
                                                                                Value = u.UnitRegisterId.ToString(),
                                                                                Text = u.InternalNumber
                                                                            }
                                                                            ).Distinct().ToList();
                return list;

            }
        }
    }
}