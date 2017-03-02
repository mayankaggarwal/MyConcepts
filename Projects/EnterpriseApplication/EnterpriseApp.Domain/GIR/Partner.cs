using EnterpriseApp.Models;
using System;
using System.Collections.Generic;

namespace GIR.Entities
{
    public class Partner:IBaseEntity
    {
        public string Code { get; set; }
        public string Label { get; set; }
        public string AdminParameter { get; set; }
        public int ID { get; set; }

        object IBaseEntity.ID
        {
            get
            {
                return this.ID;
            }
            set
            {
                this.ID = (int)value;
            }
        }
    }
}
