//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Temp
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_ExportDetails
    {
        public long IDE_ID { get; set; }
        public Nullable<int> IDE_File_ID { get; set; }
        public string VCH_Operation { get; set; }
        public string VCH_Output_File_Name { get; set; }
        public string VCH_Status { get; set; }
        public string VCH_Comment { get; set; }
        public System.DateTime DAT_Execution_DateTime { get; set; }
    
        public virtual tbl_FileExportConfigDetails tbl_FileExportConfigDetails { get; set; }
    }
}