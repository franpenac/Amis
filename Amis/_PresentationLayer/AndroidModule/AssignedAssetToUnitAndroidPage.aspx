<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="AssignedAssetToUnitAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.AssignedAssetToUnitAndroidPage" %>

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
        .CssTextBox {
        }

        .buttonLogin {
            margin-left: 0px;
        }
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="border:solid">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 100%; border:solid" >

                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <h1><asp:Label ID="Label2" runat="server" Width="100%">Asignación de activos</asp:Label></h1>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>

                <br />
                <br />
                <table style="width: 100%">

                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Label ID="lblMessageForeman" runat="server" Width="100%">Selecciones unidad</asp:Label>
                        </td>
                        <td style="width: 20%"></td>
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
                            <asp:DropDownList ID="ddlUnitSelectValue" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUnitSelectValue_SelectedIndexChanged" Width="100%">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                
                <br />
                <table class="auto-style1">

                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Label ID="Label1" runat="server" Width="100%">Seleccione Activo</asp:Label>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:DropDownList ID="ddlAssetType" runat="server" Width="100%">
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
                            <asp:Button ID="btnRead" Width="100%" OnClick="btnRead_Click" runat="server" Text="Enter" />
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>  
                <br />
               <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Button ID="btnBack" Width="100%" OnClick="btnBack_Click" runat="server" Text="Volver" />
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


