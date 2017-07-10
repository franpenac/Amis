<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectReplaceTyreDestiny.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.SelectReplaceTyreDestiny"  Async="true" %>

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
                            <h1 id="tittle" runat="server">Recambio</h1></td>
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
                            <asp:Label ID="lblSubTittle" runat="server" Width="100%" Text="Elija acción de destino con el neumático seleccionado" ForeColor="Black"></asp:Label>
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
                            <asp:Button ID="btnIntoTheSameUnit" runat="server" Width="100%" Text="Dentro de la misma unidad" style="height: 26px" OnClick="btnIntoTheSameUnit_Click"/>
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
                            <asp:Button ID="btnToWareHouse" runat="server" Width="100%" Text="A una bodega" OnClick="btnToWareHouse_Click" />
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
                                <asp:Button ID="btnToAnotherUnit" runat="server" Width="100%" Text="A otra unidad en taller" OnClick="btnToAnotherUnit_Click" />
                            </td>
                            <td style="width: 20%"></td>
                        </tr>
                    </table>
                    <br />   
                                        <table style="width: 100%">
                        <tr>
                            <td style="width: 20%"></td>
                            <td style="width: 60%; text-align: center;">
                                <asp:Button ID="btnToAnotherUnitOnRoad" runat="server" Width="100%" Text="A otra unidad en terreno" OnClick="btnToAnotherUnitOnRoad_Click" />
                            </td>
                            <td style="width: 20%"></td>
                        </tr>
                    </table>                                            
                </ContentTemplate>
            </asp:UpdatePanel>
        
    </form>
</body>
</html>
