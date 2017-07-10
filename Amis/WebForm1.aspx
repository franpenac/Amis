<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="amis.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <!-- Start: Main -->
        <div id="main">
            <!-- AQUI COMIENZA TODO EL MENU LATERAL -->
            <!-- Start: Sidebar Left Content -->
            <div class="sidebar-left-content nano-content">
                <!-- Start: Sidebar Menu -->
                <ul class="nav sidebar-menu">
                    <li class="sidebar-label pt15"></li>
                    <li><a class="accordion-toggle" href="#"><span class="fa fa-group"></span><span class="sidebar-title">Asignaciones</span><span class="caret"></span></a><ul class="nav sub-nav">
                        <li><a href="/_PresentationLayer/Configuration/MemberBranchOfficePage.aspx"><span class=""></span>Integrantes</a></li>
                        <li><a href="/_PresentationLayer/OperationModule/UnitRegisterToOperationPage.aspx"><span class=""></span>Unidades a operación</a></li>
                    </ul>
                    </li>
                    <li><a class="accordion-toggle" href="#"><span class="fa fa-group"></span><span class="sidebar-title">Configuraciones</span><span class="caret"></span></a><ul class="nav sub-nav">
                        <li><a href="/_PresentationLayer/Configuration/PressureSettingPage.aspx"><span class=""></span>Presión de trabajo</a></li>
                        <li><a href="/_PresentationLayer/Configuration/DepthSettingPage.aspx"><span class=""></span>Profundidad mínima</a></li>
                        <li><a href="/_PresentationLayer/Configuration/AssetUniqueIdentificationPage.aspx"><span class=""></span>Única de activos</a></li>
                    </ul>
                    </li>
                    <li><a class="accordion-toggle" href="#"><span class="fa fa-group"></span><span class="sidebar-title">Integrantes</span><span class="caret"></span></a><ul class="nav sub-nav">
                        <li><a href="/_PresentationLayer/Configuration/MemberRegisterPage.aspx"><span class=""></span>Registro de Integrantes</a></li>
                    </ul>
                    </li>
                    <li><a class="accordion-toggle" href="#"><span class="fa fa-group"></span><span class="sidebar-title">Logística materiales</span><span class="caret"></span></a><ul class="nav sub-nav">
                        <li><a href="/_PresentationLayer/Inventory/DispatchProviderDocumentPage.aspx"><span class=""></span>Registro Guía Proveedores</a></li>
                    </ul>
                    </li>
                    <li><a class="accordion-toggle" href="#"><span class="fa fa-group"></span><span class="sidebar-title">Páginas Android</span><span class="caret"></span></a><ul class="nav sub-nav">
                        <li><a href="/_PresentationLayer/AndroidModule/AssignedAssetToUnitAndroidPage.aspx"><span class=""></span>Asignación de activos</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/AssignedToUnitAndroidPage.aspx"><span class=""></span>Asignar activo a unidad</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/AssignedTyreToUnitAndroidPage.aspx"><span class=""></span>Asignar neumático</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/ChangeAssetToAnotherWarehouse.aspx"><span class=""></span>Cambio a otra bodega</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/ChangePasswordInAndroidPage.aspx"><span class=""></span>Cambio de contraseña</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/ChangePositionAssetPage.aspx"><span class=""></span>Cambio de posición</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/SelectReplaceToSameUnitTyre.aspx"><span class=""></span>Cambio en misma unidad</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/ForgotPasswordAndroidPage.aspx"><span class=""></span>Contraseña fue olvidada</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/none2.aspx"><span class=""></span>Documento de despacho</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/none1.aspx"><span class=""></span>Documento de recepción</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/IndexAndroidPage.aspx"><span class=""></span>Índice Android</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/ChangePasswordAndroidPage.aspx"><span class=""></span>Ingresar código para cambio contraseña</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/InspectionAssetPage.aspx"><span class=""></span>Inspección - Estado de activos</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/PhotoAndroidPage.aspx"><span class=""></span>Inspección - Fotos</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/AnyObservationPage.aspx"><span class=""></span>Inspección - Observaciones</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/SelectionAnotherUnitTyrePage.aspx"><span class=""></span>Inspección - Otro neumático</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/ReasonRemoveAndroidPage.aspx"><span class=""></span>Inspección - Razón mal estado</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/SelectionTyrePage.aspx"><span class=""></span>Inspección - Seleccionar neumático</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/SelectedInspectionAndroidPage.aspx"><span class=""></span>Inspección - TAG</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/InspectionIndexAndroidPage.aspx"><span class=""></span>Inspección - Tipo de activo</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/MeassurementTyrePage.aspx"><span class=""></span>Inspección - Toma de mediciones</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/WrongTagInspectionPage.aspx"><span class=""></span>Inspección de TAG fallido</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/InventoryIndexAndroidPage.aspx"><span class=""></span>Inventario - Índice</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/InventoryTyreAndroidPage.aspx"><span class=""></span>Inventario - Neumático</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/InventoryNoTyreAndroidPage.aspx"><span class=""></span>Inventario - No neumático</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/InventoryEndAndroidPage.aspx"><span class=""></span>Inventario -Mensaje terminar/continuar</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/LoginAndroidPage.aspx"><span class=""></span>Login</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/SelectRegisterTagOption.aspx"><span class=""></span>Manú selección de opción de TAG</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/MenuAndroidPage.aspx"><span class=""></span>Menú principal</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/RemoveTyreInspectionAndroidPage.aspx"><span class=""></span>Operaciones de neumático</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/ErrorAndroidPage.aspx"><span class=""></span>Página de error</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/InConstructionPage.aspx"><span class=""></span>Página en construcción</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/ReplaceTyreOnRoad.aspx"><span class=""></span>Recambio - En terreno</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/SelectUnitToReplaceTyre.aspx"><span class=""></span>Recambio - Error en lectura de TAG</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/MeassurementTyreToReplacePage.aspx"><span class=""></span>Recambio - Mediciones</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/SelectReplaceTyreDestiny.aspx"><span class=""></span>Recambio - Menú</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/SelectionReplaceTyrePage.aspx"><span class=""></span>Recambio - Reemplazar neumático</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/SelectionAnotherUnitToReplacePage.aspx"><span class=""></span>Recambio - Unidad receptora</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/RegisterTagAndroidPage.aspx"><span class=""></span>Registro de TAG</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/RegisterManyTagsAndroidPage.aspx"><span class=""></span>Registro masivo de TAGs</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/RemoveAssetAndroidPage.aspx"><span class=""></span>Remover</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/RemoveInspectionAndroidPage.aspx"><span class=""></span>Remover - Confirmación</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/RepairAssetAndroidPage.aspx"><span class=""></span>Reparar</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/SelectBranchOfficeAndroidPage.aspx"><span class=""></span>Seleccionar oficina</a></li>
                        <li><a href="/_PresentationLayer/AndroidModule/ChangeTyreToAnotherUnit.aspx"><span class=""></span>Unidad receptora</a></li>
                    </ul>
                    </li>
                    <li><a class="accordion-toggle" href="#"><span class="fa fa-group"></span><span class="sidebar-title">Registros</span><span class="caret"></span></a><ul class="nav sub-nav">
                        <li><a href="/_PresentationLayer/Inventory/WarehousePage.aspx"><span class=""></span>Bodegas</a></li>
                        <li><a href="/_PresentationLayer/OperationModule/OperationRegisterPage.aspx"><span class=""></span>Operaciones</a></li>
                        <li><a href="/_PresentationLayer/Configuration/BranchOfficePage.aspx"><span class=""></span>Sucursales</a></li>
                        <li><a href="/_PresentationLayer/Configuration/UnitRegisterPage.aspx"><span class=""></span>Unidades</a></li>
                    </ul>
                    </li>
                    <li><a class="accordion-toggle" href="#"><span class="fa fa-group"></span><span class="sidebar-title">Reportes</span><span class="caret"></span></a><ul class="nav sub-nav">
                        <li><a href="/_PresentationLayer/Report/AssetPerUnitReportPage.aspx"><span class=""></span>Activos por unidad</a></li>
                        <li><a href="/_PresentationLayer/Report/BenchMarkingDurationReportPage.aspx"><span class=""></span>Benchmarking duracion</a></li>
                        <li><a href="/_PresentationLayer/Report/ProviderPurchasesReportPage.aspx"><span class=""></span>Compras por proveedor</a></li>
                        <li><a href="/_PresentationLayer/Report/GlobalCostReportPage.aspx"><span class=""></span>Costo global</a></li>
                        <li><a href="/_PresentationLayer/Report/KilometersAndRetreadsCostReportPage.aspx"><span class=""></span>Costo kilometros y recapados</a></li>
                        <li><a href="/_PresentationLayer/Report/LogsReportPage.aspx"><span class=""></span>Historial del sistema</a></li>
                        <li><a href="/_PresentationLayer/Maintenance/GlobalCostDetailPage.aspx"><span class=""></span>Ingreso de costo global</a></li>
                        <li><a href="/_PresentationLayer/Report/ModelPurchasedReportPage.aspx"><span class=""></span>Modelos/Marca comprados</a></li>
                        <li><a href="/_PresentationLayer/Report/ForecastPurchasesReportPage.aspx"><span class=""></span>Pronóstico de compras</a></li>
                        <li><a href="/_PresentationLayer/Report/AssetPerUnitSummaryReportPage.aspx"><span class=""></span>Resumen de activos por unidad</a></li>
                        <li><a href="/_PresentationLayer/Report/CurrentStockReportPage.aspx"><span class=""></span>Stock actual</a></li>
                        <li><a href="/_PresentationLayer/Report/AmisUserTaskRegister.aspx"><span class=""></span>Tareas de usuario</a></li>
                        <li><a href="/_PresentationLayer/Report/ScrapTypesReportPage.aspx"><span class=""></span>Tipos de baja</a></li>
                        <li><a href="/_PresentationLayer/Report/WearSpeedReportPage.aspx"><span class=""></span>Velocidad de desgaste</a></li>
                    </ul>
                    </li>
                    <li><a class="accordion-toggle" href="#"><span class="fa fa-group"></span><span class="sidebar-title">Usuarios</span><span class="caret"></span></a><ul class="nav sub-nav">
                        <li><a href="/_PresentationLayer/Users/RegisterUserPage.aspx"><span class=""></span>Administrador de usuarios</a></li>
                    </ul>
                    </li>
                </ul>
            </div>

            <!-- Start: Content-Wrapper -->
            <!-- begin: .tray-center -->
            <div class="tray tray-center">
                <div class="mw1000 center-block">
                    <section id="content_wrapper">

                        <div id="MainContent_UpdatePanel1">


                            <img id="MainContent_imgLogoTS" class="TSImage" src="../../ig_common/images/TSPng.png" />

                            <div class="AmisLogo">
                                <img id="MainContent_imgLogoAmis" src="../../ig_common/images/PNG_MEDIA.png" />
                            </div>


                        </div>

                    </section>
                </div>
            </div>
        </div>


    </div>
    </form>
</body>
</html>
