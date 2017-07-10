<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OperationRegisterPage.aspx.cs" Inherits="amis._PresentationLayer.OperationModule.OperationRegisterPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css"/>
    <link rel="stylesheet" type="text/css" href="~/Content/css/buttonStyle.css"/>
    <link rel="stylesheet" type="text/css" href="~/Content/StyleOperation.css"/>
    <link id="stil" runat="server" href="StyleOperation.css" rel="stylesheet" type="text/css" />
    chambe

<script type="text/javascript" id="igClientScript">


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

    function textbox_text_onkeypress(e) {

        if (window.event) {
            code = e.keyCode;
        } else {
            code = e.which;
        };
        if (code >= 65 && code <= 90) {
            return true;
        }
        if (code == 225 || code == 233 || code == 237 || code == 243 || code == 250 || code == 241) {
            return true;
        }
        if (code >= 97 && code <= 122) {
            return true;
        }

        if (code >= 45 && code <= 57) {
            return true;
        }

        if (code == 45 || code == 46 || code == 38 || code == 32 || code == 44) {
            return true;
        }

        event.preventDefault();
        return false;
    }
</script>
    <style type="text/css">
        .labelStyle
        {
            font-family: Arial;
             font-size: 13px;
        }
        .auto-style1 {
            width: 180px;
        }

        .PEPITO {
            color:white;
            background:url('http://newevangelizationministries.org/images/Slate.jpg');
            text-align:center;
            align-content:center;
        }
        .buttonExport {
            visibility:hidden;
        }
    </style>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 10px">
                </br></br></br><h1 id="h1OptionMenuPageName" runat="server">
                    Registro de operaciones-clientes
                </h1>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <table>
                    <tr>
                        <td style="font-family: Arial;font-size: 13px; width:100px">
                            <asp:Label ID="lblBranchOffice" runat="server" Text="Sucursal"></asp:Label>
                        </td>
                        <td style="font-family: Arial;font-size: 13px; width:200px">
                            <asp:DropDownList ID="ddlBranchOffice" runat="server"  Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlBranchOffice_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <td style="font-family: Arial;font-size: 13px; width:100px">
                            <asp:Label ID="lblCliente" runat="server" Text="Cliente"></asp:Label>
                        </td>
                        <td style="font-family: Arial;font-size: 13px; width:200px">
                            <asp:DropDownList ID="ddlClientMember" runat="server" Width="100%"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <br />
                <table>
                    <tr>
                        <td style="font-family: Arial;font-size: 13px; width:100px">
                            <asp:Label ID="lblOperationName" runat="server" Text="Operación"></asp:Label>
                        </td>
                        <td style="font-family: Arial;font-size: 13px; width:200px">
                            <ig:WebTextEditor ID="wteOperationName" CssClass="textBoxDesign" onkeyPress="return textbox_text_onkeypress(event)" runat="server" Width="100%"></ig:WebTextEditor>
                        </td>
                    </tr>
                </table>
                <br />
                       
                    
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
                                <igtxt:WebImageButton ID="wibExportExcel" runat="server" Text="Exportar" Width="142px" Height="30px" Visible="true" >
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
                    AutoGenerateColumns="False" DataKeyFields="OperationId"
                    OnRowSelectionChanged="wdgMain_Selection_RowSelectionChanged">
                    <Columns>
                        <ig:TemplateDataField Width="60px" Key="DeleteRow">
                            <ItemTemplate>
                                <asp:Image runat="server" id="imgDelete" ImageUrl="~/ig_common/images/trash-delete-16x16.png" CommandName="DeleteRow" CommandArgument='<%# DataBinder.Eval(((Infragistics.Web.UI.TemplateContainer)Container).Item, "Row.Index") %>'></asp:Image>
                            </ItemTemplate><Header Text="Eliminar"></Header>
                        </ig:TemplateDataField>
                        <ig:BoundDataField DataFieldName="OperationId" DataType="System.UInt32" Key="OperationId" Hidden="True" VisibleIndex="0">
                            <Header Text="Id Operación">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="OperationName"  Key="OperationName" >
                            <Header Text="Operación" CssClass="igg_HeaderCaption" >
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="BranchOfficeId"  Key="BranchOfficeId" Hidden="true">
                            <Header Text="Id Sucursal" CssClass="igg_HeaderCaption" >
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="BranchOfficeName"  Key="BranchOfficeName" >
                            <Header Text="Sucursal" CssClass="igg_HeaderCaption" >
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="MemberId"  Key="MemberId" Hidden="true">
                            <Header Text="Id Integrante" CssClass="igg_HeaderCaption" >
                            </Header>  
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="MemberName"  Key="MemberName" >
                            <Header Text="Integrante" CssClass="igg_HeaderCaption" >
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