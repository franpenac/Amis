<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssetUniqueIdentificationPage.aspx.cs" Inherits="amis._PresentationLayer.Configuration.AssetUniqueIdentificationPage" %>

<%@ Register Assembly="Infragistics45.WebUI.WebSchedule.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>
<%@ Register Src="~/_PresentationLayer/Configuration/WucSettingExtinguisher.ascx" TagPrefix="uc1" TagName="WucSettingExtinguisher" %>
<%@ Register Src="~/_PresentationLayer/Configuration/WucSettingBattery.ascx" TagPrefix="uc1" TagName="WucSettingBattery" %>
<%@ Register Src="~/_PresentationLayer/Configuration/WucSettingCat.ascx" TagPrefix="uc1" TagName="WucSettingCat" %>
<%@ Register Src="~/_PresentationLayer/Configuration/WucSettingRadio.ascx" TagPrefix="uc1" TagName="WucSettingRadio" %>
<%@ Register Src="~/_PresentationLayer/Configuration/WucSettingLigthPole.ascx" TagPrefix="uc1" TagName="WucSettingLigthPole" %>
<%@ Register Src="~/_PresentationLayer/Configuration/WucSettingTyre.ascx" TagPrefix="uc1" TagName="WucSettingTyre" %>








<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">
    <link rel="stylesheet" type="text/css" href="~/Content/css/buttonStyle.css">

<script type="text/javascript" id="igClientScript">

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

