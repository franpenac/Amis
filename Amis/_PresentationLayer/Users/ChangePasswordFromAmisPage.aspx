<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePasswordFromAmisPage.aspx.cs" Inherits="amis._PresentationLayer.Users.ChangePasswordFromAmisPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebSchedule.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">

    <title>Cambiar contraseña</title>

    <style type="text/css">
        .auto-style1 {
            height: 17px;
        }

        .auto-style2 {
            height: 20px;
        }
    </style>

    <style>
        .divCentrado {
            text-align: left;
            margin-top: 100px;
            margin-left: 200px;
        }
    </style>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="font-family: Arial; font-size: 20px; font-weight: bold">
                Cambio de contraseña
            </div>
            <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
            <div class="divCentrado">
                <hr style="height: 2px; color: #123455; background-color: #123455; border: none; width: 600px; margin-left: -3px" />
                <table>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblCurrentPassword" runat="server" Text="Contraseña Actual" Font-Bold="true"></asp:Label><asp:Label runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblMessageCurrentPassword" runat="server" Text="Introduzca su contraseña actual."></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <ig:WebTextEditor ID="wteCurrentPassword" runat="server" Width="300px" TextMode="Password"></ig:WebTextEditor>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblNewPassword" runat="server" Text="Nueva Contraseña" Font-Bold="true"></asp:Label><asp:Label runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblMessageNewPassword" runat="server" Text="Introduzca nueva contraseña. Mínimo 8 caracteres."></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <ig:WebTextEditor ID="wteNewPassword" runat="server" Width="301px" TextMode="Password">
                            </ig:WebTextEditor>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top" class="auto-style1"></td>
                        <td style="vertical-align: top" class="auto-style1"></td>
                        <td style="vertical-align: top" class="auto-style1"></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top" class="auto-style2">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblRepeatNewPassword" runat="server" Text="Confirmar contraseña" Font-Bold="true"></asp:Label><asp:Label runat="server" Text="*" ForeColor="Red"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblMesssageRepeatPassword" runat="server" Text="Introduzca de nuevo la contraseña. Asegurese de que las contraseñas son idénticas."></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top" class="auto-style2">
                            <ig:WebTextEditor ID="wteRepeatNewPassword" runat="server" Width="301px" TextMode="Password">
                            </ig:WebTextEditor>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top" class="auto-style2">
                            <div style="font-family: Arial; font-size: 13px">
                                <igtxt:WebImageButton ID="wibChangePassword" runat="server" Text="Cambiar contraseña" OnClick="wibChangePassword_Click" Width="150px" Height="30px">
                                    <Appearance>
                                        <Image Url="../../ig_common/images/changePasswordIcon16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                </table>
                <hr style="height: 2px; color: #123455; background-color: #123455; border: none; width: 600px; margin-left: -3px" />
            </div>
            <br />
            <br />
            <div>
                <table>
                </table>
            </div>
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="divAux" runat="server"></div>

</asp:Content>
