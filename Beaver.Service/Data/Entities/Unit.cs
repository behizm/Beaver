using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beaver.Service.Data.Entities
{
    [Table("ProUnits")]
    public class Unit : BaseEntity
    {
        [StringLength(6)]
        public string Code { get; set; } // floor 2 unit 4 : f002u004

        public int FloorNumber { get; set; }

        public int UnitNumber { get; set; }

        public int? ResidentsCount { get; set; }

        public int? Area { get; set; }

        public DateTime? ResideDate { get; set; }

        public DateTime? VacateDate { get; set; }


        [ForeignKey("Apartment")]
        public Guid ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }

        public virtual ICollection<Connection> Connections { get; set; }

        public virtual ICollection<Accounting> Accountings { get; set; }

        public virtual ICollection<Notice> Notices { get; set; }
    }
}