<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucDispatchItem.ascx.cs" Inherits="amis._PresentationLayer.Inventory.wucDispatchItem" %>

<%@ Register Assembly="Infragistics45.WebUI.WebSchedule.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>


<style type="text/css">
    .auto-style1 {
        width: 292px;
        height: 71px;
    }
</style>


<script type="text/javascript" id="igClientScript">

</script>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="margin: 10px">
                <div style="font-family: Arial; font-size: 20px; font-weight: bold">
                    Creación de item
                </div>
                <br />
                <div style="font-family: Arial; font-size: 15px; font-weight: bold">
                <asp:Label id="lblProvider" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label id="lblNumber" runat="server" Text=""></asp:Label>
                </div>
                <hr style="height: 1px; color: #123455; background-color: #123455; border: none;" />
                <table>
                                 <tr>
                            <td style="vertical-align: top">
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblDispatchProviderDocument" Visible="false" runat="server" Text="Numero de documento"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                <ig:WebNumericEditor ID="wneDispatchProviderDocument" Visible="false" runat="server" DataMode="Int" Nullable="False"></ig:WebNumericEditor>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">
                                 <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblAssetType" runat="server" Text="Tipo de activo"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">                                               <ig:WebDropDown ID="wddAssetType" runat="server" Width="300px" OnSelectionChanged="wddAssetType_SelectionChanged" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                    <AutoPostBackFlags SelectionChanged="On" />
                                </ig:WebDropDown></td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblOrigin" runat="server" Text="Procedencia"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                                                <ig:WebDropDown ID="wddOrigin" runat="server" Width="300px" OnSelectionChanged="wddOrigin_SelectionChanged" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                    <AutoPostBackFlags SelectionChanged="On" />
                                </ig:WebDropDown>
                            </td>
                        </tr>
                                            <tr>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top"></td>
                            <td style="vertical-align: top">&nbsp;</td>
                        </tr>
                    <div id="DivType" runat="server">
                    </div>
                    <div id="DivOrigin" runat="server">
                    </div>
                    <div id="DivBrand" runat="server">
                        <tr>
                            <td style="vertical-align: top">
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblBrand" runat="server" Text="Marca"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                <ig:WebDropDown ID="wddBrand" runat="server" Width="300px" OnSelectionChanged="wddBrand_SelectionChanged" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                    
                                    <AutoPostBackFlags SelectionChanged="On" />
                                    
                                </ig:WebDropDown>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">                              <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblAssetModel" runat="server" Text="Modelo"></asp:Label>
                                </div></td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                                              <ig:WebDropDown ID="wddAssetModel" runat="server" Width="300px" OnSelectionChanged="wddAssetModel_SelectionChanged" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                    
                                    <AutoPostBackFlags SelectionChanged="On" />
                                    
                                </ig:WebDropDown>
                            </td>
                        </tr>

                    </div>
                    <div id="DivModel" runat="server">
                    </div>
                    <div id="DivService" runat="server">

                        <tr>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="vertical-align: top">
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblAssetModelService" runat="server" Text="Servicio"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                <ig:WebDropDown ID="wddAssetModelService" runat="server" Width="300px" OnSelectionChanged="wddAssetModelService_SelectionChanged" EnableAutoFiltering="Client" AutoSelectOnMatch="False">
                                    
                                    <AutoPostBackFlags SelectionChanged="On" />
                                    
                                </ig:WebDropDown>
                            </td>
                        </tr>

                    </div>

                        <tr>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                        </tr>
                    <div id="DivComplementari" runat="server">

                            <tr>
                            <td style="vertical-align: top">
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lbManufacturerYear" runat="server" Text="Fecha de fabricación"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                <ig:WebNumericEditor ID="wneManufacturerYear" runat="server" DataMode="Int" MaxDecimalPlaces="0" MinValue="0" ValueText="0"></ig:WebNumericEditor>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                                   <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="Label3" runat="server" Text="Dot"></asp:Label>
                                </div>
                            </td>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">
                                    <ig:WebTextEditor ID="wteDot" runat="server" Enabled="false" AutoPostBackFlags-ValueChanged="On" OnTextChanged="wneDot_TextChanged"></ig:WebTextEditor>
                                </td>
                            </tr>
                                                <tr>
                            <td style="vertical-align: top">
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
 
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                                                    <td style="vertical-align: top">
                                                        <div style="font-family: Arial; font-size: 13px">
                                                            <asp:Label ID="Label2" runat="server" Text="Aplicación"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td style="vertical-align: top">&nbsp;</td>
                                                    <td style="vertical-align: top">
                                                                                       <ig:WebDropDown ID="wddApplication" runat="server" Width="300px" EnableAutoFiltering="Client" AutoSelectOnMatch="False" Enabled="false">
                                    <AutoPostBackFlags SelectionChanged="On" />
                                </ig:WebDropDown>
                                                    </td>
                        </tr>
                            <tr>
                            <td style="vertical-align: top">
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblCost" runat="server" Text="Costo total de item"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                <ig:WebNumericEditor ID="wneCost" runat="server" DataMode="Int" Nullable="False"></ig:WebNumericEditor>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">&nbsp;</td>
                            </tr>
                            <tr>
                            <td style="vertical-align: top">
                                <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblDeclaredAmount" runat="server" Text="Cantidad declarada"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                <ig:WebNumericEditor ID="wneDeclaredAmount" runat="server" DataMode="Int" Nullable="False"></ig:WebNumericEditor>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                                            <div style="font-family: Arial; font-size: 13px">
                                    <asp:Label ID="lblReceptionAmount" runat="server" Text="Cantidad recepcionada"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                                                <ig:WebNumericEditor ID="wneReceptionAmount" runat="server" DataMode="Int" Nullable="False"></ig:WebNumericEditor>
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
                                    <asp:Label ID="lblObservation" runat="server" Text="Observaciones"></asp:Label>
                                </div>
                            </td>
                            <td style="vertical-align: top">&nbsp;</td>
                            <td style="vertical-align: top">
                                <textarea id="wteObservations" runat="server" class="auto-style1" style="font-size:13px" name="S1"></textarea></td>
                            </tr>
                            <tr>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">&nbsp;</td>
                                <td style="vertical-align: top">&nbsp;</td>
                            </tr>
                        </div>     
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
