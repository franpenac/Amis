<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnyObservationPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.AnyObservationPage" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/AmisAndroid.css" />
    <style>
        .ConfTable {
            padding: 0px;
            margin: 0px;
            border-collapse: collapse;
            width: 288px;
            height: 405px;
            -moz-background-size: 100% 100%; /* Gecko 1.9.2 (Firefox 3.6) */
            -o-background-size: 100% 100%; /* Opera 9.5 */
            -webkit-background-size: 100% 100%; /* Safari 3.0 */
            background-size: 100% 100%; /* Gecko 2.0 (Firefox 4.0) and other CSS3-compliant browsers */
            background-repeat: no-repeat;
        }

            .ConfTable td {
                border: 0px;
                padding: 0px;
                margin: 0px;
                width: 23px;
                height: 43px;
            }

        .centerDiv {
            position: absolute;
            top: 50%;
            left: 10%;
            top: 30%;
        }

        .imgHidden {
            background-image: url('/ig_common/configurations/TyreTransparent.png');
            background-repeat: no-repeat;
            width: 100%;
            height: 100%;
            opacity: 0;
            font-size: 0px;
            border: 0px;
            padding: 0px;
        }

        .imgInProgress {
            background-image: url('/ig_common/configurations/YellowTyre.png');
            background-repeat: no-repeat;
            width: 100%;
            height: 100%;
            opacity: 100;
            font-size: 0px;
            border: 0px;
            padding: 0px;
        }

        .imgWrongRequest {
            background-image: url('/ig_common/configurations/RedTyre.png');
            background-repeat: no-repeat;
            width: 100%;
            height: 100%;
            opacity: 100;
            font-size: 0px;
            border: 0px;
            padding: 0px;
        }

        .imgInspectionSuccessful {
            background-image: url('/ig_common/configurations/GreenTyre.png');
            background-repeat: no-repeat;
            width: 100%;
            height: 100%;
            opacity: 100;
            font-size: 0px;
            border: 0px;
            padding: 0px;
        }
    </style>
    <script type="text/javascript">
        function changeColor(td_id) {
            alert('id del td: ' + td_id);
        }
        function executeChange(divId) {
            PageMethods.changeColor(divId);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                                                <table style="width: 100%; border: solid" border="1">
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblTittle" runat="server" Width="100%" Text="Inspección" Font-Bold="true" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblPatent" runat="server" Width="100%" Text="Patente"></asp:Label>
                        </td>
                        <td style="width: 20%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblInternalNumber" runat="server" Width="100%" Text="N° interno"></asp:Label>
                        </td>
                        <td style="width: 10%"></td>
                    </tr>
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblPatentSelected" runat="server" Width="100%"></asp:Label>
                        </td>
                        <td style="width: 20%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblInternalNumberSelected" runat="server" Width="100%"></asp:Label>
                        </td>
                        <td style="width: 10%"></td>
                    </tr>
                </table>
                <br />
                <table style="width:100%">
                    <td style="width:20%"></td>
                    <td style="width:60%; text-align:center">
                        <asp:Label runat="server" ID="lblBadReason" Text="Indique la razón del mal estado del neumático"></asp:Label>
                    </td>
                    <td style="width:20%"></td>
                </table>
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:35%"></td>
                        <td style="width:30%">
                            <asp:DropDownList runat="server" ID="ddlAssetSituation" OnSelectedIndexChanged="ddlAssetSituation_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                        <td style="width:35%"></td>
                    </tr>
                </table>
                <br />
                                   <%-- Mpe remove?--%>
                <asp:Button ID="btnConfirmar" style="display:none" runat="server"/>
            <cc1:ModalPopupExtender ID="mpeNeedToRemove" runat="server" 
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
                                    <asp:Label ID="lblText" runat="server" Text="¿Necesita remover?"></asp:Label>
                                </td>
                                <td style="width: 20%"></td>
                            </tr>
                        </table>
                        <table id="Table6" runat="server" style="Width:100%">
                            <tr>
                                <td style="width: 20%"></td>
                                <td style="width: 60%; text-align:center">
                                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                                <td style="width:20%"></td>
                            </tr>
                        </table>

                        <table id="Table5" runat="server" style="Width:100%">
                            <tr>
                                <td style="width: 10%"></td>
                                <td style="width: 30%">
                                    <asp:Button ID="btnToScrapYes" runat="server" Text="Si" Width="100%" Height="20px" OnClick="btnToScrapYes_Click"/>
                                </td>
                                <td style="width: 20%"></td>
                                <td style="width: 30%">
                                    <asp:Button ID="btnToScrapNo" runat="server" Text="No" Width="100%" Height="20px" OnClick="btnToScrapNo_Click"/>
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
