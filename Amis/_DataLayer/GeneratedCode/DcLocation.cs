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
    public partial class DcLocation
    {
        public void Copy(Location objSource, ref Location objDestination)
        {
            objDestination.LocationId = objSource.LocationId;
            if (objSource.LocationName=="")
            {

                objDestination.LocationName = "Sin Asignar";
            }
            else
            {
                objDestination.LocationName = objSource.LocationName;
            }
            objDestination.CommuneId = objSource.CommuneId;

        }

        public Location Save(Location objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        Location row = context.Location.Where(r => r.LocationId == objSource.LocationId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Location();
                            Copy(objSource, ref row);
                            context.Location.Add(row);
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

        public bool ExistsLocation(int LocationId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Location obj = null;
                using (var context = new Entity())
                {
                    obj = context.Location.Where(r => r.LocationId != LocationId).FirstOrDefault();
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

        public List<Location> GetLocationList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Location> list = context.Location.OrderBy(a => a.LocationName).ToList();
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
                        (from obj in context.Location
                         select new TsDropDownItem()
                         {
                             ComboId = obj.LocationId.ToString(),
                             ComboName = obj.LocationName
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
                        (from Location in context.Location
                         select new
                         {
                             LocationId = Location.LocationId,
                             LocationName = Location.LocationName,
                             CommuneId = Location.CommuneId,
                             CommuneName = Location.Commune.CommuneName

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

        public CommonEnums.DeletedRecordStates DeleteLocation(int ILocationId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Location obj = context.Location.Where(r => r.LocationId == ILocationId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Location.Remove(obj);
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