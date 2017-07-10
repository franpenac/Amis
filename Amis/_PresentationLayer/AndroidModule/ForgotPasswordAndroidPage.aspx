<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPasswordAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.ForgotPasswordAndroidPage" Async="true" %>

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
<body style="border:solid">
    <form id="form1" runat="server">

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table style="width:100%; border:solid">
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
                            <asp:Label ID="lblMessage" runat="server" Width="100%" Text=""></asp:Label>
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
                        <td style="width:60%; align-content:center; text-align:center">
                            <asp:TextBox ID="txtRecoveryUserEmail" runat="server" Width="100%" placeholder="Email"></asp:TextBox>
                        </td>
                        <td style="width:20%">

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
                            <ig:WebCaptcha ID="wbcRecoveryPassword" runat="server" Width="100%" Height="83px" InputValueEditor-BorderColor="Green" InputValueEditor-Font-Bold="true" CaptchaDictionaryPath="" ErrorMessage="Código ingresado inválido">
                                    <InputValueEditor runat="server" NullText="Ingrese texto" HorizontalAlign="Center"></InputValueEditor>
                                    <RefreshButton ToolTip="Refrescar imagen de Captcha" />
                                    <SubmitButton  Visible="false"/>
                                    <AudioButton  Visible="false"/>
                                </ig:WebCaptcha>
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
                        <td style="width:60%; align-content:center; text-align:center">
                            <asp:Label ID="lblError" runat="server" Text="" Width="100%"></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="width:10%">

                        </td>
                        <td style="width:30%; text-align:center">
                            <asp:Button ID="btnBack" runat="server" Text="Volver" Width="100%" OnClick="btnBack_Click"/>
                        </td>
                        <td style="width:20%">

                        </td>
                        <td style="width:30%; text-align:center">
                            <asp:Button ID="btnRestore" runat="server" Text="Recuperar" Width="100%" OnClick="btnRestore_Click"/>
                        </td>
                        <td style="width:10%">

                        </td>
                    </tr
                </table>
                    <caption>
                        <br />
                    </caption>

                </div>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
       
    </form>
</body>
</html>
