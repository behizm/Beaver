using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beaver.Service.Data.Entities
{
    [Table("ProAccountings")]
    public class Accounting: BaseEntity
    {
        public double Debit { get; set; } // بدهکار

        public double Credit { get; set; } // بستانکار

        [StringLength(200)]
        public string Description { get; set; }


        [ForeignKey("Apartment")]
        public Guid? ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }

        [ForeignKey("Unit")]
        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }

        [ForeignKey("Cost")]
        public Guid? CostId { get; set; }
        public virtual Cost Cost { get; set; }
    }
}