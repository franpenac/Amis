<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogsReportSheet.aspx.cs" Inherits="amis._PresentationLayer.Report.LogsReportSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <div>
                <!--initHeader-->
         <table style="width:200px; font:15px arial">
            <tr>
                <td style="border:solid">Usuario</td>
                <td style="border:solid">%USER%</td>
            </tr>
            <tr>
                <td style="border:solid">Opción de menú</td>
                <td style="border:solid">%MENUOPTION%</td>
            </tr>
            <tr>
                <td style="border:solid">Acción</td>
                <td style="border:solid">%ACTION%</td>
            </tr>
             <tr>
                <td style="border:solid">Fecha</td>
                <td style="border:solid">%DATE%</td>
            </tr>
            </table>
                <!--endHeader-->
        <br />
        <br />
        <table style="width: 1100px; font:15px arial; border:1px" >
            <tr>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Usuario</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Nombre</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Página</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Acción</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Fecha</td>
            </tr>
            <!--ROW_START-->
            <tr>
                <td style="border:solid 1px; text-align:left; width:100px">#USEREMAIL</td>
                <td style="border:solid 1px; text-align:left; width:100px">#USERNAME</td>
                <td style="border:solid 1px; text-align:left; width:100px">#MENUOPTION</td>
                <td style="border:solid 1px; text-align:left; width:100px">#ACTION</td>
                <td style="border:solid 1px; text-align:left; width:100px">#DATE</td>
            </tr>
            <!--ROW_END-->
            </table>
    </div>
    </form>
</body>
</html>
