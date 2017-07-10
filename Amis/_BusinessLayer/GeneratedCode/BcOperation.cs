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
    public class BcOperation : ITsDropDownList
    {
        public void Copy(Operation objSource, ref Operation objDestination)
        {
            new DcOperation().Copy(objSource, ref objDestination);
        }

        public Operation Save(Operation objSource, out string errorMessage)
        {
            Operation obj = new DcOperation().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La operación '" + objSource.OperationName + "' fue guardada correctamente.";

            else if (errorMessage == "Repeated operation name")
                errorMessage = "No fue posible guardar la operación '" + objSource.OperationName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar la operación, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(Operation operation, out string errorMessage)
        {
            if (!ValidateOperationName(operation.OperationName, out errorMessage)) return false;
            if (!ValidateBranchOffice(operation.BranchOfficeId, out errorMessage)) return false;
            if (!ValidateMember(operation.MemberId, out errorMessage)) return false;
            return true;
        }

        public bool ExistsOperation(int OperationId, out string errorMessage)
        {
            bool exist = new DcOperation().ExistsOperation(OperationId, out errorMessage);
            return exist;
        }

        public List<Operation> GetOperationList(out string errorMessage)
        {
            List<Operation> list = new DcOperation().GetOperationList(out errorMessage);
            return list;
        }

        public bool ValidateOperationId(int OperationId, out string errorMessage)
        {
            errorMessage = "";
            if (OperationId == 0)
            {
                errorMessage = "Debe seleccionar una operación, debido a que es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateOperationName(string operationName, out string errorMessage)
        {
            errorMessage = "";
            if (operationName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de operación' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteOperation(int operationId, string operationName, out string errorMessage)
        {

            Assignment obj = new Assignment();
            if (!new DcAssignment().HasOperation(operationId, ref obj))
            {
                CommonEnums.DeletedRecordStates wasDeleted = new DcOperation().DeleteOperation(operationId, out errorMessage);
                if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
                {
                    errorMessage = "La operación fue eliminado correctamente.";
                    return CommonEnums.DeletedRecordStates.DeletedOk;
                }
                else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
                {
                    errorMessage = "No se encontró la operación '" + operationName + "', por lo cual no pudo ser eliminado.";
                    return CommonEnums.DeletedRecordStates.NotFound;
                }
            }
            else
            {
                errorMessage = "La operación '" + operationName
                    + " no pudo ser eliminado, debido a que tiene unidades asociados a ella, como por ejemplo la unidad con patente: '";
                return CommonEnums.DeletedRecordStates.NotDeleted;
            }


            errorMessage = "La operación '" + operationName
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
            List<TsDropDownItem> list = new DcOperation().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcOperation().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcOperation().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        protected bool ValidateBranchOffice(int branchOfficeId, out string errorMessage)
        {
            errorMessage = "";
            if (branchOfficeId != 0)
            {
                return true;
            }
            else { errorMessage = "Debe seleccionar una sucursal para la operación"; return false; }
        }

        protected bool ValidateMember(int memberId, out string errorMessage)
        {
            errorMessage = "";
            if (memberId != 0)
            {
                Member member = new DcMember().SearchMemberBranchOfficeById(memberId);
                if (member != null)
                {
                    return true;
                }
                else
                {
                    errorMessage = "El cliente seleccionado, debe estar previamente asignado a alguna sucursal.";
                    return false;
                }
            }
            else { errorMessage = "Debe seleccionar un cliente para la operación"; return false; }
        }

        public List<ListItem> GetClientBranchOfficeList(int branchOfficeId, out string errorMessage)
        {
            return new DcMember().GetClientBranchOfficeList(branchOfficeId, out errorMessage);
        }

        public List<ListItem> GetBranchOfficeItemList(out string errorMessage)
        {
            return new DcBranchOffice().GetBranchOfficeItemList(out errorMessage);
        }

        public Operation GetOperationById(int OperationId, out string errorMessage)
        {
            return new DcOperation().GetOperationById(OperationId, out errorMessage);
        }
    }
}