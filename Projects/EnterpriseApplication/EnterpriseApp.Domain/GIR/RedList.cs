using EnterpriseApp.Models;
using System;
using System.Collections.Generic;

namespace GIR.Entities
{
    public class RedList:IBaseEntity
    {
        public string CUID { get; set; }
        public DateTime EndDate { get; set; }
        public long ID { get; set; }
        public bool BIT_Deleted { get; set; }

        object IBaseEntity.ID
        {
            get
            {
                return this.ID;
            }
            set
            {
                this.ID = (long)value;
            }
        }
    }
}
