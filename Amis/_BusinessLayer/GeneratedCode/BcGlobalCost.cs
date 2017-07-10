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
    public class BcGlobalCost : ITsDropDownList
    {
        public void Copy(GlobalCost objSource, ref GlobalCost objDestination)
        {
            new DcGlobalCost().Copy(objSource, ref objDestination);
        }

        public GlobalCost Save(GlobalCost objSource, out string errorMessage)
        {
            GlobalCost obj = new DcGlobalCost().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El costo global '" + objSource.GlobalCostName + "' fue guardado correctamente.";

            else if (errorMessage == "Repeated globalCost name")
                errorMessage = "No fue posible guardar el costo global'" + objSource.GlobalCostName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el costo global, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(GlobalCost GlobalCost, out string errorMessage)
        {
            if (!ValidateGlobalCostName(GlobalCost.GlobalCostName, out errorMessage)) return false;
            return true;
        }

        public bool ExistsGlobalCost(int GlobalCostId, out string errorMessage)
        {
            bool exist = new DcGlobalCost().ExistsGlobalCost(GlobalCostId, out errorMessage);
            return exist;
        }

        public List<GlobalCost> GetGlobalCostList(out string errorMessage)
        {
            List<GlobalCost> list = new DcGlobalCost().GetGlobalCostList(out errorMessage);
            return list;
        }

        public bool ValidateGlobalCostId(int GlobalCostId, out string errorMessage)
        {
            errorMessage = "";
            if (GlobalCostId == 0)
            {
                errorMessage = "El campo 'Id de costo global' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateGlobalCostName(string GlobalCostName, out string errorMessage)
        {
            errorMessage = "";
            if (GlobalCostName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de costo global' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteGlobalCost(int GlobalCostId, string GlobalCostName, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcGlobalCost().DeleteGlobalCost(GlobalCostId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El costo global fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el costo global '" + GlobalCostName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El costo global '" + GlobalCostName
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
            List<TsDropDownItem> list = new DcGlobalCost().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcGlobalCost().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcGlobalCost().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcGlobalCost().GetComboListFilter(out errorMessage);
            return list;
        }


    }

}