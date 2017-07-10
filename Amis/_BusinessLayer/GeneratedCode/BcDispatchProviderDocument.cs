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
    public class BcDispatchProviderDocument : ITsDropDownList
    {
        public void Copy(DispatchProviderDocument objSource, ref DispatchProviderDocument objDestination)
        {
            new DcDispatchProviderDocument().Copy(objSource, ref objDestination);
        }

        public DispatchProviderDocument Save(DispatchProviderDocument objSource, out string errorMessage)
        {
            DispatchProviderDocument obj = new DcDispatchProviderDocument().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El documento de despacho '" + objSource.DocumentNumber + "' fue guardado correctamente."; 
            else
                errorMessage = "No fue posible guardar el documento de despacho, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool ExistsDispatchProviderDocument(int DispatchProviderDocumentId, out string errorMessage)
        {
            bool exist = new DcDispatchProviderDocument().ExistsDispatchProviderDocument(DispatchProviderDocumentId, out errorMessage);
            return exist;
        }

        public List<DispatchProviderDocument> GetDispatchProviderDocumentList(out string errorMessage)
        {
            List<DispatchProviderDocument> list = new DcDispatchProviderDocument().GetDispatchProviderDocumentList(out errorMessage);
            return list;
        }

        public bool ValidateDispatchProviderDocumentId(int DispatchProviderDocumentId, out string errorMessage)
        {
            errorMessage = "";
            if (DispatchProviderDocumentId == 0)
            {
                errorMessage = "El campo 'Id de documento de despacho' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteDispatchProviderDocument(int DispatchProviderDocumentId, int DocumentNumber, out string errorMessage)
        {
			
			DispatchProviderDocumentItem obj = new DispatchProviderDocumentItem();
			if(! new DcDispatchProviderDocumentItem().HasDispatchProviderDocument(DispatchProviderDocumentId,ref obj))
			{
				CommonEnums.DeletedRecordStates wasDeleted = new DcDispatchProviderDocument().DeleteDispatchProviderDocument(DispatchProviderDocumentId, out errorMessage);
				if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
				{
					errorMessage = "El documento de despacho fue eliminado correctamente.";
					return CommonEnums.DeletedRecordStates.DeletedOk;
				}
				else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
				{
					errorMessage = "No se encontró el documento de despacho '" + DocumentNumber + "', por lo cual no pudo ser eliminado.";
					return CommonEnums.DeletedRecordStates.NotFound;
				}
			}
			else
			{
				errorMessage = "El documento '" + DocumentNumber.ToString()
					+ " no pudo ser eliminado, debido a que tiene items asociados a el.";
				return CommonEnums.DeletedRecordStates.NotDeleted;
			}
			
            
            errorMessage = "El documento de despacho '" + DocumentNumber
                + " no pudo ser eliminado. Comuníquese con el Administrador del Sistema. "
                + "El Servidor entregó el siguiente mensaje: " + errorMessage;
            return CommonEnums.DeletedRecordStates.NotDeleted;
        }

        public void ExportWebDataGridToExcel(WebExcelExporter webExcelExporter, WebDataGrid webDataGrid)
        {
            webExcelExporter.DataExportMode = Infragistics.Web.UI.GridControls.DataExportMode.AllDataInDataSource;
            webExcelExporter.DownloadName = "amis_exported_file.xlsx";
            webExcelExporter.Export(webDataGrid);
        }

        public bool ValidateNumberProvider(int number, int idMember)
        {
            return new DcDispatchProviderDocument().ValidateNumberProvider(number,idMember);
        }

        public bool ValidateStateDocument(int id, out string errorMessage)
        {
            errorMessage = "";
            if (!new DcDispatchProviderDocument().ValidateStateDocument(id, out errorMessage))
            {
                errorMessage = "La guia ya fue recepcionada correctamente, no se le pueden agregar mas items!";
                return false;
            }

            return true;
        }

        // Implementacion de las interfaces

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcDispatchProviderDocument().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcDispatchProviderDocument().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcDispatchProviderDocument().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcDispatchProviderDocument().GetComboListByFilter(id,out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableListByFilter(int number, int id,out string errorMessage)
        {
            return new DcDispatchProviderDocument().GetTableListByFilter(number, id,out errorMessage);
        }

        public List<ListItem> GetDispatchProviderDocumentNumber(int providerId, out string errorMessage)
        {
            return new DcDispatchProviderDocument().GetDispatchProviderDocimentNumber(providerId, out errorMessage);
        }

        public DispatchProviderDocument GetDocumentById(int id)
        {
            return new DcDispatchProviderDocument().GetDocumentById(id);
        }
    }

}