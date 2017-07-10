<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventoryTyreAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.InventoryTyreAndroidPage" %>

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
        .Opacity
        {
            opacity:0;
        }
    </style>
    <script type="text/javascript">
        function changeColor(td_id) {
            alert('id del td: ' + td_id);
        }
        function executeChange(divId) {
            PageMethods.changeColor(divId);
        }
        function getControl(controlName) {
            return document.getElementById(controlName);
        }

        function ReadTag() {
            AndroidInterface.androidRFIDTurnOn(true);
            getControl('txtTyreTag').value = '';
            var value = AndroidInterface.androidFindTagStrongSound();
            getControl('txtTyreTag').value = value;
            var button = getControl('btnReadTag');
            button.click();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
             <table style="width: 100%; border:solid" border="1">
                    <tr>
                        <td style="width: 100%; text-align: center">
                            <asp:Label ID="lblTittle" runat="server" Width="100%" Text="Inventario" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblPatentTitle" CssClass="CssSubTitle" runat="server" Text="Patente: "></asp:Label>
                            </td>
                        <td style="width: 20%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblInternalNumberTitle" CssClass="CssSubTitle" runat="server" Text="N° Interno: "></asp:Label>
                            </td>
                        <td style="width: 10%"></td>
                    </tr>
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label runat="server" ID="lblPatent"></asp:Label>
                            </td>
                        <td style="width: 20%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label runat="server" ID="lblInternalNumber"></asp:Label>
                            </td>
                        <td style="width: 10%"></td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 35%"></td>
                        <td style="width: 30%">
                            <table runat="server" id="imgTable" class="ConfTable">
                                <tr runat="server" id="r1">
                                    <td runat="server">
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0101" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0102" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0103" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0104" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0105" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0106" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0107" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0108" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0109" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0110" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0111" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0112" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                </tr>
                                <tr runat="server" id="r2">
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0201" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0202" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0203" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0204" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0205" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0206" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0207" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0208" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0209" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0210" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0211" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0212" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                </tr>
                                <tr runat="server" id="r3">
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0301" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0302" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0303" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0304" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0305" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0306" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0307" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0308" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0309" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0310" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0311" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0312" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                </tr>
                                <tr runat="server" id="r4">
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0401" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0402" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0403" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0404" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0405" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0406" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0407" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0408" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0409" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0410" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0411" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0412" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                </tr>
                                <tr runat="server" id="r5">
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0501" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0502" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0503" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0504" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0505" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0506" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0507" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0508" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0509" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0510" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0511" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0512" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                </tr>
                                <tr runat="server" id="r6">
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0601" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0602" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0603" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0604" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0605" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0606" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0607" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0608" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0609" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0610" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0611" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0612" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                </tr>
                                <tr runat="server" id="r7">
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0701" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0702" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0703" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0704" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0705" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0706" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0707" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0708" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0709" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0710" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0711" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0712" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                </tr>
                                <tr runat="server" id="r8">
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0801" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0802" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0803" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0804" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0805" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0806" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0807" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0808" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0809" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0810" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0811" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0812" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                </tr>
                                <tr runat="server" id="r9">
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0901" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0902" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0903" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0904" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0905" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0906" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0907" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0908" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0909" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0910" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0911" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                    <td>
                                        <div runat="server" style="width: 23px; height: 44px">
                                            <asp:Button ID="btn0912" runat="server" OnClick="imgbtn_Click" CssClass="imgHidden" Enabled="false" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="width: 35%"></td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                          <input type="button" value='Leer' style="width:100%" id="btnReadRfiTag" onclick='ReadTag();'/>   
                        </td>
                        <td style="width:20%">
                            <asp:Button runat="server" ID="btnReadTag" Width="1%" CssClass="Opacity" ClientIDMode="Static" OnClick="btnReadTag_Click" Text="Leer Tag" />
                            <asp:TextBox runat="server" ID="txtTyreTag" Width="1%" CssClass="Opacity"></asp:TextBox>

                        </td>
                    </tr>
                </table>
                <br />
                <table style="width:100%">
                    <tr>
                        <td style="width:20%">

                        </td>
                        <td style="width:60%; text-align:center">
                             <asp:Button runat="server" ID="btnNext" Width="100%" OnClick="btnNext_Click" Text="Fin Inventario" Enabled="true" />


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
