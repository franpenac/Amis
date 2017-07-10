<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePasswordAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.ChangePasswordAndroidPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.ListControls" tagprefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.DisplayControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
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
                <br />
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:TextBox ID="txtChangePasswordCode" runat="server" Width="100%" placeholder="Codigo"></asp:TextBox>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:35%">

                        </td>
                        <td style="width:30%; align-content:center; text-align:center">
                            <asp:Button ID="btnCheckCode" runat="server" Text="Validar"  Width="100%" OnClick="btnCheckCode_Click" />
                        </td>
                        <td style="width:35%">

                        </td>
                    </tr>
                </table>
                <br />
                <div runat="server" id="divNewPassword">
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:TextBox ID="txtNewPassword" runat="server" placeholder="Contraseña" Width="100%" TextMode="Password"></asp:TextBox>
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
                            <asp:TextBox ID="txtRepeatPassword" runat="server"  placeholder="Repetir contraseña" Width="100%" TextMode="Password"></asp:TextBox>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:10%">

                        </td>
                        <td style="width:30%; text-align:center">
                            <asp:Button ID="btnChangePassword" runat="server" Text="Guardar" Width="100%" OnClick="btnChangePassword_Click" />
                        </td>
                        <td style="width:20%">

                        </td>
                        <td style="width:30%; text-align:center">
                            <asp:Button ID="btnBackToLogin" runat="server" Text="Cancelar" Width="100%" OnClick="btnBackToLogin_Click" />
                        </td>
                        <td style="width:10%">

                        </td>
                    </tr
                </table>
</div>

                       
                        
                </ContentTemplate>
            </asp:UpdatePanel>
       
    </form>
</body>
</html>

