<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPasswordPage.aspx.cs" Async="true" Inherits="amis._PresentationLayer.Users.ForgotPasswordPage" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.DisplayControls" TagPrefix="ig" %>

<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Recuperar Contraseña</title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
        }
    </style>
    <link rel='stylesheet prefetch' href='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css' />
    <link rel="stylesheet" href="../../css/style.css" />
    <style>
        .buttons {
            cursor:pointer;
            text-decoration: none;
            text-align: center;
            padding: 5px 40px;
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
            padding: 11px 32px;
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
            padding: 11px 32px;
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

        .divToCaptcha {
            height: 100%;
            width: 50%;
            margin: 0 auto;
            position: relative;
        }

        .divToTextEmail {
            height: 100%;
            width: 70%;
            margin: 0 auto;
            position: relative;
        }
        .divContainerToMessage
        {
            position: relative;
            width: 90%;
            height: 100%;
            margin: 0 auto;
            text-align:left;
            font-family: "Segoe UI Webfont",-apple-system,"Helvetica Neue","Lucida Grande","Roboto","Ebrima","Nirmala UI","Gadugi","Segoe Xbox Symbol","Segoe UI Symbol","Meiryo UI","Khmer UI","Tunga","Lao UI","Raavi","Iskoola Pota","Latha","Leelawadee","Microsoft YaHei UI","Microsoft JhengHei UI","Malgun Gothic","Estrangelo Edessa","Microsoft Himalaya","Microsoft New Tai Lue","Microsoft PhagsPa","Microsoft Tai Le","Microsoft Yi Baiti","Mongolian Baiti","MV Boli","Myanmar Text","Cambria Math";
            font-size:13px;
            color:#ffffff;
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
                            <div>
                                <h1 style="font-family: 'Ubuntu', sans-serif; font-size: 30px; margin-top: -10px; color: white">Recuperar contraseña</h1>
                            </div>
                            <hr style="height: 1px; color: white; background-color: white; border: none;" />
                            <div class="divContainerToMessage">
                                <div><asp:Label runat="server" Text="Para recuperar su contraseña, ingrese su correo registrado, a continuación recibirá un correo para proceder a la recuperación de su clave de acceso a AMIS."></asp:Label></div>
                            </div>
                            <br />
                            <div class="divToTextEmail">
                                <asp:TextBox ID="txtRecoveryUserEmail" runat="server" CssClass="InputBox" placeholder="Email" Width="260px"></asp:TextBox>
                            </div>
                            <br />
                            <div class="divToCaptcha">
                                <ig:WebCaptcha ID="wbcRecoveryPassword" runat="server" Width="220px" Height="83px" InputValueEditor-BorderColor="Green" InputValueEditor-Font-Bold="true" CaptchaDictionaryPath="" ErrorMessage="Código ingresado inválido">
                                    <InputValueEditor runat="server" NullText="Ingrese texto" HorizontalAlign="Center"></InputValueEditor>
                                    <RefreshButton ToolTip="Refrescar imagen de Captcha" />
                                    <SubmitButton  Visible="false"/>
                                    <AudioButton  Visible="false"/>
                                </ig:WebCaptcha>
                            </div>
                            <br />
                            <br />
                            <br />
                            <div class="divContainer">
                                <div class="divButtonLeft">
                                    <asp:Button ID="btnBack" runat="server" Text="Volver" CssClass="buttons" Height="30px" OnClick="btnBack_Click" />
                                </div>
                                <div class="divButtonRight">
                                    <asp:Button ID="btnRecoveryPassword" runat="server" Text="Recuperar" CssClass="buttons" Height="30px" OnClick="btnRecoveryPassword_Click" />
                                </div>
                            </div>
                            <br />
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
