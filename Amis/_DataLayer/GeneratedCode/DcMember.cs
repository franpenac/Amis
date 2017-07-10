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
    public partial class DcMember
    {
        public void Copy(Member objSource, ref Member objDestination)
        {
            objDestination.MemberId = objSource.MemberId;
            objDestination.MemberName = objSource.MemberName;
            objDestination.MemberRut = objSource.MemberRut;
            objDestination.MemberEmail = objSource.MemberEmail;
            objDestination.MemberTypeId = objSource.MemberTypeId;
        }

        public Member Save(Member objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();
                        Member row = context.Member.Where(r => r.MemberId == objSource.MemberId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new Member();
                            Copy(objSource, ref row);
                            context.Member.Add(row);
                            action = CommonEnums.PageActionEnum.Create;
                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;
                        }
                        context.SaveChanges();
                        string description = string.Format("Nombre miembro: {0}, Id: {1}", row.MemberName, row.MemberId);
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

        public bool ExistsMember(int MemberId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Member obj = null;
                using (var context = new Entity())
                {
                    obj = context.Member.Where(r => r.MemberId != MemberId).FirstOrDefault();
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

        public List<Member> GetMemberList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Member> list = context.Member.OrderBy(r => r.MemberName).ToList();
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
                        (from obj in context.Member
                         select new TsDropDownItem()
                         {
                             ComboId = obj.MemberId.ToString(),
                             ComboName = obj.MemberName
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
                        (from member in context.Member
                         join memberType in context.MemberType on member.MemberTypeId equals memberType.MemberTypeId
                         select new
                         {
                             MemberId = member.MemberId,
                             MemberName = member.MemberName,
                             MemberRut = member.MemberRut,
                             MemberEmail = member.MemberEmail,
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

        public int GetNewMemberId()
        {
            using (var context = new Entity())
            {
                int maxId = 0;
                int numMembers = context.Member.Count();
                if (numMembers == 0)
                {
                    maxId = 1;
                }
                else
                {
                    maxId = context.Member.Max(r => r.MemberId);
                }
                return maxId + 1;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteMember(int IMemberId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Member obj = context.Member.Where(r => r.MemberId == IMemberId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Member.Remove(obj);
                    context.SaveChanges();
                    string description = string.Format("Nombre miembro: {0}, Id: {1}", obj.MemberName, obj.MemberId);
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

        public String GetMemberName(int memberId)
        {
            using (var context = new Entity())
            {
                String marcaBuscada = "";
                Member obj = context.Member.Where(r => r.MemberId == memberId).FirstOrDefault();
                if (obj != null)
                {
                    marcaBuscada = obj.MemberName;
                }
                return marcaBuscada;
            }
        }

        public List<TsDropDownItem> GetComboListByTipeId(int tipeId,out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.Member where obj.MemberTypeId == tipeId
                         select new TsDropDownItem()
                         {
                             ComboId = obj.MemberId.ToString(),
                             ComboName = obj.MemberName
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

        public bool ValidateExistRut(string rut)
        {
            using (var context = new Entity())
            {
                Member member = (from m in context.Member where m.MemberRut == rut select m).FirstOrDefault();

                if (member == null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool ValidateExistMail(string mail)
        {
            using (var context = new Entity())
            {
                Member member = (from m in context.Member where m.MemberEmail == mail select m).FirstOrDefault();

                if (member == null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool ValidateExistName(string nane)
        {
            using (var context = new Entity())
            {
                Member member = (from m in context.Member where m.MemberName == nane select m).FirstOrDefault();

                if (member == null)
                {
                    return false;
                }
                return true;
            }
        }

        public Member GetMemberById(int memberId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    Member obj = context.Member.Where(r => r.MemberId == memberId).FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<ListItem> GetProviderList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<ListItem> list =
                        (from obj in context.Member
                         where obj.MemberTypeId == 1
                         select new ListItem()
                         {
                             Value = obj.MemberId.ToString(),
                             Text = obj.MemberName
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

        public Member SearchMemberBranchOfficeById(int memberId)
        {
            using (var context = new Entity())
            {
                Member member = (from m in context.Member
                                 join mb in context.MemberBranchOffice on m.MemberId equals mb.MemberId
                                 where mb.MemberId != 0
                                 select m).FirstOrDefault();

                return member;
            }
        }

        public List<ListItem> GetClientBranchOfficeList(int branchOfficeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<ListItem> list =
                        (from obj in context.Member
                         join mb in context.MemberBranchOffice on obj.MemberId equals mb.MemberId
                         where obj.MemberTypeId == 3 && mb.BranchOfficeId != 0
                         select new ListItem()
                         {
                             Value = obj.MemberId.ToString(),
                             Text = obj.MemberName
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