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
    
    public partial class tbl_pz_blogpost
    {
        public int BlogPostID { get; set; }
        public Nullable<int> BlogID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Subject { get; set; }
        public string PermaLink { get; set; }
        public string Status { get; set; }
        public string CommentStatus { get; set; }
        public Nullable<System.DateTime> PublishedDate { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> ModificationDate { get; set; }
        public Nullable<bool> MinorEdit { get; set; }
    }
}
