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
    
    public partial class AssetUniqueIdentification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssetUniqueIdentification()
        {
            this.Asset = new HashSet<Asset>();
            this.AssetEvent = new HashSet<AssetEvent>();
            this.DispatchProviderDocumentItem = new HashSet<DispatchProviderDocumentItem>();
        }
    
        public int AssetUniqueIdentificationId { get; set; }
        public int OriginId { get; set; }
        public int AssetModelId { get; set; }
        public int AssetModelServiceId { get; set; }
        public int AssetTypeId { get; set; }
        public Nullable<int> SettingTyreId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asset> Asset { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssetEvent> AssetEvent { get; set; }
        public virtual AssetModel AssetModel { get; set; }
        public virtual AssetModelService AssetModelService { get; set; }
        public virtual AssetType AssetType { get; set; }
        public virtual Origin Origin { get; set; }
        public virtual SettingTyre SettingTyre { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DispatchProviderDocumentItem> DispatchProviderDocumentItem { get; set; }
    }
}
