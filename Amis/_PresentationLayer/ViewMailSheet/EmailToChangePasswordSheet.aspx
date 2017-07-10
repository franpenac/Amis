<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailToChangePasswordSheet.aspx.cs" Inherits="amis._PresentationLayer.ViewMailSheet.EmailToChangePasswordSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1 style="text-align:center">Cambio de contraseña para AMIS</h1>
        <hr />
        <p>Estimado usuario, para completar el proceso de creación, recuperación o cambio de contraseña presione el link &quot;Cambiar contraseña&quot;, esta acción lo llevará a la página de cambio de contraseña, en ella ingrese el codigo según indicación. Se sugiere copiar y pegar el código.</p>
        <a href="#WEB_SITE/ForgotPasswordDerivation.aspx">Cambiar contraseña</a>
        <br />
        <br />
        <label style="text-decoration:underline; text-decoration:solid; font-size:30px">Código: #CODE</label>
        <br />
        <br />
        <br />
        <br />
        <asp:Label runat="server" Font-Size="Medium" Font-Italic="true">Saluda cordialmente, Equipo Technology Source.</asp:Label>
          <br />
        </div>
    </form>
</body>
</html>
