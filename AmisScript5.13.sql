/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     27/07/2016 16:17:18                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AmisUser') and o.name = 'FK_AMISUSER_REFERENCE_MEMBER')
alter table AmisUser
   drop constraint FK_AMISUSER_REFERENCE_MEMBER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Asset') and o.name = 'FK_ASSET_REFERENCE_ASSETUNI')
alter table Asset
   drop constraint FK_ASSET_REFERENCE_ASSETUNI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Asset') and o.name = 'FK_ASSET_REFERENCE_FACILITY')
alter table Asset
   drop constraint FK_ASSET_REFERENCE_FACILITY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Asset') and o.name = 'FK_ASSET_REFERENCE_DISPATCH')
alter table Asset
   drop constraint FK_ASSET_REFERENCE_DISPATCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Asset') and o.name = 'FK_ASSET_REFERENCE_SCRAPTYP')
alter table Asset
   drop constraint FK_ASSET_REFERENCE_SCRAPTYP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Asset') and o.name = 'FK_ASSET_REFERENCE_REPAIRTY')
alter table Asset
   drop constraint FK_ASSET_REFERENCE_REPAIRTY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetEvent') and o.name = 'FK_ASSETEVE_REFERENCE_ASSET')
alter table AssetEvent
   drop constraint FK_ASSETEVE_REFERENCE_ASSET
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetEvent') and o.name = 'FK_ASSETEVE_REFERENCE_UNIT')
alter table AssetEvent
   drop constraint FK_ASSETEVE_REFERENCE_UNIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetEvent') and o.name = 'FK_ASSETEVE_REFERENCE_ASSETPOS')
alter table AssetEvent
   drop constraint FK_ASSETEVE_REFERENCE_ASSETPOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetEvent') and o.name = 'FK_ASSETEVE_REFERENCE_ASSETSIT')
alter table AssetEvent
   drop constraint FK_ASSETEVE_REFERENCE_ASSETSIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetEvent') and o.name = 'FK_ASSETEVE_REFERENCE_ASSIGNME')
alter table AssetEvent
   drop constraint FK_ASSETEVE_REFERENCE_ASSIGNME
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetEvent') and o.name = 'FK_ASSETEVE_REFERENCE_FACILITY')
alter table AssetEvent
   drop constraint FK_ASSETEVE_REFERENCE_FACILITY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetEvent') and o.name = 'FK_ASSETEVE_REFERENCE_MEMBER')
alter table AssetEvent
   drop constraint FK_ASSETEVE_REFERENCE_MEMBER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetEvent') and o.name = 'FK_ASSETEVE_REFERENCE_MEASUREM')
alter table AssetEvent
   drop constraint FK_ASSETEVE_REFERENCE_MEASUREM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetEvent') and o.name = 'FK_ASSETEVE_REFERENCE_SUBEVENT')
alter table AssetEvent
   drop constraint FK_ASSETEVE_REFERENCE_SUBEVENT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetModel') and o.name = 'FK_ASSETMOD_REFERENCE_BRAND')
alter table AssetModel
   drop constraint FK_ASSETMOD_REFERENCE_BRAND
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetPosition') and o.name = 'FK_ASSETPOS_REFERENCE_AXLECONF')
alter table AssetPosition
   drop constraint FK_ASSETPOS_REFERENCE_AXLECONF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetSituation') and o.name = 'FK_ASSETSIT_REFERENCE_SITUATIO')
alter table AssetSituation
   drop constraint FK_ASSETSIT_REFERENCE_SITUATIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetUniqueIdentification') and o.name = 'FK_ASSETUNI_REFERENCE_ORIGIN')
alter table AssetUniqueIdentification
   drop constraint FK_ASSETUNI_REFERENCE_ORIGIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetUniqueIdentification') and o.name = 'FK_ASSETUNI_IDENTIFIC_REFERENCE_ASSETMOD')
alter table AssetUniqueIdentification
   drop constraint FK_ASSETUNI_IDENTIFIC_REFERENCE_ASSETMOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetUniqueIdentification') and o.name = 'FK_ASSETUNI_REFERENCE_ASSETMOD')
alter table AssetUniqueIdentification
   drop constraint FK_ASSETUNI_REFERENCE_ASSETMOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssetUniqueIdentification') and o.name = 'FK_ASSETUNI_REFERENCE_ASSETTYP')
alter table AssetUniqueIdentification
   drop constraint FK_ASSETUNI_REFERENCE_ASSETTYP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('AssignedUnit') and o.name = 'FK_ASSIG_PAR_REFERENCE_UNIT')
alter table AssignedUnit
   drop constraint FK_ASSIG_PAR_REFERENCE_UNIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Assignment') and o.name = 'FK_ASSIGNME_REFERENCE_UNIT')
alter table Assignment
   drop constraint FK_ASSIGNME_REFERENCE_UNIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Assignment') and o.name = 'FK_ASSIGNME_REFERENCE_OPERATIO')
alter table Assignment
   drop constraint FK_ASSIGNME_REFERENCE_OPERATIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('BranchOffice') and o.name = 'FK_BRANCHOF_REFERENCE_LOCATION')
alter table BranchOffice
   drop constraint FK_BRANCHOF_REFERENCE_LOCATION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Brand') and o.name = 'FK_BRAND_REFERENCE_MANUFACT')
alter table Brand
   drop constraint FK_BRAND_REFERENCE_MANUFACT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Commune') and o.name = 'FK_COMMUNE_REFERENCE_REGION')
alter table Commune
   drop constraint FK_COMMUNE_REFERENCE_REGION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ConfigurationAxleUnitType') and o.name = 'FK_CONFIGUR_REFERENCE_AXLECONF')
alter table ConfigurationAxleUnitType
   drop constraint FK_CONFIGUR_REFERENCE_AXLECONF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ConfigurationAxleUnitType') and o.name = 'FK_CONFIGUR_REFERENCE_CONFIGUR')
alter table ConfigurationAxleUnitType
   drop constraint FK_CONFIGUR_REFERENCE_CONFIGUR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ConfigurationUnitType') and o.name = 'FK_CONFIGUR_REFERENCE_TRACTION')
alter table ConfigurationUnitType
   drop constraint FK_CONFIGUR_REFERENCE_TRACTION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ConfigurationUnitType') and o.name = 'FK_CONFIGUR_REFERENCE_UNITTYPE')
alter table ConfigurationUnitType
   drop constraint FK_CONFIGUR_REFERENCE_UNITTYPE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DepthSetting') and o.name = 'FK_DEPTHSET_REFERENCE_APPLICAT')
alter table DepthSetting
   drop constraint FK_DEPTHSET_REFERENCE_APPLICAT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DepthSetting') and o.name = 'FK_DEPTHSET_REFERENCE_ASSETMOD')
alter table DepthSetting
   drop constraint FK_DEPTHSET_REFERENCE_ASSETMOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DispatchDocument') and o.name = 'FK_DISPATCH_REFERENCE_FACILITY_DESTINY')
alter table DispatchDocument
   drop constraint FK_DISPATCH_REFERENCE_FACILITY_DESTINY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DispatchDocument') and o.name = 'FK_DISPATCH_REFERENCE_FACILITY_ORIGIN')
alter table DispatchDocument
   drop constraint FK_DISPATCH_REFERENCE_FACILITY_ORIGIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DispatchDocumentItem') and o.name = 'FK_DOCUMENT_REFERENCE_ACTIVO2')
alter table DispatchDocumentItem
   drop constraint FK_DOCUMENT_REFERENCE_ACTIVO2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DispatchDocumentItem') and o.name = 'FK_DOCUMENT_REFERENCE_DOCUMENT2')
alter table DispatchDocumentItem
   drop constraint FK_DOCUMENT_REFERENCE_DOCUMENT2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DispatchProviderDocument') and o.name = 'FK_DISPATCH_REFERENCE_MEMBER')
alter table DispatchProviderDocument
   drop constraint FK_DISPATCH_REFERENCE_MEMBER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DispatchProviderDocument') and o.name = 'FK_DISPATCH_REFERENCE_FACILITY')
alter table DispatchProviderDocument
   drop constraint FK_DISPATCH_REFERENCE_FACILITY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DispatchProviderDocument') and o.name = 'FK_DISPATCH_PROVIDER_REFERENCE_DISPATCH_STATE')
alter table DispatchProviderDocument
   drop constraint FK_DISPATCH_PROVIDER_REFERENCE_DISPATCH_STATE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DispatchProviderDocumentItem') and o.name = 'FK_DISPATCH_ITEM_REFERENCE_DISPATCH')
alter table DispatchProviderDocumentItem
   drop constraint FK_DISPATCH_ITEM_REFERENCE_DISPATCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DispatchProviderDocumentItem') and o.name = 'FK_DISPAT_ITEM_REFERENCE_DISPATCH')
alter table DispatchProviderDocumentItem
   drop constraint FK_DISPAT_ITEM_REFERENCE_DISPATCH
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DispatchProviderDocumentItem') and o.name = 'FK_DISPATCH_REFERENCE_ASSETUNI')
alter table DispatchProviderDocumentItem
   drop constraint FK_DISPATCH_REFERENCE_ASSETUNI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EventAssetType') and o.name = 'FK_EVENTASS_REFERENCE_ASSETTYP')
alter table EventAssetType
   drop constraint FK_EVENTASS_REFERENCE_ASSETTYP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Facility') and o.name = 'FK_FACILITY_REFERENCE_UNIT')
alter table Facility
   drop constraint FK_FACILITY_REFERENCE_UNIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Facility') and o.name = 'FK_FACILITY_REFERENCE_FACILITY')
alter table Facility
   drop constraint FK_FACILITY_REFERENCE_FACILITY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Facility') and o.name = 'FK_FACILITY_REFERENCE_WAREHOUS')
alter table Facility
   drop constraint FK_FACILITY_REFERENCE_WAREHOUS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('GlobalCostDetail') and o.name = 'FK_GLOBALCO_REFERENCE_GLOBALCO')
alter table GlobalCostDetail
   drop constraint FK_GLOBALCO_REFERENCE_GLOBALCO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('InventoryDocument') and o.name = 'FK_INVENTOR_REFERENCE_FACILITY')
alter table InventoryDocument
   drop constraint FK_INVENTOR_REFERENCE_FACILITY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('InventoryDocumentItem') and o.name = 'FK_INVENTOR_REFERENCE_INVENTOR')
alter table InventoryDocumentItem
   drop constraint FK_INVENTOR_REFERENCE_INVENTOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('InventoryDocumentItem') and o.name = 'FK_INVENTOR_REFERENCE_ASSET')
