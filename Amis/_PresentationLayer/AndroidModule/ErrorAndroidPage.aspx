<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.ErrorAndroidPage" Async="true" %>

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
<body>
    <form id="form1" runat="server">
        
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    

                <br />
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:10%">

                        </td>
                        <td style="width:40%; align-content:center;">
                            <asp:Label ID="lblReadTag" runat="server" Width="100%" Text="Lectura de TAG"></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                        <td style="width:10%">

                            <asp:Image ID="Smile" runat="server" ImageUrl="~/ig_common/images/sad-face-red-60x60.png" />

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
                            &nbsp;</td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                            &nbsp;</td>
                        <td style="width:60%; text-align:center">
                            <asp:Label ID="lblSubTittle" runat="server" Width="100%" Visible="False"></asp:Label>
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
                            &nbsp;</td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Label ID="lblMessageForeman" runat="server" Width="100%" Visible="False"></asp:Label>
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
                            &nbsp;</td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="width:40%">

                        </td>
                        <td style="width:10%; text-align:right">
                            <asp:Label ID="lblNext" runat="server" Width="100%" Text="Siguiente" Visible="False" style="height: 19px"></asp:Label>
                        </td >
                        <td style="width:2%; text-align:right"></td>
                        <td style="width:10%; align-items:center;position:center">
                            <asp:ImageButton ID="imgNext" runat="server" ImageUrl="~/ig_common/images/right_row.png" OnClick="imgNext_Click" Visible="False" />

                        </td>
                        <td style="width:38%">

                        </td>
                    </tr>
                </table>
                
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        
    </form>
</body>
</html>
