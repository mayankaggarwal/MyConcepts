//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace temp
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_pz_message
    {
        public int MessageID { get; set; }
        public Nullable<int> ParentMessageID { get; set; }
        public Nullable<int> ThreadID { get; set; }
        public Nullable<long> ContainerType { get; set; }
        public string ContainerCode { get; set; }
        public Nullable<int> ContainerID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Subject { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
    }
}