<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterTagAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.RegisterTagAndroidPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/AmisAndroid.css" />
    <style>
        .Opacity
        {
            opacity:0;
        }
        .auto-style2 {
            width: 100%;
            height: 70px;
            font-size:18px;
        }
    </style>
    <script type="text/javascript">

        function getControl(controlName) {
            return document.getElementById(controlName);
        }

        function ReadTag()
        {
            AndroidInterface.androidRFIDTurnOn(true);
            getControl('txbTagRead').value = '';
            var value = AndroidInterface.androidFindTagStrongSound();
            getControl('txbTagRead').value = value;
            var button = getControl('imbAssetAdd');
            button.click();
        }
        
    </script>
</head>
<body >
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer ID="timer" runat="server" OnTick="timer_Tick"></asp:Timer>

                <table style="width: 100%; border:solid" border="1">
                    <tr>
                        <trs>
                            <td style="width: 100%; text-align: center">
                                <asp:Label ID="lblTittle" runat="server" Font-Bold="true" Font-Size="XX-Large" Text="Registro de TAG" Width="100%"></asp:Label>
                            </td>
                        </trs>
                    </tr>
                </table>
                <br />
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 25%"></td>
                        <td style="width: 50%; align-content: center; text-align: center">
                            <asp:TextBox ID="txbTagRead" runat="server" CssClass="Opacity" Width="100%"></asp:TextBox>
                        </td>
                        <td style="width: 25%">
                            <asp:ImageButton ID="imbAssetAdd" runat="server" ClientIDMode="Static" CssClass="Opacity" ImageUrl="~/ig_common/images/add16x16.png" OnClick="imbAssetAdd_Click" Style="width:100%; height:16px" />
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 25%"></td>
                        <td style="width: 45%; align-content: center; text-align: center">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 5%">                            
                            &nbsp;</td>
                        <td style="width: 25%">
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 25%"></td>
                        <td style="width: 50%; align-content: center; text-align: center">
                        </td>
                        <td style="width: 25%">
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center; font-size:18px">
                            <input type="button" value='Leer tag' id="btnReadRfiTag" onclick='ReadTag();' class="auto-style2"/>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Fin de registro de TAGS" class="auto-style2" Width="100%" Height="51px" />
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                <br />

            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>

