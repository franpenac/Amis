<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="AssignedToUnitAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.AssignedToUnitAndroidPage" %>

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
            getControl('txbAssetRead').value = '';
            var value = AndroidInterface.androidFindTagStrongSound();
            getControl('txbAssetRead').value = value;
            var button = getControl('btnProcess');
            button.click();
        }
    </script>
</head>
<body style="border:solid">
    <form id="form1" runat="server">
        
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    
                    <asp:Timer ID="timer" runat="server" OnTick="timer_Tick"></asp:Timer>

                <table style="width:100%; border:solid">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <h1>
                                <asp:Label ID="lblTittle" runat="server" Text="Asignar Activo a Unidad"></asp:Label></h1></td>
                        <td style="width:20%">

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
                            <asp:Label ID="lblPatentSelected" runat="server" Width="100%" Visible="False"></asp:Label>
                            </td>
                        <td style="width: 20%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblInternalNumberSelected" runat="server" Width="100%" Visible="False"></asp:Label>
                            </td>
                        <td style="width: 10%"></td>
                    </tr>
                </table>
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Label ID="lblMessage" runat="server" Text="Activo a asignar"></asp:Label>
                        </td>
                        
                        <td style="width:20%">

                        </td>
                    </tr>
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:ImageButton ID="imgAssetType" runat="server" Width="60px" Height="60px"/>
                        </td>
                        
                        <td style="width:20%">

                        </td>
                    </tr>
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            
                        </td>
                        
                        <td style="width:20%">

                        </td>
                    </tr>
                    </table>
                    <table id="Error" runat="server" style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Button ID="btnProcess" runat="server" ClientIDMode="Static" CssClass="Opacity" OnClick="btnProcess_Click" Text="Button" />
                            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="txbAssetRead" runat="server" CssClass="Opacity" ></asp:TextBox>
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
                        <td style="width:60%; text-align:center">
                            <input type="button" value='Leer' style="width:100%" id="btnReadRfiTag" onclick='ReadTag();'/>
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
                        <td style="width:60%; text-align:center">
                            <asp:Button ID="btnAssigned" runat="server" Text="Asignar" Width="100%" OnClick="btnAssigned_Click" />
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
                        <td style="width:60%; text-align:center">
                            <asp:Button ID="btnBack" runat="server" Text="Volver" Width="100%" OnClick="btnBack_Click" />
                        </td>
                        <td style="width:20%">

                        </td>
                    </tr>
                </table>
                    

                                    <%-- Mpe--%>
                <asp:Button ID="btnConfirmar" style="display:none" runat="server"/>
            <cc1:ModalPopupExtender ID="mpeConfirmar" runat="server" 
                TargetControlID="btnConfirmar" CancelControlID="btnConfirmar" OkControlID="btnConfirmar"
                PopupControlID="panConfirmar">
            </cc1:ModalPopupExtender>
            <div id="panConfirmar" class="popupPanelClass" style="display:none; height:215px;">
                <div class="popupContainerClass">
                    <div id="popupHeaderConfirmar">
                        <div style="background-color: black;">
                        <asp:Table ID="Table3" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                            <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                    <div style="font-family: Arial; font-size: 20px">
                                        <asp:Label ID="Label1" runat="server" ForeColor="White" Text="Amis">
                                        </asp:Label>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        </div>
                        <div style="background-color:lightgray">

                        <table id="Table4" style="Width:100%" runat="server" >
                            <tr>
                                <td style="width: 40%"></td>
                                <td style="width: 20%"></td>
                                <td style="width: 40%"></td>
                            </tr>
                        </table>

                        <table id="Table1" runat="server" style="Width:100%">
                            <tr>
                                <td style="width: 20%"></td>
                                <td style="width: 60%; text-align:center">
                                    <asp:Label ID="lblText" runat="server" Text="¿En la misma unidad?"></asp:Label>
                                </td>
                                <td style="width: 20%"></td>
                            </tr>
                        </table>
                        <table id="Table6" runat="server" style="Width:100%">
                            <tr>
                                <td style="width: 20%"></td>
                                <td style="width: 60%; text-align:center">
                                    <asp:Label ID="Label2" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                                <td style="width:20%"></td>
                            </tr>
                        </table>

                        <table id="Table5" runat="server" style="Width:100%">
                            <tr>
                                <td style="width: 10%"></td>
                                <td style="width: 30%">
                                    <asp:Button ID="btnConfirmarPoppup" runat="server" Text="Si" Width="100%" Height="20px" OnClick="imgchkSame_Click"/>
                                </td>
                                <td style="width: 20%"></td>
                                <td style="width: 30%">
                                    <asp:Button ID="btnCancel" runat="server" Text="No" Width="100%" Height="20px" OnClick="imgchkOther_Click" />
                                </td>
                                <td style="width: 10%"></td>
                            </tr>
                        </table>
                        </div>
                    </div>
                </div>
            </div>
                <%-- Mpe Otro Cambio--%>
                <asp:Button ID="btnOtherReplace" style="display:none" runat="server"/>
            <cc1:ModalPopupExtender ID="mpeAnotherReplace" runat="server" 
                TargetControlID="btnOtherReplace" CancelControlID="btnOtherReplace" OkControlID="btnOtherReplace"
                PopupControlID="panReplace">
            </cc1:ModalPopupExtender>
            <div id="panReplace" class="popupPanelClass" style="display:none; height:215px;">
                <div class="popupContainerClass">
                    <div id="popupHeaderConfirmarReplace">
                        <div style="background-color: black;">
                        <asp:Table ID="Table2" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                            <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                    <div style="font-family: Arial; font-size: 20px">
                                        <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Amis">
                                        </asp:Label>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        </div>
                        <div style="background-color:lightgray">

                        <table id="Table7" style="Width:100%" runat="server" >
                            <tr>
                                <td style="width: 40%"></td>
                                <td style="width: 20%"></td>
                                <td style="width: 40%"></td>
                            </tr>
                        </table>

                        <table id="Table8" runat="server" style="Width:100%">
                            <tr>
                                <td style="width: 20%"></td>
                                <td style="width: 60%; text-align:center">
                                    <asp:Label ID="Label4" runat="server" Text="¿Otra asignación?"></asp:Label>
                                </td>
                                <td style="width: 20%"></td>
                            </tr>
                        </table>
                        <table id="Table9" runat="server" style="Width:100%">
                            <tr>
                                <td style="width: 20%"></td>
                                <td style="width: 60%; text-align:center">
                                    <asp:Label ID="Label5" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                                <td style="width:20%"></td>
                            </tr>
                        </table>

                        <table id="Table10" runat="server" style="Width:100%">
                            <tr>
                                <td style="width: 10%"></td>
                                <td style="width: 30%">
                                    <asp:Button ID="btnConffirmAnotherReplace" runat="server" Text="Si" Width="100%" Height="20px" OnClick="ImageButton1_Click"/>
                                </td>
                                <td style="width: 20%"></td>
                                <td style="width: 30%">
                                    <asp:Button ID="btnNoAnotherReplace" runat="server" Text="No" Width="100%" Height="20px" OnClick="imgchkNo_Click"/>
                                </td>
                                <td style="width: 10%"></td>
                            </tr>
                        </table>
                        </div>
                    </div>
                </div>
            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        
    </form>
</body>
</html>

