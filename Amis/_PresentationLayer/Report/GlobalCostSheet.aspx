<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlobalCostSheet.aspx.cs" Inherits="amis._PresentationLayer.Report.GlobalCostSheet" %>

<!DOCTYPE html>
        <html xmlns="http://www.w3.org/1999/xhtml">
            <head>
</head>
<body>
    <!--initHeader-->
        <table style="width:200px; font:15px arial">

            <tr>
                 <td style="border:solid"> Bodega</td>
                 <td style="border:solid">%WAREHOUSE%</td>
            </tr>
            <tr>
                <td style="border:solid">Fecha</td>
                <td style="border:solid">%DATEFILTER%</td>
            </tr>
            </table>
    <!--endHeader-->
            <br />

                

            <br />
            <table style="width: 1100px; font:15px arial; border:1px">
            <tr>
                <td style="border:solid 1px; width:100px; background-color:#2F75B5;color:white"></td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white" colspan="2">Costo Nuevo</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white" colspan="2">Costo Recapado</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white" colspan="2">Rechauchado Base</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white" colspan="2">Rechauchado Terreno</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white" colspan="2">C. Disp Final</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white" colspan="2">Venta Cascos</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Total Costo</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Total Ingresado</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Total Km</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Total Cost/Km</td>
            </tr>
            <tr>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white">Meses</td>
                <td style="border:solid 1px; width:50px; text-align:center; background-color:#2F75B5;color:white">Unidad</td>
                <td style="border:solid 1px; width:50px; text-align:center; background-color:#2F75B5;color:white">Costo</td>
                <td style="border:solid 1px; width:50px; text-align:center; background-color:#2F75B5;color:white">Unidad</td>
                <td style="border:solid 1px; width:50px; text-align:center; background-color:#2F75B5;color:white">Costo</td>
                <td style="border:solid 1px; width:50px; text-align:center; background-color:#2F75B5;color:white">Unidad</td>
                <td style="border:solid 1px; width:50px; text-align:center; background-color:#2F75B5;color:white">Costo</td>
                <td style="border:solid 1px; width:50px; text-align:center; background-color:#2F75B5;color:white">Unidad</td>
                <td style="border:solid 1px; width:50px; text-align:center; background-color:#2F75B5;color:white">Costo</td>
                <td style="border:solid 1px; width:50px; text-align:center; background-color:#2F75B5;color:white">Unidad</td>
                <td style="border:solid 1px; width:50px; text-align:center; background-color:#2F75B5;color:white">Costo</td>
                <td style="border:solid 1px; width:50px; text-align:center; background-color:#2F75B5;color:white">Unidad</td>
                <td style="border:solid 1px; width:50px; text-align:center; background-color:#2F75B5;color:white">Costo</td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white"></td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white"></td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white"></td>
                <td style="border:solid 1px; width:100px; text-align:center; background-color:#2F75B5;color:white"></td>
            </tr>
            <tr>
                <td style="border:solid 1px; width:100px; color:#70AD47">Linea Base</td>
                <td style="border:solid 1px; text-align:right;  width:50px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right;  width:50px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:50px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:50px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:50px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:50px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:50px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:50px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:50px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:50px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:50px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:50px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:100px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:100px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:100px; color:#70AD47"></td>
                <td style="border:solid 1px; text-align:right; width:100px; color:#70AD47"></td>
            </tr>  
            <!--ROW_START--> 
            <tr>
                <td style="border:solid 1px; width:100px">#MOUNT</td>
                <td style="border:solid 1px; text-align:right; width:50px">#UNITNEW</td>
                <td style="border:solid 1px; text-align:right; width:50px">#COSTNEW</td>
                <td style="border:solid 1px; text-align:right; width:50px">#URETREA</td>
                <td style="border:solid 1px; text-align:right; width:50px">#CRETREA</td>
                <td style="border:solid 1px; text-align:right; width:50px">#RBASE</td>
                <td style="border:solid 1px; text-align:right; width:50px">#CBASE</td>
                <td style="border:solid 1px; text-align:right; width:50px">#RTERRE</td>
                <td style="border:solid 1px; text-align:right; width:50px">#CTERRE</td>
                <td style="border:solid 1px; text-align:right; width:50px">#UDISP</td>
                <td style="border:solid 1px; text-align:right; width:50px">#CDISP</td>
                <td style="border:solid 1px; text-align:right; width:50px">#UVENT</td>
                <td style="border:solid 1px; text-align:right; width:50px">#CVENT</td>
                <td style="border:solid 1px; text-align:right; width:100px">#TOTALCOST</td>
                <td style="border:solid 1px; text-align:right; width:100px">#TOTALINGR</td>
                <td style="border:solid 1px; text-align:right; width:100px">#TOTALKM</td>
                <td style="border:solid 1px; text-align:right; width:100px">#COSTKM</td>
                
            </tr>
            
            <!--ROW_END-->
            
        </table>
    </body>
</html>
