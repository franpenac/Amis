<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserMenuOptionPage.aspx.cs" Inherits="amis._PresentationLayer.Users.UserMenuOptionPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebSchedule.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">

    <title>Permisos de usuario</title>

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


    </script>
    <style>
        .importantMessage
        {
            font-family:'Times New Roman', Times, serif;
            color:red;
            font-size:medium;
        }
        .chkBox
        {
            float:left;
        }
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 10px">
                </br></br></br><h1 id="h1OptionMenuPageName" runat="server">
                    Permisos de Usuario
                </h1>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <table>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px;">
                                <asp:Label ID="lblName" runat="server" Font-Bold="true" Text="Usuario a asignar permisos: "></asp:Label>
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                <asp:Label ID="lblUserName" runat="server"></asp:Label>
                                &nbsp;&nbsp;
                            </div>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <div>
                    <table>
                        <tr>
                            <td>
                                <igtxt:WebImageButton ID="wibSaveChanges" runat="server" Text="Guardar permisos" Width="134px" Height="30px" OnClick="wibSaveChanges_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/save16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
                            <td></td>
                            <td id="tdExportExcel" runat="server">
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
                            <td>
                                <igtxt:WebImageButton ID="wibReturn" runat="server" Text="Volver" Width="134px" Height="30px" OnClick="wibReturn_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/BackTo16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <asp:Label runat="server" Text="IMPORTANTE" Font-Bold="true" CssClass="importantMessage"></asp:Label>
                    <br />
                    <asp:Label runat="server" style="font-family: Arial; font-size: 13px" Text="Si el botón 'autorizar' no se encuentra chequeado, los permisos asignados no surtirán efecto."></asp:Label>
                    <hr />
                </div>
                <br />
                <table style="width: 940px">
                    <tr>
                        <td style="width: 313px"></td>
                        <td style="width: 313px"></td>
                        <td style="width: 313px">
                            <table style="width: 100%">
                                <tr style="text-align:left">
                                    <td style="width: 78px">
                                        <asp:Label runat="server" Text="Todos"></asp:Label>
                                    </td>
                                    <td style="width: 78px">
                                        <asp:Label runat="server" Text="Todos"></asp:Label>
                                    </td>
                                    <td style="width: 78px">
                                        <asp:Label runat="server" Text="Todos"></asp:Label>
                                    </td>
                                    <td style="width: 78px">
                                        <asp:Label runat="server" Text="Todos"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table style="width:940px">
                    <tr>
                        <td style="width:313px"></td>
                        <td style="width:313px"></td>
                        <td style="width:313px">
                            <table style="width:100%">
                                <tr>
                                    <td style="width:78px">
                                        <asp:CheckBox runat="server" ID="chkAuthorizeAll" AutoPostBack="true" OnCheckedChanged="chkAuthorizeAll_CheckedChanged"/>
                                    </td>
                                    <td style="width:78px">
                                        <asp:CheckBox runat="server" ID="chkCanSaveAll" AutoPostBack="true" OnCheckedChanged="chkCanSaveAll_CheckedChanged"/>
                                    </td>
                                    <td style="width:78px">
                                        <asp:CheckBox runat="server" ID="chkCanDeleteAll" AutoPostBack="true" OnCheckedChanged="chkCanDeleteAll_CheckedChanged"/>
                                    </td>
                                    <td style="width:78px">
                                        <asp:CheckBox runat="server" ID="chkGenerateReportAll" AutoPostBack="true" OnCheckedChanged="chkGenerateReportAll_CheckedChanged"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <ig:WebDataGrid ID="wdgMain" ClientIDMode="Static" runat="server" Height="350px" Width="940px" 
                    DataKeyFields="MenuOptionId" AutoGenerateColumns="False">
                    <Columns>
                        <ig:BoundDataField DataFieldName="ParentMenuOptionName" Key="ParentMenuOptionName" Width="250px">
                            <Header Text="Modulo">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="MenuOptionName" Key="MenuOptionName" Width="350px">
                            <Header Text="Pagina">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="UserId" Key="UserId" Hidden="true">
                            <Header Text="UserId">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="MenuOptionId" Key="MenuOptionId" Hidden="true">
                            <Header Text="MenuOptionId">
                            </Header>
                        </ig:BoundDataField>
                        <ig:TemplateDataField Key="CanAuthorize" Width="80px">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkAuthorize" Checked='<%# DataBinder.Eval(((Infragistics.Web.UI.TemplateContainer)Container).DataItem, "CanAuthorizeBool") %>'/>
                            </ItemTemplate>
                            <Header Text="Autorizar"></Header>
                        </ig:TemplateDataField>
                        <ig:TemplateDataField Key="CanCreate" Width="80px">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkCreate" Checked='<%# DataBinder.Eval(((Infragistics.Web.UI.TemplateContainer)Container).DataItem, "CanCreateBool") %>'/>
                            </ItemTemplate>
                            <Header Text="Grabar"></Header>
                        </ig:TemplateDataField>
                        <ig:TemplateDataField Key="CanDelete" Width="80px">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkDelete" Checked='<%# DataBinder.Eval(((Infragistics.Web.UI.TemplateContainer)Container).DataItem, "CanDeleteBool") %>' />
                            </ItemTemplate>
                            <Header Text="Eliminar"></Header>
                        </ig:TemplateDataField>
                        <ig:TemplateDataField Key="CanGenerateReport" Width="80px">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkGenerateReport"  Checked='<%# DataBinder.Eval(((Infragistics.Web.UI.TemplateContainer)Container).DataItem, "CanGenerateReportBool") %>'/>
                            </ItemTemplate>
                            <Header Text="Informe"></Header>
                        </ig:TemplateDataField>
                    </Columns>
                    <Behaviors>
                        <ig:Activation />
                        <ig:Selection RowSelectType="Single" CellClickAction="Row">
                        </ig:Selection>
                        <ig:Sorting SortingMode="Multi" />
                        <ig:ColumnResizing />
                        <ig:ColumnMoving />
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
