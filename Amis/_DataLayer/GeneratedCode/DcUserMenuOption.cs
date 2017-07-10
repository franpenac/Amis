using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;
using amis._Controls;

namespace amis._DataLayer.GeneratedCode
{
    public partial class DcUserMenuOption
    {
        public void Copy(UserMenuOption objSource, ref UserMenuOption objDestination)
        {
            objDestination.UserMenuOptionId = objSource.UserMenuOptionId;
            objDestination.AmisUserId = objSource.AmisUserId;
            objDestination.MenuOptionId = objSource.MenuOptionId;
            objDestination.CanCreate = objSource.CanCreate;
            objDestination.CanRead = objSource.CanRead;
            objDestination.CanUpdate = objSource.CanUpdate;
            objDestination.CanDelete = objSource.CanDelete;
            objDestination.CanFind = objSource.CanFind;
            objDestination.CanExecute = objSource.CanExecute;
            objDestination.CanChange = objSource.CanChange;
            objDestination.CanAuthorize = objSource.CanAuthorize;
            objDestination.CanDoAction1 = objSource.CanDoAction1;
            objDestination.CanDoAction2 = objSource.CanDoAction2;
            objDestination.CanDoAction3 = objSource.CanDoAction3;
            objDestination.CanDoAction4 = objSource.CanDoAction4;
            objDestination.CanDoAction5 = objSource.CanDoAction5;
            objDestination.CanDoAction6 = objSource.CanDoAction6;
            objDestination.CanDoAction7 = objSource.CanDoAction7;
            objDestination.CanGenerateReport = objSource.CanGenerateReport;
        }

