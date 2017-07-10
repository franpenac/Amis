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
    public class BcGlobalCostDetail : ITsDropDownList
    {
        public void Copy(GlobalCostDetail objSource, ref GlobalCostDetail objDestination)
        {
            new DcGlobalCostDetail().Copy(objSource, ref objDestination);
        }

        public GlobalCostDetail Save(GlobalCostDetail objSource, out string errorMessage)
        {
            GlobalCostDetail obj = new DcGlobalCostDetail().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El detalle costo global fue guardado correctamente.";

            else if (errorMessage == "Cost not valid")
                errorMessage = "No fue posible guardar la configuracion, debido a que el costo ingresado no es valida";

            else
                errorMessage = "No fue posible guardar el detalle costo global, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(GlobalCostDetail detail, out string errorMessage)
        {
            if (detail.Month > DateTime.Now)
            {
                errorMessage = "No puede ingresar costos de una fecha mayor a la actual.";
                return false;
            }
            if (!new DcGlobalCost().ExistCostDate(detail.Month, detail.GlobalCostId, out errorMessage)) return false;
            if (!new BcGlobalCost().ValidateGlobalCostId(detail.GlobalCostId, out errorMessage)) return false;
            return true;
        }

        public bool ExistsGlobalCostDetail(int GlobalCostDetailId, out string errorMessage)
        {
            bool exist = new DcGlobalCostDetail().ExistsGlobalCostDetail(GlobalCostDetailId, out errorMessage);
            return exist;
        }

        public List<GlobalCostDetail> GetGlobalCostDetailList(out string errorMessage)
        {
            List<GlobalCostDetail> list = new DcGlobalCostDetail().GetGlobalCostDetailList(out errorMessage);
            return list;
        }

        public bool ValidateGlobalCostDetailId(int GlobalCostDetailId, out string errorMessage)
        {
            errorMessage = "";
            if (GlobalCostDetailId == 0)
            {
                errorMessage = "El campo 'Id de detalle de costo global' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteGlobalCostDetail(int GlobalCostDetailId, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcGlobalCostDetail().DeleteGlobalCostDetail(GlobalCostDetailId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El detalle de costo global fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el detalle de costo global por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El detalle de costo global no pudo ser eliminado. Comuníquese con el Administrador del Sistema. "
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
            throw new NotImplementedException();
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcGlobalCostDetail().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcGlobalCostDetail().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }

}