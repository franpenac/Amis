<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterUserPage.aspx.cs" Inherits="amis._PresentationLayer.Users.RegisterUserPage" Async="true" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebSchedule.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">

    <title>Registro de usuarios</title>

    <script type="text/javascript" id="igClientScript">
        function wibExportExcel_Click(oButton, oEvent) {
            document.getElementById('wibExportTableToExcel').click();
        }
    </script>
    <script>
        function wdgMain_Selection_CellSelectionChanged_Profile(sender, eventArgs) {
            var grid = $find("wdgMain");
            var gridBehaviors = grid.get_behaviors();
            var cell = gridBehaviors.get_selection().get_selectedCells().getItem(0);
            var index = cell.get_index();

            if (index == 8) {
                var row = gridBehaviors.get_selection().get_selectedCells().getItem(0).get_row(0);
                var index = row.get_index();
                __doPostBack('<%= wdgMain.ClientID %>', 'wdgEnable;' + index);
            }
            else if (index == 0) {
                var row = gridBehaviors.get_selection().get_selectedCells().getItem(0).get_row(0);
                var index = row.get_index();
                __doPostBack('<%= wdgMain.ClientID %>', 'wdgProfile;' + index);
            }
            else if (index == 1) {
                var row = gridBehaviors.get_selection().get_selectedCells().getItem(0).get_row(0);
                var index = row.get_index();
                __doPostBack('<%= wdgMain.ClientID %>', 'wdgAlarm;' + index);
            }
            else{
                var row = gridBehaviors.get_selection().get_selectedCells().getItem(0).get_row(0);
                var index = row.get_index();
                __doPostBack('<%= wdgMain.ClientID %>', 'wdgMain;' + index);
            }
    }
    </script>
    <script type="text/javascript">
        function onlyLetters(e) {

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

            if (code == 38 || code == 39 || code == 32) {
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

        .imgPosition {
            float: initial;
        }

        .divContainer {
            position: relative;
            width: 70%;
            height: 100%;
            margin: 0 auto;
        }

        .divButtonLeft {
            width: 50%;
            height: 100%;
            float: left;
        }

        .divButtonRight {
            width: 50%;
            height: 100%;
            float: right;
        }
    </style>
    <style>
        .lblFormat {
            margin-top: 7px;
        }

        .hiddeTextBox {
            visibility: hidden;
        }
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 10px">
                </br></br></br><h1 id="h1OptionMenuPageName" runat="server">
                    Administrador de usuarios
                </h1>              
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <asp:Label runat="server" ID="txtRegisterMessage" Text="Creación de usuarios para el sistema" Font-Size="Medium"></asp:Label>
                <br />
                <br />
                <br />
                <div style="margin-left: 56px; text-align: right">
                    <table>
                        <tr>
                            <td>
                            </td>
                            <td style="vertical-align: top" class="auto-style3">&nbsp;</td>
                            <td style="vertical-align: top">
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblUserId" Visible="false" Enabled="false"></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top" class="auto-style3">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblMember" runat="server" Text="Miembro" CssClass="lblFormat"></asp:Label>
                                </div>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <ig:WebDropDown ID="wddMember" runat="server" Width="200px" OnSelectionChanged="wddMember_SelectionChanged">
                                    <AutoPostBackFlags SelectionChanged="On"/>
                                </ig:WebDropDown>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top" class="auto-style3">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="Label4" runat="server" Text="Email Miembro" CssClass="lblFormat"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                <ig:WebTextEditor ID="wteUserEmail" runat="server" Width="300px" ReadOnly="true"></ig:WebTextEditor>
                            </td>
                            <td>
                                <td>
                                    <igtxt:WebImageButton ID="wibSendPassword" runat="server" Text="Enviar nueva contraseña" OnClick="wivForwardPasswordEmail_Click">
                                        <Appearance>
                                            <Image Url="../../ig_common/images/SendPassword.png" />
                                            <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px" Width="200px">
                                            </ButtonStyle>
                                        </Appearance>
                                    </igtxt:WebImageButton>
                                </td>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top; float:left">
                                <asp:Label runat="server" ID="lblMessageRecovery" Text="Opción para recuperación de contraseña" Font-Size="Small"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblSecondaryEmail" runat="server" Text="Correo alternativo" CssClass="lblFormat"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                <ig:WebTextEditor ID="wteSecondaryEmail" runat="server" Width="300px"></ig:WebTextEditor>
                            </td>
                            <td>
                                <td>
                                    <igtxt:WebImageButton ID="wivSecondaryPasswordEmail" runat="server" Text="Enviar nueva contraseña" OnClick="wivSecondaryPasswordEmail_Click">
                                        <Appearance>
                                            <Image Url="../../ig_common/images/SendPassword.png" />
                                            <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px" Width="200px">
                                            </ButtonStyle>
                                        </Appearance>
                                    </igtxt:WebImageButton>
                                </td>
                            </td>
                        </tr>
                    </table>
                </div>
                <hr />
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
                                <igtxt:WebImageButton ID="wibExportExcel" runat="server" Text="Exportar a Excel" Width="134px" Height="30px" OnClick="wibExportExcel_Click">
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

                <ig:WebDataGrid ID="wdgMain" ClientIDMode="Static" runat="server" Height="350px" Width="1020px"
                    AutoGenerateColumns="False" DataKeyFields="UserId">
                    <Columns>
                        <ig:TemplateDataField Key="UserMenuOptionRow" Width="100px">
                            <ItemTemplate>
                                <asp:Image runat="server" ImageAlign="Bottom" ID="imgUserMenuOption" ToolTip="Asignar permisos de usuario" ImageUrl="~/ig_common/images/ProfileUser1.png" ></asp:Image>
                            </ItemTemplate>
                            <Header Text="Modificar Perfil"></Header>
                        </ig:TemplateDataField>
                        <ig:TemplateDataField Key="UserAlarm" Width="63px">
                            <ItemTemplate>
                                <asp:Image runat="server" ImageAlign="Bottom" ID="imgUserAlarm" ToolTip="Asignar alarmas" ImageUrl="~/ig_common/images/alarm16x16.png"  ></asp:Image>
                            </ItemTemplate>
                            <Header Text="Alarmas"></Header>
                        </ig:TemplateDataField>
                        <ig:BoundDataField DataFieldName="UserId" DataType="System.UInt32" Key="UserId" Hidden="True">
                            <Header Text="Id usuario">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Email" Key="Email" Width="220px">
                            <Header Text="Email usuario">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="Password" Key="Password" Hidden="True">
                            <Header Text="Password">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="SecretQuestion" Key="SecretQuestion" Hidden="true">
                            <Header Text="Pregunta secreta">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="SecretAnswer" Key="SecretAnswer" Hidden="True">
                            <Header Text="Respuesta secreta">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="EnabledDescription" Key="EnabledDescription" Width="95px">
                            <Header Text="Estado">
                            </Header>
                        </ig:BoundDataField>
                        <ig:TemplateDataField Key="EnabledRow" Width="70px">
                            <ItemTemplate>
                                 <asp:Image runat="server" ID="UserEnabled" ToolTip="Habilitar o Deshabilitar Usuario" CommandName="UserEnabled"
                                      CommandArgument='<%# DataBinder.Eval(((Infragistics.Web.UI.TemplateContainer)Container).Item, "Row.Index") %>' ImageUrl = '<%# DataBinder.Eval(((Infragistics.Web.UI.TemplateContainer)Container).DataItem, "EnabledImage") %>'></asp:Image>
                            </ItemTemplate>
                            <Header Text="Habilitar"></Header>
                        </ig:TemplateDataField>
                        <ig:BoundDataField DataFieldName="Name" Key="Name" Width="300px">
                            <Header Text="Nombre usuario">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="CreatedDate" Key="CreatedDate" Width="105px">
                            <Header Text="Fecha creación">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="ChangePasswordPage" Key="ChangePasswordPage" Hidden="true">
                            <Header Text="Pagina cambio de clave">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="DisabledDate" Key="DisabledDate">
                            <Header Text="Fecha Inhabilitado"></Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="MemberId" Key="MemberId" Hidden="true">
                            <Header Text="Member Id"></Header>
                        </ig:BoundDataField>
                    </Columns>
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection RowSelectType="Single" Enabled="true" EnableHiddenSelection="false">
                            <SelectionClientEvents CellSelectionChanged="wdgMain_Selection_CellSelectionChanged_Profile"></SelectionClientEvents>
                        </ig:Selection>
                        <ig:Paging FirstPageText="<|" LastPageText="|>" NextPageText=">" PreviousPageText="<" PageSize="10" Enabled="true"/>
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
                                    <div style="font-family: Arial; font-size: 20px; color: white; background: url('http://newevangelizationministries.org/images/Slate.jpg'); text-align: left; width: 400px">
                                        <asp:Label ID="Label3" runat="server" Text="Amis">
                                        </asp:Label>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <div class="divContainer">
                            <br />
                            <div style="text-align: center">
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="Label2" runat="server" Text="No puede asignar permisos a usuarios DESHABILITADOS"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <div style="margin-left: 25%; margin-right: 40%">
                                <igtxt:WebImageButton ID="wibConfirmar" runat="server" Text="Ok" Width="134px" Height="30px" OnClick="wibConfirmar_Click">
                                    <Appearance>
                                        <Image Url="../../ig_common/images/ok.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%-- Otro popup--%>
            <asp:Button ID="btnEnable" Style="display: none" runat="server" />
            <cc1:ModalPopupExtender ID="mpeEnable" runat="server"
                TargetControlID="btnEnable" CancelControlID="btnEnable" OkControlID="btnEnable"
                PopupControlID="popHabilitar">
            </cc1:ModalPopupExtender>
            <div id="popHabilitar" class="popupPanelClass" style="display: none; height: 215px; background-color: snow; width: 400px">
                <div class="popupContainerClass">
                    <%--BARRA DE TITULO--%>
                    <div id="popupHeaderHabilitar">
                        <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="350px">
                            <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                    <div style="font-family: Arial; font-size: 20px; color: white; background: url('http://newevangelizationministries.org/images/Slate.jpg'); text-align: left; width: 400px">
                                        <asp:Label ID="Label1" runat="server" Text="Amis">
                                        </asp:Label>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <div class="divContainer">
                            <br />
                            <div style="text-align: center">
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblEnabledMessage" runat="server"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <div class="divButtonLeft">
                                <igtxt:WebImageButton ID="wibConfirmEnable" runat="server" Text="Confirmar" Width="134px" Height="30px" OnClick="wibConfirmEnable_Click">
                                    <Appearance>
                                        <Image Url="../../ig_common/images/ok.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </div>
                            <div class="divButtonRight">
                                <igtxt:WebImageButton ID="wibCancelEnable" runat="server" Text="Cancelar" Width="134px" Height="30px" OnClick="wibCancelEnable_Click">
                                    <Appearance>
                                        <Image Url="../../ig_common/images/cancel16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
              <%--POPUP Permisos--%>
            <asp:Button ID="Button1" Style="display: none" runat="server" />
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                TargetControlID="btnConfirmar" CancelControlID="btnConfirmar" OkControlID="btnConfirmar"
                PopupControlID="panConfirmar">
            </cc1:ModalPopupExtender>
            <div id="panConfirmar1" class="popupPanelClass" style="display: none; height: 215px; background-color: snow; width: 400px">
                <div class="popupContainerClass">
                    <%--BARRA DE TITULO--%>
                    <div id="popupHeaderConfirmar1">
                        <asp:Table ID="Table2" runat="server" BorderStyle="Solid" BorderWidth="0.5px" Height="20px" Width="350px">
                            <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="0.5px">
                                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="0.5px">
                                    <div style="font-family: Arial; font-size: 20px; color: white; background: url('http://newevangelizationministries.org/images/Slate.jpg'); text-align: left; width: 400px">
                                        <asp:Label ID="Label5" runat="server" Text="Amis">
                                        </asp:Label>
                                    </div>
                                </asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                        <div class="divContainer">
                            <br />
                            <div style="text-align: center">
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblPermission" runat="server"></asp:Label>
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <div style="margin-left: 25%; margin-right: 40%">
                                <igtxt:WebImageButton ID="WebImageButton1" runat="server" Text="Ok" Width="134px" Height="30px" OnClick="wibConfirmar_Click">
                                    <Appearance>
                                        <Image Url="../../ig_common/images/ok.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="divAux" runat="server"></div>
    <igtxt:WebImageButton ID="wibExportTableToExcel" ClientIDMode="Static"
        runat="server" CssClass="buttonExport" Text="Exportar a Excel" Width="120px" OnClick="wibExportTableToExcel_Click">
    </igtxt:WebImageButton>
</asp:Content>
