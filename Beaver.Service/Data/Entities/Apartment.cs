using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beaver.Service.Data.Entities
{
    [Table("ProApartments")]
    public class Apartment : BaseEntity
    {
        [StringLength(100)]
        public string Name { get; set; }

        public int FloorCount { get; set; }

        public int UnitCount { get; set; }


        public virtual ApartmentInf ApartmentInf { get; set; }

        public virtual ICollection<Unit> Units { get; set; }

        public virtual ICollection<Connection> Connections { get; set; }

        public virtual ICollection<Accounting> Accountings { get; set; }

        public virtual ICollection<Notice> Notices { get; set; }
    }
}