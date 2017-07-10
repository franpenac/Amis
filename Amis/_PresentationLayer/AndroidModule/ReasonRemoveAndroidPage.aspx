<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReasonRemoveAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.ReasonRemoveAndroidPage" %>

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
    <form id="form2" runat="server">
        
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
                        <td style="width:10%">

                        </td><td style="width:10%">
                            <asp:Image ID="Image1" runat="server" Width="60px" Height="60px" />
                        </td>
                        <td style="width:10%">

                            

                        </td>
                        <td style="width:20%; align-content:center;">
                            <asp:Label ID="lblReadTag" runat="server" Width="100%" Text="Lectura de TAG"></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                        <td style="width:10%">

                            <asp:Image ID="Smile" runat="server" ImageUrl="~/ig_common/images/fa-smile-green.png" />

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
                            <asp:Label ID="lblStateAsset" runat="server" Width="100%" text="Indique la razón del mal estado"></asp:Label>
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
                            <asp:DropDownList ID="ddlScrapType" 
                                runat="server" OnSelectedIndexChanged="ddlScrapType_SelectedIndexChanged" Width="100%" >
                            </asp:DropDownList>
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
                            &nbsp;</td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                    <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:10%; text-align:center" id="Td1" runat="server">
                                
                                </td>
                        <td style="width:15%; text-align:center" runat="server">
                            <asp:Label ID="lblPhoto" runat="server" Text="Fotografia"></asp:Label>
                                <br />
                        </td>
                        <td style="width:10%; text-align:center" id="Td3" runat="server">
                                <asp:Button ID="btnPhoto" runat="server" Text="Foto" Width="100%" OnClick="btnPhoto_Click" />
                                </td>
                        <td style="width:15%; text-align:center">
                            <br />
                            </td>
                        <td style="width:10%; text-align:center" id="Td2" runat="server">
                                </td>
                        <td style="width:20%">
                            
                        </td>
                    </tr>
                </table>
                    <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                            &nbsp;</td>
                        <td style="width:30%; text-align:center">
                            
                            &nbsp;</td><td style="width:30%;">
                            
                        </td>
                        
                        <td style="width:20%">
                            
                        </td>
                    </tr>
                        </table>
                    <table style="width:100%" id="Option" runat="server" visible="false">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:10%; text-align:center" id="Td4" runat="server">
                        </td>
                        <td style="width:15%; text-align:center">
                                <br />
                        </td>
                        <td style="width:10%; text-align:center" id="Td5" runat="server">
                        </td>
                        <td style="width:15%; text-align:center">
                                <br />
                        </td>
                        <td style="width:10%; text-align:center" id="Td6" runat="server">
                                </td>
                        <td style="width:20%">
                            
                        </td>
                    </tr>
                </table>
                </table>
                    </table>
                    <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                            &nbsp;</td>
                        <td style="width:30%; text-align:center">
                            &nbsp;</td><td style="width:30%;">
                            &nbsp;</td>
                        
                        <td style="width:20%">
                            
                        </td>
                    </tr>
                </table>
                    <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                            &nbsp;</td>
                        <td style="width:30%; text-align:center">
                            
                        </td><td style="width:30%;">
                            
                        </td>
                        
                        <td style="width:20%">
                            
                        </td>
                    </tr>
                </table>
                    </table>
                    
                
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        
    </form>
</body>
</html>
