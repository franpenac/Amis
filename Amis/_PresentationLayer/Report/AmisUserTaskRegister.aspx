<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AmisUserTaskRegister.aspx.cs" Inherits="amis._PresentationLayer.Report.AmisUserTaskRegister" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">

    <link rel="stylesheet" type="text/css" href="~/Content/css/MainCSS.css" />

    <script type="text/javascript" id="igClientScript">
<!--
    function wdgMain_Selection_CellSelectionChanged(sender, eventArgs) {
        var grid = $find('wdgMain');
        var gridBehaviors = grid.get_behaviors();
        var cell = gridBehaviors.get_selection().get_selectedCells().getItem(0);
        var colIndex = cell.get_index();
        var amisUserTaskId = cell.get_row(0).get_cellByColumnKey('AmisUserTaskId').get_text();
        var done = cell.get_row(0).get_cellByColumnKey('AmisUserTaskDone').get_text();

        document.getElementById('txtDone').value = done == "Y" ? "N" : "Y";

        //document.getElementById('txtTaskId').value = amisUserTaskId;
        document.getElementById('txtTaskId').value = amisUserTaskId + ";" + document.getElementById('txtDone').value;

        if (colIndex == 1) {

            //alert('ChangeDone   colIndex=' + colIndex + '   txtTaskId=' + document.getElementById('txtTaskId').value + "  " + document.getElementById('txtDone').value);

            document.getElementById('btnChangeDone').click();

        } else {

            //alert('SetHtmlTextBox   colIndex=' + colIndex + '   txtTaskId=' + document.getElementById('txtTaskId').value + "  " + document.getElementById('txtDone').value);

            document.getElementById('btnSetHtmlTextBox').click();
  
        }
    }

    // -->
    </script>

