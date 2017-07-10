<%@ Page ValidateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AmisHomePage.aspx.cs" Inherits="amis._PresentationLayer.Configuration.AmisHomePage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.LayoutControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/css/amis.css">

    <title>Amis</title>

    <style>
        .AmisLogo
        {
            position:absolute;
            margin:0 auto;
            top:35%;
            left:30%;
        }
        .TsLogo
        {
            position:absolute;
            margin:0 auto;
        }
        .TSImage
        {
            width:20%;
            height:20%;
        }
        .RightBottom{
            position:absolute;
            right:0;
            bottom:0;
        }
    </style>
</asp:Content>

<asp:Content ID="Main" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <asp:Image  ID="imgLogoTS" runat="server" ImageUrl="~/ig_common/images/TSPng.png" CssClass="TSImage"/>

            <div class="AmisLogo">
                <asp:Image ID="imgLogoAmis" runat="server"  ImageUrl="~/ig_common/images/PNG_MEDIA.png"/>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>