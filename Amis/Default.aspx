<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="amis._Default" %>
<asp:Content ID="Header" ContentPlaceHolderID="HeaderContent" runat="server">

    <script runat="server" language="c#">

    public void Page_Load(Object sender, EventArgs e) 
    {
            
        if (Request.Browser.IsMobileDevice) 
        {
            Response.Redirect("_PresentationLayer/AndroidModule/LoginAndroidPage.aspx");
        }
        else 
        {
            Response.Redirect("_PresentationLayer/Users/LoginPage.aspx");
        }
    }

</script>
        
    </asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/amis2.png" Width="720px" />
</asp:Content>
