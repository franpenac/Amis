<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectedInspectionAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.SelectedInspectionAndroidPage" %>


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
                            <h1>
                                <asp:Label ID="lblTittle" runat="server" Text="Inspección"></asp:Label></h1></td>
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
                <%--<table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                            <asp:Label ID="lblMessageForeman" runat="server" Width="100%" text="¿Otra inspección?"></asp:Label>
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
                        <td style="width:10%; text-align:center" id="Td1" runat="server">
                                </td>
                        <td style="width:15%; text-align:center" runat="server">
                            <asp:ImageButton ID="imgchkYe" OnClick="ImageButton1_Click" runat="server" Width="60px" Height="60px" ImageUrl="~/ig_common/images/unchecked.png" />
                                <br />
                            <label style="background-color:white"><h3>Si</h3></label>
                        </td>
                        <td style="width:10%; text-align:center" id="Td3" runat="server">
                                </td>
                        <td style="width:15%; text-align:center">
                            <asp:ImageButton ID="imgchkNo" OnClick="imgchkNo_Click" runat="server" Width="60px" Height="60px" ImageUrl="~/ig_common/images/unchecked.png" />
                            <br />
                            <label style="background-color:white"><h3>No</h3></label>
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
                            
                        </td><td style="width:30%;">
                            
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
                            <asp:ImageButton ID="imgchkSame" OnClick="imgchkSame_Click"  runat="server" Width="60px" Height="60px" ImageUrl="~/ig_common/images/unchecked.png" />
                                <br />
                            <label style="background-color:white"><h3>En la misma unidad</h3></label>
                        </td>
                        <td style="width:10%; text-align:center" id="Td5" runat="server">
                        </td>
                        <td style="width:15%; text-align:center">
                            <asp:ImageButton ID="imgchkOther" OnClick="imgchkOther_Click"  runat="server" Width="60px" Height="60px" ImageUrl="~/ig_common/images/unchecked.png" />
                                <br />
                            <label style="background-color:white"><h3>En otra unidad</h3></label>
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
                    </table>--%>
                    
                
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
                                    <asp:Button ID="btnConfirmarPoppup" runat="server" Text="Si" Width="100%" Height="20px" OnClick="btnConfirmarPoppup_Click"/>
                                </td>
                                <td style="width: 20%"></td>
                                <td style="width: 30%">
                                    <asp:Button ID="btnCancel" runat="server" Text="No" Width="100%" Height="20px" OnClick="btnCancel_Click"/>
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
                                    <asp:Label ID="Label4" runat="server" Text="¿Otra inspección?"></asp:Label>
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
                                    <asp:Button ID="btnConffirmAnotherReplace" runat="server" Text="Si" Width="100%" Height="20px" OnClick="btnConffirmAnotherReplace_Click"/>
                                </td>
                                <td style="width: 20%"></td>
                                <td style="width: 30%">
                                    <asp:Button ID="btnNoAnotherReplace" runat="server" Text="No" Width="100%" Height="20px" OnClick="btnNoAnotherReplace_Click"/>
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

