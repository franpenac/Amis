<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryIndexAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.InventoryIndexAndroidPage" %>

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
        .Opacity
        {
            opacity:0;
        }
    </style>
    <script type="text/javascript" id="igClientScript">
        function getControl(controlName) {
            return document.getElementById(controlName);
        }

        function ReadTag() {
            AndroidInterface.androidRFIDTurnOn(true);
            getControl('txbTagUnit').value = '';
            var value = AndroidInterface.androidFindTagStrongSound();
            getControl('txbTagUnit').value = value;
            var button = getControl('btnSearch');
            button.click();
        }
    </script>
</head>
<body >
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <table style="width: 100%; border:solid" border="1">
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblTittle" runat="server" Width="100%" Text="Inventario" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 30%; align-content: center; text-align: center">
                            <asp:Label ID="lblInstruction" runat="server" Width="100%" Text="Lea TAG unidad"></asp:Label>
                        </td>
                        <td style="width: 30%">
                            <asp:TextBox ID="txbTagUnit" runat="server" Text="Unidad Tag" CssClass="Opacity" ></asp:TextBox>
                        </td>
                        <td style="width: 30%">
                            <asp:Button ID="btnSearch" runat="server" Text="Buscar" ClientIDMode="Static" CssClass="Opacity"  OnClick="btnSearch_Click"/>
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
      <br />
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <input type="button" value='Leer' style="width:100%" id="btnReadRfiTag" onclick='ReadTag();'/>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Button ID="btnCantReadTag" runat="server" OnClick="btnCantReadTag_Click" Text="No se pudo leer TAG" Width="100%" />
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

                        <table id="Table6" runat="server" style="Width:100%">
                            <tr>
                                <td style="width: 20%"></td>
                                <td style="width: 60%; text-align:center">
                                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                                <td style="width:20%"></td>
                            </tr>
                        </table>

                        <table id="Table5" runat="server" style="Width:100%; height:100px" >
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
                        </div>
                    </div>
                </div>
            </div>


            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
