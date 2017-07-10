<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DispatchProviderDocumentPage.aspx.cs" Inherits="amis._PresentationLayer.Inventory.DispatchProviderDocumentPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register src="wucDispatchItem.ascx" tagname="wucDispatchItem" tagprefix="uc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">
    
    <link rel="stylesheet" type="text/css" href="~/Content/css/MainCSS.css" />

<script type="text/javascript" id="igClientScript">


function wibExportExcel_Click() {
    document.getElementById('wibExportTableToExcel').click();
}

    function wdgMain_Selection_CellSelectionChanged_Profile(sender, eventArgs) {
            var grid = $find("wdgMain");
            var gridBehaviors = grid.get_behaviors();
            var cell = gridBehaviors.get_selection().get_selectedCells().getItem(0);
            var index = cell.get_index();

            if (index == 1) {
                var row = gridBehaviors.get_selection().get_selectedCells().getItem(0).get_row(0);
                var index = row.get_index();
                __doPostBack('<%= wdgMain.ClientID %>', 'AddItem;' + index);
            }
            else if (index == 0) {
                var row = gridBehaviors.get_selection().get_selectedCells().getItem(0).get_row(0);
                var index = row.get_index();
                __doPostBack('<%= wdgMain.ClientID %>', 'ReceptionRow;' + index);
            }
            else {
                var row = gridBehaviors.get_selection().get_selectedCells().getItem(0).get_row(0);
                var index = row.get_index();
                __doPostBack('<%= wdgMain.ClientID %>', 'wdgMain;' + index);
            }
    }

