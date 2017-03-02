using System;
using System.Collections.Generic;

namespace EnterpriseApp.Models.GIR
{
    public class Category : IBaseEntity
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public string Mask { get; set; }
        public long? ParentID { get; set; }
        public bool Obsolete { get; set; }
        public bool GASSI { get; set; }
        public bool Directory { get; set; }
        public bool ForGUI { get; set; }
        public int LifeTime { get; set; }
        public bool BirthDateMandatory { get; set; }
        public bool Replaceable { get; set; }
        public int DURATION { get; set; }
        public bool Linked { get; set; }
        public bool GroupSubsidiary { get; set; }
        public bool Partner { get; set; }
        public bool Prefix { get; set; }

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
