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
    public partial class DcAmisUser
    {
        public void Copy(AmisUser objSource, ref AmisUser objDestination)
        {
            objDestination.AmisUserId = objSource.AmisUserId;
            objDestination.Email = objSource.Email;
            objDestination.Password = objSource.Password;
            objDestination.SecretQuestion = objSource.SecretQuestion;
            objDestination.SecretAnswer = objSource.SecretAnswer;
            objDestination.Enable = objSource.Enable;
            objDestination.Name = objSource.Name;
            objDestination.CreatedDate = objSource.CreatedDate;
            objDestination.ChangePasswordCode = objSource.ChangePasswordCode;
            objDestination.MemberId = objSource.MemberId;
        }

        public AmisUser Save(AmisUser objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        AmisUser row = context.AmisUser.Where(r => r.AmisUserId == objSource.AmisUserId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new AmisUser();
                            Copy(objSource, ref row);
                            context.AmisUser.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha añadido el usuario:" + row.Name + ", con el id:" + row.AmisUserId;
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

        public void EnabledUser(int userId, string enabled, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        AmisUser user = context.AmisUser.Where(a=>a.AmisUserId == userId).FirstOrDefault();
                        if (user!=null)
                        {
                            user.Enable = enabled;
                            if (enabled == "N")
                            {
                                user.DisabledDate = DateTime.Now;
                            }
                            else if (enabled == "Y")
                            {
                                user.DisabledDate = null;
                            }                   
                            context.SaveChanges();
                            transaction.Complete();
                        }       
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
            }
        }

        public AmisUser GetUserById(int Id, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    AmisUser nUser = context.AmisUser.Where(a => a.AmisUserId == Id).FirstOrDefault();
                    if (nUser == null)
                    {
                        return null;
                    }
                    return nUser;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }

        }

        public bool ValidateUserEmailExist(string userEmail, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    AmisUser user = context.AmisUser.Where(r => r.Email.ToUpper() == userEmail.ToUpper()).FirstOrDefault();
                    if (user != null)
                    {
                        return false;
                    }
                    return true;
                }
            }catch(Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return true;
            }

        }

        public AmisUser GetUserByEmail(string email, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    AmisUser nUser = context.AmisUser.Where(a => a.Email == email).FirstOrDefault();
                    if (nUser == null)
                    {
                        return nUser;
                    }
                    return nUser;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }

        }

        public void ChangeUserPasswordCode(string code, string email, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (TransactionScope transanction = new TransactionScope())
                {
                    using (var context = new Entity())
                    {
                        AmisUser user = context.AmisUser.Where(a => a.Email == email).FirstOrDefault();
                        user.ChangePasswordCode = code;
                        context.SaveChanges();
                        transanction.Complete();
                    }
                }
            }
            catch (Exception ex)
            {

                errorMessage = ErrorController.GetErrorMessage(ex);
            }
        }

        public AmisUser GetUserInDB(string email, string password, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    AmisUser nUser = context.AmisUser.Where(a => a.Email == email && a.Password == password).FirstOrDefault();
                    if (nUser == null)
                    {
                        return null;
                    }
                    return nUser;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
            
        }

        public void ChangePassword(int userId, string newPassword, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transanction = new TransactionScope())
                    {
                        AmisUser user = context.AmisUser.Where(a => a.AmisUserId == userId).FirstOrDefault();
                        if (user != null)
                        {
                            user.Password = newPassword;
                            context.SaveChanges();
                            transanction.Complete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return;
            }
        }

        public List<AmisUser> GetUserList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<AmisUser> list = context.AmisUser.OrderBy(a => a.AmisUserId).ToList();
                    if (list == null)
                    {
                        return null;
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public AmisUser GetUserByCode(string code, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    AmisUser nUser = context.AmisUser.Where(a => a.ChangePasswordCode == code).FirstOrDefault();

                    if (nUser == null)
                    {
                        return null;
                    }
                    else
                        return nUser;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
           
        }

        public void ChangeAmisUserFromMember(int memberId, string memberName, string memberEmail)
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transanction = new TransactionScope())
                    {
                        AmisUser user = context.AmisUser.Where(a => a.MemberId == memberId).FirstOrDefault();
                        if (user != null)
                        {
                            user.Name = memberName;
                            user.Email = memberEmail;
                            context.SaveChanges();
                            transanction.Complete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                errorMessage = ErrorController.GetErrorMessage(ex);
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
                        (from obj in context.AmisUser
                         select new TsDropDownItem()
                         {
                             ComboId = obj.AmisUserId.ToString(),
                             ComboName = obj.Name
                         }).ToList();
                    if (list != null)
                    {
                        return list;
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

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    IEnumerable<object> list =
                        (from user in context.AmisUser /*where user.AmisUserId != 1*/
                         select new
                         {
                             UserId = user.AmisUserId,
                             Email = user.Email,
                             Password = user.Password,
                             SecretQuestion = user.SecretQuestion,
                             SecretAnswer = user.SecretAnswer,
                             EnabledDescription = (user.Enable == "Y") ? "Habilitado" : "Deshabilitado",
                             EnabledImage = (user.Enable == "Y") ? @"~/ig_common/images/ButtonChecked16x16.png" : @"~/ig_common/images/ButtonUnchecked16x16.png",
                             Name = user.Name,
                             CreatedDate = user.CreatedDate,
                             ChangePasswordPage = user.ChangePasswordCode,
                             DisabledDate = user.DisabledDate,
                             MemberId = user.MemberId
                         }).ToList();
                    if (list != null)
                    {
                        return list;
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

        public CommonEnums.DeletedRecordStates DeleteUser(int IUserId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    AmisUser obj = context.AmisUser.Where(r => r.AmisUserId == IUserId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.AmisUser.Remove(obj);
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