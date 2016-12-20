using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OperaWebSites.Models
{
    public class Opera
    {
        public int OperaID { get; set; }
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [CheckValidYear]
        public int Year { get; set; }
        [Required]
        public string Composer { get; set; }
    }

    public class CheckValidYear:ValidationAttribute
    {
        public CheckValidYear()
        {
            ErrorMessage = "The earliest opera is by Dephne, 1598";
        }

        public override bool IsValid(object value)
        {
            int year = (int)value;
            if (year < 1598)
            {
                return false;
            }
            else
                return true;
        }
    }
}