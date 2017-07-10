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
    public class BcUnitRegister : ITsDropDownList
    {
        public void Copy(UnitRegister objSource, ref UnitRegister objDestination)
        {
            new DcUnitRegister().Copy(objSource, ref objDestination);
        }

        public UnitRegister Save(UnitRegister objSource, out string errorMessage)
        {
            UnitRegister obj = new DcUnitRegister().Save(objSource, out errorMessage);
            if (obj != null) errorMessage = "La unidad de patente '" + objSource.PatentNumber + "' fue guardada correctamente.";
            return obj;
        }

        public bool Validate(UnitRegister unitRegister, out string errorMessage)
        {
            if (!ValidateUnitTypeId(unitRegister.UnitTypeId, out errorMessage)) return false;
            if (!ValidatePatentNumber(unitRegister.PatentNumber, unitRegister.UnitRegisterId, out errorMessage)) return false;
            //UnitName
            if (!ValidateConfigurationUnitTypeId(unitRegister.UnitTypeConfigurationId, out errorMessage)) return false;
            if (!ValidateInternalNumber(unitRegister.InternalNumber, out errorMessage)) return false;
            if (!ValidateSuspensionTypeId(unitRegister.SuspensionTypeId, out errorMessage)) return false;
            //kilometersOfTravel
            if (!ValidateUnitTara(unitRegister.UnitTara, out errorMessage)) return false;
            if (!ValidateVin(unitRegister.Vin, out errorMessage)) return false;
            if (!ValidateNewOrUsed(unitRegister.NewOrUsed, out errorMessage)) return false;
            if (!ValidateUnitManufacturingYear(unitRegister.UnitManufacturingYear, out errorMessage)) return false;
            //UnitPurchaseDate
            if (!ValidateUnitOwnerMemberId(unitRegister.UnitOwnerMemberId, out errorMessage)) return false;

            return true;
        }

        public bool ValidateUnitTypeId(int unitTypeId, out string errorMessage)
        {
            errorMessage = "";
            if (unitTypeId == 0)
            {
                errorMessage = "El campo 'Tipo de unidad' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public bool ValidateConfigurationUnitTypeId(int configurationUnitTypeId, out string errorMessage)
        {
            errorMessage = "";
            if (configurationUnitTypeId == 0)
            {
                errorMessage = "El campo 'Configuración' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public bool ValidateSuspensionTypeId(int suspensionTypeId, out string errorMessage)
        {
            errorMessage = "";
            if (suspensionTypeId == 0)
            {
                errorMessage = "El campo 'Tipo de suspensión' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public bool ValidateUnitOwnerMemberId(int unitOwnerMemberId, out string errorMessage)
        {
            errorMessage = "";
            if (unitOwnerMemberId == 0)
            {
                errorMessage = "El campo 'Dueño de la unidad' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public bool ValidatePatentNumber(string patentNumber, int currenUnitRegisterId, out string errorMessage)
        {
            errorMessage = "";
            patentNumber = patentNumber.Trim();
            if (patentNumber == "")
            {
                errorMessage = "El campo 'Patente' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            else
            {
                if (patentNumber.Length != 8)
                {
                    errorMessage = "La patente tiene un formato no válido. La patente debe estar compuesta por 3 valores de 2 caracteres, separados por un guión, por ejemplo: BR-JT-56";
                    return false;
                }
                string part1 = patentNumber.Substring(0, 2);
                string part2 = patentNumber.Substring(2, 1);
                string part3 = patentNumber.Substring(3, 2);
                string part4 = patentNumber.Substring(5, 1);
                string part5 = patentNumber.Substring(6, 2);
                if (part2 != "-" || part4 != "-")
                {
                    errorMessage = "La patente tiene un formato no válido, pues los valores no están separados por un guión. La patente debe estar compuesta por 3 valores de 2 caracteres, separados por un guión, por ejemplo: BR-JT-56";
                    return false;
                }
                if (part1.Length != 2 || part3.Length != 2 || part5.Length != 2)
                {
                    errorMessage = "La patente tiene un formato no válido. La patente debe estar compuesta por 3 valores de 2 caracteres, separados por un guión, por ejemplo: BR-JT-56";
                    return false;
                }
                if (!new DcUnitRegister().ValidateRepeatedPatentNumber(patentNumber, currenUnitRegisterId, out errorMessage))
                {
                    errorMessage = "La patente '" + patentNumber + "' ya está asignada a otra unidad.";
                    return false;
                }
                //int number = -1;
                //if (!int.TryParse(part5, out number))
                //{
                //    errorMessage = "La patente tiene un formato no válido. La patente debe estar terminar con un número.";
                //    return false;
                //}
            }
            return true;
        }

        public bool ValidateUnitManufacturingYear(int unitManufacturingYear, out string errorMessage)
        {
            errorMessage = "";
            if (unitManufacturingYear == 0)
            {
                errorMessage = "El campo 'Año de fabricación' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public bool ValidateNewOrUsed(string newOrUsed, out string errorMessage)
        {
            errorMessage = "";
            if (newOrUsed != "N" && newOrUsed != "U")
            {
                errorMessage = "El campo 'Nuevo o usado' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public bool ValidateUnitTara(decimal unitTara, out string errorMessage)
        {
            errorMessage = "";
            if (unitTara == 0)
            {
                errorMessage = "El campo 'Kg Tara' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public bool ValidateVin(string vin, out string errorMessage)
        {
            errorMessage = "";
            if (vin == "")
            {
                errorMessage = "El campo 'Vin' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
        }

        public bool ValidateInternalNumber(string internalNumber, out string errorMessage)
        {
            errorMessage = "";
            if (internalNumber == "")
            {
                errorMessage = "El campo 'Número interno' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            return true;
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
            List<TsDropDownItem> list = new DcUnitRegister().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcUnitRegister().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcUnitRegister().GetTableList(out errorMessage);
            return list;
        }

        public List<UnitRegisterTableRow> GetUnitRegisterTable(out string errorMessage)
        {
            List<UnitRegisterTableRow> list = new DcUnitRegister().GetUnitRegisterTable(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            List<TsDropDownItem> list = new DcUnitRegister().GetComboListByFiltrer(id, out errorMessage);
            return list;
        }

        public CommonEnums.DeletedRecordStates DeleteUnitRegister(int unitRegisterId, string patentNumber, out string errorMessage)
        {
            if (new DcUnitRegister().HasUnit(unitRegisterId, out errorMessage))
            {
                errorMessage = "El registro de unidad con la patente '" + patentNumber
                                + "' no pudo ser eliminado, debido a que ya ha sido creado como un activo.";
                return CommonEnums.DeletedRecordStates.NotDeleted;
            }

            CommonEnums.DeletedRecordStates deleteState = new DcUnitRegister().DeleteUnitRegister(unitRegisterId, out errorMessage);

            if (deleteState == CommonEnums.DeletedRecordStates.DeletedOk)
            {
                errorMessage = "El registro de unidad con la patente '" + patentNumber + "' fue eliminado correctamente.";
            }
            else if (deleteState == CommonEnums.DeletedRecordStates.NotDeleted)
            {
                errorMessage = "El registro de unidad no pudo ser eliminado. Comuníquese con el Administrador del Sistema. "
                    + "El Servidor entregó el siguiente mensaje: " + errorMessage;
            }
            else if (deleteState == CommonEnums.DeletedRecordStates.NotFound)
            {
                errorMessage = "No se encontró el registro de unidad con la patente '" + patentNumber + "', por lo cual no pudo ser eliminado.";
            }

            return deleteState;
        }

        public UnitRegister GetUnitRegisterById(int unitRegisterId, out string errorMessage)
        {
            UnitRegister obj = new DcUnitRegister().GetUnitRegisterById(unitRegisterId, out errorMessage);
            return obj;
        }

        public UnitRegister GetUnitRegisterByPatentNumber(string patentNumber, out string errorMessage)
        {
            UnitRegister obj = new DcUnitRegister().GetUnitRegisterByPatentNumber(patentNumber, out errorMessage);
            return obj;
        }

        public bool IsTagCorrect(int assetPosition, string tagRead, int unitId, out int errorNumber)
        {
            string errorMessage = "";
            errorNumber = 0;
            Tag tag = new DcInspectionAndroid().SearchTag(tagRead);
            {
                if (tag != null)
                {
                    TagAssigned assigned = new DcInspectionAndroid().SearchAssigned(tag.TagId);
                    Asset asset = new BcAsset().GetAssetById(assigned.AssetId, out errorMessage);
                    UnitAsset unitAsset = new BcUnitAsset().GetActiveUnitAsset(asset.AssetId);
                    if (unitAsset != null)
                    {
                        if (assigned != null)
                        {
                            AssetUniqueIdentification assetUniq = new BcAssetUniqueIdentification().GetAssetUniqueIdentificationById(asset.AssetUniqueIdentificationId);
                            string type = new BcAssetType().GetAssetTypeNameById(assetUniq.AssetTypeId);
                            if (type == "Neumático")
                            {
                                if (asset.IsGood != "N")
                                {
                                    bool next = new DcInspectionAndroid().SearchAssetAssigned(assigned.AssetId, unitId);
                                    if (next)
                                    {
                                        Tag Tag = new BcTag().GetTagByCodeTag(tagRead, out errorMessage);

                                        TagAssigned tagAssigned = new BcTagAssigned().GetAssignedByTag(Tag.TagId, out errorMessage);

                                        Asset assetObj = new BcAsset().GetAssetById(tagAssigned.AssetId, out errorMessage);

                                        List<UnitAsset> unitAssetList = new BcUnitAsset().GetListUnitAssetByAssetId(assetObj.AssetId);

                                        foreach (UnitAsset item in unitAssetList)
                                        {
                                            if (item.AssetPositionId == assetPosition)
                                            {
                                                errorNumber = 0;
                                                return true;
                                            }
                                            else
                                            {
                                                errorNumber = 8;
                                                return false;
                                            }
                                        }
                                        return true;
                                    }
                                    else
                                    {
                                        errorNumber = 5;
                                        return false;
                                    }
                                }
                                else
                                {
                                    errorNumber = 9;
                                    return false;
                                }
                            }else
                            {
                                errorNumber = 11;
                                return false;
                            }                 

                        }
                        else
                        {
                            errorNumber = 2;
                            return false;
                        }
                    }
                    else
                    {
                        errorNumber = 5;
                        return false;
                    }
                }
                else
                {
                    errorNumber = 1;
                    return false;
                }
            }
        }

        public UnitRegister GetUnitRegisterByPatentNumberOrInternalNumber(string patentNumber, string internalNumber, out string errorMessage)
        {
            UnitRegister obj = new DcUnitRegister().GetUnitRegisterByPatentNumberOrInternalNumber(patentNumber, internalNumber, out errorMessage);
            if (obj != null)
            {
                errorMessage = "";
                return obj;
            }
            else
            {
                errorMessage = "No se encontró la unidad de destino.";
                return null;
            }
        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetInternalNumberList()
        {
            return new DcUnitRegister().GetInternalNumberList();
        }
    }
}