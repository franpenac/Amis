<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssetAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AssetModule.AssetAndroidPage" %>


<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.ListControls" tagprefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>
<style>
        .Opacity
        {
            opacity:0;
        }
    </style>
<script type="text/javascript" id="igClientScript">


function wdgItem_Selection_RowSelectionChanged(webDataGrid, evntArgs) {
        var grid = $find("wdgItem");
        var gridBehaviors = grid.get_behaviors();
        var row = gridBehaviors.get_selection().get_selectedRows().getItem(0);
        var index = row.get_index();
        __doPostBack('<%= wdgItem.ClientID %>', 'wdgItem;' + index);
}
    function getControl(controlName) {
        return document.getElementById(controlName);
    }

    function ReadTag() {
        AndroidInterface.androidRFIDTurnOn(true);
        getControl('txtTagCodeAdd').value = '';
        var value = AndroidInterface.androidFindTagStrongSound();
        getControl('txtTagCodeAdd').value = value;
        var button = getControl('imbAssetAdd');
        button.click();
    }

    function DeleteTag() {
        AndroidInterface.androidRFIDTurnOn(true);
        getControl('txtTagCodeRemove').value = '';
        var value = AndroidInterface.androidFindTagStrongSound();
        getControl('txtTagCodeRemove').value = value;
        var button = getControl('imbAssetRemove');
        button.click();
    }
</script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/AmisAndroid.css" />
    </head>
