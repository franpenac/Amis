<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ScrapTypesReportPage.aspx.cs" Inherits="amis._PresentationLayer.Report.ScraptTypesReportPage" %>

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
                    Tipos de Bajas
                </h1>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <div style="font-family: Arial; font-size: 13px">
                    <asp:Label ID="Label1" runat="server" Text="Filtrar por: "></asp:Label>
                    <br />
                    <br />
                </div>
                <table>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblAssetId" runat="server" Text="ID de Activo"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="3">
                            <ig:WebTextEditor ID="wteAssetId" runat="server" Width="100px" ></ig:WebTextEditor>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="3">&nbsp;</td>
                    </tr>
                    <div runat="server" id="divOperationType">
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblOperation" runat="server" Text="Operacion"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="3">
                            <ig:WebDropDown ID="wddOPeration" runat="server" Width="300px" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
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
                                <asp:Label ID="lblAssetType" runat="server" Text="Tipo de Activo"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="3">
                            <ig:WebDropDown ID="wddAssetType" runat="server" Width="300px" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                            </ig:WebDropDown>
                        </td>
                    </tr>
                    </div>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                           <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblPeriod" runat="server" Text="Periodo"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top" colspan="3">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="Label2" runat="server" Text="Mes"></asp:Label>
                            </div>
                            <ig:WebDropDown ID="wddPeriodMonth" runat="server" Width="140px" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                <Items>
                                    <ig:DropDownItem Selected="False" Text="Seleccionar" Value="0">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="Enero" Value="01">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="Febrero" Value="02">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="Marzo" Value="03">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="Abril" Value="04">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="Mayo" Value="05">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="Junio" Value="06">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="Julio" Value="07">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="Agosto" Value="08">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="Septiembre" Value="09">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="Octubre" Value="10">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="Noviembre" Value="11">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="Diciembre" Value="12">
                                    </ig:DropDownItem>
                                </Items>
                            </ig:WebDropDown>
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblYear" runat="server" Text="Año"></asp:Label>
                                <ig:WebDropDown ID="wddPeriodYear" runat="server" Width="140px" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                            </ig:WebDropDown>
                            </div>
                        </td>
                        <td style="vertical-align: top" colspan="3">
                            
                        </td>
                    </tr>
                </table>
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
