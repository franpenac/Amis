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
    public class BcMemberBranchOffice : ITsDropDownList
    {
        public void Copy(MemberBranchOffice objSource, ref MemberBranchOffice objDestination)
        {
            new DcMemberBranchOffice().Copy(objSource, ref objDestination);
        }

        public MemberBranchOffice Save(MemberBranchOffice objSource, out string errorMessage)
        {
            MemberBranchOffice obj = new DcMemberBranchOffice().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La asignacion de integrante a la oficina fue guardada correctamente.";
            
            else
                errorMessage = "No fue posible guardar la asignacion de integrante a la oficina, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(MemberBranchOffice memberBranchOffice, out string errorMessage)
        {
            if (!ValidateMember(memberBranchOffice.MemberId, memberBranchOffice.BranchOfficeId, out errorMessage)) return false;
            if (!ValidateBranchOffice(memberBranchOffice.BranchOfficeId, out errorMessage)) return false;
            return true;
        }

        public bool ExistsMemberBranchOffice(int MemberBranchOfficeId, out string errorMessage)
        {
            bool exist = new DcMemberBranchOffice().ExistsMemberBranchOffice(MemberBranchOfficeId, out errorMessage);
            return exist;
        }

        public List<MemberBranchOffice> GetMemberBranchOfficeList(out string errorMessage)
        {
            List<MemberBranchOffice> list = new DcMemberBranchOffice().GetMemberBranchOfficeList(out errorMessage);
            return list;
        }

        public bool ValidateMember(int idMemeber, int idBranchOffice,out string errorMessage)
        {
            errorMessage = "";

            if (idMemeber==0)
            {
                errorMessage = "Debe seleccionar un integrante, este campo no puede estar vacío.";
                return false;
            }
            MemberBranchOffice obj = new MemberBranchOffice();
            if (new DcMemberBranchOffice().HasMemberBranch(idMemeber, idBranchOffice, ref obj))
            {
                errorMessage = "El integrante seleccionado, ya está asignado a esta oficina. ";
                return false;
            }

            return true;
        }

        public bool ValidateTypeMember(int idType, out string errorMessage)
        {
            errorMessage = "";

            if (idType == 0)
            {
                errorMessage = "Debe seleccionar un tipo de integrante, este campo no puede estar vacío.";
                return false;
            }
            MemberBranchOffice obj = new MemberBranchOffice();
            if (!new DcMemberType().ExistsMemberType(idType,out errorMessage))
            {
                errorMessage = "El tipo seleccionado, no existe. Por favor, póngase en contacto con el administrador del sistema";
                return false;
            }

            return true;
        }

        public bool ValidateBranchOffice(int idBranchOffice, out string errorMessage)
        {
            errorMessage = "";

            if (idBranchOffice == 0)
            {
                errorMessage = "Debe seleccionar una sucursal, este campo no puede estar vacío.";
                return false;
            }
            if (!new DcBranchOffice().ExistsBranchOffice(idBranchOffice, out errorMessage))
            {
                errorMessage = "La sucursal, no existe. Por favor, póngase en contacto con el administrador del sistema";
                return false;
            }

            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteMemberBranchOffice(int memberBranchOfficeId, out string errorMessage)
        {
            CommonEnums.DeletedRecordStates wasDeleted = new DcMemberBranchOffice().DeleteMemberBranchOffice(memberBranchOfficeId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "La asignacion de integrante a la oficina fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró la asignacion de integrante a la oficina numero'" + memberBranchOfficeId + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "La asignacion de integrante a la oficina numero'" + memberBranchOfficeId
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
            List<TsDropDownItem> list = new DcMemberBranchOffice().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcMemberBranchOffice().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcMemberBranchOffice().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
        
    }

}