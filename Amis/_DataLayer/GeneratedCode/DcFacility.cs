using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using amis._Common;
using amis.Models;
using System.Transactions;

namespace amis._DataLayer.GeneratedCode
{
    public class DcFacility
    {
        public void Copy(Facility objSource, ref Facility objDestination)
        {
            objDestination.FacilityId = objSource.FacilityId;
            objDestination.FacilityTypeId = objSource.FacilityTypeId;
            objDestination.WarehouseId = objSource.WarehouseId;
            objDestination.UnitId = objSource.UnitId;
        }

        public Facility Save(Facility objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        Facility facility = context.Facility.Where(r => r.FacilityId == objSource.FacilityId).FirstOrDefault();
                        if (facility != null) return (Facility)ErrorController.SetErrorMessage("Repeated Facility Id", out errorMessage);

                        Facility row = context.Facility.Where(r => r.FacilityId == objSource.FacilityId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Facility();
                            Copy(objSource, ref row);
                            context.Facility.Add(row);
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

        public bool ExistsFacility(int FacilityId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Facility obj = null;
                using (var context = new Entity())
                {
                    obj = context.Facility.Where(r => r.FacilityId != FacilityId).FirstOrDefault();
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

        public List<Facility> GetFacilityList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Facility> list = context.Facility.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<TsDropDownItem> GetComboList(int facilityTypeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    if (facilityTypeId == 1) //Warehouse
                    {
                        List<TsDropDownItem> list =
                        (from warehouse in context.Warehouse
                         select new TsDropDownItem
                         {
                             ComboId = warehouse.WarehouseId.ToString(),
                             ComboName = warehouse.WarehouseName
                         }).ToList();
                        return list;
                    }
                    else if (facilityTypeId == 2) //Unit
                    {
                        List<TsDropDownItem> list =
                        (from ftype in context.FacilityType
                         join facility in context.Facility on ftype.FacilityTypeId equals facility.FacilityTypeId
                         join unit in context.Unit on facility.UnitId equals unit.UnitId
                         join reg in context.UnitRegister on  unit.UnitRegisterId equals reg.UnitRegisterId
                         select new TsDropDownItem
                         {
                             ComboId = facility.FacilityId.ToString(),
                             ComboName = unit.UnitRegister.PatentNumber
                         }).ToList();
                        return list;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteFacility(int IFacilityId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Facility obj = context.Facility.Where(r => r.FacilityId == IFacilityId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Facility.Remove(obj);
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

        public int GetFacilityByWarehouse(int warehouseId)
        {
            Facility obj = null;
            using (var context = new Entity())
            {
                obj = context.Facility.Where(r => r.WarehouseId == warehouseId).FirstOrDefault();
                if (obj == null)
                {
                    return 0;
                }
                return obj.FacilityId;
            }
        }

        public bool HasWarehouse(int WareHouseId, ref Facility first)
        {
            using (var context = new Entity())
            {
                first = context.Facility.Where(r => r.WarehouseId == WareHouseId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool HasUnit(int UnitId, ref Facility first)
        {
            using (var context = new Entity())
            {
                first = context.Facility.Where(r => r.UnitId == UnitId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }

        public Facility GetFacilityByIdAndTypeId(int facilityId, int facilityTypeId)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    Facility obj = (from facility in context.Facility where facility.FacilityId == facilityId && facility.FacilityTypeId == facilityTypeId select facility).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj;
                    }else
                    {
                        return null;
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
