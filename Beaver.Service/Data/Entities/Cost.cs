using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beaver.Service.Data.Entities
{
    [Table("ProCosts")]
    public class Cost: BaseEntity
    {
        public CostType CostType { get; set; }

        public double Value { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public double? EmptyUnitRatio { get; set; }

        public bool IsDividingStaticBase { get; set; } // محاسبه بر اساس مبلغ ثابت
        public bool IsDividingUnitBase { get; set; } // محاسبه بر اساس هر واحد
        public bool IsDividingResidentCountBase { get; set; } // محاسبه بر اساس تعداد افراد
        public bool IsDividingAreaBase { get; set; } // محاسبه بر اساس متراژ


        public virtual ICollection<Accounting> Accountings { get; set; }
    }

    public enum CostType
    {
        [Description("قبض آب")]
        WaterBill = 11,
        [Description("قبض گاز")]
        GazBill = 12,
        [Description("قبض برق")]
        ElectricityBill = 13,
        [Description("قبض تلفن")]
        TelphoneBill = 14,
        [Description("هزینه نگهداری")]
        Maintenance = 31,
        [Description("هزینه نظافت")]
        Cleaning = 32,
        [Description("هزینه تعمیرات")]
        Repairs = 33,
        [Description("حقوق سرایدار")]
        JanitorWage = 34,
        [Description("هزینه شارژ")]
        PeriodicCharge = 51,
        [Description("هزینه های دیگر")]
        Others = 99
    }
}