<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePasswordInAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.ChangePasswordInAndroidPage" %>



<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.ListControls" tagprefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.EditorControls" tagprefix="ig" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/AmisAndroid.css" />
</head>
<body style="border:solid">
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                                <asp:Timer ID="timer" runat="server" OnTick="timer_Tick"></asp:Timer>

                <table style="width:100%; border:solid">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                          <asp:Label ID="lblTittle" CssClass="CssTitle" Width="100%" runat="server" Text="Cambio de contraseña"></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                <div  id="Error" runat="server" visible="false">
                    <table style="width:100%">
                        <tr>
                            <td style="width:20%">

                            </td>
                            <td style="width:60%; text-align:center">
                                <asp:Label ID="lblError"  runat="server" Width="100%" Text=""></asp:Label>
                            </td>
                            <td style="width:20%">

                            </td>
                        </tr>
                    </table>
                </div>
                <div id="password" runat="server">
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Label ID="lblCurrentPassword" CssClass="CssSubTitle" runat="server" Width="100%" Text="Digite su contraseña actual"></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; align-content:center; text-align:center">
                            <asp:TextBox ID="txtCurrentPassword" runat="server" ClientIDMode="Static" Width="100%" TextMode="Password"></asp:TextBox>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Label ID="lblMessageNewPassword" CssClass="CssLabel" runat="server" Width="100%" Text="Digite su nueva contraseña Mínimo 8 caracteres."></asp:Label>
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
                            <asp:TextBox ID="txtNewPassword" runat="server" ClientIDMode="Static" Width="100%" TextMode="Password"></asp:TextBox>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Label ID="lblMessageErrorNewPassword" CssClass="CssLabel" runat="server" Width="100%" Text="Digite de nuevo la contraseña. Asegurese que las contraseñas sean idénticas"></asp:Label>
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
                            <asp:TextBox ID="txtRepeatNewPassword" runat="server" ClientIDMode="Static" Width="100%" TextMode="Password"></asp:TextBox>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                </div>
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:10%">

                        </td>
                        <td style="width:30%; text-align:center">
                            <asp:Button ID="btnChange" Width="100%" runat="server" Text="Cambiar Contraseña" OnClick="btnChange_Click" />
                        </td>
                        <td style="width:20%">

                        </td>
                        <td style="width:30%; text-align:center">
                            <asp:Button ID="btnBack" Width="100%" runat="server" Text="Volver" OnClick="btnBack_Click" />
                        </td>
                        <td style="width:10%">

                        </td>
                    </tr
                </table>
                <table>
                    <tr><td></td></tr>
                </table>                

            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
