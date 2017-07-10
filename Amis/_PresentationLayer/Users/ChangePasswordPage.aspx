<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePasswordPage.aspx.cs" Inherits="amis._PresentationLayer.Users.ChangePasswordPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cambiar contraseña</title>
    <link rel='stylesheet prefetch' href='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css' />
    <link rel="stylesheet" href="../../css/style.css" />
    <style>
        .buttons {
            cursor:pointer;
            text-decoration: none;
            text-align: center;
            padding: 6px 40px;
            border: none;
            font-family: "Segoe UI Webfont",-apple-system,"Helvetica Neue","Lucida Grande","Roboto","Ebrima","Nirmala UI","Gadugi","Segoe Xbox Symbol","Segoe UI Symbol","Meiryo UI","Khmer UI","Tunga","Lao UI","Raavi","Iskoola Pota","Latha","Leelawadee","Microsoft YaHei UI","Microsoft JhengHei UI","Malgun Gothic","Estrangelo Edessa","Microsoft Himalaya","Microsoft New Tai Lue","Microsoft PhagsPa","Microsoft Tai Le","Microsoft Yi Baiti","Mongolian Baiti","MV Boli","Myanmar Text","Cambria Math";
            color: #ffffff;
            background-color: #91c01c;
            background-image: -moz-linear-gradient(top, #91c01c 0%, #456ca3 100%);
            background-image: -webkit-linear-gradient(top, #91c01c 0%, #456ca3 100%);
            background-image: -o-linear-gradient(top, #91c01c 0%, #456ca3 100%);
            background-image: -ms-linear-gradient(top, #91c01c 0%,#456ca3 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#456ca3', endColorstr='#456ca3',GradientType=0 );
            background-image: linear-gradient(top, #91c01c 0%,#456ca3 100%);
            -webkit-box-shadow: 0px 0px 2px #bababa, inset 0px 0px 1px #ffffff;
            -moz-box-shadow: 0px 0px 2px #bababa, inset 0px 0px 1px #ffffff;
            box-shadow: 0px 0px 2px #bababa, inset 0px 0px 1px #ffffff;
        }

        .button:hover {
            padding: 6px 40px;
            border: none;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            font-family: "Segoe UI Webfont",-apple-system,"Helvetica Neue","Lucida Grande","Roboto","Ebrima","Nirmala UI","Gadugi","Segoe Xbox Symbol","Segoe UI Symbol","Meiryo UI","Khmer UI","Tunga","Lao UI","Raavi","Iskoola Pota","Latha","Leelawadee","Microsoft YaHei UI","Microsoft JhengHei UI","Malgun Gothic","Estrangelo Edessa","Microsoft Himalaya","Microsoft New Tai Lue","Microsoft PhagsPa","Microsoft Tai Le","Microsoft Yi Baiti","Mongolian Baiti","MV Boli","Myanmar Text","Cambria Math";
            font-weight: bold;
            color: #ffffff;
            background-color: #91c01c;
            background-image: -moz-linear-gradient(top, #91c01c 0%, #456ca3 100%);
            background-image: -webkit-linear-gradient(top, #91c01c 0%, #456ca3 100%);
            background-image: -o-linear-gradient(top, #91c01c 0%, #456ca3 100%);
            background-image: -ms-linear-gradient(top, #91c01c 0%,#456ca3 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#456ca3', endColorstr='#456ca3',GradientType=0 );
            background-image: linear-gradient(top, #91c01c 0%,#456ca3 100%);
            -webkit-box-shadow: 0px 0px 2px #bababa, inset 0px 0px 1px #ffffff;
            -moz-box-shadow: 0px 0px 2px #bababa, inset 0px 0px 1px #ffffff;
            box-shadow: 0px 0px 2px #bababa, inset 0px 0px 1px #ffffff;
        }

        .button:active {
            padding: 6px 40px;
            border: none;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            font-family: "Segoe UI Webfont",-apple-system,"Helvetica Neue","Lucida Grande","Roboto","Ebrima","Nirmala UI","Gadugi","Segoe Xbox Symbol","Segoe UI Symbol","Meiryo UI","Khmer UI","Tunga","Lao UI","Raavi","Iskoola Pota","Latha","Leelawadee","Microsoft YaHei UI","Microsoft JhengHei UI","Malgun Gothic","Estrangelo Edessa","Microsoft Himalaya","Microsoft New Tai Lue","Microsoft PhagsPa","Microsoft Tai Le","Microsoft Yi Baiti","Mongolian Baiti","MV Boli","Myanmar Text","Cambria Math";
            font-weight: bold;
            color: #ffffff;
            background-color: #91c01c;
            background-image: -moz-linear-gradient(top, #91c01c 0%, #456ca3 100%);
            background-image: -webkit-linear-gradient(top, #91c01c 0%, #456ca3 100%);
            background-image: -o-linear-gradient(top, #91c01c 0%, #456ca3 100%);
            background-image: -ms-linear-gradient(top, #91c01c 0%,#456ca3 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#456ca3', endColorstr='#456ca3',GradientType=0 );
            background-image: linear-gradient(top, #91c01c 0%,#456ca3 100%);
            -webkit-box-shadow: 0px 0px 2px #bababa, inset 0px 0px 1px #ffffff;
            -moz-box-shadow: 0px 0px 2px #bababa, inset 0px 0px 1px #ffffff;
            box-shadow: 0px 0px 2px #bababa, inset 0px 0px 1px #ffffff;
        }
    </style>
    <style>
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
        .divContainer2
        {
            position: relative;
            width: 85%;
            height: 100%;
            margin: 0 auto;
        }
    </style>
</head>
<body class="body">
    <form id="form1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div>
                    <div style="position: absolute; top: -48px; left: 20px; visibility: visible; z-index: 1">
                        <img src="../../ig_common/images/TS6.png" width="400" />
                    </div>
                    <link href='http://fonts.googleapis.com/css?family=Ubuntu:500' rel='stylesheet' type='text/css' />
                    <div class="login">
                        <div class="login-form">
                            <h1 style="font-family: 'Ubuntu', sans-serif; font-size: 30px; margin-top: -10px; color: white">Cambiar contraseña</h1>
                            <hr />
                            <div class="divContainer">
                                <div>
                                    <asp:TextBox ID="txtChangePasswordCode" runat="server" CssClass="InputBox" placeholder="Código" Width="300px"></asp:TextBox>
                                </div>
                                <br />
                                <div>
                                    <asp:Button ID="btnCheckCode" runat="server" Text="Validar" CssClass="buttonLogin" Height="30px" Width="340px" OnClick="btnCheckCode_Click" />
                                </div>
                            </div>
                            <br />
                            <div runat="server" id="divNewPassword" visible="false">
                                <div class="divContainer">
                                    <div>
                                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="InputBox" placeholder="Nueva contraseña" Width="300px" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div>
                                        <asp:TextBox ID="txtRepeatPassword" runat="server" CssClass="InputBox" placeholder="Repetir nueva contraseña" Width="300px" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <div>

                                    </div>
                                </div>
                                <br />
                                <div class="divContainer2">
                                    <div class="divButtonRight"> <asp:Button ID="btnChangePassword" runat="server" Text="Guardar" CssClass="buttons" OnClick="btnChangePassword_Click" /></div>
                                    <div class="divButtonLeft"><asp:Button ID="btnBackToLogin" runat="server" Text="Cancelar" CssClass="buttons" OnClick="btnBackToLogin_Click" /></div>
                                </div>
                                <br />
                                <br />
                            </div>
                            <br />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
