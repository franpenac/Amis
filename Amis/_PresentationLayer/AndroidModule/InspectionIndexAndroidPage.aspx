<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="InspectionIndexAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.InspectionIndexAndroidPage" %>


<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/AmisAndroid.css" />
    <style type="text/css">
        .CssTextBox {
        }

        .buttonLogin {
            margin-left: 0px;
        }
        .auto-style1 {
            width: 100%;
        }
        .btnInv
        {
            opacity: 0;
            width:1px;
        }
        .Opacity
        {
            opacity:0;
        }
    </style>
    <script type="text/javascript">

        function getControl(controlName) {
            return document.getElementById(controlName);
        }

        function ReadTag(id)
        {
            if (id == 'btnReadRfidTag') {
                var button = getControl('btnReadRfidTag');
                button.disabled = true;
            } else if (id == 'btnReadRfiTag2') {
                var button = getControl('btnReadRfiTag2');
                button.disabled = true;
            }

            if (id == 'btnReadRfiTag'){
            AndroidInterface.androidRFIDTurnOn(true);
            getControl('txbTagUnit').value = '';
            var value = AndroidInterface.androidFindTagStrongSound();
            getControl('txbTagUnit').value = value;
            var button = getControl('btnSearch');
            button.click();
            }
            if (id == 'btnReadRfiTag2')
            {
                AndroidInterface.androidRFIDTurnOn(true);
                getControl('txbAsset').value = '';
                var value = AndroidInterface.androidFindTagStrongSound();
                getControl('txbAsset').value = value;
                var button = getControl('btnProcess');
                button.click();
            }
        }
    </script>
