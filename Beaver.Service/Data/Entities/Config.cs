using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beaver.Service.Data.Entities
{
    [Table("ProConfigs")]
    public class Config: BaseEntity
    {
        [StringLength(50)]
        public string Key { get; set; }

        [StringLength(200)]
        public string Value { get; set; }
    }
}