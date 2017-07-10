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
    public partial class DcMemberBranchOffice
    {
        public void Copy(MemberBranchOffice objSource, ref MemberBranchOffice objDestination)
        {
            objDestination.MemberBranchOfficeId = objSource.MemberBranchOfficeId;
            objDestination.MemberId = objSource.MemberId;
            objDestination.BranchOfficeId = objSource.BranchOfficeId;

        }

        public MemberBranchOffice Save(MemberBranchOffice objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        MemberBranchOffice row = context.MemberBranchOffice.Where(r => r.MemberBranchOfficeId == objSource.MemberBranchOfficeId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new MemberBranchOffice();
                            Copy(objSource, ref row);
                            context.MemberBranchOffice.Add(row);
                            action = CommonEnums.PageActionEnum.Create;
                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;
                        }
                        context.SaveChanges();
                        string description = "Se ha asignado el miembro de id: "+row.MemberId+" a la sucursal de id: "+row.BranchOfficeId;
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

        public bool ExistsMemberBranchOffice(int MemberBranchOfficeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                MemberBranchOffice obj = null;
                using (var context = new Entity())
                {
                    obj = context.MemberBranchOffice.Where(r => r.MemberBranchOfficeId != MemberBranchOfficeId).FirstOrDefault();
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

        public List<MemberBranchOffice> GetMemberBranchOfficeList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<MemberBranchOffice> list = context.MemberBranchOffice.ToList();
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
                        (from obj in context.MemberBranchOffice
                         select new TsDropDownItem()
                         {
                             ComboId = obj.MemberBranchOfficeId.ToString(),
                             //ComboName = obj.MemberBranchOfficeName
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
                        (from memberBranchOffice in context.MemberBranchOffice
                         join branchOffice in context.BranchOffice on memberBranchOffice.BranchOfficeId equals branchOffice.BranchOfficeId
                         join member in context.Member on memberBranchOffice.MemberId equals member.MemberId
                         join memberType in context.MemberType on member.MemberTypeId equals memberType.MemberTypeId
                         select new
                         {
                             MemberBranchOfficeId = memberBranchOffice.MemberBranchOfficeId,
                             MemberId = member.MemberId,
                             MemberName = member.MemberName,
                             BranchOfficeId = branchOffice.BranchOfficeId,
                             BranchOfficeName = branchOffice.BranchOfficeName,
                             MemberTypeId = memberType.MemberTypeId,
                             MemberTypeName = memberType.MemberTypeName

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

        public CommonEnums.DeletedRecordStates DeleteMemberBranchOffice(int IMemberBranchOfficeId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    MemberBranchOffice obj = context.MemberBranchOffice.Where(r => r.MemberBranchOfficeId == IMemberBranchOfficeId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.MemberBranchOffice.Remove(obj);
                    context.SaveChanges();
                    string description = "Se ha eliminado la asignacion con el id: "+obj.MemberBranchOfficeId;
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

        public bool HasBranchOffice(int BranchOfficeId, ref MemberBranchOffice first, out string name)
        {
            using (var context = new Entity())
            {
                first = (from o in context.MemberBranchOffice where o.BranchOfficeId == BranchOfficeId
                         join m in context.Member on o.BranchOfficeId equals m.MemberId select o).FirstOrDefault();
                if (first == null)
                {
                    name = "";
                    return true;
                }
                name = first.Member.MemberName;
                return false;
            }
        }

        public bool HasMember(int MemberId, ref MemberBranchOffice first)
        {
            using (var context = new Entity())
            {
                first = context.MemberBranchOffice.Where(r => r.MemberId == MemberId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool HasMemberBranch(int MemberId,int BranchOficeId, ref MemberBranchOffice first)
        {
            using (var context = new Entity())
            {
                first = context.MemberBranchOffice.Where(r => r.MemberId == MemberId && r.BranchOfficeId == BranchOficeId).FirstOrDefault();
                if (first == null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}