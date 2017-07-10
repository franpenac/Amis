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
using amis._BusinessLayer;
using System.Collections;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcManufacturer : ITsDropDownList
    {
        public void Copy(Manufacturer objSource, ref Manufacturer objDestination)
        {
            new DcManufacturer().Copy(objSource, ref objDestination);
        }

        public Manufacturer Save(Manufacturer objSource)
        {
            Manufacturer obj = new DcManufacturer().Save(objSource);
            return obj;
        }

        public bool ExistsManufacturer(int ManufacturerId, out string errorMessage)
        {
            bool exist = new DcManufacturer().ExistsManufacturer(ManufacturerId, out errorMessage);
            return exist;
        }

        public bool ExistsManufacturerName(string ManufacturerName, out string errorMessage)
        {
            bool exist = new DcManufacturer().ExistsManufacturerName(ManufacturerName, out errorMessage);
            return exist;
        }

        public List<Manufacturer> GetManufacturerList(out string errorMessage)
        {
            List<Manufacturer> list = new DcManufacturer().GetManufacturerList(out errorMessage);
            return list;
        }

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcManufacturer().GetComboList(out errorMessage);
            return list;
        }

        public bool ValidateManufacturerId(int ManufacturerId, out string errorMessage)
        {
            errorMessage = "";
            if (ManufacturerId == 0)
            {
                errorMessage = "El campo 'Id de fabricante' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public bool ValidateManufacturerName(string ManufacturerName, Label lblErrorLabel)
        {
            if (ManufacturerName.Replace(" ", "") == "")
            {
                return ControlRoutines.ShowErrorLabel(false, lblErrorLabel, "El campo 'Nombre fabricante' es un campo obligatorio y no puede estar vacío");
            }
            return ControlRoutines.ShowErrorLabel(true, lblErrorLabel, "");
        }

        public int GetNewManufacturerId()
        {
            return new DcManufacturer().GetNewManufacturerId();
        }

        public void CreateNewOrigin(WebTextEditor wteManufacturerId, WebTextEditor wteManufacturerName)
        {
            int newManufacturerId = new BcManufacturer().GetNewManufacturerId();
            wteManufacturerId.Text = newManufacturerId.ToString();
            wteManufacturerName.Text = "";
        }

        public CommonEnums.DeletedRecordStates DeleteManufacturer(string ManufacturerId, out string errorMessage)
        {
            int iManufacturerId = 0;
            if (!int.TryParse(ManufacturerId, out iManufacturerId))
            {
                errorMessage = "El ID de fabricante debe ser un entero válido.";
                return CommonEnums.DeletedRecordStates.NotDeleted;
            }
            

            CommonEnums.DeletedRecordStates wasDeleted = new DcManufacturer().DeleteManufacturer(iManufacturerId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El fabricante fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el fabricante con el ID '" + iManufacturerId.ToString() + ", por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "El fabricante con el ID '" + iManufacturerId.ToString()
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

        public List<String> GetManufacturer()
        {
            List<String> fabricantes = new DcManufacturer().GetManufacturer();

            return fabricantes;

        }

        public int GetIdManufacturer(String manufacturerName)
        {
            return new DcManufacturer().GetIdManufacturer(manufacturerName);
        }
        
        public String GetManufacturerName(int manufacturerId)
        {
            return new DcManufacturer().GetManufacturerName(manufacturerId);
        }

        public bool FindBrandByManufacturerId(int originId, out string errorMessage)
        {
            bool exist = new DcManufacturer().FindBrandByManufacturerId(originId, out errorMessage);
            return exist;

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