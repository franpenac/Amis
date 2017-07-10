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
    
    public partial class AssetPosition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssetPosition()
        {
            this.AssetEvent = new HashSet<AssetEvent>();
            this.UnitAsset = new HashSet<UnitAsset>();
        }
    
        public int AssetPositionId { get; set; }
        public int AxleConfigurationId { get; set; }
        public string AssetPositionName { get; set; }
        public string AssetPositionAbbreviation { get; set; }
        public int AssetColumn { get; set; }
        public string PositionDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssetEvent> AssetEvent { get; set; }
        public virtual AxleConfiguration AxleConfiguration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnitAsset> UnitAsset { get; set; }
    }
}
