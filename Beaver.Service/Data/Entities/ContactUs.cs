using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beaver.Service.Data.Entities
{
    [Table("ProContactUses")]
    public class ContactUs: BaseEntity
    {
        [StringLength(50)]
        public string Email { get; set; }

        public string Body { get; set; }
    }
}