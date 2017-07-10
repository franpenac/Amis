<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveTyreInspectionAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.RemoveTyreInspectionAndroidPage"  Async="true" %>

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
<body style="border:solid">
    <form id="form1" runat="server">
        
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    

                <table style="width:100%; border:solid">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <h1 id="tittle" runat="server">Operaciones de neumático</h1></td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center;">
                            <asp:Label ID="lblSubTittle" runat="server" Width="100%" Text="Acciones con el neumático seleccionado" ForeColor="Black"></asp:Label>
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
                        <td style="width:60%; text-align:center;">
                            <asp:Button ID="btnDiscardTyre" runat="server" Width="100%" Text="Descartar" OnClick="btnDiscardTyre_Click" style="height: 26px"/>
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
                        <td style="width:60%; text-align:center;">
                            <asp:Button ID="btnRepair" runat="server" Width="100%" Text="Reparar" OnClick="btnRepair_Click" />
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                    <br />
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 20%"></td>
                            <td style="width: 60%; text-align: center;">
                                <asp:Button ID="btnChangePosition" runat="server" Width="100%" Text="Cambiar posición" OnClick="btnChangePosition_Click" />
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
