//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OA.Moel
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActionInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActionInfo()
        {
            this.RoleInfo = new HashSet<RoleInfo>();
        }
    
        public int id { get; set; }
        public string ActionName { get; set; }
        public Nullable<int> ActionTypeMenu { get; set; }
        public string MenuId { get; set; }
        public string HttpMethod { get; set; }
        public string Url { get; set; }
        public string ActionDesc { get; set; }
        public string DelFlag { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public Nullable<System.DateTime> SubTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleInfo> RoleInfo { get; set; }
    }
}