using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using amis._Common;
using amis.Models;

namespace amis._DataLayer.GeneratedCode
{
    public class DcAmisTaskType
    {
        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            errorMessage = "";
            try
            {
                using (var context = new Entity())
                {
                    List<TsDropDownItem> list =
                        (from tt in context.AmisTaskType
                         select new TsDropDownItem
                         {
                             ComboId = tt.AmisTaskTypeId.ToString(),
                             ComboName   = tt.AmisTaskTypeName

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