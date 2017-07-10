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
    
    public partial class Asset
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Asset()
        {
            this.AssetEvent = new HashSet<AssetEvent>();
            this.AuditDocumentItem = new HashSet<AuditDocumentItem>();
            this.DispatchDocumentItem = new HashSet<DispatchDocumentItem>();
            this.ReceptionDocumentItem = new HashSet<ReceptionDocumentItem>();
            this.TagAssigned = new HashSet<TagAssigned>();
            this.Unit = new HashSet<Unit>();
            this.UnitAsset = new HashSet<UnitAsset>();
        }
    
        public int AssetId { get; set; }
        public int AssetUniqueIdentificationId { get; set; }
        public Nullable<int> FacilityId { get; set; }
        public int DispatchProviderDocumentId { get; set; }
        public Nullable<int> ScrapTypeId { get; set; }
        public Nullable<int> RepairTypeId { get; set; }
        public Nullable<int> ApplicationId { get; set; }
        public int Kilometers { get; set; }
        public Nullable<int> AssetSerie { get; set; }
        public decimal Cost { get; set; }
        public System.DateTime WarrantyStartDate { get; set; }
        public Nullable<int> WarrantyKm { get; set; }
        public Nullable<int> WarrantyMounth { get; set; }
        public string IsGood { get; set; }
        public string Dot { get; set; }
    
        public virtual Application Application { get; set; }
        public virtual AssetUniqueIdentification AssetUniqueIdentification { get; set; }
        public virtual DispatchProviderDocument DispatchProviderDocument { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual RepairType RepairType { get; set; }
        public virtual ScrapType ScrapType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssetEvent> AssetEvent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AuditDocumentItem> AuditDocumentItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DispatchDocumentItem> DispatchDocumentItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReceptionDocumentItem> ReceptionDocumentItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TagAssigned> TagAssigned { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unit> Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UnitAsset> UnitAsset { get; set; }
    }
}