alter table InventoryDocumentItem
   drop constraint FK_INVENTOR_REFERENCE_ASSET
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Location') and o.name = 'FK_LOCATION_REFERENCE_COMMUNE')
alter table Location
   drop constraint FK_LOCATION_REFERENCE_COMMUNE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Member') and o.name = 'FK_MEMBER_REFERENCE_MEMBERTY')
alter table Member
   drop constraint FK_MEMBER_REFERENCE_MEMBERTY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MemberBranchOffice') and o.name = 'FK_MEMBERBR_REFERENCE_MEMBER')
alter table MemberBranchOffice
   drop constraint FK_MEMBERBR_REFERENCE_MEMBER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MemberBranchOffice') and o.name = 'FK_MEMBERBR_REFERENCE_BRANCHOF')
alter table MemberBranchOffice
   drop constraint FK_MEMBERBR_REFERENCE_BRANCHOF
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MenuOption') and o.name = 'FK_MENUOPTI_REFERENCE_MENUOPTIPATERN')
alter table MenuOption
   drop constraint FK_MENUOPTI_REFERENCE_MENUOPTIPATERN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PageLog') and o.name = 'FK_PAGELOG_REFERENCE_MENUOPTI')
alter table PageLog
   drop constraint FK_PAGELOG_REFERENCE_MENUOPTI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PageLog') and o.name = 'FK_PAGELOG_REFERENCE_AMISUSER')
alter table PageLog
   drop constraint FK_PAGELOG_REFERENCE_AMISUSER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PageLog') and o.name = 'FK_PAGELOG_REFERENCE_PAGEACTI')
alter table PageLog
   drop constraint FK_PAGELOG_REFERENCE_PAGEACTI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PressureSetting') and o.name = 'FK_CONFIGUR_REFERENCE_APLICACI2')
alter table PressureSetting
   drop constraint FK_CONFIGUR_REFERENCE_APLICACI2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PressureSetting') and o.name = 'FK_CONFIGUR_REFERENCE_MODELOAC2')
alter table PressureSetting
   drop constraint FK_CONFIGUR_REFERENCE_MODELOAC2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ReceptionDocument') and o.name = 'FK_RECEPTIO_REFERENCE_FACILITY')
alter table ReceptionDocument
   drop constraint FK_RECEPTIO_REFERENCE_FACILITY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ReceptionDocumentItem') and o.name = 'FK_RECEPTIO_REFERENCE_RECEPTIO')
alter table ReceptionDocumentItem
   drop constraint FK_RECEPTIO_REFERENCE_RECEPTIO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ReceptionDocumentItem') and o.name = 'FK_RECEPTIO_REFERENCE_ASSET')
alter table ReceptionDocumentItem
   drop constraint FK_RECEPTIO_REFERENCE_ASSET
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Region') and o.name = 'FK_REGION_REFERENCE_COUNTRY')
alter table Region
   drop constraint FK_REGION_REFERENCE_COUNTRY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RepairType') and o.name = 'FK_REPAIRTY_REFERENCE_ASSETTYP')
alter table RepairType
   drop constraint FK_REPAIRTY_REFERENCE_ASSETTYP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ScrapType') and o.name = 'FK_SCRAPTYP_REFERENCE_ASSETTYP')
alter table ScrapType
   drop constraint FK_SCRAPTYP_REFERENCE_ASSETTYP
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SettingBattery') and o.name = 'FK_SETTINGB_REFERENCE_ASSETMOD')
alter table SettingBattery
   drop constraint FK_SETTINGB_REFERENCE_ASSETMOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SettingCat') and o.name = 'FK_SETTINGC_REFERENCE_ASSETMOD')
alter table SettingCat
   drop constraint FK_SETTINGC_REFERENCE_ASSETMOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SettingExtinguisher') and o.name = 'FK_SETTINGE_REFERENCE_ASSETMOD')
alter table SettingExtinguisher
   drop constraint FK_SETTINGE_REFERENCE_ASSETMOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SettingExtinguisher') and o.name = 'FK_SETTINGE_REFERENCE_FIRETYPE')
alter table SettingExtinguisher
   drop constraint FK_SETTINGE_REFERENCE_FIRETYPE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SettingLigthPole') and o.name = 'FK_SETTINGL_REFERENCE_ASSETMOD')
alter table SettingLigthPole
   drop constraint FK_SETTINGL_REFERENCE_ASSETMOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SettingRadio') and o.name = 'FK_SETTINGR_REFERENCE_ASSETMOD')
alter table SettingRadio
   drop constraint FK_SETTINGR_REFERENCE_ASSETMOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SettingTreadDepthDifference') and o.name = 'FK_SETTINGDEPTH_REFERENCE_ASSETMOD')
alter table SettingTreadDepthDifference
   drop constraint FK_SETTINGDEPTH_REFERENCE_ASSETMOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SettingTyre') and o.name = 'FK_SETTINGTYRE_REFERENCE_ASSETMOD')
alter table SettingTyre
   drop constraint FK_SETTINGTYRE_REFERENCE_ASSETMOD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SubEventAssetType') and o.name = 'FK_SUBEVENT_REFERENCE_EVENTASS')
alter table SubEventAssetType
   drop constraint FK_SUBEVENT_REFERENCE_EVENTASS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SystemParameter') and o.name = 'FK_SYSTEMPA_REFERENCE_CURRENCY')
alter table SystemParameter
   drop constraint FK_SYSTEMPA_REFERENCE_CURRENCY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SystemParameter') and o.name = 'FK_SYSTEMPA_REFERENCE_MEASUREM')
alter table SystemParameter
   drop constraint FK_SYSTEMPA_REFERENCE_MEASUREM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SystemParameter') and o.name = 'FK_SYSTEMPA_REFERENCE_MEASUREM2')
alter table SystemParameter
   drop constraint FK_SYSTEMPA_REFERENCE_MEASUREM2
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('SystemParameter') and o.name = 'FK_SYSTEMPA_REFERENCE_MEASUREM3')
alter table SystemParameter
   drop constraint FK_SYSTEMPA_REFERENCE_MEASUREM3
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TagAssigned') and o.name = 'FK_TAGASSIG_REFERENCE_TAG')
alter table TagAssigned
   drop constraint FK_TAGASSIG_REFERENCE_TAG
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('TagAssigned') and o.name = 'FK_TAGASSIG_REFERENCE_ASSET')
alter table TagAssigned
   drop constraint FK_TAGASSIG_REFERENCE_ASSET
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Unit') and o.name = 'FK_UNIT_REFERENCE_ASSET')
alter table Unit
   drop constraint FK_UNIT_REFERENCE_ASSET
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Unit') and o.name = 'FK_UNIT_REFERENCE_UNITREGI')
alter table Unit
   drop constraint FK_UNIT_REFERENCE_UNITREGI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UnitAsset') and o.name = 'FK_UNITASSE_REFERENCE_UNIT')
alter table UnitAsset
   drop constraint FK_UNITASSE_REFERENCE_UNIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UnitAsset') and o.name = 'FK_UNITASSE_REFERENCE_ASSET')
alter table UnitAsset
   drop constraint FK_UNITASSE_REFERENCE_ASSET
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UnitAsset') and o.name = 'FK_UNITASSE_REFERENCE_ASSETPOS')
alter table UnitAsset
   drop constraint FK_UNITASSE_REFERENCE_ASSETPOS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UnitRegister') and o.name = 'FK_UNITREGI_REFERENCE_UNITTYPE')
alter table UnitRegister
   drop constraint FK_UNITREGI_REFERENCE_UNITTYPE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UnitRegister') and o.name = 'FK_UNITREGI_REFERENCE_MEMBER')
alter table UnitRegister
   drop constraint FK_UNITREGI_REFERENCE_MEMBER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UnitRegister') and o.name = 'FK_UNITREGI_REFERENCE_CONFIGUR')
alter table UnitRegister
   drop constraint FK_UNITREGI_REFERENCE_CONFIGUR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UnitRegister') and o.name = 'FK_UNITREGI_REFERENCE_SUSPENSI')
alter table UnitRegister
   drop constraint FK_UNITREGI_REFERENCE_SUSPENSI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UserAlarm') and o.name = 'FK_USERALAR_REFERENCE_AMISUSER')
alter table UserAlarm
   drop constraint FK_USERALAR_REFERENCE_AMISUSER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UserAlarm') and o.name = 'FK_USERALAR_REFERENCE_ALARM')
alter table UserAlarm
   drop constraint FK_USERALAR_REFERENCE_ALARM
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UserAlarm') and o.name = 'FK_USERALAR_REFERENCE_USERALAR')
alter table UserAlarm
   drop constraint FK_USERALAR_REFERENCE_USERALAR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UserMenuOption') and o.name = 'FK_USERMENU_REFERENCE_AMISUSER')
alter table UserMenuOption
   drop constraint FK_USERMENU_REFERENCE_AMISUSER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UserMenuOption') and o.name = 'FK_USERMENU_REFERENCE_MENUOPTI')
alter table UserMenuOption
   drop constraint FK_USERMENU_REFERENCE_MENUOPTI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Warehouse') and o.name = 'FK_WAREHOUS_REFERENCE_BRANCHOF')
