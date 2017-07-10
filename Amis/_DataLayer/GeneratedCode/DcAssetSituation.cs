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
    public class DcAssetSituation
    {
        public List<AssetSituation> GetAssetSituationList()
        {
            string errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<AssetSituation> list = (from assetSituation in context.AssetSituation where assetSituation.SituationTypeId == 1 select assetSituation).ToList();
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

        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from obj in context.AssetSituation
                         select new TsDropDownItem()
                         {
                             ComboId = obj.AssetSituationId.ToString(),
                             ComboName = obj.AssetSituationName
                         }).ToList();
                    TsDropDownItem item = new TsDropDownItem();
                    item.ComboId = "0";
                    item.ComboName = "Seleccione";
                    list.Insert(0,item);
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
