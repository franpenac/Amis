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
    public class BcReceptionDocument : ITsDropDownList
    {
        
		public CommonEnums.DeletedRecordStates DeleteReceptionDocument(int ReceptionDocumentId,int ReceptionDocumentNumber, out string errorMessage)
        {

			ReceptionDocumentItem obj = new ReceptionDocumentItem();
			if(! new DcReceptionDocumentItem().HasDispatchDocument(ReceptionDocumentId,ref obj))
			{
                //Colocar las lineas de eliminacion normal del codigo!
                errorMessage = "Colocar metodo de eliminacion";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
			else
			{
				errorMessage = "El documento '" + ReceptionDocumentNumber.ToString()
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