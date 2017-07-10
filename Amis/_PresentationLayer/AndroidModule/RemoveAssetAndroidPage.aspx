<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveAssetAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.RemoveAssetAndroidPage" Async="true" %>

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
<body style="border:solid">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <table style="width: 100%; border:solid" border="1">
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblTittle" runat="server" Width="100%" Text="Remover" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:10%">

                        </td><td style="width:10%">
                            &nbsp;</td>
                        <td style="width:10%">

                            

                        </td>
                        <td style="width:20%; align-content:center;">
                            &nbsp;</td>
                        <td style="width:20%">

                        </td>
                        <td style="width:10%">

                            <asp:Image ID="Smile" runat="server" ImageUrl="~/ig_common/images/fa-smile-green.png" />

                        </td>
                        <td style="width:20%">

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
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblAssetType" runat="server" Width="100%" Text="Tipo de activo: "></asp:Label>
                            </td>
                        <td style="width: 20%"></td>
                        <td style="width: 30%; text-align: center">
                            &nbsp;</td>
                        <td style="width: 10%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Label ID="Label2" runat="server" Width="100%" Text="Se debe depositar a la bodega de bajas" ForeColor="Red"></asp:Label>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Label ID="Label3" runat="server" Width="100%" Text="Se envió un aviso a su supervisor" ForeColor="Red"></asp:Label>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                <br />
                 <table style="width:100%">
                    <tr>
                        <td style="width:40%">

                        </td>
                        <td style="width:10%; text-align:right">
                            <asp:Label ID="lblNext" runat="server" Width="100%" Text="Siguiente"></asp:Label>
                        </td >
                        <td style="width:2%; text-align:right"></td>
                        <td style="width:10%; align-items:center;position:center">
                            <asp:ImageButton ID="imgNext" runat="server" ImageUrl="~/ig_common/images/right_row.png" OnClick="imgNext_Click" Height="26px" />

                        </td>
                        <td style="width:38%">

                        </td>
                    </tr>
                </table>
                
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
