<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlobalCostSheet.aspx.cs" Inherits="amis._PresentationLayer.Report.GlobalCostSheet" %>

<!DOCTYPE html>
        <html xmlns="http://www.w3.org/1999/xhtml">
            <head runat="server">
</head>
<body>
    <!--initHeader-->
        <table style="width:200px; font:15px arial">

            <tr>
                 <td style="border:solid"> Proveedor</td>
                 <td style="border:solid">%PROVIDER%</td>
            </tr>
            <tr>
                <td style="border:solid">Fecha</td>
                <td style="border:solid">%DATEFILTER%</td>
            </tr>
            </table>
    <!--endHeader-->
            <br />

                

            <br />
            <table style="width: 1100px; font:15px arial; border:1px }">
            <tr>
                <td style="border:solid 1px; width:100px; background-color:#2F75B5;color:white"></td>
            </tr>
            <tr>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Periodo</td>
                <!--HEADER_START-->
                <!--HEADER_END-->
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Total</td>
            </tr>
            
            <tr>
                <!--COLUMN_START-->
                
                <!--COLUMN_END-->
            </tr>
            
        </table>
    </body>
</html>
