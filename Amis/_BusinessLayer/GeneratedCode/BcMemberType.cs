using amis._Common;
using amis._DataLayer.GeneratedCode;
using amis.Models;
using Infragistics.Web.UI.EditorControls;
using Infragistics.Web.UI.GridControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcMemberType : ITsDropDownList
    {
        public void Copy(MemberType objSource, ref MemberType objDestination)
        {
            new DcMemberType().Copy(objSource, ref objDestination);
        }

        public MemberType Save(MemberType objSource, out string errorMessage)
        {
            MemberType obj = new DcMemberType().Save(objSource, out errorMessage);
            return obj;
        }

        public bool ExistsMemberType(int MemberTypeId, out string errorMessage)
        {
            bool exist = new DcMemberType().ExistsMemberType(MemberTypeId, out errorMessage);
            return exist;
        }

        public List<MemberType> GetMemberTypeList(out string errorMessage)
        {
            List<MemberType> list = new DcMemberType().GetMemberTypeList(out errorMessage);
            return list;
        }

        public bool ValidateMemberTypeId(int memberTypeId, out string errorMessage)
        {
            errorMessage = "";
            if (memberTypeId == 0)
            {
                errorMessage = "El campo 'Id de Tipo' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateMemberTypeName(string MemberTypeName, Label lblErrorLabel)
        {
            if (MemberTypeName.Replace(" ", "") == "")
            {
                return ControlRoutines.ShowErrorLabel(false, lblErrorLabel, "El campo 'Nombre del tipo de miembro' es un campo obligatorio y no puede estar vacío");
            }
            return ControlRoutines.ShowErrorLabel(true, lblErrorLabel, "");
        }

        public int GetNewMemberTypeId()
        {
            return new DcMemberType().GetNewMemberTypeId();
        }

        public void CreateNewMemberType(WebTextEditor wteMemberTypeId, WebTextEditor wteMemberTypeName)
        {
            int newMemberTypeId = new BcMemberType().GetNewMemberTypeId();
            wteMemberTypeId.Text = newMemberTypeId.ToString();
            wteMemberTypeName.Text = "";
        }

        public CommonEnums.DeletedRecordStates DeleteMemberType(string MemberTypeId, out string errorMessage)
        {
            int iMemberTypeId = 0;
            if (!int.TryParse(MemberTypeId, out iMemberTypeId))
            {
                errorMessage = "El ID del tipo de miembro debe ser un entero válido.";
                return CommonEnums.DeletedRecordStates.NotDeleted;
            }
            //bool eliminar = FindMemberByMemberTypeId(iMemberTypeId, out errorMessage);
            //if (eliminar == false)
            //{
            //    String MemberTypeName = GetMemberTypeName(iMemberTypeId);
            //    String MemberName = new amis._DataLayer.GeneratedCode.DcMember().GetMemberNameByMemberTypeId(iMemberTypeId);

            //    errorMessage = "No fue posible eliminar el tipo de miembro " + MemberTypeName +
            //        ", pues tiene asociados mienbros, como por ejemplo: " + "'" + MemberName + "'" +
            //        ". Para poder eliminar un tipo de miembro, debe eliminar primero todos sus miembros.";
            //    return CommonEnums.DeletedRecordStates.NotDeleted;
            //}

            CommonEnums.DeletedRecordStates wasDeleted = new DcMemberType().DeleteMemberType(iMemberTypeId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El tipo de miembro fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el tipo de miembro con el ID '" + iMemberTypeId.ToString() + ", por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El tipo de miembro con el ID '" + iMemberTypeId.ToString()
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

        public List<String> GetMemberType()
        {
            List<String> tipos = new DcMemberType().GetMemberType();

            return tipos;

        }

        public int GetIdMemberType(String memberTypeName)
        {
            return new DcMemberType().GetIdMemberType(memberTypeName);
        }

        public String GetMemberTypeName(int memberTypeId)
        {
            return new DcMemberType().GetMemberTypeName(memberTypeId);
        }

        public bool FindMemberByMemberTypeId(int memberTypeId, out string errorMessage)
        {
            bool exist = new DcMemberType().FindMemberByMemberTypeId(memberTypeId, out errorMessage);
            return exist;

        }

        public List<TsDropDownItem> GetComboList(out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcMemberType().GetComboList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}