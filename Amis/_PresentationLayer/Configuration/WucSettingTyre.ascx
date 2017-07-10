<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucSettingTyre.ascx.cs" Inherits="amis._PresentationLayer.Configuration.WucSettingTyre" %>


<%@ Register Assembly="Infragistics45.WebUI.WebDataInput.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.ListControls" TagPrefix="ig" %>
<%@ Register Assembly="Infragistics45.Web.v15.2, Version=15.2.20152.2125, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" Namespace="Infragistics.Web.UI.EditorControls" TagPrefix="ig" %>



<style type="text/css">
    .auto-style1 {
        height: 23px;
        width: 173px;
    }
    .auto-style6 {
        width: 87%;
    }
    .auto-style13 {
        width: 94px;
    }
    .auto-style14 {
        height: 28px;
        width: 152px;
    }
    .auto-style18 {
        width: 325px;
    }
    .auto-style19 {
        height: 28px;
        width: 173px;
    }
    .auto-style20 {
        width: 63px;
    }
    .auto-style21 {
        width: 152px;
    }
    .auto-style22 {
        width: 173px;
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
        <div style="font-family: Arial; font-size: 13px; text-align:right ;">
        <table>
            <tr>
                <td style="width:50px"></td>
                <td style="width:150px"><asp:Label ID="lblNewOrUse" runat="server" Text="Nuevo/Recapado"></asp:Label></td>
                <td style="width:50px"></td>
                <td style="width:200px"><asp:DropDownList ID="ddlOriginal" runat="server"  Width="100%"></asp:DropDownList></td>
                <td style="width:50px"></td>
                <td style="width:150px"></td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width:50px"></td>
                <td style="width:150px"><asp:Label ID="lblDepthNumber"  runat="server" Text="Numero de huellas"></asp:Label></td>
                <td style="width:50px"></td>
                <td style="width:200px"><asp:TextBox ID="txbDepthNumber" Width="100%" onkeyPress="return textbox_number_onkeypress(event)" runat="server"></asp:TextBox></td>
                <td style="width:50px"></td>
                <td style="width:150px"></td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width:50px"></td>
                <td style="width:150px"><asp:Label ID="lblMeasurement" runat="server" Text="Medidas"></asp:Label></td>
                <td style="width:50px"></td>
                <td style="width:200px"><asp:DropDownList ID="ddlMeasurementTyre" runat="server"  Width="100%"></asp:DropDownList></td>
                <td style="width:50px"></td>
                <td style="width:150px"></td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width:50px"></td>
                <td style="width:150px"><asp:Label ID="lblSpeedIndex" runat="server" Text="Indice de velocidad"></asp:Label></td>
                <td style="width:50px"></td>
                <td style="width:200px"><asp:DropDownList ID="ddlSpeedIndex" runat="server"  Width="100%"></asp:DropDownList></td>
                <td style="width:50px"></td>
                <td style="width:150px"><asp:Label ID="lblSpeed" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width:50px"></td>
                <td style="width:150px"><asp:Label ID="lblWeighIndex" runat="server" Text="Indice de peso"></asp:Label></td>
                <td style="width:50px"></td>
                <td style="width:200px"><asp:DropDownList ID="ddlWeighIndex" runat="server" Width="100%"></asp:DropDownList></td>
                <td style="width:50px"></td>
                <td style="width:150px"><asp:Label ID="lblWeigh" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
        <table>
            <tr>
                <td style="width:50px"></td>
                <td style="width:150px"></td>
                <td style="width:50px"></td>
                <td style="width:200px"></td>
                <td style="width:50px"></td>
                <td style="width:150px"></td>
            </tr>
        </table>
            </div>
    </ContentTemplate>
    
</asp:UpdatePanel>