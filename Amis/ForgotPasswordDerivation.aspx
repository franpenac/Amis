<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPasswordDerivation.aspx.cs" Inherits="amis.ForgotPasswordDerivation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <script runat="server" language="c#">
    public void Page_Load(Object sender, EventArgs e) 
    {
        if (Request.Browser["IsMobileDevice"] == "true" ) 
        {
            Response.Redirect("_PresentationLayer/AndroidModule/ChangePasswordAndroidPage.aspx");
        }
        else 
        {
            Response.Redirect("_PresentationLayer/Users/ChangePasswordPage.aspx");
        }
    }
</script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
