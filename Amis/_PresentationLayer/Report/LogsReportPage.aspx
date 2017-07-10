<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogsReportPage.aspx.cs" Inherits="amis._PresentationLayer.Report.LogsReportPage" %>

<%@ Register Assembly="Infragistics45.WebUI.WebSchedule.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 10px">
                </br></br></br><h1 id="h1OptionMenuPageName" runat="server">
                    Reporte de Logs
                </h1>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <div style="font-family: Arial; font-size: 13px">
                    <asp:Label ID="Label1" runat="server" Text="Filtrar por: "></asp:Label>
                    <br />
                    <br />
                </div>
                <div>
                <table>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblUser" runat="server" Text="Usuario"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="3">
                            <ig:WebDropDown ID="wddUser" runat="server" Width="300px" AutoSelectOnMatch="False" EnableAutoFiltering="Client">
                            </ig:WebDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblMenuOption" runat="server" Text="Opcion de menu"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="3">
                            <ig:WebDropDown ID="wddMenuOption" runat="server" Width="300px" AutoSelectOnMatch="False" EnableAutoFiltering="Client">
                            </ig:WebDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblAction" runat="server" Text="Accion"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="3">
                            <ig:WebDropDown ID="wddAction" runat="server" Width="300px" AutoSelectOnMatch="False" EnableAutoFiltering="Client">
                            </ig:WebDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblDate" runat="server" Text="Fecha Inicio/termino"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td runat="server">
                            <ig:WebMonthCalendar runat="server" ID="CalendarView" EnableWeekNumbers="true"
                                ChangeMonthToDateClicked="true" EnableMonthDropDown="True" EnableYearDropDown="True">
                            </ig:WebMonthCalendar>
                        </td>
                        <td>
                            <ig:WebDatePicker ID="wdpInitDate" runat="server" DropDownCalendarID="CalendarView"></ig:WebDatePicker>
                        </td>
                        <td style="vertical-align: top" colspan="3">
                            <ig:WebDatePicker ID="wdpEndDate" runat="server" DropDownCalendarID="CalendarView"></ig:WebDatePicker>
                        </td>
                    </tr>
                </table>
                    </div>
                <br />
                <br />
                <div>
                    <table>
                        <tr>
                            <td></td>
                            <td runat="server" id="tdNew">
                                <igtxt:WebImageButton ID="wibNew" runat="server" Text="Nueva busqueda" Width="134px" Height="30px" OnClick="wibNew_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/new16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
                            <td></td>
                            <td runat="server" id="tdExportExcel">
                                <igtxt:WebImageButton ID="wibExportExcel" runat="server" Text="Exportar a Excel" Width="134px" Height="30px" OnClick="wibExportExcel_Click">
                                    <ClientSideEvents Click="wibExportExcel_Click" />
                                    <Appearance>
                                        <Image Url="/ig_common/images/Report16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
                            <td></td>
                            <td runat="server" id="tdSearch">
                                <igtxt:WebImageButton ID="wibSearchResults" runat="server" Text="Filtrar" Width="134px" Height="30px" OnClick="wibSearchResults_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/lupa16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
            </div>
            <div>
                <div runat="server" id="divReport">
                </div>
                <div runat="server">
                    <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="divAux" runat="server"></div>
</asp:Content>
