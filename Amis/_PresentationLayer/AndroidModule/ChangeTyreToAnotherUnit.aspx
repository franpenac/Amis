<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeTyreToAnotherUnit.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.ChangeTyreToAnotherUnit" %>


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
        .auto-style1 {
            margin-bottom: 0px;
        }
        .btnInv
        {
            opacity: 0;
            width: 1px;
        }
    </style>
        <script type="text/javascript">

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
<body style="border:solid">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <table style="width: 100%; border:solid" border="1">
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblTittle" runat="server" Width="100%" Text="Unidad receptora" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 30%; align-content: center; text-align: center">
                            <input type="button" value='Leer tag' id="btnReadRfiTag" onclick='ReadTag();'/>
                        </td>
                        <td style="width: 30%">
                                                        <asp:TextBox ID="txbTagUnit" runat="server" Visible="true" CssClass="btnInv"></asp:TextBox>
                        </td>
                        <td style="width: 30%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btnInv" OnClick="btnSearch_Click"/>
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
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            &nbsp;</td>
                        <td style="width: 20%"></td>
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
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Button ID="btnReadTag" runat="server" Text="Leer TAG" Width="100%" OnClick="btnReadTag_Click" />
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
                            <asp:Button ID="btnWrongFacility" runat="server" OnClick="btnWrongFacility_Click" Text="TAG no corresponde a unidad" Width="100%" CssClass="auto-style1" />
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