alter table Warehouse
   drop constraint FK_WAREHOUS_REFERENCE_BRANCHOF
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Alarm')
            and   type = 'U')
   drop table Alarm
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AmisUser')
            and   name  = 'IX_EMAIL'
            and   indid > 0
            and   indid < 255)
   drop index AmisUser.IX_EMAIL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AmisUser')
            and   type = 'U')
   drop table AmisUser
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Application')
            and   name  = 'AK_NAME'
            and   indid > 0
            and   indid < 255)
   drop index Application.AK_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Application')
            and   type = 'U')
   drop table Application
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Asset')
            and   type = 'U')
   drop table Asset
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AssetEvent')
            and   name  = 'IX_ASSETSITUATIONDATE'
            and   indid > 0
            and   indid < 255)
   drop index AssetEvent.IX_ASSETSITUATIONDATE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AssetEvent')
            and   name  = 'IX_ASSETSUBEVENTDATE'
            and   indid > 0
            and   indid < 255)
   drop index AssetEvent.IX_ASSETSUBEVENTDATE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AssetEvent')
            and   name  = 'IX_ASSETID'
            and   indid > 0
            and   indid < 255)
   drop index AssetEvent.IX_ASSETID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AssetEvent')
            and   type = 'U')
   drop table AssetEvent
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AssetModel')
            and   type = 'U')
   drop table AssetModel
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AssetModelService')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index AssetModelService.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AssetModelService')
            and   type = 'U')
   drop table AssetModelService
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AssetPosition')
            and   type = 'U')
   drop table AssetPosition
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AssetSituation')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index AssetSituation.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AssetSituation')
            and   type = 'U')
   drop table AssetSituation
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AssetType')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index AssetType.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AssetType')
            and   type = 'U')
   drop table AssetType
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AssetUniqueIdentification')
            and   name  = 'IX_IDORIGIN_IDMODEL_IDSERVICE'
            and   indid > 0
            and   indid < 255)
   drop index AssetUniqueIdentification.IX_IDORIGIN_IDMODEL_IDSERVICE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AssetUniqueIdentification')
            and   type = 'U')
   drop table AssetUniqueIdentification
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AssignedUnit')
            and   type = 'U')
   drop table AssignedUnit
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Assignment')
            and   name  = 'IX_UNIOPELOCDAT'
            and   indid > 0
            and   indid < 255)
   drop index Assignment.IX_UNIOPELOCDAT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Assignment')
            and   type = 'U')
   drop table Assignment
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AxleConfiguration')
            and   name  = 'IX_ABB'
            and   indid > 0
            and   indid < 255)
   drop index AxleConfiguration.IX_ABB
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('AxleConfiguration')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index AxleConfiguration.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AxleConfiguration')
            and   type = 'U')
   drop table AxleConfiguration
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('BranchOffice')
            and   name  = 'AX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index BranchOffice.AX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BranchOffice')
            and   type = 'U')
   drop table BranchOffice
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Brand')
            and   type = 'U')
   drop table Brand
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Commune')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index Commune.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Commune')
            and   type = 'U')
   drop table Commune
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ConfigurationAxleUnitType')
            and   name  = 'IX_AXLE_UNITTYPE'
            and   indid > 0
            and   indid < 255)
   drop index ConfigurationAxleUnitType.IX_AXLE_UNITTYPE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ConfigurationAxleUnitType')
            and   type = 'U')
   drop table ConfigurationAxleUnitType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ConfigurationUnitType')
            and   type = 'U')
   drop table ConfigurationUnitType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CostBaseLine')
            and   type = 'U')
   drop table CostBaseLine
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Country')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index Country.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Country')
            and   type = 'U')
   drop table Country
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Currency')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index Currency.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Currency')
            and   type = 'U')
   drop table Currency
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DepthSetting')
            and   type = 'U')
   drop table DepthSetting
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DispatchDocument')
            and   name  = 'IX_DOCNUM'
            and   indid > 0
            and   indid < 255)
   drop index DispatchDocument.IX_DOCNUM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DispatchDocument')
            and   type = 'U')
   drop table DispatchDocument
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DispatchDocumentItem')
            and   name  = 'IX_DOCUMENTASSET'
            and   indid > 0
            and   indid < 255)
   drop index DispatchDocumentItem.IX_DOCUMENTASSET
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DispatchDocumentItem')
            and   type = 'U')
   drop table DispatchDocumentItem
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DispatchProviderDocument')
            and   type = 'U')
   drop table DispatchProviderDocument
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DispatchProviderDocumentItem')
            and   type = 'U')
   drop table DispatchProviderDocumentItem
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DispatchProviderDocumentState')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index DispatchProviderDocumentState.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DispatchProviderDocumentState')
            and   type = 'U')
   drop table DispatchProviderDocumentState
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EventAssetType')
            and   type = 'U')
   drop table EventAssetType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Facility')
            and   type = 'U')
   drop table Facility
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('FacilityType')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index FacilityType.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FacilityType')
            and   type = 'U')
   drop table FacilityType
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('FireType')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index FireType.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FireType')
            and   type = 'U')
   drop table FireType
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GlobalCost')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index GlobalCost.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GlobalCost')
            and   type = 'U')
   drop table GlobalCost
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('GlobalCostDetail')
            and   name  = 'IX_MONTHCOST'
            and   indid > 0
            and   indid < 255)
   drop index GlobalCostDetail.IX_MONTHCOST
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GlobalCostDetail')
            and   type = 'U')
   drop table GlobalCostDetail
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('InventoryDocument')
            and   name  = 'IX_DOCNUM'
            and   indid > 0
            and   indid < 255)
   drop index InventoryDocument.IX_DOCNUM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InventoryDocument')
            and   type = 'U')
   drop table InventoryDocument
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('InventoryDocumentItem')
            and   name  = 'IX_DOCUMENTASSET'
            and   indid > 0
            and   indid < 255)
   drop index InventoryDocumentItem.IX_DOCUMENTASSET
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InventoryDocumentItem')
            and   type = 'U')
   drop table InventoryDocumentItem
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Location')
            and   type = 'U')
   drop table Location
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Manufacturer')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index Manufacturer.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Manufacturer')
            and   type = 'U')
   drop table Manufacturer
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MeasurementUnit')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index MeasurementUnit.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MeasurementUnit')
            and   type = 'U')
   drop table MeasurementUnit
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Member')
            and   name  = 'IX_RUT'
            and   indid > 0
            and   indid < 255)
   drop index Member.IX_RUT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Member')
            and   type = 'U')
   drop table Member
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MemberBranchOffice')
            and   type = 'U')
   drop table MemberBranchOffice
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MemberType')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index MemberType.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MemberType')
            and   type = 'U')
   drop table MemberType
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MenuOption')
            and   name  = 'IX_PAGEURL'
            and   indid > 0
            and   indid < 255)
   drop index MenuOption.IX_PAGEURL
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MenuOption')
            and   type = 'U')
   drop table MenuOption
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Operation')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index Operation.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Operation')
            and   type = 'U')
   drop table Operation
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Origin')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index Origin.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Origin')
            and   type = 'U')
   drop table Origin
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PageAction')
            and   type = 'U')
   drop table PageAction
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PageLog')
            and   type = 'U')
   drop table PageLog
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PressureSetting')
            and   name  = 'IX_APLICATIONMODELOPERATION'
            and   indid > 0
            and   indid < 255)
   drop index PressureSetting.IX_APLICATIONMODELOPERATION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PressureSetting')
            and   type = 'U')
   drop table PressureSetting
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ReceptionDocument')
            and   name  = 'IX_DOCNUM'
            and   indid > 0
            and   indid < 255)
   drop index ReceptionDocument.IX_DOCNUM
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ReceptionDocument')
            and   type = 'U')
   drop table ReceptionDocument
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ReceptionDocumentItem')
            and   name  = 'IX_DOCUMENTASSET'
            and   indid > 0
            and   indid < 255)
   drop index ReceptionDocumentItem.IX_DOCUMENTASSET
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ReceptionDocumentItem')
            and   type = 'U')
   drop table ReceptionDocumentItem
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Region')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index Region.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Region')
            and   type = 'U')
   drop table Region
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RepairType')
            and   type = 'U')
   drop table RepairType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ScrapType')
            and   type = 'U')
   drop table ScrapType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SettingBattery')
            and   type = 'U')
   drop table SettingBattery
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SettingCat')
            and   type = 'U')
   drop table SettingCat
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SettingExtinguisher')
            and   type = 'U')
   drop table SettingExtinguisher
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SettingLigthPole')
            and   type = 'U')
   drop table SettingLigthPole
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SettingRadio')
            and   type = 'U')
   drop table SettingRadio
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SettingTreadDepthDifference')
            and   type = 'U')
   drop table SettingTreadDepthDifference
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SettingTyre')
            and   type = 'U')
   drop table SettingTyre
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SituationType')
            and   type = 'U')
   drop table SituationType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SubEventAssetType')
            and   type = 'U')
   drop table SubEventAssetType
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('SuspensionType')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index SuspensionType.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SuspensionType')
            and   type = 'U')
   drop table SuspensionType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SystemParameter')
            and   type = 'U')
   drop table SystemParameter
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Tag')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index Tag.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tag')
            and   type = 'U')
   drop table Tag
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TagAssigned')
            and   name  = 'IX_TAGASSETDATE'
            and   indid > 0
            and   indid < 255)
   drop index TagAssigned.IX_TAGASSETDATE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TagAssigned')
            and   type = 'U')
   drop table TagAssigned
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('TractionType')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index TractionType.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TractionType')
            and   type = 'U')
   drop table TractionType
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Unit')
            and   name  = 'IX_REG_ASSET'
            and   indid > 0
            and   indid < 255)
   drop index Unit.IX_REG_ASSET
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Unit')
            and   type = 'U')
   drop table Unit
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UnitAsset')
            and   type = 'U')
   drop table UnitAsset
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('UnitRegister')
            and   name  = 'IX_PATENTNUMBER'
            and   indid > 0
            and   indid < 255)
   drop index UnitRegister.IX_PATENTNUMBER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UnitRegister')
            and   type = 'U')
   drop table UnitRegister
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('UnitType')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index UnitType.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UnitType')
            and   type = 'U')
   drop table UnitType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UserAlarm')
            and   type = 'U')
   drop table UserAlarm
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UserAlarmType')
            and   type = 'U')
   drop table UserAlarmType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UserMenuOption')
            and   type = 'U')
   drop table UserMenuOption
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Warehouse')
            and   name  = 'IX_BRANCH_WAREHOUSE'
            and   indid > 0
            and   indid < 255)
   drop index Warehouse.IX_BRANCH_WAREHOUSE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Warehouse')
            and   name  = 'IX_NAME'
            and   indid > 0
            and   indid < 255)
   drop index Warehouse.IX_NAME
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Warehouse')
            and   type = 'U')
   drop table Warehouse
go

/*==============================================================*/
/* Table: Alarm                                                 */
/*==============================================================*/
create table Alarm (
   AlarmId              int                  not null,
   AlarmName            varchar(255)         not null,
   constraint PK_ALARM primary key (AlarmId)
)
go

/*==============================================================*/
/* Table: AmisUser                                              */
/*==============================================================*/
create table AmisUser (
   AmisUserId           int                  identity,
   MemberId             int                  not null,
   Email                varchar(100)         not null,
   Password             varchar(100)         not null,
   Enable               char(1)              not null,
   Name                 varchar(100)         not null,
   CreatedDate          datetime             not null,
   DisabledDate         datetime             null,
   ChangePasswordCode   varchar(100)         not null,
   SecretAnswer         varchar(100)         null,
   SecretQuestion       varchar(100)         null,
   DisableDate          datetime             null,
   constraint PK_AMISUSER primary key (AmisUserId)
)
go

/*==============================================================*/
/* Index: IX_EMAIL                                              */
/*==============================================================*/
create unique index IX_EMAIL on AmisUser (
Email ASC
)
go

/*==============================================================*/
/* Table: Application                                           */
/*==============================================================*/
create table Application (
   ApplicationId        int                  identity,
   ApplicationName      varchar(255)         not null,
   constraint PK_APPLICATION primary key (ApplicationId)
)
go

