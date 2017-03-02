using System;
using System.Collections.Generic;

namespace EnterpriseApp.Models.GIR
{
    public class Domain : IBaseEntity
    {
        public string Code { get; set; }
        public string ShortName { get; set; }
        public int ID { get; set; }
        public bool ReportingGlobal { get; set; }
        public bool Notif1 { get; set; }
        public bool Notif2 { get; set; }
        public bool Notif3 { get; set; }
        public bool Notif4 { get; set; }
        public bool Notif5 { get; set; }
        public bool Notif6 { get; set; }
        public bool Notif7 { get; set; }
        public string Mail { get; set; }
        public string Header { get; set; }
        public bool SupportHomonymyRule1 { get; set; }

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
