<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAndroidPage.aspx.cs" Inherits="amis._PresentationLayer.AndroidModule.LoginAndroidPage" %>



<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" namespace="Infragistics.Web.UI.ListControls" tagprefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.GridControls" TagPrefix="ig" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
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
                    <div>
                        <br />
                        <div style="position: absolute; visibility: visible; z-index: 1">
                            <br />
                            <br />
                            <br />
                            <br />
                        <img src="../../ig_common/images/PNG_MEDIA.png" width="90%" height="90%" />
                        </div>
                        <br />
                        <div style="position: absolute; width:90%; top: 240px; left: 9px;">
                            <div id="User" style="position:absolute; top: -5px; left: 75px; margin-top: 2px;">
                          <asp:TextBox ID="txtUserEmail" CssClass="CssTextBox" placeholder="Email" runat="server" ClientIDMode="Static" ></asp:TextBox>
                                </div>
                        </div>
                        <br />
                        <div style="position: absolute; width:90%; top: 280px; left: 9px;">
                          <div id="Pass" style="position:absolute; top: -5px; left: 75px; margin-top: 2px;">
                            <asp:TextBox ID="txtUserPassword" runat="server" placeholder="Contraseña" TextMode="Password" ClientIDMode="Static"></asp:TextBox>
                        <div>
                        </div>
                        <br />
                        <div style="position: absolute; width:90%; top: 52px; left: -56px;">
                          <div id="Login" style="position:absolute; top: -5px; left: 100px; margin-top: 2px;">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="buttonLogin" Height="30px" Width="91px" OnClick="btnLogin_Click" />
                              <hr />
                              <div class="divButtonLeft">
                                    <asp:Image runat="server" ImageUrl="~/ig_common/images/keyForgot1.png" />
                                </div>
                                <div class="divButtonRight">
                                    <asp:LinkButton ID="lnkbRecoveryPassword" runat="server" OnClick="lnkbRecoveryPassword_Click" ForeColor="Black">Olvide mi contraseña</asp:LinkButton>
                                </div>
                          </div>
                        </div>
                        <br />
                        <br />
                    </div>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>

