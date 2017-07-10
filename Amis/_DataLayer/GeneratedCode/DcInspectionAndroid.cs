using amis._Common;
using amis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace amis._DataLayer.GeneratedCode
{
    public class DcInspectionAndroid
    {
        public int SearchScrapIdByName(string ScrapName)
        {
            using (var context = new Entity())
            {
                int id = (from s in context.ScrapType
                          where s.ScrapName == ScrapName
                          select s.ScrapTypeId).FirstOrDefault();

                return id;
            }
        }

        public List<ListItem> GetComboList(int idUnit, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<ListItem> list =
                    (from obj in context.AssetType
                     join aui in context.AssetUniqueIdentification on obj.AssetTypeId equals aui.AssetTypeId
                     join asset in context.Asset on aui.AssetUniqueIdentificationId equals asset.AssetUniqueIdentificationId
                     join assigned in context.UnitAsset on asset.AssetId equals assigned.AssetId
                     where assigned.UnitId == idUnit && assigned.UnassignedDate == null
                     select new ListItem()
                     {
                         Text = obj.AssetTypeName,
                         Value = obj.AssetTypeId.ToString()
                     }).Distinct().ToList();
                    ListItem item0 = new ListItem();
                    item0.Text = "Seleccione";
                    item0.Value = "0";
                    list.Insert(0, item0);
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<ListItem> GetComboListScrap(int idType, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<ListItem> list =
                        (from obj in context.AssetType
                         join scrap in context.ScrapType on obj.AssetTypeId equals scrap.AssetTypeId
                         where obj.AssetTypeId == idType
                         select new ListItem()
                         {
                             Text = scrap.ScrapName,
                             Value = scrap.ScrapTypeId.ToString()
                         }).ToList();
                    ListItem item0 = new ListItem();
                    item0.Text = "Seleccione";
                    item0.Value = "0";

                    list.Insert(0, item0);
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<ListItem> GetComboListScrapName(string TypeName, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<ListItem> list =
                        (from obj in context.AssetType
                         join scrap in context.ScrapType on obj.AssetTypeId equals scrap.AssetTypeId
                         where obj.AssetTypeName == TypeName
                         select new ListItem()
                         {
                             Text = scrap.ScrapName,
                             Value = scrap.ScrapTypeId.ToString()
                         }).ToList();
                    ListItem item0 = new ListItem();
                    item0.Text = "Seleccione";
                    item0.Value = "0";

                    list.Insert(0, item0);
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public List<ListItem> GetComboListBranchOfficeUser(int amisUserId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<ListItem> list =
                        (from obj in context.BranchOffice
                         join mbo in context.MemberBranchOffice on obj.BranchOfficeId equals mbo.BranchOfficeId
                         join m in context.Member on mbo.MemberId equals m.MemberId
                         join a in context.AmisUser on m.MemberId equals a.MemberId
                         where a.AmisUserId == amisUserId
                         select new ListItem()
                         {
                             Text = obj.BranchOfficeName,
                             Value = obj.BranchOfficeId.ToString()
                         }).Distinct().ToList();
                    ListItem item0 = new ListItem();
                    item0.Text = "Seleccione";
                    item0.Value = "0";

                list.Add(item0);
                    return list;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public int GetIdBranchOfficeUser(int amisUserId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    BranchOffice list =
                        (from obj in context.BranchOffice
                         join mbo in context.MemberBranchOffice on obj.BranchOfficeId equals mbo.BranchOfficeId
                         join m in context.Member on mbo.MemberId equals m.MemberId
                         join a in context.AmisUser on m.MemberId equals a.MemberId
                         where a.AmisUserId == amisUserId
                         select obj).FirstOrDefault();
                    
                    return list.BranchOfficeId;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return 0;
            }

        }

        public int GetIdBranchOfficeByName(string BranchOfficeName, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    BranchOffice list =
                        (from obj in context.BranchOffice
                         where obj.BranchOfficeName == BranchOfficeName
                         select obj).FirstOrDefault();

                    return list.BranchOfficeId;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return 0;
            }

        }

        public int GetIdBranchOfficeByUser(int amisUserId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    BranchOffice list =
                        (from obj in context.BranchOffice
                         join mbo in context.MemberBranchOffice on obj.BranchOfficeId equals mbo.BranchOfficeId
                         join m in context.Member on mbo.MemberId equals m.MemberId
                         join a in context.AmisUser on m.MemberId equals a.MemberId
                         where a.AmisUserId == amisUserId
                         select obj).FirstOrDefault();

                    return list.BranchOfficeId;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return 0;
            }

        }

        public void SendToRepair(int branchOfficeId, string tag)
        {
            using (var context = new Entity())
            {
                Asset asset = (from a in context.Asset
                               join assigned in context.TagAssigned on a.AssetId equals assigned.AssetId
                               join tags in context.Tag on assigned.TagId equals tags.TagId
                               where tags.TagCode == tag
                               select a).FirstOrDefault();

                int IdWarehouseRepair = (from w in context.Warehouse
                                         where w.BranchOfficeId == branchOfficeId && w.WarehouseName.IndexOf("Bodega de Reparación") != -1
                                         select w.WarehouseId).FirstOrDefault();

                Facility facility = (from f in context.Facility
                                     where f.WarehouseId == IdWarehouseRepair
                                         select f).FirstOrDefault();

                if (facility != null)
                {
                    asset.FacilityId = facility.FacilityId;
                    context.SaveChanges();
                }
                else
                {
                    Facility newFacility = new Facility();
                    newFacility.WarehouseId = IdWarehouseRepair;
                    newFacility.FacilityTypeId = 1;
                    context.Facility.Add(newFacility);
                    asset.FacilityId = newFacility.FacilityId;
                    context.SaveChanges();
                }

                UnitAsset ua = (from u in context.UnitAsset
                                where u.AssetId == asset.AssetId && u.UnassignedDate==null
                                select u).FirstOrDefault();
                ua.UnassignedDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public void SendToScrap(int branchOfficeId, string tag, int scrap)
        {
            using (var context = new Entity())
            {
                Asset asset = (from a in context.Asset
                               join assigned in context.TagAssigned on a.AssetId equals assigned.AssetId
                               join tags in context.Tag on assigned.TagId equals tags.TagId
                               where tags.TagCode == tag
                               select a).FirstOrDefault();

                int IdWarehouseRepair = (from w in context.Warehouse
                                         where w.BranchOfficeId == branchOfficeId && w.WarehouseName.IndexOf("Bodega de Scrap") != -1
                                         select w.WarehouseId).FirstOrDefault();

                Facility facility = (from f in context.Facility
                                     where f.WarehouseId == IdWarehouseRepair
                                     select f).FirstOrDefault();

                if (facility != null)
                {
                    asset.FacilityId = facility.FacilityId;
                    context.SaveChanges();
                }
                else
                {
                    Facility newFacility = new Facility();
                    newFacility.WarehouseId = IdWarehouseRepair;
                    newFacility.FacilityTypeId = 1;
                    context.Facility.Add(newFacility);
                    asset.FacilityId = newFacility.FacilityId;
                    context.SaveChanges();
                }

                int assetId = asset.AssetId;
                UnitAsset ua = (from u in context.UnitAsset
                                where u.AssetId == assetId && null == u.UnassignedDate
                                select u).First();

                Tag t = (from tags in context.Tag
                         where tags.TagCode == tag
                         select tags).FirstOrDefault();
                DateTime? date = DateTime.Now;
                t.CancellationDate = date;
                asset.ScrapTypeId = scrap;
                context.SaveChanges();

                ua.UnassignedDate = date;
                context.SaveChanges();
            }
        }

        public int GetCountOffice(int amisUserId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<ListItem> list =
                        (from obj in context.BranchOffice
                         join mbo in context.MemberBranchOffice on obj.BranchOfficeId equals mbo.BranchOfficeId
                         join m in context.Member on mbo.MemberId equals m.MemberId
                         join a in context.AmisUser on m.MemberId equals a.MemberId
                         where a.AmisUserId == amisUserId
                         select new ListItem()
                         {
                             Text = obj.BranchOfficeName,
                             Value = obj.BranchOfficeId.ToString()
                         }).Distinct().ToList();
                    return list.Count;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return 0;
            }
        }

        public void ChangeState(string tag, string state)
        {
            using (var context = new Entity())
            {
                Asset asset = (from a in context.Asset
                               join assigned in context.TagAssigned on a.AssetId equals assigned.AssetId
                                             join tags in context.Tag on assigned.TagId equals tags.TagId
                                             where tags.TagCode == tag
                               select a).FirstOrDefault();
                asset.IsGood = state;
                context.SaveChanges();
            }
        }

        public UnitRegister SearchUnitByTag(string tagCode)
        {
            using (var context = new Entity())
            {
                UnitRegister unitRegister = (from u in context.UnitRegister
                                             join unit in context.Unit on u.UnitRegisterId equals unit.UnitRegisterId
                                             join unitAsigned in context.UnitAsset on unit.UnitId equals unitAsigned.UnitId
                                             join asset in context.Asset on unit.AssetId equals asset.AssetId
                                             join assigned in context.TagAssigned on asset.AssetId equals assigned.AssetId
                                             join tag in context.Tag on assigned.TagId equals tag.TagId
                                             where tag.TagCode == tagCode select u).FirstOrDefault();

                if (unitRegister!=null)
                {
                    return unitRegister;
                }

                return null;
            }
        }

        public UnitRegister SearchUnitByTag2(string tagCode)
        {
            using (var context = new Entity())
            {
                UnitRegister unitRegister = (from u in context.UnitRegister
                                             join unit in context.Unit on u.UnitRegisterId equals unit.UnitRegisterId
                                             join asset in context.Asset on unit.AssetId equals asset.AssetId
                                             join assigned in context.TagAssigned on asset.AssetId equals assigned.AssetId
                                             join tag in context.Tag on assigned.TagId equals tag.TagId
                                             where tag.TagCode == tagCode
                                             select u).FirstOrDefault();

                if (unitRegister != null)
                {
                    return unitRegister;
                }

                return null;
            }
        }

        public UnitRegister SearchUnitById(int id)
        {
            using (var context = new Entity())
            {
                UnitRegister unitRegister = (from u in context.UnitRegister where u.UnitRegisterId == id
                                             select u).FirstOrDefault();

                if (unitRegister != null)
                {
                    return unitRegister;
                }

                return null;
            }
        }

        public string SearchUrlByTag(string tagCode)
        {
            using (var context = new Entity())
            {
                AssetType asset = (from a in context.AssetType
                                   join aui in context.AssetUniqueIdentification on a.AssetTypeId equals aui.AssetTypeId
                                             join asst in context.Asset on aui.AssetUniqueIdentificationId equals asst.AssetUniqueIdentificationId
                                             join assigned in context.TagAssigned on asst.AssetId equals assigned.AssetId
                                             join tag in context.Tag on assigned.TagId equals tag.TagId
                                             where tag.TagCode == tagCode
                                             select a).FirstOrDefault();

                if (asset != null)
                {
                    return asset.AssetTypeName;
                }

                return "";
            }
        }

        public Asset SearchAssetByTag(string tagCode)
        {
            using (var context = new Entity())
            {
                Asset asset = (from a in context.Asset
                               join assigned in context.TagAssigned on a.AssetId equals assigned.AssetId
                                   join tag in context.Tag on assigned.TagId equals tag.TagId
                                   where tag.TagCode == tagCode
                                   select a).FirstOrDefault();

                if (asset != null)
                {
                    return asset;
                }

                return null;
            }
        }

        public Tag SearchTag(string tagCode)
        {
            using (var context = new Entity())
            {
                Tag tag = (from t in context.Tag
                           where t.TagCode == tagCode
                           select t).FirstOrDefault();

                if (tag != null)
                {
                    return tag;
                }

                return null;
            }
        }

        public TagAssigned SearchAssigned(int tagId)
        {
            using (var context = new Entity())
            {
                TagAssigned assigned = (from a in context.TagAssigned
                                        where a.TagId == tagId
                                        select a).FirstOrDefault();

                if (assigned != null)
                {
                    return assigned;
                }

                return null;
            }
        }

        public bool AssignedInUnit(int assetId)
        {
            using (var context = new Entity())
            {
                Asset asset = (from a in context.Asset where a.AssetId == assetId
                               join aui in context.AssetUniqueIdentification on a.AssetUniqueIdentificationId equals aui.AssetUniqueIdentificationId
                               join type in context.AssetType on aui.AssetTypeId equals type.AssetTypeId where type.AssetTypeName== "Vehiculo"
                               select a).FirstOrDefault();

                if (asset != null)
                {
                    return true;
                }

                return false;
            }
        }

        public UnitAsset ExistAssetAssigned(int assetId)
        {
            using (var context = new Entity())
            {
                UnitAsset unitAsset = (from a in context.UnitAsset
                                   join unit in context.Unit on a.UnitId equals unit.UnitId
                                   where a.AssetId == assetId
                                   select a).FirstOrDefault();

                if (unitAsset != null)
                {
                    return unitAsset;
                }

                return null;
            }
        }

        public bool SearchAssetAssigned(int assetId, int unitId)
        {
            using (var context = new Entity())
            {
                UnitAsset asset = (from a in context.UnitAsset
                               join unit in context.Unit on a.UnitId equals unit.UnitId
                               where a.AssetId == assetId && a.UnitId== unitId
                               select a).FirstOrDefault();

                if (asset != null)
                {
                    return true;
                }

                return false;
            }
        }

        public bool SearchAssetTypeAssigned(int assetId, int assetTypeId)
        {   
            using (var context = new Entity())
            {
                Asset asset = (from a in context.Asset where a.AssetId == assetId
                               join aui in context.AssetUniqueIdentification on a.AssetUniqueIdentificationId equals aui.AssetUniqueIdentificationId
                               join type in context.AssetType on aui.AssetTypeId equals type.AssetTypeId
                               where type.AssetTypeId == assetTypeId
                               select a).FirstOrDefault();

                if (asset != null)
                {
                    return true;
                }

                return false;
            }
        }

        public int GetAssetId(int id)
        {
            using (var context = new Entity())
            {
                Unit unit = (from a in context.Unit where a.UnitRegisterId==id
                               select a).FirstOrDefault();

                if (unit != null)
                {
                    return unit.AssetId;
                }

                return 0;
            }
        }

        public int GetUnitRegisterIdByPatent(String patent)
        {
            using (var context = new Entity())
            {
                UnitRegister unit = (from u in context.Unit
                             join reg in context.UnitRegister on u.UnitRegisterId equals reg.UnitRegisterId
                             where reg.PatentNumber == patent
                             select reg).FirstOrDefault();

                return unit.UnitRegisterId;
            }
        }

        public int GetUnitIdByPatent(String patent)
        {
            using (var context = new Entity())
            {
                Unit unit = (from u in context.Unit
                                     join reg in context.UnitRegister on u.UnitRegisterId equals reg.UnitRegisterId
                                     where reg.PatentNumber == patent
                                     select u).FirstOrDefault();

                return unit.UnitId;
            }
        }

        public string getAssetTypeByTag(string tag)
        {
            using (var context = new Entity())
            {
                string typeName = (from t in context.Tag
                               where t.TagCode == tag
                               join assigned in context.TagAssigned
                               on t.TagId equals assigned.TagId
                               join asset in context.Asset
                               on assigned.AssetId equals asset.AssetId
                               join aui in context.AssetUniqueIdentification
                               on asset.AssetUniqueIdentificationId equals aui.AssetUniqueIdentificationId
                               join type in context.AssetType
                               on aui.AssetTypeId equals type.AssetTypeId
                               select type.AssetTypeName).FirstOrDefault();
                return typeName;
            }
            
        }

        public Asset SearchAssetScraped(int assetId)
        {
            using (var context = new Entity())
            {
                Asset asset = (from a in context.Asset
                               where a.AssetId == assetId
                               select a).FirstOrDefault();

                if (asset.ScrapTypeId == null)
                {
                    return asset;
                }

                return null;
            }
        }

    }
}