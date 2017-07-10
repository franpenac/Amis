<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnitRegisterToOperationPage.aspx.cs" Inherits="amis._PresentationLayer.OperationModule.UnitRegisterToOperationPage" %>

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
    </style>
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

function wdgMain_Selection_CellSelectionChanged_Profile(sender, eventArgs) {
            var grid = $find("wdgMain");
            var gridBehaviors = grid.get_behaviors();
            var cell = gridBehaviors.get_selection().get_selectedCells().getItem(0);
            var index = cell.get_index();

            if (index == 1) {
                var row = gridBehaviors.get_selection().get_selectedCells().getItem(0).get_row(0);
                var index = row.get_index();
                __doPostBack('<%= wdgMain.ClientID %>', 'wdgEnd;' + index);
            }
            else {
                var row = gridBehaviors.get_selection().get_selectedCells().getItem(0).get_row(0);
                var index = row.get_index();
                __doPostBack('<%= wdgMain.ClientID %>', 'wdgMain;' + index);
            }
    }

</script></asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 10px">
                </br></br></br><h1 id="h1OptionMenuPageName" runat="server">
                    Asignación a operaciones
                </h1>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <table>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="Label1" runat="server" Text="Tipo de busqueda"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <ig:WebDropDown ID="wddSearchType" runat="server" Width="298px" EnableAutoFiltering="Client" AutoSelectOnMatch="False" OnSelectionChanged="wddSearchType_SelectionChanged">
                                
                                <AutoPostBackFlags SelectionChanged="On" />
                                
                            </ig:WebDropDown>
                        </td>
                        <tr>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblUnit" runat="server" Text="Patente/N° Interno"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top"></td>
                            <td style="vertical-align: top">&nbsp;<ig:WebDropDown ID="wddUnit" runat="server" AutoSelectOnMatch="False" EnableAutoFiltering="Client" Width="298px">
                                </ig:WebDropDown>
                            </td>
                            <tr>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top">
                                    <div style="font-family: Arial; font-size: 13px">
                                        <asp:Label ID="lblOperation" runat="server" Text="Operacion"></asp:Label>
                                    </div>
                                </td>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">
                                    <ig:WebDropDown ID="wddOperation" runat="server" AutoSelectOnMatch="False" EnableAutoFiltering="Client" Width="300px">
                                    </ig:WebDropDown>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">&nbsp;</td>
                            </tr>
                        </tr>
                        
                    </tr>
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
                    AutoGenerateColumns="False" DataKeyFields="AssignmentId">
                    <Columns>
                        <ig:TemplateDataField Width="60px" Key="DeleteRow">
                            <ItemTemplate>
                                <asp:Image runat="server" id="imgDelete" ImageUrl="~/ig_common/images/trash-delete-16x16.png" CommandName="DeleteRow" CommandArgument='<%# DataBinder.Eval(((Infragistics.Web.UI.TemplateContainer)Container).Item, "Row.Index") %>'></asp:Image>
                            </ItemTemplate><Header Text="Eliminar"></Header>
                        </ig:TemplateDataField>
                        <ig:TemplateDataField Key="EndDate" Width="100px">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgUserMenuOption" runat="server" ImageAlign="Bottom" ToolTip="Terminar la operación"
                                    ImageUrl="~/ig_common/images/Cancel16x16.png" />
                            </ItemTemplate>
                            <Header Text="Fin Op."></Header>
                        </ig:TemplateDataField>
                        <ig:BoundDataField DataFieldName="AssignmentId" DataType="System.UInt32" Key="AssignmentId" Hidden="True">
                            <Header Text="Id">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AssignmentDate" Key="AssignmentDate">
                            <Header Text="Fecha de asignacion">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="OperationId" Key="OperationId" Hidden="True">
                            <Header Text="Id Operacion">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="OperationName" Key="OperationName">
                            <Header Text="Nombre Operacion">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="UnitId" Key="UnitId" Hidden="True">
                            <Header Text="Id Unidad">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="PatentNumber" Key="PatentNumber" >
                            <Header Text="Patente">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="EndAssignmentDate" Key="EndAssignmentDate">
                            <Header Text="Fecha de termino">
                            </Header>
                        </ig:BoundDataField>
                    </Columns>
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection RowSelectType="Single" Enabled="true" EnableHiddenSelection="false">
                            <SelectionClientEvents CellSelectionChanged="wdgMain_Selection_CellSelectionChanged_Profile"></SelectionClientEvents>
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

    <igtxt:WebImageButton ID="wibExportTableToExcel" Visible="true" ClientIDMode="Static" 
        runat="server" Text="Exportar a Excel"  CssClass="buttonExport" Width="120px"  OnClick="wibExportTableToExcel_Click">
    </igtxt:WebImageButton>
</asp:Content>