using amis._Common;
using amis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace amis._DataLayer.GeneratedCode
{
    public class DcMemberType
    {

        public void Copy(MemberType objSource, ref MemberType objDestination)
        {
            objDestination.MemberTypeId = objSource.MemberTypeId;
            objDestination.MemberTypeName = objSource.MemberTypeName;
        }

        public MemberType Save(MemberType objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    MemberType row = context.MemberType.Where(r => r.MemberTypeId == objSource.MemberTypeId).FirstOrDefault();

                    using (TransactionScope transaction = new TransactionScope())
                    {
                        if (row == null)
                        {
                            row = new MemberType();
                            Copy(objSource, ref row);
                            context.MemberType.Add(row);
                        }
                        else
                        {
                            Copy(objSource, ref row);
                        }

                        context.SaveChanges();
                        transaction.Complete();
                    }
                    return row;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public bool ExistsMemberType(int MemberTypeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                MemberType obj = null;
                using (var context = new Entity())
                {
                    obj = context.MemberType.Where(r => r.MemberTypeId != MemberTypeId).FirstOrDefault();
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

        public List<MemberType> GetMemberTypeList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<MemberType> list = context.MemberType.OrderBy(r => r.MemberTypeName).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public int GetNewMemberTypeId()
        {
            using (var context = new Entity())
            {
                int maxId = 0;
                int numMember = context.MemberType.Count();
                if (numMember == 0)
                {
                    maxId = 1;
                }
                else
                {
                    maxId = context.MemberType.Max(r => r.MemberTypeId);
                }
                return maxId + 1;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteMemberType(int iMemberTypeId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    MemberType obj = context.MemberType.Where(r => r.MemberTypeId == iMemberTypeId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.MemberType.Remove(obj);
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

        public List<String> GetMemberType()
        {
            List<MemberType> list = new List<MemberType>();
            List<String> tipos = new List<String>();

            using (var context = new Entity())
            {
                list = context.MemberType.OrderBy(r => r.MemberTypeName).ToList();
            }

            foreach (MemberType p in list)
            {
                tipos.Add(p.MemberTypeName);
            }
            return tipos;
        }

        public int GetIdMemberType(String memberTypeName)
        {
            int Id = 0;
            using (var context = new Entity())
            {
                MemberType obj = context.MemberType.Where(r => r.MemberTypeName == memberTypeName).FirstOrDefault();
                if (obj == null)
                {

                }
                else
                { Id = obj.MemberTypeId; }
            }
            return Id;
        }

        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.MemberType
                         select new TsDropDownItem()
                         {
                             ComboId = obj.MemberTypeId.ToString(),
                             ComboName = obj.MemberTypeName
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

        public String GetMemberTypeName(int memberTypeId)
        {
            using (var context = new Entity())
            {
                String tipoBuscado = "";
                MemberType obj = context.MemberType.Where(r => r.MemberTypeId == memberTypeId).FirstOrDefault();
                if (obj != null)
                {
                    tipoBuscado = obj.MemberTypeName;
                }
                return tipoBuscado;
            }
        }

        public bool FindMemberByMemberTypeId(int memberTypeId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Member obj = null;
                using (var context = new Entity())
                {
                    obj = context.Member.Where(r => r.MemberTypeId == memberTypeId).FirstOrDefault();
                    if (obj == null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }
    }
}