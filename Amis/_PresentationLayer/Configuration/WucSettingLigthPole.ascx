﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucSettingLigthPole.ascx.cs" Inherits="amis._PresentationLayer.Configuration.WucSettingLigthPole" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>



<style type="text/css">
    .auto-style1 {
        height: 23px;
        width: 233px;
    }
    .auto-style6 {
        width: 87%;
    }
    .auto-style8 {
        height: 28px;
        width: 336px;
    }
    .auto-style9 {
        width: 233px;
    }
    .auto-style13 {
        width: 94px;
    }
    .auto-style14 {
        height: 28px;
        width: 233px;
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
            .auto-style2 {
                height: 24px;
            }
</style>



<asp:UpdatePanel ID="UpdatePanel1" runat="server">

    <ContentTemplate>
        <table class="auto-style6">
            <tr>
                <td style="vertical-align: top" class="auto-style13">
                    
                </td>
                <td class="auto-style14">
                    
            </tr>
            <tr>
                <td></td>
                <td style="vertical-align: top" class="auto-style13">
                    <div style="font-family: Arial; font-size: 13px; padding-top:5px; text-align:right">
                        <asp:Label ID="lblAssetModelName" runat="server" Text="Nuevo Modelo"></asp:Label>
                    </div>
                </td>
                <td class="auto-style14">
                    <ig:WebTextEditor ID="wteAssetModelName" CssClass="textBoxDesign" onkeyPress="return textbox_text_onkeypress(event)" runat="server" Height="23px" Width="200px"></ig:WebTextEditor>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="vertical-align: top" class="auto-style13">
                    <div style="font-family: Arial; font-size: 13px; padding-top:5px; text-align:right">
                        <asp:Label ID="lblInstallDate" runat="server" Text="Fecha Instalacion"></asp:Label>
                    </div>
                </td>
                <td class="auto-style1">
                    <ig:WebDatePicker ID="wdpInstallDate" runat="server" DropDownCalendarID="wmcInstallDate" DisplayModeFormat="dd/MM/yyyy"></ig:WebDatePicker>
                            <ig:WebMonthCalendar runat="server" Visible="true" ID="wmcInstallDate" EnableWeekNumbers="true"
                                ChangeMonthToDateClicked="true" EnableMonthDropDown="True" EnableYearDropDown="True">
                            </ig:WebMonthCalendar>
                </td>
            </tr>
        </table>


    </ContentTemplate>
    
</asp:UpdatePanel>