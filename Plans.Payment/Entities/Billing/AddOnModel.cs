using Akounto.Billing.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Plans.Payment.Entities.Billing
{
   public class AddOnModel: BaseEntity
    {
        public int? ID { get; set; }
        public int? PlanID { get; set; }
        public int? PlanDurationTypeId { get; set; }
        public int? DurationDays { get; set; }
        
        public string Description { get; set; }
        public decimal? Cost { get; set; }
        public decimal? FirstSubcriptionCode { get; set; }
        public int? Order { get; set; }
        public bool? IsActive { get; set; }

        public DateTime? Created { get; set; }
    }
}
