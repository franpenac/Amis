﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.IndexAndroidPage" %>




<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.ListControls" tagprefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta http-equiv="refresh" content="4;url=LoginAndroidPage.aspx" />
    <title></title>
    <link rel="stylesheet" type="text/css" href="../Content/AmisAndroid.css" />
    <style type="text/css">
        .CssTextBox {}
        .buttonLogin {
            margin-left: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    
                        
                        <div style="position: absolute; visibility: visible; z-index: 1">
                            <img src="../../ig_common/images/TS6.png" width="100%" height="90%" />
                        <img src="../../ig_common/images/PNG_MEDIA.png" width="95%" height="90%" />
                        </div>
                        
                        
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>


