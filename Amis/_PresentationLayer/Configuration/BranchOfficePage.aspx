<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BranchOfficePage.aspx.cs" Inherits="amis._PresentationLayer.Configuration.BranchOfficePage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">
    <link rel="stylesheet" type="text/css" href="~/Content/css/buttonStyle.css">

<script type="text/javascript" id="igClientScript">


function wibExportExcel_Click(oButton, oEvent) {
    document.getElementById('wibExportTableToExcel').click();
}

function wdgMain_Selection_CellSelectionChanged_Delete(sender, eventArgs)
{
    var grid = $find("wdgMain");
    var gridBehaviors = grid.get_behaviors();
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

    function textbox_validate_onkeypress(e) {

        if (window.event) {
            code = e.keyCode;
        } else {
            code = e.which;
        };
        if (code >= 65 && code <= 90) {
            return true;
        }

        if (code >= 97 && code <= 122) {
            return true;
        }

        if (code >= 44 && code <= 57) {
            return true;
        }

        if (code == 39 || code == 38 || code == 32) {
            return true;
        }

        if (code == 225 || code == 233 || code == 237 || code == 243 || code == 250 || code == 241) {
            return true;
        }

        event.preventDefault();
        return false;
    }

</script>
        <style>
        .buttonExport {
            visibility:hidden;
        }
        .igg_HeaderCaption {
            color:white;
            background:url('http://newevangelizationministries.org/images/Slate.jpg');
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
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 10px">
                </br></br></br><h1 id="h1OptionMenuPageName" runat="server">
                    Registro de sucursales
                </h1>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <table>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px; padding-top:5px; text-align:right">
                                <asp:Label ID="lblBranchOfficeName" runat="server" Text="Nombre Sucursal"></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <ig:WebTextEditor ID="wteBranchOfficeName" runat="server" CssClass="textBoxDesign" onkeyPress="return textbox_validate_onkeypress(event);" Width="300px"></ig:WebTextEditor>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                     <tr>
                            <td style="vertical-align: top">
                                <div style="font-family: Arial; font-size: 13px; padding-top:5px; text-align:right">
                                    <asp:Label ID="lblRegion" runat="server" Text="Región"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                <ig:WebDropDown ID="wddRegion" runat="server" Width="280px" CssClass="textBoxDesign" OnSelectionChanged="wddRegion_SelectionChanged" OnValueChanged="wddRegion_ValueChanged" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                    <AutoPostBackFlags SelectionChanged="On" />
                                </ig:WebDropDown>
                            </td>
                        </tr>
                        <div id="divCommune" runat="server">
                        <tr>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">
                                <div style="font-family: Arial; font-size: 13px; padding-top:5px; text-align:right">
                                    <asp:Label ID="lblCommune" runat="server" Text="Comuna"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                <ig:WebDropDown ID="wddCommune" runat="server" Width="280px" CssClass="textBoxDesign" OnSelectionChanged="wddCommune_SelectionChanged" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                    <AutoPostBackFlags SelectionChanged="On" />
                                </ig:WebDropDown>
                            </td>
                        </tr>
                        </div>
                        <div id="divLocation" runat="server">
                        <tr>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">
                                <div style="font-family: Arial; font-size: 13px; padding-top:5px; text-align:right">
                                    <asp:Label ID="lblLocationName" runat="server" Text="Dirección"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                <ig:WebTextEditor ID="wteLocationName" runat="server" CssClass="textBoxDesign" onkeyPress="return textbox_validate_onkeypress(event);" Width="300px"></ig:WebTextEditor>
                            </td>
                        </tr>
                        </div>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                </table>
                <br />
                <br />
                <div>
                    <table>
                        <tr>
                            <td runat="server" id="tdSave">
                                <igtxt:WebImageButton ID="wibSave" runat="server" Text="Grabar" Width="142px" Height="30px" OnClick="wibSave_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/save16x16.png" />
                                        <ButtonStyle CssClass="buttonDesign">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
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

                <ig:WebDataGrid ID="wdgMain" ClientIDMode="Static" runat="server" Height="350px" Width="800px" 
                    AutoGenerateColumns="False" DataKeyFields="BranchOfficeId"
                    OnRowSelectionChanged="wdgMain_Selection_RowSelectionChanged">
                    <Columns>
                        <ig:TemplateDataField Width="60px" Key="DeleteRow">
                            <ItemTemplate>              
                                    <asp:ImageButton ID="imgDelete" runat="server"
                                        ClientIDMode="static" ImageUrl="~/ig_common/images/trash-delete-16x16.png" />
                            </ItemTemplate>
                            <Header Text="Eliminar"></Header>
                        </ig:TemplateDataField>
                        <ig:BoundDataField DataFieldName="BranchOfficeId" DataType="System.UInt32" Key="BranchOfficeId" Hidden="True">
                            <Header Text="Id Sucursal">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="BranchOfficeName" Key="BranchOfficeName">
                            <Header Text="Sucursal">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RegionId" Key="RegionId" Hidden="true">
                            <Header Text="Id Region">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="RegionName" Key="RegionName">
                            <Header Text="Región">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="CommuneId" Key="CommuneId" Hidden="True">
                            <Header Text="Id Comuna">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="CommuneName" Key="CommuneName">
                            <Header Text="Comuna">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="LocationId" Key="LocationId" Hidden="True">
                            <Header Text="Id Localizacion">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="LocationName" Key="LocationName">
                            <Header Text="Dirección">
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

    <igtxt:WebImageButton ID="wibExportTableToExcel" Visible="true" ClientIDMode="Static" 
        runat="server" CssClass="buttonExport" Text="Exportar a Excel" Width="120px" OnClick="wibExportTableToExcel_Click">
    </igtxt:WebImageButton>
</asp:Content>