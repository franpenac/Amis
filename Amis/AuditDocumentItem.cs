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
    
    public partial class AuditDocumentItem
    {
        public int AuditDocumentItemId { get; set; }
        public int AuditDocumentId { get; set; }
        public int AssetId { get; set; }
        public string Found { get; set; }
    
        public virtual Asset Asset { get; set; }
        public virtual AuditDocument AuditDocument { get; set; }
    }
}