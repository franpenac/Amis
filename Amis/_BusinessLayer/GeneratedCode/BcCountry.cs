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
    public class BcCountry : ITsDropDownList
    {
        public void Copy(Country objSource, ref Country objDestination)
        {
            new DcCountry().Copy(objSource, ref objDestination);
        }

        public Country Save(Country objSource, out string errorMessage)
        {
            Country obj = new DcCountry().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El pais '" + objSource.CountryName + "' fue guardada correctamente.";

            else if (errorMessage == "Repeated Country name")
                errorMessage = "No fue posible guardar el pais'" + objSource.CountryName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el pais, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(Country Country, out string errorMessage)
        {
            if (!ValidateCountryName(Country.CountryName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsCountry(int CountryId, out string errorMessage)
        {
            bool exist = new DcCountry().ExistsCountry(CountryId, out errorMessage);
            return exist;
        }

        public List<Country> GetCountryList(out string errorMessage)
        {
            List<Country> list = new DcCountry().GetCountryList(out errorMessage);
            return list;
        }

        public bool ValidateCountryId(int CountryId, out string errorMessage)
        {
            errorMessage = "";
            if (CountryId == 0)
            {
                errorMessage = "El campo 'Id de pais' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateCountryName(string CountryName, out string errorMessage)
        {
            errorMessage = "";
            if (CountryName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de pais' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteCountry(int CountryId, string CountryName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcCountry().DeleteCountry(CountryId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El pais fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el pais '" + CountryName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El pais '" + CountryName
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

        // Implementacion de las interfaces

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcCountry().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcCountry().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcCountry().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}