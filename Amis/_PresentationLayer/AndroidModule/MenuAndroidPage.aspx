<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.MenuAndroidPage" %>

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
<body>
    <form id="form1" runat="server">
        
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    
                      <table style="width:100%">
                        <tr>
                            <td style="width:100%; text-align:center">
                              <img src="../../ig_common/images/PNG_MEDIA.png" width="100%" />
                            </td>
                        </tr>
                    </table>
                
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                        </td>
                        <td style="width:20%">
                            <asp:Button ID="btnCloseSession" runat="server" Text="Cerrar Sesion" Width="100%" OnClick="btnCloseSession_Click" />
                        </td>
                    </tr>
                </table>
                    <br />
                <br />
                
                <table style="width:100%" id="regTag" runat="server">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Button ID="btnRegisterTag" runat="server" Text="Registro de TAG" Width="100%"  OnClick="btnRegisterTag_Click"/>
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
                            <asp:Button ID="btnAsignationTag" runat="server" Text="Asignar TAG a activo" Width="100%" OnClick="btnAsignationTag_Click" />
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
                            <asp:Button ID="btnAsignationAsset" runat="server" Text="Asignar Activo a Unidad" Width="100%" OnClick="btnAsignationAsset_Click" />
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
                            <asp:Button ID="btnInspection" runat="server" Text="Inspección" Width="100%" OnClick="btnInspection_Click" />
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
                            <asp:Button ID="btnInventory" runat="server" Text="Inventario" Width="100%" OnClick="btnInventory_Click" />
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <%--<table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Button ID="btnInconcist" runat="server" Text="Inconsistencias" Width="100%" OnClick="btnInconcist_Click" />
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>--%>
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 20%"></td>
                            <td style="width: 60%; text-align: center">
                                <asp:Button ID="btnReplaceTyre" runat="server" Text="Recambio" Width="100%" OnClick="btnReplaceTyre_Click" />
                            </td>
                            <td style="width: 20%"></td>
                        </tr>
                    </table>
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Button ID="btnChangePassword" runat="server" Text="Cambio de contraseña" Width="100%" OnClick="btnChangePassword_Click" />
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Label ID="lblWelcome" runat="server" Width="100%" Text=""></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        
    </form>
</body>
</html>
