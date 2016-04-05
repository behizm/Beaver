using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beaver.Service.Data.Entities
{
    [Table("ProApartmentInfs")]
    public class ApartmentInf : BaseEntity
    {
        [StringLength(50)]
        public string City { get; set; }

        [StringLength(300)]
        public string Address { get; set; }


        [Key, ForeignKey("Apartment")]
        public new Guid Id { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}