</head>
<body style="border:solid">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 100%; border:solid" border="1">
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblTittle" runat="server" Width="100%" Text="Inspección" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 30%; align-content: center; text-align: center">
                         <input type="button" value='Leer tag' runat="server" id="btnReadRfiTag" onclick='ReadTag(id);' style="width:100%"/>
                            
                        </td>
                        
                        <td style="width: 30%">
                            <asp:TextBox ID="txbTagUnit" runat="server" Visible="true" CssClass="btnInv"></asp:TextBox>
                            <asp:TextBox ID="txbAsset" runat="server" Text="" CssClass="btnInv" Enabled="false"></asp:TextBox>
                            <asp:Button ID="btnProcess" runat="server" CssClass="Opacity" Width="1%" OnClick="txbAsset_TextChanged" Text="Button" />
                        </td>
                        <td style="width: 30%">
                            <asp:Button ID="btnSearch" runat="server" ClientIDMode="Static" Text="Buscar" CssClass="btnInv" OnClick="btnSearch_Click"/>
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblPatent" runat="server" Width="100%"  Text="Patente"></asp:Label>
                            </td>
                        <td style="width: 20%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblInternalNumber" runat="server" Width="100%"  Text="N° interno"></asp:Label>
                            </td>
                        <td style="width: 10%"></td>
                    </tr>
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblPatentSelected" runat="server" Width="100%" Visible="False"></asp:Label>
                            </td>
                        <td style="width: 20%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblInternalNumberSelected" runat="server" Width="100%" Visible="False"></asp:Label>
                            </td>
                        <td style="width: 10%"></td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            &nbsp;</td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <div id="Asset" runat="server" visible="false">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 40%; text-align: right">
                            <asp:Label ID="lblAssetType" runat="server" Width="100%" Text="Tipo de activo"></asp:Label>
                            </td>
                        <td style="width: 30%; text-align: center">
                            <asp:DropDownList ID="ddlAssetType" Width="100%" runat="server" OnSelectedIndexChanged="ddlAssetType_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                </div>
                
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            &nbsp;</td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <div id="TyreSelected" runat="server" visible="false">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 40%; text-align: right">
                            <table style="width:100%">
                                <tr>
                                    <td>                            
                                        <asp:Button ID="btnInpection" runat="server" Text="Inspeccionar" Width="100%" OnClick="btnInpection_Click" />
                                    </td>
                                </tr>
                            </table>
                            </td>
                        <td style="width: 30%; text-align: left">
                            <asp:Image ID="imgAssetType" Width="30%" ImageUrl="~/ig_common/images/BlackTyre.png" runat="server" />

                            </td>
                        <td style="width: 10%"></td>
                    </tr>
                </table>
                </div>

                <div id="DivImage" runat="server" visible="false">
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 40%; text-align: right">
                            </td>
                        <td style="width: 40%; text-align: left">
                            <asp:Image ID="imgOtherAsset" Width="60px" Height="60px" runat="server" />

                            </td>
                        <td style="width: 10%"></td>
                    </tr>
                </table>
                </div>

                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                                                        
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <input type="button" value='Leer tag' runat="server" id="btnReadRfiTag2" onclick='ReadTag(id);' style="width:100%"/>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Button ID="btnCantReadTag" runat="server" OnClick="btnCantReadTag_Click" Text="No se puede leer tag de la unidad" Width="100%" />
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>               
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Button ID="btnWrongFacility" runat="server" OnClick="btnWrongFacility_Click" Text="TAG no corresponde a unidad" Width="100%" Enabled="false" />
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Volver" Width="100%" />
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                

            <asp:Button ID="btnConfirmar" style="display:none" runat="server"/>
            <cc1:ModalPopupExtender ID="mpeConfirmar" runat="server" 
                TargetControlID="btnConfirmar" CancelControlID="btnConfirmar" OkControlID="btnConfirmar"
                PopupControlID="panConfirmar">
            </cc1:ModalPopupExtender>
            <div id="panConfirmar" class="popupPanelClass" style="display:none; height:315px;">
                <div class="popupContainerClass">
                    <div id="popupHeaderConfirmar">
                        <div style="background-color: black;">
                        <asp:Table ID="Table3" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                            <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                    <div style="font-family: Arial; font-size: 20px">
                                        <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Amis">
                                        </asp:Label>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        </div>
                        <div style="background-color:lightgray">

                        <table id="Table4" style="Width:100%" runat="server" >
                            <tr>
                                <td style="width: 40%"></td>
                                <td style="width: 20%"></td>
                                <td style="width: 40%"></td>
                            </tr>
                        </table>

                        <table id="Table1" runat="server" style="Width:100%">
                            <tr>
                                <td style="width: 20%"></td>
                                <td style="width: 60%; text-align:center">
                                    <asp:Label ID="lblText" runat="server" Text="Digite el kilometraje actual del vehiculo. El ultimo kilometraje registrado fue de: "></asp:Label>
                                </td>
                                <td style="width: 20%"></td>
                            </tr>
                        </table>

                        <table id="Table2" runat="server" style="Width:100%">
                            <tr>
                                <td style="width: 20%"></td>
                                <td style="width: 60%">
                                    <asp:TextBox ID="txtObservation" runat="server" Width="100%"></asp:TextBox>
                                </td>
                                <td style="width: 20%"></td>
                            </tr>
                        </table>
                            <table>
                                <tr>
                                    <td></td>
                                </tr>
                            </table>
                        <table id="Table6" runat="server" style="Width:100%">
                            <tr>
                                <td style="width: 20%"></td>
                                <td style="width: 60%; text-align:center">
                                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                                <td style="width:20%"></td>
                            </tr>
                        </table>
                            <table>
                                <tr>
                                    <td></td>
                                </tr>
                            </table>

                        <table id="Table5" runat="server" style="Width:100%" >
                            <tr>
                                <td style="width: 10%"></td>
                                <td style="width: 30%">
                                    <asp:Button ID="btnConfirmarPoppup" runat="server" Text="Confirmar" Width="100%" Height="20px" OnClick="btnConfirmarPoppup_Click" />
                                </td>
                                <td style="width: 20%"></td>
                                <td style="width: 30%">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancelar" Width="100%" Height="20px" OnClick="btnCancel_Click" />
                                </td>
                                <td style="width: 10%"></td>
                            </tr>
                        </table>
                            <table>
                                <tr>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>


            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