/*==============================================================*/
/* Index: AK_NAME                                               */
/*==============================================================*/
create unique index AK_NAME on Application (
ApplicationName ASC
)
go

/*==============================================================*/
/* Table: Asset                                                 */
/*==============================================================*/
create table Asset (
   AssetId              int                  identity,
   AssetUniqueIdentificationId int                  not null,
   FacilityId           int                  null,
   DispatchProviderDocumentId int                  not null,
   ScrapTypeId          int                  null,
   RepairTypeId         int                  null,
   Kilometers           int                  not null,
   AssetSerie           int                  null,
   Cost                 int                  not null,
   WarrantyStartDate    datetime             not null,
   WarrantyKm           int                  null,
   WarrantyMounth       int                  null,
   IsGood               char(1)              not null,
   constraint PK_ASSET primary key (AssetId)
)
go

/*==============================================================*/
/* Table: AssetEvent                                            */
/*==============================================================*/
create table AssetEvent (
   AssetEventId         int                  identity,
   AssetId              int                  not null,
   SubEventAssetTypeId  int                  not null,
   MeasurementUnitId    int                  null,
   AssetPositionId      int                  null,
   AsignmentId          int                  null,
   AssetSituationId     int                  null,
   AssetEventMemberId   int                  not null,
   FacilityId           int                  null,
   UnitId               int                  null,
   AssetEventDate       datetime             not null,
   AssetEventCost       decimal              null,
   MeasurementAsset     decimal              null,
   MeasurementKm        int                  null,
   StartPressureMeasurement decimal              null,
   FinishPressureMeasurement decimal              null,
   MeasurementTireTreadDepth1 decimal              null,
   MeasurementTireTreadDepth2 decimal              null,
   MeasurementTireTreadDepth3 decimal              null,
   MeasurementTireTreadDepth4 decimal              null,
   MeasurementTireTreadDepth5 decimal              null,
   ExecutingUserId      int                  null,
   AuthorizingUserId    int                  null,
   constraint PK_ASSETEVENT primary key (AssetEventId)
)
go

/*==============================================================*/
/* Index: IX_ASSETID                                            */
/*==============================================================*/
create index IX_ASSETID on AssetEvent (
AssetId ASC
)
go

/*==============================================================*/
/* Index: IX_ASSETSUBEVENTDATE                                  */
/*==============================================================*/
create index IX_ASSETSUBEVENTDATE on AssetEvent (
AssetId ASC,
SubEventAssetTypeId ASC,
AssetEventDate ASC
)
go

/*==============================================================*/
/* Index: IX_ASSETSITUATIONDATE                                 */
/*==============================================================*/
create index IX_ASSETSITUATIONDATE on AssetEvent (
AssetId ASC,
AssetSituationId ASC,
AssetEventDate ASC
)
go

/*==============================================================*/
/* Table: AssetModel                                            */
/*==============================================================*/
create table AssetModel (
   AssetModelId         int                  identity,
   BrandId              int                  not null,
   AssetModelName       varchar(255)         not null,
   constraint PK_ASSETMODEL primary key (AssetModelId)
)
go