function wdgItem_Selection_RowSelectionChanged(webDataGrid, evntArgs) {
        var grid = $find("wdgItem");
        var gridBehaviors = grid.get_behaviors();
        var row = gridBehaviors.get_selection().get_selectedRows().getItem(0);
        var index = row.get_index();
        __doPostBack('<%= wdgItem.ClientID %>', 'wdgItem;' + index);
}
</script>

    <style>
        .buttonExport {
            visibility:hidden;
        }
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate><div style="margin: 10px">
                <div id="HeaderDocument" runat="server">
                </br></br></br><h1 id="h1OptionMenuPageName" runat="server">
                    Documento de despacho de proveedor
                </h1>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <table>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top; font-size:20px">
                            <asp:Label ID="Label4" runat="server" Text="Creación de Guía"></asp:Label>
                        </td>
                    </tr>
                    <div id="New" runat="server">
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblDispatchProviderNumber" runat="server" Text="N° guia"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <ig:WebNumericEditor ID="wneDispatchProviderNumber" runat="server"></ig:WebNumericEditor>
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
                                <asp:Label ID="lblFacility" runat="server" Text="Bodega"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <ig:WebDropDown ID="wddFacility" runat="server" Width="300px" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                <AutoPostBackFlags SelectionChanged="On"/>
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
                                <asp:Label ID="lblProvider" runat="server" Text="Proveedor"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <ig:WebDropDown ID="wddProvider" runat="server" Width="300px" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                <AutoPostBackFlags SelectionChanged="On"/>
                            </ig:WebDropDown>
                        </td>
                    </tr>
                    </div>
                    
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    </div>
                </table>
                <div id="BodyDocument" runat="server">
                     <uc1:wucDispatchItem ID="wucDispatchItem" runat="server" />
                     <table>
                         <tr>
                            <td>
                                <igtxt:WebImageButton ID="wibSaveItem" runat="server" Text="Grabar" Width="134px" Height="30px" OnClick="wibSaveItem_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/save16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
                            <td></td>
                            <td>
                                <igtxt:WebImageButton ID="wibBack" runat="server" Text="Volver" Width="134px" Height="30px" OnClick="wibBackItem_Click">
                                    <Appearance>
                                        <Image Url="../../ig_common/images/BackTo16x16.png" />
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
                <div>
                    <div id="Buttons" runat="server">
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
                            <td>
                                <igtxt:WebImageButton ID="wibOpenSearch" runat="server" Text="Buscar" Width="134px" Height="30px" OnClick="wibOpenSearch_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/lupa16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
                            <td></td>
                            <td runat="server" id="tdExportExcel" >
                                <igtxt:WebImageButton ID="wibExportExcel" runat="server" Visible="false" Text="Exportar a Excel" Width="134px" Height="30px" >
                                    <ClientSideEvents Click="wibExportExcel_Click;" />
                                    <Appearance>
                                        <Image Url="/ig_common/images/Report16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
                            <td></td>
                            <td>
                                <igtxt:WebImageButton ID="wibAddItem" runat="server" Text="Agregar Item" Visible="false" Width="134px" Height="30px" OnClick="wibAddItem_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/add16x16.png" />
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
                <br />
                <br />

                <ig:WebDataGrid ID="wdgMain" ClientIDMode="Static" runat="server" Height="350px" Width="800px" 
                    AutoGenerateColumns="False" DataKeyFields="DispatchProviderDocumentId">
                    <Columns>
                        <ig:TemplateDataField Width="50px" Key="ReceptionRow">
                            <ItemTemplate>              
                                    
                                    <asp:Image runat="server" id="imgreceptionguid" ImageUrl="~/ig_common/images/puntoVerde16x16.jpeg" CommandName="ReceptionRow" 
                                        CommandArgument='<%# DataBinder.Eval(((Infragistics.Web.UI.TemplateContainer)Container).Item, "Row.Index") %>'></asp:Image>
  
                            </ItemTemplate><Header Text="Cierre"></Header>
                        </ig:TemplateDataField>
                        <ig:TemplateDataField Width="100px" Key="AddItem" >
                            <ItemTemplate>          
                                   <asp:Image runat="server" id="imgAddItem" ImageUrl="~/ig_common/images/add16x16.png" CommandName="AddItem" CommandArgument='<%# DataBinder.Eval(((Infragistics.Web.UI.TemplateContainer)Container).Item, "Row.Index") %>'></asp:Image>
                                
                         </ItemTemplate><Header Text="Agregar item"></Header>
                        </ig:TemplateDataField>
                        <ig:BoundDataField DataFieldName="DispatchProviderDocumentId" DataType="System.UInt32" Key="DispatchProviderDocumentId" Hidden="True">
                            <Header Text="Id Documento">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="DocumentNumber" Key="DocumentNumber">
                            <Header Text="N° Doc.">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="DispatchProviderDocumentStateId" Key="DispatchProviderDocumentStateId"  Hidden="True">
                            <Header Text="Id Estado Doc">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="DispatchProviderDocumentStateName" Key="DispatchProviderDocumentStateName">
                            <Header Text="Estado Doc">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="FacilityId" Key="FacilityId"  Hidden="True">
                            <Header Text="Id Ubicacion">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="WarehouseId" Key="WarehouseId"  Hidden="True">
                            <Header Text="Id Bodega">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="WarehouseName" Key="WarehouseName">
                            <Header Text="Bodega">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="MemberId" Key="MemberId"  Hidden="True">
                            <Header Text="Id Proveedor">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="MemberName" Key="MemberName">
                            <Header Text="Proveedor">
                            </Header>
                        </ig:BoundDataField>
                    </Columns>
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection RowSelectType="Single" Enabled="true" EnableHiddenSelection="false">
                            <SelectionClientEvents CellSelectionChanged="wdgMain_Selection_CellSelectionChanged_Profile"></SelectionClientEvents>
                        </ig:Selection>
                        <ig:Paging PagerMode="Numeric" FirstPageText="<|" LastPageText="|>" NextPageText=">" PreviousPageText="<" PagerAppearance="Bottom" PageSize="8" Enabled="true" />
                        <ig:Sorting SortingMode="Multi" Enabled="true" />
                        <ig:ColumnResizing Enabled="true" />
                        <ig:ColumnMoving Enabled="true" />
                    </Behaviors>
                </ig:WebDataGrid>

                <div id="GridItem" runat="server">
                    <ig:WebDataGrid ID="wdgItem" ClientIDMode="Static" runat="server" Height="350px" Width="1000px" 
                    AutoGenerateColumns="False" DataKeyFields="DispatchProviderDocumentItemId"
                        OnItemCommand="wdgItem_ItemCommand"
                        OnRowSelectionChanged="wdgItem_Selection_RowSelectionChanged">
                     <Columns>
                         <ig:TemplateDataField Width="28px" Key="ReceptionRow">
                            <ItemTemplate>              
                                    <asp:ImageButton ID="imgReception" runat="server" CommandName="ReceptionRow" CommandArgument='<%# DataBinder.Eval(((Infragistics.Web.UI.TemplateContainer)Container).Item, "Row.Index") %>'
                                        ImageUrl="~/ig_common/images/puntoVerde16x16.jpeg" />   
                            </ItemTemplate>
                        </ig:TemplateDataField>
                        <ig:BoundDataField DataFieldName="DispatchProviderDocumentItemId" DataType="System.UInt32" Key="DispatchProviderDocumentItemId" Hidden="True">
                            <Header Text="Id Item">
                            </Header>
                        </ig:BoundDataField>
                         <ig:BoundDataField DataFieldName="DispatchProviderDocumentStateId" Key="DispatchProviderDocumentStateId" Hidden="True">
                            <Header Text="Id Estado">
                            </Header>
                        </ig:BoundDataField>
                         <ig:BoundDataField DataFieldName="DispatchProviderDocumentStateName" Key="DispatchProviderDocumentStateName">
                            <Header Text="Estado">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AssetTypeId" Key="AssetTypeId" Hidden="True">
                            <Header Text="Id Tipo Activo">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AssetTypeName" Key="AssetTypeName">
                            <Header Text="Tipo Activo">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AssetModelId" Key="AssetModelId" Hidden="True">
                            <Header Text="Id Modelo">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="OriginName" Key="OriginName">
                            <Header Text="Procedencia">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="BrandId" Key="BrandId" Hidden="True">
                            <Header Text="Id Marca">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="OriginId" Key="OriginId" Hidden="true">
                            <Header Text="Id procedencia">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="BrandName" Key="BrandName">
                            <Header Text="Marca">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ManufacturerYear" Key="ManufacturerYear">
                            <Header Text="Fabricacion">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="DeclaratedAmount" Key="DeclaratedAmount" >
                            <Header Text="Declarada">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ReceptionAmount" Key="ReceptionAmount">
                            <Header Text="Recepcionada">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AssignedAmount" Key="AssignedAmount" Hidden="true">
                            <Header Text="Asignada">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ItemCost" Key="ItemCost">
                            <Header Text="Costo">
                            </Header>
                        </ig:BoundDataField>
                         
                        <ig:BoundDataField DataFieldName="Observation" Key="Observation">
                            <Header Text="Observaciones">
                            </Header>
                        </ig:BoundDataField>
                    </Columns>
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection RowSelectType="Single" Enabled="true" CellClickAction="Row">
                            <SelectionClientEvents RowSelectionChanged="wdgItem_Selection_RowSelectionChanged"></SelectionClientEvents>
                        </ig:Selection>
                        <ig:Paging PagerMode="Numeric" FirstPageText="<|" LastPageText="|>" NextPageText=">" PreviousPageText="<" PagerAppearance="Bottom" PageSize="8" Enabled="true" />
                        <ig:Sorting SortingMode="Multi" Enabled="true" />
                        <ig:ColumnResizing Enabled="true" />
                        <ig:ColumnMoving Enabled="true" />
                    </Behaviors>
                </ig:WebDataGrid>
                </div>
            </div>
             
            
             <%--POPUP AJUSTE--%>
            <asp:Button ID="btnAuxAjuste" style="display:none" runat="server" />
            <cc1:ModalPopupExtender ID="mpeAjuste" runat="server" 
                TargetControlID="btnAuxAjuste" CancelControlID="btnAuxAjuste" OkControlID="btnAuxAjuste"
                PopupControlID="panAjuste">
            </cc1:ModalPopupExtender>
            <div id="panAjuste" class="popupPanelClass" style="display:none; height:200px;" >
                <div class="popupContainerClass">
                    <%--BARRA DE TITULO--%>
                    <div id="popupHeaderAjuste">
                        <asp:Table ID="Table2" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="650px">
                            <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                    <div style="font-family: Arial; font-size: 20px; color:white;
                                    background:url('http://newevangelizationministries.org/images/Slate.jpg');
                                    text-align:center; width:650px">
                                        <asp:Label ID="Label3" runat="server"  Text="Amis">
                                        </asp:Label>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <table ID="Table1" runat="server" style="background-color:white !important" BorderStyle="Solid" BorderWidth="0.5px" Width="650px" height="185px">
                            <tr>
                                <td><div style="width: 160px"></div></td>
                                <td><div style="width: 160px"></div></td>
                                <td><div style="width: 160px"></div></td>
                                <td><div style="width: 159px"></div></td>
                            </tr>
                            <tr><td></td>
                                <td><div style="font-family: Arial; font-size: 13px">
                                        <asp:Label ID="lblProviederSerch" runat="server" Text="Proveedor"></asp:Label>
                                    </div>
                                </td>
                                <td>
                                    <ig:WebDropDown ID="wddProviederSearch" runat="server" Width="150px">
                                        
                                    </ig:WebDropDown>
                                </td>
                            <td></td></tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div style="font-family: Arial; right; font-size: 13px" >
                                        <asp:Label ID="lblNUmberSearch" runat="server" Text="N° guia"></asp:Label>
                                    </div>
                                </td>
                                <td>
                                    <ig:WebDropDown ID="wddNumberSearch" runat="server" Width="150px" >
                                        
                                    </ig:WebDropDown>
                                </td>
                                <td></td>

                            </tr>
                            <tr><td></td><td></td><td></td><td></td></tr>
                            <tr>
                                <td></td>
                                <td>
                                    <igtxt:WebImageButton ID="wibSearch" runat="server" Text="Buscar" Width="134px" Height="30px" OnClick="wibSearch_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/lupa16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                                </td>
                                <td>
                                    <igtxt:WebImageButton ID="wibCancel" runat="server" Text="Cancelar" Width="134px" Height="30px">
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
            
            <%--POPUP AJUSTE--%>
            <asp:Button ID="btnConfirmar" style="display:none" runat="server" />
            <cc1:ModalPopupExtender ID="mpeConfirmar" runat="server" 
                TargetControlID="btnConfirmar" CancelControlID="btnConfirmar" OkControlID="btnConfirmar"
                PopupControlID="panConfirmar">
            </cc1:ModalPopupExtender>
            <div id="panConfirmar" class="popupPanelClass" style="display:none; height:215px;" >
                <div class="popupContainerClass">
                    <%--BARRA DE TITULO--%>
                    <div id="popupHeaderConfirmar">
                        <asp:Table ID="Table3" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="650px">
                            <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                    <div style="font-family: Arial; font-size: 20px">
                                        <asp:Label ID="Label1" runat="server" Text="Amis">
                                        </asp:Label>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <table ID="Table4" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Width="650px" height="185px">
                            <tr>
                                <td><div style="width: 240px"></div></td>
                                <td><div style="width: 159px"></div></td>
                                <td><div style="width: 240px"></div></td>
                            </tr>
                            <tr><td></td>
                                <td><div style="font-family: Arial; font-size: 13px">
                                        <asp:Label ID="lbl" runat="server" Text="El item no tiene la recepcion completa, desea agregarle alguna observacion
                                            antes de declararlo como recepcionado"></asp:Label>
                                    </div>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td><div style="width: 240px"></div></td>
                                <td><ig:WebTextEditor ID="wteObservation" runat="server" Height="55px" Width="276px"></ig:WebTextEditor>
                                </td>
                                <td><div style="width: 240px"></div></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <igtxt:WebImageButton ID="wibConfirmar" runat="server" Text="Confirmar" Width="134px" Height="30px" OnClick="wibConfirmar_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/save16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                                </td>

                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <%--POPUP Message--%>
            <asp:Button ID="Button1" style="display:none" runat="server" />
            <cc1:ModalPopupExtender ID="mpeMessage" runat="server" 
                TargetControlID="btnOk" CancelControlID="btnOk" OkControlID="btnOk"
                PopupControlID="panMessage">
            </cc1:ModalPopupExtender>
            <div id="panMessage" class="popupPanelClass" style="display:none; height:200px;" >
                <div class="popupContainerClass">
                    <%--BARRA DE TITULO--%>
                    <div id="popupHeaderMessage">
                        <asp:Table ID="Table5" runat="server" style="background-color:cadetblue" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="500px">
                            <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                    <div style="font-family: Arial; font-size: 20px">
                                        <asp:Label ID="Label2" runat="server" Text="Amis">
                                        </asp:Label>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <table ID="Table6" style="background-color:gainsboro" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Width="500px" height="185px">
                            <tr>
                                <td><div style="width: 100px"></div></td>
                                <td><div style="width: 300px"></div></td>
                                <td><div style="width: 100px"></div></td>
                            </tr>
                            <tr><td></td>
                                <td><div style="font-family: Arial; font-size: 13px">
                                        <asp:Label ID="lblMessage" Width="100%" runat="server" Text=""></asp:Label>
                                    </div>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td><div style="width: 100px"></div></td>
                                <td>
                                    <asp:Button ID="btnOk" Width="100%" runat="server" Text="Ok" OnClick="btnOk_Click" />
                                </td>
                                <td><div style="width: 100px"></div></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <igtxt:WebImageButton ID="wibExportTableToExcel" Visible="true" ClientIDMode="Static" 
        runat="server" CssClass="buttonExport" Text="Exportar a Excel" Width="120px" OnClick="wibExportTableToExcel_Click">
    </igtxt:WebImageButton>
</asp:Content>