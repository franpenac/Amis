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
    public class BcAsset : ITsDropDownList
    {
        public void Copy(Asset objSource, ref Asset objDestination)
        {
            new DcAsset().Copy(objSource, ref objDestination);
        }

        public Asset Save(Asset objSource, out string errorMessage)
        {
            Asset obj = new DcAsset().Save(objSource, out errorMessage);
            if (obj != null)
                errorMessage = "El activo fue guardado correctamente.";

            else if (errorMessage == "Repeated Asset name")
                errorMessage = "No fue posible guardar el activo, pues ya existe en la Base de Datos.";

            else
                errorMessage = "No fue posible guardar el activo, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
            return obj;
        }

        public bool ExistsAsset(int AssetId, out string errorMessage)
        {
            bool exist = new DcAsset().ExistsAsset(AssetId, out errorMessage);
            return exist;
        }

        public List<Asset> GetAssetList(out string errorMessage)
        {
            List<Asset> list = new DcAsset().GetAssetList(out errorMessage);
            return list;
        }

        public bool ValidateAssetId(int AssetId, out string errorMessage)
        {
            errorMessage = "";
            if (AssetId == 0)
            {
                errorMessage = "El campo 'Id de activo' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public CommonEnums.DeletedRecordStates DeleteAsset(int AssetId, out string errorMessage)
        {
			
			Unit objUnit = new Unit();
			if(! new DcUnit().HasAsset(AssetId,ref objUnit))
			{
				AssetEvent objEvent = new AssetEvent();
				if(! new DcAssetEvent().HasAsset(AssetId,ref objEvent))
				{
					DispatchDocumentItem objDisp = new DispatchDocumentItem();
					if(! new DcDispatchDocumentItem().HasAsset(AssetId,ref objDisp))
					{
						ReceptionDocumentItem objRecep = new ReceptionDocumentItem();
						if(! new DcReceptionDocumentItem().HasAsset(AssetId,ref objRecep))
						{
							TagAssigned objTag = new TagAssigned();
							if(! new DcTagAssigned().HasAsset(AssetId,ref objTag))
							{
								UnitAsset objUnitA = new UnitAsset();
								if(! new DcUnitAsset().HasAsset(AssetId,ref objUnitA))
								{
									CommonEnums.DeletedRecordStates wasDeleted = new DcAsset().DeleteAsset(AssetId, out errorMessage);
									if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
									{
										errorMessage = "El activo fue eliminado correctamente.";
										return CommonEnums.DeletedRecordStates.DeletedOk;
									}
									else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
									{
										errorMessage = "No se encontró el activo, por lo cual no pudo ser eliminado.";
										return CommonEnums.DeletedRecordStates.NotFound;
									}
								}
								else
								{
                                    errorMessage = "El activo unidad no pudo ser eliminado, debido a que tiene una asignacion a unidad asociados a el.";
									return CommonEnums.DeletedRecordStates.NotDeleted;
								}
							}
							else
							{
                                errorMessage = "El activo unidad no pudo ser eliminado, debido a que tiene un tag asociados a el.";
								return CommonEnums.DeletedRecordStates.NotDeleted;
							}
						}
						else
						{
                            errorMessage = "El activo unidad no pudo ser eliminado, debido a que tiene registros asociados a el.";
							return CommonEnums.DeletedRecordStates.NotDeleted;
						}
					}
					else
					{
                        errorMessage = "El activo unidad no pudo ser eliminado, debido a que tiene registros asociados a el.";
						return CommonEnums.DeletedRecordStates.NotDeleted;
					}
				}
				else
				{
                    errorMessage = "El activo unidad no pudo ser eliminado, debido a que tiene eventos asociados a el.";
					return CommonEnums.DeletedRecordStates.NotDeleted;
				}
			}
			else
			{
				errorMessage = "El activo unidad no pudo ser eliminado, debido a que tiene unidades asociados a el, "+
				"como por ejemplo la unidad con patente: '";
				return CommonEnums.DeletedRecordStates.NotDeleted;
			}
			
            errorMessage = "El activo no pudo ser eliminado. Comuníquese con el Administrador del Sistema. "
                + "El Servidor entregó el siguiente mensaje: " + errorMessage;
            return CommonEnums.DeletedRecordStates.NotDeleted;
        }

        public void ExportWebDataGridToExcel(WebExcelExporter webExcelExporter, WebDataGrid webDataGrid)
        {
            webExcelExporter.DataExportMode = Infragistics.Web.UI.GridControls.DataExportMode.AllDataInDataSource;
            webExcelExporter.DownloadName = "amis_exported_file.xlsx";
            webExcelExporter.Export(webDataGrid);
        }

        public Asset GetAssetById(int id, out string errorMessage)
        {
            errorMessage = "";
            return new DcAsset().GetAssetById(id,out errorMessage);
        }
        // Implementacion de las interfaces

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcAsset().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcAsset().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public bool ChangeFacility(int assetId, int facilityId)
        {
          bool ok =  new DcAsset().ChangeFacility(assetId, facilityId);
            if (ok)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public Asset GetAssetByUnitRegisterId(int unitRegisterId, out string errorMessage)
        {
            return new DcAsset().GetAssetByUnitRegisterId(unitRegisterId, out errorMessage);
        }

        public Asset GetAssetByTag(string tagCode, out string errorMessage)
        {
            return new DcAsset().GetAssetByTag(tagCode, out errorMessage);
        }
    }

}