/*==============================================================*/
/* Table: AssetModelService                                     */
/*==============================================================*/
create table AssetModelService (
   AssetModelServiceId  int                  identity,
   AssetModelServiceName varchar(255)         not null,
   constraint PK_ASSETMODELSERVICE primary key (AssetModelServiceId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on AssetModelService (
AssetModelServiceName ASC
)
go

/*==============================================================*/
/* Table: AssetPosition                                         */
/*==============================================================*/
create table AssetPosition (
   AssetPositionId      int                  identity,
   AxleConfigurationId  int                  not null,
   AssetPositionName    varchar(255)         not null,
   AssetPositionAbbreviation varchar(10)          not null,
   AssetColumn          int                  not null,
   PositionDescription  varchar(255)         not null,
   constraint PK_ASSETPOSITION primary key (AssetPositionId)
)
go

/*==============================================================*/
/* Table: AssetSituation                                        */
/*==============================================================*/
create table AssetSituation (
   AssetSituationId     int                  identity,
   SituationTypeId      int                  null,
   AssetSituationName   varchar(255)         not null,
   constraint PK_ASSETSITUATION primary key (AssetSituationId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on AssetSituation (
AssetSituationName ASC
)
go

/*==============================================================*/
/* Table: AssetType                                             */
/*==============================================================*/
create table AssetType (
   AssetTypeId          int                  identity,
   AssetTypeName        varchar(255)         not null,
   constraint PK_ASSETTYPE primary key (AssetTypeId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on AssetType (
AssetTypeName ASC
)
go

/*==============================================================*/
/* Table: AssetUniqueIdentification                             */
/*==============================================================*/
create table AssetUniqueIdentification (
   AssetUniqueIdentificationId int                  identity,
   OriginId             int                  not null,
   AssetModelId         int                  not null,
   AssetModelServiceId  int                  not null,
   AssetTypeId          int                  not null,
   constraint PK_ASSETUNIQUEIDENTIFICATION primary key (AssetUniqueIdentificationId)
)
go

/*==============================================================*/
/* Index: IX_IDORIGIN_IDMODEL_IDSERVICE                         */
/*==============================================================*/
create index IX_IDORIGIN_IDMODEL_IDSERVICE on AssetUniqueIdentification (
OriginId ASC,
AssetModelId ASC,
AssetModelServiceId ASC,
AssetTypeId ASC
)
go

/*==============================================================*/
/* Table: AssignedUnit                                          */
/*==============================================================*/
create table AssignedUnit (
   AssignedUnitId       int                  identity,
   UnitParentId         int                  not null,
   UnsignedDate         datetime             null,
   AssignedDate         datetime             null,
   constraint PK_ASSIGNEDUNIT primary key (AssignedUnitId)
)
go

/*==============================================================*/
/* Table: Assignment                                            */
/*==============================================================*/
create table Assignment (
   AssignmentId         int                  identity,
   OperationId          int                  not null,
   UnitId               int                  null,
   AssignmentDate       datetime             not null,
   EndAssignmentDate    datetime             null,
   constraint PK_ASSIGNMENT primary key (AssignmentId)
)
go

/*==============================================================*/
/* Index: IX_UNIOPELOCDAT                                       */
/*==============================================================*/
create unique index IX_UNIOPELOCDAT on Assignment (
OperationId ASC,
AssignmentDate ASC
)
go

/*==============================================================*/
/* Table: AxleConfiguration                                     */
/*==============================================================*/
create table AxleConfiguration (
   AxleConfigurationId  int                  identity,
   AxleConfigurationName varchar(255)         not null,
   AxleConfigurationAbbreviation varchar(10)          not null,
   Path                 varchar(255)         null,
   constraint PK_AXLECONFIGURATION primary key (AxleConfigurationId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on AxleConfiguration (
AxleConfigurationName ASC
)
go

/*==============================================================*/
/* Index: IX_ABB                                                */
/*==============================================================*/
create unique index IX_ABB on AxleConfiguration (
AxleConfigurationAbbreviation ASC
)
go

/*==============================================================*/
/* Table: BranchOffice                                          */
/*==============================================================*/
create table BranchOffice (
   BranchOfficeId       int                  identity,
   LocationId           int                  not null,
   BranchOfficeName     varchar(255)         not null,
   constraint PK_BRANCHOFFICE primary key (BranchOfficeId)
)
go

/*==============================================================*/
/* Index: AX_NAME                                               */
/*==============================================================*/
create unique index AX_NAME on BranchOffice (
BranchOfficeName ASC
)
go

/*==============================================================*/
/* Table: Brand                                                 */
/*==============================================================*/
create table Brand (
   BrandId              int                  identity,
   ManufacturerId       int                  not null,
   BrandName            varchar(255)         not null,
   constraint PK_BRAND primary key (BrandId)
)
go

/*==============================================================*/
/* Table: Commune                                               */
/*==============================================================*/
create table Commune (
   CommuneId            int                  identity,
   RegionId             int                  not null,
   CommuneName          varchar(255)         not null,
   constraint PK_COMMUNE primary key (CommuneId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on Commune (
CommuneName ASC
)
go

/*==============================================================*/
/* Table: ConfigurationAxleUnitType                             */
/*==============================================================*/
create table ConfigurationAxleUnitType (
   ConfigurationUnitTypeId int                  not null,
   AxleConfigurationId  int                  not null,
   ConfigurationAxleUnitTypeid int                  identity,
   Position             int                  not null,
   constraint PK_CONFIGURATIONAXLEUNITTYPE primary key (ConfigurationAxleUnitTypeid)
)
go

/*==============================================================*/
/* Index: IX_AXLE_UNITTYPE                                      */
/*==============================================================*/
create unique index IX_AXLE_UNITTYPE on ConfigurationAxleUnitType (
ConfigurationUnitTypeId ASC,
AxleConfigurationId ASC
)
go

/*==============================================================*/
/* Table: ConfigurationUnitType                                 */
/*==============================================================*/
create table ConfigurationUnitType (
   ConfigurationUnitTypeId int                  identity,
   UnitTypeId           int                  not null,
   TractionTypeId       int                  not null,
   ConfigurationUnitTypeName varchar(255)         not null,
   ConfigurationUnitTypeAbr varchar(10)          not null,
   Path                 varchar(500)         not null,
   constraint PK_CONFIGURATIONUNITTYPE primary key (ConfigurationUnitTypeId)
)
go

/*==============================================================*/
/* Table: CostBaseLine                                          */
/*==============================================================*/
create table CostBaseLine (
   CostBaseLineId       int                  identity,
   ThirdCost            int                  not null,
   RetreadingCost       int                  not null,
   NewCost              int                  not null,
   FieldCost            int                  not null,
   FinalDisposition     int                  not null,
   ShellCost            int                  not null,
   CostBaseLineYear     int                  not null,
   constraint PK_COSTBASELINE primary key (CostBaseLineId)
)
go

/*==============================================================*/
/* Table: Country                                               */
/*==============================================================*/
create table Country (
   CountryId            int                  identity,
   CountryName          varchar(255)         not null,
   constraint PK_COUNTRY primary key (CountryId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on Country (
CountryName ASC
)
go

/*==============================================================*/
/* Table: Currency                                              */
/*==============================================================*/
create table Currency (
   CurrencyId           int                  identity,
   CurrencyName         varchar(100)         not null,
   CurrencySymbol       varchar(10)          not null,
   CurrencyIsoCode      varchar(10)          null,
   constraint PK_CURRENCY primary key (CurrencyId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on Currency (
CurrencyName ASC
)
go

/*==============================================================*/
/* Table: DepthSetting                                          */
/*==============================================================*/
create table DepthSetting (
   DepthSettingId       int                  identity,
   ApplicationId        int                  not null,
   AssetModelId         int                  not null,
   ScrapDepth           decimal              not null,
   constraint PK_DEPTHSETTING primary key (DepthSettingId)
)
go

/*==============================================================*/
/* Table: DispatchDocument                                      */
/*==============================================================*/
create table DispatchDocument (
   DispatchDocumentId   int                  identity,
   FacilityOriginId     int                  not null,
   FacilityDestinyId    int                  not null,
   DispatchDate         datetime             not null,
   DispatchDocumentNumber int                  not null,
   constraint PK_DISPATCHDOCUMENT primary key (DispatchDocumentId)
)
go

/*==============================================================*/
/* Index: IX_DOCNUM                                             */
/*==============================================================*/
create unique index IX_DOCNUM on DispatchDocument (
DispatchDocumentNumber ASC
)
go

/*==============================================================*/
/* Table: DispatchDocumentItem                                  */
/*==============================================================*/
create table DispatchDocumentItem (
   DispatchDocumentItemId int                  identity,
   DispatchDocumentId   int                  not null,
   AssetId              int                  not null,
   constraint PK_DISPATCHDOCUMENTITEM primary key (DispatchDocumentItemId)
)
go

/*==============================================================*/
/* Index: IX_DOCUMENTASSET                                      */
/*==============================================================*/
create unique index IX_DOCUMENTASSET on DispatchDocumentItem (
DispatchDocumentId ASC,
AssetId ASC
)
go

/*==============================================================*/
/* Table: DispatchProviderDocument                              */
/*==============================================================*/
create table DispatchProviderDocument (
   DispatchProviderDocumentId int                  identity,
   FacilityId           int                  not null,
   DispatchProviderDocumentStateId int                  not null,
   ProviderMemberId     int                  not null,
   DispatchDate         datetime             not null,
   DocumentNumber       int                  not null,
   constraint PK_DISPATCHPROVIDERDOCUMENT primary key (DispatchProviderDocumentId)
)
go

/*==============================================================*/
/* Table: DispatchProviderDocumentItem                          */
/*==============================================================*/
create table DispatchProviderDocumentItem (
   DispatchProviderDocumentItemId int                  identity,
   DispatchProviderDocumentId int                  not null,
   AssetUniqueIdentificationId int                  not null,
   DispatchProviderDocumentStateId int                  not null,
   DeclaratedAmount     int                  not null,
   ReceptionAmount      int                  not null,
   ItemCost             int                  not null,
   ManufacturerYear     int                  not null,
   AssignedAmount       int                  not null,
   Observation          varchar(500)         null,
   constraint PK_DISPATCHPROVIDERDOCUMENTITE primary key (DispatchProviderDocumentItemId)
)
go

/*==============================================================*/
/* Table: DispatchProviderDocumentState                         */
/*==============================================================*/
create table DispatchProviderDocumentState (
   DispatchProviderDocumentStateId int                  identity,
   DispatchProviderDocumentStateName varchar(255)         not null,
   constraint PK_DISPATCHPROVIDERDOCUMENTSTA primary key (DispatchProviderDocumentStateId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on DispatchProviderDocumentState (
DispatchProviderDocumentStateName ASC
)
go

/*==============================================================*/
/* Table: EventAssetType                                        */
/*==============================================================*/
create table EventAssetType (
   EventAssetTypeId     int                  identity,
   AssetTypeId          int                  not null,
   EventAssetTypeName   varchar(255)         not null,
   constraint PK_EVENTASSETTYPE primary key (EventAssetTypeId)
)
go

/*==============================================================*/
/* Table: Facility                                              */
/*==============================================================*/
create table Facility (
   FacilityId           int                  identity,
   FacilityTypeId       int                  not null,
   WarehouseId          int                  null,
   UnitId               int                  null,
   constraint PK_FACILITY primary key (FacilityId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'This table is Installation acording to answer given in email 21:19 hrs 26-01-2016 from Cristián Gómez Vega',
   'user', @CurrentUser, 'table', 'Facility'
go

/*==============================================================*/
/* Table: FacilityType                                          */
/*==============================================================*/
create table FacilityType (
   FacilityTypeId       int                  identity,
   FacilityTypeName     varchar(255)         not null,
   constraint PK_FACILITYTYPE primary key (FacilityTypeId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on FacilityType (
FacilityTypeName ASC
)
go

/*==============================================================*/
/* Table: FireType                                              */
/*==============================================================*/
create table FireType (
   FireTypeId           int                  identity,
   FireTypeName         varchar(255)         not null,
   constraint PK_FIRETYPE primary key (FireTypeId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on FireType (
FireTypeName ASC
)
go

/*==============================================================*/
/* Table: GlobalCost                                            */
/*==============================================================*/
create table GlobalCost (
   GlobalCostId         int                  identity,
   GlobalCostName       varchar(255)         not null,
   constraint PK_GLOBALCOST primary key (GlobalCostId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on GlobalCost (
GlobalCostName ASC
)
go

/*==============================================================*/
/* Table: GlobalCostDetail                                      */
/*==============================================================*/
create table GlobalCostDetail (
   GlobalCostDetailId   int                  identity,
   GlobalCostId         int                  not null,
   Month                datetime             not null,
   Cost                 decimal              not null,
   CountUnit            int                  not null,
   constraint PK_GLOBALCOSTDETAIL primary key (GlobalCostDetailId)
)
go

/*==============================================================*/
/* Index: IX_MONTHCOST                                          */
/*==============================================================*/
create unique index IX_MONTHCOST on GlobalCostDetail (
Month ASC,
Cost ASC
)
go

/*==============================================================*/
/* Table: InventoryDocument                                     */
/*==============================================================*/
create table InventoryDocument (
   InventoryDocumentId  int                  identity,
   FacilityId           int                  null,
   InventoryDate        datetime             not null,
   InventoryDocumentNumber int                  not null,
   Cost                 decimal              not null,
   constraint PK_INVENTORYDOCUMENT primary key (InventoryDocumentId)
)
go

/*==============================================================*/
/* Index: IX_DOCNUM                                             */
/*==============================================================*/
create unique index IX_DOCNUM on InventoryDocument (
InventoryDocumentNumber ASC
)
go

/*==============================================================*/
/* Table: InventoryDocumentItem                                 */
/*==============================================================*/
create table InventoryDocumentItem (
   InventoryDocumentItemId int                  identity,
   InventoryDocumentId  int                  not null,
   AssetId              int                  not null,
   constraint PK_INVENTORYDOCUMENTITEM primary key (InventoryDocumentItemId)
)
go

/*==============================================================*/
/* Index: IX_DOCUMENTASSET                                      */
/*==============================================================*/
create unique index IX_DOCUMENTASSET on InventoryDocumentItem (
InventoryDocumentId ASC,
AssetId ASC
)
go

/*==============================================================*/
/* Table: Location                                              */
/*==============================================================*/
create table Location (
   LocationId           int                  identity,
   CommuneId            int                  not null,
   LocationName         varchar(255)         not null,
   constraint PK_LOCATION primary key (LocationId)
)
go

/*==============================================================*/
/* Table: Manufacturer                                          */
/*==============================================================*/
create table Manufacturer (
   ManufacturerId       int                  identity,
   ManufacturerName     varchar(255)         not null,
   constraint PK_MANUFACTURER primary key (ManufacturerId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on Manufacturer (
ManufacturerName ASC
)
go

/*==============================================================*/
/* Table: MeasurementUnit                                       */
/*==============================================================*/
create table MeasurementUnit (
   MeasurementUnitId    int                  identity,
   MeasurementUnitName  varchar(255)         not null,
   constraint PK_MEASUREMENTUNIT primary key (MeasurementUnitId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on MeasurementUnit (
MeasurementUnitName ASC
)
go

/*==============================================================*/
/* Table: Member                                                */
/*==============================================================*/
create table Member (
   MemberId             int                  identity,
   MemberTypeId         int                  not null,
   MemberName           varchar(255)         not null,
   MemberRut            varchar(50)          not null,
   MemberEmail          varchar(100)         not null,
   constraint PK_MEMBER primary key nonclustered (MemberId)
)
go

/*==============================================================*/
/* Index: IX_RUT                                                */
/*==============================================================*/
create unique index IX_RUT on Member (
MemberRut ASC
)
go

/*==============================================================*/
/* Table: MemberBranchOffice                                    */
/*==============================================================*/
create table MemberBranchOffice (
   MemberBranchOfficeId int                  identity,
   MemberId             int                  not null,
   BranchOfficeId       int                  not null,
   constraint PK_SucursalIntegrante primary key (MemberBranchOfficeId)
)
go

/*==============================================================*/
/* Table: MemberType                                            */
/*==============================================================*/
create table MemberType (
   MemberTypeId         int                  identity,
   MemberTypeName       varchar(255)         not null,
   constraint PK_MEMBERTYPE primary key (MemberTypeId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on MemberType (
MemberTypeName ASC
)
go

/*==============================================================*/
/* Table: MenuOption                                            */
/*==============================================================*/
create table MenuOption (
   MenuOptionId         int                  not null,
   ParentMenuOptionId   int                  null,
   Name                 varchar(100)         not null,
   PageURL              varchar(100)         not null,
   WindowType           varchar(255)         not null,
   CreatePermission     char(1)              not null,
   ReadPermission       char(1)              not null,
   UpdatePermission     char(1)              not null,
   DeletePermission     char(1)              not null,
   FindPermission       char(1)              not null,
   ExecutePermission    char(1)              not null,
   ChangePermission     char(1)              not null,
   GenerateReport       char(1)              not null,
   AuthorizePermission  char(1)              not null,
   Action1              char(1)              not null,
   NameAction1          varchar(100)         not null,
   Action2              char(1)              not null,
   NameAction2          varchar(100)         not null,
   Action3              char(1)              not null,
   NameAction3          varchar(100)         not null,
   Action4              char(1)              not null,
   NameAction4          varchar(100)         not null,
   Action5              char(1)              not null,
   NameAction5          varchar(100)         not null,
   Action6              char(1)              not null,
   NameAction6          varchar(100)         not null,
   Action7              char(1)              not null,
   NameAction7          varchar(100)         not null,
   Active               char(1)              not null,
   constraint PK_MENUOPTION primary key nonclustered (MenuOptionId)
)
go

/*==============================================================*/
/* Index: IX_PAGEURL                                            */
/*==============================================================*/
create unique index IX_PAGEURL on MenuOption (
PageURL ASC
)
go

/*==============================================================*/
/* Table: Operation                                             */
/*==============================================================*/
create table Operation (
   OperationId          int                  identity,
   OperationName        varchar(255)         not null,
   constraint PK_OPERATION primary key (OperationId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on Operation (
OperationName ASC
)
go

/*==============================================================*/
/* Table: Origin                                                */
/*==============================================================*/
create table Origin (
   OriginId             int                  identity,
   OriginName           varchar(255)         not null,
   constraint PK_ORIGIN primary key (OriginId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on Origin (
OriginName ASC
)
go

/*==============================================================*/
/* Table: PageAction                                            */
/*==============================================================*/
create table PageAction (
   PageActionId         int                  identity,
   PageActionName       varchar(255)         not null,
   PageActionDescription varchar(255)         not null,
   constraint PK_PAGEACTION primary key (PageActionId)
)
go

/*==============================================================*/
/* Table: PageLog                                               */
/*==============================================================*/
create table PageLog (
   PageLogId            int                  identity,
   MenuOptionId         int                  not null,
   PageActionId         int                  not null,
   AmisUserId           int                  null,
   Description          varchar(1000)        null,
   ActionDateTime       datetime             not null,
   constraint PK_PAGELOG primary key nonclustered (PageLogId)
)
go

/*==============================================================*/
/* Table: PressureSetting                                       */
/*==============================================================*/
create table PressureSetting (
   PressureSettingId    int                  identity,
   AssetModelId         int                  not null,
   ApplicationId        int                  not null,
   Pressure             decimal              not null,
   constraint PK_PRESSURESETTING primary key (PressureSettingId)
)
go

/*==============================================================*/
/* Index: IX_APLICATIONMODELOPERATION                           */
/*==============================================================*/
create unique index IX_APLICATIONMODELOPERATION on PressureSetting (
ApplicationId ASC,
AssetModelId ASC
)
go

/*==============================================================*/
/* Table: ReceptionDocument                                     */
/*==============================================================*/
create table ReceptionDocument (
   ReceptionDocumentId  int                  identity,
   ReceptionFacilityId  int                  not null,
   ReceptionDate        datetime             not null,
   ReceptionDocumentNumber int                  not null,
   Cost                 decimal              not null,
   constraint PK_RECEPTIONDOCUMENT primary key (ReceptionDocumentId)
)
go

/*==============================================================*/
/* Index: IX_DOCNUM                                             */
/*==============================================================*/
create unique index IX_DOCNUM on ReceptionDocument (
ReceptionDocumentNumber ASC
)
go

/*==============================================================*/
/* Table: ReceptionDocumentItem                                 */
/*==============================================================*/
create table ReceptionDocumentItem (
   ReceptionDocumentItemId int                  identity,
   ReceptionDocumentId  int                  not null,
   AssetId              int                  not null,
   constraint PK_RECEPTIONDOCUMENTITEM primary key (ReceptionDocumentItemId)
)
go

/*==============================================================*/
/* Index: IX_DOCUMENTASSET                                      */
/*==============================================================*/
create unique index IX_DOCUMENTASSET on ReceptionDocumentItem (
ReceptionDocumentId ASC,
AssetId ASC
)
go

/*==============================================================*/
/* Table: Region                                                */
/*==============================================================*/
create table Region (
   RegionId             int                  identity,
   CountryId            int                  not null,
   RegionName           varchar(255)         not null,
   constraint PK_REGION primary key (RegionId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on Region (
RegionName ASC
)
go

/*==============================================================*/
/* Table: RepairType                                            */
/*==============================================================*/
create table RepairType (
   RepairTypeId         int                  identity,
   AssetTypeId          int                  not null,
   RepairTypeName       varchar(255)         not null,
   constraint PK_REPAIRTYPE primary key (RepairTypeId)
)
go

/*==============================================================*/
/* Table: ScrapType                                             */
/*==============================================================*/
create table ScrapType (
   ScrapTypeId          int                  identity,
   AssetTypeId          int                  not null,
   ScrapName            varchar(255)         not null,
   constraint PK_SCRAPTYPE primary key (ScrapTypeId)
)
go

/*==============================================================*/
/* Table: SettingBattery                                        */
/*==============================================================*/
create table SettingBattery (
   SettingBatteryId     int                  identity,
   AssetModelId         int                  not null,
   InstallDate          datetime             not null,
   Voltage              int                  not null,
   Capacity             int                  not null,
   PositionPolePositive varchar(100)         not null,
   constraint PK_SETTINGBATTERY primary key (SettingBatteryId)
)
go

/*==============================================================*/
/* Table: SettingCat                                            */
/*==============================================================*/
create table SettingCat (
   SettingCatId         int                  identity,
   AssetModelId         int                  not null,
   Capacity             int                  not null,
   constraint PK_SETTINGCAT primary key (SettingCatId)
)
go

/*==============================================================*/
/* Table: SettingExtinguisher                                   */
/*==============================================================*/
create table SettingExtinguisher (
   SettingExtinguisherId int                  identity,
   AssetModelId         int                  not null,
   FireTypeId           int                  not null,
   FireSize             int                  not null,
   EndLifeDate          datetime             not null,
   constraint PK_SETTINGEXTINGUISHER primary key (SettingExtinguisherId)
)
go

/*==============================================================*/
/* Table: SettingLigthPole                                      */
/*==============================================================*/
create table SettingLigthPole (
   SettingLigthPoleId   int                  identity,
   AssetModelId         int                  not null,
   InstallDate          datetime             not null,
   constraint PK_SETTINGLIGTHPOLE primary key (SettingLigthPoleId)
)
go

/*==============================================================*/
/* Table: SettingRadio                                          */
/*==============================================================*/
create table SettingRadio (
   SettingRadioId       int                  identity,
   AssetModelId         int                  not null,
   EndOfUseDate         datetime             not null,
   constraint PK_SETTINGRADIO primary key (SettingRadioId)
)
go

/*==============================================================*/
/* Table: SettingTreadDepthDifference                           */
/*==============================================================*/
create table SettingTreadDepthDifference (
   SettingTreadDepthDifferenceId int                  identity,
   AssetModelId         int                  not null,
   TreadDepthDifferenceAccepted decimal              not null,
   AcceptancePercentage decimal              null,
   InitialDifferenceDepth decimal              not null,
   DepthNumber          int                  not null,
   constraint PK_SETTINGTREADDEPTHDIFFERENCE primary key (SettingTreadDepthDifferenceId)
)
go

/*==============================================================*/
/* Table: SettingTyre                                           */
/*==============================================================*/
create table SettingTyre (
   SettingTyreId        int                  identity,
   AssetModelId         int                  not null,
   New                  char(1)              not null,
   Retreaiding          char(1)              not null,
   constraint PK_SETTINGTYRE primary key (SettingTyreId)
)
go

/*==============================================================*/
/* Table: SituationType                                         */
/*==============================================================*/
create table SituationType (
   SituationTypeId      int                  identity,
   SituationTypeName    varchar(255)         not null,
   constraint PK_SITUATIONTYPE primary key (SituationTypeId)
)
go

/*==============================================================*/
/* Table: SubEventAssetType                                     */
/*==============================================================*/
create table SubEventAssetType (
   SubEventAssetTypeId  int                  identity,
   AssetEventTypeId     int                  not null,
   SubEventAssetTypeName varchar(255)         not null,
   constraint PK_SUBEVENTASSETTYPE primary key (SubEventAssetTypeId)
)
go

/*==============================================================*/
/* Table: SuspensionType                                        */
/*==============================================================*/
create table SuspensionType (
   SuspensionTypeId     int                  identity,
   SuspensionTypeName   varchar(255)         not null,
   constraint PK_SUSPENSIONTYPE primary key (SuspensionTypeId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on SuspensionType (
SuspensionTypeName ASC
)
go

/*==============================================================*/
/* Table: SystemParameter                                       */
/*==============================================================*/
create table SystemParameter (
   SystemParameterId    int                  identity,
   CurrencyId           int                  not null,
   TyrePressureMeasurementId int                  not null,
   TyreDepthMeasurementUnitId int                  not null,
   UnitMeasurementUnitId int                  not null,
   constraint PK_SYSTEMPARAMETER primary key (SystemParameterId)
)
go

/*==============================================================*/
/* Table: Tag                                                   */
/*==============================================================*/
create table Tag (
   TagId                int                  identity,
   TagCode              varchar(255)         not null,
   TSOwner              char(1)              not null,
   StartDate            datetime             not null,
   CustomerAssignationDate datetime             null,
   CancellationDate     datetime             null,
   constraint PK_TAG primary key (TagId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on Tag (
TagCode ASC
)
go

/*==============================================================*/
/* Table: TagAssigned                                           */
/*==============================================================*/
create table TagAssigned (
   TagAssignedId        int                  identity,
   TagId                int                  not null,
   AssetId              int                  not null,
   TagAssignedDate      datetime             not null,
   constraint PK_TAGASSIGNED primary key (TagAssignedId)
)
go

/*==============================================================*/
/* Index: IX_TAGASSETDATE                                       */
/*==============================================================*/
create unique index IX_TAGASSETDATE on TagAssigned (
TagId ASC,
AssetId ASC,
TagAssignedDate ASC
)
go

/*==============================================================*/
/* Table: TractionType                                          */
/*==============================================================*/
create table TractionType (
   TractionTypeId       int                  identity,
   TractionTypeName     varchar(255)         not null,
   constraint PK_TRACTIONTYPE primary key (TractionTypeId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on TractionType (
TractionTypeName ASC
)
go

/*==============================================================*/
/* Table: Unit                                                  */
/*==============================================================*/
create table Unit (
   UnitId               int                  identity,
   AssetId              int                  not null,
   UnitRegisterId       int                  not null,
   constraint PK_UNIT primary key (UnitId)
)
go

/*==============================================================*/
/* Index: IX_REG_ASSET                                          */
/*==============================================================*/
create unique index IX_REG_ASSET on Unit (
AssetId ASC,
UnitRegisterId ASC
)
go

/*==============================================================*/
/* Table: UnitAsset                                             */
/*==============================================================*/
create table UnitAsset (
   UnitAssetId          int                  identity,
   AssetId              int                  not null,
   UnitId               int                  null,
   AssetPositionId      int                  null,
   AssignedDate         datetime             not null,
   UnassignedDate       datetime             null,
   constraint PK_UNITASSET primary key (UnitAssetId)
)
go

/*==============================================================*/
/* Table: UnitRegister                                          */
/*==============================================================*/
create table UnitRegister (
   UnitRegisterId       int                  identity,
   UnitTypeId           int                  not null,
   UnitTypeConfigurationId int                  not null,
   SuspensionTypeId     int                  not null,
   UnitOwnerMemberId    int                  not null,
   KilometersOfTravel   int                  not null,
   UnitPurchaseDate     datetime             not null,
   UnitName             varchar(255)         not null,
   PatentNumber         varchar(255)         not null,
   UnitManufacturingYear int                  not null,
   NewOrUsed            char(1)              not null,
   UnitTara             decimal              not null,
   Vin                  varchar(255)         not null,
   InternalNumber       varchar(255)         not null,
   NextDrivingLicenseDate datetime             null,
   NextTechnicalReviewDate datetime             null,
   NextQualificationDate datetime             null,
   constraint PK_UNITREGISTER primary key (UnitRegisterId)
)
go

/*==============================================================*/
/* Index: IX_PATENTNUMBER                                       */
/*==============================================================*/
create index IX_PATENTNUMBER on UnitRegister (
PatentNumber ASC
)
go

/*==============================================================*/
/* Table: UnitType                                              */
/*==============================================================*/
create table UnitType (
   UnitTypeId           int                  identity,
   UnitTypeName         varchar(255)         not null,
   constraint PK_UNITTYPE primary key (UnitTypeId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on UnitType (
UnitTypeName ASC
)
go

/*==============================================================*/
/* Table: UserAlarm                                             */
/*==============================================================*/
create table UserAlarm (
   UserAlarmId          int                  identity,
   AmisUserId           int                  not null,
   AlarmId              int                  not null,
   UserAlarmTypeId      int                  not null,
   constraint PK_USERALARM primary key (UserAlarmId)
)
go

/*==============================================================*/
/* Table: UserAlarmType                                         */
/*==============================================================*/
create table UserAlarmType (
   UserAlarmTypeId      int                  not null,
   UserAlarmTypeName    varchar(255)         not null,
   constraint PK_USERALARMTYPE primary key (UserAlarmTypeId)
)
go

/*==============================================================*/
/* Table: UserMenuOption                                        */
/*==============================================================*/
create table UserMenuOption (
   UserMenuOptionId     int                  identity,
   MenuOptionId         int                  not null,
   AmisUserId           int                  null,
   CanCreate            char(1)              not null,
   CanRead              char(1)              not null,
   CanUpdate            char(1)              not null,
   CanDelete            char(1)              not null,
   CanFind              char(1)              not null,
   CanExecute           char(1)              not null,
   CanChange            char(1)              not null,
   CanAuthorize         char(1)              not null,
   CanDoAction1         char(1)              not null,
   CanDoAction2         char(1)              not null,
   CanDoAction3         char(1)              not null,
   CanDoAction4         char(1)              not null,
   CanDoAction5         char(1)              not null,
   CanDoAction6         char(1)              not null,
   CanDoAction7         char(1)              not null,
   CanGenerateReport    char(1)              not null,
   constraint PK_USERMENUOPTION primary key (UserMenuOptionId)
)
go

/*==============================================================*/
/* Table: Warehouse                                             */
/*==============================================================*/
create table Warehouse (
   WarehouseId          int                  identity,
   BranchOfficeId       int                  not null,
   WarehouseName        varchar(255)         not null,
   constraint PK_WAREHOUSE primary key (WarehouseId)
)
go

/*==============================================================*/
/* Index: IX_NAME                                               */
/*==============================================================*/
create unique index IX_NAME on Warehouse (
WarehouseName ASC
)
go

/*==============================================================*/
/* Index: IX_BRANCH_WAREHOUSE                                   */
/*==============================================================*/
create unique index IX_BRANCH_WAREHOUSE on Warehouse (
WarehouseId ASC,
BranchOfficeId ASC
)
go

alter table AmisUser
   add constraint FK_AMISUSER_REFERENCE_MEMBER foreign key (MemberId)
      references Member (MemberId)
go

alter table Asset
   add constraint FK_ASSET_REFERENCE_ASSETUNI foreign key (AssetUniqueIdentificationId)
      references AssetUniqueIdentification (AssetUniqueIdentificationId)
go

alter table Asset
   add constraint FK_ASSET_REFERENCE_FACILITY foreign key (FacilityId)
      references Facility (FacilityId)
go

alter table Asset
   add constraint FK_ASSET_REFERENCE_DISPATCH foreign key (DispatchProviderDocumentId)
      references DispatchProviderDocument (DispatchProviderDocumentId)
go

alter table Asset
   add constraint FK_ASSET_REFERENCE_SCRAPTYP foreign key (ScrapTypeId)
      references ScrapType (ScrapTypeId)
go

alter table Asset
   add constraint FK_ASSET_REFERENCE_REPAIRTY foreign key (RepairTypeId)
      references RepairType (RepairTypeId)
go

alter table AssetEvent
   add constraint FK_ASSETEVE_REFERENCE_ASSET foreign key (AssetId)
      references Asset (AssetId)
go

alter table AssetEvent
   add constraint FK_ASSETEVE_REFERENCE_UNIT foreign key (UnitId)
      references Unit (UnitId)
go

alter table AssetEvent
   add constraint FK_ASSETEVE_REFERENCE_ASSETPOS foreign key (AssetPositionId)
      references AssetPosition (AssetPositionId)
go

alter table AssetEvent
   add constraint FK_ASSETEVE_REFERENCE_ASSETSIT foreign key (AssetSituationId)
      references AssetSituation (AssetSituationId)
go

alter table AssetEvent
   add constraint FK_ASSETEVE_REFERENCE_ASSIGNME foreign key (AsignmentId)
      references Assignment (AssignmentId)
go

alter table AssetEvent
   add constraint FK_ASSETEVE_REFERENCE_FACILITY foreign key (FacilityId)
      references Facility (FacilityId)
go

alter table AssetEvent
   add constraint FK_ASSETEVE_REFERENCE_MEMBER foreign key (AssetEventMemberId)
      references Member (MemberId)
go

alter table AssetEvent
   add constraint FK_ASSETEVE_REFERENCE_MEASUREM foreign key (MeasurementUnitId)
      references MeasurementUnit (MeasurementUnitId)
go

alter table AssetEvent
   add constraint FK_ASSETEVE_REFERENCE_SUBEVENT foreign key (SubEventAssetTypeId)
      references SubEventAssetType (SubEventAssetTypeId)
go

alter table AssetModel
   add constraint FK_ASSETMOD_REFERENCE_BRAND foreign key (BrandId)
      references Brand (BrandId)
go

alter table AssetPosition
   add constraint FK_ASSETPOS_REFERENCE_AXLECONF foreign key (AxleConfigurationId)
      references AxleConfiguration (AxleConfigurationId)
go

alter table AssetSituation
   add constraint FK_ASSETSIT_REFERENCE_SITUATIO foreign key (SituationTypeId)
      references SituationType (SituationTypeId)
go

alter table AssetUniqueIdentification
   add constraint FK_ASSETUNI_REFERENCE_ORIGIN foreign key (OriginId)
      references Origin (OriginId)
go

alter table AssetUniqueIdentification
   add constraint FK_ASSETUNI_IDENTIFIC_REFERENCE_ASSETMOD foreign key (AssetModelId)
      references AssetModel (AssetModelId)
go

alter table AssetUniqueIdentification
   add constraint FK_ASSETUNI_REFERENCE_ASSETMOD foreign key (AssetModelServiceId)
      references AssetModelService (AssetModelServiceId)
go

alter table AssetUniqueIdentification
   add constraint FK_ASSETUNI_REFERENCE_ASSETTYP foreign key (AssetTypeId)
      references AssetType (AssetTypeId)
go

alter table AssignedUnit
   add constraint FK_ASSIG_PAR_REFERENCE_UNIT foreign key (UnitParentId)
      references Unit (UnitId)
go

alter table Assignment
   add constraint FK_ASSIGNME_REFERENCE_UNIT foreign key (UnitId)
      references Unit (UnitId)
go

alter table Assignment
   add constraint FK_ASSIGNME_REFERENCE_OPERATIO foreign key (OperationId)
      references Operation (OperationId)
go

alter table BranchOffice
   add constraint FK_BRANCHOF_REFERENCE_LOCATION foreign key (LocationId)
      references Location (LocationId)
go

alter table Brand
   add constraint FK_BRAND_REFERENCE_MANUFACT foreign key (ManufacturerId)
      references Manufacturer (ManufacturerId)
go

alter table Commune
   add constraint FK_COMMUNE_REFERENCE_REGION foreign key (RegionId)
      references Region (RegionId)
go

alter table ConfigurationAxleUnitType
   add constraint FK_CONFIGUR_REFERENCE_AXLECONF foreign key (AxleConfigurationId)
      references AxleConfiguration (AxleConfigurationId)
go

alter table ConfigurationAxleUnitType
   add constraint FK_CONFIGUR_REFERENCE_CONFIGUR foreign key (ConfigurationUnitTypeId)
      references ConfigurationUnitType (ConfigurationUnitTypeId)
go

alter table ConfigurationUnitType
   add constraint FK_CONFIGUR_REFERENCE_TRACTION foreign key (TractionTypeId)
      references TractionType (TractionTypeId)
go

alter table ConfigurationUnitType
   add constraint FK_CONFIGUR_REFERENCE_UNITTYPE foreign key (UnitTypeId)
      references UnitType (UnitTypeId)
go

alter table DepthSetting
   add constraint FK_DEPTHSET_REFERENCE_APPLICAT foreign key (ApplicationId)
      references Application (ApplicationId)
go

alter table DepthSetting
   add constraint FK_DEPTHSET_REFERENCE_ASSETMOD foreign key (AssetModelId)
      references AssetModel (AssetModelId)
go

alter table DispatchDocument
   add constraint FK_DISPATCH_REFERENCE_FACILITY_DESTINY foreign key (FacilityDestinyId)
      references Facility (FacilityId)
go

alter table DispatchDocument
   add constraint FK_DISPATCH_REFERENCE_FACILITY_ORIGIN foreign key (FacilityOriginId)
      references Facility (FacilityId)
go

alter table DispatchDocumentItem
   add constraint FK_DOCUMENT_REFERENCE_ACTIVO2 foreign key (AssetId)
      references Asset (AssetId)
go

alter table DispatchDocumentItem
   add constraint FK_DOCUMENT_REFERENCE_DOCUMENT2 foreign key (DispatchDocumentId)
      references DispatchDocument (DispatchDocumentId)
go

alter table DispatchProviderDocument
   add constraint FK_DISPATCH_REFERENCE_MEMBER foreign key (ProviderMemberId)
      references Member (MemberId)
go

alter table DispatchProviderDocument
   add constraint FK_DISPATCH_REFERENCE_FACILITY foreign key (FacilityId)
      references Facility (FacilityId)
go

alter table DispatchProviderDocument
   add constraint FK_DISPATCH_PROVIDER_REFERENCE_DISPATCH_STATE foreign key (DispatchProviderDocumentStateId)
      references DispatchProviderDocumentState (DispatchProviderDocumentStateId)
go

alter table DispatchProviderDocumentItem
   add constraint FK_DISPATCH_ITEM_REFERENCE_DISPATCH foreign key (DispatchProviderDocumentStateId)
      references DispatchProviderDocumentState (DispatchProviderDocumentStateId)
go

alter table DispatchProviderDocumentItem
   add constraint FK_DISPAT_ITEM_REFERENCE_DISPATCH foreign key (DispatchProviderDocumentId)
      references DispatchProviderDocument (DispatchProviderDocumentId)
go

alter table DispatchProviderDocumentItem
   add constraint FK_DISPATCH_REFERENCE_ASSETUNI foreign key (AssetUniqueIdentificationId)
      references AssetUniqueIdentification (AssetUniqueIdentificationId)
go

alter table EventAssetType
   add constraint FK_EVENTASS_REFERENCE_ASSETTYP foreign key (AssetTypeId)
      references AssetType (AssetTypeId)
go

alter table Facility
   add constraint FK_FACILITY_REFERENCE_UNIT foreign key (UnitId)
      references Unit (UnitId)
go

alter table Facility
   add constraint FK_FACILITY_REFERENCE_FACILITY foreign key (FacilityTypeId)
      references FacilityType (FacilityTypeId)
go

alter table Facility
   add constraint FK_FACILITY_REFERENCE_WAREHOUS foreign key (WarehouseId)
      references Warehouse (WarehouseId)
go

alter table GlobalCostDetail
   add constraint FK_GLOBALCO_REFERENCE_GLOBALCO foreign key (GlobalCostId)
      references GlobalCost (GlobalCostId)
go

alter table InventoryDocument
   add constraint FK_INVENTOR_REFERENCE_FACILITY foreign key (FacilityId)
      references Facility (FacilityId)
go

alter table InventoryDocumentItem
   add constraint FK_INVENTOR_REFERENCE_INVENTOR foreign key (InventoryDocumentId)
      references InventoryDocument (InventoryDocumentId)
go

alter table InventoryDocumentItem
   add constraint FK_INVENTOR_REFERENCE_ASSET foreign key (AssetId)
      references Asset (AssetId)
go

alter table Location
   add constraint FK_LOCATION_REFERENCE_COMMUNE foreign key (CommuneId)
      references Commune (CommuneId)
go

alter table Member
   add constraint FK_MEMBER_REFERENCE_MEMBERTY foreign key (MemberTypeId)
      references MemberType (MemberTypeId)
go

alter table MemberBranchOffice
   add constraint FK_MEMBERBR_REFERENCE_MEMBER foreign key (MemberId)
      references Member (MemberId)
go

alter table MemberBranchOffice
   add constraint FK_MEMBERBR_REFERENCE_BRANCHOF foreign key (BranchOfficeId)
      references BranchOffice (BranchOfficeId)
go

alter table MenuOption
   add constraint FK_MENUOPTI_REFERENCE_MENUOPTIPATERN foreign key (ParentMenuOptionId)
      references MenuOption (MenuOptionId)
go

alter table PageLog
   add constraint FK_PAGELOG_REFERENCE_MENUOPTI foreign key (MenuOptionId)
      references MenuOption (MenuOptionId)
go

alter table PageLog
   add constraint FK_PAGELOG_REFERENCE_AMISUSER foreign key (AmisUserId)
      references AmisUser (AmisUserId)
go

alter table PageLog
   add constraint FK_PAGELOG_REFERENCE_PAGEACTI foreign key (PageActionId)
      references PageAction (PageActionId)
go

alter table PressureSetting
   add constraint FK_CONFIGUR_REFERENCE_APLICACI2 foreign key (ApplicationId)
      references Application (ApplicationId)
go

alter table PressureSetting
   add constraint FK_CONFIGUR_REFERENCE_MODELOAC2 foreign key (AssetModelId)
      references AssetModel (AssetModelId)
go

alter table ReceptionDocument
   add constraint FK_RECEPTIO_REFERENCE_FACILITY foreign key (ReceptionFacilityId)
      references Facility (FacilityId)
go

alter table ReceptionDocumentItem
   add constraint FK_RECEPTIO_REFERENCE_RECEPTIO foreign key (ReceptionDocumentId)
      references ReceptionDocument (ReceptionDocumentId)
go

alter table ReceptionDocumentItem
   add constraint FK_RECEPTIO_REFERENCE_ASSET foreign key (AssetId)
      references Asset (AssetId)
go

alter table Region
   add constraint FK_REGION_REFERENCE_COUNTRY foreign key (CountryId)
      references Country (CountryId)
go

alter table RepairType
   add constraint FK_REPAIRTY_REFERENCE_ASSETTYP foreign key (AssetTypeId)
      references AssetType (AssetTypeId)
go

alter table ScrapType
   add constraint FK_SCRAPTYP_REFERENCE_ASSETTYP foreign key (AssetTypeId)
      references AssetType (AssetTypeId)
go

alter table SettingBattery
   add constraint FK_SETTINGB_REFERENCE_ASSETMOD foreign key (AssetModelId)
      references AssetModel (AssetModelId)
go

alter table SettingCat
   add constraint FK_SETTINGC_REFERENCE_ASSETMOD foreign key (AssetModelId)
      references AssetModel (AssetModelId)
go

alter table SettingExtinguisher
   add constraint FK_SETTINGE_REFERENCE_ASSETMOD foreign key (AssetModelId)
      references AssetModel (AssetModelId)
go

alter table SettingExtinguisher
   add constraint FK_SETTINGE_REFERENCE_FIRETYPE foreign key (FireTypeId)
      references FireType (FireTypeId)
go

alter table SettingLigthPole
   add constraint FK_SETTINGL_REFERENCE_ASSETMOD foreign key (AssetModelId)
      references AssetModel (AssetModelId)
go

alter table SettingRadio
   add constraint FK_SETTINGR_REFERENCE_ASSETMOD foreign key (AssetModelId)
      references AssetModel (AssetModelId)
go

alter table SettingTreadDepthDifference
   add constraint FK_SETTINGDEPTH_REFERENCE_ASSETMOD foreign key (AssetModelId)
      references AssetModel (AssetModelId)
go

alter table SettingTyre
   add constraint FK_SETTINGTYRE_REFERENCE_ASSETMOD foreign key (AssetModelId)
      references AssetModel (AssetModelId)
go

alter table SubEventAssetType
   add constraint FK_SUBEVENT_REFERENCE_EVENTASS foreign key (AssetEventTypeId)
      references EventAssetType (EventAssetTypeId)
go

alter table SystemParameter
   add constraint FK_SYSTEMPA_REFERENCE_CURRENCY foreign key (CurrencyId)
      references Currency (CurrencyId)
go

alter table SystemParameter
   add constraint FK_SYSTEMPA_REFERENCE_MEASUREM foreign key (TyrePressureMeasurementId)
      references MeasurementUnit (MeasurementUnitId)
go

alter table SystemParameter
   add constraint FK_SYSTEMPA_REFERENCE_MEASUREM2 foreign key (TyreDepthMeasurementUnitId)
      references MeasurementUnit (MeasurementUnitId)
go

alter table SystemParameter
   add constraint FK_SYSTEMPA_REFERENCE_MEASUREM3 foreign key (UnitMeasurementUnitId)
      references MeasurementUnit (MeasurementUnitId)
go

alter table TagAssigned
   add constraint FK_TAGASSIG_REFERENCE_TAG foreign key (TagId)
      references Tag (TagId)
go

alter table TagAssigned
   add constraint FK_TAGASSIG_REFERENCE_ASSET foreign key (AssetId)
      references Asset (AssetId)
go

alter table Unit
   add constraint FK_UNIT_REFERENCE_ASSET foreign key (AssetId)
      references Asset (AssetId)
go

alter table Unit
   add constraint FK_UNIT_REFERENCE_UNITREGI foreign key (UnitRegisterId)
      references UnitRegister (UnitRegisterId)
go

alter table UnitAsset
   add constraint FK_UNITASSE_REFERENCE_UNIT foreign key (UnitId)
      references Unit (UnitId)
go

alter table UnitAsset
   add constraint FK_UNITASSE_REFERENCE_ASSET foreign key (AssetId)
      references Asset (AssetId)
go

alter table UnitAsset
   add constraint FK_UNITASSE_REFERENCE_ASSETPOS foreign key (AssetPositionId)
      references AssetPosition (AssetPositionId)
go

alter table UnitRegister
   add constraint FK_UNITREGI_REFERENCE_UNITTYPE foreign key (UnitTypeId)
      references UnitType (UnitTypeId)
go

alter table UnitRegister
   add constraint FK_UNITREGI_REFERENCE_MEMBER foreign key (UnitOwnerMemberId)
      references Member (MemberId)
go

alter table UnitRegister
   add constraint FK_UNITREGI_REFERENCE_CONFIGUR foreign key (UnitTypeConfigurationId)
      references ConfigurationUnitType (ConfigurationUnitTypeId)
go

alter table UnitRegister
   add constraint FK_UNITREGI_REFERENCE_SUSPENSI foreign key (SuspensionTypeId)
      references SuspensionType (SuspensionTypeId)
go

alter table UserAlarm
   add constraint FK_USERALAR_REFERENCE_AMISUSER foreign key (AmisUserId)
      references AmisUser (AmisUserId)
go

alter table UserAlarm
   add constraint FK_USERALAR_REFERENCE_ALARM foreign key (AlarmId)
      references Alarm (AlarmId)
go

alter table UserAlarm
   add constraint FK_USERALAR_REFERENCE_USERALAR foreign key (UserAlarmTypeId)
      references UserAlarmType (UserAlarmTypeId)
go

alter table UserMenuOption
   add constraint FK_USERMENU_REFERENCE_AMISUSER foreign key (AmisUserId)
      references AmisUser (AmisUserId)
go

alter table UserMenuOption
   add constraint FK_USERMENU_REFERENCE_MENUOPTI foreign key (MenuOptionId)
      references MenuOption (MenuOptionId)
go

alter table Warehouse
   add constraint FK_WAREHOUS_REFERENCE_BRANCHOF foreign key (BranchOfficeId)
      references BranchOffice (BranchOfficeId)
go

