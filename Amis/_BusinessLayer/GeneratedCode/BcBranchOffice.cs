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
using System.Web;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcBranchOffice : ITsDropDownList
    {
        public void Copy(BranchOffice objSource, ref BranchOffice objDestination)
        {
            new DcBranchOffice().Copy(objSource, ref objDestination);
        }

        public BranchOffice Save(BranchOffice objSource,int LocationId ,out string errorMessage)
        {
            errorMessage = "";
            if (Validate(objSource,out errorMessage))
            {
                BranchOffice obj = new DcBranchOffice().Save(objSource, LocationId, out errorMessage);
                if (obj != null)
                    errorMessage = "La sucursal '" + objSource.BranchOfficeName + "' fue guardada correctamente.";

                else
                    errorMessage = "No fue posible guardar la sucursal, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
                return obj;
            }

            return null;
            
            
        }

        public bool Validate(BranchOffice branchOffice, out string errorMessage)
        {
            errorMessage = "";
            if (branchOffice.BranchOfficeId == 0)
            {
                if (!ValidateBranchOfficeName(branchOffice.BranchOfficeName, out errorMessage)) return false;
                return true;
            }
            else
            {
                return true;
            }
            
        }

        public bool ExistsBranchOffice(int BranchOfficeId, out string errorMessage)
        {
            bool exist = new DcBranchOffice().ExistsBranchOffice(BranchOfficeId, out errorMessage);
            return exist;
        }

        public List<BranchOffice> GetBranchOfficeList(out string errorMessage)
        {
            List<BranchOffice> list = new DcBranchOffice().GetBranchOfficeList(out errorMessage);
            return list;
        }

        public bool ValidateBranchOfficeId(int BranchOfficeId, out string errorMessage)
        {
            errorMessage = "";
            if (BranchOfficeId == 0)
            {
                errorMessage = "El campo 'Id de integrante' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateBranchOfficeName(string branchOfficeName, out string errorMessage)
        {
            errorMessage = "";
            if (branchOfficeName.Replace(" ", "") == "")
            {
                errorMessage = "El campo 'Nombre sucursal' es un campo obligatorio y no puede estar vacío";
                return false;
            }
            if (!new DcBranchOffice().ValidateBranchOfficeName(branchOfficeName))
            {
                errorMessage = "Ya existe una sucursal con el nombre '"+branchOfficeName+"'.";
                return false;
            }
            return true;
        }

        public int GetNewBranchOfficeId()
        {
            return new DcBranchOffice().GetNewBranchOfficeId();
        }

        public void CreateNewBranchOffice(WebTextEditor wteOBranchOfficeId, WebTextEditor wteBranchOfficeName)
        {
            int newBranchOfficeId = new BcBranchOffice().GetNewBranchOfficeId();
            wteOBranchOfficeId.Text = newBranchOfficeId.ToString();
            wteBranchOfficeName.Text = "";
        }

        public CommonEnums.DeletedRecordStates DeleteBranchOffice(int branchOfficeId, string branchOfficeName, out string errorMessage)
        {
            MemberBranchOffice obj = new MemberBranchOffice();
            string name = "";
            if (new DcMemberBranchOffice().HasBranchOffice(branchOfficeId,ref obj, out name))
            {
                Warehouse obj2 = new Warehouse();
                if (new DcWarehouse().HasBranchOffice(branchOfficeId,ref obj2))
                {
                    CommonEnums.DeletedRecordStates wasDeleted = new DcBranchOffice().DeleteBranchOffice(branchOfficeId, out errorMessage);

                    if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
                    {
                        errorMessage = "La sucursal fue eliminada correctamente.";
                        return CommonEnums.DeletedRecordStates.DeletedOk;
                    }
                    else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
                    {
                        errorMessage = "No se encontró la sucursal '" + branchOfficeName + "', por lo cual no pudo ser eliminado.";
                        return CommonEnums.DeletedRecordStates.NotFound;
                    }
                    errorMessage = "La sucursal '" + branchOfficeName
                        + " no pudo ser eliminado. Comuníquese con el Administrador del Sistema. "
                        + "El Servidor entregó el siguiente mensaje: " + errorMessage;
                    return CommonEnums.DeletedRecordStates.NotDeleted;
                }
                else
                {
                    errorMessage = "La sucursal '" + branchOfficeName
                        + "' no pudo ser eliminada, debido a que tiene bodegas asociados a ella, como por ejemplo: '"
                        + obj2.WarehouseName + "'.";
                    return CommonEnums.DeletedRecordStates.NotDeleted;
                }

            }
            else
            {
                errorMessage = "La sucursal '" + branchOfficeName
                    + "' no pudo ser eliminada, debido a que tiene integrantes asociados a ella, Por ejemplo el integrante: "+name;
                return CommonEnums.DeletedRecordStates.NotDeleted;
            }
    
        }


        // Implementacion de las interfaces

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcBranchOffice().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcBranchOffice().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcBranchOffice().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            throw new NotImplementedException();
        }

        public BranchOffice GetBranchOfficeById(int branchOfficeId, out string errorMessage)
        {
            return new DcBranchOffice().GetBranchOfficeById(branchOfficeId, out errorMessage);
        }
        // Metodos para eliminar
    }

}