function wibExportExcel_Click(oButton, oEvent) {
    document.getElementById('wibExportTableToExcel').click();
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

    function textbox_text_onkeypress(e) {

        if (window.event) {
            code = e.keyCode;
        } else {
            code = e.which;
        };
        if (code >= 64 && code <= 90) {
            return true;
        }

        if (code >= 97 && code <= 122) {
            return true;
        }

        if (code >= 48 && code <= 57) {
            return true;
        }

        if (code == 45 || code == 42 || code == 95 || code == 94 || code == 46 || code == 38 || code == 32) {
            return true;
        }

        event.preventDefault();
        return false;
    }

</script>
    <style type="text/css">
        .auto-style3 {
            height: 11px;
        }
        .auto-style4 {
            width: 94px;
        }
        .auto-style6 {
            height: 11px;
            width: 94px;
        }
    </style>
    <style>
        .buttonExcel{
            visibility:hidden;
        }
    </style>
    <style>
        .buttonExport {
            visibility:hidden;
        }
        .igg_HeaderCaption {
            color:white;
            background:url());
            text-align:center;
        }
        .buttonDesign
        {
        text-decoration:none; 
         text-align:center; 
         padding:3px 35px; 
         border: 0px solid #848484; 
        -webkit-border-radius: 30px; 
        -moz-border-radius: 30px; 
        border-radius: 30px; 
        outline:0;  
         font:15px "Arial Black", Gadget, sans-serif; 
         font-weight:bold; 
         color:#ffffff; 
         background:#114868; 
         -webkit-box-shadow:0px 0px 0px #bababa, inset 0px 0px 0px #ffffff; 
         -moz-box-shadow: 0px 0px 0px #bababa,  inset 0px 0px 0px #ffffff;  
         box-shadow:0px 0px 0px #bababa, inset 0px 0px 0px #ffffff;   
        }

        .textBoxDesign
  {
    -webkit-border-radius: 30px; 
    -moz-border-radius: 30px; 
    border-radius: 30px; 
    outline:0; 
    height:25px; 
    width: 275px; 
    padding-left:10px; 
    padding-right:10px; 
  } 
        .importantMessage
        {
            font-family:'Times New Roman', Times, serif;
            color:red;
            font-size:medium;
        }
    </style>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 10px">
                </br></br></br><h1 id="h1OptionMenuPageName" runat="server">
                   Configuración única de activos
                </h1>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                
                <hr />
                    <asp:Label runat="server" Text="IMPORTANTE" Font-Bold="true" CssClass="importantMessage"></asp:Label>
                    <br />
                    <asp:Label runat="server" style="font-family: Arial; font-size: 13px" Text="Si la marca o modelo buscado, no existe. Seleccione la ultima opción 'Agregar Marca/Modelo', para agregarlo."></asp:Label>
                    <hr />
                <hr style="height: 0px; color: #123455; background-color: #123455; border: none;" />

                <table>
                        <tr>
                            <td>
                                <table  style="font-family: Arial; font-size: 13px"; >
                                    <tr>
                                        <td style="vertical-align: top;text-align:right"><asp:Label ID="lblAssetType" runat="server" Text="Tipo de activo"></asp:Label></td>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"><ig:WebDropDown ID="wddAssetType" OnSelectionChanged="wddAssetType_SelectionChanged" runat="server" CssClass="textBoxDesign" Width="280px"  EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                                    <AutoPostBackFlags SelectionChanged="On" />
                                                </ig:WebDropDown></td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"></td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top;text-align:right"><asp:Label ID="lblOrigin" runat="server" Text="Procedencia"></asp:Label></td>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"><ig:WebDropDown ID="wddOrigin" OnSelectionChanged="wddOrigin_SelectionChanged" runat="server" Width="280px" CssClass="textBoxDesign" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                                    <AutoPostBackFlags SelectionChanged="On" />
                                                </ig:WebDropDown></td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"></td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top;text-align:right"><asp:Label ID="lblBrand" runat="server" Text="Marca"></asp:Label></td>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"><ig:WebDropDown ID="wddBrand" runat="server" Width="280px" CssClass="textBoxDesign" EnableAutoFiltering="Client" AutoSelectOnMatch="False" OnSelectionChanged="wddBrand_SelectionChanged">
                                                    <AutoPostBackFlags SelectionChanged="On" />
                                                </ig:WebDropDown></td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"></td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top;text-align:right"><asp:Label ID="lblAssetModel" runat="server" Text="Modelo"></asp:Label></td>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"><ig:WebDropDown ID="wddAssetModel" runat="server" CssClass="textBoxDesign" Width="280px" EnableAutoFiltering="Client" AutoSelectOnMatch="False" OnSelectionChanged="wddAssetModel_SelectionChanged">                         
                                                    <AutoPostBackFlags SelectionChanged="On" />                 
                                                </ig:WebDropDown></td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"></td>
                                    </tr>
                                    <tr>
                                        <td style="vertical-align: top;text-align:right"><asp:Label ID="lblAssetModelService" runat="server" Text="Servicio"></asp:Label></td>
                                        <td style="vertical-align: top"></td>
                                        <td style="vertical-align: top"><ig:WebDropDown ID="wddAssetModelService" runat="server" CssClass="textBoxDesign" Width="280px" EnableAutoFiltering="Client" AutoSelectOnMatch="False" OnSelectionChanged="wddAssetModelService_SelectionChanged1">
                                                    <AutoPostBackFlags SelectionChanged="On" />
                                                </ig:WebDropDown></td>
                                    </tr>
                                </table>
                            </td>
                  
                            <%-- Pestaña de al lado  --%>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <div id="DivUserControl" runat="server">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                            <uc1:WucSettingTyre runat="server" id="WucSettingTyre" />
                                                            <uc1:WucSettingExtinguisher runat="server" id="WucSettingExtinguisher" />
                                                            <uc1:WucSettingBattery runat="server" id="WucSettingBattery" />
                                                            <uc1:WucSettingCat runat="server" id="WucSettingCat" />
                                                            <uc1:WucSettingRadio runat="server" id="WucSettingRadio" />
                                                            <uc1:WucSettingLigthPole runat="server" id="WucSettingLigthPole" />
                                                            </td>
                                                            </tr><tr>
                                                            <td style="text-align:center;" id="SaveBtn" runat="server">
                                                                <igtxt:WebImageButton ID="wibSaveModel" runat="server" Text="Agregar" Width="142px" Height="30px" OnClick="wibSaveModel_Click">
                                                                <Appearance>
                                                                    <Image Url="/ig_common/images/add16x16.png" />
                                                                    <ButtonStyle CssClass="buttonDesign">
                                                                    </ButtonStyle>
                                                                </Appearance>
                                                                </igtxt:WebImageButton>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            <div id="DivNewBrand" runat="server" style="float:right">
                                                <table>
                                                    <tr>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top">&nbsp;</td>

                                                        <td style="vertical-align: top">
                                                            <div style="font-family: Arial; font-size: 13px; padding-top:5px; text-align:center">
                                                                <asp:Label ID="lblNewBrand" runat="server"  Text="Nueva Marca"></asp:Label>
                                                            </div>
                                                        </td>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                        <td style="vertical-align: top; text-align:center"">
                                                            <ig:WebTextEditor ID="wteNewBrand" CssClass="textBoxDesign" onkeyPress="return textbox_text_onkeypress(event)" runat="server" Width="150px"></ig:WebTextEditor>
                                                        </td>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                        <td style="vertical-align: top; text-align:center">
                                                            <igtxt:WebImageButton ID="wibSaveNewBrand" runat="server" OnClick="wibSaveNewBrand_Click" Text="Agregar" Width="142px" Height="30px">
                                                                <Appearance>
                                                                <Image Url="/ig_common/images/add16x16.png" />
                                                                <ButtonStyle CssClass="buttonDesign">
                                                                </ButtonStyle>
                                                            </Appearance>
                                                            </igtxt:WebImageButton>
                                                        </td>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div id="DivNewModel" runat="server">
                                                <table>
                                                    <tr>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                        <td style="vertical-align: top; text-align:center"">
                                                            <div style="font-family: Arial; font-size: 13px; padding-top:5px; text-align:center">
                                                                <asp:Label ID="lblNewModel" runat="server" Text="Nuevo Modelo"></asp:Label>
                                                            </div>
                                                        </td>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                        <td style="vertical-align: top; text-align:center"">
                                                            <ig:WebTextEditor ID="wteNewModel" runat="server" CssClass="textBoxDesign" Width="150px"></ig:WebTextEditor>
                                                        </td>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                        <td style="vertical-align: top; text-align:center">
                                                            <igtxt:WebImageButton ID="wibSaveNewModel" runat="server" onkeyPress="return textbox_text_onkeypress(event)" OnClick="wibSaveNewModel_Click" Text="Agregar" Width="142px" >
                                                                <Appearance>
                                                                <Image Url="/ig_common/images/add16x16.png" />
                                                                <ButtonStyle CssClass="buttonDesign">
                                                                </ButtonStyle>
                                                            </Appearance>
                                                            </igtxt:WebImageButton>
                                                        </td>
                                                        <td style="vertical-align: top">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                </table> 
                <br />
                    
                    <table>
                        <tr>
                            <div id="DivButtons" runat="server">
                            <td runat="server" id="tdSave">
                                <igtxt:WebImageButton ID="wibSave" runat="server" Text="Grabar" Width="142px" Height="30px" OnClick="wibSave_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/save16x16.png" />
                                        <ButtonStyle CssClass="buttonDesign">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
                             </div>
                            <td></td>
                            <td runat="server" id="tdNew">
                                <igtxt:WebImageButton ID="wibNew" runat="server" Text="Nuevo" Width="142px" Height="30px" OnClick="wibNew_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/new16x16.png" />
                                        <ButtonStyle CssClass="buttonDesign">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
                            <td></td>
                           
                            <td runat="server" id="tdExportExcel">
                                <igtxt:WebImageButton ID="wibExportExcel" runat="server" Visible="true" Text="Exportar" Width="142px" Height="30px" >
                                    <ClientSideEvents Click="wibExportExcel_Click" />
                                    <Appearance>
                                        <Image Url="/ig_common/images/Report16x16.png" />
                                        <ButtonStyle CssClass="buttonDesign">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <br />

                <ig:WebDataGrid ID="wdgMain" ClientIDMode="Static" runat="server" Height="415px" Width="800px" 
                    AutoGenerateColumns="False" DataKeyFields="AssetUniqueIdentificationId"
                    OnRowSelectionChanged="wdgMain_Selection_RowSelectionChanged" >
                    <Columns>
                        <ig:TemplateDataField Width="60px" Key="DeleteRow">
                            <ItemTemplate>              
                                    <asp:ImageButton ID="imgDelete" runat="server"
                                        ImageUrl="~/ig_common/images/trash-delete-16x16.png" /> 
                                </ItemTemplate>
                        <Header Text="Eliminar"></Header>
                        </ig:TemplateDataField>
                        <ig:BoundDataField DataFieldName="AssetUniqueIdentificationId" DataType="System.UInt32" Key="AssetUniqueIdentificationId" Hidden="True">
                            <Header Text="Id Identificacion">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AssetTypeId" Key="AssetTypeId" Hidden="True">
                            <Header Text="Id Tipo">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AssetTypeName" Key="AssetTypeName">
                            <Header Text="Tipo">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="OriginId" Key="OriginId" Hidden="True">
                            <Header Text="Id Origen">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="OriginName" Key="OriginName">
                            <Header Text="Origen">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="BrandId" Key="BrandId" Hidden="True">
                            <Header Text="Id Marca">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="BrandName" Key="BrandName">
                            <Header Text="Marca">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AssetModelId" Key="AssetModelId" Hidden="True">
                            <Header Text="Id Modelo">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AssetModelName" Key="AssetModelName">
                            <Header Text="Modelo">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AssetModelServiceId" Key="AssetModelServiceId" Hidden="True">
                            <Header Text="Id Service">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AssetModelServiceName" Key="AssetModelServiceName">
                            <Header Text="Servicio">
                            </Header>
                        </ig:BoundDataField>
                    </Columns>
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection RowSelectType="Single" Enabled="true" EnableHiddenSelection="True">
                            <SelectionClientEvents CellSelectionChanged="wdgMain_Selection_CellSelectionChanged_Delete"></SelectionClientEvents>
                        </ig:Selection>
                        <ig:Paging PagerMode="Numeric" FirstPageText="<|" LastPageText="|>" NextPageText=">" PreviousPageText="<" PagerAppearance="Bottom" PageSize="10" Enabled="true" />
                        <ig:Sorting SortingMode="Multi" Enabled="true" />
                        <ig:ColumnResizing Enabled="true" />
                        <ig:ColumnMoving Enabled="true" />
                    </Behaviors>
                </ig:WebDataGrid>
            </div>

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