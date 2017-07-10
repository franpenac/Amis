<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeAssetToAnotherWarehouse.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.ChangeAssetToAnotherWarehouse" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

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
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 100%; border: solid" border="1">
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblTittle" runat="server" Width="100%" Text="Cambio a otra bodega" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <div>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 10%"></td>
                            <td style="width: 30%; text-align: center">
                                <asp:Label ID="lblPatent" runat="server" Width="100%" Text="Patente"></asp:Label>
                            </td>
                            <td style="width: 20%"></td>
                            <td style="width: 30%; text-align: center">
                                <asp:Label ID="lblInternalNumber" runat="server" Width="100%" Text="N° interno"></asp:Label>
                            </td>
                            <td style="width: 10%"></td>
                        </tr>
                        <tr>
                            <td style="width: 10%"></td>
                            <td style="width: 30%; text-align: center">
                                <asp:Label ID="lblPatentSelected" runat="server" Width="100%"></asp:Label>
                            </td>
                            <td style="width: 20%"></td>
                            <td style="width: 30%; text-align: center">
                                <asp:Label ID="lblInternalNumberSelected" runat="server" Width="100%"></asp:Label>
                            </td>
                            <td style="width: 10%"></td>
                        </tr>
                    </table>
                    <br />
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 10%"></td>
                            <td style="width: 20%; text-align: center"></td>
                            <td style="width: 40%">
                                <asp:Label ID="lblWarehouse" runat="server" Width="100%" Text="Seleccione bodega"></asp:Label>
                            </td>
                            <td style="width: 20%; text-align: center">&nbsp;</td>
                            <td style="width: 10%"></td>
                        </tr>
                    </table>
                    </table>
                   <table style="width: 100%">
                       <tr>
                           <td style="width: 10%"></td>
                           <td style="width: 20%; text-align: center"></td>
                           <td style="width: 40%">
                               <asp:DropDownList ID="ddlSelectWarehouse" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlSelectWarehouse_SelectedIndexChanged"></asp:DropDownList>
                           </td>
                           <td style="width: 20%; text-align: center">&nbsp;</td>
                           <td style="width: 10%"></td>
                       </tr>
                   </table>
                </div>
                <%-- Mpe warehouse correct--%>
                <asp:Button ID="btnWarehouseCorrect" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeWarehouseCorrect" runat="server"
                    TargetControlID="btnWarehouseCorrect" CancelControlID="btnWarehouseCorrect" OkControlID="btnWarehouseCorrect"
                    PopupControlID="panReplace">
                </cc1:ModalPopupExtender>
                <div id="panReplace" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderConfirmarReplace">
                            <div style="background-color: black;">
                                <asp:Table ID="Table2" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table7" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table8" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label3" runat="server" Text="¿Esta seguro?"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table9" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label4" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table10" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 10%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnConffirmWarehouse" runat="server" Text="Si" Width="100%" Height="20px" OnClick="btnYes_Click" />
                                        </td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnNoConffirmWarehouse" runat="server" Text="No" Width="100%" Height="20px" OnClick="btnNo_Click" />
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
