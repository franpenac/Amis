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
using System.Text.RegularExpressions;

namespace amis._BusinessLayer.GeneratedCode
{
    public class BcMember : ITsDropDownList
    {
        public void Copy(Member objSource, ref Member objDestination)
        {
            new DcMember().Copy(objSource, ref objDestination);
        }

        public Member Save(Member objSource, out string errorMessage)
        {
            if (ValidateMemberId(objSource.MemberId,out errorMessage))
            {
                if (Validate(objSource, out errorMessage))
                {
                    Member obj = new DcMember().Save(objSource, out errorMessage);
                    if (obj != null) { 
                        errorMessage = "El integrante '" + objSource.MemberName + "' fue guardado correctamente.";
                    new BcAmisUser().ChangeAmisUserFromMember(objSource.MemberId, objSource.MemberName, objSource.MemberEmail);
                    }
                    else
                        errorMessage = "No fue posible guardar el integrante, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (new DcMember().ValidateExistRut(objSource.MemberRut))
                {
                    errorMessage = "Ya existe un usuario con este rut.";
                    return null;
                }
                if (new DcMember().ValidateExistMail(objSource.MemberEmail))
                {
                    errorMessage = "Ya existe un usuario con este mail.";
                    return null;
                }
                if (Validate(objSource, out errorMessage))
                {
                    Member obj = new DcMember().Save(objSource, out errorMessage);
                    if (obj != null)
                        errorMessage = "El integrante '" + objSource.MemberName + "' fue guardado correctamente.";

                    else
                        errorMessage = "No fue posible guardar el integrante, por favor informe al Administrador del Sistema. El Servidor entregó el siguiente mensaje: " + errorMessage;
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            
           
        }

        public bool Validate(Member member, out string errorMessage)
        {
            if (!ValidateName(member.MemberName, out errorMessage)) return false;
            if (!ValidateRut(member.MemberRut, out errorMessage)) return false;
            if (!ValidateEmail(member.MemberEmail, out errorMessage)) return false;
            if (!new BcMemberType().ValidateMemberTypeId(member.MemberTypeId, out errorMessage)) return false;
            return true;
        }

        public bool ExistsMember(int MemberId, out string errorMessage)
        {
            bool exist = new DcMember().ExistsMember(MemberId, out errorMessage);
            return exist;
        }

        public List<Member> GetMemberList(out string errorMessage)
        {
            List<Member> list = new DcMember().GetMemberList(out errorMessage);
            return list;
        }

        public bool ValidateMemberId(int MemberId, out string errorMessage)
        {
            errorMessage = "";
            if (MemberId == 0)
            {
                errorMessage = "El campo 'Id de integrante' es un campo obligatorio y no puede estar vacío.";
                return false;
            }
            return true;
        }

        public bool ValidateName(string memberName, out string errorMessage)
        {
            
            if (memberName == "")
            {
                errorMessage = "El campo \" Nombre\" no puede quedar vacío, por favor digite el nombre del integrante.";
                return false;
            }

            if (memberName.Length>255)
            {
                errorMessage = "El nombre ingresado, ha excedido la cantidad máxima de caracteres permitido.";
                return false;
            }
            errorMessage = "";

            return true;
        
        }

        public bool ValidateEmail(string email, out string errorMessage)
        {
            errorMessage = "";

            if (email == "")
            {
                errorMessage = "El campo \" Email\" no puede quedar vacío, por favor digite el nombre del integrante.";
                return false;
            }

            if (email.Length > 100)
            {
                errorMessage = "El email ingresado, ha excedido la cantidad máxima de caracteres permitido.";
                return false;
            }

            

            String sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, sFormato))
            {
                if (Regex.Replace(email, sFormato, String.Empty).Length != 0)
                {
                    errorMessage = "El formato de email es incorrecto.";
                    return false;
                }
            }
            else
            {
                errorMessage = "El formato de email es incorrecto.";
                return false;
            }

            return true;
        }

        public bool ValidateRut(string rut, out string errorMessage)
        {
            int comas = 0;
            int guion = 0;
            for (int i = 0; i < rut.Length; i++)
            {
                if (rut.Substring(i,1) ==".")
                {
                    comas++;
                }
                if (rut.Substring(i, 1) == "-")
                {
                    guion++;
                }
            }

            if (comas!=2 || guion!=1)
            {
                errorMessage = "El rut digitado no cumple con el formato de escrita, por favor, ver la referencia al lado derecho";
                return false;
            }

            if (rut == "")
            {
                errorMessage = "El campo \" Rut\" no puede quedar vacío, por favor digite el nombre del integrante.";
                return false;
            }

            if (rut.Length > 50)
            {
                errorMessage = "El campo rut, ha excedido la cantidad máxima de caracteres permitido.";
                return false;
            }

            rut = rut.ToUpper();
            rut = rut.Replace(".", "");
            rut = rut.Replace("-", "");
            int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

            char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

            int m = 0, s = 1;
            for (; rutAux != 0; rutAux /= 10)
            {
                s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
            }
            if (dv == (char)(s != 0 ? s + 47 : 75))
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = "El rut digitado no es válido, por favor digite un rut valido";
                return false;

            }
        }

