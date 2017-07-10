using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Transactions;
using amis._Common;
using amis.Models;

namespace amis._DataLayer.GeneratedCode
{
    public class DcModelPurchaseReport
    {
        public List<Asset> GetListReport(int month, int year)
        {
            DateTime init = new DateTime();
            DateTime end = new DateTime();
            if (month.ToString().Length == 1)
            {

                init = DateTime.Parse(year.ToString() + "-0" + month.ToString() + "-01");
                end = DateTime.Parse((year + 1).ToString() + "-0" + (month).ToString() + "-01");
            }
            else
            {

                init = DateTime.Parse(year.ToString() + "-" + month.ToString() + "-01");
                end = DateTime.Parse((year + 1).ToString() + "-" + (month).ToString() + "-01");
            }

            using (var context = new Entity())
            {
                GlobalCostDetail list = new GlobalCostDetail();

                List<Asset> listado = (from asset in context.Asset where asset.WarrantyStartDate >= init && asset.WarrantyStartDate <= end
                                               join unique in context.AssetUniqueIdentification on asset.AssetUniqueIdentificationId equals unique.AssetUniqueIdentificationId
                                               join model in context.AssetModel on unique.AssetModelId equals model.AssetModelId
                                               join brand in context.Brand on model.BrandId equals brand.BrandId
                                               select asset).ToList();
                return listado;
            }
        }

        public string GetBrandHeader(int id)
        {
            using (var context= new Entity())
            {

                string brandName = (from name in context.AssetUniqueIdentification
                                    where name.AssetUniqueIdentificationId == id
                                    join model in context.AssetModel on name.AssetModelId equals model.AssetModelId
                                    join brand in context.Brand on model.BrandId equals brand.BrandId
                                    select brand.BrandName).FirstOrDefault();

                return brandName;
            }
        }

        public string GetModelHeader(int id)
        {
            using (var context = new Entity())
            {

                string modelName = (from name in context.AssetUniqueIdentification
                                    where name.AssetUniqueIdentificationId == id
                                    join model in context.AssetModel on name.AssetModelId equals model.AssetModelId
                                    select model.AssetModelName).FirstOrDefault();

                return modelName;
            }
        }

        public int GetIdProvider(string providerName)
        {
            using (var context = new Entity())
            {
                int id = (from member in context.Member where member.MemberName == providerName select member.MemberId).FirstOrDefault();

                return id;
            }
        }

        public DateTime GetDateItem(int id)
        {
            using (var context = new Entity())
            {
                DateTime date = (from item in context.DispatchProviderDocumentItem
                                 join disp in context.DispatchProviderDocument on item.DispatchProviderDocumentId equals disp.DispatchProviderDocumentId
                                 where item.DispatchProviderDocumentItemId == id
                                 select disp.DispatchDate).FirstOrDefault();

                return date;
            }
        }

        public List<DispatchProviderDocumentItem> GetReportByFilter(string provider,int month, int year)
        {
            DateTime init = new DateTime();
            DateTime end = new DateTime();

            int id = GetIdProvider(provider);
            if (month.ToString().Length == 1)
            {

                init = DateTime.Parse(year.ToString() + "-0" + month.ToString() + "-01");
                end = DateTime.Parse((year + 1).ToString() + "-0" + (month).ToString() + "-01");
            }
            else
            {

                init = DateTime.Parse(year.ToString() + "-" + month.ToString() + "-01");
                end = DateTime.Parse((year + 1).ToString() + "-" + (month).ToString() + "-01");
            }

            using (var context = new Entity())
            {
                DispatchProviderDocumentItem list = new DispatchProviderDocumentItem();

                List<DispatchProviderDocumentItem> listado = (from item in context.DispatchProviderDocumentItem where item.DispatchProviderDocumentStateId==1
                                                              join doc in context.DispatchProviderDocument on item.DispatchProviderDocumentId equals doc.DispatchProviderDocumentId
                                                              where doc.DispatchDate >= init && doc.DispatchDate <= end && doc.ProviderMemberId==id
                                                               join unique in context.AssetUniqueIdentification on item.AssetUniqueIdentificationId equals unique.AssetUniqueIdentificationId
                                                               join model in context.AssetModel on unique.AssetModelId equals model.AssetModelId
                                                               join brand in context.Brand on model.BrandId equals brand.BrandId
                                                               select item).ToList();
                return listado;
            }
        }

        public List<DispatchProviderDocumentItem> GetReportDontFilter(int month, int year)
        {
            DateTime init = new DateTime();
            DateTime end = new DateTime();
            
            if (month.ToString().Length == 1)
            {

                init = DateTime.Parse(year.ToString() + "-0" + month.ToString() + "-01");
                end = DateTime.Parse((year + 1).ToString() + "-0" + (month).ToString() + "-01");
            }
            else
            {

                init = DateTime.Parse(year.ToString() + "-" + month.ToString() + "-01");
                end = DateTime.Parse((year + 1).ToString() + "-" + (month).ToString() + "-01");
            }

            using (var context = new Entity())
            {
                DispatchProviderDocumentItem list = new DispatchProviderDocumentItem();

                List<DispatchProviderDocumentItem> listado = (from item in context.DispatchProviderDocumentItem
                                                              where item.DispatchProviderDocumentStateId == 1
                                                              join doc in context.DispatchProviderDocument on item.DispatchProviderDocumentId equals doc.DispatchProviderDocumentId
                                                              where doc.DispatchDate >= init && doc.DispatchDate <= end
                                                              join unique in context.AssetUniqueIdentification on item.AssetUniqueIdentificationId equals unique.AssetUniqueIdentificationId
                                                              join model in context.AssetModel on unique.AssetModelId equals model.AssetModelId
                                                              join brand in context.Brand on model.BrandId equals brand.BrandId
                                                              select item).ToList();
                return listado;
            }
        }

        public List<Member> GetComboProvider()
        {
            using (var context = new Entity())
            {
                List<Member> listProvider = (from member in context.Member
                                             join disp in context.DispatchProviderDocument on member.MemberId equals disp.ProviderMemberId
                                             join item in context.DispatchProviderDocumentItem on disp.DispatchProviderDocumentId equals item.DispatchProviderDocumentId
                                             select member).Distinct().ToList();
                return listProvider;
            }
        }

        public List<Member> GetComboEnterprise()
        {
            using (var context = new Entity())
            {
                List<Member> listProvider = (from member in context.Member
                                             join type in context.MemberType on member.MemberTypeId equals type.MemberTypeId
                                             where type.MemberTypeId == 2
                                             select member).Distinct().ToList();
                return listProvider;
            }
        }
    }
}