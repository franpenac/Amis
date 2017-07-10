<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AssetModule.UnitAndroidPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.ListControls" tagprefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/AmisAndroid.css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .Opacity
        {
            opacity:0;
        }

        .auto-style2 {
            width: 100%;
            height: 53px;
            font-size:25px;
            font-family:'Times New Roman', Times, serif;
        }

    </style>
    <script type="text/javascript" id="igClientScript">
        function getControl(controlName) {
            return document.getElementById(controlName);
        }

        function ReadTag() {
            AndroidInterface.androidRFIDTurnOn(true);
            getControl('txbTag').value = '';
            var value = AndroidInterface.androidFindTagStrongSound();
            getControl('txbTag').value = value;
            var button = getControl('btnProcess');
            button.click();
        }
    </script>
    </head>
<body >
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div>
                        <table style="border:solid; width:100%" >
                            <tr>
                                <td style=" text-align:center">
                                    <asp:Label ID="lblTitle" CssClass="CssTitle" runat="server" Text="Asignación TAG a Unidades"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table class="auto-style1">
                            <tr>
                                <td style="width:10%">
                                </td>
                                <td style="width:15%; text-align:center">
                                    
                                </td>
                                <td style="width:50%; text-align:center">
                                    <asp:Label ID="lblUnit" runat="server" Text="Seleccione la unidad"></asp:Label>
                                </td>
                                <td style="width:25%">

                                </td>
                            </tr>
                        </table>
                        <br />
                        <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:DropDownList ID="ddlTypeSearch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTypeSearch_SelectedIndexChanged" Width="100%">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:DropDownList ID="ddlUnitSelectValue" runat="server"  Width="100%">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                        <table style="width:100%">
                            <tr>
                                <td style="width:10%">
                                </td>
                                <td style="width:15%">
                                </td>
                                <td style="width:50%">
                                   <input type="button" value='Leer' class="auto-style2" style="width:100%" id="btnReadRfiTag" onclick='ReadTag();'/>
                                </td>
                                <td style="width:25%">

                                </td>
                            </tr>
                        </table>
                        
                        <br />
                        <table style="width:100%">
                            <tr>
                                <td style="width:10%">
                                </td>
                                <td style="width:15%">
                                </td>
                                <td style="width:50%">
                                    <asp:Button ID="btnBack" runat="server" CssClass="auto-style2" Text="Volver" Width="100%" OnClick="btnBack_Click" />
                                </td>
                                <td style="width:25%">

                                </td>
                            </tr>
                        </table>
                        <br />
                    <table style="width: 100%; opacity:0;">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:TextBox ID="txbTag" CssClass="Opacity" runat="server"></asp:TextBox>
                            
                            <asp:Button ID="btnProcess" runat="server" CssClass="Opacity" OnClick="btnProcess_Click" Text="Button" />
                            
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
