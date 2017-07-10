<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnitRegisterPage.aspx.cs" Inherits="amis._PresentationLayer.Configuration.UnitRegisterPage" %>

<%@ Register Assembly="Infragistics45.WebUI.WebSchedule.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">
    <style>
        .buttonExport {
            visibility:hidden;
        }
        .auto-style1 {
            width: 44px;
        }
    </style>
    <script type="text/javascript" id="igClientScript">
<!--

function wmePatentNumber_Blur(sender, eventArgs)
{
	///<summary>
	///
	///</summary>
	///<param name="sender" type="Infragistics.Web.UI.WebTextEditor"></param>
	///<param name="eventArgs" type="Infragistics.Web.UI.EventArgs"></param>

    //Add code to handle your event here.
    var value = document.getElementById('wmePatentNumber').value;
    document.getElementById('wmePatentNumber').value = value.toString().toUpperCase();
}


function wibExportExcel_Click(oButton, oEvent) {
    document.getElementById('wibExportTableToExcel').click();
}

function wdgMain_Selection_CellSelectionChanged_Delete(sender, eventArgs)
{
    var grid = $find("wdgMain");
    var gridBehaviors = grid.get_behaviors();
    var row = gridBehaviors.get_selection().get_selectedRows().getItem(0);
    var cell = gridBehaviors.get_selection().get_selectedCells().getItem(0);
    var index = cell.get_index();

    if (index == 0) {
        var row = gridBehaviors.get_selection().get_selectedCells().getItem(0).get_row(0);
        var index = row.get_index();
        __doPostBack('<%= wdgMain.ClientID %>', 'wdgDelete;' + index);
    }
    else {
        var row = gridBehaviors.get_selection().get_selectedCells().getItem(0).get_row(0);
        var index = row.get_index();
        __doPostBack('<%= wdgMain.ClientID %>', 'wdgMain;' + index);
    }
}

        function textbox_number_onkeypress(e) {

            if (window.event) {
                code = e.keyCode;
            } else {
                code = e.which;
            };
            if (code >= 48 && code <= 57) {
                return true;
            }

            if (code == 107 || code == 46 || code == 45) {
                return true;
            }

            event.preventDefault();
            return false;
        }
    

