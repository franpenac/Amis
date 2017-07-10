<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ScrapTypesReportSheet.aspx.cs" Inherits="amis._PresentationLayer.Report.ScrapTypesReportSheet" %>

<!DOCTYPE html>
        <html xmlns="http://www.w3.org/1999/xhtml">
            <head runat="server">
                    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 121px;
            height: 21px;
        }
        .auto-style3 {
            height: 21px;
        }
    </style>
</head>
<body>
    <div>
        <!--initHeader-->
        <table style="width:200px; font:15px arial">
            <tr>
                 <td style="border:solid">ID</td>
                 <td style="border:solid">%ASSETID%</td>
            </tr>
            <tr>
                <td style="border:solid">Operacion</td>
                <td style="border:solid">%OPERATION%</td>
            </tr>
            <tr>
                <td style="border:solid">Tipo Activo</td>
                <td style="border:solid">%ASSETTYPE%</td>
            </tr>
            <tr>
                <td style="border:solid">Fecha</td>
                <td style="border:solid">%PERIOD%</td>
            </tr>
            </table>
        <!--endHeader-->
            <br />
            <br />
            <table style="width: 1100px; font:15px arial; border:1px">
            <tr>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Meses</td>
                <!--HEADER_START-->
                <!--HEADER_END-->
                <td style="border:solid 1px; width:100px; text-align:left; background-color:#2F75B5;color:white">Total</td>
            </tr>
            <tr>
                <!--COLUMN_START-->
                
                <!--COLUMN_END-->
            </tr>
        </table>
        </div>
    </body>
</html>
