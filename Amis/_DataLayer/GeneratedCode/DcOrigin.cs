using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using amis._Common;
using amis.Models;

namespace amis._DataLayer
{
    public partial class DcOrigin
    {
        public void Copy(Origin objSource, ref Origin objDestination)
        {
            objDestination.OriginId = objSource.OriginId;
            objDestination.OriginName = objSource.OriginName;
        }

        public Origin Save(Origin objSource, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    Origin row = context.Origin.Where(r => r.OriginId == objSource.OriginId).FirstOrDefault();

                    using (TransactionScope transaction = new TransactionScope())
                    {
                        if (row == null)
                        {
                            row = new Origin();
                            Copy(objSource, ref row);
                            context.Origin.Add(row);
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
            catch(Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return null;
            }
        }

        public bool ExistsOrigin(int OriginId, out string errorMessage)
        {
            errorMessage = "";
            try
            {
                Origin obj = null;
                using (var context = new Entity ())
                {
                    obj = context.Origin.Where(r => r.OriginId != OriginId).FirstOrDefault();
                    if (obj == null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch(Exception ex)
            {
                errorMessage = ErrorController.GetErrorMessage(ex);
                return false;
            }
        }

        public List<Origin> GetOriginList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<Origin> list = context.Origin.OrderBy(r => r.OriginName).ToList();
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
                        (from obj in context.Origin
                         select new TsDropDownItem()
                         {
                             ComboId = obj.OriginId.ToString(),
                             ComboName = obj.OriginName
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

        public int GetNewOriginId()
        {
            using (var context = new Entity())
            {
                int maxId = 0;
                int numOrigins = context.Origin.Count();
                if (numOrigins == 0)
                {
                    maxId = 1;
                }
                else
                {
                    maxId = context.Origin.Max(r => r.OriginId);
                }
                return maxId + 1;
            }
        }

        public CommonEnums.DeletedRecordStates DeleteOrigin(int iOriginId, out string errorMessage)
        {
            try
            {
                using (var context = new Entity())
                {
                    errorMessage = "";
                    Origin obj = context.Origin.Where(r => r.OriginId == iOriginId).FirstOrDefault();
                    if (obj == null)
                    {
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    context.Origin.Remove(obj);
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

        public List<String> GetCountry()
        {
            List<Origin> list = new List<Origin>();
            List<String> paises = new List<String>();

            using (var context = new Entity())
            {
                list = context.Origin.OrderBy(r => r.OriginName).ToList();
            }

            foreach (Origin p in list)
            {
                paises.Add(p.OriginName);
            }
            return paises;
        }

        public int GetIdOrigin(String originName)
        {
            int Id=0;
            using (var context = new Entity())
            {
                Origin obj = context.Origin.Where(r => r.OriginName == originName).FirstOrDefault();
                if (obj == null)
                {

                }
                else
                {  Id = obj.OriginId; }                  
            }
            return Id;
        }

        public String GetOriginName(int originId)
        {
            using (var context = new Entity())
            {
                String paisBuscado = "";
                Origin obj = context.Origin.Where(r => r.OriginId == originId).FirstOrDefault();
                if (obj != null)
                {
                    paisBuscado = obj.OriginName;
                }
                return paisBuscado;
            }
        }

    }
}
