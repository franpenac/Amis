<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GlobalCostReportPage.aspx.cs" Inherits="amis._PresentationLayer.Report.GlobalCostReportPage" %>

<%@ Register Assembly="Infragistics45.WebUI.WebSchedule.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">
    <style type="text/css">
        .auto-style5 {
            font-family: Arial;
            font-weight: bold;
            font-size: 20px;
        }
        .auto-style2 {
            height: 41px;
        }
        .auto-style3 {
            height: 20px;
        }
        .auto-style4 {
            height: 256px;
        }
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server" >
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 10px" class="auto-style4">
                </br></br></br><h1 id="h1OptionMenuPageName" runat="server">
                    Costo Global

                </h1>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <div style="font-family: Arial; font-size: 13px" class="auto-style3">
                    <asp:Label ID="Label1" runat="server" Text="Seleccione el filtro"></asp:Label>
                    <br />
                    <br />
                </div>
                <table>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblWarehouse" runat="server" Text="Bodega"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <ig:WebDropDown ID="wddWarehouse" runat="server" Width="300px" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                            </ig:WebDropDown>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    </table>
                    <table>
                    <tr>
                        <td style="vertical-align: top" class="auto-style2">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblDate" runat="server" Text="Fecha"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top" class="auto-style2"></td>
                        <td>
                            <ig:WebDropDown ID="wddMount" runat="server" Width="143px" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                            <Items>
                                                <ig:DropDownItem Selected="False" Text="Selecicone Mes" Value="0">
                                                </ig:DropDownItem>
                                                <ig:DropDownItem Selected="False" Text="Enero" Value="1">
                                                </ig:DropDownItem>
                                                <ig:DropDownItem Selected="False" Text="Febrero" Value="2">
                                                </ig:DropDownItem>
                                                <ig:DropDownItem Selected="False" Text="Marzo" Value="3">
                                                </ig:DropDownItem>
                                                <ig:DropDownItem Selected="False" Text="Abril" Value="4">
                                                </ig:DropDownItem>
                                                <ig:DropDownItem Selected="False" Text="Mayo" Value="5">
                                                </ig:DropDownItem>
                                                <ig:DropDownItem Selected="False" Text="Junio" Value="6">
                                                </ig:DropDownItem>
                                                <ig:DropDownItem Selected="False" Text="Julio" Value="7">
                                                </ig:DropDownItem>
                                                <ig:DropDownItem Selected="False" Text="Agosto" Value="8">
                                                </ig:DropDownItem>
                                                <ig:DropDownItem Selected="False" Text="Septiembre" Value="9">
                                                </ig:DropDownItem>
                                                <ig:DropDownItem Selected="False" Text="Octubre" Value="10">
                                                </ig:DropDownItem>
                                                <ig:DropDownItem Selected="False" Text="Noviembre" Value="11">
                                                </ig:DropDownItem>
                                                <ig:DropDownItem Selected="False" Text="Diciembre" Value="12">
                                                </ig:DropDownItem>
                                            </Items>
                            </ig:WebDropDown>
                        </td>
                        <td>
                            <ig:WebDropDown ID="wddYear" runat="server" Width="143px" EnableAutoFiltering="Client" AutoPostBack="True">
                            </ig:WebDropDown>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <div>
                    <table>
                        <tr>
                            <td></td>
                            <td runat="server" id="tdFilter">
                                <igtxt:WebImageButton ID="wibBuscar" runat="server" Text="Buscar" Width="134px" Height="30px" OnClick="wibBuscar_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/lupa16x16.png" />
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
                            <td runat="server" id="tdNewSearch"></td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />
            
            </div>
        <div runat="server" id="divReport">
        </div>

        <div runat="server" id="divAux2">
            <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    <div id="divAux" runat="server"></div>
    <igtxt:WebImageButton ID="wibExportTableToExcel" Visible="false" ClientIDMode="Static"
        runat="server" Text="Exportar a Excel" Width="120px" OnClick="wibExportTableToExcel_Click">
    </igtxt:WebImageButton>
</asp:Content>
