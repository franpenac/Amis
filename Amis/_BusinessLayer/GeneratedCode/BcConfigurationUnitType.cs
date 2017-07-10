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
    public class BcConfigurationUnitType : ITsDropDownList
    {
        public void Copy(ConfigurationUnitType objSource, ref ConfigurationUnitType objDestination)
        {
            new DcConfigurationUnitType().Copy(objSource, ref objDestination);
        }

        public ConfigurationUnitType Save(ConfigurationUnitType objSource, out string errorMessage)
        {
            ConfigurationUnitType obj = new DcConfigurationUnitType().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El tipo de configuración de unidad '" + objSource.ConfigurationUnitTypeName + "' fue guardada correctamente.";

            else if (errorMessage == "Repeated ConfigurationUnitType name")
                errorMessage = "No fue posible guardar el tipo de configuración de unidad'" + objSource.ConfigurationUnitTypeName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el tipo de configuración de unidad, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(ConfigurationUnitType ConfigurationUnitType, out string errorMessage)
        {
            if (!ValidateConfigurationUnitTypeName(ConfigurationUnitType.ConfigurationUnitTypeName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsConfigurationUnitType(int ConfigurationUnitTypeId, out string errorMessage)
        {
            bool exist = new DcConfigurationUnitType().ExistsConfigurationUnitType(ConfigurationUnitTypeId, out errorMessage);
            return exist;
        }

        public List<ConfigurationUnitType> GetConfigurationUnitTypeList(out string errorMessage)
        {
            List<ConfigurationUnitType> list = new DcConfigurationUnitType().GetConfigurationUnitTypeList(out errorMessage);
            return list;
        }

        public bool ValidateConfigurationUnitTypeId(int ConfigurationUnitTypeId, out string errorMessage)
        {
            errorMessage = "";
            if (ConfigurationUnitTypeId == 0)
            {
                errorMessage = "El campo 'Id de tipo de configuración de unidad' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateConfigurationUnitTypeName(string ConfigurationUnitTypeName, out string errorMessage)
        {
            errorMessage = "";
            if (ConfigurationUnitTypeName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de tipo de configuración de unidad' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteConfigurationUnitType(int ConfigurationUnitTypeId, string ConfigurationUnitTypeName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcConfigurationUnitType().DeleteConfigurationUnitType(ConfigurationUnitTypeId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El tipo de configuración de unidad fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el tipo de configuración de unidad '" + ConfigurationUnitTypeName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El tipo de configuración de unidad '" + ConfigurationUnitTypeName
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
            List<TsDropDownItem> list = new DcConfigurationUnitType().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcConfigurationUnitType().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcConfigurationUnitType().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public ConfigurationUnitType GetConfigurationUnitType(int configurationUnitTypeId, out string errorMessage)
        {
            ConfigurationUnitType obj = new DcConfigurationUnitType().GetConfigurationUnitType(configurationUnitTypeId, out errorMessage);
            return obj;
        }

        public ConfigurationUnitType GetMinConfigurationUnitType(out string errorMessage)
        {
            ConfigurationUnitType obj = new DcConfigurationUnitType().GetMinConfigurationUnitType(out errorMessage);
            return obj;
        }

        public ConfigurationUnitType GetMaxConfigurationUnitType(out string errorMessage)
        {
            ConfigurationUnitType obj = new DcConfigurationUnitType().GetMaxConfigurationUnitType(out errorMessage);
            return obj;
        }
    }
}