</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br /><br /><br /><div style="margin: 10px">
                <h1 id="h1OptionMenuPageName" runat="server">
                    Tareas de usuario
                </h1>

                <div style="display:none">
                    <asp:TextBox ID="txtTaskId" ClientIDMode="Static" runat="server" Text=""></asp:TextBox>
                    <asp:TextBox ID="txtAction" ClientIDMode="Static" runat="server" Text=""></asp:TextBox>
                    <asp:TextBox ID="txtDone" ClientIDMode="Static" runat="server" Text=""></asp:TextBox>
                    <asp:TextBox ID="txtName" ClientIDMode="Static" runat="server" Text=""></asp:TextBox>
                    <asp:Button ID="btnChangeDone" ClientIDMode="Static" runat="server" Text="Button" OnClick="btnChangeDone_Click" />
                    <asp:Button ID="btnSetHtmlTextBox" ClientIDMode="Static" runat="server" Text="Button"/>
                </div>

                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <table>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                Tipo de tarea
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <ig:WebDropDown ID="wddTaskTypeId" runat="server" Width="250px" AutoPostBack="true">
                            </ig:WebDropDown>
                        </td>

                        <td style="vertical-align: top">&nbsp;</td>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                Estado de tarea
                            </div>
                        </td>
                        <td style="vertical-align: top">&nbsp;</td>
                        <td>
                            <ig:WebDropDown ID="wddAmisUserTaskDone" runat="server" Width="120px" AutoPostBack="true">
                                <Items>
                                    <ig:DropDownItem Key="Done" Selected="true" Text="No realizado" Value="2">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Key="Done" Selected="False" Text="Realizado" Value="1">
                                    </ig:DropDownItem>
                                    <ig:DropDownItem Key="Done" Selected="False" Text="Ambos" Value="3">
                                    </ig:DropDownItem>
                                </Items>
                            </ig:WebDropDown>
                        </td>

                        <td style="vertical-align: top">&nbsp;</td>
                        <td>
                            <div style="font-family: Arial; font-size: 13px">
                                Fecha de inicio desde
                            </div>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            <ig:WebDatePicker ID="wdpStartDate" runat="server" DropDownCalendarID="CalendarView" AutoPostBackFlags-ValueChanged="On" AutoPostBackFlags-EnterKeyDown="On">
                            </ig:WebDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top">
                            <div style="font-family: Arial; font-size: 13px">
                                Nombre contiene
                            </div>
                        </td>
                        <td style="vertical-align: top"></td>
                        <td style="vertical-align: top" colspan="5">
                            <div id="divName" runat="server">
                                <input style="width:476px; font-family: Arial; font-size: 13px;" type="text" onkeydown="document.getElementById('txtName').value = document.getElementById('txtNameCon').value; if (event.keyCode == 13) { document.getElementById('btnSetHtmlTextBox').click(); return false; }" ID="txtNameCon" value="<%= txtName.Text %>" />
                            </div>
                        </td>
                        <td style="vertical-align: top"></td>
                        <td style="margin-left: 40px">
                            
                            <div style="font-family: Arial; font-size: 13px; text-align: right;">
                                hasta
                            </div>

                        </td>
                        <td style="margin-left: 40px"></td>
                        <td style="margin-left: 40px">
                            <ig:WebDatePicker ID="wdpFinishDate" runat="server" DropDownCalendarID="CalendarView" AutoPostBackFlags-ValueChanged="On" AutoPostBackFlags-EnterKeyDown="On">
                            </ig:WebDatePicker>
                        </td>
                    </tr>
                </table>

                <br />

                <ig:WebSplitter ID="wspAmisUserTask" runat="server" Height="400px">
                    <Panes>
                        <ig:SplitterPane runat="server" Size="60%" ScrollBars="Hidden">
                            <Template>
                                <ig:WebDataGrid ID="wdgMain" OnInitializeRow="wdgMain_InitializeRow" ClientIDMode="Static" runat="server" Height="400px" Width="100%"
                                    AutoGenerateColumns="False" DataKeyFields="AmisUserTaskId">
                                    <Columns>
                                        <ig:TemplateDataField Width="40px" Key="AmisTaskTypeImageButton">
                                            <ItemTemplate>
                                                <img id="imgAmisTaskTypeImageButton" runat="server" src="~/ig_common/images/alarm16x16.png" />
                                            </ItemTemplate>
                                            <Header Text="Tipo"></Header>
                                        </ig:TemplateDataField>

                                        <ig:TemplateDataField Width="40px" Key="AmisUserTaskDoneImageButton">
                                            <ItemTemplate>
                                                <asp:TextBox style="display:none" ID="test2" Text='<%# Bind("AmisUserTaskId") %>' runat="server"></asp:TextBox>
                                                <asp:ImageButton ClientIDMode="Static" ImageUrl="~/ig_common/images/ButtonUnchecked16x16.png" ID="imgAmisUserTaskDoneImageButton"
                                                    runat="server" />
                                            </ItemTemplate>
                                            <Header Text="OK"></Header>
                                        </ig:TemplateDataField>

                                        <ig:BoundDataField Hidden="true" DataFieldName="AmisUserTaskId" DataType="System.UInt32" Key="AmisUserTaskId">
                                            <Header Text="AmisUserTaskId">
                                            </Header>
                                        </ig:BoundDataField>

                                        <ig:BoundDataField Hidden="true" DataFieldName="AmisTaskTypeId" DataType="System.UInt32" Key="AmisTaskTypeId">
                                            <Header Text="AmisTaskTypeId">
                                            </Header>
                                        </ig:BoundDataField>

                                        <ig:BoundDataField Hidden="true" DataFieldName="AmisTaskTypeImage" Key="AmisTaskTypeImage">
                                            <Header Text="AmisTaskTypeImage">
                                            </Header>
                                        </ig:BoundDataField>

                                        <ig:BoundDataField Hidden="true" DataFieldName="AmisTaskId" DataType="System.UInt32" Key="AmisTaskId">
                                            <Header Text="ID">
                                            </Header>
                                        </ig:BoundDataField>

                                        <ig:BoundDataField DataFieldName="AmisTaskName" Key="AmisTaskName">
                                            <Header Text="Tarea">
                                            </Header>
                                        </ig:BoundDataField>

                                        <ig:BoundDataField Hidden="true" DataFieldName="AmisUserTaskDescription" Key="AmisUserTaskDescription">
                                            <Header Text="AmisUserTaskDescription">
                                            </Header>
                                        </ig:BoundDataField>

                                        <ig:BoundDataField Hidden="true" DataFieldName="AmisUserTaskActionTaken" Key="AmisUserTaskActionTaken">
                                            <Header Text="AmisUserTaskActionTaken">
                                            </Header>
                                        </ig:BoundDataField>

                                        <ig:BoundDataField Hidden="true" DataFieldName="AmisUserTaskDone" Key="AmisUserTaskDone">
                                            <Header Text="D">
                                            </Header>
                                        </ig:BoundDataField>

                                        <ig:BoundDataField Width="85px" DataFieldName="AmisUserTaskStartDate" Key="AmisUserTaskStartDate">
                                            <Header Text="Inicio">
                                            </Header>
                                        </ig:BoundDataField>

                                        <ig:BoundDataField Width="85px" DataFieldName="AmisUserTaskFinishDate" Key="AmisUserTaskFinishDate">
                                            <Header Text="Fin">
                                            </Header>
                                        </ig:BoundDataField>
                                    </Columns>
                                    <Behaviors>
                                        <ig:Selection RowSelectType="Single" CellClickAction="Cell" Enabled="true" EnableHiddenSelection="false">

                                            <SelectionClientEvents CellSelectionChanged="wdgMain_Selection_CellSelectionChanged" />

                                        </ig:Selection>
                                        <ig:Paging PagerMode="Numeric" FirstPageText="<|" LastPageText="|>" NextPageText=">" PreviousPageText="<" PagerAppearance="Bottom" PageSize="8" Enabled="true" />
                                        <ig:Sorting SortingMode="Multi" Enabled="true" />
                                        <ig:ColumnResizing Enabled="true" />
                                        <ig:ColumnMoving Enabled="true" />
                                    </Behaviors>
                                </ig:WebDataGrid>
                            </Template>
                        </ig:SplitterPane>
                        <ig:SplitterPane runat="server" Size="40%">
                            <Template>
                                <ig:WebSplitter ID="wspHorizontal" runat="server" Height="100%" Width="100%" Orientation="Horizontal">
                                    <Panes>
                                        <ig:SplitterPane runat="server" style="height:50px">
                                            <Template>
                                                
                                                Descripción
                                                <br />
                                                <asp:TextBox ReadOnly="true" style="font-family: Arial; font-size: 13px; width:100%; height:100%" TextMode="MultiLine" ID="txtUserTaskDescription" runat="server"></asp:TextBox>
                                                
                                            </Template> 
                                        </ig:SplitterPane> 
                                        <ig:SplitterPane runat="server">
                                            <Template>
                                                Acciones realizadas
                                                <br />
                                                <asp:TextBox style="font-family: Arial; font-size: 13px; width:100%; height:75%" TextMode="MultiLine" ID="txtActionTaken" ClientIDMode="Static" runat="server"></asp:TextBox>
                                                <br />
                                                <asp:Button OnClientClick="document.getElementById('txtAction').value = document.getElementById('txtActionTaken').value;" ID="btnSaveAmisUserTaskActionTaken" ClientIDMode="Static" runat="server" Text="Guardar" OnClick="btnSaveAmisUserTaskActionTaken_Click" />
                                            </Template>
                                        </ig:SplitterPane>
                                    </Panes>
                                </ig:WebSplitter>
                            </Template>
                        </ig:SplitterPane>
                    </Panes>
                </ig:WebSplitter>

                <ig:WebMonthCalendar runat="server" ID="CalendarView" EnableWeekNumbers="true"
                    ChangeMonthToDateClicked="true" EnableMonthDropDown="True" EnableYearDropDown="True">
                </ig:WebMonthCalendar>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
