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
    public class BcTagAssigned : ITsDropDownList
    {
        public void Copy(TagAssigned objSource, ref TagAssigned objDestination)
        {
            new DcTagAssigned().Copy(objSource, ref objDestination);
        }

        public TagAssigned Save(TagAssigned objSource, out string errorMessage)
        {
            TagAssigned obj = new DcTagAssigned().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La asignacion fue guardada correctamente.";

            else if (errorMessage == "Repeated TagAssigned name")
                errorMessage = "No fue posible guardar la asignacion, pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar la asignacion, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(TagAssigned TagAssigned, out string errorMessage)
        {
            if (!new BcTag().ValidateTagId(TagAssigned.TagId, out errorMessage)) return false;
            return true;
        }

        public bool ExistsTagAssigned(int TagAssignedId, out string errorMessage)
        {
            bool exist = new DcTagAssigned().ExistsTagAssigned(TagAssignedId, out errorMessage);
            return exist;
        }

        public List<TagAssigned> GetTagAssignedList(out string errorMessage)
        {
            List<TagAssigned> list = new DcTagAssigned().GetTagAssignedList(out errorMessage);
            return list;
        }

        public bool ValidateTagAssignedId(int TagAssignedId, out string errorMessage)
        {
            errorMessage = "";
            if (TagAssignedId == 0)
            {
                errorMessage = "El campo 'Id de asignacion' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateTagAssignedName(string TagAssignedName, out string errorMessage)
        {
            errorMessage = "";
            if (TagAssignedName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de asignacion' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteTagAssigned(int TagAssignedId, out string errorMessage)
        {

            CommonEnums.DeletedRecordStates wasDeleted = new DcTagAssigned().DeleteTagAssigned(TagAssignedId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "La asignacion fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró la asignacion, por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "La asignacion no pudo ser eliminado. Comuníquese con el Administrador del Sistema. "
                + "El Servidor entregó el siguiente mensaje: " + errorMessage;
            return CommonEnums.DeletedRecordStates.NotDeleted;
        }

        public void ExportWebDataGridToExcel(WebExcelExporter webExcelExporter, WebDataGrid webDataGrid)
        {
            webExcelExporter.DataExportMode = Infragistics.Web.UI.GridControls.DataExportMode.AllDataInDataSource;
            webExcelExporter.DownloadName = "amis_exported_file.xlsx";
            webExcelExporter.Export(webDataGrid);
        }

        public TagAssigned GetAssignedByTag(int tagId, out string errorMessage)
        {
            errorMessage = "";
            TagAssigned tag = new DcTagAssigned().GetAsseginedByTag(tagId, out errorMessage);
            if (tag != null)
            {
                return tag;
            }else
            {
                return null;
            }
        }
        // Implementacion de las interfaces

         
        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcTagAssigned().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcTagAssigned().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public TagAssigned GetAsseginedByAssetId(int AssetId, out string errorMessage)
        {
            return new DcTagAssigned().GetAsseginedByAssetId(AssetId, out errorMessage);
        }
    }

}