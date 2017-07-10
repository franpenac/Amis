<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeassurementTyrePage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.MeassurementTyrePage" Async="true" %>

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
        .btnCancel {
            background-image: url('/ig_common/images/cancel16x16.png');
            background-repeat: no-repeat;
            width: 20px;
            height: 20px;
            font-size: 0px;
        }

        .buttonExport {
            visibility: hidden;
        }

        .imgPosition {
            float: initial;
        }

        .divContainer {
            position: relative;
            width: 70%;
            height: 100%;
            margin: 0 auto;
        }

        .divButtonLeft {
            width: 50%;
            height: 100%;
            float: left;
        }

        .divButtonRight {
            width: 50%;
            height: 100%;
            float: right;
        }

        .btnP {
            opacity: 0;
            width:1px;
        }

        .btnPressure {
            float: right;
            width: 100px;
        }

        .chkAutoInflate {
            float: right;
        }
        .lblChkAutoInflate
        {
            float:left;
        }
    </style>

    <script type="text/javascript">

        function getControl(controlName) {
            return document.getElementById(controlName);
        }

        function androidFindProbe() {
            AndroidInterface.androidShowMessage('Conectando IProbe...');
            AndroidInterface.androidFindProbe();
        }

        function takeMeasurements() {
            var button2 = getControl('btnDepthMeassurement');
            button2.disabled = true;
            AndroidInterface.androidShowMessage('Por favor comenzar a medir profundidad.');
            ////////////
            //getControl('txtMeassureDepth0').value = '';
            //getControl('txtMeassureDepth1').value = '';
            //getControl('txtMeassureDepth2').value = '';
            //getControl('txtMeassureDepth3').value = '';
            //getControl('txtMeassureDepth4').value = '';
            //getControl('txtMeassureDepth5').value = '';
            //getControl('txtMeassureDepth6').value = '';
            //getControl('txtMeassureDepth7').value = '';
            //getControl('txtMeassureDepth8').value = '';
            //getControl('txtMeassureDepth9').value = '';
            //var count = parseInt(getControl('txtDepthNumber').value);
            /////////////////
            var values = AndroidInterface.androidGetSeveralTreadDepthMeasurement(3);

            if (values[0].indexOf('error') == -1 && values[1].indexOf('error') == -1 && values[2].indexOf('error') == -1) {

                getControl('txtMeassureDepth0').value = values.split('/')[0];
                getControl('txtMeassureDepth1').value = values.split('/')[1];
                getControl('txtMeassureDepth2').value = values.split('/')[2];
                AndroidInterface.androidShowMessage('Se terminó de medir profundidad.');
                var button1 = getControl('btnPressureMeassurement');
                button1.disabled = false;
                var button2 = getControl('btnDepthMeassurement');
                button2.disabled = true;
                var button = getControl('btnDoDepth');
                button.click();
            } else
            {
                var button2 = getControl('btnDepthMeassurement');
                button2.disabled = false;
                var button = getControl('btnDepthErrorControl');
                button.click();
            }
            ////////////////////
            //for (var i = 0; i < count; i++) {

            //    if(values[i].indexOf('error') == -1)
            //    {
            //        getControl('txtMeassureDepth'.concat(i.toString())).value = values.split('/')[i];

            //    } else
            //    {
            //        var button2 = getControl('btnDepthMeassurement');
            //            button2.disabled = false;
            //            var button = getControl('btnDepthErrorControl');
            //            button.click();
            //            break;
            //    }
            //}
            //for (var i = count; i < 10; i++) {

            //    if (i < 11) {
            //          getControl('txtMeassureDepth'.concat(i.toString())).value = 0;
            //    }       
            //}
            //AndroidInterface.androidShowMessage('Se terminó de medir profundidad.');
            //var button1 = getControl('btnPressureMeassurement');
            //button1.disabled = false;
            //var button2 = getControl('btnDepthMeassurement');
            //button2.disabled = true;
            //var button = getControl('btnDoDepth');
            //button.click();
            ///////////////////
        }

        function takePressure() {
            var button1 = getControl('btnPressureMeassurement');
            button1.disabled = true;
            AndroidInterface.androidShowMessage('Por favor comenzar a medir presión.');
            getControl('txtMeassurementPressure').value = '';
            var values = AndroidInterface.androidGetSeveralPressureMeasurement(1);
            if (values[0].indexOf('error') == -1) {
                getControl('txtMeassurementPressure').value = values.split('/')[0];
                AndroidInterface.androidShowMessage('Se terminó de medir presión');
                var button = getControl('btnDoPressureMethod');
                button.click();
            }else
            {
                var button1 = getControl('btnPressureMeassurement');
                button1.disabled = false;
                var button = getControl('btnErrorPressureController');
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
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtDepthNumber" CssClass="btnP"></asp:TextBox>
                        </td>
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
                <hr />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 30%">
                            <input type='button' value='Conectar Probe' id="btnConnectProbe" style="float: left" onclick='androidFindProbe();' />
                        </td>
                        <td style="width: 40%"></td>
                        <td style="width: 30%">
                            <input type='button' runat="server" value='Medir Profundidad' id="btnDepthMeassurement" onclick='takeMeasurements();' class="btnPressure" style="width: 100%" />
                        </td>
                    </tr>
                </table>
                <hr />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%">
                            <asp:Button runat="server" ID="btnDepthErrorControl" CssClass="btnP" ClientIDMode="Static" OnClick="btnDepthErrorControl_Click"/>
                        </td>
                        <td style="width: 80%">
                            <asp:Label runat="server" Text="Medición de Profundidad"></asp:Label></td>
                        <td style="width: 10%"></td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%">
                            <asp:Button runat="server" ID="btnDoDepth" CssClass="btnP" ClientIDMode="Static" Width="1px" OnClick="btnDoDepth_Click" />
                        </td>
                        <td style="width: 70%">
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtMeassureDepth0" AutoPostBack="true" Width="35px" Enabled="false"></asp:TextBox>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtMeassureDepth1" AutoPostBack="true" Width="35px" Enabled="false"></asp:TextBox>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="txtMeassureDepth2" AutoPostBack="true" Width="35px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 20%">
                            <asp:Button runat="server" ID="btnCancelMeassureDepth" CssClass="btnCancel" OnClick="btnCancelMeassureDepth_Click" Width="20px" />
                        </td>
                    </tr>
                </table>
                <hr />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 40%"></td>
                        <td style="width: 30%">
                            <input type='button' value='Medir Presión' runat="server" id="btnPressureMeassurement" onclick="takePressure();" class="btnPressure" style="width: 100%" disabled="disabled" />
                        </td>
                    </tr>
                </table>
                <hr />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%">
                            <asp:Button runat="server" ID="btnErrorPressureController" CssClass="btnP" ClientIDMode="Static" OnClick="btnErrorPressureController_Click"/>
                        </td>
                        <td style="width: 80%">
                            <asp:Label runat="server" Text="Medición de Presión"></asp:Label></td>
                        <td style="width: 10%"></td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 30%">
                            <asp:CheckBox runat="server" ID="ChkAutoInflate" CssClass="chkAutoInflate" />
                        </td>
                        <td style="width: 30%">
                            <asp:Label runat="server" ID="lblChkAutoInflate" Text="Autoinflado" CssClass="lblChkAutoInflate"></asp:Label>
                        </td>
                        <td style="width: 40%"></td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%">
                            <asp:Button runat="server" ID="btnDoPressureMethod" Width="1px" ClientIDMode="Static" OnClick="btnDoPressureMethod_Click" CssClass="btnP" />
                        </td>
                        <td style="width: 70%">
                            <asp:TextBox runat="server" ID="txtMeassurementPressure" ClientIDMode="Static" AutoPostBack="true" Width="40px" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 20%">
                            <asp:Button runat="server" ID="btnCancelMeassurementPressure" CssClass="btnCancel" OnClick="btnCancelMeassurementPressure_Click" />
                        </td>
                    </tr>
                </table>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 10%"></td>
                        <td style="width: 80%">
                            <asp:Label runat="server" ID="countTimes" Font-Size="Small"></asp:Label>
                        </td>
                        <td style="width: 10%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 30%">
                            <asp:Button runat="server" ID="btnFinishMeassurement" Text="Finalizar mediciones" OnClick="btnFinishMeassurement_Click" Visible="false" />
                        </td>
                        <td style="width: 40%"></td>
                        <td style="width: 30%">
                            <asp:Button runat="server" ID="btnNext" Text="Continuar" Visible="false" OnClick="btnNext_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                 <%-- Mpe send to remove--%>
                <asp:Button ID="btnSendToRemove" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeToScrapt" runat="server"
                    TargetControlID="btnSendToRemove" CancelControlID="btnSendToRemove" OkControlID="btnSendToRemove"
                    PopupControlID="panSendToRemove">
                </cc1:ModalPopupExtender>
                <div id="panSendToRemove" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderConfirmar">
                            <div style="background-color: black;">
                                <asp:Table ID="Table27" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label15" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table28" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table29" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="lblText" runat="server" Text="¿Enviar a remover?"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table30" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table31" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 10%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnAnyObservationYes" runat="server" Text="Si" Width="100%" Height="20px" OnClick="wibYesToScrap_Click"/>
                                        </td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnAnyObservationNo" runat="server" Text="No" Width="100%" Height="20px"  OnClick="wibNotToScrap_Click"/>
                                        </td>
                                        <td style="width: 10%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe Another inspection--%>
                <asp:Button ID="btnAnotherInspection1" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeOk" runat="server"
                    TargetControlID="btnAnotherInspection1" CancelControlID="btnAnotherInspection1" OkControlID="btnAnotherInspection1"
                    PopupControlID="panAnotherInspection1">
                </cc1:ModalPopupExtender>
                <div id="panAnotherInspection1" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderAnotherInspection1">
                            <div style="background-color: black;">
                                <asp:Table ID="Table4" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Amis">
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
                                            <asp:Label ID="Label5" runat="server" Text="Proceso de medición finalizado."></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table9" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label6" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table10" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 30%"></td>
                                        <td style="width: 40%">
                                            <asp:Button ID="btnOkMeassurement" runat="server" Text="Ok" Width="100%" Height="20px" OnClick="btnOkMeassurement_Click" />
                                        </td>
                                        <td style="width: 30%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe cancell depth meassurement--%>
                <asp:Button ID="btnCancelDepthMeassurement" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeCancellDepthMeassurement" runat="server"
                    TargetControlID="btnCancelDepthMeassurement" CancelControlID="btnCancelDepthMeassurement" OkControlID="btnCancelDepthMeassurement"
                    PopupControlID="panCancelDepth">
                </cc1:ModalPopupExtender>
                <div id="panCancelDepth" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderCancelDepth">
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
                                            <asp:Label ID="Label12" runat="server" Text="¿Seguro que desea cancelar el proceso de medición de profundidad?"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table24" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="lblDepthCancel" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table25" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 10%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnYesCancelDepthMeassurement" runat="server" Text="Si" Width="100%" Height="20px" OnClick="btnYesCancelDepthMeassurement_Click" />
                                        </td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnNoCancelDepthMeassurement" runat="server" Text="No" Width="100%" Height="20px" OnClick="btnNoCancelDepthMeassurement_Click" />
                                        </td>
                                        <td style="width: 10%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe cancell pressure meassurement--%>
                <asp:Button ID="btnCancelPressureMeassurement" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeCancelPressureMeassurement" runat="server"
                    TargetControlID="btnCancelPressureMeassurement" CancelControlID="btnCancelPressureMeassurement" OkControlID="btnCancelPressureMeassurement"
                    PopupControlID="panCancelPressure">
                </cc1:ModalPopupExtender>
                <div id="panCancelPressure" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderCancelPre">
                            <div style="background-color: black;">
                                <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
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

                                <table id="Table5" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table6" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label7" runat="server" Text="¿Seguro que desea cancelar el proceso de medición de presión?"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table11" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="lblPressureCancelled" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table12" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 10%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnYesCancelPressureMeassurement" runat="server" Text="Si" Width="100%" Height="20px" OnClick="btnYesCancelPressureMeassurement_Click" />
                                        </td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 30%">
                                            <asp:Button ID="btnNoCancelPressureMeassurement" runat="server" Text="No" Width="100%" Height="20px" OnClick="btnNoCancelPressureMeassurement_Click" />
                                        </td>
                                        <td style="width: 10%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe Error AutoInflate--%>
                <asp:Button ID="btnErrorAutoInflate" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeErrorAutoInflate" runat="server"
                    TargetControlID="btnErrorAutoInflate" CancelControlID="btnErrorAutoInflate" OkControlID="btnErrorAutoInflate"
                    PopupControlID="panErrorAutoInflate">
                </cc1:ModalPopupExtender>
                <div id="panErrorAutoInflate" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderErrorAutoInflate">
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
                                            <asp:Label ID="lblErrorAutoinflate" runat="server"></asp:Label>
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
                                            <asp:Button ID="btnErrorAutoinflateOk" runat="server" Text="Entendido" Width="100%" Height="20px" OnClick="btnErrorAutoinflateOk_Click"/>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe Error depth meassurement--%>
                <asp:Button ID="btnErrorDepth" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeErrorDepthController" runat="server"
                    TargetControlID="btnErrorDepth" CancelControlID="btnErrorDepth" OkControlID="btnErrorDepth"
                    PopupControlID="panErrorDepth">
                </cc1:ModalPopupExtender>
                <div id="panErrorDepth" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderErrorDepth">
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

                                <table id="Table13" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table14" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label8" runat="server" Text="Error al medir profundidad, por favor vuelva a medir."></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table15" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label9" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table16" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%">
                                            <asp:Button ID="btnErrorDepthOk" runat="server" Text="Entendido" Width="100%" Height="20px" OnClick="btnErrorDepthOk_Click"/>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- Mpe Error pressure meassurement--%>
                <asp:Button ID="btnPressureErrorController" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeErrorPressureController" runat="server"
                    TargetControlID="btnPressureErrorController" CancelControlID="btnPressureErrorController" OkControlID="btnPressureErrorController"
                    PopupControlID="panErrorPressure">
                </cc1:ModalPopupExtender>
                <div id="panErrorPressure" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderErrorPressure">
                            <div style="background-color: black;">
                                <asp:Table ID="Table17" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
                                    <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                        <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                            <div style="font-family: Arial; font-size: 20px">
                                                <asp:Label ID="Label10" runat="server" ForeColor="White" Text="Amis">
                                                </asp:Label>
                                            </div>
                                        </asp:TableHeaderCell>
                                    </asp:TableHeaderRow>
                                </asp:Table>
                            </div>
                            <div style="background-color: lightgray">

                                <table id="Table18" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table19" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label13" runat="server" Text="Error al medir presión, por favor vuelva a medir."></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table20" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label14" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table26" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%">
                                            <asp:Button ID="btnErrorPressureOk" runat="server" Text="Entendido" Width="100%" Height="20px" OnClick="btnErrorPressureOk_Click"/>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                 <%-- Mpe Error pressure meassurement--%>
                <asp:Button ID="btnErrorPressure" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeErrorPressure" runat="server"
                    TargetControlID="btnErrorPressure" CancelControlID="btnErrorPressure" OkControlID="btnErrorPressure"
                    PopupControlID="panErrorPressureMeassurement">
                </cc1:ModalPopupExtender>
                <div id="panErrorPressureMeassurement" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderErrorPressureMeassurement">
                            <div style="background-color: black;">
                                <asp:Table ID="Table3" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="100%">
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
                                            <asp:Label ID="lblErrorPressureMeassurement" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table34" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label17" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table35" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%">
                                            <asp:Button ID="btnErrorPressureMeassurementOk" runat="server" Text="Entendido" Width="100%" Height="20px" OnClick="btnErrorPressureMeassurementOk_Click"/>
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
