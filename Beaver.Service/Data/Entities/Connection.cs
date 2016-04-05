using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beaver.Service.Data.Entities
{
    [Table("ProConnections")]
    public class Connection : BaseEntity
    {
        public RelationshipType Type { get; set; }

        [StringLength(50)]
        public string Name { get; set; }


        [ForeignKey("User"), Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Apartment")]
        public Guid ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }

        [ForeignKey("Unit")]
        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }
    }

    public enum RelationshipType
    {
        [Description("مدیر")]
        Management = 11,
        [Description("مالک")]
        Landlord = 21,
        [Description("مستاجر")]
        Tenant = 22,
        [Description("وکیل")]
        Lawyer = 23
    }
}
