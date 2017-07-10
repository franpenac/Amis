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
    public class BcBrand : ITsDropDownList
    {
        public void Copy(Brand objSource, ref Brand objDestination)
        {
            new DcBrand().Copy(objSource, ref objDestination);
        }

        public Brand Save(Brand objSource, out string errorMessage)
        {
            Brand obj = new DcBrand().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "La marca '" + objSource.BrandName + "' fue guardada correctamente.";

            else if (errorMessage == "Manufacturer not found")
                errorMessage = "No fue posible guardar la marca '" + objSource.BrandName + "', pues el fabricante no fue encontrado en la Base de Datos.";

            else if (errorMessage == "Origin not found")
                errorMessage = "No fue posible guardar la marca '" + objSource.BrandName + "', pues la procedencia no fue encontrada en la Base de Datos.";

            else if (errorMessage == "Repeated brand name")
                errorMessage = "No fue posible guardar la marca '" + objSource.BrandName + "', pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar la marca, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool Validate(Brand brand, out string errorMessage)
        {
            if (!ValidateBrandName(brand.BrandName, out errorMessage)) return false;
            if (!new BcManufacturer().ValidateManufacturerId(int.Parse(brand.ManufacturerId.ToString()), out errorMessage)) return false;
            return true;
        }

        public bool ExistsBrand(int BrandId, out string errorMessage)
        {
            bool exist = new DcBrand().ExistsBrand(BrandId, out errorMessage);
            return exist;
        }

        public List<Brand> GetBrandList(out string errorMessage)
        {
            List<Brand> list = new DcBrand().GetBrandList(out errorMessage);
            return list;
        }

        public bool ValidateBrandName(string brandName, out string errorMessage)
        {
            errorMessage = "";
            if (brandName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre marca' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public bool ValidateBrandId(int brandId, out string errorMessage)
        {
            errorMessage = "";
            if (brandId == 0)
            {
                errorMessage = "El campo 'Id de marca' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteBrand(int brandId, string brandName, out string errorMessage)
        {
            //AssetModel model = FindAssetsModelByBrandId(brandId, out errorMessage);
            //if (model != null)
            //{
            //    errorMessage = "No fue posible eliminar la marca " + brandName +
            //        ", pues tiene asociados modelos, como por ejemplo: " + "'" + model.AssetModelName + "'" +
            //        ". Para poder eliminar una marca, debe eliminar primero todos sus modelos.";
            //    return CommonEnums.DeletedRecordStates.NotDeleted;
            //}

            CommonEnums.DeletedRecordStates wasDeleted = new DcBrand().DeleteBrand(brandId, out errorMessage);
            if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "La marca fue eliminado correctamente.";
                return CommonEnums.DeletedRecordStates.DeletedOk;
            }
            else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró la marca '" + brandName + "', por lo cual no pudo ser eliminado.";
                return CommonEnums.DeletedRecordStates.NotFound;
            }
            errorMessage = "La marca '" + brandName
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
            List<TsDropDownItem> list = new DcBrand().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcBrand().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcBrand().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListExistModel(out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new DcBrand().GetComboListExistModel(out errorMessage);
            return List;

        }

        public Brand GetBrandById(int brandId, out string errorMessage)
        {
            return new DcBrand().GetBrandById(brandId, out errorMessage);
        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboListExistModelTyre(out string errorMessage)
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> List =
                new DcBrand().GetComboListExistModelTyre(out errorMessage);
            return List;

        }
    }

}