        public int GetNewMemberId()
        {
            return new DcMember().GetNewMemberId();
        }

        public void CreateNewMember(WebTextEditor wteOMemberId, WebTextEditor wteMemberName)
        {
            int newMemberId = new BcMember().GetNewMemberId();
            wteOMemberId.Text = newMemberId.ToString();
            wteMemberName.Text = "";
        }

        public CommonEnums.DeletedRecordStates DeleteMember(int memberId, string memberName, out string errorMessage)
        {
            MemberBranchOffice obj = new MemberBranchOffice();

            if (! new DcMemberBranchOffice().HasMember(memberId,ref obj))
            {
				
				AssetEvent objEvent = new AssetEvent();
				if(! new DcAssetEvent().HasMember(memberId, ref objEvent))
				{
                    if (new DcDispatchProviderDocument().HasMember(memberId))
                    {
                        CommonEnums.DeletedRecordStates wasDeleted = new DcMember().DeleteMember(memberId, out errorMessage);
                        if (wasDeleted == CommonEnums.DeletedRecordStates.DeletedOk)
                        {
                            errorMessage = "El integrante fue eliminado correctamente.";
                            return CommonEnums.DeletedRecordStates.DeletedOk;
                        }
                        else if (wasDeleted == CommonEnums.DeletedRecordStates.NotFound)
                        {
                            errorMessage = "No se encontró el integrante '" + memberName + "', por lo cual no pudo ser eliminado.";
                            return CommonEnums.DeletedRecordStates.NotFound;
                        }
                    }
                    else
                    {
                        errorMessage = "El miembro '" + memberName
                        + " no pudo ser eliminado, debido a que tiene guías de proveedor asociados a él.";
                        return CommonEnums.DeletedRecordStates.NotDeleted;
                    }
				
				}
				else
				{
					errorMessage ="El miembro '" + memberName
                        + " no pudo ser eliminado, debido a que tiene eventos asociados a él.";
						return CommonEnums.DeletedRecordStates.NotDeleted;
				}
					 
            }
            else
            {
                errorMessage = "El miembro '" + memberName
                        + " no pudo ser eliminado, debido a que tiene sucursales asociados a él.";
                return CommonEnums.DeletedRecordStates.NotDeleted;
            }
            
            errorMessage = "Él integrante '" + memberName
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

        public String GetMemberName(int brandId)
        {
            return new DcMember().GetMemberName(brandId);
        }

        // Implementacion de las interfaces

        List<TsDropDownItem> ITsDropDownList.GetComboList(out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcMember().GetComboList(out errorMessage);
            return list;
        }

        IEnumerable<object> ITsDropDownList.GetTableList(out string errorMessage)
        {
            IEnumerable<object> list = new DcMember().GetTableList(out errorMessage);
            return list;
        }

        public IEnumerable<object> GetTableList2(out string errorMessage)
        {
            IEnumerable<object> list = new DcMember().GetTableList(out errorMessage);
            return list;
        }

        public List<TsDropDownItem> GetComboListByFiltrer(int id, out string errorMessage)
        {
            errorMessage = "";
            List<TsDropDownItem> list = new DcMember().GetComboListByTipeId(id, out errorMessage);
            return list;
        }

        public Member GetMemberById(int memberId, out string errorMessage)
        {
            Member obj = new DcMember().GetMemberById(memberId, out errorMessage);
            return obj;
        }
        public List<ListItem> GetProviderList(out string errorMessage)
        {
            return new DcMember().GetProviderList(out errorMessage);
        }

        public List<Infragistics.Web.UI.ListControls.DropDownItem> GetComboProvider()
        {
            List<Infragistics.Web.UI.ListControls.DropDownItem> list = new List<Infragistics.Web.UI.ListControls.DropDownItem>();

            List<Member> members = new DcModelPurchaseReport().GetComboEnterprise();

            Infragistics.Web.UI.ListControls.DropDownItem Default = new Infragistics.Web.UI.ListControls.DropDownItem();
            Default.Text = "";
            Default.Value = "0";
            list.Add(Default);

            foreach (Member m in members)
            {
                Infragistics.Web.UI.ListControls.DropDownItem item = new Infragistics.Web.UI.ListControls.DropDownItem();

                item.Text = m.MemberName;
                item.Value = m.MemberId.ToString();

                list.Add(item);
            }
            return list;
        }
    }

}