using System.Transactions;
using amis._Common;
using amis._DataLayer;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infragistics.Web.UI;
using Infragistics.Web.UI.EditorControls;
using Infragistics.Web.UI.GridControls;
using amis.Models;
using amis._DataLayer.GeneratedCode;
using System.Collections.Generic;
using System;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcAssetSituation : ITsDropDownList
    {
        public List<AssetSituation> GetAssetSituationList()
        {
            List<AssetSituation> list = new DcAssetSituation().GetAssetSituationList();
            AssetSituation item = new AssetSituation();
            item.AssetSituationId = 0;
            item.SituationTypeId = 1;
            item.AssetSituationName = "Seleccione";
            list.Insert(0, item);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcAssetSituation().GetComboList(out errorMessage);
            return list;
        }
    }
}