<body >
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="timer" runat="server" OnTick="timer_Tick"></asp:Timer>
                    <div>
                        <table style="border:solid; width:100%" >
                            <tr>
                                <td style=" text-align:center">
                                    <asp:Label ID="lblTitle" CssClass="CssTitle" runat="server" Text="Asignación TAG a Activos"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table style="width:100%">
                        <tr>
                            <td style="width:25%">
                            </td>
                            <td style="width:50%; text-align:center" >
                                <asp:Label ID="lblProvider" CssClass="CssSubTitle" Width="100%" runat="server" Text="Seleccione el proveedor"></asp:Label>

                            </td>
                            <td style="width:25%">
                            </td>
                        </tr>
                        </table>


                        <table style="width:100%">
                            <tr>
                                <td style="width:25%">
                                </td>
                                <td style="width:50%">
                                    <asp:DropDownList ID="ddlProvider" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvider_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td style="width:25%">
                                    
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table style="width:100%">
                            <tr>
                                <td style="width:25%">
                                </td>
                                <td style="width:50%; text-align:center">
                                    <asp:Label ID="Label1" CssClass="CssSubTitle" runat="server" Width="100%" Text="Seleccione la guia de proveedor"></asp:Label>
                                </td>
                                <td style="width:25%">
                                </td>
                            </tr>
                        </table>
                        <table style="width:100%">
                            <tr>
                                <td style="width:25%">
                                </td>
                                <td style="width:50%">
                                    <asp:DropDownList ID="ddlNumber" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNumber_SelectedIndexChanged" Width="100%">
                                    </asp:DropDownList>

                                </td>
                                <td style="width:25%">
                                    
                                </td>
                            </tr>
                        </table>
                        <br />
                        
                        <table style="width: 100%; border-collapse:collapse">
                            <tr>
                                <td style="width:15%"></td>
                                <td style="text-align:center; width:65%">
                                    <asp:TextBox ID="txtTagCodeAdd" CssClass="Opacity" runat="server" ClientIDMode="Static" Style="width: 1%"></asp:TextBox>
                                    <input type="button" value='Assignar TAG' style="width:100%" id="btnReadRfiTag" onclick='ReadTag();'/>
                                </td>
                                <td style="vertical-align: middle; width: 16px; width:5%">
                                    <asp:ImageButton ID="imbAssetAdd" CssClass="Opacity" ClientIDMode="Static" runat="server" ImageUrl="~/ig_common/images/add16x16.png" OnClick="imbAssetAdd_Click"  Style="height: 16px; width: 16px "/>
                                </td>
                                <td style="width:15%"></td>
                            </tr>
                        </table>
                        <br />
                        <table style="width: 100%; border-collapse:collapse">
                            <tr>
                                <td style="width:15%"></td>
                                <td style="text-align:center; width:65%">
                                    <asp:TextBox ID="txtTagCodeRemove" CssClass="Opacity" runat="server" ClientIDMode="Static"  Style="width: 1%"></asp:TextBox>
                                    <input type="button" value='Desasignar TAG' style="width:100%" id="btnReadDeleteRfiTag" onclick='DeleteTag();'/>
                                </td>
                                <td style="vertical-align: middle; width: 16px; width:5%">
                                    <asp:ImageButton ID="imbAssetRemove" CssClass="Opacity" ClientIDMode="Static" runat="server" ImageUrl="~/ig_common/images/cancel16x16.png" Style="height: 16px" OnClick="imbAssetRemove_Click" />
                                </td>
                                <td style="width:15%"></td>
                            </tr>
                        </table>
                        <br />
                        <table style="width:100%">
                            <tr>
                                <td style="width:0%">
                                </td>
                                <td style="width:100%; text-align:center">
                                    <div id="GridItem" runat="server">
                        <ig:WebDataGrid ID="wdgItem" ClientIDMode="Static" runat="server" 
                                AutoGenerateColumns="False" DataKeyFields="DispatchProviderDocumentItemId"
                                    OnRowSelectionChanged="wdgItem_Selection_RowSelectionChanged" Width="100%">
                                 <Columns>
                                    <ig:BoundDataField DataFieldName="DispatchProviderDocumentItemId" DataType="System.UInt32" Key="DispatchProviderDocumentItemId" Hidden="True">
                                        <Header Text="Id Item">
                                        </Header>
                                    </ig:BoundDataField>
                                     <ig:BoundDataField DataFieldName="DispatchProviderDocumentStateId" Key="DispatchProviderDocumentStateId" Hidden="True">
                                        <Header Text="Id Estado">
                                        </Header>
                                    </ig:BoundDataField>
                                     <ig:BoundDataField DataFieldName="DispatchProviderDocumentStateName" Key="DispatchProviderDocumentStateName" Hidden="True">
                                        <Header Text="Estado">
                                        </Header>
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="AssetTypeId" Key="AssetTypeId" Hidden="True">
                                        <Header Text="Id Tipo Activo">
                                        </Header>
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="AssetTypeName" Key="AssetTypeName">
                                        <Header Text="Tipo">
                                        </Header>
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="AssetModelId" Key="AssetModelId" Hidden="True">
                                        <Header Text="Id Modelo">
                                        </Header>
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="OriginName" Key="OriginName" Hidden="True">
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
                                     <ig:BoundDataField DataFieldName="AssetModelName" Key="AssetModelName">
                                        <Header Text="Modelo">
                                        </Header>
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="ManufacturerYear" Key="ManufacturerYear" Hidden="True">
                                        <Header Text="Fabricacion">
                                        </Header>
                                    </ig:BoundDataField>
                                    
                                    <ig:BoundDataField DataFieldName="ReceptionAmount" Key="ReceptionAmount" Hidden="True">
                                        <Header Text="Recepcionada">
                                        </Header>
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="AssignedAmount" Key="AssignedAmount">
                                        <Header Text="Asignada">
                                        </Header>
                                    </ig:BoundDataField>
                                     <ig:BoundDataField DataFieldName="DeclaratedAmount" Key="DeclaratedAmount" >
                                        <Header Text="Pendiente">
                                        </Header>
                                    </ig:BoundDataField>
                                    <ig:BoundDataField DataFieldName="ItemCost" Key="ItemCost" Hidden="True">
                                        <Header Text="Costo">
                                        </Header>
                                    </ig:BoundDataField>
                         
                                    <ig:BoundDataField DataFieldName="Observation" Key="Observation" Hidden="True">
                                        <Header Text="Observaciones">
                                        </Header>
                                    </ig:BoundDataField>
                                </Columns>
                                <Behaviors>
                                    <ig:Activation Enabled="true" />
                                    <ig:Selection RowSelectType="Single" Enabled="true" CellClickAction="Row">
                                        <SelectionClientEvents RowSelectionChanged="wdgItem_Selection_RowSelectionChanged"></SelectionClientEvents>
                                    </ig:Selection>
                                    <ig:Paging PagerMode="Numeric" FirstPageText="<|" LastPageText="|>" NextPageText=">" PreviousPageText="<" PagerAppearance="Bottom" PageSize="50" Enabled="true" />
                                    <ig:Sorting SortingMode="Multi" Enabled="true" />
                                    <ig:ColumnResizing Enabled="true" />
                                    <ig:ColumnMoving Enabled="true" />
                                </Behaviors>
                            </ig:WebDataGrid>
                            </div>
                                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                                </td>
                                <td style="width:0%">
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <table style="width:100%">
                        <tr>
                            <td style="width:15%">
                            </td>
                            <td style="width:65%">
                                <asp:Button ID="btnBack" Width="100%" runat="server" Text="Volver" OnClick="btnSend_Click"  />
                            </td>
                            <td style="width:20%">
                            </td>
                        </tr>
                    </table>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
