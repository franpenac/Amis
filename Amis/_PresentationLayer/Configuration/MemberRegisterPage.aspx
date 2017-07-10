<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberRegisterPage.aspx.cs" Inherits="amis._PresentationLayer.Configuration.MemberRegisterPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">
    <link rel="stylesheet" type="text/css" href="~/Content/css/buttonStyle.css">
    <script type="text/javascript" id="igClientScript">

        function renameRutAndProcess(obj) {
            //var rut = obj.value;
            //if (!/\./.test(rut)) {
            //    var nuevo = "";
            //    for (var i = 0; i < rut.length; i++) {
            //        if (i == 1 || i == 4) {
            //            nuevo += rut[i] + '.';
            //        } else if (i == (rut.length - 1)) {
            //            nuevo += '-' + rut[i];
            //        } else {
            //            nuevo += rut[i];
            //        }
            //    }
            //    obj.value = nuevo;
            //}
            //var rut = obj.value;
            //if (!/\./.test(rut)) {
            //    var nuevo = "";
            //    var contador = 0;
            //    for (var i = rut.length - 1; i > 0; i--) {
            //        if (contador == 3) {
            //            nuevo = rut[i]+'.' + nuevo;
            //            contador = 1;
            //        } else {
            //            nuevo = rut[i] + nuevo;
            //            contador = contador + 1;
            //        }
            //    }
            
            //    obj.value = nuevo;}

        }

        function wibExportExcel_Click(oButton, oEvent) {
            document.getElementById('wibExportTableToExcel').click();
        }

        function wdgMain_Selection_CellSelectionChanged_Delete(sender, eventArgs) {

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
    };
}

function textbox_letter_onkeypress(e) {

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

    if (code >= 160 && code <= 163) {
        return true;

    }

    if (code >= 44 && code <= 47) {
        return true;

    }

    if (code == 225 || code == 233 || code == 237 || code == 243 || code == 250) {
        return true;
    }

    if (code == 38 || code == 39 || code == 32 || code == 130 || code == 164 || code == 241) {
        return true;
    }
    event.preventDefault();
    return false;
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

    if (code == 107) {
        return true;
    }

    event.preventDefault();
    return false;
}

