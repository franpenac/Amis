<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrentStockReportSheet.aspx.cs" Inherits="amis._PresentationLayer.Report.CurrentStockReportSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
    <form id="form1" runat="server">
    <div>
        <!--initHeader-->
         <table style="width:200px; font:15px arial">
            <tr>
                <td style="border:solid">Sucursal</td>
                <td style="border:solid">%BRANCHOFFICE%</td>
            </tr>
            <tr>
                <td style="border:solid">Bodega</td>
                <td style="border:solid">%WAREHOUSE%</td>
            </tr>
            <tr>
                <td style="border:solid">Tipo Activo</td>
                <td style="border:solid">%ASSETTYPE%</td>
            </tr>
            </table>
        <!--endHeader-->
        <br />
        <br />
        <table style="width: 1100px; font:15px arial; border:1px" >
            <tr>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Tipo</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Marca</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Modelo</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Bodega</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Stock</td>
            </tr>
            <!--ROW_START-->
            <tr>
                <td style="border:solid 1px; text-align:left; width:100px">#ASSETTYPE</td>
                <td style="border:solid 1px; text-align:left; width:100px">#BRANDNAME</td>
                <td style="border:solid 1px; text-align:left; width:100px">#MODELNAME</td>
                <td style="border:solid 1px; text-align:left; width:100px">#WAREHOUSENAME</td>
                <td style="border:solid 1px; text-align:right; width:100px">#STOCK</td>
            </tr>
            <!--ROW_END-->
            <tr>
                <td style="border:solid 1px; width:100px"></td>
                <td style="border:solid 1px; width:100px"></td>
                <td style="border:solid 1px; width:100px"></td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Total</td>
                <td style="border:solid 1px; text-align:right; width:100px">#TOTALSTOCK</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
