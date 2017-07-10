<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GlobalCostDetailPage.aspx.cs" Inherits="amis._PresentationLayer.Maintenance.GlobalCostDetailPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">

<script type="text/javascript" id="igClientScript">


function wibExportExcel_Click(oButton, oEvent) {
    document.getElementById('wibExportTableToExcel').click();
}

function wdgMain_Selection_RowSelectionChanged(webDataGrid, evntArgs) {
        var grid = $find("wdgMain");
        var gridBehaviors = grid.get_behaviors();
        var row = gridBehaviors.get_selection().get_selectedRows().getItem(0);
        var index = row.get_index();
        __doPostBack('<%= wdgMain.ClientID %>', 'wdgMain;' + index);
}


</script></asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 10px">
                </br></br></br><h1 id="h1OptionMenuPageName" runat="server">
                    Detalle de costo global
                </h1>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <table>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="Label1" runat="server" Text="Fecha"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                        <td style="vertical-align: top">
                            <ig:WebDropDown ID="wddMonth" runat="server" Width="140px" AutoSelectOnMatch="False" EnableAutoFiltering="Client">
                                
                                <Items>
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
                        <td style="vertical-align: top">&nbsp;&nbsp; &nbsp;</td>
                        <td style="vertical-align: top">
                            <ig:WebDropDown ID="wddAnno" runat="server" Width="140px" AutoSelectOnMatch="False" EnableAutoFiltering="Client">
                                
                                <Items>
                                    <ig:DropDownItem Selected="False" Text="2015" Value="2015">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Selected="False" Text="2016" Value="2016">
                                    </ig:DropDownItem>
                                </Items>
                                
                            </ig:WebDropDown>
                        </td>
                    </tr>
                    </table><table>
                        <caption>
                            <br />
                            <tr>
                                <td style="vertical-align: top">
                                    <div style="font-family: Arial; font-size: 13px">
                                        <asp:Label ID="lblGlobalCostName" runat="server" Text="Tipo de costo"></asp:Label>
                                    </div>
                                </td>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">
                                    <ig:WebDropDown ID="wddGlobalCost" runat="server" AutoSelectOnMatch="False" Width="300px" EnableAutoFiltering="Client">
                                       
                                    </ig:WebDropDown>
                                </td>
                            </tr>
                                <tr>
                                    <td style="vertical-align: top">&nbsp;</td>
                                    <td style="vertical-align: top">&nbsp;</td>
                                    <td style="vertical-align: top">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: top">
                                        <div style="font-family: Arial; font-size: 13px">
                                            <asp:Label ID="lblGlobalCostDetailCost" runat="server" Text="Costo"></asp:Label>
                                        </div>
                                    </td>
                                    <td style="vertical-align: top">&nbsp;</td>
                                    <td>
                                        <ig:WebNumericEditor ID="wneCost" runat="server" DataMode="Int" Nullable="False" Width="295px">
                                        </ig:WebNumericEditor>
                                    </td>
                                </tr>
                        </caption>
                </table>
                <br />
                <br />
                <div>
                    <table>
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
                                <igtxt:WebImageButton ID="wibExportExcel" runat="server" Text="Exportar a Excel" Width="134px" Height="30px" >
                                    <ClientSideEvents Click="wibExportExcel_Click" />
                                    <Appearance>
                                        <Image Url="/ig_common/images/Report16x16.png" />
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

                <ig:WebDataGrid ID="wdgMain" ClientIDMode="Static" runat="server" Height="350px" Width="600px" 
                    AutoGenerateColumns="False" DataKeyFields="GlobalCostDetailId"
                    OnItemCommand="wdgMain_ItemCommand"
                    OnRowSelectionChanged="wdgMain_Selection_RowSelectionChanged">
                    <Columns>
                        <ig:BoundDataField DataFieldName="GlobalCostDetailId" DataType="System.UInt32" Key="GlobalCostDetailId" Hidden="True">
                            <Header Text="Id Detalle">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="GlobalCostId" Key="GlobalCostId" Hidden="True">
                            <Header Text="Id Costo">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="GlobalCostName" Key="GlobalCostName">
                            <Header Text="Nombre Costo">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Cost" Key="Cost">
                            <Header Text="Costo">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Month" Key="Month">
                            <Header Text="Fecha">
                            </Header>
                        </ig:BoundDataField>
                    </Columns>
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection RowSelectType="Single" Enabled="true" CellClickAction="Row">
                            <SelectionClientEvents RowSelectionChanged="wdgMain_Selection_RowSelectionChanged"></SelectionClientEvents>
                        </ig:Selection>
                        <ig:Paging PagerMode="Numeric" FirstPageText="<|" LastPageText="|>" NextPageText=">" PreviousPageText="<" PagerAppearance="Bottom" PageSize="50" Enabled="true" />
                        <ig:Sorting SortingMode="Multi" Enabled="true" />
                        <ig:ColumnResizing Enabled="true" />
                        <ig:ColumnMoving Enabled="true" />
                    </Behaviors>
                </ig:WebDataGrid>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <div id="divAux" runat="server"></div>

    <igtxt:WebImageButton ID="wibExportTableToExcel" Visible="false" ClientIDMode="Static" 
        runat="server" Text="Exportar a Excel" Width="120px" OnClick="wibExportTableToExcel_Click">
    </igtxt:WebImageButton>
</asp:Content>
