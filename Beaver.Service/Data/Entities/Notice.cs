using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beaver.Service.Data.Entities
{
    [Table("ProNotices")]
    public class Notice : BaseEntity
    {
        public NoticeType NoticeType { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public string Body { get; set; }


        [ForeignKey("Apartment")]
        public Guid? ApartmentId { get; set; }
        public virtual Apartment Apartment { get; set; }

        [ForeignKey("Unit")]
        public Guid? UnitId { get; set; }
        public virtual Unit Unit { get; set; }
    }

    public enum NoticeType
    {
        [Description("پیام عمومی")]
        PublicMessage,
        [Description("پیام شخصی")]
        PersonalMessage,
        [Description("اطلاعیه فوری")]
        ImmediateNotice,
        [Description("قوانین و مقررات")]
        Rules
    }
}