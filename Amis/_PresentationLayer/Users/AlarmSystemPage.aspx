<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlarmSystemPage.aspx.cs" Inherits="amis._PresentationLayer.Users.AlarmSystemPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebSchedule.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">

    <title>Alarmas de Usuario</title>
    <style>
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
                <div style="font-family: Arial; font-size: 20px; font-weight: bold">
                    Alarmas de Usuario
                </div>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <table>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px;">
                                <asp:Label ID="lblName" runat="server" Font-Bold="true" Text="Usuario a asignar alarmas: "></asp:Label>
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
                                <igtxt:WebImageButton ID="wibSaveChanges" runat="server" Text="Guardar alarmas" Width="134px" Height="30px" OnClick="wibSaveChanges_Click">
                                    <Appearance>
                                        <Image Url="/ig_common/images/save16x16.png" />
                                        <ButtonStyle BackColor="White" BorderStyle="Solid" BorderWidth="0px">
                                        </ButtonStyle>
                                    </Appearance>
                                </igtxt:WebImageButton>
                            </td>
                            <td></td>
                            <td id="tdExportExcel" runat="server">
                                <igtxt:WebImageButton ID="wibExportExcel" runat="server" Text="Exportar a Excel" Width="134px" Height="30px" >
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
                                <igtxt:WebImageButton ID="wibReturn" runat="server" Text="Volver Atrás" Width="134px" Height="30px" OnClick="wibReturn_Click" >
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
                <br />
                <ig:WebDataGrid ID="wdgMain" ClientIDMode="Static" runat="server" Height="350px" Width="680px" 
                    DataKeyFields="AlarmId" AutoGenerateColumns="False">
                    <Columns>
                        <ig:BoundDataField DataFieldName="AlarmId" Key="AlarmId" Hidden="true">
                            <Header Text="Alarma Id">
                            </Header>
                        </ig:BoundDataField>
                        <ig:BoundDataField DataFieldName="AlarmName" Key="AlarmName" Hidden="false">
                            <Header Text="Alarma">
                            </Header>
                        </ig:BoundDataField>
                        <ig:TemplateDataField Key="UserAlarmType">
                            <ItemTemplate>
                                <ig:WebDropDown runat="server" ID="wddUserAlarmType" DisplayMode="DropDownList" Width="300px" DropDownContainerWidth="200px"></ig:WebDropDown>
                            </ItemTemplate>
                        </ig:TemplateDataField>
                    </Columns>
                    <Behaviors>
                        <ig:Activation Enabled="true" />
                        <ig:Selection RowSelectType="Single" Enabled="true" EnableHiddenSelection="false">
                        </ig:Selection>
                        <ig:Paging FirstPageText="<|" LastPageText="|>" NextPageText=">" PreviousPageText="<" PageSize="10" />
                        <ig:Sorting SortingMode="Multi" Enabled="true" />
                        <ig:ColumnResizing Enabled="true" />
                        <ig:ColumnMoving Enabled="true" />
                    </Behaviors>
                </ig:WebDataGrid>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <igtxt:WebImageButton ID="wibExportTableToExcel" Visible="false" ClientIDMode="Static"
        runat="server" Text="Exportar a Excel" Width="120px">
    </igtxt:WebImageButton>
</asp:Content>
