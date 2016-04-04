using System;
using System.ComponentModel.DataAnnotations;
using Beaver.Service.Utilities.GuidTools;

namespace Beaver.Service.Data.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            Id = GuidComb.GenerateComb();
            CreateDate = DateTime.Now;
        }

        [Key]
        public Guid Id { get; private set; }

        public DateTime CreateDate { get; private set; }
    }
}
