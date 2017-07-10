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
    public partial class DcDispatchProviderDocument
    {
        public void Copy(DispatchProviderDocument objSource, ref DispatchProviderDocument objDestination)
        {
            objDestination.DispatchProviderDocumentId = objSource.DispatchProviderDocumentId;
            objDestination.DispatchProviderDocumentStateId = objSource.DispatchProviderDocumentStateId;
            objDestination.FacilityId = objSource.FacilityId;
            objDestination.DispatchDate = objSource.DispatchDate;
            objDestination.DocumentNumber = objSource.DocumentNumber;
            objDestination.ProviderMemberId = objSource.ProviderMemberId;
        }

        public DispatchProviderDocument Save(DispatchProviderDocument objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        DispatchProviderDocument row = context.DispatchProviderDocument.Where(r => r.DispatchProviderDocumentId == objSource.DispatchProviderDocumentId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new DispatchProviderDocument();
                            Copy(objSource, ref row);
                            context.DispatchProviderDocument.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha añadido la guia de proveedor n°"+row.DocumentNumber +" con el id:" + row.DispatchProviderDocumentId;
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

        public bool ExistsDispatchProviderDocument(int DispatchProviderDocumentId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                DispatchProviderDocument obj = null;
                using (var context = new Entity())
                {
                    obj = context.DispatchProviderDocument.Where(r => r.DispatchProviderDocumentId == DispatchProviderDocumentId).FirstOrDefault();
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

        public List<DispatchProviderDocument> GetDispatchProviderDocumentList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<DispatchProviderDocument> list = context.DispatchProviderDocument.OrderBy(a => a.DocumentNumber).ToList();
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
                    var list =
                        (from obj in context.DispatchProviderDocument
                         select new {
                             comboId = obj.DocumentNumber.ToString()
                         }).Distinct().ToList();
                    List <TsDropDownItem> strs = new List<TsDropDownItem>();
                    foreach (var item in list)
                    {
                        TsDropDownItem ts = new TsDropDownItem();
                        ts.ComboId = item.comboId.ToString();
                        ts.ComboName = item.comboId.ToString();
                        strs.Add(ts);
                    }
                    return strs;
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
                        (from DispatchProviderDocument in context.DispatchProviderDocument
                         join state in context.DispatchProviderDocumentState on DispatchProviderDocument.DispatchProviderDocumentStateId equals state.DispatchProviderDocumentStateId
                         join facility in context.Facility on DispatchProviderDocument.FacilityId equals facility.FacilityId
                         join warehouse in context.Warehouse on facility.WarehouseId equals warehouse.WarehouseId
                         join member in context.Member on DispatchProviderDocument.ProviderMemberId equals member.MemberId
                         join type in context.MemberType on member.MemberTypeId equals type.MemberTypeId
                         select new
                         {
                             DispatchProviderDocumentId = DispatchProviderDocument.DispatchProviderDocumentId,
                             DocumentNumber = DispatchProviderDocument.DocumentNumber,
                             DispatchProviderDocumentStateId = DispatchProviderDocument.DispatchProviderDocumentStateId,
                             DispatchProviderDocumentStateName = DispatchProviderDocument.DispatchProviderDocumentState.DispatchProviderDocumentStateName,
                             FacilityId = DispatchProviderDocument.FacilityId,
                             MemberId = DispatchProviderDocument.ProviderMemberId,
                             MemberName = DispatchProviderDocument.Member.MemberName,
                             WarehouseId = DispatchProviderDocument.Facility.WarehouseId,
                             WarehouseName = DispatchProviderDocument.Facility.Warehouse.WarehouseName

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

        public CommonEnums.DeletedRecordStates DeleteDispatchProviderDocument(int IDispatchProviderDocumentId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    DispatchProviderDocument obj = context.DispatchProviderDocument.Where(r => r.DispatchProviderDocumentId == IDispatchProviderDocumentId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.DispatchProviderDocument.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la guia n°"+obj.DocumentNumber+" con el id:" + obj.DispatchProviderDocumentId;
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

        public bool ValidateNumberProvider(int number, int idProvider)
        {
            using (Entity context = new Entity())
            {
                DispatchProviderDocument obj = context.DispatchProviderDocument.Where(r => r.DocumentNumber == number && r.ProviderMemberId == idProvider).FirstOrDefault();
                if (obj==null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public IEnumerable<object> GetTableListByFilter(int number,int id, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    if (number!=0  && id !=0)
                    {
                        IEnumerable<object> list =
                        (from DispatchProviderDocument in context.DispatchProviderDocument.Where(r => r.DocumentNumber == number && r.ProviderMemberId == id)
                         join state in context.DispatchProviderDocumentState on DispatchProviderDocument.DispatchProviderDocumentStateId equals state.DispatchProviderDocumentStateId
                         join facility in context.Facility on DispatchProviderDocument.FacilityId equals facility.FacilityId
                         join warehouse in context.Warehouse on facility.WarehouseId equals warehouse.WarehouseId
                         join member in context.Member on DispatchProviderDocument.ProviderMemberId equals member.MemberId
                         join type in context.MemberType on member.MemberTypeId equals type.MemberTypeId
                         select new
                         {
                             DispatchProviderDocumentId = DispatchProviderDocument.DispatchProviderDocumentId,
                             DocumentNumber = DispatchProviderDocument.DocumentNumber,
                             DispatchProviderDocumentStateId = DispatchProviderDocument.DispatchProviderDocumentStateId,
                             DispatchProviderDocumentStateName = DispatchProviderDocument.DispatchProviderDocumentState.DispatchProviderDocumentStateName,
                             FacilityId = DispatchProviderDocument.FacilityId,
                             MemberId = DispatchProviderDocument.ProviderMemberId,
                             MemberTypeId = DispatchProviderDocument.Member.MemberTypeId,
                             MemberName = DispatchProviderDocument.Member.MemberName,
                             WarehouseId = DispatchProviderDocument.Facility.WarehouseId,
                             WarehouseName = DispatchProviderDocument.Facility.Warehouse.WarehouseName

                         }).ToList();
                        return list;
                    }

                    if (number != 0 && id == 0)
                    {
                        IEnumerable<object> list =
                        (from DispatchProviderDocument in context.DispatchProviderDocument.Where(r => r.DocumentNumber == number)
                         join state in context.DispatchProviderDocumentState on DispatchProviderDocument.DispatchProviderDocumentStateId equals state.DispatchProviderDocumentStateId
                         join facility in context.Facility on DispatchProviderDocument.FacilityId equals facility.FacilityId
                         join warehouse in context.Warehouse on facility.WarehouseId equals warehouse.WarehouseId
                         join member in context.Member on DispatchProviderDocument.ProviderMemberId equals member.MemberId
                         join type in context.MemberType on member.MemberTypeId equals type.MemberTypeId
                         select new
                         {
                             DispatchProviderDocumentId = DispatchProviderDocument.DispatchProviderDocumentId,
                             DocumentNumber = DispatchProviderDocument.DocumentNumber,
                             DispatchProviderDocumentStateId = DispatchProviderDocument.DispatchProviderDocumentStateId,
                             DispatchProviderDocumentStateName = DispatchProviderDocument.DispatchProviderDocumentState.DispatchProviderDocumentStateName,
                             FacilityId = DispatchProviderDocument.FacilityId,
                             MemberId = DispatchProviderDocument.ProviderMemberId,
                             MemberTypeId = DispatchProviderDocument.Member.MemberTypeId,
                             MemberName = DispatchProviderDocument.Member.MemberName,
                             WarehouseId = DispatchProviderDocument.Facility.WarehouseId,
                             WarehouseName = DispatchProviderDocument.Facility.Warehouse.WarehouseName

                         }).ToList();
                        return list;
                    }

                    if (number == 0 && id != 0)
                    {
                        IEnumerable<object> list =
                        (from DispatchProviderDocument in context.DispatchProviderDocument.Where(r => r.ProviderMemberId == id)
                         join state in context.DispatchProviderDocumentState on DispatchProviderDocument.DispatchProviderDocumentStateId equals state.DispatchProviderDocumentStateId
                         join facility in context.Facility on DispatchProviderDocument.FacilityId equals facility.FacilityId
                         join warehouse in context.Warehouse on facility.WarehouseId equals warehouse.WarehouseId
                         join member in context.Member on DispatchProviderDocument.ProviderMemberId equals member.MemberId
                         join type in context.MemberType on member.MemberTypeId equals type.MemberTypeId
                         select new
                         {
                             DispatchProviderDocumentId = DispatchProviderDocument.DispatchProviderDocumentId,
                             DocumentNumber = DispatchProviderDocument.DocumentNumber,
                             DispatchProviderDocumentStateId = DispatchProviderDocument.DispatchProviderDocumentStateId,
                             DispatchProviderDocumentStateName = DispatchProviderDocument.DispatchProviderDocumentState.DispatchProviderDocumentStateName,
                             FacilityId = DispatchProviderDocument.FacilityId,
                             MemberId = DispatchProviderDocument.ProviderMemberId,
                             MemberTypeId = DispatchProviderDocument.Member.MemberTypeId,
                             MemberName = DispatchProviderDocument.Member.MemberName,
                             WarehouseId = DispatchProviderDocument.Facility.WarehouseId,
                             WarehouseName = DispatchProviderDocument.Facility.Warehouse.WarehouseName

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

        public List<TsDropDownItem> GetComboListByFilter(int id,out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.DispatchProviderDocument.Where(r=> r.ProviderMemberId==id)
                         select new TsDropDownItem()
                         {
                             ComboId = obj.DispatchProviderDocumentId.ToString(),
                             ComboName = obj.DocumentNumber.ToString()
                         }).Distinct().ToList();

                    List<TsDropDownItem> strs = new List<TsDropDownItem>();
                    int count = 0;
                    foreach (TsDropDownItem item in list)
                    {
                        if (strs.Count == 0)
                        {
                            strs.Add(item);
                        }
                        else
                        {
                            foreach (TsDropDownItem str in strs)
                            {
                                if (item.ComboName == str.ComboName)
                                {
                                    count++; ;
                                }
                            }

                            if (count == 0)
                            {
                                strs.Add(item);
                            }
                            count = 0;
                        }
                    }
                    return strs;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public bool ValidateStateDocument(int id, out string errorMessage)
        {
            errorMessage = "";

            using (var context = new Entity())
            {

                int valor =(from state in context.DispatchProviderDocument where state.DispatchProviderDocumentId == id select state.DispatchProviderDocumentStateId).FirstOrDefault();

                if (valor==1)
                {
                    return false;
                }
                return true;
            }
        }

        public bool HasMember(int idMember)
        {
            using (var context = new Entity())
            {
                DispatchProviderDocument document = 
                    (from doc in context.DispatchProviderDocument
                                                         where doc.ProviderMemberId == idMember
                                                         select doc).FirstOrDefault();
                if (document==null)
                {
                    return true;
                }

                return false;
            }
        }

        public List<ListItem> GetDispatchProviderDocimentNumber(int providerId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<ListItem> list =
                        (from obj in context.DispatchProviderDocument.Where(r => r.ProviderMemberId == providerId)
                         select new ListItem()
                         {
                             Value = obj.DispatchProviderDocumentId.ToString(),
                             Text = obj.DocumentNumber.ToString()
                         }).Distinct().ToList();

                    List<ListItem> strs = new List<ListItem>();
                    int count = 0;
                    foreach (ListItem item in list)
                    {
                        if (strs.Count == 0)
                        {
                            strs.Add(item);
                        }
                        else
                        {
                            foreach (ListItem str in strs)
                            {
                                if (item.Value == str.Value)
                                {
                                    count++; ;
                                }
                            }

                            if (count == 0)
                            {
                                strs.Add(item);
                            }
                            count = 0;
                        }
                    }
                    ListItem Default = new ListItem();
                    Default.Value = "0";
                    Default.Text = "Seleccione";
                    strs.Insert(0, Default);
                    return strs;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public DispatchProviderDocument GetDocumentById(int id)
        {
            using (var context = new Entity())
            {
                DispatchProviderDocument obj = (from d in context.DispatchProviderDocument where d.DispatchProviderDocumentId == id select d).First();
                return obj;
            }
        }
    }
}