        public UserMenuOption Save(UserMenuOption objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        CommonEnums.PageActionEnum action = new CommonEnums.PageActionEnum();

                        UserMenuOption row = context.UserMenuOption.Where(r => r.UserMenuOptionId == objSource.UserMenuOptionId).FirstOrDefault();
                        if (row == null)
                        {
                            row = new UserMenuOption();
                            Copy(objSource, ref row);
                            context.UserMenuOption.Add(row);
                            action = CommonEnums.PageActionEnum.Create;

                        }
                        else
                        {
                            Copy(objSource, ref row);
                            action = CommonEnums.PageActionEnum.Update;

                        }
                        context.SaveChanges();
                        string description = "Se ha añadido al usuario:" + row.AmisUserId + " con el id:" + row.MenuOptionId;
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

        public UserMenuOption GetUserMenuOptionByUserId(int userId)
        {
            try
            {
                UserMenuOption obj = null;
                using (var context = new Entity())
                {
                    obj = context.UserMenuOption.Where(r => r.AmisUserId == userId).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public List<MenuOption> UserAuthorizedPages(int userId)
        {
            try
            {
                using (var context = new Entity())
                {
                    List<UserMenuOption> userMenuOptionList = context.UserMenuOption.Where(r => r.AmisUserId == userId && r.CanAuthorize == "Y" && r.CanCreate == "Y").ToList();

                    List<MenuOption> list = (
                        from umo in userMenuOptionList
                        join mo in context.MenuOption on umo.MenuOptionId equals mo.MenuOptionId
                        select mo).ToList();

                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MenuOption> UserAuthorizedModules(int userId)
        {
            try
            {
                using (var context = new Entity())
                {
                    List<MenuOption> userMenuOptionList = UserAuthorizedPages(userId);

                    List<MenuOption> list = (
                        from umo in userMenuOptionList
                        join mo in context.MenuOption on umo.ParentMenuOptionId equals mo.MenuOptionId
                        where mo.CreatePermission == "Y"
                        select mo).Distinct().OrderBy(r => r.Name).ToList();

                    return list;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public UserMenuOption GetUserMenuOptionById(int menuOptionId, int userId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                UserMenuOption obj = null;
                using (var context = new Entity())
                {
                    obj = context.UserMenuOption.Where(r => r.MenuOptionId == menuOptionId && r.AmisUserId == userId).FirstOrDefault();
                    if (obj != null)
                    {
                        return obj;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public bool ValidUserToPage(int menuOptionId, int userId)
        {
            try
            {
                UserMenuOption obj = null;
                using (var context = new Entity())
                {
                    obj = context.UserMenuOption.Where(r => r.MenuOptionId == menuOptionId && r.AmisUserId == userId).FirstOrDefault();
                    if (obj == null || obj.CanAuthorize =="N")
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception)
            {
                throw new Exception();
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
                        (from menuOption in context.MenuOption where menuOption.ParentMenuOptionId.ToString() != "NULL"
                         select new 
                         { 
                             MenuOptionId = menuOption.MenuOptionId,

                         ParentMenuOptionName = (menuOption.ParentMenuOptionId == 1 && menuOption.ParentMenuOptionId != null) ? "Configurarion" :
                             (menuOption.ParentMenuOptionId == 2 && menuOption.ParentMenuOptionId != null) ? "Activos" :
                             (menuOption.ParentMenuOptionId == 3 && menuOption.ParentMenuOptionId != null) ? "Operaciones" :
                             (menuOption.ParentMenuOptionId == 4 && menuOption.ParentMenuOptionId != null) ? "Inventario" :
                             (menuOption.ParentMenuOptionId == 5 && menuOption.ParentMenuOptionId != null) ? "Mantencion" :
                             (menuOption.ParentMenuOptionId == 6 && menuOption.ParentMenuOptionId != null) ? "Reportes" :
                             (menuOption.ParentMenuOptionId == 7 && menuOption.ParentMenuOptionId != null) ? "Usuarios" :
                             (menuOption.ParentMenuOptionId == 31 && menuOption.ParentMenuOptionId != null) ? "R4 Costo kilometros y recapados" :
                             (menuOption.ParentMenuOptionId == 39 && menuOption.ParentMenuOptionId != null) ? "R5 Compras Proveedores" : "Módulo",
                             Name = menuOption.Name,
                             AuthorizePermission = "Y",
                             CreatePermission = "Y",
                             DeletePermission = "Y",
                             GenerateReportPermission = "Y",
                             EnabledImage = ""
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

        public List<UserMenuOptionAuthorization> GetPagesList(int userId)
        {
            try
            {
                using (var context = new Entity())
                {
                    List<MenuOption> listMenuOption = (from mo in context.MenuOption where mo.ParentMenuOptionId != null select mo).ToList();

                    List<UserMenuOptionAuthorization> listUserMenuOptionAuthorization = new List<UserMenuOptionAuthorization>();

                    foreach (var menuOption in listMenuOption)
                    {
                        UserMenuOptionAuthorization umoAuth = new UserMenuOptionAuthorization();

                        UserMenuOption userMenuOption = 
                            (from UserMenuOption in context.UserMenuOption
                             where UserMenuOption.MenuOptionId == menuOption.MenuOptionId && UserMenuOption.AmisUserId == userId
                             select UserMenuOption
                             ).FirstOrDefault();

                            if (userMenuOption == null)
                            {
                                umoAuth.UserId = userId;
                                umoAuth.MenuOptionId = menuOption.MenuOptionId;
                                umoAuth.CanAuthorize = "N";
                                umoAuth.CanCreate = "N";
                                umoAuth.CanDelete = "N";
                                umoAuth.CanGenerateReport = "N";
                                umoAuth.MenuOptionName = menuOption.Name;
                                umoAuth.ParentMenuOptionName = (from mo in context.MenuOption
                                                            where mo.MenuOptionId ==
                                                            menuOption.ParentMenuOptionId
                                                                select mo.Name).FirstOrDefault();
                        }
                            else
                            {
                                umoAuth.UserId = userId;
                                umoAuth.MenuOptionId = userMenuOption.MenuOptionId;
                                umoAuth.CanAuthorize = userMenuOption.CanAuthorize;
                                umoAuth.CanCreate = userMenuOption.CanCreate;
                                umoAuth.CanDelete = userMenuOption.CanDelete;
                                umoAuth.CanGenerateReport = userMenuOption.CanGenerateReport;
                                umoAuth.MenuOptionName = menuOption.Name;
                                umoAuth.ParentMenuOptionName = (from mo in context.MenuOption
                                                            where mo.MenuOptionId ==
                                                            menuOption.ParentMenuOptionId
                                                            select mo.Name).FirstOrDefault();

                        }
                        listUserMenuOptionAuthorization.Add(umoAuth);
                    }

                    return listUserMenuOptionAuthorization;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return null;
            }
        }
    }
}