using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "Picture")]
        public byte[] PhotoFile { get; set; }
        public string ImageMimeType { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="Created Date")]
        [DisplayFormat(DataFormatString="{0:MM/dd/yy}")]
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }

        public virtual List<Comment> Comments { get; set; }
   }
}