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
    public class BcApplication : ITsDropDownList
    {
        public void Copy(Application objSource, ref Application objDestination)
        {
            new DcApplication().Copy(objSource, ref objDestination);
        }

        public Application Save(Application objSource, out string errorMessage)
        {
            Application obj = new DcApplication().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La aplicacion '" + objSource.ApplicationName + "' fue guardada correctamente.";

            else if (errorMessage == "Repeated application name")
                errorMessage = "No fue posible guardar la aplicacion'" + objSource.ApplicationName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar la aplicacion, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(Application application, out string errorMessage)
        {
            if (!ValidateApplicationName(application.ApplicationName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsApplication(int ApplicationId, out string errorMessage)
        {
            bool exist = new DcApplication().ExistsApplication(ApplicationId, out errorMessage);
            return exist;
        }

        public List<Application> GetApplicationList(out string errorMessage)
        {
            List<Application> list = new DcApplication().GetApplicationList(out errorMessage);
            return list;
        }

        public bool ValidateApplicationId(int ApplicationId, out string errorMessage)
        {
            errorMessage = "";
            if (ApplicationId == 0)
            {
                errorMessage = "Debe seleccionar una aplicación, debido a que es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateApplicationName(string applicationName, out string errorMessage)
        {
            errorMessage = "";
            if (applicationName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de aplicacion' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteApplication(int applicationId, string applicationName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcApplication().DeleteApplication(applicationId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "La aplicacion fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró la aplicacion '" + applicationName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "La aplicacion '" + applicationName
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

        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcApplication().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcApplication().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcApplication().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}