// -->
</script></asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 10px">
                </br></br></br><h1 id="h1OptionMenuPageName" runat="server">
                    Registro de Unidades
                </h1>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <table >
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblUnitType" runat="server" Text="Tipo de Unidad"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">
                            <ig:WebDropDown ID="wddUnitType" runat="server" Width="280px" OnSelectionChanged="wddUnitType_SelectionChanged" AutoSelectOnMatch="False">
                                <AutoPostBackFlags SelectionChanged="On" />
                            </ig:WebDropDown>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblPatentNumber" runat="server" Text="Patente"></asp:Label>
                                </div>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <table>
                                <tr>
                                    <td>
                                        <ig:WebMaskEditor ID="wmePatentNumber" ClientIDMode="Static" runat="server" InputMask="AA-AA-AA" Width="150px">
                                            <ClientEvents Blur="wmePatentNumber_Blur" />
                                        </ig:WebMaskEditor>
                                    </td>
                                    <td>
                                        <div style="font-family: Arial; font-size: 13px">
                                            &nbsp;&nbsp;&nbsp;Ejemplo: BR-JT-56
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblUnitName" runat="server" Text="Nombre Unidad"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">
                            <ig:WebTextEditor ID="wteUnitName" runat="server" Width="300px">
                            </ig:WebTextEditor>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblConfigurationUnitType" runat="server" Text="Configuración"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <ig:WebDropDown ID="wddConfigurationUnitType" runat="server" Width="310px" OnSelectionChanged="wddConfigurationUnitType_SelectionChanged">
                                <AutoPostBackFlags SelectionChanged="On" />
                            </ig:WebDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblInternalNumber" runat="server" Text="Número Interno"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">
                            <ig:WebTextEditor ID="wteInternalNumber" runat="server" Width="300px"></ig:WebTextEditor>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top;" colspan="3" rowspan="12">
                            <table style="border: 1px solid #98BAE0;" align="center">
                                <tr>
                                    <td id="tdLefArrow" onclick="imbLeftArrow.click();" runat="server" style="cursor: pointer; border: 1px solid #98BAE0; background: #E3E7EA">
                                        <asp:ImageButton ID="imbLeftArrow" ClientIDMode="Static" ImageUrl="~/ig_common/images/left_row.png" runat="server" OnClick="imbLeftArrow_Click" />
                                    </td>
                                    <td>
                                        <asp:Image ID="imgConfigurationImage" Width="135px" runat="server" ImageUrl="~/ig_common/configurations/blank_configuration.png" />
                                    </td>
                                    <td id="tdRightArrow" onclick="imbRightArrow.click();" runat="server" style="cursor: pointer; border: 1px solid #98BAE0; background: #E3E7EA">
                                        <asp:ImageButton ID="imbRightArrow" ClientIDMode="Static" ImageUrl="~/ig_common/images/right_row.png" runat="server" OnClick="imbRightArrow_Click" />
                                    </td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblSuspensionType" runat="server" Text="Tipo de Suspensión"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">
                            <ig:WebDropDown ID="wddSuspensionType" runat="server" Width="280px" AutoSelectOnMatch="False">
                            </ig:WebDropDown>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblKilometersOfTravel" runat="server" Text="Kilometraje inicial"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top"></td>
                        <td style="vertical-align: top">
                            <asp:TextBox ID="wneKilometersOfTrave" Width="80px" onkeyPress="return textbox_number_onkeypress(event);" runat="server"></asp:TextBox>
                        </td>
                        <td style="vertical-align: top"></td>
                        <td style="vertical-align: top; ">
                            <div style="font-family: Arial; font-size: 13px; text-align: right">
                                <asp:Label ID="lblUnitTara" runat="server" Text="Kg Tara"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top"></td>
                        <td style="vertical-align: top;" >
                            <ig:WebNumericEditor ID="wneUnitTara" Width="80px" runat="server" DataMode="Int" MinValue="0" Nullable="False" NullText="0" NullValue="0"></ig:WebNumericEditor>
                        </td>
                        <td style="vertical-align: top"></td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblVin" runat="server" Text="Vin"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">
                            <ig:WebTextEditor ID="wteVin" runat="server" Width="300px"></ig:WebTextEditor>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblNewOrUsed" runat="server" Text="Nuevo o Usado"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">
                            <ig:WebDropDown ID="wddNewOrUsed" runat="server" Width="280px" AutoSelectOnMatch="False">
                                <AutoPostBackFlags SelectionChanged="On" />
                                <Items>
                                    <ig:DropDownItem Key="NewOrUsed" Selected="False" Text="" Value="0">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Key="NewOrUsed" Selected="False" Text="Nuevo" Value="N">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Key="NewOrUsed" Selected="False" Text="Usado" Value="U">
                                    </ig:DropDownItem>
                                </Items>
                            </ig:WebDropDown>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblUnitManufacturingYear" runat="server" Text="Año de Fabricación"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <asp:TextBox ID="wteUnitManufacturingYea" Width="80px" onkeyPress="return textbox_number_onkeypress(event);" runat="server"></asp:TextBox>

                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top; " class="auto-style1">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblUnitPurchaseDate" runat="server" Text="Fecha Compra"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top; text-align: right;">
                            <ig:WebDatePicker ID="wdpUnitPurchaseDate" DropDownCalendarID="wmcCalendar" runat="server" Nullable="true" Width="100px" DisplayModeFormat="dd/MM/yyyy"></ig:WebDatePicker>
                            <ig:WebMonthCalendar runat="server" ID="wmcCalendar" EnableWeekNumbers="true"
                                ChangeMonthToDateClicked="true" EnableMonthDropDown="True" EnableYearDropDown="True">
                            </ig:WebMonthCalendar>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="Label9" runat="server" Text="Dueño"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">
                            <ig:WebDropDown ID="wddMember" runat="server" Width="300px">
                                <AutoPostBackFlags SelectionChanged="On" />
                            </ig:WebDropDown>
                            </td>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="Label11" runat="server" Text="Marca"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top" colspan="5">
                            <ig:WebDropDown ID="wddBrand" runat="server" AutoSelectOnMatch="False"  Width="280px" OnSelectionChanged="wddBrand_SelectionChanged">
                                <AutoPostBackFlags SelectionChanged="On" />
                            </ig:WebDropDown>
                        </td>
                        </tr>
                        <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="Label1" runat="server" Text="Vencimiento de revisión técnica"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">
                          <ig:WebDatePicker ID="wdpTechnicalReview" runat="server" DisplayModeFormat="dd/MM/yyyy" DropDownCalendarID="TechnicalReview"></ig:WebDatePicker>
                            <ig:WebMonthCalendar runat="server" ID="TechnicalReview" EnableWeekNumbers="true"
                                ChangeMonthToDateClicked="true" EnableMonthDropDown="True" EnableYearDropDown="True">
                            </ig:WebMonthCalendar>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="Label10" runat="server" Text="Modelo"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top" colspan="5">
                            <ig:WebDropDown ID="wddModel" runat="server" AutoSelectOnMatch="False" Width="280px" OnSelectionChanged="wddModel_SelectionChanged">
                                <AutoPostBackFlags SelectionChanged="On" />
                            </ig:WebDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="Label2" runat="server" Text="Proxima habilitación"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">
                          <ig:WebDatePicker ID="wdpQuality" runat="server" DropDownCalendarID="Quality" DisplayModeFormat="dd/MM/yyyy" ></ig:WebDatePicker>
                            <ig:WebMonthCalendar runat="server" ID="Quality" EnableWeekNumbers="true"
                                ChangeMonthToDateClicked="true" EnableMonthDropDown="True" EnableYearDropDown="True">
                            </ig:WebMonthCalendar>
                            </td>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="Label12" runat="server" Text="Servicio"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top" colspan="5">
                            <ig:WebDropDown ID="wddService" runat="server" AutoSelectOnMatch="False" Width="280px" OnSelectionChanged="wddService_SelectionChanged">
                                <AutoPostBackFlags SelectionChanged="On" />
                            </ig:WebDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="Label4" runat="server" Visible="false" Text="Vencimiento licencia de conducir"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="5">
                            <ig:WebDatePicker ID="wdpDriveLicence" Visible="false" runat="server" DropDownCalendarID="DriveLicence" DisplayModeFormat="dd/MM/yyyy"></ig:WebDatePicker>
                            <ig:WebMonthCalendar runat="server" Visible="false" ID="DriveLicence" EnableWeekNumbers="true"
                                ChangeMonthToDateClicked="true" EnableMonthDropDown="True" EnableYearDropDown="True">
                            </ig:WebMonthCalendar>
                            </td>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="Label7" runat="server" Text="Procedencia"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top" colspan="5">
                            <ig:WebDropDown ID="wddOrigin" runat="server" AutoSelectOnMatch="False"  Width="280px">
                                <AutoPostBackFlags SelectionChanged="On" />
                            </ig:WebDropDown>
                        </td>
                    </tr>
                </table>
            </div>
            <table >
                <tr>
                    <td runat="server" id="tdSave">
                        <igtxt:WebImageButton ID="wibSave" runat="server" Text="Grabar" Width="134px" Height="30px" OnClick="wibSave_Click">
                            <Appearance>
                                <Image Url="/ig_common/images/save16x16.png" />
                                <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                </ButtonStyle>
                            </Appearance>
                        </igtxt:WebImageButton>
                    </td>
                    <td></td>
                    <td runat="server" id="tdNew">
                        <igtxt:WebImageButton ID="wibNew" runat="server" Text="Nuevo" Width="134px" Height="30px" OnClick="wibNew_Click">
                            <Appearance>
                                <Image Url="/ig_common/images/new16x16.png" />
                                <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                </ButtonStyle>
                            </Appearance>
                        </igtxt:WebImageButton>
                    </td>
                    <td></td>
                    <td runat="server" id="tdExportExcel">
                        <igtxt:WebImageButton ID="wibExportExcel" runat="server" Text="Exportar a Excel" Width="134px" Height="30px">
                            <ClientSideEvents Click="wibExportTableToExcel.click();" />
                            <Appearance>
                                <Image Url="/ig_common/images/Report16x16.png" />
                                <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                </ButtonStyle>
                            </Appearance>
                        </igtxt:WebImageButton>
                    </td>
            </table>
            <br />
            <ig:WebDataGrid ID="wdgMain" ClientIDMode="Static" runat="server" Height="250px" Width="800px"
                AutoGenerateColumns="False" DataKeyFields="UnitRegisterId"
                OnRowSelectionChanged="wdgMain_Selection_RowSelectionChanged">
                <Columns>
                    <ig:TemplateDataField Width="60px" Key="DeleteRow" >
                            <ItemTemplate>              
                                    <asp:ImageButton ID="imgDelete" runat="server"
                                        ClientIDMode="static" ImageUrl="~/ig_common/images/trash-delete-16x16.png" />
                            </ItemTemplate>
                            <Header Text="Eliminar"></Header>
                        </ig:TemplateDataField>
                    <ig:BoundDataField DataFieldName="UnitRegisterId" Key="UnitRegisterId" Hidden="true">
                        <Header Text="Id Registro Unidad">
                        </Header>
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="UnitTypeId" Key="UnitTypeId" Hidden="true">
                        <Header Text="Id Tipo de Unidad">
                        </Header>
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="UnitTypeName" Key="UnitTypeName">
                        <Header Text="Tipo de Unidad">
                        </Header>
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="ConfigurationUnitTypeId" Key="ConfigurationUnitTypeId" Hidden="true">
                        <Header Text="Id Configuración">
                        </Header>
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="ConfigurationUnitTypeName" Key="ConfigurationUnitTypeName">
                        <Header Text="Configuración">
                        </Header>
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="PatentNumber" Key="PatentNumber">
                        <Header Text="Número de Patente">
                        </Header>
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="InternalNumber" Key="InternalNumber">
                        <Header Text="Número interno">
                        </Header>
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="RevTec" Key="RevTec">
                        <Header Text="Rev Tec.">
                        </Header>
                    </ig:BoundDataField>
                    <ig:BoundDataField DataFieldName="HabDate" Key="HabDate">
                        <Header Text="Habilitación">
                        </Header>
                    </ig:BoundDataField>
                </Columns>
                <Behaviors>
                    <ig:Activation Enabled="true" />
                    <ig:Selection RowSelectType="Single" Enabled="true" EnableHiddenSelection="True">
                            <SelectionClientEvents CellSelectionChanged="wdgMain_Selection_CellSelectionChanged_Delete"></SelectionClientEvents>
                        </ig:Selection>
                    <ig:Paging PagerMode="Numeric" FirstPageText="<|" LastPageText="|>" NextPageText=">" PreviousPageText="<" PagerAppearance="Bottom" PageSize="3" Enabled="true" />
                    <ig:Sorting SortingMode="Multi" Enabled="true" />
                    <ig:ColumnResizing Enabled="true" />
                    <ig:ColumnMoving Enabled="true" />
                </Behaviors>
            </ig:WebDataGrid>
            <br />
            <br />

             <%--POPUP AJUSTE--%>
            <asp:Button ID="btnConfirmar" style="display:none" runat="server" />
            <cc1:ModalPopupExtender ID="mpeConfirmar" runat="server" 
                TargetControlID="btnConfirmar" CancelControlID="btnConfirmar" OkControlID="btnConfirmar"
                PopupControlID="panConfirmar">
            </cc1:ModalPopupExtender>
            <div id="panConfirmar" class="popupPanelClass" style="display:none; height:215px; background-color:snow; Width:400px" >
                <div class="popupContainerClass">
                    <%--BARRA DE TITULO--%>
                    <div id="popupHeaderConfirmar">
                        <asp:Table ID="Table3" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="350px">
                            <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                    <div style="font-family: Arial; font-size: 20px; color:white;
                                    background:url('http://newevangelizationministries.org/images/Slate.jpg');
                                    text-align:center; width:400px">
                                        <asp:Label ID="Label3" runat="server"  Text="Amis">
                                        </asp:Label>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <table ID="Table4" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Width="380px" height="185px">
                            <tr>
                                <td><div style="width: 50px"></div></td>
                                <td><div style="width: 300px"></div></td>
                                <td><div style="width: 50px"></div></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><div style="font-family: Arial; font-size: 13px">
                                        <asp:Label ID="lbl" runat="server" Text=" ¿Esta seguro que desea eliminar esta configuración?"></asp:Label>
                                    </div>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <igtxt:WebImageButton ID="wibConfirmar" runat="server" Text="Confirmar" Width="134px" Height="30px" OnClick="wibConfirmar_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/trash-delete-16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <igtxt:WebImageButton ID="wibCancel" runat="server" Text="Cancelar" Width="134px" Height="30px" OnClick="wibCancel_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/cancel16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="divAux" runat="server"></div>

    <igtxt:WebImageButton ID="wibExportTableToExcel" Visible="true" ClientIDMode="Static" 
        runat="server" CssClass="buttonExport" Text="Exportar a Excel" Width="120px" OnClick="wibExportTableToExcel_Click">
    </igtxt:WebImageButton>
</asp:Content>
