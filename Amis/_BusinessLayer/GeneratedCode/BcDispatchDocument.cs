using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcDispatchDocument : ITsDropDownList
    {
        
		public CommonEnums.DeletedRecordStates DeleteDispatchDocument(int DispatchDocumentId,int DispatchDocumentNumber, out string errorMessage)
        {
            errorMessage = "";
			DispatchDocumentItem obj = new DispatchDocumentItem();
			if(! new DcDispatchDocumentItem().HasDispatchDocument(DispatchDocumentId,ref obj))
			{
                errorMessage = "Colocar metodo de eliminacion";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
			else
			{
				errorMessage = "El documento '" + DispatchDocumentNumber.ToString()
					+ " no pudo ser eliminado, debido a que tiene items asociados a el.";
				return CommonEnums.DeletedRecordStates.NotDeleted;
			}
			
		}

        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}