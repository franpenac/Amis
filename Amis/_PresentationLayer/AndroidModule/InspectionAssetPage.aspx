<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionAssetPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.InspectionAssetPage" %>


<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.ListControls" tagprefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/AmisAndroid.css" />
    <style type="text/css">
        .CssTextBox {}
        .buttonLogin {
            margin-left: 0px;
        }
    </style>
</head>
<body style="border:solid">
    <form id="form1" runat="server">
        
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    

                <table style="width:100%; border:solid">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <h1>Inspección</h1></td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:10%">

                        </td><td style="width:10%">
                            <asp:Image ID="Image1" runat="server" Width="60px" Height="60px" />
                        </td>
                        <td style="width:10%">

                            

                        </td>
                        <td style="width:20%; align-content:center;">
                            <asp:Label ID="lblReadTag" runat="server" Width="100%" Text="Lectura de TAG"></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                        <td style="width:10%">

                            <asp:Image ID="Smile" runat="server" ImageUrl="~/ig_common/images/fa-smile-green.png" />

                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            &nbsp;</td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                            &nbsp;</td>
                        <td style="width:30%; text-align:center">
                            <asp:Label ID="lblStateAsset" runat="server" Width="100%" text="Estado de activo"></asp:Label>
                        </td><td style="width:30%;">
                            <asp:DropDownList ID="ddlStateAsset" Width="100%" runat="server" OnSelectedIndexChanged="ddlStateAsset_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Selected="True" Value="0">Seleccione</asp:ListItem>
                                <asp:ListItem Value="1">Bueno</asp:ListItem>
                                <asp:ListItem Value="2">Malo</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        
                        <td style="width:20%">
                            
                        </td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            &nbsp;</td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Label ID="lblMessageForeman" runat="server" Width="100%" text="¿Otra inspección?"></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                </table>
                    </table>
                </table>
                    </table>   
                    <%-- Mpe otra inspeccion--%>
                <asp:Button ID="btnOtherInspection" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeOtherInspection" runat="server"
                    TargetControlID="btnOtherInspection" CancelControlID="btnOtherInspection" OkControlID="btnOtherInspection"
                    PopupControlID="panOther">
                </cc1:ModalPopupExtender>
                <div id="panOther" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderOther">
                            <div style="background-color: black;">
                                <asp:Table ID="Table21" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label11" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table22" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table23" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label12" runat="server" Text="¿Otra inspección?"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table24" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label13" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table25" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 10%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnOtherYes" runat="server" Text="Si" Width="100%" Height="20px" OnClick="btnOtherYes_Click"/>
                                        </td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnOtherNo" runat="server" Text="No" Width="100%" Height="20px" OnClick="btnOtherNo_Click" />
                                        </td>
                                        <td style="width: 10%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                    <%-- Mpe same unit--%>
                <asp:Button ID="btnSameUnit" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeUnit" runat="server"
                    TargetControlID="btnSameUnit" CancelControlID="btnSameUnit" OkControlID="btnSameUnit"
                    PopupControlID="panUnit">
                </cc1:ModalPopupExtender>
                <div id="panUnit" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderUnit">
                            <div style="background-color: black;">
                                <asp:Table ID="Table26" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label14" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table27" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table28" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label15" runat="server" Text="¿En la misma unidad?"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table29" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label16" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table30" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 10%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnSameUnitYes" runat="server" Text="Si" Width="100%" Height="20px" OnClick="btnSameUnitYes_Click"/>
                                        </td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnSameUnitNo" runat="server" Text="No" Width="100%" Height="20px" OnClick="btnSameUnitNo_Click"/>
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
