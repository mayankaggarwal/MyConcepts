using System;
using System.Collections.Generic;

namespace EnterpriseApp.Models.GIR
{
    public class GroupSubsidiary:IBaseEntity
    {
        public string Code { get; set; }
        public string Label { get; set; }
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
