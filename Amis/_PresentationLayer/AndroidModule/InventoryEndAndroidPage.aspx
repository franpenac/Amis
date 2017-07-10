<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryEndAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.InventoryEndAndroidPage" %>

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
                            <h1>Inventario</h1></td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                    <table style="width:100%">
                    <tr>
                        <td style="width:10%">

                        </td><td style="width:10%">
                            &nbsp;</td>
                        <td style="width:60%; text-align:center;">
                            <asp:Label ID="lblMessageNoTyre" runat="server" Width="100%" Text="La cantidad de activos NO neumaticos registrados en la unidad es de: "></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:10%">

                        </td><td style="width:10%">
                            &nbsp;</td>
                        <td style="width:60%; text-align:center;">
                            <asp:Label ID="lblNoTyre" runat="server" Width="100%" Text="La cantidad de activos NO neumaticos leidos es de: "></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                    <table style="width:100%">
                    <tr>
                        <td style="width:10%">

                        </td><td style="width:10%">
                            &nbsp;</td>
                        <td style="width:40%; text-align:center;">
                            <asp:Label ID="lblMessageTyre" runat="server" Width="100%" Text="La cantidad de activos neumaticos registrados en la unidad es de: "></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                    <table style="width:100%">
                    <tr>
                        <td style="width:10%">

                        </td><td style="width:10%">
                            &nbsp;</td>
                        <td style="width:40%; text-align:center;">
                            <asp:Label ID="lblTyre" runat="server" Width="100%" text="La cantidad de activos neumaticos leidos es de:"></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:15%">

                        </td>
                        <td style="width:30%; text-align:center">
                            <asp:Button ID="btnEnd" runat="server" OnClick="btnEnd_Click" Text="Terminar inspección" Width="100%" />
                        </td>
                        <td style="width:10%; text-align:center">
                        </td>
                        <td style="width:30%; text-align:center">
                            <asp:Button ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continuar inspección" Width="100%" />
                        </td>
                        <td style="width:15%">

                        </td>
                    </tr>
                </table>
                
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        
    </form>
</body>
</html>
