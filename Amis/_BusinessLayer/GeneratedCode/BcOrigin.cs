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

namespace amis._BusinessLayer
{
    public partial class BcOrigin : ITsDropDownList
    {
        public void Copy(Origin objSource, ref Origin objDestination)
        {
            new DcOrigin().Copy(objSource, ref objDestination);
        }

        public Origin Save(Origin objSource, out string errorMessage)
        {
            Origin obj = new DcOrigin().Save(objSource, out errorMessage);
            return obj;
        }

        public bool ExistsOrigin(int OriginId, out string errorMessage)
        {
            bool exist = new DcOrigin().ExistsOrigin(OriginId, out errorMessage);
            return exist;
        }

        public List<Origin> GetOriginList(out string errorMessage)
        {
            List<Origin> list = new DcOrigin().GetOriginList(out errorMessage);
            return list;
        }

        public bool ValidateOriginId(int originId, out string errorMessage)
        {
            errorMessage = "";
            if (originId == 0)
            {
                errorMessage = "El campo 'Id de procedencia' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateOriginName(string originName, out string errorMessage)
        {
            errorMessage = "";
            if (originName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre procedencia' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public int GetNewOriginId()
        {
            return new DcOrigin().GetNewOriginId();
        }

        public void CreateNewOrigin(WebTextEditor wteOriginId, WebTextEditor wteOriginName)
        {
            int newOriginId = new BcOrigin().GetNewOriginId();
            wteOriginId.Text = newOriginId.ToString();
            wteOriginName.Text = "";
        }

        public CommonEnums.DeletedRecordStates DeleteOrigin(string originId, out string errorMessage)
        {
            int iOriginId = 0;
            if (!int.TryParse(originId, out iOriginId))
            {
                errorMessage = "El ID de origen debe ser un entero válido.";
                return CommonEnums.DeletedRecordStates.NotDeleted;
            }

            //bool eliminarUnit = FindUnitByOriginId(iOriginId, out errorMessage);

            //if (eliminarUnit == false)
            //{
            //    String originName = GetOriginName(iOriginId);
            //    String unitName = new amis._DataLayer.GeneratedCode.DcUnit().GetUnitNameByOriginId(iOriginId);

            //    errorMessage = "No fue posible eliminar el origen " + originName +
            //        ", pues tiene asociadas marcas, como por ejemplo: " + "'" + unitName + "'" +
            //        ". Para poder eliminar un origen, debe eliminar primero todas sus marcas.";
            //    return CommonEnums.DeletedRecordStates.NotDeleted;

            //}


            CommonEnums.DeletedRecordStates wasDeleted = new DcOrigin().DeleteOrigin(iOriginId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El origen fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el origen con el ID '" + iOriginId.ToString() + ", por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El origen con el ID '" + iOriginId.ToString() 
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

        public List<String> GetCountry()
        {
            List<String> paises = new DcOrigin().GetCountry();

            return paises;

        }

        public int GetIdOrigin(String originName)
        {
            return new DcOrigin().GetIdOrigin(originName);
        }

        public String GetOriginName(int originId)
        {
            return new DcOrigin().GetOriginName(originId);
        }


        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcOrigin().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }
    }
}
