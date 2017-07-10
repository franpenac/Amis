<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectBranchOfficeAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.SelectBranchOfficeAndroidPage" %>

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
                    
                      <table style="width:100%">
                        <tr>
                            <td style="width:100%; text-align:center">
                              <img src="../../ig_common/images/PNG_MEDIA.png" width="100%" />
                            </td>
                        </tr>
                    </table>
                
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                        </td>
                        <td style="width:20%">
                            &nbsp;</td>
                    </tr>
                </table>
                    <br />
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; align-content:center; text-align:center">
                            <asp:DropDownList ID="ddlSelectedBranchOffice" runat="server" Width="100%">
                            </asp:DropDownList>
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
                        <td style="width:60%; align-content:center; text-align:center">
                            
                            <asp:Button ID="btnContinue" runat="server" OnClick="btnContinue_Click" Text="Continuar" Width="100%" />
                            
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Label ID="lblWelcome" runat="server" Width="100%" Text=""></asp:Label>
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        
    </form>
</body>
</html>