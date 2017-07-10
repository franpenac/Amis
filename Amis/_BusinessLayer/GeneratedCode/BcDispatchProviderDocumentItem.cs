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
    public class BcDispatchProviderDocumentItem : ITsDropDownList
    {
        public void Copy(DispatchProviderDocumentItem objSource, ref DispatchProviderDocumentItem objDestination)
        {
            new DcDispatchProviderDocumentItem().Copy(objSource, ref objDestination);
        }

        public DispatchProviderDocumentItem Save(DispatchProviderDocumentItem objSource, out string errorMessage)
        {
            DispatchProviderDocumentItem obj = new DcDispatchProviderDocumentItem().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El item fue guardado correctamente.";

            else if (errorMessage == "Repeated item id")
                errorMessage = "No fue posible guardar el item, pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el item, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool ExistsDispatchProviderDocumentItem(int DispatchProviderDocumentItemId, out string errorMessage)
        {
            bool exist = new DcDispatchProviderDocumentItem().ExistsDispatchProviderDocumentItem(DispatchProviderDocumentItemId, out errorMessage);
            return exist;
        }

        public List<DispatchProviderDocumentItem> GetDispatchProviderDocumentItemList(out string errorMessage)
        {
            List<DispatchProviderDocumentItem> list = new DcDispatchProviderDocumentItem().GetDispatchProviderDocumentItemList(out errorMessage);
            return list;
        }

        public bool ValidateDispatchProviderDocumentItemId(int DispatchProviderDocumentItemId, out string errorMessage)
        {
            errorMessage = "";
            if (DispatchProviderDocumentItemId == 0)
            {
                errorMessage = "El campo 'Id de item' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteDispatchProviderDocumentItem(int DispatchProviderDocumentItemId, out string errorMessage)
        {
		
            CommonEnums.DeletedRecordStates wasDeleted = new DcDispatchProviderDocumentItem().DeleteDispatchProviderDocumentItem(DispatchProviderDocumentItemId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El item fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el item, por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El acitemtivo no pudo ser eliminado. Comuníquese con el Administrador del Sistema. "
                + "El Servidor entregó el siguiente mensaje: " + errorMessage;
            return CommonEnums.DeletedRecordStates.NotDeleted;
        }

        public void ExportWebDataGridToExcel(WebExcelExporter webExcelExporter, WebDataGrid webDataGrid)
        {
            webExcelExporter.DataExportMode = Infragistics.Web.UI.GridControls.DataExportMode.AllDataInDataSource;
            webExcelExporter.DownloadName = "amis_exported_file.xlsx";
            webExcelExporter.Export(webDataGrid);
        }

        public DispatchProviderDocumentItem GetObjById(int id)
        {
            return new DcDispatchProviderDocumentItem().GetObjById(id);
        }

        // Implementacion de las interfaces

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcDispatchProviderDocumentItem().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableListByFilter(int id,out string errorMessage)
        {
            IEnumerable<object> list = new DcDispatchProviderDocumentItem().GetTableListByFilter(id,out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableListByFilterValidate(int id, out string errorMessage)
        {
            errorMessage = "";
            IEnumerable<object> list = new DcDispatchProviderDocumentItem().GetTableListByFilterValidate(id, out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        //Metodos de validacion de pagina

        public int ParseWneToString(string text)
        {
            if (text.Contains(".") || text.Contains(","))
            {
                string textNew = "";
                char[] colec = text.ToCharArray();
                foreach (char item in colec)
                {
                    if (item.ToString() != "." && item.ToString() != ",")
                    {
                        textNew = textNew + item.ToString();
                    }
                }
                return int.Parse(textNew);
            }
            else
            {
                return int.Parse(text);
            }
        }

        public bool ValidateWne(int year, int declared, int recepted, int cost, int assetTypeId ,out string errorMessage)
        {
            errorMessage = "";

            int nowYear = int.Parse(DateTime.Now.Year.ToString());
            if (cost <= 0)
            {
                errorMessage = "El costo no puede ser menor que 0";
                return false;
            }

            if (declared <= 0)
            {
                errorMessage = "La cantidad declarada no puede ser menor que 0";
                return false;
            }

            if (recepted < 0)
            {
                errorMessage = "La cantidad recepcionada no puede ser menor que 0";
                return false;
            }

            if (declared < recepted)
            {
                errorMessage = "La cantidad declarada no puede ser menor que la recepcionada";
                return false;
            }

            if (assetTypeId != 1)
            {
                if (year > nowYear || year < 1900)
                {
                    errorMessage = "La fecha de fabricacion no valida.";
                    return false;
                }
            }
            return true;
        }

        public bool ValidateWdd(string type, string origin, string brand, string model, string service, out string errorMessage)
        {
            errorMessage = "";

            if (type == "" || type == "0")
            {
                errorMessage = "Debe seleccionar un tipo de activo para poder agregar el item de la guia.";
                return false;
            }
            if (origin == "" || origin == "0")
            {
                errorMessage = "Debe seleccionar una procedencia de activo para poder agregar el item de la guia.";
                return false;
            }
            if (brand == "" || brand == "0")
            {
                errorMessage = "Debe seleccionar una marca de activo para poder agregar el item de la guia.";
                return false;
            }
            if (model == "" || model == "0")
            {
                errorMessage = "Debe seleccionar un modelo de activo para poder agregar el item de la guia.";
                return false;
            }
            if (service == "" || service == "0")
            {
                errorMessage = "Debe seleccionar un servicio de activo para poder agregar el item de la guia.";
                return false;
            }
            return true;
        }
    }

}