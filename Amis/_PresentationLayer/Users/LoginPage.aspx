<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="amis._PresentationLayer.Users.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login Amis</title>
    <link rel='stylesheet prefetch' href='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css' />
    <link rel="stylesheet" href="../../css/style.css" />

    <style>
        .divContainer {
            position: relative;
            width: 100%;
            height: 100%;
            margin: 0 auto;
        }
                .divContainer1 {
            position: relative;
            width: 100%;
            height: 100%;
            margin: 0 auto;
            text-align:center;
        }

        .divButtonLeft {
            width: 7%;
            height: 100%;
            float: left;
        }

        .divButtonRight {
            width: 31%;
            height: 100%;
            float: left;
            font-family: "Segoe UI Webfont",-apple-system,"Helvetica Neue","Lucida Grande","Roboto","Ebrima","Nirmala UI","Gadugi","Segoe Xbox Symbol","Segoe UI Symbol","Meiryo UI","Khmer UI","Tunga","Lao UI","Raavi","Iskoola Pota","Latha","Leelawadee","Microsoft YaHei UI","Microsoft JhengHei UI","Malgun Gothic","Estrangelo Edessa","Microsoft Himalaya","Microsoft New Tai Lue","Microsoft PhagsPa","Microsoft Tai Le","Microsoft Yi Baiti","Mongolian Baiti","MV Boli","Myanmar Text","Cambria Math";
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
                                <h1 style="font-family: 'Ubuntu', sans-serif; font-size: 30px; margin-top: -10px; color: white">Iniciar Sesión</h1>
                            </div>
                            <hr style="height: 1px; color: white; background-color: white; border: none;" />
                            <div class="divContainer">
                                <div>
                                    <asp:TextBox ID="txtUserEmail" runat="server" CssClass="InputBox" placeholder="Email"></asp:TextBox>
                                </div>
                                <br />
                                <div>
                                    <asp:TextBox ID="txtUserPassword" runat="server" CssClass="InputBox" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                                </div>
                                <br />
                                <div>
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttonLogin" Height="30px" OnClick="btnLogin_Click" />
                                </div>
                            </div>
                            <hr />
                            <br />
                            <div class="divContainer1">
                                <div class="divButtonLeft">
                                    <asp:Image runat="server" ImageUrl="~/ig_common/images/keyForgot1.png" />
                                </div>
                                <div class="divButtonRight">
                                    <asp:LinkButton ID="lnkbRecoveryPassword" runat="server" OnClick="lnkbRecoveryPassword_Click" ForeColor="White">Olvide mi contraseña</asp:LinkButton>
                                </div>
                                <div class="divButtonRight">
                                </div>
                                </br></br>
                                <div id="divAmisVersion" runat="server" style="text-align:center; color: #FFFFFF; text-align:left; font-size: 10px;">
                                    <asp:Literal ID="litGetAmisWebVersion" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>