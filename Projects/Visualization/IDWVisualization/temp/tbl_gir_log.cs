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
    
    public partial class tbl_gir_log
    {
        public long ID { get; set; }
        public string LOG_ID { get; set; }
        public string LOG_AUTHOR { get; set; }
        public Nullable<System.DateTime> LOG_DATE { get; set; }
        public string ACTION_TYPE { get; set; }
        public string Field { get; set; }
        public string INITIAL_VALUE { get; set; }
        public string TARGET_VALUE { get; set; }
        public string LOG_ENTITY { get; set; }
        public string MODIFIED_CUID { get; set; }
        public string LOG_ORIGIN { get; set; }
    }
}