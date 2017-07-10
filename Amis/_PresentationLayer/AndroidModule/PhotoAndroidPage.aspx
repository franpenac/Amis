<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhotoAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.PhotoAndroidPage"  Async="true" %>


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
                            <h1>Inspección</h1></td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                    <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                            &nbsp;</td>
                        <td style="width:60%; text-align:center">
                            <asp:Image ID="imgCam" Width="100%" ImageUrl="~/ig_common/images/Photo.jpg" runat="server" />
                        </td>
                        
                        <td style="width:20%">
                            
                        </td>
                    </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <table style="width:100%" id="Option" runat="server">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:10%; text-align:center" id="Td4" runat="server">
                        </td>
                        <td style="width:15%; text-align:center">
                            <asp:Button ID="btnSave" runat="server" Text="Guardar" Width="100%" OnClick="btnSave_Click" />
                        </td>
                        <td style="width:10%; text-align:center" id="Td5" runat="server">
                        </td>
                        <td style="width:15%; text-align:center">
                            <asp:Button ID="btnRepetir" runat="server" Text="Repetir" Width="100%" OnClick="btnRepetir_Click" />
                        </td>
                        <td style="width:10%; text-align:center" id="Td6" runat="server">
                                </td>
                        <td style="width:20%">
                            
                        </td>
                    </tr>
                </table>
                <br />
                    <br />    
                
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        
    </form>
</body>
</html>