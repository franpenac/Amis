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
    
    public partial class DispatchDocument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DispatchDocument()
        {
            this.DispatchDocumentItem = new HashSet<DispatchDocumentItem>();
        }
    
        public int DispatchDocumentId { get; set; }
        public int FacilityOriginId { get; set; }
        public int FacilityDestinyId { get; set; }
        public System.DateTime DispatchDate { get; set; }
        public int DispatchDocumentNumber { get; set; }
    
        public virtual Facility Facility { get; set; }
        public virtual Facility Facility1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DispatchDocumentItem> DispatchDocumentItem { get; set; }
    }
}
