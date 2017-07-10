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
    public class BcTag : ITsDropDownList
    {
        public void Copy(Tag objSource, ref Tag objDestination)
        {
            new DcTag().Copy(objSource, ref objDestination);
        }

        public Tag Save(Tag objSource, out string errorMessage)
        {
            Tag obj = new DcTag().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El tag '" + objSource.TagCode + "' fue guardado correctamente.";

            else if (errorMessage == "Repeated tag code name")
                errorMessage = "No fue posible guardar el tag'" + objSource.TagCode + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el tag, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(Tag Tag, out string errorMessage)
        {
            if (!ValidateTagCode(Tag.TagCode, out errorMessage)) return false;
            return true;
        }

        public bool ExistsTag(int TagId, out string errorMessage)
        {
            bool exist = new DcTag().ExistsTag(TagId, out errorMessage);
            return exist;
        }

        public List<Tag> GetTagList(out string errorMessage)
        {
            List<Tag> list = new DcTag().GetTagList(out errorMessage);
            return list;
        }

        public bool ValidateTagId(int TagId, out string errorMessage)
        {
            errorMessage = "";
            if (TagId == 0)
            {
                errorMessage = "El campo 'Id de tag' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateTagCode(string TagCode, out string errorMessage)
        {
            errorMessage = "";
            if (TagCode.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre de tag' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteTag(int TagId, string TagCode, out string errorMessage)
        {
			
			TagAssigned obj = new TagAssigned();
			if(! new DcTagAssigned().HasTag(TagId,ref obj))
			{
				CommonEnums.DeletedRecordStates wasDeleted = new DcTag().DeleteTag(TagId, out errorMessage);
				if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
				{
					errorMessage = "El tag fue eliminado correctamente.";
					return CommonEnums.DeletedRecordStates.DeletedOk;
				}
				else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
				{
					errorMessage = "No se encontró el tag '" + TagCode + "', por lo cual no pudo ser eliminado.";
					return CommonEnums.DeletedRecordStates.NotFound;
				}
			}
			else
			{
				errorMessage = "El tag unidad no pudo ser eliminado, debido a que esta siendo utilizado.";
				return CommonEnums.DeletedRecordStates.NotDeleted;
			}
						
            
            errorMessage = "El tag '" + TagCode
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
            List<TsDropDownItem> list = new DcTag().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcTag().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcTag().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public int GetTagByCode(string tagCode, out string errorMessage)
        {
            errorMessage = "";
            int id = new DcTag().GetTagByCode(tagCode,out errorMessage);
            return id;
        }

        public int GetTagButDelete(string tagCode, out string errorMessage)
        {
            errorMessage = "";
            int id = new DcTag().GetTagButDelete(tagCode, out errorMessage);
            return id;
        }

        public Tag GetTagByCodeTag(string tagCode, out string errorMessage)
        {
            Tag tag = new DcTag().GetTagByCodeTag(tagCode, out errorMessage);
            if (tag != null)
            {
                return tag;
            }else
            {
                return null;
            }
        }

        public Tag GetTagByAssetId(int assetId)
        {
            return new DcTag().GetTagByAssetId(assetId);
        }
    }

}