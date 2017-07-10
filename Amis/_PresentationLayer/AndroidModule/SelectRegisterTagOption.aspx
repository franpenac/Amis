<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectRegisterTagOption.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.SelectRegisterTagOption" %>

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
                            <asp:Button ID="btnAsset" runat="server" Text="Registro unitario de TAGS" Width="100%" OnClick="btnAsset_Click"/>
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
                            <asp:Button ID="btnUnit" runat="server" Text="Registro masivo de TAGS" Width="100%" OnClick="btnUnit_Click"/>
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
                            <asp:Button ID="btnBack" runat="server" Text="Volver" Width="100%" OnClick="btnBackToMenu_Click"/>
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
                    <table style="width: 100%">
                        <tr>
                            <td style="width: 20%"></td>
                            <td style="width: 60%; text-align: center">
                                &nbsp;</td>
                            <td style="width: 20%"></td>
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
                <br />
                <br />
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
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        
    </form>
</body>
</html>
