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
    public partial class DcBranchOffice
    {
        public void Copy(BranchOffice objSource, ref BranchOffice objDestination)
        {
            objDestination.BranchOfficeId = objSource.BranchOfficeId;
            objDestination.BranchOfficeName = objSource.BranchOfficeName;
            objDestination.LocationId = objSource.LocationId;
            
        }

        public BranchOffice Save(BranchOffice objSource,int LocationId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();
                        BranchOffice row = context.BranchOffice.Where(r => r.BranchOfficeId == objSource.BranchOfficeId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new BranchOffice();
                            objSource.LocationId = LocationId;
                            Copy(objSource, ref row);
                            context.BranchOffice.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            objSource.LocationId = LocationId;
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;
                            
                        }
                        context.SaveChanges();
                        if (action == CommonEnums.PageActionEnum.Create)
                        {
                            Warehouse newWarehouse = new Warehouse();
                            newWarehouse.BranchOfficeId = row.BranchOfficeId;
                            newWarehouse.WarehouseName = "Bodega de Reparación " + row.BranchOfficeName;
                            context.Warehouse.Add(newWarehouse);
                            context.SaveChanges();
                            Warehouse newWarehouse2 = new Warehouse();
                            newWarehouse2.BranchOfficeId = row.BranchOfficeId;
                            newWarehouse2.WarehouseName = "Bodega de Scrap " + row.BranchOfficeName;
                            context.Warehouse.Add(newWarehouse2);
                            context.SaveChanges();

                        }
                        string description = string.Format("Nombre oficina: {0}, Id: {1}", row.BranchOfficeName, row.BranchOfficeId);
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

        public bool ExistsBranchOffice(int BranchOfficeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                BranchOffice obj = null;
                using (var context = new Entity())
                {
                    obj = context.BranchOffice.Where(r => r.BranchOfficeId == BranchOfficeId).FirstOrDefault();
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

        public List<BranchOffice> GetBranchOfficeList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<BranchOffice> list = context.BranchOffice.OrderBy(r => r.BranchOfficeName).ToList();
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
                        (from obj in context.BranchOffice
                         select new TsDropDownItem()
                         {
                             ComboId = obj.BranchOfficeId.ToString(),
                             ComboName = obj.BranchOfficeName
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
                        (from branchOffice in context.BranchOffice
                         join localization in context.Location on branchOffice.LocationId equals localization.LocationId
                         join commune in context.Commune on localization.CommuneId equals commune.CommuneId
                         join region in context.Region on commune.RegionId equals region.RegionId
                         select new
                         {
                            BranchOfficeId = branchOffice.BranchOfficeId,
                            BranchOfficeName = branchOffice.BranchOfficeName,
                            LocationId = branchOffice.LocationId,
                            LocationName = branchOffice.Location.LocationName,
                            CommuneId = branchOffice.Location.CommuneId,
                            CommuneName = branchOffice.Location.Commune.CommuneName,
                            RegionId = branchOffice.Location.Commune.RegionId,
                            RegionName = branchOffice.Location.Commune.Region.RegionName


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

        public int GetNewBranchOfficeId()
        {
            using (var context = new Entity())
            {
                int maxId = 0;
                int numBranchOffices = context.BranchOffice.Count();
                if (numBranchOffices == 0)
                {
                    maxId = 1;
                }
                else
                {
                    maxId = context.BranchOffice.Max(r => r.BranchOfficeId);
                }
                return maxId + 1;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteBranchOffice(int IBranchOfficeId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    BranchOffice obj = context.BranchOffice.Where(r => r.BranchOfficeId == IBranchOfficeId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.BranchOffice.Remove(obj);
                    context.SaveChanges();

                    string description = string.Format("Nombre oficina: {0}, Id: {1}", obj.BranchOfficeName, obj.BranchOfficeId);
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

        public bool ValidateBranchOfficeName(string branchOfficeName)
        {
            using (var context = new Entity())
            {
                BranchOffice warehouse = context.BranchOffice.Where(r => r.BranchOfficeName.ToUpper() == branchOfficeName.ToUpper()).FirstOrDefault();
                if (warehouse == null)
                {
                    return true;
                }
            }
            return false;
        }

        public BranchOffice GetBranchOfficeById(int branchOfficeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    BranchOffice obj = (from branchOffice in context.BranchOffice where branchOffice.BranchOfficeId == branchOfficeId select branchOffice).FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<ListItem> GetBranchOfficeItemList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<ListItem> list =
                        (from obj in context.BranchOffice
                         select new ListItem()
                         {
                             Value = obj.BranchOfficeId.ToString(),
                             Text = obj.BranchOfficeName
                         }).ToList();

                    ListItem Default = new ListItem();
                    Default.Value = "0";
                    Default.Text = "Seleccionar";
                    list.Insert(0, Default);

                    return list;
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