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
    
    public partial class AmisTaskType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AmisTaskType()
        {
            this.AmisTask = new HashSet<AmisTask>();
        }
    
        public int AmisTaskTypeId { get; set; }
        public string AmisTaskTypeName { get; set; }
        public string AmisTaskTypeDescription { get; set; }
        public string AmisTaskTypeImage { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AmisTask> AmisTask { get; set; }
    }
}