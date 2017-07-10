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
    public partial class DcWarehouse
    {
        public void Copy(Warehouse objSource, ref Warehouse objDestination)
        {
            objDestination.WarehouseId = objSource.WarehouseId;
            objDestination.WarehouseName = objSource.WarehouseName;
            objDestination.BranchOfficeId = objSource.BranchOfficeId;
        }

        public Warehouse Save(Warehouse objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        Warehouse row = context.Warehouse.Where(r => r.WarehouseId == objSource.WarehouseId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Warehouse();
                            Copy(objSource, ref row);
                            context.Warehouse.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha añadido la bodega: "+row.WarehouseName+", con el id:" + row.WarehouseId;
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

        public bool ExistsWarehouse(int WarehouseId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Warehouse obj = null;
                using (var context = new Entity())
                {
                    obj = context.Warehouse.Where(r => r.WarehouseId != WarehouseId).FirstOrDefault();
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

        public List<Warehouse> GetWarehouseList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Warehouse> list = context.Warehouse.OrderBy(a => a.WarehouseName).ToList();
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
                        (from obj in context.Warehouse
                         select new TsDropDownItem()
                         {
                             ComboId = obj.WarehouseId.ToString(),
                             ComboName = obj.WarehouseName
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
                        (from Warehouse in context.Warehouse
                         join branchOffice in context.BranchOffice on Warehouse.BranchOfficeId equals branchOffice.BranchOfficeId
                         select new
                         {
                             WarehouseId = Warehouse.WarehouseId,
                             WarehouseName = Warehouse.WarehouseName,
                             BranchOfficeId = Warehouse.BranchOfficeId,
                             BranchOfficeName = Warehouse.BranchOffice.BranchOfficeName

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

        public CommonEnums.DeletedRecordStates DeleteWarehouse(int IWarehouseId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Warehouse obj = context.Warehouse.Where(r => r.WarehouseId == IWarehouseId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Warehouse.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la bodega:"+obj.WarehouseName+", con el id:" + obj.WarehouseId;
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

        public bool ValidateWarehouseName(string warehouseName)
        {
            using (var context = new Entity())
            {
                Warehouse warehouse = context.Warehouse.Where(r => r.WarehouseName.ToUpper() == warehouseName.ToUpper()).FirstOrDefault();
                if (warehouse != null)
                {
                    return false;
                }
            }
            return true;
        }

        public bool HasBranchOffice(int BranchOfficeId, ref Warehouse first)
        {
            using (var context = new Entity())
            {
                first = context.Warehouse.Where(r => r.BranchOfficeId == BranchOfficeId).FirstOrDefault();
                if (first == null)
                {
                    return true;
                }
                return false;
            }
        }

        public List<TsDropDownItem> GetComboListByBranchOfficeId(int BranchOfficeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.Warehouse
                         where obj.BranchOfficeId == BranchOfficeId
                         select new TsDropDownItem()
                         {
                             ComboId = obj.WarehouseId.ToString(),
                             ComboName = obj.WarehouseName
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

        public List<Warehouse> GetWharehouseListByBranchOfficeId(int BranchOfficeId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    List<Warehouse> list = (from warehouse in context.Warehouse where warehouse.BranchOfficeId == BranchOfficeId select warehouse).ToList();
                    list = list.Where(r => r.WarehouseName.IndexOf("Bodega de Scrap") == -1).ToList();
                    list = list.Where(r => r.WarehouseName.IndexOf("Bodega de Reparación") == -1).ToList();
                    if (list.Count > 0 && list != null)
                    {
                        errorMessage = "";
                        return list;
                    }else
                    {
                        errorMessage = "";
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