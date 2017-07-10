<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectionTyrePage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.SelectionTyrePage" Async="true" %>

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

        .btnRight {
            float: right;
        }

        .btnInv {
            opacity: 0;
            width: 1px;
        }
    </style>
    <script type="text/javascript">

        function getControl(controlName) {
            return document.getElementById(controlName);
        }

        function ReadTyreTag() {
            var button = getControl('btnReadRfiTag');
            button.disabled = true;
            AndroidInterface.androidRFIDTurnOn(true);
            getControl('txtTyreTag').value = '';
            var value = AndroidInterface.androidFindTagStrongSound();
            if (value != "error") {
                getControl('txtTyreTag').value = value;
                var button = getControl('btnReadTag');
                button.click();
            }else
            {
                var button = getControl('btnTagError');
                button.click();
            }
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
                        <td style="width: 10%">
                            <asp:Button runat="server" ID="btnReadTag" ClientIDMode="Static" OnClick="btnReadTag_Click" Text="Leer Tag" Enabled="false" CssClass="btnInv" />
                        </td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblPatentSelected" runat="server" Width="100%"></asp:Label>
                        </td>
                        <td style="width: 20%"></td>
                        <td style="width: 30%; text-align: center">
                            <asp:Label ID="lblInternalNumberSelected" runat="server" Width="100%"></asp:Label>
                        </td>
                        <td style="width: 10%">
                            <asp:Button  runat="server" ID="btnTagError" ClientIDMode="Static" CssClass="btnInv" OnClick="btnTagError_Click"/>
                        </td>
                    </tr>
                </table>
                <hr />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%">
                            <input type="button" runat="server" value='Leer tag' id="btnReadRfiTag" onclick='ReadTyreTag();' disabled="disabled" style="width: 100%" />
                        </td>
                        <td style="width: 50%">
                            <asp:TextBox runat="server" ID="txtTyreTag" CssClass="btnInv"></asp:TextBox>
                        </td>
                        <td style="width: 30%">
                            <asp:Button runat="server" ID="btnFinishInspection" Text="Finalizar Inspección" OnClick="btnFinishInspection_Click" CssClass="btnRight" />
                        </td>
                    </tr>
                </table>
                <table style="width:100%">
                    <tr>
                        <td style="width:20%"></td>
                        <td style="width:50%"></td>
                        <td style="width:30%">
                            <asp:Button  runat="server" ID="BtnCantReadTyreTag" Text="No se puede leer tag" CssClass="btnRight" OnClick="BtnCantReadTyreTag_Click" Enabled="false"/>
                        </td>
                    </tr>
                </table>
                <hr />
                <br />
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
                <%-- Mpe Any observation--%>
                <asp:Button ID="btnConfirmar" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeAnyObservation" runat="server"
                    TargetControlID="btnConfirmar" CancelControlID="btnConfirmar" OkControlID="btnConfirmar"
                    PopupControlID="panConfirmar">
                </cc1:ModalPopupExtender>
                <div id="panConfirmar" class="popupPanelClass" style="display: none; height: 215px;">
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
                            <div style="background-color: lightgray">

                                <table id="Table4" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table1" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="lblText" runat="server" Text="¿Alguna observación?"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table6" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table5" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 10%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnAnyObservationYes" runat="server" Text="Si" Width="100%" Height="20px" OnClick="btnAnyObservationYes_Click" />
                                        </td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnAnyObservationNo" runat="server" Text="No" Width="100%" Height="20px" OnClick="btnAnyObservationNo_Click" />
                                        </td>
                                        <td style="width: 10%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe Another inspection--%>
                <asp:Button ID="btnAnotherInspection" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeAnotherInspection" runat="server"
                    TargetControlID="btnAnotherInspection" CancelControlID="btnAnotherInspection" OkControlID="btnAnotherInspection"
                    PopupControlID="panAnotherInspection">
                </cc1:ModalPopupExtender>
                <div id="panAnotherInspection" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderAnotherInspection">
                            <div style="background-color: black;">
                                <asp:Table ID="Table11" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table12" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table13" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label6" runat="server" Text="El cambio en la misma unidad se realizó correctamente."></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table14" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label7" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table15" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%">
                                            <asp:Button ID="btnOk" runat="server" Text="Ok" Width="100%" Height="20px" OnClick="btnOk_Click" />
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe Another inspection--%>
                <asp:Button ID="btnAnotherInspection1" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeAnotherInspection1" runat="server"
                    TargetControlID="btnAnotherInspection1" CancelControlID="btnAnotherInspection1" OkControlID="btnAnotherInspection1"
                    PopupControlID="panAnotherInspection1">
                </cc1:ModalPopupExtender>
                <div id="panAnotherInspection1" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderAnotherInspection1">
                            <div style="background-color: black;">
                                <asp:Table ID="Table2" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table7" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table8" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label3" runat="server" Text="El cambio hacia otra unidad se realizó correctamente."></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table9" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label4" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table10" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%">
                                            <asp:Button ID="btnOk2" runat="server" Text="Ok" Width="100%" Height="20px" OnClick="btnOk2_Click" />
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe Finish incomplete inspection--%>
                <asp:Button ID="btnIncompleteInspection" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeIncompleteInspection" runat="server"
                    TargetControlID="btnIncompleteInspection" CancelControlID="btnIncompleteInspection" OkControlID="btnIncompleteInspection"
                    PopupControlID="panIncomplete">
                </cc1:ModalPopupExtender>
                <div id="panIncomplete" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderIncomplete">
                            <div style="background-color: black;">
                                <asp:Table ID="Table16" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label8" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table17" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table18" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label9" runat="server" Text="Sr. Usuario, ud. esta deteniendo un proceso de inspección sin revisar la totalidad de los neumáticos registrados en la unidad, se avisará a su supervisor de la situación, ¿Desea finalizar de todas formas?"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table19" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label10" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table20" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 10%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnYesFinishIncomplete" runat="server" Text="Si" Width="100%" Height="20px" OnClick="btnYesFinishIncomplete_Click" />
                                        </td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnNoFinishIncomplete" runat="server" Text="No" Width="100%" Height="20px" OnClick="btnNoFinishIncomplete_Click" />
                                        </td>
                                        <td style="width: 10%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe otra inspeccion--%>
                <asp:Button ID="btnOtherInspection" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeOtherInspection" runat="server"
                    TargetControlID="btnOtherInspection" CancelControlID="btnOtherInspection" OkControlID="btnOtherInspection"
                    PopupControlID="panOther">
                </cc1:ModalPopupExtender>
                <div id="panOther" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderOther">
                            <div style="background-color: black;">
                                <asp:Table ID="Table21" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label11" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table22" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table23" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label12" runat="server" Text="¿Otra inspección?"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table24" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label13" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table25" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 10%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnOtherYes" runat="server" Text="Si" Width="100%" Height="20px" OnClick="btnOtherYes_Click" />
                                        </td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnOtherNo" runat="server" Text="No" Width="100%" Height="20px" OnClick="btnOtherNo_Click" />
                                        </td>
                                        <td style="width: 10%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe same unit--%>
                <asp:Button ID="btnSameUnit" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeUnit" runat="server"
                    TargetControlID="btnSameUnit" CancelControlID="btnSameUnit" OkControlID="btnSameUnit"
                    PopupControlID="panUnit">
                </cc1:ModalPopupExtender>
                <div id="panUnit" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderUnit">
                            <div style="background-color: black;">
                                <asp:Table ID="Table26" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label14" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table27" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table28" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label15" runat="server" Text="¿En la misma unidad?"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table29" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label16" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table30" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 10%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnSameUnitYes" runat="server" Text="Si" Width="100%" Height="20px" OnClick="btnSameUnitYes_Click" />
                                        </td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnSameUnitNo" runat="server" Text="No" Width="100%" Height="20px" OnClick="btnSameUnitNo_Click" />
                                        </td>
                                        <td style="width: 10%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe Change warehouse ok--%>
                <asp:Button ID="btnChangeWarehouseOk" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeOkWarehouse" runat="server"
                    TargetControlID="btnChangeWarehouseOk" CancelControlID="btnChangeWarehouseOk" OkControlID="btnChangeWarehouseOk"
                    PopupControlID="panWarehouse">
                </cc1:ModalPopupExtender>
                <div id="panWarehouse" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderWarehouse">
                            <div style="background-color: black;">
                                <asp:Table ID="Table31" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label17" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table32" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table33" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label18" runat="server" Text="El cambio hacia una bodega se realizó correctamente."></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table34" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label19" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table35" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%">
                                            <asp:Button ID="btnOkW" runat="server" Text="Ok" Width="100%" Height="20px" OnClick="btnOkW_Click" />
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe dont exist tyre--%>
                <asp:Button ID="btnNoTyre" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeNoTyre" runat="server"
                    TargetControlID="btnNoTyre" CancelControlID="btnNoTyre" OkControlID="btnNoTyre"
                    PopupControlID="panNoTyre">
                </cc1:ModalPopupExtender>
                <div id="panNoTyre" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderNoTyre">
                            <div style="background-color: black;">
                                <asp:Table ID="Table36" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label20" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table37" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table38" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label21" runat="server" Text="No hay neumático asignado en la posición seleccionada."></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table39" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label22" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table40" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%">
                                            <asp:Button ID="btnNoTyreOk" runat="server" Text="Ok" Width="100%" Height="20px" OnClick="btnNoTyreOk_Click" />
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                                                                <%-- Mpe Error Tag--%>
                <asp:Button ID="btnErrorTag" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeErrorTag" runat="server"
                    TargetControlID="btnErrorTag" CancelControlID="btnErrorTag" OkControlID="btnErrorTag"
                    PopupControlID="panErrorTag">
                </cc1:ModalPopupExtender>
                <div id="panErrorTag" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderErrorTag">
                            <div style="background-color: black;">
                                <asp:Table ID="Table41" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label23" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table42" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table43" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label24" runat="server" Text="Error al leer el tag o el tiempo de espera se ha agotado, por favor intente nuevamente."></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table44" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label25" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table45" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%">
                                            <asp:Button ID="btnErrorTagOk" runat="server" Text="Entendido" Width="100%" Height="20px" OnClick="btnErrorTagOk_Click"/>
                                        </td>
                                        <td style="width: 20%"></td>
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
