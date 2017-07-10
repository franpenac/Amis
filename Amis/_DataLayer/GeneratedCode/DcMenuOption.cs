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
    public partial class DcMenuOption
    {
        public void Copy(MenuOption objSource, ref MenuOption objDestination)
        {
            objDestination.MenuOptionId = objSource.MenuOptionId;
            objDestination.ParentMenuOptionId = objSource.ParentMenuOptionId;
            objDestination.Name = objSource.Name;
            objDestination.CreatePermission = objSource.CreatePermission;
            objDestination.ReadPermission = objSource.ReadPermission;
            objDestination.UpdatePermission = objSource.UpdatePermission;
            objDestination.DeletePermission = objSource.DeletePermission;
            objDestination.FindPermission = objSource.FindPermission;
            objDestination.ExecutePermission = objSource.ExecutePermission;
            objDestination.ChangePermission = objSource.ChangePermission;
            objDestination.AuthorizePermission = objSource.AuthorizePermission;
            objDestination.Action1 = objSource.Action1;
            objDestination.NameAction1 = objSource.NameAction1;
            objDestination.Action2 = objSource.Action2;
            objDestination.NameAction2 = objSource.NameAction2;
            objDestination.Action3 = objSource.Action3;
            objDestination.NameAction3 = objSource.NameAction3;
            objDestination.Action4 = objSource.Action4;
            objDestination.NameAction4 = objSource.NameAction4;
            objDestination.Action5 = objSource.Action5;
            objDestination.NameAction5 = objSource.NameAction5;
            objDestination.Action6 = objSource.Action6;
            objDestination.NameAction6 = objSource.NameAction6;
            objDestination.Action7 = objSource.Action7;
            objDestination.NameAction7 = objSource.NameAction7;
            objDestination.Active = objSource.Active;
        }

        public MenuOption Save(MenuOption objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        MenuOption menuOption = context.MenuOption.Where(r => r.MenuOptionId != objSource.MenuOptionId).FirstOrDefault();
                        if (menuOption != null) return (MenuOption)ErrorController.SetErrorMessage("Repeated MenuOption Id", out errorMessage);

                        MenuOption row = context.MenuOption.Where(r => r.MenuOptionId == objSource.MenuOptionId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new MenuOption();
                            Copy(objSource, ref row);
                            context.MenuOption.Add(row);
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

        public bool ExistsMenuOption(int MenuOptionId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                MenuOption obj = null;
                using (var context = new Entity())
                {
                    obj = context.MenuOption.Where(r => r.MenuOptionId != MenuOptionId).FirstOrDefault();
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

        public MenuOption GetMenuOptionById(int MenuOptionId)
        {
            using (var context = new Entity())
            {
                MenuOption menuOption = context.MenuOption.Where(a => a.MenuOptionId == MenuOptionId).FirstOrDefault();
                return menuOption;
            }
        }

        public string GetParentMenuOptionNameById(int ParentMenuOptionId)
        {
            using (var context = new Entity())
            {
                string parentMenuOptionName = "";
                    MenuOption obj = context.MenuOption.Where(a => a.MenuOptionId == ParentMenuOptionId).FirstOrDefault();
                if (obj!=null)
                {
                    parentMenuOptionName = obj.Name;
                }
                return parentMenuOptionName;
            }
        }

        public List<MenuOption> GetMenuOptionList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<MenuOption> list = context.MenuOption.OrderBy(a => a.MenuOptionId).ToList();
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
                        (from MenuOption in context.MenuOption
                         join menuOption in context.MenuOption on MenuOption.MenuOptionId equals menuOption.MenuOptionId
                         select new
                         {
                             MenuOptionId = MenuOption.MenuOptionId,
                             ParentMenuOptionId = MenuOption.ParentMenuOptionId,
                             Name = MenuOption.Name,
                             CreatePermission = MenuOption.CreatePermission,
                             ReadPermission = MenuOption.ReadPermission,
                             UpdatePermission = MenuOption.UpdatePermission,
                             DeletePermission = MenuOption.DeletePermission,
                             FindPermission = MenuOption.FindPermission,
                             ExecutePermission = MenuOption.ExecutePermission,
                             ChangePermission = MenuOption.ChangePermission,
                             AuthorizePermission = MenuOption.AuthorizePermission,
                             Action1 = MenuOption.Action1,
                             NameAction1 = MenuOption.NameAction1,
                             Action2 = MenuOption.Action2,
                             NameAction2 = MenuOption.NameAction2,
                             Action3 = MenuOption.Action3,
                             NameAction3 = MenuOption.NameAction3,
                             Action4 = MenuOption.Action4,
                             NameAction4 = MenuOption.NameAction4,
                             Action5 = MenuOption.Action5,
                             NameAction5 = MenuOption.NameAction5,
                             Action6 = MenuOption.Action6,
                             NameAction6 = MenuOption.NameAction6,
                             Action7 = MenuOption.Action7,
                             NameAction7 = MenuOption.NameAction7,
                             Active = MenuOption.Active

                         }).ToList();
                    if (list!=null)
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

        public CommonEnums.DeletedRecordStates DeleteMenuOption(int IMenuOptionId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    MenuOption obj = context.MenuOption.Where(r => r.MenuOptionId == IMenuOptionId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.MenuOption.Remove(obj);
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

        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.MenuOption where obj.MenuOptionId >8
                         select new TsDropDownItem()
                         {
                             ComboId = obj.MenuOptionId.ToString(),
                             ComboName = obj.Name
                         }).OrderBy(r => r.ComboName).ToList();
                    if (list != null)
                    {
                        return list;
                    }
                    else
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