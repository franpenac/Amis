//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace amis
{
    using System;
    using System.Collections.Generic;
    
    public partial class SettingBattery
    {
        public int SettingBatteryId { get; set; }
        public int AssetModelId { get; set; }
        public System.DateTime InstallDate { get; set; }
        public int Voltage { get; set; }
        public int Capacity { get; set; }
        public string PositionPolePositive { get; set; }
    
        public virtual AssetModel AssetModel { get; set; }
    }
}
