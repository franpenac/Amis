<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryNoTyreAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.InventoryNoTyreAndroidPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
        .Opacity
        {
            opacity:0;
        }
    </style>
        <script type="text/javascript" id="igClientScript">
        function getControl(controlName) {
            return document.getElementById(controlName);
        }

        function ReadTag() {
            AndroidInterface.androidRFIDTurnOn(true);
            getControl('TextBox1').value = '';
            var value = AndroidInterface.androidFindTagStrongSound();
            getControl('TextBox1').value = value;
            var button = getControl('btnReadTag');
            button.click();
        }
    </script>
</head>
<body >
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <table style="width: 100%; border:solid" border="1">
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblTittle" runat="server" Width="100%" Text="Inventario" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                </table>
                
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblPatent" runat="server" Width="100%"  Text="Patente"></asp:Label>
                            </td>
                        <td style="width: 20%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblInternalNumber" runat="server" Width="100%"  Text="N° interno"></asp:Label>
                            </td>
                        <td style="width: 10%"></td>
                    </tr>
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblPatentSelected" runat="server" Width="100%" ></asp:Label>
                            </td>
                        <td style="width: 20%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblInternalNumberSelected" runat="server" Width="100%" ></asp:Label>
                            </td>
                        <td style="width: 10%"></td>
                    </tr>
                </table>
                <br />
                <div runat="server" style="Width:100%" id="divAssets">
                   </div>
                <!--START-->
                
                <!--END-->
                
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                              </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%">
                            </td>
                        <td style="width: 60%; text-align: center">
                            <input type="button" value='Leer' style="width:100%" id="btnReadRfiTag" onclick='ReadTag();'/>
                        </td>
                        <td style="width: 20%">
                          <asp:Button ID="btnReadTag" runat="server" CssClass="Opacity" ClientIDMode="Static" OnClick="btnReadTag_Click" Text="Leer Tag" Width="1%" />
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="Opacity" Width="1%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%">
                            </td>
                        <td style="width: 60%; text-align: center">
                            <asp:Button ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Inventariar neumaticos" Width="100%" />
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Volver" Width="100%" />
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>

           


            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>

