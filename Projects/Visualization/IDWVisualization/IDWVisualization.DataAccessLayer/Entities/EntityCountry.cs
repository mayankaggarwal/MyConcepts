using IDWVisualization.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDWVisualization.DataAccessLayer.Entities
{
    [Table("tbl_entity_countries")]
    public class EntityCountry : IIdentifiableEntity
    {
        public int ID { get; set; }
        public string Country_Name { get; set; }
        public string Entity { get; set; }
        [NotMapped]
        public int EntityId
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
    }
}
