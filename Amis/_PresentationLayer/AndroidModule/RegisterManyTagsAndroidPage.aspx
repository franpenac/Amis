<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterManyTagsAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.RegisterManyTagsAndroidPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/AmisAndroid.css" />
    <style>
        .Opacity
        {
            opacity:0;
            width:1px;
        }
        .auto-style1 {
            width: 25%;
            height: 30px;
        }
    </style>
    <script type="text/javascript">

        var times = 0;
        var tags = '';
        var count = 0;
        var tm;

        function getControl(controlName) {
            return document.getElementById(controlName);
        }

        function StartReadTags()
        {
            var howMany = getControl('txtCountTimes').value;
            if (howMany != "") {
                ReadManyTag();
            }else
            {
                var btn = getControl('btnErrorCount');
                btn.click();
            }
        }

        function ReadManyTag()
        {
            document.getElementById('btnReadRfiTag').disabled = true;
            times = parseInt(getControl('txtCountTimes').value);
            count = 0;
            tags = '';
            AndroidInterface.androidRFIDTurnOn(true);
            var startDate = new Date();
            tm = setTimeout(addFoundTag, 500);
            endDate = new Date();
        }

        function addFoundTag() {

            var TAG = AndroidInterface.androidRFIDFindTag();
            if (TAG != "error") {
                if (!tags.includes(TAG)) {
                    count++;
                    tags = tags + TAG + ';';
                    getControl('txtContador').value = count.toString();
                }
                var endDate = new Date();
                if (count != times) {
                    tm = setTimeout(addFoundTag, 10);
                } else {
                    AndroidInterface.androidPlayTakeMeasurementBeep();
                    AndroidInterface.androidShowLog('YA LEYO TODOS LOS TAGS ' + count.toString());
                    getControl('txtTagsReady').value = tags;
                    document.getElementById('btnSaveTags').disabled = false;
                    clearTimeout(tm);
                    document.getElementById('btnReadRfiTag').disabled = false;
                }
            }else
            {
                turnOffRFID(tm);
                getControl('txtContador').value = '0';
                getControl('txtTagsReady').value = '';
                document.getElementById('btnSaveTags').disabled = false;
                var btn = getControl('btnSaveTags');
                btn.click();
            }
        }

        function soloNumeros(e) {

            if (window.event) {
                code = e.keyCode;
            } else {
                code = e.which;
            };
            if (code >= 48 && code <= 57) {
                return true;
            }
            event.preventDefault();
            return false;
        }

        function turnOffRFID()
        {
            clearTimeout(tm);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 100%; border:solid" border="1">
                    <tr>
                        <trs>
                            <td style="width: 100%; text-align: center">
                                <asp:Label ID="lblTittle" runat="server" Font-Bold="true" Font-Size="XX-Large" Text="Registro masivo de TAGS" Width="100%"></asp:Label>
                            </td>
                        </trs>
                    </tr>
                </table>
                <br />
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width:25%"></td>
                        <td style="width:25%">
                            <asp:Label runat="server" ID="lblHowManyTags" Text="Ingrese cantidad deseada "></asp:Label>
                        </td>
                        <td style="align-content: center; text-align: center">
                            <asp:TextBox runat="server" ID="txtCountTimes" Width="30%" ClientIDMode="Static" onKeyPress="return soloNumeros(event);"></asp:TextBox>
                        </td>
                        <td style="width:25%">
                            <asp:Button  runat="server" ID="btnErrorCount" ClientIDMode="Static" OnClick="btnErrorCount_Click" CssClass="Opacity"/>
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 25%"></td>
                        <td style="width: 25%">
                            <asp:Label runat="server" ID="lblReadCount" Text="Cantidad leidos "></asp:Label>
                        </td>
                        <td style="width: 25%; align-content: center; text-align: center">
                            <asp:TextBox runat="server" ID="txtContador" Width="30%" Enabled="false"></asp:TextBox>
                        </td>
                        <td style="width: 25%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 25%"></td>
                        <td style="width: 50%; align-content: center; text-align: center">
                            <asp:TextBox runat="server" ID="txtTagsReady" Width="100%" Enabled="false" CssClass="Opacity"></asp:TextBox>
                        </td>
                        <td style="width: 25%">
                        </td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <input type="button" value='Leer tags' style="width:100%" id="btnReadRfiTag" onclick="StartReadTags();"/>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Button runat="server" ID="btnSaveTags" Text="Registrar tags leidos" ClientIDMode="Static" Width="100%" OnClick="btnSaveTags_Click" Enabled="false"/>
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="width: 20%"></td>
                        <td style="width: 60%; text-align: center">
                            <asp:Button ID="btnBack" runat="server" Text="Fin de registro de TAGS" Width="100%" OnClick="btnBack_Click" />
                        </td>
                        <td style="width: 20%"></td>
                    </tr>
                </table>
                <br />
                                <%-- Mpe Ok--%>
                <asp:Button ID="btnOk" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeOk" runat="server"
                    TargetControlID="btnOk" CancelControlID="btnOk" OkControlID="btnOk"
                    PopupControlID="panOk">
                </cc1:ModalPopupExtender>
                <div id="panOk" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderOk">
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
                                            <asp:Label ID="Label21" runat="server" Text="No fue posible leer todos los tags solicitados, es necesario repetir la operacion completa."></asp:Label>
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
                                            <asp:Button ID="btnNoTyreOk" runat="server" Text="Entendido" Width="100%" Height="20px" OnClick="btnNoTyreOk_Click"/>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                                                <%-- Mpe Error Count--%>
                <asp:Button ID="btnErrorCounter" Style="display: none" runat="server" />
                <cc1:ModalPopupExtender ID="mpeErrorCount" runat="server"
                    TargetControlID="btnErrorCounter" CancelControlID="btnErrorCounter" OkControlID="btnErrorCounter"
                    PopupControlID="panErrorCount">
                </cc1:ModalPopupExtender>
                <div id="panErrorCount" class="popupPanelClass" style="display: none; height: 215px;">
                    <div class="popupContainerClass">
                        <div id="popupHeaderErrorCount">
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

                                <table id="Table2" style="width: 100%" runat="server">
                                    <tr>
                                        <td style="width: 40%"></td>
                                        <td style="width: 20%"></td>
                                        <td style="width: 40%"></td>
                                    </tr>
                                </table>

                                <table id="Table3" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label2" runat="server" Text="Verifique el valor ingresado en cantidad a leer."></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>
                                <table id="Table4" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%; text-align: center">
                                            <asp:Label ID="Label3" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td style="width: 20%"></td>
                                    </tr>
                                </table>

                                <table id="Table5" runat="server" style="width: 100%">
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td style="width: 60%">
                                            <asp:Button ID="btnErrorCountOk" runat="server" Text="Entendido" Width="100%" Height="20px" OnClick="btnErrorCountOk_Click"/>
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