function textbox_email_onkeypress(e) {

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

    if (code == 45 || code == 42 || code == 95 || code == 94 || code == 46 || code == 38) {
        return true;
    }

    event.preventDefault();
    return false;
}



    </script>

    <style>
        .buttonExport {
            visibility: hidden;
        }

        .igg_HeaderCaption {
            color: white;
            background: url('http://newevangelizationministries.org/images/Slate.jpg');
            text-align: center;
        }

        .buttonDesign {
            text-decoration: none;
            text-align: center;
            padding: 3px 35px;
            border: 0px solid #848484;
            -webkit-border-radius: 30px;
            -moz-border-radius: 30px;
            border-radius: 30px;
            outline: 0;
            font: 15px "Arial Black", Gadget, sans-serif;
            font-weight: bold;
            color: #ffffff;
            background: #114868;
            -webkit-box-shadow: 0px 0px 0px #bababa, inset 0px 0px 0px #ffffff;
            -moz-box-shadow: 0px 0px 0px #bababa, inset 0px 0px 0px #ffffff;
            box-shadow: 0px 0px 0px #bababa, inset 0px 0px 0px #ffffff;
        }

        .textBoxDesign {
            -webkit-border-radius: 30px;
            -moz-border-radius: 30px;
            border-radius: 30px;
            outline: 0;
            height: 25px;
            width: 275px;
            padding-left: 10px;
            padding-right: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 10px">
                </br></br></br><h1 id="h1OptionMenuPageName" runat="server">
                    Registro de integrantes
                </h1>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <table>
                    <tr>
                        <td style="vertical-align: top; padding-top: 5px; text-align: right">
                            <div style="font-family: Arial; font-size: 13px">Nombre </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <ig:WebTextEditor ID="wteMemberName" ClientIDMode="Static" CssClass="textBoxDesign" runat="server" onkeyPress="return textbox_letter_onkeypress(event);" Width="300px" MaxLength="255"></ig:WebTextEditor>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top; padding-top: 5px; text-align: right">
                            <div style="font-family: Arial; font-size: 13px">Rut</div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <ig:WebTextEditor ID="wteMemberRut" runat="server" CssClass="textBoxDesign" onkeyPress="return textbox_number_onkeypress(event);" OnTextChanged="wteMemberRut_TextChanged" AutoPostBackFlags-ValueChanged="On"  Width="300px" MaxLength="50"></ig:WebTextEditor>
                        </td>
                        <td>
                            <div style="font-family: Arial; font-size: 13px; text-emphasis-color: #808080; width: 161px;">
                                <asp:Label ID="ExampleRut" runat="server" Text="Ej: 22.334.113-6" ForeColor="Gray"></asp:Label>
                            </div>
                        </td>
                        <tr>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top; padding-top: 5px; text-align: right">
                                <div style="font-family: Arial; font-size: 13px">
                                    Email
                                </div>
                            </td>
                            <td style="vertical-align: top"></td>
                            <td style="vertical-align: top">&nbsp;<ig:WebTextEditor OnTextChanged="wteMemberEmail_TextChanged" ID="wteMemberEmail" runat="server" CssClass="textBoxDesign" onkeyPress="return textbox_email_onkeypress(event);" Width="300px" MaxLength="100">
                            </ig:WebTextEditor>
                            </td>
                            <tr>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top; padding-top: 5px; text-align: right">
                                    <div style="font-family: Arial; font-size: 13px">
                                        <asp:Label ID="lblMemberType" runat="server" Text="Tipo"></asp:Label>
                                    </div>
                                </td>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">
                                    <ig:WebDropDown ID="wddMemberType" runat="server" CssClass="textBoxDesign" Width="280px" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                    </ig:WebDropDown>
                                </td>
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
                                <igtxt:WebImageButton ID="wibExportExcel" runat="server" Visible="true" Text="Exportar" Width="142px" Height="30px">
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
                    AutoGenerateColumns="False" DataKeyFields="MemberId"
                    OnRowSelectionChanged="wdgMain_Selection_RowSelectionChanged" ItemCssClass="igeb_ItemWhite">
                    <Columns>

                        <ig:TemplateDataField Width="60px" Key="DeleteRow">
                            <ItemTemplate>
                                <asp:Image runat="server" id="imgDelete" ImageUrl="~/ig_common/images/trash-delete-16x16.png" CommandName="DeleteRow" CommandArgument='<%# DataBinder.Eval(((Infragistics.Web.UI.TemplateContainer)Container).Item, "Row.Index") %>'></asp:Image>
                            </ItemTemplate><Header Text="Eliminar"></Header>
                        </ig:TemplateDataField>

                        <ig:BoundDataField DataFieldName="MemberId" DataType="System.UInt32" Key="MemberId" Hidden="True">
                            <Header Text="Id Integrante">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="MemberName" Key="MemberName">
                            <Header Text="Integrante">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="MemberRut" Key="MemberRut">
                            <Header Text="Rut">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="MemberEmail" Key="MemberEmail">
                            <Header Text="Email">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="MemberTypeId" Key="MemberTypeId" Hidden="True">
                            <Header Text="Id tipo">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="MemberTypeName" Key="MemberTypeName">
                            <Header Text="Tipo">
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
            <asp:Button ID="btnConfirmar" Style="display: none" runat="server" />
            <cc1:ModalPopupExtender ID="mpeConfirmar" runat="server"
                TargetControlID="btnConfirmar" CancelControlID="btnConfirmar" OkControlID="btnConfirmar"
                PopupControlID="panConfirmar">
            </cc1:ModalPopupExtender>
            <div id="panConfirmar" class="popupPanelClass" style="display: none; height: 215px; background-color: snow; width: 400px">
                <div class="popupContainerClass">
                    <%--BARRA DE TITULO--%>
                    <div id="popupHeaderConfirmar">
                        <asp:Table ID="Table3" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="350px">
                            <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                    <div style="font-family: Arial; font-size: 20px; color: white; background: url('http://newevangelizationministries.org/images/Slate.jpg'); text-align: center; width: 400px">
                                        <asp:Label ID="Label3" runat="server" Text="Amis">
                                        </asp:Label>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <table id="Table4" runat="server" borderstyle="Solid" borderwidth="0.5px" width="380px" height="185px">
                            <tr>
                                <td>
                                    <div style="width: 50px"></div>
                                </td>
                                <td>
                                    <div style="width: 300px"></div>
                                </td>
                                <td>
                                    <div style="width: 50px"></div>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div style="font-family: Arial; font-size: 13px">
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


            <%--POPUP AJUSTE--%>
            <asp:Button ID="btnRut" Style="display: none" runat="server" />
            <cc1:ModalPopupExtender ID="mpeRut" runat="server"
                TargetControlID="btnRut" CancelControlID="btnRut" OkControlID="btnRut"
                PopupControlID="panrut">
            </cc1:ModalPopupExtender>
            <div id="panrut" class="popupPanelClass" style="display: none; height: 215px; background-color: snow; width: 400px">
                <div class="popupContainerClass">
                    <%--BARRA DE TITULO--%>
                    <div id="popupHeaderConfirmar2">
                        <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="350px">
                            <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                    <div style="font-family: Arial; font-size: 20px; color: white; background: url('http://newevangelizationministries.org/images/Slate.jpg'); text-align: center; width: 400px">
                                        <asp:Label ID="Label1" runat="server" Text="Amis">
                                        </asp:Label>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <table id="Table2" runat="server" borderstyle="Solid" borderwidth="0.5px" width="380px" height="185px">
                            <tr>
                                <td>
                                    <div style="width: 50px"></div>
                                </td>
                                <td>
                                    <div style="width: 300px"></div>
                                </td>
                                <td>
                                    <div style="width: 50px"></div>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div style="font-family: Arial; font-size: 13px">
                                        <asp:Label ID="lblMessage" runat="server" Text="Rut invalido!"></asp:Label>
                                    </div>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <igtxt:WebImageButton ID="wibOk" runat="server" Text="Cancelar" Width="134px" Height="30px" OnClick="wibOk_Click">
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
